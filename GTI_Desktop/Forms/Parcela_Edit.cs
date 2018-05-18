using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Editores;
using GTI_Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Parcela_Edit : Form {
        public static List<SpExtrato> _lista_tributo;
        public Parcela_Edit(List<SpExtrato> ListaTributo) {
            InitializeComponent();
            _lista_tributo = ListaTributo;
            LoadProperty clsProperty = new LoadProperty {
                Exercicio = ListaTributo[0].Anoexercicio,
                Lancamento = ListaTributo[0].Codlancamento.ToString("00") + "-" + ListaTributo[0].Desclancamento,
                Sequencia = ListaTributo[0].Seqlancamento,
                Parcela = ListaTributo[0].Numparcela,
                Complemento = ListaTributo[0].Codcomplemento,
                Data_Vencimento = Convert.ToDateTime(ListaTributo[0].Datavencimento).ToString("dd/MM/yyyy"),
                Data_Base = Convert.ToDateTime(ListaTributo[0].Datadebase).ToString("dd/MM/yyyy"),
                StatusLancamento = ListaTributo[0].Statuslanc.ToString() + "-" + ListaTributo[0].Situacao,
                Data_Inscricao = ListaTributo[0].Datainscricao == null ? "" : Convert.ToDateTime(ListaTributo[0].Datainscricao).ToString("dd/MM/yyyy"),
                Numero_Certidao = ListaTributo[0].Certidao == null ? 0 : (int)ListaTributo[0].Certidao,
                Pagina_Livro = ListaTributo[0].Pagina == null ? 0 : (int)ListaTributo[0].Pagina,
                Numero_Livro = ListaTributo[0].Numlivro == null ? 0 : (int)ListaTributo[0].Numlivro,
                Tributos = "(...) ==>"
            };

            pGrid.SelectedObject = clsProperty;
            pGrid.ExpandAllGridItems();

        }


        private void PGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            //TODO: Gravar as alterações nas propriedades 
        }
    }

    class LoadProperty {
        private int _exercicio, _sequencia, _parcela, _complemento, _numero_certidao, _numero_livro, _pagina_livro;
        private string _lancamento, _data_vencto, _data_base, _status, _data_inscricao, _data_ajuiza, _tributo ;
        
        [Category("Atributos")]
        [DisplayName("Ano de exercício")]
        public int Exercicio {
            get {return _exercicio;}
            set { _exercicio = value; }
        }

        [Category("Atributos")]
        [DisplayName("Lançamento")]
        public string Lancamento {
            get {return _lancamento;}
            set { _lancamento = value; }
        }

        [Category("Atributos")]
        [DisplayName("Nº da sequencia")]
        public int Sequencia {
            get {return _sequencia;}
            set { _sequencia = value; }
        }

        [Category("Atributos")]
        [DisplayName("Nº da parcela")]
        public int Parcela {
            get {return _parcela;}
            set { _parcela = value; }
        }

        [Category("Atributos")]
        [DisplayName("N° do complemento")]
        public int Complemento {
            get {return _complemento;}
            set { _complemento = value; }
        }


        [Category("Dados do Lançamento")]
        [DisplayName("Data de vencimento")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Vencimento {
            get {return _data_vencto;}
            set {
                if (!gtiCore.IsDate(value) || Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                    MessageBox.Show("Data de vencimento inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    _data_vencto = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
            }
        }

        [Category("Dados do Lançamento")]
        [DisplayName("Data base")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Base {
            get {return _data_base;}
            set {
                if (!gtiCore.IsDate(value) || Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                    MessageBox.Show("Data base inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    _data_base = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
            }
        }


        [Category("Divida Ativa")]
        [DisplayName("Data de inscrição")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Inscricao {
            get {return _data_inscricao;}
            set {
                if (!gtiCore.IsDate(value))
                    _data_inscricao = null;
                else {
                    if (Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                        MessageBox.Show("Data de inscrição inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        _data_inscricao = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                }
            }
        }

        [Category("Divida Ativa")]
        [DisplayName("N° da certidão")]
        public int Numero_Certidao {
            get {return _numero_certidao;}
            set { _numero_certidao = value; }
        }

        [Category("Divida Ativa")]
        [DisplayName("N° do livro")]
        public int Numero_Livro {
            get {return _numero_livro;}
            set { _numero_livro = value; }
        }

        [Category("Divida Ativa")]
        [DisplayName("N° da página")]
        public int Pagina_Livro {
            get {return _pagina_livro;}
            set { _pagina_livro = value; }
        }

        [Category("Divida Ativa")]
        [DisplayName("Data de ajuizamento")]
        [EditorAttribute(typeof(Data_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Data_Ajuizamento {
            get {return _data_ajuiza;}
            set {
                if (!gtiCore.IsDate(value))
                    _data_ajuiza = null;
                else {
                    if (Convert.ToDateTime(value) > Convert.ToDateTime("31/12/2020") || Convert.ToDateTime(value) < Convert.ToDateTime("01/01/1980"))
                        MessageBox.Show("Data de ajuizamento inválida.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        _data_ajuiza = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                }
            }
        }

        [TypeConverter(typeof(StatusConverter))]
        [Category("Dados do Lançamento")]
        [DisplayName("Situação do lançamento")]
        public string StatusLancamento {
            get { return _status;}
            set { _status = value;}
        }

        [Category("Dados dos Tributos")]
        [DisplayName("Lista de tributos")]
        [EditorAttribute(typeof(Tributo_Editor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Tributos {
            get { return _tributo; }
            set {
                    _tributo = "(...) ==>";
            }
        }

    }



    public class StatusConverter : StringConverter {

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            ArrayList _status = new ArrayList();
            Tributario_bll clsTributario = new Tributario_bll(gtiCore.Connection_Name());
            List<Situacaolancamento> Lista = clsTributario.Lista_Status();
            foreach (Situacaolancamento item in Lista) {
                _status.Add(item.Codsituacao.ToString("00") + "-" + item.Descsituacao);
            }

            return new StandardValuesCollection(_status);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }

    }







}
