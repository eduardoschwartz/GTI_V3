using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Web;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class Tramite_Processo : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["pUserId"] == null || (int)Session["pUserId"] == 0) {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ConsultarButton_Click(object sender, EventArgs e) {
            string sNumProc = txtProcesso.Text.Trim();
            try {
                if (sNumProc.Length < 8) {
                    lblMsg.Text = "Número de processo inválido!";
                } else {
                    if (sNumProc.IndexOf("-") == -1)
                        lblMsg.Text = "Número de processo inválido!";
                    else {
                        if (sNumProc.IndexOf("/") == -1)
                            lblMsg.Text = "Número de processo inválido!";
                        else {
                            ProcessoNumero _processo = new ProcessoNumero();
                            _processo = gtiCore.Split_Processo_Numero(sNumProc);
                            if (_processo.Ano < 1900 || _processo.Ano > 2030)
                                lblMsg.Text = "Número de processo inválido!";
                            else {
                                if (_processo.Numero == 0)
                                    lblMsg.Text = "Número de processo inválido!";
                                else {
                                    Processo_bll processo_Class = new Processo_bll("GTIconnection");
                                    bool _existe = processo_Class.Existe_Processo(_processo.Ano, _processo.Numero);
                                    if (!_existe)
                                        lblMsg.Text = "Processo não cadastrado!";
                                    else {
                                        Response.Redirect("~/Pages/Tramite_Processo2.aspx?a=" + HttpUtility.UrlEncode(gtiCore.Encrypt(sNumProc)));
                                    }
                                }
                            }
                        }
                    }
                }

            } catch (Exception ) {

            //    throw;
            }

        }

       
    }
}