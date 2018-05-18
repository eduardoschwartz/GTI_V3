using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Cidadao_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        private ListViewColumnSorter lvwColumnSorter;

        public Cidadao_Lista() {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            lvMain.ListViewItemSorter = lvwColumnSorter;
        }

        private void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem) {
            selectedMenuItem.Checked = true;

            foreach (var ltoolStripMenuItem in (from object
                                                item in selectedMenuItem.Owner.Items
                                                let ltoolStripMenuItem = item as ToolStripMenuItem
                                                where ltoolStripMenuItem != null
                                                where !item.Equals(selectedMenuItem)
                                                select ltoolStripMenuItem))
                (ltoolStripMenuItem).Checked = false;

            mnuTitle.Text = "Critério: (" + selectedMenuItem.Text + ")";
            mnuTitle.Tag = selectedMenuItem.Text;
        }

        private void MnuNome_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void MnuCodigo_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void MnuCPF_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void MnuCNPJ_Click(object sender, EventArgs e) {
            UncheckOtherToolStripMenuItems((ToolStripMenuItem)sender);
        }

        private void BtFind_Click(object sender, EventArgs e) {
            lvMain.Items.Clear();
            if (txtBusca.Text.Length < 3)
                MessageBox.Show("Digite ao menos 3 caractéres.", "Informação inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Fill_List();
        }

        private void Cidadao_Lista_Activated(object sender, EventArgs e) {
            if (mnuTitle.Text.Equals(""))
                UncheckOtherToolStripMenuItems(mnuNome);
        }

        private void Fill_List() {
            gtiCore.Ocupado(this);
            string _valor = txtBusca.Text;
            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            List<GTI_Models.Models.Cidadao> Lista = new List<GTI_Models.Models.Cidadao>();
            if(mnuTitle.Tag.ToString()=="Nome")
                Lista = clsCidadao.Lista_Cidadao(_valor,"","");
            else {
                if (mnuTitle.Tag.ToString() == "CPF")
                    Lista = clsCidadao.Lista_Cidadao("",_valor, "");
                else
                    Lista = clsCidadao.Lista_Cidadao("","", _valor);
            }

            foreach (var item in Lista) {
                ListViewItem lvi = new ListViewItem(item.Codcidadao.ToString("000000"));
                lvi.SubItems.Add(item.Nomecidadao.ToString());
                if (!String.IsNullOrEmpty(item.Cpf))
                    lvi.SubItems.Add(String.Format(@"{0:000\.000\.000\-00}", Convert.ToDecimal(Regex.Match(item.Cpf, @"\d+").Value)));
                else
                    lvi.SubItems.Add("");
                if (!String.IsNullOrEmpty(item.Cnpj))
                    lvi.SubItems.Add(String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToDecimal(Regex.Match(item.Cnpj, @"\d+").Value)));
                else
                    lvi.SubItems.Add("");
                lvMain.Items.Add(lvi);
            }
            gtiCore.Liberado(this);
        }

        private void TxtBusca_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Return) {
                e.Handled = true;
                BtFind_Click(sender, e);
            }
        }

        private void LvMain_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column == lvwColumnSorter.SortColumn) {
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                    lvwColumnSorter.Order = SortOrder.Descending;
                else
                    lvwColumnSorter.Order = SortOrder.Ascending;
            } else {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            lvMain.Sort();
        }

        private void BtReturn_Click(object sender, EventArgs e) {
            if (lvMain.Items.Count > 0) {
                if (lvMain.SelectedItems.Count > 0) {
                    if (this.Tag.ToString().Equals("Cidadao")) {
                        Cidadao f1 = (Cidadao)Application.OpenForms["Cidadao"];
                        if (f1 != null)
                            f1.CodCidadao = Convert.ToInt32(lvMain.SelectedItems[0].Text);
                    }
                    this.Hide();
                } else
                    MessageBox.Show("Selecione um item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                MessageBox.Show("Selecione um item.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
