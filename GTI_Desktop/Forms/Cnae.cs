using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Cnae : Form {
        string _connection = gtiCore.Connection_Name();
        public List<CnaeStruct> Lista_Cnae{ get; set; }
        public CnaeStruct Return_Cnae { get; set; }

        public Cnae() {
            InitializeComponent();
        }

        private void Cnae_Load(object sender, EventArgs e) {
            if (Tag.ToString() == "Empresa_Cnae") {
                var frm = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Empresa_Cnae);
                Location = new Point(frm.Location.X + 50, frm.Location.Y + 50);
            }
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            Lista_Cnae = empresa_Class.Lista_Cnae();
            Carrega_Lista();
        }

        private void Carrega_Lista() {
            MainListView.Items.Clear();

            if (Busca.Text != "") {
                if (gtiCore.IsNumeric(Busca.Text.Substring(0, 1))) {
                    var Lista_Filter_Cnae = Lista_Cnae.Where(c => c.CNAE.Contains(Busca.Text));
                    foreach (CnaeStruct item in Lista_Filter_Cnae) {
                        ListViewItem lvItem = new ListViewItem(item.CNAE);
                        lvItem.SubItems.Add(item.Descricao);
                        MainListView.Items.Add(lvItem);
                    }
                } else {
                    var Lista_Filter_Nome = Lista_Cnae.Where(c => c.Descricao.Contains(Busca.Text));
                    foreach (CnaeStruct item in Lista_Filter_Nome) {
                        ListViewItem lvItem = new ListViewItem(item.CNAE);
                        lvItem.SubItems.Add(item.Descricao);
                        MainListView.Items.Add(lvItem);
                    }
                }
            } else {
                foreach (CnaeStruct item in Lista_Cnae) {
                    ListViewItem lvItem = new ListViewItem(item.CNAE);
                    lvItem.SubItems.Add(item.Descricao);
                    MainListView.Items.Add(lvItem);
                }
            }
        }

        private void SelectButton_Click(object sender, EventArgs e) {
            if(MainListView.SelectedItems.Count==0)
                MessageBox.Show("Selecione ao menos 1 Cnae.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                ListViewItem item = MainListView.SelectedItems[0];
                Return_Cnae = new CnaeStruct {
                    CNAE = item.Text,
                    Descricao = item.SubItems[1].Text
                };
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Busca_TextChanged(object sender, EventArgs e) {
            Carrega_Lista();
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            Return_Cnae = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }


}
