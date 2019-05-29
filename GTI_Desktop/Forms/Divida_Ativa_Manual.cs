using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;
using static GTI_Desktop.Classes.gtiCore;

namespace GTI_Desktop.Forms {
    public partial class Divida_Ativa_Manual : Form {
        public int ReturnValue { get; set; }
        int _codigo, _UserId;
        string _connection = gtiCore.Connection_Name();
        string _connection_integrativa = gtiCore.Connection_Name("GTI_Integrativa");

        public Divida_Ativa_Manual(List<SpExtrato> Lista) {
            InitializeComponent();
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Tributario_bll tributario_Class = new Tributario_bll(_connection);

            _UserId = sistema_Class.Retorna_User_LoginId(gtiCore.Retorna_Last_User());

            _codigo = Lista[0].Codreduzido;
            int _lanc = Convert.ToInt32(Lista[0].Desclancamento.Substring(0, 2));
            Tipolivro _tipo_livro = tributario_Class.Retorna_Tipo_Livro_Divida_Ativa(_lanc);
            if (_tipo_livro == null)
                LivroText.Text = "0 - LIVRO NÃO CADASTRADO";
            else
                LivroText.Text = _tipo_livro.Codtipo.ToString() + " - " + _tipo_livro.Desctipo;

            foreach (SpExtrato item in Lista) {
                _lanc = Convert.ToInt32(item.Desclancamento.Substring(0, 2));
                _tipo_livro = tributario_Class.Retorna_Tipo_Livro_Divida_Ativa(_lanc);

                ListViewItem lv = new ListViewItem(item.Anoexercicio.ToString());
                lv.SubItems.Add(item.Desclancamento);
                lv.SubItems.Add(item.Seqlancamento.ToString());
                lv.SubItems.Add(item.Numparcela.ToString());
                lv.SubItems.Add(item.Codcomplemento.ToString());
                lv.SubItems.Add(item.Datavencimento.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(item.Valortributo.ToString("#0.00"));
                lv.SubItems.Add(_tipo_livro==null?"0":_tipo_livro.Codtipo.ToString());
                MainListView.Items.Add(lv);

                DataInscricaoText.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        private void SairButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OKButton_Click(object sender, EventArgs e) {
            List<int> _lista = new List<int>();
            foreach (ListViewItem linha in MainListView.Items) {
                int _tipo = Convert.ToInt32(linha.SubItems[7].Text);
                if (_lista.Count == 0)
                    _lista.Add(_tipo);
                else {
                    foreach (int item in _lista) {
                        if (item != _tipo) {
                            _lista.Add(item);
                            break;
                        }
                    }
                }
            }

            if (_lista.Count > 1)
                MessageBox.Show("Não é possível escrever em dívida ativa lançamentos que pertencem a livros diferentes.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (Convert.ToInt32(LivroText.Text.Substring(0, 1)) == 0)
                    MessageBox.Show("Nenhum livro selecionado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    DateTime _data;
                    if (!DateTime.TryParseExact(DataInscricaoText.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _data)) {
                        MessageBox.Show("Data de Inscrição inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } else {
                        Grava_Dados();
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
        }

        private void Grava_Dados() {
            string _nome = "", _inscricao = "", _endereco = "", _complemento = "", _bairro = "", _cidade = "", _uf = "", _cep = "",_quadra="",_lote="";
            string _endereco_entrega = "", _complemento_entrega = "", _bairro_entrega = "", _cidade_entrega = "", _uf_entrega = "",_tipo_divida;
            int _numero = 0,_numero_entrega=0;
            LocalEndereco _tipo_cadastro;

            _tipo_cadastro = _codigo < 100000 ? LocalEndereco.Imovel : (_codigo >= 100000 && _codigo < 500000) ? LocalEndereco.Empresa : LocalEndereco.Cidadao;

            if (_tipo_cadastro == LocalEndereco.Imovel) {
                Imovel_bll imovel_Class = new Imovel_bll(_connection);
                ImovelStruct _imovel = imovel_Class.Dados_Imovel(_codigo);
                _nome = _imovel.Proprietario_Nome;
                _inscricao = _imovel.Inscricao;
                _endereco = _imovel.NomeLogradouro;
                _numero = (int)_imovel.Numero;
                _complemento = _imovel.Complemento;
                _bairro = _imovel.NomeBairro;
                _cidade = "JABOTICABAL";
                _uf = "SP";
            } else {
                if (_tipo_cadastro == LocalEndereco.Empresa) {
                    Empresa_bll empresa_Class = new Empresa_bll(_connection);
                    EmpresaStruct _empresa = empresa_Class.Retorna_Empresa(_codigo);
                    _nome = _empresa.Razao_social;
                    _inscricao = _empresa.Inscricao_estadual;
                    _endereco = _empresa.Endereco_nome;
                    _numero = (int)_empresa.Numero;
                    _complemento = _empresa.Complemento;
                    _bairro = _empresa.Bairro_nome;
                    _cidade = _empresa.Cidade_nome;
                    _uf = _empresa.UF;
                } else {
                    Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
                    CidadaoStruct _cidadao = cidadao_Class.Dados_Cidadao(_codigo);
                    _nome = _cidadao.Nome;
                    _inscricao = _codigo.ToString();
                    if (_cidadao.EtiquetaC == "S") {
                        if (_cidadao.CodigoCidadeC == 413) {
                            _endereco = _cidadao.EnderecoC.ToString();
                            Endereco_bll endereco_Class = new Endereco_bll(_connection);
                            if (_cidadao.NumeroC == null || _cidadao.NumeroC == 0 || _cidadao.CodigoLogradouroC == null || _cidadao.CodigoLogradouroC==0)
                                _cep = "14870000";
                            else 
                            _cep = endereco_Class.RetornaCep((int)_cidadao.CodigoLogradouroC,  Convert.ToInt16(_cidadao.NumeroC)).ToString("00000000");
                        } else {
                            _endereco = _cidadao.CodigoCidadeC.ToString();
                            _cep =  _cidadao.CepC.ToString();
                        }
                        _numero =(int)_cidadao.NumeroC;
                        _complemento = _cidadao.ComplementoC;
                        _bairro = _cidadao.NomeBairroC;
                        _cidade = _cidadao.NomeCidadeC;
                        _uf = _cidadao.UfC;
                    } else {
                        if (_cidadao.CodigoCidadeR == 413) {
                            _endereco = _cidadao.EnderecoR.ToString();
                            Endereco_bll endereco_Class = new Endereco_bll(_connection);
                            if (_cidadao.NumeroR == null || _cidadao.NumeroR == 0 || _cidadao.CodigoLogradouroR == null || _cidadao.CodigoLogradouroR == 0)
                                _cep = "14870000";
                            else
                                _cep = endereco_Class.RetornaCep((int)_cidadao.CodigoLogradouroR, Convert.ToInt16(_cidadao.NumeroR)).ToString("00000000");
                        } else {
                            _endereco = _cidadao.CodigoCidadeR.ToString();
                            _cep = _cidadao.CepR.ToString();
                        }
                        _numero = (int)_cidadao.NumeroR;
                        _complemento = _cidadao.ComplementoR;
                        _bairro = _cidadao.NomeBairroR;
                        _cidade = _cidadao.NomeCidadeR;
                        _uf = _cidadao.UfR;
                    }
                }
            }





            foreach (ListViewItem linha in MainListView.Items) {

            }
        }

    }
}
