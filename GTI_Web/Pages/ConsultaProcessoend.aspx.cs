using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class ConsultaProcessoend : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");
                try {
                    s = gtiCore.Decrypt(Request.QueryString["x"]);
                } catch (Exception) {

                    Response.Redirect("~/Pages/gtiMenu.aspx");
                }

                Processo_bll processo_Class = new Processo_bll("GTIconnection");
                int _numero = processo_Class.ExtractNumeroProcessoNoDV(s);
                int _ano = processo_Class.ExtractAnoProcesso(s);

                Exception ex = processo_Class.ValidaProcesso(s);
                if (ex != null)
                    Response.Redirect("~/Pages/gtiMenu.aspx");
                else {
                    Processo.Text = s;
                    ProcessoStruct _processo = processo_Class.Dados_Processo(_ano, _numero);

                    Data_abertura.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy") + " ás " + _processo.Hora;
                    if (_processo.Interno)
                        Requerente.Text = _processo.CentroCustoNome;
                    else
                        Requerente.Text = _processo.NomeCidadao;
                    Assunto.Text = _processo.Assunto;
                }



            }else
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }





    }
}