using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace GTI_Web.Pages {
    public partial class certidaoendereco : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void btPrint_Click(object sender, EventArgs e) {

            if (txtIM.Text == "") 
                lblMsg.Text = "Digite o código do imóvel.";
            else {
                lblMsg.Text = "";
                int Codigo = Convert.ToInt32(txtIM.Text);
                Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                bool ExisteImovel = imovel_Class.Existe_Imovel(Codigo);
                if (!ExisteImovel)
                    lblMsg.Text = "Imóvel não cadastrado.";
                else {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else
                        PrintReport(Codigo);
                }
            }
        }

        private void PrintReport(int Codigo) {
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            ImovelStruct Reg = imovel_Class.Dados_Imovel(Codigo);
            string sComplemento = string.IsNullOrWhiteSpace(Reg.Complemento) ? "" : " " + Reg.Complemento.ToString().Trim();
            string sQuadras = string.IsNullOrWhiteSpace(Reg.QuadraOriginal) ? "" : " Quadra: " + Reg.QuadraOriginal.ToString().Trim();
            string sLotes = string.IsNullOrWhiteSpace(Reg.LoteOriginal) ? "" : " Lote: " + Reg.LoteOriginal.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            string sEndereco = Reg.NomeLogradouro + ", " + Reg.Numero.ToString() + sComplemento;
            string sBairro = Reg.NomeBairro;
            string sInscricao = Reg.Distrito.ToString() + "." + Reg.Setor.ToString("00") + "." + Reg.Quadra.ToString("0000") + "." + Reg.Lote.ToString("00000") + "." +
                Reg.Seq.ToString("00") + "." + Reg.Unidade.ToString("00") + "." + Reg.SubUnidade.ToString("000");
            List<ProprietarioStruct>Lista = imovel_Class.Lista_Proprietario(Codigo, true);
            string sNome = Lista[0].Nome;

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoEndereco.rpt"));

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Endereco);
            int _ano_certidao = DateTime.Now.Year;

            Certidaoenderecoatualizado cert = new Certidaoenderecoatualizado();
            cert.Codigo = Codigo;
            cert.Ano = _ano_certidao;
            cert.Numero = _numero_certidao;
            cert.Data = DateTime.Now;
            cert.Inscricao = sInscricao;
            cert.Nomecidadao = sNome;
            cert.Logradouro =Reg.NomeLogradouro;
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
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "certidao" + _numero_certidao + _ano_certidao.ToString());
                } catch {
                } finally {
                    crystalReport.Close();
                    crystalReport.Dispose();
                }
            }
        }
    }
}