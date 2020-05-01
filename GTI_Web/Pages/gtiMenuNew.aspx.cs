using System;

namespace GTI_Web.Pages {
    public partial class gtiMenu : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            Response.Redirect("http://sistemas.jaboticabal.sp.gov.br/gti/");
        }
    }
}