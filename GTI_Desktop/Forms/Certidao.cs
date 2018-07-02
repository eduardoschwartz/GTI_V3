using GTI_Desktop.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Certidao : Form {
        public Certidao() {
            InitializeComponent();
        }

       
        private void CarregarButton_Click(object sender, EventArgs e) {

        }

        private void FillGrid() {
            CertidaoGrid Pms = new CertidaoGrid {Assinatura="Sim",Tipo="01-Certidão de Débito"
            };
            pGrid.SelectedObject = Pms;
        }

        private void Certidao_Load(object sender, EventArgs e) {
            FillGrid();
            foreach (Control control in pGrid.Controls) {
                ToolStrip toolStrip = control as ToolStrip;
                
                if (toolStrip != null) {
                    toolStrip.BackColor = Color.BurlyWood;
                    foreach (ToolStripItem item in toolStrip.Items) {
                        if(item is ToolStripButton || item is ToolStripSeparator)
                            item.Visible = false;
                    }

                    ToolStripButton button2 = new ToolStripButton("Imprimir Certidão");
                    button2.Name = "ImprimirButton";
                    button2.Image = Resources.print;
                    button2.Click += new EventHandler(ImprimirButton_Click);
                    toolStrip.Items.Add(button2);
                    break;
                }
            }
        }

        void ImprimirButton_Click(object sender, EventArgs e) {
            MessageBox.Show("It can print too"); ;
        }

    }


    public class CertidaoGrid {
        private string _codigo;
        private string _nome;
        private string _assinatura;
        private string _processo;
        private string _tipo;
        private string _doc;
        private string _endereco;
        private string _bairro;
        private string _cidade;
        private string _cep;
        private string _inscricao;
        private string _quadra;
        private string _lote;
        private string _atividade;

        [Category("Dados de Entrada"), DisplayName("Código/Inscrição Municipal")]
        public string Codigo {
            get { return _codigo; }
            set { _codigo = value; }
        }

        [Category("Dados de Entrada"), DisplayName("Número do Processo")]
        public string Processo {
            get { return _processo; }
            set { _processo = value; }
        }

        [TypeConverter(typeof(YesNoConverter))]
        [Category("Dados de Entrada"), DisplayName("Ocultar Assinatura")]
        public string Assinatura {
            get { return _assinatura; }
            set { _assinatura = value; }
        }

        [TypeConverter(typeof(TipoConverter))]
        [Category("Dados de Entrada")]
        [DisplayName("Tipo de Certidão")]
        public string Tipo {
            get { return _tipo; }
            set { _tipo = value; }
        }

        [Category("Dados de Impressão"),  ReadOnly(true), DisplayName("01-Nome/Razão Social")]
        public string Nome {
            get { return _nome; }
            set { _nome = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("02-CPF/CNPJ")]
        public string Doc {
            get { return _doc; }
            set { _doc = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("03-Endereço")]
        public string Endereco {
            get { return _endereco; }
            set { _endereco = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("04-Bairro")]
        public string Bairro {
            get { return _bairro; }
            set { _bairro = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("05-Cidade")]
        public string Cidade {
            get { return _cidade; }
            set { _cidade = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("06-Cep")]
        public string Cep {
            get { return _cep; }
            set { _cep = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("07-Inscrição Cadastral")]
        public string Inscricao {
            get { return _inscricao; }
            set { _inscricao = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("08-Quadra Original")]
        public string Quadra {
            get { return _quadra; }
            set { _quadra = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("09-Lote Original")]
        public string Lote {
            get { return _lote; }
            set { _lote = value; }
        }

        [Category("Dados de Impressão"), ReadOnly(true), DisplayName("10-Atividade")]
        public string Atividade {
            get { return _atividade; }
            set { _atividade = value; }
        }

        
    }

    public class TipoConverter : StringConverter {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            ArrayList _status = new ArrayList();
            _status.Add("01 - Certidão de Débito");
            _status.Add("02 - Certidão de Endereço");
            _status.Add("03 - Certidão de Isenção");
            _status.Add("04 - Certidão de Valor Venal");
            return new StandardValuesCollection(_status);
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context) {
            return true;
        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) {
            return true;
        }
    }

    public class YesNoConverter : StringConverter {
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            ArrayList _status = new ArrayList();
            _status.Add("Sim");
            _status.Add("Não");
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
