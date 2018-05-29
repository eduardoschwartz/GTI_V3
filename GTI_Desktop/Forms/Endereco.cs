using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using GTI_Desktop.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Endereco : Form {
        bool _camposObrigatorios;
        string _connection = gtiCore.Connection_Name();
        public GTI_Models.Models.Endereco EndRetorno { get; set; }

        public Endereco(GTI_Models.Models.Endereco reg, bool EnderecoLocal = false, bool EditarBairro = true,bool CamposObrigatorios = true) {
            InitializeComponent();
            Carrega_Endereco(reg);
            cmbPais.Enabled = !EnderecoLocal;
            cmbUF.Enabled = !EnderecoLocal;
            cmbCidade.Enabled = !EnderecoLocal;
            cmbBairro.Enabled = EditarBairro;
            btPais_Refresh.Enabled = !EnderecoLocal;
            btBairro_Refresh.Enabled = !EnderecoLocal;
            _camposObrigatorios = CamposObrigatorios;
        }

        private void CmbUF_SelectedIndexChanged(object sender, EventArgs e) {
            if (cmbUF.SelectedIndex > -1) {
                Endereco_bll clsCidade = new Endereco_bll(_connection);
                List<Cidade> lista = clsCidade.Lista_Cidade(cmbUF.SelectedValue.ToString());
                List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
                foreach (Cidade item in lista) {
                    myItems.Add(new CustomListBoxItem(item.Desccidade, item.Codcidade));
                }
                cmbCidade.DisplayMember = "_name";
                cmbCidade.ValueMember = "_value";
                cmbCidade.DataSource = myItems;
                if (cmbUF.SelectedIndex > 0 && cmbUF.SelectedValue.ToString() == "SP") {
                    cmbCidade.SelectedValue = 413;
                }
            }
        }

        private void Carrega_Bairro() {
            if (cmbCidade.SelectedIndex > -1) {
                Endereco_bll clsBairro = new Endereco_bll(_connection);
                List<GTI_Models.Models.Bairro> lista = clsBairro.Lista_Bairro(cmbUF.SelectedValue.ToString(), Convert.ToInt32(cmbCidade.SelectedValue));
                List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
                foreach (GTI_Models.Models.Bairro item in lista) {
                    myItems.Add(new CustomListBoxItem(item.Descbairro, item.Codbairro));
                }
                cmbBairro.DisplayMember = "_name";
                cmbBairro.ValueMember = "_value";
                cmbBairro.DataSource = myItems;
            }
        }

        private void CmbCidade_SelectedIndexChanged(object sender, EventArgs e) {
            Carrega_Bairro();
            cmbBairro.SelectedIndex = -1;
            if (Convert.ToInt32(cmbCidade.SelectedValue) == 413)
                mskCep.ReadOnly = true;
            else
                mskCep.ReadOnly = false;
        }

        private void Carrega_Pais() {
            Endereco_bll clsCidade = new Endereco_bll(_connection);
            cmbPais.DataSource = clsCidade.Lista_Pais();
            cmbPais.DisplayMember = "nome_pais";
            cmbPais.ValueMember = "id_pais";
        }

        private void Carrega_UF() {
            Endereco_bll clsCidade = new Endereco_bll(_connection);
            cmbUF.DataSource = clsCidade.Lista_UF();
            cmbUF.DisplayMember = "descuf";
            cmbUF.ValueMember = "siglauf";
        }

        private void BtPais_Refresh_Click(object sender, EventArgs e) {
            Pais frmPais = new Pais();
            frmPais.ShowDialog();
            Carrega_Pais();
        }

        private void BtBairro_Refresh_Click(object sender, EventArgs e) {
            Bairro frmBairro = new Bairro();
            frmBairro.ShowDialog();
            Carrega_Bairro();
        }

        private void TxtNum_TextChanged(object sender, EventArgs e) {
            mskCep.Text = "";
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNum.Text, "[^0-9]")) {
                MessageBox.Show("Digite apenas números.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtNum.Text = txtNum.Text.Remove(txtNum.Text.Length - 1);
                if (txtNum.Text.Length > 0) {
                    txtNum.SelectionStart = txtNum.Text.Length;
                }
                txtNum.SelectionLength = 0;
            } else {
                if (string.IsNullOrEmpty(txtLogradouro.Tag.ToString())) txtLogradouro.Tag = "0";
            }
            CarregaCep();
        }

        private void Carrega_Endereco(GTI_Models.Models.Endereco reg) {
            Carrega_Pais();
            Carrega_UF();
            if (reg.Id_pais > 0)
                cmbPais.SelectedValue = reg.Id_pais;
            if (!string.IsNullOrWhiteSpace( reg.Sigla_uf) ) {
                cmbUF.SelectedValue = reg.Sigla_uf;
                CmbUF_SelectedIndexChanged(null, null);
            }
            if (reg.Id_cidade > 0) {
                cmbCidade.SelectedValue = Convert.ToInt32(reg.Id_cidade);
                CmbCidade_SelectedIndexChanged(null, null);
            }
            if (reg.Id_bairro > 0)
                cmbBairro.SelectedValue = reg.Id_bairro;
            if (reg.Id_logradouro > 0) {
                Endereco_bll clsEndereco = new Endereco_bll(_connection);
                txtLogradouro.Text = clsEndereco.Retorna_Logradouro(reg.Id_logradouro);
            } else
                txtLogradouro.Text = reg.Nome_logradouro;
            txtLogradouro.Tag = reg.Id_logradouro;
            txtComplemento.Text = reg.Complemento;
            txtEmail.Text = reg.Email;
            txtNum.Text = reg.Numero_imovel > 0 ? reg.Numero_imovel.ToString() : "";
            if (reg.Cep > 0)
                mskCep.Text = reg.Cep.ToString();
            else
                CarregaCep();

            cmbBairro.Focus();
        }

        private void BtReturn_Click(object sender, EventArgs e) {
            if (_camposObrigatorios) {
                if (Convert.ToInt32(cmbCidade.SelectedValue) == 413) {
                    if (txtLogradouro.Tag.ToString() == "") txtLogradouro.Tag = "0";
                    if (Convert.ToInt32(txtLogradouro.Tag.ToString()) == 0) {
                        MessageBox.Show("Selecione um logradouro válido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                } else {
                    if (string.IsNullOrWhiteSpace(txtLogradouro.Text)) {
                        MessageBox.Show("Digite o nome do logradouro!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (mskCep.Text.Trim() != "-") {
                    if (!mskCep.MaskFull) {
                        MessageBox.Show("Cep inválido!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (!string.IsNullOrWhiteSpace(txtEmail.Text) & !gtiCore.Valida_Email(txtEmail.Text)) {
                    MessageBox.Show("Endereço de email inválido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            EndRetorno = new GTI_Models.Models.Endereco();
            if (cmbPais.SelectedIndex > -1) {
                EndRetorno.Id_pais = Convert.ToInt32(cmbPais.SelectedValue);
                EndRetorno.Nome_pais = cmbPais.Text;
            } else {
                EndRetorno.Id_pais = 0;
                EndRetorno.Nome_pais = "";
            }
            if (cmbUF.SelectedIndex > -1) {
                EndRetorno.Sigla_uf = cmbUF.SelectedValue.ToString();
                EndRetorno.Nome_uf = cmbUF.Text;
            } else {
                EndRetorno.Sigla_uf = "";
                EndRetorno.Nome_uf = "";
            }
            if (cmbCidade.SelectedIndex > -1) {
                EndRetorno.Id_cidade = Convert.ToInt32(cmbCidade.SelectedValue);
                EndRetorno.Nome_cidade = cmbCidade.Text;
            } else {
                EndRetorno.Id_cidade = 0;
                EndRetorno.Nome_cidade = "";
            }
            if (cmbBairro.SelectedIndex > -1) {
                EndRetorno.Id_bairro = Convert.ToInt32(cmbBairro.SelectedValue);
                EndRetorno.Nome_bairro = cmbBairro.Text;
            } else {
                EndRetorno.Id_bairro = 0;
                EndRetorno.Nome_bairro = "";
            }

            if (String.IsNullOrEmpty(txtLogradouro.Tag.ToString())) txtLogradouro.Tag = "0";
            EndRetorno.Id_logradouro = Convert.ToInt32(txtLogradouro.Tag.ToString());
            EndRetorno.Nome_logradouro = txtLogradouro.Text;
            if (String.IsNullOrEmpty(txtNum.Text.ToString())) txtNum.Text = "0";
            EndRetorno.Numero_imovel = Convert.ToInt32(txtNum.Text);
            EndRetorno.Complemento = txtComplemento.Text;
            EndRetorno.Email = txtEmail.Text;
            string _cep = gtiCore.ExtractNumber(mskCep.Text);
            EndRetorno.Cep = _cep == "" ? 0 : Convert.ToInt32(_cep);
            EndRetorno.Cancelar = false;
            this.Close();
            return;
        }

        private void TxtLogradouro_KeyDown(object sender, KeyEventArgs e) {
            if (Convert.ToInt32(cmbCidade.SelectedValue) != 413) {
                mskCep.Text = "";
                return;
            }
            if (!String.IsNullOrEmpty(txtLogradouro.Text) && e.KeyCode == Keys.Enter) {
                Endereco_bll clsImovel = new Endereco_bll(_connection);
                List<Logradouro> Listalogradouro = clsImovel.Lista_Logradouro(txtLogradouro.Text);

                lstLogr.DataSource = Listalogradouro;
                lstLogr.DisplayMember = "endereco";
                lstLogr.ValueMember = "codlogradouro";
                if (lstLogr.Items.Count > 0) {
                    lstLogr.Visible = true;
                    lstLogr.BringToFront();
                    lstLogr.DroppedDown = true;
                    lstLogr.Focus();
                } else {
                    MessageBox.Show("Logradouro não localizado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLogradouro.Focus();
                }
            } else
                txtLogradouro.Tag = "";
        }

        private void LstLogr_KeyDown(object sender, KeyEventArgs e) {
            if (lstLogr.SelectedValue == null) return;
            if (e.KeyCode == Keys.Escape) {
                lstLogr.Visible = false;
                txtLogradouro.Focus();
                return;
            }
            if (e.KeyCode == Keys.Enter) {
                txtLogradouro.Text = lstLogr.Text;
                txtLogradouro.Tag = lstLogr.SelectedValue.ToString();
                lstLogr.Visible = false;
                CarregaCep();
                txtNum.Focus();
            }
        }

        private void LstLogr_Leave(object sender, EventArgs e) {
            if (lstLogr.SelectedValue == null) {
                txtLogradouro.Text = "";
                txtLogradouro.Tag = "";
            } else {
                txtLogradouro.Text = lstLogr.Text;
                txtLogradouro.Tag = lstLogr.SelectedValue.ToString();
            }
            lstLogr.Visible = false;
            txtNum.Focus();
            CarregaCep();
        }

        private void CmbBairro_SelectedIndexChanged(object sender, EventArgs e) {
            txtLogradouro.Focus();
        }

        private void TxtNum_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                txtComplemento.Focus();
        }

        private void TxtComplemento_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                mskCep.Focus();
        }

        private void MskCep_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                btReturn.Focus();
        }

        private void CarregaCep() {
            if (Convert.ToInt32(txtLogradouro.Tag.ToString()) == 0)
                txtLogradouro.Tag = "0";

            if (cmbUF.SelectedValue.ToString() == "SP" && Convert.ToInt32(cmbCidade.SelectedValue) == 413)  {
                Endereco_bll clsEndereco = new Endereco_bll(_connection);
                int nCep = clsEndereco.RetornaCep(Convert.ToInt32(txtLogradouro.Tag.ToString()), txtNum.Text==""?(short)0:  Convert.ToInt16(txtNum.Text));
                mskCep.Text = nCep.ToString("00000-000");
            } 
        }

        private void LstLogr_TextChanged(object sender, EventArgs e) {
            mskCep.Text = "";
        }

        private void BtCancel_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Cancelar a edição do endereço?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                EndRetorno = new GTI_Models.Models.Endereco {
                    Cancelar = true
                };
                this.Close();
                return;
            }
        }

        private void Endereco_Load(object sender, EventArgs e) {

        }
    }
}
