using System;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models.Models;

namespace GTI_Web.Pages {
    public partial class cpv_pagto : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        
        }

        protected void Submit_Click(object sender, EventArgs e) {
            int _codigo = 0,_numeroDoc=0;
            bool bIsNumber= int.TryParse(Codigo.Text,out _codigo);
            if (!bIsNumber) {
                lblmsg.Text = "Digite a inscrição cadastral/municipal.";
            } else {
                if(Documento.Text.Length<17)
                    lblmsg.Text = "Número de documento inválido, digite conforme consta no boleto.";
                else {
                    string sDoc = Documento.Text.Substring(9, 8);
                    _numeroDoc = Convert.ToInt32(sDoc);

                    Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                    int _codigoBD = tributario_Class.Retorna_Codigo_por_Documento(_numeroDoc);
                    if (_codigo != _codigoBD) {
                        lblmsg.Text = "O número de documento informado não pertence a esta inscrição.";
                    } else
                        if(txtimgcode.Text != Session["randomStr"].ToString())
                          lblmsg.Text = "Código da imagem inválido.";
                    else {
                        DebitoPagoStruct reg = tributario_Class.Retorna_DebitoPago_Documento(_numeroDoc);
                        if (reg == null)
                            lblmsg.Text = "Pagamento não encontrado para este documento.";
                        else {
                            PrintReport(reg);
                        }
                    }
                }
            }
        }

        private void PrintReport(DebitoPagoStruct reg) {
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/ComprovantePagamento.rpt"));

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Endereco);
            int _ano_certidao = DateTime.Now.Year;

            Certidao_endereco cert = new Certidao_endereco();
            cert.Codigo = Codigo;
            cert.Ano = _ano_certidao;
            cert.Numero = _numero_certidao;
            cert.Data = DateTime.Now;
            cert.Inscricao = sInscricao;
            cert.Nomecidadao = sNome;
            cert.Logradouro = Reg.NomeLogradouro;
            cert.Li_num = Convert.ToInt32(Reg.Numero);
            cert.Li_compl = Reg.Complemento;
            cert.descbairro = sBairro;
            cert.Li_quadras = Reg.QuadraOriginal;
            cert.Li_lotes = Reg.LoteOriginal;
            Exception ex = tributario_Class.Insert_Certidao_Endereco(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-EA");
                crystalReport.SetParameterValue("ENDERECO", sEndereco);
                crystalReport.SetParameterValue("CADASTRO", Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME", sNome);
                crystalReport.SetParameterValue("INSCRICAO", sInscricao);
                crystalReport.SetParameterValue("BAIRRO", sBairro);

                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

                try {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "certidao" + _numero_certidao.ToString() + _ano_certidao.ToString());
                } catch {
                } finally {
                    crystalReport.Close();
                    crystalReport.Dispose();
                }
            }
        }


    }
}