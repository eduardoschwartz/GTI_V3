using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Datasets;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static GTI_Models.modelCore;

namespace GTI_Desktop.Forms {
    public partial class Carta_Cobranca : Form {
        private string _connection = gtiCore.Connection_Name();
        private bool _stop = false;

        public Carta_Cobranca() {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, EventArgs e) {
            PrintReport();
        }

        private void CalcularButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Efetuar o cálculo das cartas de cobrança?", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.No) return;

            if (CodigoInicio.Text == "") CodigoInicio.Text = "0";
            if (CodigoFinal.Text == "") CodigoFinal.Text = "0";
            int _codigo_ini = Convert.ToInt32(CodigoInicio.Text);
            int _codigo_fim = Convert.ToInt32(CodigoFinal.Text);
            if (_codigo_ini == 0 || _codigo_fim == 0)
                MessageBox.Show("Digite o código inicial e o código final.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (_codigo_ini > _codigo_fim)
                    MessageBox.Show("Código inicial não pode ser maior que o código final.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (!gtiCore.IsDate(DataVencto.Text))
                        MessageBox.Show("Data de vencimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        if (Convert.ToDateTime(DataVencto.Text) > DateTime.Now)
                            MessageBox.Show("Data de vencimento tem que ser menor que a data atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            _stop = false;
                            gtiCore.Ocupado(this);
                            Gera_Matriz(_codigo_ini, _codigo_fim, Convert.ToDateTime(DataVencto.Text));
                            gtiCore.Liberado(this);
                            PrintReport();
                        }
                    }
                }
            }
        }

        private void CodigoInicioText_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void CodigoFinalText_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Gera_Matriz(int _codigo_ini,int _codigo_fim,DateTime _data_vencto) {
            int _total = _codigo_fim - _codigo_ini+1,_pos=1,_numero_documento=16453214;
            short _remessa = 1;
            List<SpExtrato> Lista_Resumo = new List<SpExtrato>();
            List<SpExtrato> Lista_Final = new List<SpExtrato>();

            //Exclui a remessa se já existir
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);

            Exception ex = tributario_Class.Excluir_Carta_Cobranca(_remessa);
            if (ex != null) {
                ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                eBox.ShowDialog();
            }

            PBar.Value = 0;
            
            for (int _codigo_atual = _codigo_ini; _codigo_atual < _codigo_fim+1; _codigo_atual++) {
                if (_stop) break;
                if (_pos % 10 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    Refresh();
                }

                List<SpExtrato> Lista_Extrato_Tributo = tributario_Class.Lista_Extrato_Tributo(Codigo: _codigo_atual,Status1:3,Status2:3);
                if (Lista_Extrato_Tributo.Count == 0)
                    goto Proximo;
                List<SpExtrato> Lista_Extrato_Parcela = tributario_Class.Lista_Extrato_Parcela(Lista_Extrato_Tributo);
                Lista_Resumo.Clear();
                foreach (SpExtrato item in Lista_Extrato_Parcela) {
                    if (item.Statuslanc == 3 && item.Codlancamento != 20 && item.Datavencimento <= _data_vencto) {
                        Lista_Resumo.Add(item);
                    }
                }

                if (Lista_Resumo.Count == 0)
                    goto Proximo;

                Lista_Final.Clear();
                foreach (SpExtrato item in Lista_Resumo) {
                    bool _find = false;
                    int _index = 0;
                    foreach (SpExtrato item2 in Lista_Final) {
                        if (item.Anoexercicio == item2.Anoexercicio) {
                            _find = true;
                            break;
                        }
                        _index++;
                    }
                    if (_find) {
                        Lista_Final[_index].Valortributo += item.Valortributo;
                        Lista_Final[_index].Valorjuros += item.Valorjuros;
                        Lista_Final[_index].Valormulta += item.Valormulta;
                        Lista_Final[_index].Valorcorrecao += item.Valorcorrecao;
                        Lista_Final[_index].Valortotal += item.Valortotal;
                    } else {
                        SpExtrato reg = new SpExtrato();
                        reg.Codreduzido = item.Codreduzido;
                        reg.Anoexercicio = item.Anoexercicio;
                        reg.Valortributo = item.Valortributo;
                        reg.Valorjuros = item.Valorjuros;
                        reg.Valormulta = item.Valormulta;
                        reg.Valorcorrecao = item.Valorcorrecao;
                        reg.Valortotal = item.Valorcorrecao;
                        Lista_Final.Add(reg);
                    }
                }
                if (Lista_Final.Count == 0)
                    goto Proximo;
                
                //Soma o boleto
                decimal _valor_boleto = 0;
                foreach (SpExtrato item in Lista_Final) {
                    _valor_boleto += item.Valortotal;
                }

                //Dados contribuinte
                string _nome = "", _cpfcnpj = "", _endereco = "", _bairro = "", _cidade = "", _cep = "", _inscricao = "", _lote = "", _quadra = "", _atividade = "",  _convenio = "2873532",_complemento="";
                Contribuinte_Header_Struct dados = sistema_Class.Contribuinte_Header(_codigo_atual);
                TipoCadastro _tipo = dados.Tipo;
                _nome = dados.Nome;
                _cpfcnpj = dados.Cpf_cnpj;
                _inscricao = dados.Inscricao;
                _complemento = dados.Complemento == "" ? "" : " " + dados.Complemento;
                _endereco = dados.Endereco + ", " + dados.Numero.ToString() +  _complemento;
                _bairro = dados.Nome_bairro;
                _cidade = dados.Nome_cidade + "/" + dados.Nome_uf;
                _cep = dados.Cep;
                _lote = dados.Lote_original;
                _quadra = dados.Quadra_original;
                _atividade = dados.Atividade;

                //Endereço de Entrega
                if (_tipo == TipoCadastro.Imovel) {
                    EnderecoStruct endImovel = imovel_Class.Dados_Endereco(_codigo_atual, bllCore.TipoEndereco.Entrega);
                } else {
                    if (_tipo == TipoCadastro.Empresa) {
                        mobiliarioendentrega endEmpresa = empresa_Class.Empresa_Endereco_entrega(_codigo_atual);
                    } else {
                        if (_tipo == TipoCadastro.Cidadao) {
                            CidadaoStruct endCidadao = cidadao_Class.LoadReg(_codigo_atual);
                        }
                    }
                }


                //Se não tiver CEP ou CPF grava exclusão e passa para o próximo
                if(_cpfcnpj=="" || _cep == "") {
                    Carta_cobranca_exclusao regE = new Carta_cobranca_exclusao();
                    regE.Remessa = _remessa;
                    regE.Codigo = _codigo_atual;
                    ex = tributario_Class.Insert_Carta_Cobranca_Exclusao(regE);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    }
                    goto Proximo;
                }

                //****** GRAVA HEADER **************

                Carta_cobranca Reg = new Carta_cobranca();
                Reg.Remessa = _remessa;
                Reg.Codigo = _codigo_atual;
                Reg.Parcela = 1;
                Reg.Total_Parcela = 1;
                Reg.Parcela_Label = Reg.Parcela.ToString("00") + "/" + Reg.Total_Parcela.ToString("00");
                Reg.Nome = _nome;
                Reg.Cpf_cnpj = _cpfcnpj;
                Reg.Endereco = _endereco;
                Reg.Bairro = _bairro;
                Reg.Cidade = _cidade;
                Reg.Cep = _cep;
                Reg.Data_Vencimento = Convert.ToDateTime("25/10/2018");
                Reg.Data_Documento = DateTime.Now;
                Reg.Inscricao = _inscricao;
                Reg.Lote = _lote;
                Reg.Quadra = _quadra;
                Reg.Atividade = _atividade;
                Reg.Numero_Documento = _numero_documento;
                Reg.Nosso_Numero = _convenio + _numero_documento.ToString("0000000000");
                Reg.Valor_Boleto = _valor_boleto;
                ex = tributario_Class.Insert_Carta_Cobranca(Reg);
                if (ex != null) {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    eBox.ShowDialog();
                }
                _numero_documento++;

                //**********************************
                Proximo:;
                _pos++;
            }

            PBar.Value = 100;
            return;
        }

        private void Carta_Cobranca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                if (MessageBox.Show("Deseja cancelar a rotina?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    _stop=true;
                }
            }
        }

       /* private List<int> Separa_Codigos(List<SpExtrato> Lista) {
            List<int> ListaCodigo = new List<int>();
            foreach (SpExtrato item in Lista) {
                bool _find = false;
                for (int i = 0; i < ListaCodigo.Count; i++) {
                    if (ListaCodigo[i] == item.Codreduzido) {
                        _find = true;
                        break;
                    }
                }
                if (!_find)
                    ListaCodigo.Add(item.Codreduzido);
            }

            return ListaCodigo;
        }*/

        private void PrintReportOLD(List<SpExtrato>Lista_Debitos,List<int>Lista_Codigos) {
            gtiCore.Ocupado(this);
            dsCartaCobranca Ds = new dsCartaCobranca();
            dsCartaCobranca.CartaCobrancaTableDataTable dTable = new dsCartaCobranca.CartaCobrancaTableDataTable();
            dsCartaCobranca.CartaCobrancaHeaderTableDataTable dTableHeader = new dsCartaCobranca.CartaCobrancaHeaderTableDataTable();

            for (int i = 0; i < Lista_Codigos.Count; i++) {
                DataRow dRow = dTableHeader.NewRow();
                dRow["Codigo"] = Lista_Codigos[i];
                dRow["Grupo"] = 1;
                dRow["Nome"] = "Kelly Debby";
                dTableHeader.Rows.Add(dRow);
            }


            foreach (SpExtrato item in Lista_Debitos) {
                DataRow dRow = dTable.NewRow();
                dRow["Codigo"] = item.Codreduzido;
                dRow["Ano"] = item.Anoexercicio;
                dRow["Valor_Tributo"] = item.Valortributo;
                dRow["Valor_Juros"] = item.Valorjuros;
                dRow["Valor_Multa"] = item.Valormulta;
                dRow["Valor_Correcao"] =item.Valorcorrecao;
                dTable.Rows.Add(dRow);
            }
            Ds.Tables.RemoveAt(0);
            Ds.Tables.RemoveAt(0);
            Ds.Tables.Add(dTable);
            Ds.Tables.Add(dTableHeader);

            gtiCore.Liberado(this);
            ReportCR fRpt = new ReportCR("Carta_Cobranca_Envelope", null,Ds);
            fRpt.ShowDialog();


        }

        private void PrintReport() {
            ReportCR fRpt = new ReportCR("Carta_Cobranca_Envelope", null, null);
            fRpt.ShowDialog();
        }

    }
}
