using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Imovel : Form {

        bool bAddNew ;
        string _connection = gtiCore.Connection_Name();

        public Imovel() {
            gtiCore.Ocupado(this);
            InitializeComponent();
            ClearFields();
            Carrega_Lista();
            bAddNew = false;
            ControlBehaviour(true);
            gtiCore.Liberado(this);
        }

        private void TabImovel_DrawItem(object sender, DrawItemEventArgs e) {
            TabPage page = tabImovel.TabPages[e.Index];
            e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void ClearFields() {
            lblInscricao.Text = "";
            lblSomaArea.Text = "0,00";
            txtMatricula.Text = "";
            txtNomeCond.Text = "";
            optMT1.Checked = true;
            optMT2.Checked = false;
            optEnd1.Checked = false;
            optEnd2.Checked = false;
            optEnd3.Checked = false;
            lvProp.Items.Clear();
            lvTestada.Items.Clear();
            lvArea.Items.Clear();
            txtNumero.Text = "";
            txtComplemento.Text = "";
            lblDistrito.Text = "0";
            lblSetor.Text = "00";
            txtQuadra.Text = "0000";
            txtLote.Text = "00000";
            txtFace.Text = "00";
            txtUnidade.Text = "00";
            txtSubUnidade.Text = "000";
            txtLogradouro.Text = "";
            txtQuadras.Text = "";
            txtLotes.Text = "";
            lblAtivo.Text = "";
            chkReside.Checked = false;
            chkImune.Checked = false;
            chkCIP.Checked = false;
            cmbBenfeitoria.SelectedIndex = -1;
            cmbCategoria.SelectedIndex = -1;
            cmbPedologia.SelectedIndex = -1;
            cmbSituacao.SelectedIndex = -1;
            cmbTopografia.SelectedIndex = -1;
            cmbUso.SelectedIndex = -1;
            cmbTipo.SelectedIndex = -1;
            cmbUsoC.SelectedIndex = -1;
            cmbCategoriaC.SelectedIndex = -1;
        }

        private void ControlBehaviour(bool bStart) {
            Color cor_enabled = Color.White,cor_disabled = SystemColors.ButtonFace ;

            btAdd.Enabled = bStart;
            btEdit.Enabled = bStart;
            btDel.Enabled = bStart;
            btSair.Enabled = bStart;
            btPrint.Enabled = bStart;
            btFind.Enabled = bStart;
            btGravar.Enabled = !bStart;
            btCancelar.Enabled = !bStart;
            btCod.Enabled = bStart;
            mnuAddP.Enabled = !bStart;
            mnuDelP.Enabled = !bStart;
            mnuViewP.Enabled = !bStart;
            mnuMainP.Enabled = !bStart;
            mnuAdicionarA.Enabled = !bStart;
            mnuRemoverA.Enabled = !bStart;
            mnuAddHistorico.Enabled = !bStart;
            mnuRemoverHistorico.Enabled = !bStart;
            mnuViewHistorico.Enabled = !bStart;
            chkReside.AutoCheck = !bStart;
            chkImune.AutoCheck = !bStart;
            chkCIP.AutoCheck = !bStart;
            optMT1.AutoCheck = !bStart;
            optMT2.AutoCheck= !bStart;
            btLocalImovel.Enabled = !bStart;
            txtQuadras.ReadOnly = bStart;
            txtQuadras.BackColor = bStart ? cor_disabled : cor_enabled;
            txtLotes.ReadOnly = bStart;
            txtLotes.BackColor = bStart ? cor_disabled : cor_enabled;
            txtMatricula.ReadOnly = bStart;
            txtMatricula.BackColor = bStart ? cor_disabled : cor_enabled;
            pnlArea.Visible = false;
            optEnd1.AutoCheck = !bStart;
            optEnd2.AutoCheck = !bStart;
            optEnd3.AutoCheck = !bStart;
            btEndEntrega.Enabled = !bStart;
            btAddTestada.Enabled = !bStart;
            btDelTestada.Enabled = !bStart;
            txtTestada_Face.ReadOnly = bStart;
            txtTestada_Face.BackColor = bStart ? cor_disabled : cor_enabled;
            txtTestada_Metro.ReadOnly = bStart;
            txtTestada_Metro.BackColor = bStart ? cor_disabled : cor_enabled;
            txtAreaTerreno.ReadOnly = bStart;
            txtAreaTerreno.BackColor = bStart ? cor_disabled : cor_enabled;
            txtFracao.ReadOnly = bStart;
            txtFracao.BackColor = bStart ? cor_disabled : cor_enabled;

            cmbBenfeitoria.Visible = !bStart;
            cmbCategoria.Visible = !bStart;
            cmbPedologia.Visible = !bStart;
            cmbSituacao.Visible = !bStart;
            cmbTopografia.Visible = !bStart;
            cmbUso.Visible = !bStart;
            lblBenfeitoria.Visible = bStart;
            lblCategoria.Visible = bStart;
            lblPedologia.Visible = bStart;
            lblSituacao.Visible = bStart;
            lblTopografia.Visible = bStart;
            lblUsoTerreno.Visible = bStart;


        }

        private void Carrega_Lista() {
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            cmbCategoria.DataSource = clsImovel.Lista_Categoria_Propriedade();
            cmbCategoria.DisplayMember = "Desccategprop";
            cmbCategoria.ValueMember = "Codcategprop";

            cmbTopografia.DataSource = clsImovel.Lista_Topografia();
            cmbTopografia.DisplayMember = "Desctopografia";
            cmbTopografia.ValueMember = "Codtopografia";

            cmbSituacao.DataSource = clsImovel.Lista_Situacao();
            cmbSituacao.DisplayMember = "Descsituacao";
            cmbSituacao.ValueMember = "Codsituacao";

            cmbBenfeitoria.DataSource = clsImovel.Lista_Benfeitoria();
            cmbBenfeitoria.DisplayMember = "Descbenfeitoria";
            cmbBenfeitoria.ValueMember = "Codbenfeitoria";

            cmbPedologia.DataSource = clsImovel.Lista_Pedologia();
            cmbPedologia.DisplayMember = "Descpedologia";
            cmbPedologia.ValueMember = "Codpedologia";

            cmbUso.DataSource = clsImovel.Lista_uso_terreno();
            cmbUso.DisplayMember = "Descusoterreno";
            cmbUso.ValueMember = "Codusoterreno";

            cmbUsoC.DataSource = clsImovel.Lista_Uso_Construcao();
            cmbUsoC.DisplayMember = "Descusoconstr";
            cmbUsoC.ValueMember = "Codusoconstr";

            cmbCategoriaC.DataSource = clsImovel.Lista_Categoria_Construcao();
            cmbCategoriaC.DisplayMember = "Desccategconstr";
            cmbCategoriaC.ValueMember = "Codcategconstr";

            cmbTipo.DataSource = clsImovel.Lista_Tipo_Construcao();
            cmbTipo.DisplayMember = "Desctipoconstr";
            cmbTipo.ValueMember = "Codtipoconstr";

        }

        private void TxtMatricula_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            //TODO: Tela de novo imóvel
            bAddNew = true;
            ClearFields();
            ControlBehaviour(false);
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            bAddNew = false;
            if (String.IsNullOrEmpty(lblInscricao.Text))
                MessageBox.Show("Nenhum imóvel carregado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                ControlBehaviour(false);
                btCod.Focus();
            }
        }

        private void BtGravar_Click(object sender, EventArgs e) {
            if (ValidateReg()) {
                SaveReg();
                if (bAddNew) {

                }
                ControlBehaviour(true);
            }
        }

        private void SaveReg() {
            //TODO: Gravar o imóvel
        }

        private void BtCancelar_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void BtSair_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtCod_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite o código do imóvel.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                gtiCore.Ocupado(this);
                Imovel_bll clsImovel = new Imovel_bll(_connection);
                if (clsImovel.Existe_Imovel(Convert.ToInt32(sCod))) {
                    int Codigo = Convert.ToInt32(sCod);
                    lblCod.Text = Codigo.ToString("000000");
                    ClearFields();
                    CarregaImovel(Codigo);
                    CarregaCondominio();
                } else
                    MessageBox.Show("Imóvel não cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gtiCore.Liberado(this);
            }
        }

        private void TxtNumero_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void LvProp_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e) {
            if (lvProp.SelectedIndices.Count > 0)
                lvProp.Items[lvProp.SelectedIndices[0]].ToolTipText = lvProp.Items[lvProp.SelectedIndices[0]].Tag.ToString();
        }

        private void LvProp_MouseHover(object sender, EventArgs e) {
            lvProp.Focus();
        }

        private bool ValidateReg() {
            //TODO: Validar imóvel
            return true;
        }

        private void MnuProprietario_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            int nContaP = 0;
            String sCod = z.Show("", "Incluir proprietário", "Digite o código do cidadão.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                int nCod = Convert.ToInt32(sCod);
                if(nCod<500000 || nCod>700000)
                    MessageBox.Show("Código de cidadão inválido!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                else {
                    Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                    if (!clsCidadao.ExisteCidadao(nCod))
                        MessageBox.Show("Código não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        bool bFind = false;
                        foreach (ListViewItem item in lvProp.Items) {
                            if (item.Tag.ToString() == sCod) {
                                bFind = true;
                                break;
                            }
                        }
                        if (bFind)
                            MessageBox.Show("Código já cadastrado no imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            if (lvProp.Groups["groupPP"].Items.Count > 0)
                                nContaP = lvProp.Groups["groupPP"].Items.Count;
                            else
                                nContaP = 0;

                            string sNome = clsCidadao.Retorna_Nome_Cidadao(nCod);
                            ListViewItem lvItem = new ListViewItem {
                                Group = lvProp.Groups["groupPP"]
                            };
                            if (nContaP == 0)
                                lvItem.Text = sNome + " (Principal)";
                            else
                                lvItem.Text = sNome;
                            lvItem.Tag = sCod;
                            lvProp.Items.Add(lvItem);
                        }
                    }
                }
            }
        }

        private void MnuSolidario_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Incluir proprietário solidário", "Digite o código do cidadão.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                int nCod = Convert.ToInt32(sCod);
                if (nCod < 500000 || nCod > 700000)
                    MessageBox.Show("Código de cidadão inválido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                    if (!clsCidadao.ExisteCidadao(nCod))
                        MessageBox.Show("Código não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        bool bFind = false;
                        foreach (ListViewItem item in lvProp.Items) {
                            if (item.Tag.ToString() == sCod) {
                                bFind = true;
                                break;
                            }
                        }
                        if (bFind)
                            MessageBox.Show("Código já cadastrado no imóvel.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else {
                            string sNome = clsCidadao.Retorna_Nome_Cidadao(nCod);
                            ListViewItem lvItem = new ListViewItem {
                                Group = lvProp.Groups["groupPS"],
                                Text = sNome,
                                Tag = sCod
                            };
                            lvProp.Items.Add(lvItem);
                        }
                    }
                }
            }
        }

        private void MnuRemover_Click(object sender, EventArgs e) {
            if(lvProp.SelectedItems.Count==0)
                MessageBox.Show("Selecione o cidadão a ser removido.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Remover este cidadão?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                    lvProp.SelectedItems[0].Remove();
            }
        }

        private void MnuConsultar_Click(object sender, EventArgs e) {
            if (lvProp.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o cidadão que deseja consultar.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                int nCod = Convert.ToInt32(lvProp.SelectedItems[0].Tag.ToString());
                Cidadao f1 = (Cidadao)Application.OpenForms["Cidadao"];
                if (f1 != null) 
                    f1.Close();
                Cidadao f2 = new Cidadao {
                    Tag = "Imovel",
                    CodCidadao = nCod
                };
                f2.ShowDialog();
            }
        }

        private void MnuPrincipal_Click(object sender, EventArgs e) {
            int nContaP = 0;

            if (lvProp.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o cidadão a ser promovido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (lvProp.SelectedItems[0].Group.Name == "groupPS")
                    MessageBox.Show("Proprietário solidário não pode ser o proprietário principal do imóvel. É necessário remover ele do grupo solidário e adicioná-lo ao grupo proprietário.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    //verifica se o grupo principal esta criado
                    if (lvProp.Groups["groupPP"].Items.Count > 0)
                        nContaP = lvProp.Groups["groupPP"].Items.Count;
                    //porque se existir remove o atributo do proprietário principal
                    if (nContaP > 0) {
                        foreach (ListViewItem item in lvProp.Groups["groupPP"].Items) {
                            if (item.Text.Contains("(Principal)")) {
                                item.Text = item.Text.Substring(0, item.Text.IndexOf("("));
                                break;
                            }
                        }
                    }
                    lvProp.SelectedItems[0].Text = lvProp.SelectedItems[0].Text + " (Principal)";
                }
            }
        }

        private void BtLocalImovel_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
                Id_bairro = string.IsNullOrWhiteSpace(txtBairro.Text) ? 0 : Convert.ToInt32(txtBairro.Tag.ToString())
            };
            if (txtLogradouro.Tag == null) txtLogradouro.Tag = "0";
            if (string.IsNullOrWhiteSpace(txtLogradouro.Tag.ToString()))
                txtLogradouro.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(txtLogradouro.Text) ? 0 : Convert.ToInt32(txtLogradouro.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? txtLogradouro.Text : "";
            reg.Numero_imovel = txtNumero.Text == "" ? 0 : Convert.ToInt32(txtNumero.Text);
            reg.Complemento = txtComplemento.Text;
            reg.Email ="";
            

            Forms.Endereco f1 = new Forms.Endereco(reg,true,true );
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                txtBairro.Text = f1.EndRetorno.Nome_bairro;
                txtBairro.Tag = f1.EndRetorno.Id_bairro.ToString();
                txtLogradouro.Text = f1.EndRetorno.Nome_logradouro;
                txtLogradouro.Tag = f1.EndRetorno.Id_logradouro.ToString();
                txtNumero.Text = f1.EndRetorno.Numero_imovel.ToString();
                txtComplemento.Text = f1.EndRetorno.Complemento;
                txtCep.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

        private void BtEndEntrega_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = txtUF_EE.Text == "" ? "SP" : txtUF_EE.Text,
                Id_cidade = string.IsNullOrWhiteSpace(txtCidade_EE.Text) ? 413 : Convert.ToInt32(txtCidade_EE.Tag.ToString()),
                Id_bairro = string.IsNullOrWhiteSpace(txtBairro_EE.Text) ? 0 : Convert.ToInt32(txtBairro_EE.Tag.ToString())
            };
            if (txtLogradouro_EE.Tag == null) txtLogradouro_EE.Tag = "0";
            if (string.IsNullOrWhiteSpace(txtLogradouro_EE.Tag.ToString()))
                txtLogradouro_EE.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(txtLogradouro_EE.Text) ? 0 : Convert.ToInt32(txtLogradouro_EE.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? txtLogradouro_EE.Text : "";
            reg.Numero_imovel = txtNumero_EE.Text == "" ? 0 : Convert.ToInt32(txtNumero_EE.Text);
            reg.Complemento = txtComplemento_EE.Text;
            reg.Email = "";


            Endereco f1 = new Endereco(reg, false, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                txtUF_EE.Text = f1.EndRetorno.Sigla_uf;
                txtCidade_EE.Text = f1.EndRetorno.Nome_cidade;
                txtCidade_EE.Tag = f1.EndRetorno.Id_cidade.ToString();
                txtBairro_EE.Text = f1.EndRetorno.Nome_bairro;
                txtBairro_EE.Tag = f1.EndRetorno.Id_bairro.ToString();
                txtLogradouro_EE.Text = f1.EndRetorno.Nome_logradouro;
                txtLogradouro_EE.Tag = f1.EndRetorno.Id_logradouro.ToString();
                txtNumero_EE.Text = f1.EndRetorno.Numero_imovel.ToString();
                txtComplemento_EE.Text = f1.EndRetorno.Complemento;
                txtCEP_EE.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

        private void TxtTestada_Face_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void TxtTestada_Metro_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void BtAddTestada_Click(object sender, EventArgs e) {
            if(txtTestada_Face.Text.Trim()=="")
                MessageBox.Show("Digite o nº da face.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if(gtiCore.ExtractNumber( txtTestada_Metro.Text.Trim())=="")
                    MessageBox.Show("Digite o comprimento da testada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    bool bFind = false;
                    foreach (ListViewItem item in lvTestada.Items) {
                        if (Convert.ToInt32(item.Text) == Convert.ToInt32(txtTestada_Face.Text)) {
                            bFind = true;
                            break;
                        }
                    }
                    if (bFind)
                        MessageBox.Show("Face já cadastrada.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        ListViewItem reg = new ListViewItem(Convert.ToInt32(txtTestada_Face.Text).ToString("00"));
                        reg.SubItems.Add( string.Format("{0:0.00}", Convert.ToDecimal(txtTestada_Metro.Text)));
                        lvTestada.Items.Add(reg);
                    }
                }
            }
        }

        private void BtDelTestada_Click(object sender, EventArgs e) {
            if (lvTestada.SelectedItems.Count == 0)
                MessageBox.Show("Selecione a testada a ser removida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                lvTestada.SelectedItems[0].Remove();
        }

        private void MnuAddArea_Click(object sender, EventArgs e) {
        }

        private void BtCancelPnlArea_Click(object sender, EventArgs e) {
            pnlArea.Visible = false;
            pnlTop.Enabled = true;
            tabImovel.Enabled = true;
            tBar.Enabled = true;
        }

        private void MnuAdicionarA_Click(object sender, EventArgs e) {
            tabImovel.Enabled = false;
            tBar.Enabled = false;
            pnlTop.Enabled = false;
            pnlArea.Visible = true;
            pnlArea.BringToFront();
            txtAreaConstruida.Focus();
        }

        private void TxtNumProcesso_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && txtNumProcesso.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && txtNumProcesso.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private void TxtQtdePav_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void TxtAreaTerreno_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }

        private void TxtFracao_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }

        private void TxtAreaConstruida_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }

        }

        private void BtFoto_Click(object sender, EventArgs e) {
            //TODO: Visualizar/manipular fotos do imóvel
        }

        private void BtFind_Click(object sender, EventArgs e) {

            using (var form = new Imovel_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    ClearFields();
                    CarregaImovel(val);
                }
            }
        }

        private void BtPrint_Click(object sender, EventArgs e) {
            //TODO: Imprimir dados do imóvel
        }

        private void BtOkPnlArea_Click(object sender, EventArgs e) {
            //TODO: Incluir área
            //TODO: Validar dados da área
        }

        private void MnuHistorico_Click(object sender, EventArgs e) {
            //TODO: Histórico do imóvel
        }

        private void CarregaImovel(int Codigo) {
            if (String.IsNullOrEmpty(lblCod.Text)) return;
            
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            ImovelStruct regImovel = clsImovel.Dados_Imovel(Codigo);
            if (regImovel.Codigo == 0)
                MessageBox.Show("Imóvel não cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                lblCod.Text = Codigo.ToString("000000");
                StringBuilder sInscricao = new StringBuilder();
                sInscricao.Append(regImovel.Distrito.ToString() + ".");
                sInscricao.Append(regImovel.Setor.ToString("00") + ".");
                sInscricao.Append(regImovel.Quadra.ToString("0000") + ".");
                sInscricao.Append(regImovel.Lote.ToString("00000") + ".");
                sInscricao.Append(regImovel.Seq.ToString("00") + ".");
                sInscricao.Append(regImovel.Unidade.ToString("00") + ".");
                sInscricao.Append(regImovel.SubUnidade.ToString("000"));
                lblInscricao.Text = sInscricao.ToString();
                txtNomeCond.Text = "[" + regImovel.NomeCondominio.ToString() + "]";
                chkImune.Checked = Convert.ToBoolean(regImovel.Imunidade);
                chkReside.Checked = Convert.ToBoolean(regImovel.ResideImovel);
                if (Convert.ToBoolean(regImovel.Inativo)) {
                    lblAtivo.Text = "INATIVO";
                    lblAtivo.ForeColor = Color.Red;
                } else {
                    lblAtivo.Text = "ATIVO";
                    lblAtivo.ForeColor = Color.Green;
                }

                optMT1.Checked = regImovel.TipoMat == "M" ? true : false;
                optMT2.Checked = regImovel.TipoMat == "T" ? true : false;
                txtMatricula.Text = regImovel.NumMatricula.ToString();
                lblDistrito.Text = regImovel.Distrito.ToString();
                lblSetor.Text = regImovel.Setor.ToString("00");
                txtFace.Text = regImovel.Seq.ToString("00");
                txtQuadra.Text = regImovel.Quadra.ToString("0000");
                txtLote.Text = regImovel.Lote.ToString("00000");
                txtFace.Text = regImovel.Seq.ToString("00");
                txtUnidade.Text = regImovel.Unidade.ToString("00");
                txtSubUnidade.Text = regImovel.SubUnidade.ToString("000");
                txtComplemento.Text = regImovel.Complemento.ToString();
                txtNumero.Text = regImovel.Numero.ToString();
                txtLogradouro.Text = regImovel.NomeLogradouro.ToString();
                txtLogradouro.Tag = regImovel.CodigoLogradouro.ToString();
                txtBairro.Text = regImovel.NomeBairro.ToString();
                txtBairro.Tag = regImovel.CodigoBairro.ToString();
                txtQuadras.Text = regImovel.QuadraOriginal.ToString();
                txtLotes.Text = regImovel.LoteOriginal.ToString();
                txtCep.Text =  Convert.ToInt32(regImovel.Cep.ToString()).ToString("00000-000");
                txtFracao.Text = string.Format("{0:0.00}", regImovel.FracaoIdeal);
                txtAreaTerreno.Text = string.Format("{0:0.00}", regImovel.Area_Terreno);
                cmbBenfeitoria.SelectedValue = regImovel.Benfeitoria == 0 ? -1 : regImovel.Benfeitoria;
                cmbCategoria.SelectedValue = regImovel.Categoria == 0 ? -1 : regImovel.Categoria;
                cmbPedologia.SelectedValue = regImovel.Pedologia == 0 ? -1 : regImovel.Pedologia;
                cmbSituacao.SelectedValue = regImovel.Situacao == 0 ? -1 : regImovel.Situacao;
                cmbTopografia.SelectedValue = regImovel.Topografia == 0 ? -1 : regImovel.Topografia;
                cmbUso.SelectedValue = regImovel.Uso_terreno == 0 ? -1 : regImovel.Uso_terreno;
                lblBenfeitoria.Text = regImovel.Benfeitoria_Nome;
                lblCategoria.Text = regImovel.Categoria_Nome;
                lblPedologia.Text = regImovel.Pedologia_Nome;
                lblSituacao.Text = regImovel.Situacao_Nome;
                lblTopografia.Text = regImovel.Topografia_Nome;
                lblUsoTerreno.Text = regImovel.Uso_terreno_Nome;


                //Carrega proprietário
                List<ProprietarioStruct> Lista = clsImovel.Lista_Proprietario(Codigo);
                foreach (ProprietarioStruct reg in Lista) {
                    ListViewItem lvItem = new ListViewItem();
                    if (reg.Tipo == "P")
                        lvItem.Group = lvProp.Groups["groupPP"];
                    else
                        lvItem.Group = lvProp.Groups["groupPS"];
                    if (reg.Principal == true)
                        lvItem.Text = reg.Nome + " (Principal)";
                    else
                        lvItem.Text = reg.Nome;
                    lvItem.Tag = reg.Codigo.ToString();
                    lvProp.Items.Add(lvItem);
                }

                //Carrega testada
                List<GTI_Models.Models.Testada> ListaT = clsImovel.Lista_Testada(Codigo);
                foreach (GTI_Models.Models.Testada reg in ListaT) {
                    ListViewItem lvItem = new ListViewItem(reg.Numface.ToString("00"));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)reg.Areatestada));
                    lvTestada.Items.Add(lvItem);
                }

                //Carrega Endereço de Entrega
                optEnd1.Checked = false;optEnd2.Checked = false;optEnd3.Checked = false;
                if (regImovel.EE_TipoEndereco == 0)
                    optEnd1.Checked = true;
                else if (regImovel.EE_TipoEndereco == 1)
                    optEnd2.Checked = true;
                else
                    optEnd3.Checked = true;

                bllCore.TipoEndereco Tipoend = regImovel.EE_TipoEndereco == 0 ? bllCore.TipoEndereco.Local : regImovel.EE_TipoEndereco == 1 ? bllCore.TipoEndereco.Proprietario : bllCore.TipoEndereco.Entrega;
                EnderecoStruct regEntrega = clsImovel.Dados_Endereco(Codigo, Tipoend);
                if (regEntrega != null) {
                    txtLogradouro_EE.Text = regEntrega.Endereco.ToString();
                    txtLogradouro_EE.Tag = regEntrega.CodLogradouro.ToString();
                    txtNumero_EE.Text = regEntrega.Numero.ToString();
                    txtComplemento_EE.Text = regEntrega.Complemento.ToString();
                    txtUF_EE.Text = regEntrega.UF.ToString();
                    txtCidade_EE.Text = regEntrega.NomeCidade.ToString();
                    txtCidade_EE.Tag = regEntrega.CodigoCidade.ToString();
                    txtBairro_EE.Text = regEntrega.NomeBairro.ToString();
                    txtBairro_EE.Tag = regEntrega.CodigoBairro.ToString();
                    txtCEP_EE.Text = regEntrega.Cep==null?"00000-000":  Convert.ToInt32(regEntrega.Cep.ToString()).ToString("00000-000");
                }

                //Carrega Área
                short n = 1;
                decimal SomaArea = 0;
                List<GTI_Models.Models.AreaStruct> ListaA = clsImovel.Lista_Area(Codigo);
                foreach (GTI_Models.Models.AreaStruct reg in ListaA) {
                    ListViewItem lvItem = new ListViewItem(n.ToString("00"));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", (decimal)reg.Area));
                    lvItem.SubItems.Add(reg.Uso_Nome);
                    lvItem.SubItems.Add(reg.Tipo_Nome);
                    lvItem.SubItems.Add(reg.Categoria_Nome);
                    lvItem.SubItems.Add(reg.Pavimentos.ToString());
                    lvItem.Tag = reg.Seq.ToString();
                    lvArea.Items.Add(lvItem);
                    SomaArea += (decimal)reg.Area;
                    n++;
                }
                lblSomaArea.Text = string.Format("{0:0.00}", SomaArea);
                //TODO: Ler CIP, Imunidade 
                //TODO: Carregar valor do IPTU
            }
        }

        private void CarregaCondominio() {
            if (String.IsNullOrEmpty(lblCod.Text)) return;
            int nCodigo = Convert.ToInt32(lblCod.Text);
            Imovel_bll clsImovel = new Imovel_bll(_connection);
            CondominioStruct regImovel = clsImovel.Dados_Condominio(62);
            List<AreaStruct> ListaArea = clsImovel.Lista_Area_Condominio(62);
            if (regImovel.Codigo == 0)
                MessageBox.Show("Imóvel não cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                StringBuilder sInscricao = new StringBuilder();
            }
        }

        private void btDel_Click(object sender, EventArgs e) {
            //TODO: Desativar/excluir  o imóvel
        }
    }
}
