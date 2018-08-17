using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Datasets;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Carta_Cobranca : Form {
        private string _connection = gtiCore.Connection_Name();
        private bool _stop = false;

        public Carta_Cobranca() {
            InitializeComponent();
        }

        private void PrintButton_Click(object sender, EventArgs e) {
            if (CodigoInicio.Text == "") CodigoInicio.Text = "0";
            if (CodigoFinal.Text == "") CodigoFinal.Text = "0";
            int _codigo_ini = Convert.ToInt32(CodigoInicio.Text);
            int _codigo_fim = Convert.ToInt32(CodigoFinal.Text);
            if(_codigo_ini==0 || _codigo_fim==0)
                MessageBox.Show("Digite o código inicial e o código final.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if(_codigo_ini>_codigo_fim)
                    MessageBox.Show("Código inicial não pode ser maior que o código final.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else {
                    if (!gtiCore.IsDate(DataVencto.Text))
                        MessageBox.Show("Data de vencimento inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        if (Convert.ToDateTime(DataVencto.Text) > DateTime.Now)
                            MessageBox.Show("Data de vencimento tem que ser menor que a data atual.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            _stop = false;
                            gtiCore.Ocupado(this);
                            List<SpExtrato>Lista_Debitos= Gera_Matriz(_codigo_ini, _codigo_fim, Convert.ToDateTime(DataVencto.Text));
                            List<int> Lista_Codigos = Separa_Codigos(Lista_Debitos);
                            gtiCore.Liberado(this);
                            PrintReport(Lista_Debitos,Lista_Codigos);
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

        private List<SpExtrato> Gera_Matriz(int _codigo_ini,int _codigo_fim,DateTime _data_vencto) {
            int _total = _codigo_fim - _codigo_ini,_pos=1;
            List<SpExtrato> Lista_Resumo = new List<SpExtrato>();
            PBar.Value = 0;
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            for (int i = _codigo_ini; i < _codigo_fim+1; i++) {
                if (_stop) break;
                if (_pos % 10 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    Refresh();
                }

                List<SpExtrato> Lista_Extrato_Tributo = tributario_Class.Lista_Extrato_Tributo(i);
                if (Lista_Extrato_Tributo.Count == 0)
                    goto Proximo;
                List<SpExtrato> Lista_Extrato_Parcela = tributario_Class.Lista_Extrato_Parcela(Lista_Extrato_Tributo);
                foreach (SpExtrato item in Lista_Extrato_Parcela) {
                    if (item.Statuslanc == 3 && item.Codlancamento != 20 && item.Datavencimento <= _data_vencto) {
                        Lista_Resumo.Add(item);
                    }
                }
                
                Proximo:;
                _pos++;
            }

            List<SpExtrato> Lista_Final = new List<SpExtrato>();
            foreach (SpExtrato item in Lista_Resumo) {
                bool _find = false;
                int _index = 0;
                foreach (SpExtrato item2 in Lista_Final) {
                    if(item.Codreduzido==item2.Codreduzido && item.Anoexercicio == item2.Anoexercicio) {
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


            PBar.Value = 100;
            return Lista_Final;
        }

        private void Carta_Cobranca_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                if (MessageBox.Show("Deseja cancelar a rotina?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    _stop=true;
                }
            }
        }

        private List<int> Separa_Codigos(List<SpExtrato> Lista) {
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
        }

        private void PrintReport(List<SpExtrato>Lista_Debitos,List<int>Lista_Codigos) {
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


    }
}
