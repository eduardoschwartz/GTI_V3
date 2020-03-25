using System;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class _default : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (gtiCore.pUserId == 0) {
                lblLogin.Text = "Visitante";
                lblLogout.Visible = false;
                lblPwd.Visible = false;
                Par1.Visible = false;
                Par2.Visible = false;
            } else {
                lblLogin.Text = gtiCore.pUserFullName;
                lblLogout.Visible = true;
                lblPwd.Visible = true;
                Par1.Visible = true;
                Par2.Visible = true;
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e) {
            gtiCore.pUserId = 0;
            Session["pUserId"]=0;
            Response.Redirect("gtiMenu.aspx");
        }

        protected void lblSenha_Click(object sender, EventArgs e) {
            Response.Redirect("Senha.aspx");
        }
    }
}