using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class Tramite_Processo2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["pUserId"] == null || (int)Session["pUserId"] == 0) {
                Response.Redirect("Login.aspx");
            }

            string sNumProc = gtiCore.Decrypt(Request.QueryString["a"]); ;
            try {
                Processo_bll processo_Class = new Processo_bll("GTIconnection");
                ProcessoNumero _numero = gtiCore.Split_Processo_Numero(sNumProc);
                ProcessoStruct _processo = processo_Class.Dados_Processo(_numero.Ano, _numero.Numero);
                Processo.Text =sNumProc;
                DataAbertura.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy");
                Requerente.Text = _processo.NomeCidadao;
                Assunto.Text = _processo.Complemento;
            } catch (Exception ) {

                Response.Redirect("~/Pages/gtiMenu3.aspx");
            }
        }
    }
}