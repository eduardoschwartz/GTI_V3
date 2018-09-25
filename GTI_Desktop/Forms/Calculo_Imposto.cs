using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Calculo_Imposto : Form {
        string _connection = gtiCore.Connection_Name();
        string _path = @"c:\cadastro\bin\";
        int _ano = 2019;
        int _documento = 19555444;

        private enum Tipo_imposto {
            Iptu = 1,
            Vigilancia=5
        }

        public Calculo_Imposto() {
            InitializeComponent();
        }

        private void Calculo_Imposto_Load(object sender, EventArgs e) {
            ImpostoList.SelectedIndex = 0;
        }

        private void ExecutarButton_Click(object sender, EventArgs e) {
            ExecutarButton.Enabled = false;
            gtiCore.Ocupado(this);
            switch (ImpostoList.SelectedIndex) {
                case 0:
                    Calculo_Iptu();
                    break;
                case 1:
                    Calculo_IssTll();
                    break;
                case 2:
                    Calculo_Vigilancia();
                    break;
                default:
                    break;
            }
            gtiCore.Liberado(this);
            ExecutarButton.Enabled = true;
        }

        private void Calculo_Iptu() {

        }

        private void Calculo_IssTll() {

        }

        private void Calculo_Vigilancia() {

            FileStream fsDP = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs1 = new StreamWriter(fsDP, System.Text.Encoding.Default);
            FileStream fsDT = new FileStream(_path + "DEBITOTRIBUTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs2 = new StreamWriter(fsDT, System.Text.Encoding.Default);
            FileStream fsPD = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs3 = new StreamWriter(fsPD, System.Text.Encoding.Default);
            FileStream fsND = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs4 = new StreamWriter(fsND, System.Text.Encoding.Default);
            FileStream fsCC = new FileStream(_path + "CALCULO_ISS_VS.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter fs5 = new StreamWriter(fsCC, System.Text.Encoding.Default);


            MsgToolStrip.Text = "Calculando vigilância sanitária";
            List<DateTime> aVencimento = new List<DateTime>();
            List<decimal> aDesconto = new List<decimal>();
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Paramparcela _Prm = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)Tipo_imposto.Vigilancia);
            if( _Prm.Venc01 != null) {
                aVencimento.Add((DateTime)_Prm.Venc01);
                if(_Prm.Descontounica!=null)
                    aDesconto.Add((decimal)_Prm.Descontounica);
                if (_Prm.Venc02 != null) {
                    aVencimento.Add((DateTime)_Prm.Venc02);
                    if (_Prm.Descontounica2 != null)
                        aDesconto.Add((decimal)_Prm.Descontounica2);
                    if (_Prm.Venc03 != null) {
                        aVencimento.Add((DateTime)_Prm.Venc03);
                        if (_Prm.Descontounica3 != null)
                            aDesconto.Add((decimal)_Prm.Descontounica3);
                        if (_Prm.Venc04 != null) {
                            aVencimento.Add((DateTime)_Prm.Venc04);
                        }
                    }
                }
            }

            int _qtde_parcelas = aVencimento.Count;
            bool _unica = _Prm.Parcelaunica == "S" ? true : false;

            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<Mobiliarioatividadevs2> ListaEmpresas = empresa_Class.Lista_Empresas_Vigilancia_Sanitaria();
            List<Mobiliarioatividadevs2> ListaVS = new List<Mobiliarioatividadevs2>();
            foreach (Mobiliarioatividadevs2 item in ListaEmpresas) {
                bool _find = false;
                for (int i = 0; i < ListaVS.Count; i++) {
                    if (item.Codmobiliario == ListaVS[i].Codmobiliario) {
                        _find = true;
                        ListaVS[i].Valor += item.Valor * item.Qtde;
                        break;
                    }
                }
                
                if (!_find) {
                    Mobiliarioatividadevs2 reg = new Mobiliarioatividadevs2();
                    reg.Codmobiliario = item.Codmobiliario;
                    reg.Qtde = item.Qtde;
                    reg.Valor = item.Valor;
                    ListaVS.Add(reg);
                }
            }

            int _total = ListaVS.Count, _pos = 1;
            string _documento0="", _documento1="", _documento2="", _documento3="", _documento4="", _valor0="", _valor1="";
            string _vencimento0="", _vencimento1="", _vencimento2="", _vencimento3="", _vencimento4="";

            foreach (Mobiliarioatividadevs2 item in ListaVS) {

                if (_pos % 10 == 0) {
                    PBar.Value = _pos * 100 / _total;
                    PBar.Update();
                    Refresh();
                    Application.DoEvents();
                }

                for (int _parcela = 0; _parcela <= _qtde_parcelas; _parcela++) {
                    string _vencto =  _parcela==0 ? aVencimento[0].ToString("MM/dd/yyyy"):   aVencimento[_parcela-1].ToString("MM/dd/yyyy");
                    string _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0,18," + _vencto + ",01/01/" + _ano ;
                    fs1.WriteLine(_linha);
                    decimal _valor = item.Valor, _valor_unica = item.Valor - (item.Valor * (decimal)0.05);
                    decimal _valor_parcela = _parcela > 0 ? _valor : _valor_unica;
                    _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0,25," + gtiCore.Virg2Ponto(gtiCore.RemovePonto(string.Format("{0:0.00}", _valor_parcela))) ;
                    fs2.WriteLine(_linha);
                    _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0," + _documento;
                    fs3.WriteLine(_linha);
                    _linha = _documento + "," + DateTime.Now.ToString("MM/dd/yyyy");
                    fs4.WriteLine(_linha);

                    switch (_parcela) {
                        case 0:
                            _documento0 = _documento.ToString();
                            _vencimento0 = _vencto.ToString();
                            _valor0 = gtiCore.Virg2Ponto(gtiCore.RemovePonto(string.Format("{0:0.00}", _valor_parcela)));
                            break;
                        case 1:
                            _documento1 = _documento.ToString();
                            _vencimento1 = _vencto.ToString();
                            _valor1 = gtiCore.Virg2Ponto(gtiCore.RemovePonto(string.Format("{0:0.00}", _valor_parcela)));
                            break;
                        case 2:
                            _documento2 = _documento.ToString();
                            _vencimento2 = _vencto.ToString();
                            break;
                        case 3:
                            _documento3 = _documento.ToString();
                            _vencimento3 = _vencto.ToString();
                            break;
                        case 4:
                            _documento4 = _documento.ToString();
                            _vencimento4 = _vencto.ToString();
                            break;
                        default:
                            break;
                    }

                    _documento++;
                }

                string _linha_calc = _ano.ToString() + "," + item.Codmobiliario + ",13," + _valor0 + "," + _valor1 + "," +
                    _documento0 + "," + _vencimento0 + "," + _documento1 + "," + _vencimento1 + "," + _documento2 + ',' + _vencimento2 + "," + _documento3 + "," +
                    _vencimento3 + "," + _documento4 + "," + _vencimento4 + "," + _qtde_parcelas.ToString();
                fs5.WriteLine(_linha_calc);

                _pos++;
            }

            fs1.Close(); fs2.Close(); fs3.Close(); fs4.Close();fs5.Close() ; fsDP.Close(); fsDT.Close(); fsND.Close(); fsPD.Close();fsCC.Close();

            PBar.Value = 100;
            PBar.Update();
            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            Refresh();

            MessageBox.Show("Cálculo finalizado.","Infiormação",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ExportarButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Exportar para o banco de dados?", "Confimação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            Tributario_bll tributario_Class = new Tributario_bll(_connection);

            DataTable dtDP = new DataTable();
            dtDP.Columns.Add("codreduzido", typeof(int));
            dtDP.Columns.Add("anoexercicio", typeof(short));
            dtDP.Columns.Add("codlancamento", typeof(short));
            dtDP.Columns.Add("seqlancamento", typeof(short));
            dtDP.Columns.Add("numparcela", typeof(byte));
            dtDP.Columns.Add("codcomplemento", typeof(byte));
            dtDP.Columns.Add("statuslanc", typeof(byte));
            dtDP.Columns.Add("datavencimento", typeof(DateTime));
            dtDP.Columns.Add("datadebase", typeof(DateTime));

            FileStream fsDP = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Open, FileAccess.Read);
            StreamReader fs1 = new StreamReader(fsDP, System.Text.Encoding.Default);
            while (!fs1.EndOfStream) {
                string _line = fs1.ReadLine();
                string[] _fields = _line.Split(',');
                DataRow _row = dtDP.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["statuslanc"] = Convert.ToByte(_fields[6]);
                _row["datavencimento"] =Convert.ToDateTime( _fields[7]);
                _row["datadebase"] = Convert.ToDateTime(_fields[8]);
                dtDP.Rows.Add(_row);
            }

            MsgToolStrip.Text = "Inserindo parcelas";
            Refresh();
            SqlBulkCopy sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOPARCELA";
            sbc.WriteToServer(dtDP);
            sbc.Close();
            dtDP.Dispose(); fsDP.Close(); fs1.Close();

            MsgToolStrip.Text = "Inserindo tributos";
            Refresh();


            DataTable dtDT = new DataTable();
            dtDT.Columns.Add("codreduzido", typeof(int));
            dtDT.Columns.Add("anoexercicio", typeof(short));
            dtDT.Columns.Add("codlancamento", typeof(short));
            dtDT.Columns.Add("seqlancamento", typeof(short));
            dtDT.Columns.Add("numparcela", typeof(byte));
            dtDT.Columns.Add("codcomplemento", typeof(byte));
            dtDT.Columns.Add("codtributo", typeof(short));
            dtDT.Columns.Add("valortributo", typeof(decimal));

            DataTable dtPD = new DataTable();
            dtPD.Columns.Add("codreduzido", typeof(int));
            dtPD.Columns.Add("anoexercicio", typeof(short));
            dtPD.Columns.Add("codlancamento", typeof(short));
            dtPD.Columns.Add("seqlancamento", typeof(short));
            dtPD.Columns.Add("numparcela", typeof(byte));
            dtPD.Columns.Add("codcomplemento", typeof(byte));
            dtPD.Columns.Add("numdocumento", typeof(int));



            //Calculo_iss_vs reg_iss = new Calculo_iss_vs {
            //    Ano = (short)_ano,
            //    Lancamento = 13,
            //    Qtde_parcela = (byte)_qtde_parcelas
            //};

            //reg_iss.Codigo = item.Codmobiliario;
            //switch (_parcela) {
            //    case 0:
            //        reg_iss.Documento0 = _documento;
            //        reg_iss.Vencimento0 = Convert.ToDateTime(_vencto);
            //        reg_iss.Valor0 = _valor_parcela;
            //        break;
            //    case 1:
            //        reg_iss.Documento1 = _documento;
            //        reg_iss.Vencimento1 = Convert.ToDateTime(_vencto);
            //        reg_iss.Valor1 = _valor_parcela;
            //        break;
            //    case 2:
            //        reg_iss.Documento2 = _documento;
            //        reg_iss.Vencimento2 = Convert.ToDateTime(_vencto);
            //        break;
            //    case 3:
            //        reg_iss.Documento3 = _documento;
            //        reg_iss.Vencimento3 = Convert.ToDateTime(_vencto);
            //        break;
            //    case 4:
            //        reg_iss.Documento4 = _documento;
            //        reg_iss.Vencimento4 = Convert.ToDateTime(_vencto);
            //        break;
            //    default:
            //        break;
            //}

            //Exception ex = tributario_Class.Insert_Calculo_Iss_VS(reg_iss);
            //if (ex != null) {
            //    ErrorBox eBox = new ErrorBox("Erro", ex.Message, ex);
            //    eBox.ShowDialog();
            //}





            //MsgToolStrip.Text = "Inserindo tributos";
            //Refresh();
            //sbc = new SqlBulkCopy(_connection);
            //sbc.BulkCopyTimeout = 0;
            //sbc.DestinationTableName = "DEBITOTRIBUTO";
            //sbc.WriteToServer(dtDT);
            //sbc.Close();

            //MsgToolStrip.Text = "Inserindo parcelas por documento";
            //Refresh();
            //sbc = new SqlBulkCopy(_connection);
            //sbc.BulkCopyTimeout = 0;
            //sbc.DestinationTableName = "PARCELADOCUMENTO";
            //sbc.WriteToServer(dtPD);
            //sbc.Close();


        }



    }
}
