using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_Cnae : Form {
        public List<CnaeStruct> Lista_Cnae { get; set; }

        public Empresa_Cnae(List<CnaeStruct>Lista_Cnae_Old) {
            InitializeComponent();
            CnaeToolStrip.Renderer = new MySR();
            foreach (CnaeStruct item in Lista_Cnae_Old) {
                ListViewItem lvItem = new ListViewItem(item.CNAE);
                lvItem.SubItems.Add(item.Descricao);
                lvItem.Checked = item.Principal;
                MainListView.Items.Add(lvItem);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            int _count = 0;
            Lista_Cnae = new List<CnaeStruct>();
            if (MainListView.Items.Count > 0) {
                foreach (ListViewItem item in MainListView.Items) {
                    if (item.Checked)
                        _count++;
                }
                if (_count == 0)
                    MessageBox.Show("Selecione um Cnae como principal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    if (_count > 1)
                        MessageBox.Show("Selecione apenas um Cnae como principal.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        //retorna a lista de Cnaes
                        foreach (ListViewItem item in MainListView.Items) {
                            CnaeStruct reg = new CnaeStruct();
                            reg.CNAE = item.Text;
                            reg.Descricao = item.SubItems[1].Text;
                            reg.Principal = item.Checked;
                            Lista_Cnae.Add(reg);
                        }
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            } else {
                Lista_Cnae.Clear() ;
                Close();
            }
        }

        private void AddButton_Click(object sender, EventArgs e) {
            Cnae frm = new Cnae();
            frm.Tag = Name;
            frm.ShowDialog(this);
            if (frm.Return_Cnae != null) {
                ListViewItem lvItem = new ListViewItem(frm.Return_Cnae.CNAE);
                lvItem.SubItems.Add(frm.Return_Cnae.Descricao);
                MainListView.Items.Add(lvItem);
            }
        }


    }
}
