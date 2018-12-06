using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class SegundaViaISS : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
        }


        protected void optCPF_CheckedChanged(object sender, EventArgs e) {
            if (optCPF.Checked) {
                txtCPF.Visible = true;
                txtCNPJ.Visible = false;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
            }
        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void VerificarButton_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text, num_cpf_cnpj = "", sNome = "", sAtividade = "";
            int _codigo = 0;

            bool isNum = Int32.TryParse(Codigo.Text, out _codigo);
            if (!isNum) {
                lblMsg.Text = "Código de contribuinte inválido!";
            } else {
                if (_codigo < 100000 || _codigo >= 300000) {
                    lblMsg.Text = "Código de contribuinte inválido!";
                } else {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else {
                        if (sCPF == "" && sCNPJ == "")
                            lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
                        else {
                            if (optCPF.Checked) {
                                num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                                if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                                    lblMsg.Text = "CPF inválido!";
                                    return;
                                }
                            } else {
                                num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                                if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                                    lblMsg.Text = "CNPJ inválido!";
                                    return;
                                }
                            }

                            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                            bool bFind = empresa_Class.Existe_Empresa(_codigo);
                            if (bFind) {
                                EmpresaStruct reg = empresa_Class.Retorna_Empresa(_codigo);
                                if (optCPF.Checked) {
                                    if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000") != num_cpf_cnpj) {
                                        lblMsg.Text = "CPF não pertence ao proprietário deste imóvel!";
                                        return;
                                    }
                                } else {
                                    if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                                        lblMsg.Text = "CNPJ não pertence ao proprietário deste imóvel!";
                                        return;
                                    }
                                }
                                sNome = reg.Razao_social;
                                sAtividade = reg.Atividade_extenso;
                            } else {
                                lblMsg.Text = "Inscrição Municipal não cadastrada!";
                                return;
                            }

                            //se chegou até aqui então a empresa esta ok para verificar os débitos


                        }
                    }
                }
            }
        }



    }
}