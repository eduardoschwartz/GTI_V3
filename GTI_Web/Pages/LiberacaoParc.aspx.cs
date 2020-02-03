using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GTI_Web.Pages {
    public partial class LiberacaoParc : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

            if (!IsPostBack) {
                txtProcesso.Text = "";
                txtIM.Text = "";
                lblMsg.Text = "";
            }
        }

        private bool Valida() {
            int Codigo = 0;
            lblMsg.Text = "";

            if (txtIM.Text == "") {
                lblMsg.Text = "Digite a inscrição cadastral.";
                return false;
            } else {
                Codigo = Convert.ToInt32(txtIM.Text);
                if (Codigo < 100000) {
                    Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                    bool ExisteImovel = imovel_Class.Existe_Imovel(Codigo);
                    if (!ExisteImovel) {
                        lblMsg.Text = "Inscrição não cadastrada.";
                        return false;
                    }
                } else {
                    if (Codigo >= 100000 && Codigo < 500000) {
                        Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                        bool ExisteEmpresa = empresa_Class.Existe_Empresa(Codigo);
                        if (!ExisteEmpresa) {
                            lblMsg.Text = "Inscrição não cadastrada.";
                            return false;
                        } 
                    } else {
                        Cidadao_bll cidadao_Class = new Cidadao_bll("GTIconnection");
                        bool ExisteCidadao = cidadao_Class.ExisteCidadao(Codigo);
                        if (!ExisteCidadao) {
                            lblMsg.Text = "Inscrição não cadastrada.";
                            return false;
                        }
                    }
                }
            }

            string sNumProc = txtProcesso.Text;
            if (sNumProc.Length<6) {
                lblMsg.Text = "Nº de processo inválido.";
                return false;
            } else {
                Tributario_bll tributario_class = new Tributario_bll("GTIconnection");
                List<Destinoreparc> Lista = tributario_class.Lista_Destino_Parcelamento(sNumProc);
                if (Lista.Count == 0) {
                    lblMsg.Text = "Processo não cadastrado.";
                    return false;
                } else {
                    int _codigo = Lista[0].Codreduzido;
                    if (_codigo != Codigo) {
                        lblMsg.Text = "Processo não pertence a esta inscrição.";
                        return false;
                    } else {
                        int _seq = Lista[0].Numsequencia;

                    }


                }
            }


            return true;
        }


        protected void btPrint_Click(object sender, EventArgs e) {
            if (Valida()) {
                lblMsg.Text = "OK";
            }  
        }

    }
}