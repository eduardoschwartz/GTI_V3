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

            DataTable dtDT = new DataTable();
            dtDT.Columns.Add("codreduzido", typeof(int));
            dtDT.Columns.Add("anoexercicio", typeof(short));
            dtDT.Columns.Add("codlancamento", typeof(short));
            dtDT.Columns.Add("seqlancamento", typeof(short));
            dtDT.Columns.Add("numparcela", typeof(byte));
            dtDT.Columns.Add("codcomplemento", typeof(byte));
            dtDT.Columns.Add("codtributo", typeof(short));
            dtDT.Columns.Add("valortributo", typeof(decimal));


            foreach (Mobiliarioatividadevs2 item in ListaVS) {
                for (int _parcela = 0; _parcela <= _qtde_parcelas; _parcela++) {

                    string _vencto =  _parcela==0 ? aVencimento[0].ToString("MM/dd/yyyy"):   aVencimento[_parcela-1].ToString("MM/dd/yyyy");
                    decimal _valor = item.Valor, _valor_unica = item.Valor - (item.Valor * (decimal)0.05);
                    decimal _valor_parcela = _parcela == 0 ? _valor : _valor_unica;

                    dtDP.Rows.Add(item.Codmobiliario,_ano,13,0,_parcela,0,18,Convert.ToDateTime(_vencto),Convert.ToDateTime("01/01/"+_ano.ToString()));
                    dtDT.Rows.Add(item.Codmobiliario, _ano, 13, 0, _parcela, 0, 25,_valor_parcela);
//                    _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0,25," + gtiCore.Virg2Ponto( gtiCore.RemovePonto( string.Format("{0:0.00}", _valor_parcela))) + ",0,0,0";
  //                  _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0," + _documento  ;
    //                _linha = _documento + ",'" + DateTime.Now.ToString("MM/dd/yyyy") ;
                    _documento++;
                }
            }

            MsgToolStrip.Text = "Inserindo Débitos";
            SqlBulkCopy sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOPARCELA";
            sbc.WriteToServer(dtDP);
            sbc.Close();

            MsgToolStrip.Text = "Inserindo Tributos";
            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOTRIBUTO";
            sbc.WriteToServer(dtDT);
            sbc.Close();

            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            MessageBox.Show("Cálculo finalizado.","Infiormação",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        private void Calculo_Vigilancia_Old() {
            //FileStream fsDP = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Create, FileAccess.Write);
            //StreamWriter fs1 = new StreamWriter(fsDP, System.Text.Encoding.Default);
            //FileStream fsDT = new FileStream(_path + "DEBITOTRIBUTO.TXT",FileMode.Create,FileAccess.Write);
            //StreamWriter fs2 = new StreamWriter(fsDT, System.Text.Encoding.Default);
            //FileStream fsPD = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            //StreamWriter fs3 = new StreamWriter(fsPD, System.Text.Encoding.Default);
            //FileStream fsND = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Create, FileAccess.Write);
            //StreamWriter fs4 = new StreamWriter(fsND, System.Text.Encoding.Default);

            List<DateTime> aVencimento = new List<DateTime>();
            List<decimal> aDesconto = new List<decimal>();
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Paramparcela _Prm = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)Tipo_imposto.Vigilancia);
            if (_Prm.Venc01 != null) {
                aVencimento.Add((DateTime)_Prm.Venc01);
                if (_Prm.Descontounica != null)
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

            DataTable dtP = new DataTable();
            dtP.Columns.Add("codreduzido", typeof(int));
            dtP.Columns.Add("anoexercicio", typeof(short));
            dtP.Columns.Add("codlancamento", typeof(short));
            dtP.Columns.Add("seqlancamento", typeof(short));
            dtP.Columns.Add("numparcela", typeof(byte));
            dtP.Columns.Add("codcomplemento", typeof(byte));
            dtP.Columns.Add("statuslanc", typeof(byte));
            dtP.Columns.Add("datavencimento", typeof(DateTime));
            dtP.Columns.Add("datadebase", typeof(DateTime));

            foreach (Mobiliarioatividadevs2 item in ListaVS) {
                for (int _parcela = 0; _parcela <= _qtde_parcelas; _parcela++) {

                    string _vencto = _parcela == 0 ? aVencimento[0].ToString("MM/dd/yyyy") : aVencimento[_parcela - 1].ToString("MM/dd/yyyy");
                    string _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0,18," + _vencto + ",01/01/" + _ano + ",1";

                    dtP.Rows.Add(item.Codmobiliario, _ano, 13, 0, _parcela, 0, 18, Convert.ToDateTime(_vencto), Convert.ToDateTime("01/01/" + _ano.ToString()));



                    //                    fs1.WriteLine(_linha);

                    decimal _valor = item.Valor, _valor_unica = item.Valor - (item.Valor * (decimal)0.05);
                    decimal _valor_parcela = _parcela == 0 ? _valor : _valor_unica;
                    _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0,25," + gtiCore.Virg2Ponto(gtiCore.RemovePonto(string.Format("{0:0.00}", _valor_parcela))) + ",0,0,0";
                    //                    fs2.WriteLine(_linha);

                    _linha = item.Codmobiliario + "," + _ano + ",13,0," + _parcela + ",0," + _documento;
                    //                    fs3.WriteLine(_linha);

                    _linha = _documento + ",'" + DateTime.Now.ToString("MM/dd/yyyy");
                    //                    fs4.WriteLine(_linha);

                    _documento++;
                }
            }

            //           fs1.Close();fs2.Close();fs3.Close();fs4.Close();fsDP.Close();fsDT.Close();fsND.Close();fsPD.Close();


            // Initializing an SqlBulkCopy object
            SqlBulkCopy sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            // Copying data to destination
            sbc.DestinationTableName = "DEBITOPARCELA";
            sbc.WriteToServer(dtP);

            // Closing connection and the others
            sbc.Close();

            MessageBox.Show("fim");
        }




    }
}
