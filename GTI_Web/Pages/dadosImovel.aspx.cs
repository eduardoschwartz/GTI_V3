using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class dadosImovel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

            if (!IsPostBack) {
                txtCNPJ.Text = "";
                txtIM.Text = "";
                lblMsg.Text = "";
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                txtIM.Text = "";
            }
        }

        protected void optCPF_CheckedChanged(object sender, EventArgs e) {
            if (optCPF.Checked) {
                txtCPF.Visible = true;
                txtCNPJ.Visible = false;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                txtIM.Text = "";
            }
        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            txtCNPJ.Text = "";
        
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            txtCPF.Text = "";
          
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            lblMsg.Text = "";
            Imovel_bll imovel_class = new Imovel_bll("GTIconnection");
            if (string.IsNullOrWhiteSpace(txtIM.Text) && string.IsNullOrWhiteSpace(txtCNPJ.Text) && string.IsNullOrWhiteSpace(txtCPF.Text))
                lblMsg.Text = "Digite IM ou CPF ou CNPJ.";
            else {
                if (!string.IsNullOrWhiteSpace(txtIM.Text) && (!string.IsNullOrWhiteSpace(txtCNPJ.Text) || !string.IsNullOrWhiteSpace(txtCPF.Text))) {

                } else {
                    lblMsg.Text = "Erro: Digite a inscrição municipal e o CPF ou o CNPJ do proprietário.";
                    return;
                }

                if (!string.IsNullOrWhiteSpace(txtIM.Text)) {
                    if (!imovel_class.Existe_Imovel(Convert.ToInt32(txtIM.Text))) {
                        lblMsg.Text = "Erro: Cadastro inexistente.";
                        return;
                    }
                } 

                if (optCPF.Checked && txtCPF.Text.Length < 14) {
                    lblMsg.Text = "CPF inválido!";
                    return;
                }
                if (optCNPJ.Checked && txtCNPJ.Text.Length < 18) {
                    lblMsg.Text = "CNPJ inválido!";
                    return;
                }
                string num_cpf_cnpj = "";
                if (optCPF.Checked) {
                    num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                    if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                        lblMsg.Text = "CPF inválido!";
                        return;
                    } else {
                        //valida codigo cpf
                    }
                } else {
                    num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                    if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                        lblMsg.Text = "CNPJ inválido!";
                        return;
                    } else {
                        //valida codigo cnpj
                    }
                }
                Imprimir_Ficha(Convert.ToInt32(txtIM.Text));
               
            }
        }

        private void Imprimir_Ficha(int Codigo) {
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Dados_Imovel.rpt"));

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");

            ImovelStruct _dados = imovel_Class.Dados_Imovel(Codigo);
            string _ativo = "SIM";
            string _controle = "XXX";


            dados_imovel_rpt cert = new dados_imovel_rpt();
            cert.Codigo = Codigo;
            Exception ex = imovel_Class.Insert_Dados_Imovel(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("CODIGO", _dados.Codigo.ToString("000000"));
                crystalReport.SetParameterValue("INSCRICAO", _dados.Inscricao);
                crystalReport.SetParameterValue("SITUACAO", _ativo);
                crystalReport.SetParameterValue("MT", _dados.NumMatricula);
                crystalReport.SetParameterValue("PROPRIETARIO", _dados.Proprietario_Nome);
                crystalReport.SetParameterValue("CONTROLE", _controle);

                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

                try {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Ficha_Cadastral");
                } catch {
                } finally {
                    crystalReport.Close();
                    crystalReport.Dispose();
                }
            }
        }

    }
}