using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Cidadao : Form {
        bool bAddNew;
        int _CodCidadao = 0;
        string _connection = gtiCore.Connection_Name();

        public int CodCidadao {
            get { return (_CodCidadao); }
            set {
                _CodCidadao = value;
                bAddNew = false;
                LoadReg(_CodCidadao);
            }
        }

        public Cidadao() {
            InitializeComponent();
            Carrega_Profissao();
            Clear_Reg();
            ControlBehaviour(true);
        }

        private void Carrega_Profissao() {
            Cidadao_bll clsProfissao = new Cidadao_bll(_connection);
            List<GTI_Models.Models.Profissao> lista = clsProfissao.Lista_Profissao();
            cmbProfissao.DataSource = lista;
            cmbProfissao.DisplayMember = "nome";
            cmbProfissao.ValueMember = "codigo";
        }

        private void CmbPessoa_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbPessoa.SelectedIndex == 0) {
                lblNomeDoc.Text = "CPF....:";
                mskCPF.BringToFront();
                mskCNPJ.SendToBack();
            } else {
                lblNomeDoc.Text = "CNPJ..:";
                mskCPF.SendToBack();
                mskCNPJ.BringToFront();
            }
            txtPessoa.Text = cmbPessoa.Text;
            txtPessoa.Tag = (cmbPessoa.SelectedIndex+1).ToString();
        }

        private void Clear_Reg() {
            lblCod.Text = "000000";
            lblTipoCidadao.Text = "";
            txtNome.Text = "";
            cmbPessoa.SelectedIndex = 0;
            txtPessoa.Text = "";
            txtPessoa.Tag = "";
            mskCPF.Text = "";
            mskCNPJ.Text = "";
            txtRG.Text = "";
            txtOrgao.Text = "";
            mskDataNascto.Text = "";
            cmbProfissao.SelectedIndex = -1;
            txtProfissao.Text = "";
            txtProfissao.Tag = "";
            txtEmailR.Text = "";
            txtFoneR.Text = "";
            txtLogradouroR.Text = "";
            txtNumeroR.Text = "";
            txtBairroR.Text = "";
            txtComplementoR.Text = "";
            txtCidadeR.Text = "";
            txtUFR.Text = "";
            txtCepR.Text = "";
            txtPaisR.Text = "";
            chkEtiquetaR.Checked = false;
            txtLogradouroC.Text = "";
            txtNumeroC.Text = "";
            txtBairroC.Text = "";
            txtComplementoC.Text = "";
            txtCidadeC.Text = "";
            txtUFC.Text = "";
            txtCepC.Text = "";
            txtPaisC.Text = "";
            chkEtiquetaC.Checked = false;
        }

        private void ControlBehaviour(bool bStart) {
            Color color_enable = Color.White, color_disable = this.BackColor;
            btFindCodigo.Enabled = bStart;
            btAdd.Enabled = bStart;
            btEdit.Enabled = bStart;
            btDel.Enabled = bStart;
            btExit.Enabled = bStart;
            btFind.Enabled = bStart;
            btGravar.Enabled = !bStart;
            btCancelar.Enabled = !bStart;
            btProfissao_Edit.Enabled = !bStart;
            btProfissao_Del.Enabled = !bStart;
            btAddEnderecoR.Enabled = !bStart;
            btAddEnderecoC.Enabled = !bStart;
            btDelEnderecoR.Enabled = !bStart;
            btDelEnderecoC.Enabled = !bStart;

            TextBox box;
            MaskedTextBox mbox;

            foreach (Control c in this.Controls) {
                if (c is TextBox) {
                    box = c as TextBox;
                    box.ReadOnly = bStart;
                } else if (c is MaskedTextBox) {
                    mbox = c as MaskedTextBox;
                    mbox.ReadOnly = bStart;
                }
            }

            foreach (Control c in this.pnlEndR.Controls) {
                if (c is TextBox) {
                    box = c as TextBox;
                    box.ReadOnly = true;
                    box.BackColor =  color_disable;
                } else if (c is MaskedTextBox) {
                    mbox = c as MaskedTextBox;
                    mbox.ReadOnly = true;
                }
            }

            foreach (Control c in this.pnlEndC.Controls) {
                if (c is TextBox) {
                    box = c as TextBox;
                    box.ReadOnly = true;
                    box.BackColor = color_disable;
                } else if (c is MaskedTextBox) {
                    mbox = c as MaskedTextBox;
                    mbox.ReadOnly = true;
                }
            }

            txtPessoa.ReadOnly = true;
            txtPessoa.Visible = bStart;
            cmbPessoa.Enabled = !bStart;
            cmbPessoa.Visible = !bStart;
            txtProfissao.Visible = bStart;
            cmbProfissao.Enabled = !bStart;
            cmbProfissao.Visible = !bStart;
            chkJuridica.Enabled = !bStart;
            chkEtiquetaR.Enabled = !bStart;
            chkEtiquetaC.Enabled = !bStart;
        }

        private void BtFindCodigo_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite o código do cidadão.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                gtiCore.Ocupado(this);
                Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                if (clsCidadao.ExisteCidadao(Convert.ToInt32(sCod))) {
                    Clear_Reg();
                    LoadReg(Convert.ToInt32(sCod));
                } else
                    MessageBox.Show("Cidadão não cadastrado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gtiCore.Liberado(this);
            }
        }

        private void BtAdd_Click(object sender, EventArgs e) {
            bAddNew = true;
            Clear_Reg();
            ControlBehaviour(false);
            txtNome.Focus();
        }

        private void BtEdit_Click(object sender, EventArgs e) {
            if (Convert.ToInt32(lblCod.Text) == 0)
                MessageBox.Show("Selecione um cidadão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bAddNew = false;
                ControlBehaviour(false);
            }
        }

        private void BtGravar_Click(object sender, EventArgs e) {
            if (ValidateReg()) {
                SaveReg();
                btFindCodigo.Focus();
            }
        }

        private void BtCancelar_Click(object sender, EventArgs e) {
            Int32 nCod = Convert.ToInt32(lblCod.Text);
            if (nCod > 0)
                LoadReg(nCod);
            ControlBehaviour(true);
        }

        private void BtExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BtFind_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    LoadReg(val);
                }
            }
        }

        private void LoadReg(Int32 nCodigo) {
            Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
            CidadaoStruct reg = clsCidadao.LoadReg(nCodigo);
            lblCod.Text = reg.Codigo.ToString("000000");
            txtNome.Text = reg.Nome;
            txtRG.Text = reg.Rg ?? "";
            txtOrgao.Text = reg.Orgao ?? "";
            if (reg.DataNascto != null)
                mskDataNascto.Text = Convert.ToDateTime(reg.DataNascto).ToString("dd/MM/yyyy");
            txtFoneR.Text = reg.TelefoneR ?? "";
            txtEmailR.Text = reg.EmailR ?? "";
            if (reg.CodigoProfissao == null || reg.CodigoProfissao == 0) {
                cmbProfissao.SelectedIndex = -1;
                txtProfissao.Text = "";
                txtProfissao.Tag = "";
            } else {
                cmbProfissao.SelectedValue = reg.CodigoProfissao;
                txtProfissao.Text = cmbProfissao.Text;
                txtProfissao.Tag = reg.CodigoProfissao;
            }
            chkJuridica.Checked = reg.Juridica;

            if (reg.Tipodoc == 1) {
                cmbPessoa.SelectedIndex = 0;
                mskCPF.Text = reg.Cpf;
            } else if(reg.Tipodoc==2){
                cmbPessoa.SelectedIndex = 1;
                mskCNPJ.Text = reg.Cnpj;
            } else {
                cmbPessoa.SelectedIndex = 0;
                mskCPF.Text = "";
            }
            txtPessoa.Text = cmbPessoa.Text;
            txtPessoa.Tag = reg.Tipodoc;

            txtLogradouroR.Text = reg.EnderecoR;
            txtLogradouroR.Tag = reg.CodigoLogradouroR.ToString();
            if(!string.IsNullOrWhiteSpace(txtLogradouroR.Text)) {
                txtNumeroR.Text = reg.NumeroR.ToString();
                txtComplementoR.Text = reg.ComplementoR;
                txtBairroR.Text = reg.NomeBairroR;
                txtBairroR.Tag = reg.CodigoBairroR.ToString();
                txtCidadeR.Text = reg.NomeCidadeR;
                txtCidadeR.Tag = reg.CodigoCidadeR.ToString();
                txtUFR.Text = reg.UfR;
                txtPaisR.Text = reg.PaisR;
                txtPaisR.Tag = reg.CodigoPaisR.ToString();
                txtCepR.Text = reg.CepR.ToString();
                txtEmailR.Text = reg.EmailR;
                chkEtiquetaR.Checked = reg.EtiquetaR == "S";
            } else {
                txtNumeroR.Text = "";
                txtComplementoR.Text = "";
                txtBairroR.Text = "";
                txtBairroR.Tag = "";
                txtCidadeR.Text = "";
                txtCidadeR.Tag = "";
                txtUFR.Text = "";
                txtPaisR.Text = "";
                txtPaisR.Tag = "";
                txtCepR.Text = "";
                txtEmailR.Text = "";
                chkEtiquetaR.Checked =false;
            }

            txtLogradouroC.Text = reg.EnderecoC;
            txtLogradouroC.Tag = reg.CodigoLogradouroC.ToString();
            if (!string.IsNullOrWhiteSpace(txtLogradouroC.Text)) {
                txtNumeroC.Text = reg.NumeroC.ToString();
                txtComplementoC.Text = reg.ComplementoC;
                txtBairroC.Text = reg.NomeBairroC;
                txtBairroC.Tag = reg.CodigoBairroC.ToString();
                txtCidadeC.Text = reg.NomeCidadeC;
                txtCidadeC.Tag = reg.CodigoCidadeC.ToString();
                txtUFC.Text = reg.UfC;
                txtPaisC.Text = reg.PaisC;
                txtPaisC.Tag = reg.CodigoPaisC.ToString();
                txtCepC.Text = reg.CepC.ToString();
                txtEmailC.Text = reg.EmailC;
                chkEtiquetaC.Checked = reg.EtiquetaC == "S";
            } else {
                txtLogradouroC.Text = "";
                txtLogradouroC.Tag = "";
                txtNumeroC.Text = "";
                txtComplementoC.Text = "";
                txtBairroC.Text = "";
                txtBairroC.Tag = "";
                txtCidadeC.Text = "";
                txtCidadeC.Tag = "";
                txtUFC.Text = "";
                txtPaisC.Text = "";
                txtPaisC.Tag = "";
                txtCepC.Text = "";
                txtEmailC.Text = "";
                chkEtiquetaC.Checked = false;
            }

            if (!chkEtiquetaR.Checked && !chkEtiquetaC.Checked) chkEtiquetaR.Checked = true;
        }

        private bool ValidateReg() {
            if (!gtiCore.IsEmptyDate(mskDataNascto.Text) && !gtiCore.IsDate(mskDataNascto.Text)) {
                MessageBox.Show("Data de nascimento inválida.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtLogradouroR.Text) & string.IsNullOrEmpty(txtLogradouroC.Text)) {
                MessageBox.Show("Digite um endereço válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!chkEtiquetaR.Checked & !chkEtiquetaC.Checked) {
                MessageBox.Show("Selecione o endereço principal.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (chkEtiquetaR.Checked & chkEtiquetaC.Checked) {
                MessageBox.Show("Selecione apenas um endereço como principal.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if ((string.IsNullOrEmpty(txtLogradouroC.Text) & chkEtiquetaC.Checked) || (string.IsNullOrEmpty(txtLogradouroR.Text) & chkEtiquetaR.Checked)) {
                MessageBox.Show("Endereço principal inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbPessoa.SelectedIndex==0 && !mskCPF.MaskFull) {
                MessageBox.Show("Digite um CPF válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbPessoa.SelectedIndex == 0 && !gtiCore.Valida_CPF(mskCPF.Text)) {
                MessageBox.Show("Digite um CPF válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbPessoa.SelectedIndex == 1 && !mskCNPJ.MaskFull) {
                MessageBox.Show("Digite um CNPJ válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbPessoa.SelectedIndex == 1 && !gtiCore.Valida_CNPJ(mskCNPJ.Text)) {
                MessageBox.Show("Digite um CNPJ válido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmailR.Text) & !gtiCore.Valida_Email(txtEmailR.Text)) {
                MessageBox.Show("Endereço de email inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!string.IsNullOrEmpty(txtEmailC.Text) & !gtiCore.Valida_Email(txtEmailC.Text)) {
                MessageBox.Show("Endereço de email inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SaveReg() {
            if (MessageBox.Show("Gravar os dados?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes){
                GTI_Models.Models.Cidadao reg = new GTI_Models.Models.Cidadao {
                    Nomecidadao = txtNome.Text,
                    Rg = String.IsNullOrWhiteSpace(txtRG.Text) ? null : txtRG.Text,
                    Orgao = String.IsNullOrWhiteSpace(txtOrgao.Text) ? null : txtOrgao.Text
                };
                if (cmbPessoa.SelectedIndex == 0) {
                    if (mskCPF.Text != "")
                        reg.Cpf = mskCPF.Text;
                } else {
                    if (mskCNPJ.Text != "")
                        reg.Cnpj = mskCNPJ.Text;
                }
                reg.Telefone = String.IsNullOrWhiteSpace(txtFoneR.Text) ? null : txtFoneR.Text;
                reg.Juridica = chkJuridica.Checked ? true : false;
                if ( mskDataNascto.MaskCompleted &&  gtiCore.IsDate(mskDataNascto.Text))
                    reg.Data_nascimento = Convert.ToDateTime(mskDataNascto.Text);
                else
                    reg.Data_nascimento = null;
                if (cmbProfissao.SelectedIndex > -1)
                    reg.Codprofissao = Convert.ToInt32(cmbProfissao.SelectedValue);

                if (!string.IsNullOrWhiteSpace(txtLogradouroR.Text)) {
                    reg.Codpais = txtPaisR.Tag == null ? 0 : Convert.ToInt32(txtPaisR.Tag.ToString());
                    reg.Siglauf = txtUFR.Text;
                    reg.Codcidade = string.IsNullOrWhiteSpace(txtCidadeR.Tag.ToString()) ? (short)0 : Convert.ToInt16(txtCidadeR.Tag.ToString());
                    reg.Codbairro = string.IsNullOrWhiteSpace( txtBairroR.Tag.ToString())? (short)0 : Convert.ToInt16(txtBairroR.Tag.ToString());
                    reg.Codlogradouro =string.IsNullOrWhiteSpace( txtLogradouroR.Tag.ToString()) ? 0 : Convert.ToInt32(txtLogradouroR.Tag.ToString());
                    reg.Nomelogradouro = reg.Codcidade != 413 ? txtLogradouroR.Text : "";
                    reg.Numimovel = txtNumeroR.Text == "" ? (short)0 : Convert.ToInt16(txtNumeroR.Text);
                    reg.Complemento = txtComplementoR.Text;
                    reg.Cep = reg.Codcidade != 413 ? txtCepR.Text == "" ? 0 : Convert.ToInt32(txtCepR.Text) : 0;
                    reg.Email = txtEmailR.Text;
                    reg.Etiqueta = chkEtiquetaR.Checked ? "S" : "N";
                }

                if (!string.IsNullOrWhiteSpace(txtLogradouroC.Text)) {
                    reg.Codpais2 = txtPaisC.Tag == null ? 0 : Convert.ToInt32(txtPaisC.Tag.ToString());
                    reg.Siglauf2 = txtUFC.Text;
                    reg.Codcidade2 = string.IsNullOrWhiteSpace(txtCidadeC.Tag.ToString()) ? (short)0 : Convert.ToInt16(txtCidadeC.Tag.ToString());
                    reg.Codbairro2 = string.IsNullOrWhiteSpace(txtBairroC.Tag.ToString()) ? (short)0 : Convert.ToInt16(txtBairroC.Tag.ToString());
                    reg.Codlogradouro2 = string.IsNullOrWhiteSpace( txtLogradouroC.Tag.ToString()) ? 0 : Convert.ToInt32(txtLogradouroC.Tag.ToString());
                    reg.Nomelogradouro2 = reg.Codcidade2 != 413 ? txtLogradouroC.Text : "";
                    reg.Numimovel2 = txtNumeroC.Text == "" ? (short)0 : Convert.ToInt16(txtNumeroC.Text);
                    reg.Complemento2 = txtComplementoC.Text;
                    reg.Cep2 = reg.Codcidade2 != 413 ? txtCepC.Text == "" ? 0 : Convert.ToInt32(txtCepC.Text) : 0;
                    reg.Email2 = txtEmailC.Text;
                    reg.Etiqueta2 = chkEtiquetaC.Checked ? "S" : "N";
                }

                Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                Exception ex;
                
                if (bAddNew) {
                    ex = clsCidadao.Incluir_cidadao(reg);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else {
                        int nLastCod = clsCidadao.Retorna_Ultimo_Codigo_Cidadao();
                        LoadReg(nLastCod);
                        ControlBehaviour(true);
                    }
                } else {
                    reg.Codcidadao = Convert.ToInt32(lblCod.Text);
                    ex = clsCidadao.Alterar_cidadao(reg);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else {
                        ControlBehaviour(true);
                    }
                }

                int nCodigo = 0;
                if (bAddNew)
                    nCodigo = clsCidadao.Retorna_Ultimo_Codigo_Cidadao();
                else
                    nCodigo = Convert.ToInt32(lblCod.Text);


            }
        }

        private void BtDel_Click(object sender, EventArgs e) {
            int nCodigo = Convert.ToInt32(lblCod.Text);
            if (nCodigo == 0)
                MessageBox.Show("Selecione um cidadão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (MessageBox.Show("Excluir este registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Cidadao_bll clsCidadao = new Cidadao_bll(_connection);
                    Exception ex= clsCidadao.Excluir_cidadao(nCodigo);
                    if (ex != null) {
                        ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                        eBox.ShowDialog();
                    } else
                        Clear_Reg();
                }
            }
        }

        private void BtProfissao_Del_Click(object sender, EventArgs e) {
            cmbProfissao.SelectedIndex = -1;
        }

        private void BtProfissao_Edit_Click(object sender, EventArgs e) {
            Carrega_Profissao();
        }

        private void CmbProfissao_SelectedIndexChanged(object sender, EventArgs e) {
            txtProfissao.Text = cmbProfissao.Text;
            if (cmbProfissao.SelectedIndex==-1)
                txtProfissao.Tag = "";
            else
                txtProfissao.Tag = cmbProfissao.SelectedValue.ToString();

        }

        private void ChkEtiquetaR_CheckedChanged(object sender, EventArgs e) {
            chkEtiquetaC.Checked = !chkEtiquetaR.Checked;
        }

        private void ChkEtiquetaC_CheckedChanged(object sender, EventArgs e) {
            chkEtiquetaR.Checked = !chkEtiquetaC.Checked;
        }

        private void BtAddEnderecoR_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = string.IsNullOrWhiteSpace(txtPaisR.Text) ? 1 : Convert.ToInt32(txtPaisR.Tag.ToString()),
                Sigla_uf = txtUFR.Text == "" ? "SP" : txtUFR.Text,
                Id_cidade = string.IsNullOrWhiteSpace(txtCidadeR.Text) ? 413 : Convert.ToInt32(txtCidadeR.Tag.ToString()),
                Id_bairro = string.IsNullOrWhiteSpace(txtBairroR.Text) ? 0 : Convert.ToInt32(txtBairroR.Tag.ToString())
            };
            if (txtLogradouroR.Tag == null) txtLogradouroR.Tag = "0";
            if (string.IsNullOrWhiteSpace(txtLogradouroR.Tag.ToString()))
                txtLogradouroR.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(txtLogradouroR.Text) ? 0 : Convert.ToInt32(txtLogradouroR.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? txtLogradouroR.Text : "";
            reg.Numero_imovel = txtNumeroR.Text == "" ? 0 : Convert.ToInt32(txtNumeroR.Text);
            reg.Complemento = txtComplementoR.Text;
            reg.Email = txtEmailR.Text;
            reg.Cep = reg.Id_cidade != 413 ? txtCepR.Text == "" ? 0 : Convert.ToInt32(gtiCore.ExtractNumber( txtCepR.Text)) : 0;

            Forms.Endereco f1 = new Forms.Endereco(reg);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                txtPaisR.Text = f1.EndRetorno.Nome_pais;
                txtPaisR.Tag = f1.EndRetorno.Id_pais.ToString();
                txtUFR.Text = f1.EndRetorno.Sigla_uf;
                txtCidadeR.Text = f1.EndRetorno.Nome_cidade;
                txtCidadeR.Tag = f1.EndRetorno.Id_cidade.ToString();
                txtBairroR.Text = f1.EndRetorno.Nome_bairro;
                txtBairroR.Tag = f1.EndRetorno.Id_bairro.ToString();
                txtLogradouroR.Text = f1.EndRetorno.Nome_logradouro;
                txtLogradouroR.Tag = f1.EndRetorno.Id_logradouro.ToString();
                txtNumeroR.Text = f1.EndRetorno.Numero_imovel.ToString();
                txtComplementoR.Text = f1.EndRetorno.Complemento;
                txtEmailR.Text = f1.EndRetorno.Email;
                txtCepR.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

        private void BtAddEnderecoC_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = string.IsNullOrWhiteSpace(txtPaisC.Text) ? 1 : Convert.ToInt32(txtPaisC.Tag.ToString()),
                Sigla_uf = txtUFC.Text == "" ? "SP" : txtUFC.Text,
                Id_cidade = string.IsNullOrWhiteSpace(txtCidadeC.Text) ? 413 : Convert.ToInt32(txtCidadeC.Tag.ToString()),
                Id_bairro = string.IsNullOrWhiteSpace(txtBairroC.Text) ? 0 : Convert.ToInt32(txtBairroC.Tag.ToString())
            };
            if (txtLogradouroC.Tag == null) txtLogradouroC.Tag = "0";
            if (string.IsNullOrWhiteSpace(txtLogradouroC.Tag.ToString()))
                txtLogradouroC.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(txtLogradouroC.Text) ? 0 : Convert.ToInt32(txtLogradouroC.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? txtLogradouroC.Text : "";
            reg.Numero_imovel = txtNumeroC.Text == "" ? 0 : Convert.ToInt32(txtNumeroC.Text);
            reg.Complemento = txtComplementoC.Text;
            reg.Email = txtEmailC.Text;
            reg.Cep = reg.Id_cidade != 413 ? txtCepC.Text == "" ? 0 : Convert.ToInt32(gtiCore.ExtractNumber( txtCepC.Text)) : 0;

            Forms.Endereco f1 = new Forms.Endereco(reg);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                txtPaisC.Text = f1.EndRetorno.Nome_pais;
                txtPaisC.Tag = f1.EndRetorno.Id_pais.ToString();
                txtUFC.Text = f1.EndRetorno.Sigla_uf;
                txtCidadeC.Text = f1.EndRetorno.Nome_cidade;
                txtCidadeC.Tag = f1.EndRetorno.Id_cidade.ToString();
                txtBairroC.Text = f1.EndRetorno.Nome_bairro;
                txtBairroC.Tag = f1.EndRetorno.Id_bairro.ToString();
                txtLogradouroC.Text = f1.EndRetorno.Nome_logradouro;
                txtLogradouroC.Tag = f1.EndRetorno.Id_logradouro.ToString();
                txtNumeroC.Text = f1.EndRetorno.Numero_imovel.ToString();
                txtComplementoC.Text = f1.EndRetorno.Complemento;
                txtEmailC.Text = f1.EndRetorno.Email;
                txtCepC.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

    }
}
