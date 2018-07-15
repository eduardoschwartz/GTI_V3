using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using GTI_Bll.Classes;
using GTI_Models.Models;
using static GTI_Models.modelCore;
using System.Web;
using GTI_Models;
using CrystalDecisions.CrystalReports.Engine;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class certidaoinscricao : System.Web.UI.Page {
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

        protected void btPrint_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text,sCNPJ=txtCNPJ.Text;
            int Codigo = 0;

            if (sCPF == "" && sCNPJ=="")
                lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
            else {
                Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                if (sCPF != "")
                    Codigo = empresa_Class.Retorna_Codigo_por_CPF(gtiCore.RetornaNumero( sCPF));
                else {
                    if (sCNPJ != "")
                        Codigo = empresa_Class.Retorna_Codigo_por_CNPJ(gtiCore.RetornaNumero( sCNPJ));
                }

                lblMsg.Text = "";
                if (Codigo > 0) {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else
                        PrintReport(Codigo, TipoCadastro.Empresa);
                } else {
                    lblMsg.Text = "Empresa não cadastrada.";
                }
            }
        }

        private void PrintReport(int Codigo, TipoCadastro _tipo_cadastro) {
            ReportDocument crystalReport = new ReportDocument();
            string sComplemento = "", sQuadras = "", sLotes = "", sEndereco = "", sBairro = "", sInscricao = "", sNome = "", sCidade = "", sUF = "";
            string sData = "18/04/2012",  sCPF = "", sCNPJ = "", sAtividade = "", sRG = "", sProcAbertura = "", sSufixo = "", sProcEncerramento="", sDoc = "";
            short nNumeroImovel = 0;
            DateTime dDataProc = Convert.ToDateTime(sData);
            DateTime?  dDataAbertura = null,dDataEncerramento = null;

            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            EmpresaStruct Reg = empresa_Class.Retorna_Empresa(Codigo);
            sComplemento = string.IsNullOrWhiteSpace(Reg.Complemento) ? "" : " " + Reg.Complemento.ToString().Trim();
            sComplemento += sQuadras + sLotes;
            sEndereco = Reg.Endereco_nome + ", " + Reg.Numero.ToString() + sComplemento;
            nNumeroImovel = (short)Reg.Numero;
            sBairro = Reg.Bairro_nome;
            sCidade = Reg.Cidade_nome;
            sUF = Reg.UF;
            sNome = Reg.Razao_social;
            sCPF = string.IsNullOrWhiteSpace( Reg.Cpf)  ? "" : Reg.Cpf;
            sCNPJ = string.IsNullOrWhiteSpace( Reg.Cnpj)  ? "" : Reg.Cnpj;
            sRG = Reg.Rg;
            sDoc = gtiCore.FormatarCpfCnpj( Reg.Cpf_cnpj);
            sProcAbertura = Reg.Numprocesso.ToString();
            dDataAbertura = Reg.Data_abertura;
            if (Reg.Data_Encerramento != null) {
                dDataEncerramento = Reg.Data_Encerramento;
                sProcEncerramento = Reg.Numprocessoencerramento.ToString();
            }
            sAtividade = Reg.Atividade_extenso;


            if (Reg.Data_Encerramento == null) {
                crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoEncerrada.rpt"));
                sSufixo = "IE";
            } else {
                crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoAtiva.rpt"));
                sSufixo = "IA";
            }

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Debito);
            int _ano_certidao = DateTime.Now.Year;

            Certidao_inscricao cert = new Certidao_inscricao();
            cert.Cadastro = Codigo;
            cert.Ano = (short)_ano_certidao;
            cert.Numero = _numero_certidao;
            cert.Data_emissao = DateTime.Now;
            cert.Nome = sNome;
            cert.Endereco = sEndereco;
            cert.Rg = sRG;
            cert.Bairro = sBairro;
            cert.Cidade = sCidade;
            cert.Processo_abertura = sProcAbertura;
            cert.Data_abertura = Convert.ToDateTime( dDataAbertura);
            cert.Processo_encerramento = sProcEncerramento;
            cert.Data_encerramento =Convert.ToDateTime( dDataEncerramento);
            cert.Documento = sDoc;
            cert.Atividade = sAtividade;

            Exception ex = tributario_Class.Insert_Certidao_Inscricao(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-" + sSufixo);
                crystalReport.SetParameterValue("ENDERECO", sEndereco);
                crystalReport.SetParameterValue("CADASTRO", Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME", sNome);
                crystalReport.SetParameterValue("BAIRRO", sBairro);
                crystalReport.SetParameterValue("DOCUMENTO", sDoc);
                crystalReport.SetParameterValue("CIDADE", sCidade + "/" + sUF);
                crystalReport.SetParameterValue("ATIVIDADE", sAtividade);
                crystalReport.SetParameterValue("RG", sRG);
                crystalReport.SetParameterValue("DATAABERTURA", dDataAbertura);
                crystalReport.SetParameterValue("PROCESSOABERTURA", sProcAbertura);
                crystalReport.SetParameterValue("DATAENCERRAMENTO", dDataEncerramento);
                crystalReport.SetParameterValue("PROCESSOENCERRAMENTO", sProcEncerramento);

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

        protected void ValidarButton_Click(object sender, EventArgs e) {

        }
    }
}