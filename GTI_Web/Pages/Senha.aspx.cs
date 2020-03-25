using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class Senha : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void OKButton_Click(object sender, EventArgs e) {
            if (SenhaAtual.Text.Trim() == "" || NovaSenha.Text.Trim()=="" || Confirmacao.Text.Trim()=="") {
                lblMsg.Text = "Preencha todos os campos!";
            } else {
                Sistema_bll sistema_Class = new Sistema_bll("GTIconnection");
                TAcessoFunction tacesso_Class = new TAcessoFunction();
                string _oldPwd = tacesso_Class.DecryptGTI(sistema_Class.Retorna_User_Password(gtiCore.pUserLoginName));
                if (SenhaAtual.Text != _oldPwd) {
                    lblMsg.Text = "Senha atual não confere!";
                } else {
                    if (NovaSenha.Text != Confirmacao.Text) {
                        lblMsg.Text = "Nova senha e a confirmação de senha são diferentes!";
                    } else {
                        Usuario reg = new Usuario {
                            Nomelogin = gtiCore.pUserLoginName,
                            Senha = tacesso_Class.Encrypt128(NovaSenha.Text)
                        };
                        Exception ex = sistema_Class.Alterar_Senha(reg);
                        if (ex != null)
                            lblMsg.Text = "Erro, senha não alterada";
                        else {
                            gtiCore.pUserId = 0;
                            Session["pUserId"] = 0;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "MsgChange();", true);
                            Response.Redirect("Login.aspx");
                        }
                    }
                }
            }
        }
    }
}