using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using UIWeb;
using static GTI_Models.modelCore;
using CrystalDecisions.Shared;

namespace GTI_Web.Pages {
    public partial class certidaodebito_doc : System.Web.UI.Page {
        
        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void optCPF_CheckedChanged(object sender, EventArgs e) {
            if (optCPF.Checked) {
                txtCPF.Visible = true;
                txtCNPJ.Visible = false;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
            }
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber() {
            lock (syncLock) { // synchronize
                return getrandom.Next(1, 2000000);
            }
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text;
            if (sCPF == "" && sCNPJ == "")
                lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
            else {
                if (sCPF != "") {
                    bool _validacpf = gtiCore.ValidaCpf(txtCPF.Text);
                    if (!_validacpf) {
                        lblMsg.Text = "CPF inválido.";
                        return;
                    }
                } else {
                    bool _validacnpj = gtiCore.ValidaCNPJ(txtCNPJ.Text);
                    if (!_validacnpj) {
                        lblMsg.Text = "CNPJ inválido.";
                        return;
                    }
                }

                lblMsg.Text = "";
                Sistema_bll sistema_Class = new Sistema_bll("GTIconnection");
                List<int> _codigos = sistema_Class.Lista_Codigos_Documento(sCPF != "" ? sCPF : sCNPJ, sCPF != "" ?TipoDocumento.Cpf:TipoDocumento.Cnpj);
                if (_codigos.Count > 0) {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else
                        PrintReport();
                } else {
                    lblMsg.Text = "O CPF/CNPJ digitado não retornou nenuma inscrição cadastrada.";
                }
            }
        }

        private void PrintReport() {

        }




        protected void ValidarButton_Click(object sender, EventArgs e) {

        }



    }
}