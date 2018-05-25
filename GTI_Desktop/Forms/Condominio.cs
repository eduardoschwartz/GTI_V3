using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
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
            AreasButton.Enabled = !bStart;
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
            
        }

    }
}
