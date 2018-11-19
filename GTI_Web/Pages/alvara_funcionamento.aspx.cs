using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models.Models;

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace GTI_Web.Pages {
    public partial class alvara_funcionamento : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }
      
        private void EmiteAlvara(int Codigo) {

            lblmsg.Text = "";
            string sTipo = "";

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoValida.rpt"));
            crystalReport.SetParameterValue("NUMCERTIDAO", "");
            crystalReport.SetParameterValue("DATAEMISSAO", "");
            crystalReport.SetParameterValue("CONTROLE", "");
            crystalReport.SetParameterValue("ENDERECO","");
            crystalReport.SetParameterValue("CADASTRO", "");
            crystalReport.SetParameterValue("NOME", "");
            crystalReport.SetParameterValue("INSCRICAO", "");
            crystalReport.SetParameterValue("BAIRRO", "");
            crystalReport.SetParameterValue("TIPO", sTipo);
            crystalReport.SetParameterValue("PROCESSO", "");
            crystalReport.SetParameterValue("ATIVIDADE", "");
            crystalReport.SetParameterValue("TRIBUTO", "");

            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();

            try {
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "comp"+ "");
            } catch {
            } finally {
                crystalReport.Close();
                crystalReport.Dispose();
            }

        }

        protected void ValidarButton_Click(object sender, EventArgs e) {

        }

        protected void btPrint_Click(object sender, EventArgs e) {
            int Num = 0;

            if (Page.IsValid && (txtimgcode.Text == Session["randomStr"].ToString())) {
                Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                bool isNum = Int32.TryParse(txtCod.Text, out Num);
                if (!isNum) {
                    lblmsg.Text = "Inscrição Municipal inválida!";
                    return;
                } else {
                    bool bExiste = empresa_Class.Existe_Empresa(Num);
                    if (!bExiste) {
                        lblmsg.Text = "Inscrição Municipal inválida!";
                        return;
                    } else {
                        bool bAlvara = empresa_Class.Empresa_tem_Alvara(Num);
                        if (!bAlvara) {
                            lblmsg.Text = "Esta empresa não pode emitir alvará pela internet.";
                            return;
                        } else {
                            lblmsg.Text = "OK";
                            return;

                        }
                    }
                }
            } else {
                lblmsg.Text = "Código da imagem inválido.";
            }
        }
    }
}