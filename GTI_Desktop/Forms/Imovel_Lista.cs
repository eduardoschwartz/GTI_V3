using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Imovel_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        private ListViewColumnSorter lvwColumnSorter;

        public Imovel_Lista() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            lvwColumnSorter = new ListViewColumnSorter();
        }

        private void SelectButton_Click(object sender, EventArgs e) {
            if (MainListView.SelectedItems.Count>0) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.SelectedItems[0].Text);
                Close();
            } else {
                MessageBox.Show("Selecione um imóvel.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void ProprietarioButton_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                    Contribuinte_Header_Struct reg = sistema_Class.Contribuinte_Header(val);
                    Proprietario.Text = reg.Nome;
                    Proprietario.Tag = val.ToString();
                }
            }
        }

        private void CallPB(System.Windows.Forms.ToolStripProgressBar pBar,  int nPos,int nTot) {
            pBar.Value = nPos * 100 / nTot;
        }

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column == lvwColumnSorter.SortColumn) {
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            MainListView.Sort();
        }

        private void FindButton_Click(object sender, EventArgs e) {
            MainListView.Items.Clear();
            gtiCore.Ocupado(this);
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            ImovelStruct Reg = new ImovelStruct();
            Reg.Codigo = string.IsNullOrEmpty(Codigo.Text) ? 0 : Convert.ToInt32(Codigo.Text);
            Reg.Proprietario_Principal = PrincipalCheckBox.Checked;
            Reg.Proprietario_Codigo = Proprietario.Tag == null ? 0 : Convert.ToInt32(Proprietario.Tag.ToString());
            Reg.Distrito = Inscricao.Text.Substring(0, 1).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(0, 1).Trim());
            Reg.Setor = Inscricao.Text.Substring(2, 2).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(2, 2).Trim());
            Reg.Quadra = Inscricao.Text.Substring(5, 4).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(5, 4).Trim());
            Reg.Lote = Inscricao.Text.Substring(10, 5).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(10, 5).Trim());
            MainListView.ListViewItemSorter = null;
            List<ImovelStruct> Lista = imovel_Class.Lista_Imovel(Reg);
            int _pos = 0, _total = Lista.Count;
            MainListView.BeginUpdate();
            foreach (var item in Lista) {
                ListViewItem lvi = new ListViewItem(item.Codigo.ToString("000000"));
                lvi.SubItems.Add(item.Inscricao.ToString());
                lvi.SubItems.Add(item.Proprietario_Nome.ToString());
                MainListView.Items.Add(lvi);
                if (_pos % 20 == 0)
                    CallPB(PBar, _pos, _total);
                _pos++;
            }
            MainListView.EndUpdate();
            MainListView.ListViewItemSorter = lvwColumnSorter;
            TotalImovel.Text = _total.ToString();
            PBar.Value = 0;
            gtiCore.Liberado(this);

        }


    }
}
