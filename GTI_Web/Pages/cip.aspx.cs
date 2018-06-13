using System;

namespace GTI_Web.Pages {
    public partial class cip : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Response.Redirect("~/Pages/wait.aspx");
        }
    }
}