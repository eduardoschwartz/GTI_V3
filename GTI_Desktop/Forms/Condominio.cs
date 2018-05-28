using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Condominio : Form {
        string _connection = gtiCore.Connection_Name();

        public Condominio() {
            InitializeComponent();
            ClearReg();
            Carrega_Lista();
            ControlBehaviour(true);
        }

        private void btSair_Click(object sender, EventArgs e) {
            Close();
        }

        private void ControlBehaviour(bool bStart) {
            Color color_disable = !bStart ? Color.White : BackColor;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            FindButton.Enabled = bStart;
            SaveButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            EnderecoButton.Enabled = !bStart;
            UnidadesButton.Enabled = !bStart;
            TestadaAddButton.Enabled = !bStart;
            TestadaDelButton.Enabled = !bStart;
            ProprietarioButton.Enabled = !bStart;
            Nome.ReadOnly = bStart;
            Nome.BackColor = color_disable;
            Setor.ReadOnly = bStart;
            Setor.BackColor = color_disable;
            Quadra.ReadOnly = bStart;
            Quadra.BackColor = color_disable;
            Lote.ReadOnly = bStart;
            Lote.BackColor = color_disable;
            Face.ReadOnly = bStart;
            Face.BackColor = color_disable;
            Quadra_Original.ReadOnly = bStart;
            Quadra_Original.BackColor = color_disable;
            Lote_Original.ReadOnly = bStart;
            Lote_Original.BackColor = color_disable;
            AreaPredial.ReadOnly = bStart;
            AreaPredial.BackColor = color_disable;
            AreaTerreno.ReadOnly = bStart;
            AreaTerreno.BackColor = color_disable;
            Unidades.ReadOnly = bStart;
            Unidades.BackColor = color_disable;
            Benfeitoria.Visible = bStart;
            Topografia.Visible = bStart;
            Situacao.Visible = bStart;
            Uso.Visible = bStart;
            Categoria.Visible = bStart;
            Pedologia.Visible = bStart;
            BenfeitoriaList.Visible = !bStart;
            TopografiaList.Visible = !bStart;
            SituacaoList.Visible = !bStart;
            UsoList.Visible = !bStart;
            CategoriaList.Visible = !bStart;
            PedologiaList.Visible = !bStart;
        }

        private void AddButton_Click(object sender, EventArgs e) {
            ControlBehaviour(false);
        }

        private void EditButton_Click(object sender, EventArgs e) {
            ControlBehaviour(false);
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void CancelButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void Setor_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Quadra_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Lote_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Face_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void AreaTerreno_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void AreaPredial_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void Unidades_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void FindButton_Click(object sender, EventArgs e) {
            using (var form = new Condominio_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    short val = form.ReturnValue;
                    CarregaDados(val);
                }
            }
        }

        private void Carrega_Lista() {
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            CategoriaList.DataSource = clsImovel.Lista_Categoria_Propriedade();
            CategoriaList.DisplayMember = "Desccategprop";
            CategoriaList.ValueMember = "Codcategprop";

            TopografiaList.DataSource = clsImovel.Lista_Topografia();
            TopografiaList.DisplayMember = "Desctopografia";
            TopografiaList.ValueMember = "Codtopografia";

            SituacaoList.DataSource = clsImovel.Lista_Situacao();
            SituacaoList.DisplayMember = "Descsituacao";
            SituacaoList.ValueMember = "Codsituacao";

            BenfeitoriaList.DataSource = clsImovel.Lista_Benfeitoria();
            BenfeitoriaList.DisplayMember = "Descbenfeitoria";
            BenfeitoriaList.ValueMember = "Codbenfeitoria";

            PedologiaList.DataSource = clsImovel.Lista_Pedologia();
            PedologiaList.DisplayMember = "Descpedologia";
            PedologiaList.ValueMember = "Codpedologia";

            UsoList.DataSource = clsImovel.Lista_uso_terreno();
            UsoList.DisplayMember = "Descusoterreno";
            UsoList.ValueMember = "Codusoterreno";
        }

        private void ClearReg() {
            CodigoCondominio.Text = "000000";
            Nome.Text = "";
            ProprietarioCodigo.Text = "000000";
            Distrito.Text = "0";
            Setor.Text = "00";
            Quadra.Text = "0000";
            Lote.Text = "00000";
            Face.Text = "00";
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Numero.Text = "";
            Complemento.Text = "";
            CEP.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
            Lote_Original.Text = "";
            Quadra_Original.Text = "";
            Benfeitoria.Text = "";
            BenfeitoriaList.SelectedValue = -1;
            Topografia.Text = "";
            TopografiaList.SelectedValue = -1;
            Pedologia.Text = "";
            PedologiaList.SelectedValue = -1;
            Situacao.Text = "";
            SituacaoList.SelectedValue = -1;
            Categoria.Text = "";
            CategoriaList.SelectedValue = -1;
            Uso.Text = "";
            UsoList.SelectedValue = -1;
            UnidadesListView.Items.Clear();
            TestadaListView.Items.Clear();
            AreaListView.Items.Clear();
            SomaArea.Text = "0,00";
        }

        private void CarregaDados(int Codigo) {
            ClearReg();
            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            CondominioStruct reg = imovel_Class.Dados_Condominio(Codigo);
            CodigoCondominio.Text = Codigo.ToString("000000");
            Nome.Text = reg.Nome;
            ProprietarioCodigo.Text = Convert.ToInt32(reg.Codigo_Proprietario).ToString("000000");
            Distrito.Text = reg.Distrito.ToString();
            Setor.Text = reg.Setor.ToString("00");
            Quadra.Text = reg.Quadra.ToString("0000");
            Lote.Text = reg.Lote.ToString("00000");
            Face.Text = reg.Seq.ToString("00");
            Logradouro.Text = reg.Nome_Logradouro;
            Logradouro.Tag = reg.Codigo_Logradouro.ToString();
            Numero.Text = reg.Numero.ToString();
            Complemento.Text = reg.Complemento;
            CEP.Text = reg.Cep;
            Bairro.Text = reg.Nome_Bairro;
            Bairro.Tag = reg.Codigo_Bairro.ToString();
            Lote_Original.Text = reg.Lote_Original;
            Quadra_Original.Text = reg.Quadra_Original;
            Benfeitoria.Text = reg.Benfeitoria_Nome;
            BenfeitoriaList.SelectedValue = reg.Benfeitoria;
            Topografia.Text = reg.Topografia_Nome;
            TopografiaList.SelectedValue = reg.Topografia;
            Pedologia.Text = reg.Pedologia_Nome;
            PedologiaList.SelectedValue = reg.Pedologia;
            Situacao.Text = reg.Situacao_Nome;
            SituacaoList.SelectedValue = reg.Situacao;
            Categoria.Text = reg.Categoria_Nome;
            CategoriaList.SelectedValue = reg.Categoria;
            Uso.Text = reg.Uso_terreno_Nome;
            UsoList.SelectedValue = reg.Uso_terreno;
            AreaPredial.Text = Convert.ToDecimal(reg.Area_Construida).ToString("#0.00");
            AreaTerreno.Text = Convert.ToDecimal(reg.Area_Terreno).ToString("#0.00");
            Unidades.Text = reg.Qtde_Unidade.ToString();

            List<Testadacondominio> ListaTestada = imovel_Class.Lista_Testada_Condominio(Codigo);
            foreach (Testadacondominio Testada in ListaTestada) {
                ListViewItem lvItem = new ListViewItem(Testada.Numface.ToString("00"));
                lvItem.SubItems.Add(Testada.Areatestada.ToString("#0.00"));
                TestadaListView.Items.Add(lvItem);
            }

            List<Condominiounidade> ListaUnidade = imovel_Class.Lista_Unidade_Condominio(Codigo);
            foreach (Condominiounidade Unidade in ListaUnidade) {
                ListViewItem lvItem = new ListViewItem(Unidade.Cd_unidade.ToString("00"));
                lvItem.SubItems.Add(Unidade.Cd_subunidades.ToString("00"));
                UnidadesListView.Items.Add(lvItem);
            }

            short n = 1;
            decimal SomaArea = 0;
            List<AreaStruct> ListaArea = imovel_Class.Lista_Area_Condominio(Codigo);
            foreach (AreaStruct Area in ListaArea) {
                ListViewItem lvItem = new ListViewItem(n.ToString("00"));
                lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)Area.Area));
                lvItem.SubItems.Add(Area.Uso_Nome);
                lvItem.SubItems.Add(Area.Tipo_Nome);
                lvItem.SubItems.Add(Area.Categoria_Nome);
                lvItem.SubItems.Add(Area.Pavimentos.ToString());
                lvItem.Tag = reg.Seq.ToString();
                AreaListView.Items.Add(lvItem);
                SomaArea += (decimal)reg.Area_Construida;
                n++;
            }
            this.SomaArea.Text = string.Format("{0:0.00}", SomaArea);

        }

        private void AreasButton_Click(object sender, EventArgs e) {
            if (AreasButton.Checked) {
                AreaPanel.BringToFront();
            } 
            AreaPanel.Visible = AreasButton.Checked;
            PanelDados.Enabled = !AreasButton.Checked;
            PanelHeader.Enabled = !AreasButton.Checked;
            PanelLocal.Enabled = !AreasButton.Checked;
            PanelOutro.Enabled = !AreasButton.Checked;
            tBar.Enabled = !AreasButton.Checked;
        }

        private void CloseAreaButton_Click(object sender, EventArgs e) {
            AreasButton.Checked = false;
            AreasButton_Click(null, null);
        }

        private void mnuSair_Click(object sender, EventArgs e) {
            AreasButton.Checked = false;
            AreasButton_Click(null, null);
        }

        private void AdicionarMenuItem_Click(object sender, EventArgs e) {
            AreaPanel.Enabled = false;
            AreaEditPanel.Visible = true;
            AreaEditPanel.BringToFront();
            AreaConstruida.Focus();
        }

        private void RemoverMenuItem_Click(object sender, EventArgs e) {
        }

        private void OkAreaButton_Click(object sender, EventArgs e) {
            AreaPanel.Enabled = true;
            AreaEditPanel.Visible = false;
        }

        private void CancelAreaButton_Click(object sender, EventArgs e) {
            AreaPanel.Enabled = true;
            AreaEditPanel.Visible = false;
        }

        private void AlterarMenuItem_Click(object sender, EventArgs e) {
            AreaPanel.Enabled = false;
            AreaEditPanel.Visible = true;
        }
    }
}
