using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class Tramite_Processo2 : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["pUserId"] == null || (int)Session["pUserId"] == 0) {
                Response.Redirect("Login.aspx");
            }

            string sNumProc = gtiCore.Decrypt(Request.QueryString["a"]); ;
              Carrega_Grid(sNumProc);
        }

        private void Carrega_Grid(string sNumProc) {
            Processo_bll processo_Class = new Processo_bll("GTIconnection");
            try {
                ProcessoNumero _numero = gtiCore.Split_Processo_Numero(sNumProc);
                ProcessoStruct _processo = processo_Class.Dados_Processo(_numero.Ano, _numero.Numero);
                Processo.Text = sNumProc;
                DataAbertura.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy");
                Requerente.Text = _processo.NomeCidadao;
                Assunto.Text = _processo.Complemento;

                List<TramiteStruct> Lista_Tramite = processo_Class.DadosTramite((short)_numero.Ano, _numero.Numero, 0);

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Seq"), new DataColumn("Local"), new DataColumn("Data"), new DataColumn("Hora"), 
                    new DataColumn("Usuario1"), new DataColumn("Despacho"), new DataColumn("Data2"), new DataColumn("Usuario2") });

                foreach (TramiteStruct item in Lista_Tramite) {
                    dt.Rows.Add(item.Seq, item.CentroCustoNome,item.DataEntrada,item.HoraEntrada,item.Usuario1,item.DespachoNome,item.DataEnvio,item.Usuario2);
                }

                grdMain.DataSource = dt;
                grdMain.DataBind();


            } catch (Exception ) {

                Response.Redirect("~/Pages/gtiMenu3.aspx");
            }

        }

        protected void grdMain_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e) {
            string arg = Convert.ToString(e.CommandArgument);

            //if (e.CommandName == "cmdReceber") {
            //    DataAbertura.Text = "RECEBER";
            //} else {
            //    if (e.CommandName == "cmdEnviar") {
            //        DataAbertura.Text = "ENVIAR";
            //    }
            //}
        }


    }
}