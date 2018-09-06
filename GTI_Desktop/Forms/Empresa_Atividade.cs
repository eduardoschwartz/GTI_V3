using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_Atividade : Form {
        string _connection = gtiCore.Connection_Name();

        public Empresa_Atividade() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            Carrega_Lista();
            ControlBehaviour(true);
        }

        private void ControlBehaviour(bool bStart) {
            Color color_disable = !bStart ? Color.White : BackColor;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            PrintButton.Enabled = bStart;
            SelecionarButton.Enabled = bStart;
            Codigo.ReadOnly = bStart;
            Codigo.BackColor = color_disable;
            Descricao.ReadOnly = bStart;
            Descricao.BackColor = color_disable;
            Aliquota1.ReadOnly = bStart;
            Aliquota1.BackColor = color_disable;
            Aliquota2.ReadOnly = bStart;
            Aliquota3.BackColor = color_disable;
            Aliquota3.ReadOnly = bStart;
            Aliquota3.BackColor = color_disable;
            MainListView.Enabled = bStart;
        }

        private void Aliquota1_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Aliquota2_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Aliquota3_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Carrega_Lista() {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            List<Atividade> Lista = empresa_Class.Lista_Atividade();
            foreach (Atividade item in Lista) {
                ListViewItem lvItem = new ListViewItem(item.Codatividade.ToString("00000"));
                lvItem.SubItems.Add(item.Descatividade);
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valoraliq1));
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valoraliq2));
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valoraliq3));
                MainListView.Items.Add(lvItem);
            }
            MainListView.Items[0].Selected = true;
        }

        private void MainListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainListView.SelectedItems.Count > 0) {
                Codigo.Text = MainListView.SelectedItems[0].Text;
                Descricao.Text = MainListView.SelectedItems[0].SubItems[1].Text;
                Aliquota1.Text = MainListView.SelectedItems[0].SubItems[2].Text;
                Aliquota2.Text = MainListView.SelectedItems[0].SubItems[3].Text;
                Aliquota3.Text = MainListView.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void ZoomButton_Click(object sender, EventArgs e) {
            bool bReadOnly = false;
            if (AddButton.Enabled) bReadOnly = true;
            ZoomBox f1 = new ZoomBox("Descrição da atividade", this, Descricao.Text, bReadOnly,300);
            f1.ShowDialog();
            Descricao.Text = f1.ReturnText;
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void CancelarButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            ControlBehaviour(false);
        }

        private void EditButton_Click(object sender, EventArgs e) {
            ControlBehaviour(false);
        }

        private void Codigo_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

    }
}
