using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTI_Web.Pages {
    public partial class gtiMenu3 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["pUserId"] == null) {
                Response.Redirect("LoginFunc.aspx");
            }
        }
    }
}