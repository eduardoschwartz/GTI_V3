using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Divida_Ativa_Manual : Form {
        public int ReturnValue { get; set; }
        int _codigo, _UserId,_numero_livro=0;
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
                _numero_livro = _tipo_livro.Codtipo;

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

                    if (!DateTime.TryParseExact(DataInscricaoText.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime _data)) {
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
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Tributario_bll tributario_Class = new Tributario_bll(_connection);
            
            Contribuinte_Header_Struct _header = sistema_Class.Contribuinte_Header(_codigo);

            string _tipo_divida = _codigo < 100000 ? "Imobiliário" : _codigo >= 500000 ? "Taxas Diversas" : "Mobiliário";
            int _certidao = tributario_Class.Retorna_Ultima_Certidao_Livro(_numero_livro);
            int _pagina = _certidao;

            Cdas regCda = new Cdas() {
                Iddevedor = _codigo.ToString(),
                Setordevedor = _tipo_divida,
                Dtinscricao = Convert.ToDateTime(DataInscricaoText.Text),
                Nrocertidao = _certidao,
                Nrolivro = _numero_livro,
                Nrofolha = _pagina,
                Dtgeracao = DateTime.Now
            };
            
            Integrativa_bll integrativa_Class = new Integrativa_bll(_connection_integrativa);
            int _idCda = integrativa_Class.Insert_Integrativa_Cda(regCda);


            foreach (ListViewItem linha in MainListView.Items) {

            }



        }

    }
}
