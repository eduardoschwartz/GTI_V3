using GTI_Bll.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class LoginFunc : System.Web.UI.Page {

        protected void AcessoButton_Click(object sender, EventArgs e) {
            string sLogin = Login.Text, sNewPwd = Pwd.Text,sOldPwd,sOldPwd2,sName;
            int UserId;
            
            if (sLogin == "" )
                lblMsg.Text = "Digite o Login!";
            else {
                if(sNewPwd=="")
                    lblMsg.Text = "Digite a senha!";
                else {
                    Sistema_bll sistema_Class = new Sistema_bll("GTIconnection");
                    TAcessoFunction tacesso_Class = new TAcessoFunction();
                    sOldPwd = sistema_Class.Retorna_User_Password(sLogin);
                    UserId = sistema_Class.Retorna_User_LoginId(sLogin);
                    sName = sistema_Class.Retorna_User_FullName(UserId);
                    if (sOldPwd == null) {
                        lblMsg.Text = "Usuário/Senha inválido!";
                        Session["pUserId"] = 0;
                    } else {
                        gtiCore.pUserId = UserId;
                        gtiCore.pUserFullName = sName;
                        gtiCore.pUserLoginName = sLogin;
                        sOldPwd2 = tacesso_Class.DecryptGTI(sOldPwd);
                        if (sOldPwd2 != sNewPwd) {
                            lblMsg.Text = "Usuário/Senha inválido!";
                            Session["pUserId"] = 0;
                        } else {
                            lblMsg.Text = "";
                            Session["pUserId"] = UserId;
                            //Label lbl = Master.FindControl("lblLogin") as Label;
                            //lbl.Text = sName;
                            Response.Redirect("gtiMenu3.aspx");
                        }
                    }
                }
            }
        }

    

    }
}