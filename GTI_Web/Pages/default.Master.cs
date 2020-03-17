using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class _default : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (gtiCore.pUserId == 0) {
                lblLogin.Text = "Visitante";
                lblLogout.Visible = false;
            } else {
                lblLogin.Text = gtiCore.pUserFullName;
                lblLogout.Visible = true;
            }
        }

        protected void lblLogOut_Click(object sender, EventArgs e) {
            gtiCore.pUserId = 0;
            Response.Redirect("gtiMenu.aspx");
        }

       
    }
}