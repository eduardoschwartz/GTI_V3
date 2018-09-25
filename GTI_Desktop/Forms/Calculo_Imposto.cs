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
        decimal _ipca = (decimal)2.5377;

        private enum Tipo_imposto {
            Iptu = 1,
            ISS_Fixo_TLL=2,
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
                    Calculo_IssTLL();
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

        private void Calculo_IssTLL() {
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

            MsgToolStrip.Text = "Calculando ISS Fixo/Taxa de Licença";
            List<DateTime> aVencimento = new List<DateTime>();
            List<decimal> aDesconto = new List<decimal>();
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            Paramparcela _Prm = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)Tipo_imposto.ISS_Fixo_TLL);
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
            bool _possui_taxa = false;
            decimal _valor_vistoria = tributario_Class.Retorna_Valor_Tributo(_ano, 24);


            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<EmpresaStruct> ListaEmpresas = empresa_Class.Lista_Empresas_ISS_Fixo_TLL();
            int _total = ListaEmpresas.Count, _pos = 1;
            string _documento0 = "", _documento1 = "", _documento2 = "", _documento3 = "", _documento4 = "", _valor0 = "", _valor1 = "";
            string _vencimento0 = "", _vencimento1 = "", _vencimento2 = "", _vencimento3 = "", _vencimento4 = "";
            decimal _valor_aliquota = 0;

            foreach (EmpresaStruct item in ListaEmpresas) {
                bool _vistoria = item.Vistoria == 1 ? true : false;
                decimal _area = item.Area == null ? 0 : (decimal)item.Area;
                int _codigo_aliquota = item.Codigo_aliquota == null ? 0 : (int)item.Codigo_aliquota;
                switch (_codigo_aliquota) {
                    case 0:;
                        break;
                    case 1:
                        _valor_aliquota = item.Valor_aliquota1==null?0:(decimal)item.Valor_aliquota1;
                        break;
                    case 2:
                        _valor_aliquota = item.Valor_aliquota2 == null ? 0 : (decimal)item.Valor_aliquota2;
                        break;
                    case 3:
                        _valor_aliquota = item.Valor_aliquota3 == null ? 0 : (decimal)item.Valor_aliquota3;
                        break;
                    default:
                        break;
                }

                //Limitante de área
                if (_area > 27000 && _valor_aliquota == (decimal)0.29)
                    _area = 27000;
                else {
                    if (_area > 9000 && (_valor_aliquota == (decimal)0.58 || _valor_aliquota == (decimal)0.36))
                        _area = 9000;
                    else {
                        if (_area > 6000 && (_valor_aliquota == (decimal)0.72 || _valor_aliquota == (decimal)0.86))
                            _area = 6000;
                    }
                }

                _valor_aliquota *= _ipca;
                if (_valor_aliquota < 14)
                    _valor_aliquota *= _area;

                if (_valor_aliquota == 0 && !_vistoria)
                    goto LABEL_ISS_FIXO;
                else
                    _possui_taxa = true;

                for (int _parcela = 0; _parcela <= _qtde_parcelas; _parcela++) {
                    string _vencto = _parcela == 0 ? aVencimento[0].ToString("dd/MM/yyyy") : aVencimento[_parcela - 1].ToString("dd/MM/yyyy");
                    string _linha = item.Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#18#" + _vencto + "#01/01/" + _ano;
                    fs1.WriteLine(_linha);

                    decimal _valor = _valor_aliquota/3, _valor_unica = (_valor_aliquota / 3) - ((_valor_aliquota / 3) * (decimal)0.05);
                    decimal _valor_parcela = _parcela > 0 ? _valor : _valor_unica;
                    _linha = item.Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#14#" + _valor_parcela.ToString("#0.00");
                    fs2.WriteLine(_linha);
                    if (_vistoria) {
                        _linha = item.Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#24#" + _valor_vistoria.ToString("#0.00");
                        fs2.WriteLine(_linha);
                    }

                    _linha = item.Codigo + "#" + _ano + "#6#0#" + _parcela + "#0#" + _documento;
                    fs3.WriteLine(_linha);

                    _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                    fs4.WriteLine(_linha);

                    switch (_parcela) {
                        case 0:
                            _documento0 = _documento.ToString();
                            _vencimento0 = _vencto.ToString();
                            _valor0 = _valor_parcela.ToString("#0.00");
                            break;
                        case 1:
                            _documento1 = _documento.ToString();
                            _vencimento1 = _vencto.ToString();
                            _valor1 = _valor_parcela.ToString("#0.00");
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

                string _linha_calc = _ano.ToString() + "#" + item.Codigo + "#6#" + _valor0 + "#" + _valor1 + "#" +
                _documento0 + "#" + _vencimento0 + "#" + _documento1 + "#" + _vencimento1 + "#" + _documento2 + '#' + _vencimento2 + "#" + _documento3 + "#" +
                _vencimento3 + "#" + _documento4 + "#" + _vencimento4 + "#" + _qtde_parcelas.ToString();
                fs5.WriteLine(_linha_calc);

                _pos++;


LABEL_ISS_FIXO:;

            }


            fs1.Close(); fs2.Close(); fs3.Close(); fs4.Close(); fs5.Close(); fsDP.Close(); fsDT.Close(); fsND.Close(); fsPD.Close(); fsCC.Close();
            PBar.Value = 100;
            PBar.Update();
            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            Refresh();
            MessageBox.Show("Cálculo finalizado.", "Infiormação", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    string _vencto =  _parcela==0 ? aVencimento[0].ToString("dd/MM/yyyy"):   aVencimento[_parcela-1].ToString("dd/MM/yyyy");
                    string _linha = item.Codmobiliario + "#" + _ano + "#13#0#" + _parcela + "#0#18#" + _vencto + "#01/01/" + _ano ;
                    fs1.WriteLine(_linha);
                    decimal _valor = item.Valor, _valor_unica = item.Valor - (item.Valor * (decimal)0.05);
                    decimal _valor_parcela = _parcela > 0 ? _valor : _valor_unica;
                    _valor_parcela = _valor_parcela * item.Qtde;
                    _linha = item.Codmobiliario + "#" + _ano + "#13#0#" + _parcela + "#0#25#" +  _valor_parcela.ToString("#0.00") ;
                    fs2.WriteLine(_linha);
                    _linha = item.Codmobiliario + "#" + _ano + "#13#0#" + _parcela + "#0#" + _documento;
                    fs3.WriteLine(_linha);
                    _linha = _documento + "#" + DateTime.Now.ToString("dd/MM/yyyy");
                    fs4.WriteLine(_linha);

                    switch (_parcela) {
                        case 0:
                            _documento0 = _documento.ToString();
                            _vencimento0 = _vencto.ToString();
                            _valor0 = _valor_parcela.ToString("#0.00");
                            break;
                        case 1:
                            _documento1 = _documento.ToString();
                            _vencimento1 = _vencto.ToString();
                            _valor1 = _valor_parcela.ToString("#0.00");
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

                string _linha_calc = _ano.ToString() + "#" + item.Codmobiliario + "#13#" + _valor0 + "#" + _valor1 + "#" +
                    _documento0 + "#" + _vencimento0 + "#" + _documento1 + "#" + _vencimento1 + "#" + _documento2 + '#' + _vencimento2 + "#" + _documento3 + "#" +
                    _vencimento3 + "#" + _documento4 + "#" + _vencimento4 + "#" + _qtde_parcelas.ToString();
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

            #region DEBITOPARCELA
            MsgToolStrip.Text = "Inserindo parcelas";
            Refresh();

            DataTable dt = new DataTable();
            dt.Columns.Add("codreduzido", typeof(int));
            dt.Columns.Add("anoexercicio", typeof(short));
            dt.Columns.Add("codlancamento", typeof(short));
            dt.Columns.Add("seqlancamento", typeof(short));
            dt.Columns.Add("numparcela", typeof(byte));
            dt.Columns.Add("codcomplemento", typeof(byte));
            dt.Columns.Add("statuslanc", typeof(byte));
            dt.Columns.Add("datavencimento", typeof(DateTime));
            dt.Columns.Add("datadebase", typeof(DateTime));

            FileStream fs = new FileStream(_path + "DEBITOPARCELA.TXT", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["statuslanc"] = Convert.ToByte(_fields[6]);
                _row["datavencimento"] =Convert.ToDateTime( _fields[7]);
                _row["datadebase"] = Convert.ToDateTime(_fields[8]);
                dt.Rows.Add(_row);
            }

            SqlBulkCopy sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOPARCELA";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); fs.Close(); sr.Close();

            MsgToolStrip.Text = "Inserindo tributos";
            Refresh();
            #endregion

            #region DEBITOTRIBUTO
            MsgToolStrip.Text = "Inserindo tributos";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("codreduzido", typeof(int));
            dt.Columns.Add("anoexercicio", typeof(short));
            dt.Columns.Add("codlancamento", typeof(short));
            dt.Columns.Add("seqlancamento", typeof(short));
            dt.Columns.Add("numparcela", typeof(byte));
            dt.Columns.Add("codcomplemento", typeof(byte));
            dt.Columns.Add("codtributo", typeof(short));
            dt.Columns.Add("valortributo", typeof(decimal));

            fs = new FileStream(_path + "DEBITOTRIBUTO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["codtributo"] = Convert.ToInt16(_fields[6]);
                _row["valortributo"] = Convert.ToDecimal(_fields[7]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "DEBITOTRIBUTO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); fs.Close(); sr.Close();

            #endregion

            #region PARCELADOCUMENTO
            MsgToolStrip.Text = "Inserindo parcelas por documento";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("codreduzido", typeof(int));
            dt.Columns.Add("anoexercicio", typeof(short));
            dt.Columns.Add("codlancamento", typeof(short));
            dt.Columns.Add("seqlancamento", typeof(short));
            dt.Columns.Add("numparcela", typeof(byte));
            dt.Columns.Add("codcomplemento", typeof(byte));
            dt.Columns.Add("numdocumento", typeof(int));

            fs = new FileStream(_path + "PARCELADOCUMENTO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["codreduzido"] = Convert.ToInt32(_fields[0]);
                _row["anoexercicio"] = Convert.ToInt16(_fields[1]);
                _row["codlancamento"] = Convert.ToInt16(_fields[2]);
                _row["seqlancamento"] = Convert.ToInt16(_fields[3]);
                _row["numparcela"] = Convert.ToByte(_fields[4]);
                _row["codcomplemento"] = Convert.ToByte(_fields[5]);
                _row["numdocumento"] = Convert.ToInt32(_fields[6]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "PARCELADOCUMENTO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); sr.Close(); fs.Close();

            #endregion

            #region NUMDOCUMENTO
            MsgToolStrip.Text = "Inserindo números de documento";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("numdocumento", typeof(int));
            dt.Columns.Add("datadocumento", typeof(DateTime));

            fs = new FileStream(_path + "NUMDOCUMENTO.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["numdocumento"] = Convert.ToInt32(_fields[0]);
                _row["datadocumento"] = Convert.ToDateTime(_fields[1]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "NUMDOCUMENTO";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); sr.Close(); fs.Close();

            #endregion

            #region CALCULO_ISS_VS
            MsgToolStrip.Text = "Gravando cálculo";
            Refresh();

            dt = new DataTable();
            dt.Columns.Add("ano", typeof(short));
            dt.Columns.Add("codigo", typeof(int));
            dt.Columns.Add("lancamento", typeof(short));
            dt.Columns.Add("valor0", typeof(decimal));
            dt.Columns.Add("valor1", typeof(decimal));
            dt.Columns.Add("documento0", typeof(int));
            dt.Columns.Add("vencimento0", typeof(DateTime));
            dt.Columns.Add("documento1", typeof(int));
            dt.Columns.Add("vencimento1", typeof(DateTime));
            dt.Columns.Add("documento2", typeof(int));
            dt.Columns.Add("vencimento2", typeof(DateTime));
            dt.Columns.Add("documento3", typeof(int));
            dt.Columns.Add("vencimento3", typeof(DateTime));
            dt.Columns.Add("documento4", typeof(int));
            dt.Columns.Add("vencimento4", typeof(DateTime));
            dt.Columns.Add("qtde_parcela", typeof(byte));

            fs = new FileStream(_path + "CALCULO_ISS_VS.TXT", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs, System.Text.Encoding.Default);
            while (!sr.EndOfStream) {
                string _line = sr.ReadLine();
                string[] _fields = _line.Split('#');
                DataRow _row = dt.NewRow();
                _row["ano"] = Convert.ToInt16( _fields[0]);
                _row["codigo"] = Convert.ToInt32(_fields[1]);
                _row["lancamento"] = Convert.ToInt16(_fields[2]);
                _row["valor0"] = Convert.ToDecimal(_fields[3]);
                _row["valor1"] = Convert.ToDecimal(_fields[4]);
                _row["documento0"] = Convert.ToInt32(_fields[5]);
                _row["vencimento0"] = Convert.ToDateTime(_fields[6]);
                _row["documento1"] = Convert.ToInt32(_fields[7]);
                _row["vencimento1"] = Convert.ToDateTime(_fields[8]);
                _row["documento2"] = Convert.ToInt32(_fields[9]);
                _row["vencimento2"] = Convert.ToDateTime(_fields[10]);
                if (_fields[11] != "") {
                    _row["documento3"] = Convert.ToInt32(_fields[11]);
                    _row["vencimento3"] = Convert.ToDateTime(_fields[12]);
                    _row["documento4"] = Convert.ToInt32(_fields[13]);
                    _row["vencimento4"] = Convert.ToDateTime(_fields[14]);
                }
                _row["qtde_parcela"] = Convert.ToByte(_fields[15]);
                dt.Rows.Add(_row);
            }

            sbc = new SqlBulkCopy(_connection);
            sbc.BulkCopyTimeout = 0;
            sbc.DestinationTableName = "CALCULO_ISS_VS";
            sbc.WriteToServer(dt);
            sbc.Close();
            dt.Dispose(); sr.Close(); fs.Close();

            #endregion

            MsgToolStrip.Text = "Selecione uma opção de cálculo";
            Refresh();
            MessageBox.Show("Exportação finalizada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
