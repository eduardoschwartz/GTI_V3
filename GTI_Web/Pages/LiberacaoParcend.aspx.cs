using GTI_Bll.Classes;
using GTI_Models.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class LiberacaoParcend : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                String s = Request.QueryString["d"];
                if (s != "gti")
                    Response.Redirect("~/Pages/gtiMenu.aspx");

                if (Session["sid"] != null && Session["sid"].ToString() != "") {
                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    List<Boletoguia> ListaBoleto = tributario_Class.Lista_Boleto_Guia(Convert.ToInt32(Session["sid"]));

                    txtcpfCnpj.Text = ListaBoleto[0].Cpf;
                    txtCodigo.Text = ListaBoleto[0].Codreduzido;
                    txtNome.Text = ListaBoleto[0].Nome;
                    txtEndereco.Text = ListaBoleto[0].Endereco + ", " + ListaBoleto[0].Numimovel.ToString() + " " + ListaBoleto[0].Complemento + " " + ListaBoleto[0].Bairro;
                    txtCidade.Text = ListaBoleto[0].Cidade + "/" + ListaBoleto[0].Uf;
                    txtCep.Text = ListaBoleto[0].Cep;
                    txtProcesso.Text = ListaBoleto[0].Numproc;
                } else
                    Response.Redirect("~/Pages/gtiMenu.aspx");
            } 
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(Session["sid"].ToString())) {
                printCarne(Convert.ToInt32(Session["sid"]));
                Session["sid"] = "";
            } else
                Response.Redirect("~/Pages/gtiMenu.aspx");
        }

        private void printCarne(int nSid) {
            lblMsg.Text = "";
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            Session["sid"] = "";
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<Boletoguia> ListaBoleto = tributario_Class.Lista_Boleto_Guia(nSid);
            if (ListaBoleto.Count > 0) {
                tributario_Class.Insert_Carne_Web(Convert.ToInt32(ListaBoleto[0].Codreduzido), 2019);
                DataSet Ds = gtiCore.ToDataSet(ListaBoleto);
                ReportDataSource rdsAct = new ReportDataSource("dsBoletoGuia", Ds.Tables[0]);
                ReportViewer viewer = new ReportViewer();
                viewer.LocalReport.Refresh();
                viewer.LocalReport.ReportPath = "Report/Carne_PARCELAMENTO.rdlc";
                viewer.LocalReport.DataSources.Add(rdsAct); 


                byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                tributario_Class.Excluir_Carne(nSid);
                Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                Response.AddHeader("content-disposition", "attachment; filename= guia_pmj" + "." + extension);
                Response.OutputStream.Write(bytes, 0, bytes.Length);
                Response.Flush();
                Response.End();
            } else
                lblMsg.Text = "A guia já foi impressa!";

        }



    }
}