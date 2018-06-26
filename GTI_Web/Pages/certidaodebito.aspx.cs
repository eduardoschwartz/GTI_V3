using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Web;
using static GTI_Models.modelCore;

namespace GTI_Web.Pages {
    public partial class certidaodebito : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btPrint_Click(object sender, EventArgs e) {
            if (txtIM.Text == "")
                lblMsg.Text = "Digite o código do imóvel ou a inscrição municipal.";
            else {
                lblMsg.Text = "";
                int Codigo = Convert.ToInt32(txtIM.Text);
                if (Codigo < 100000) {
                    Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                    bool ExisteImovel = imovel_Class.Existe_Imovel(Codigo);
                    if (!ExisteImovel)
                        lblMsg.Text = "Código não cadastrado.";
                    else {
                        if (txtimgcode.Text != Session["randomStr"].ToString())
                            lblMsg.Text = "Código da imagem inválido";
                        else
                            PrintReport(Codigo,TipoCadastro.Imovel);
                    }
                } else {
                    if(Codigo>=100000 && Codigo < 500000) {
                        Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                        bool ExisteEmpresa = empresa_Class.Existe_Empresa(Codigo);
                        if (!ExisteEmpresa)
                            lblMsg.Text = "Código não cadastrado.";
                        else {
                            if (txtimgcode.Text != Session["randomStr"].ToString())
                                lblMsg.Text = "Código da imagem inválido";
                            else
                                PrintReport(Codigo,TipoCadastro.Empresa);
                        }
                    } else {
                        lblMsg.Text = "Código não cadastrado.";
                    }
                }
            }
        }

        private void PrintReport(int Codigo,TipoCadastro _tipo_cadastro) {
            ReportDocument crystalReport = new ReportDocument();
            string sComplemento = "", sQuadras = "", sLotes = "", sEndereco = "", sBairro = "", sInscricao = "", sNome = "", sCidade = "", sUF = "", sNumProcesso = "9222-3/2012";
            string sData = "18/04/2012",sAtendente="GTI.Web",sCPF="",sCNPJ="",sAtividade="",sTipoCertidao="",sTributo="",sSufixo="",sNao="",sDoc="";
            short nNumeroImovel = 0,nRet=0;
            DateTime dDataProc = Convert.ToDateTime(sData);

            if (_tipo_cadastro == TipoCadastro.Imovel) {
                Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                ImovelStruct Reg = imovel_Class.Dados_Imovel(Codigo);
                sComplemento = string.IsNullOrWhiteSpace(Reg.Complemento) ? "" : " " + Reg.Complemento.ToString().Trim();
                sQuadras = string.IsNullOrWhiteSpace(Reg.QuadraOriginal) ? "" : " Quadra: " + Reg.QuadraOriginal.ToString().Trim();
                sLotes = string.IsNullOrWhiteSpace(Reg.LoteOriginal) ? "" : " Lote: " + Reg.LoteOriginal.ToString().Trim();
                sComplemento += sQuadras + sLotes;
                sEndereco = Reg.NomeLogradouro + ", " + Reg.Numero.ToString() + sComplemento;
                nNumeroImovel = (short)Reg.Numero;
                sBairro = Reg.NomeBairro;
                sCidade = "JABOTICABAL";
                sUF = "SP";
                sInscricao = Reg.Distrito.ToString() + "." + Reg.Setor.ToString("00") + "." + Reg.Quadra.ToString("0000") + "." + Reg.Lote.ToString("00000") + "." +
                    Reg.Seq.ToString("00") + "." + Reg.Unidade.ToString("00") + "." + Reg.SubUnidade.ToString("000");
                List<ProprietarioStruct> Lista = imovel_Class.Lista_Proprietario(Codigo, true);
                sNome = Lista[0].Nome;
                sCPF = Lista[0].CPF;
                sCNPJ = Lista[0].CPF;
            } else {
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
                sCPF = Reg.Cpf;
                sCNPJ = Reg.Cnpj;
                sDoc = Reg.Cpf_cnpj;
                sAtividade = Reg.Atividade_extenso;
            }

            //***Verifica débito
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Certidao_debito_detalhe dadosCertidao = tributario_Class.Certidao_Debito(Codigo);
            if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Negativa) {
                sTipoCertidao = "NEGATIVA";
                sNao = "Não ";
                sSufixo = "CN";
                if (_tipo_cadastro == TipoCadastro.Imovel)
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoImovel.rpt"));
                else {
                    if (_tipo_cadastro == TipoCadastro.Empresa)
                        crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoEmpresa.rpt"));
                }
            } else {
                if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Positiva) {
                    sTipoCertidao = "POSITIVA";
                    sSufixo = "CP";
                    if (_tipo_cadastro == TipoCadastro.Imovel)
                        crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoImovel.rpt"));
                    else {
                        if (_tipo_cadastro == TipoCadastro.Empresa)
                            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoEmpresa.rpt"));
                    }
                } else {
                    if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.NegativaPositiva) {
                        sTipoCertidao = "POSITIVA COM EFEITO NEGATIVA";
                        sSufixo = "PN";
                        if (_tipo_cadastro == TipoCadastro.Imovel)
                            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoImovelPN.rpt"));
                        else {
                            if (_tipo_cadastro == TipoCadastro.Empresa)
                                crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoEmpresaPN.rpt"));
                        }
                    }
                }
            }
            sTributo = dadosCertidao.Descricao_Lancamentos;

            //******************
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Endereco);
            int _ano_certidao = DateTime.Now.Year;

            Certidao_debito cert = new Certidao_debito();
            cert.Codigo = Codigo;
            cert.Ano = (short)_ano_certidao;
            cert.Ret = nRet;
            cert.Numero = _numero_certidao;
            cert.Datagravada = DateTime.Now;
            cert.Inscricao = sInscricao;
            cert.Nome = sNome;
            cert.Logradouro = sEndereco;
            cert.Numimovel = nNumeroImovel;
            cert.Bairro = sBairro;
            cert.Cidade = sCidade;
            cert.UF = sUF;
            cert.Processo = sNumProcesso;
            cert.Dataprocesso = dDataProc;
            cert.Atendente = sAtendente;
            cert.Cpf = sCPF;
            cert.Cnpj = sCNPJ;
            cert.Atividade = sAtividade;
            Exception ex = tributario_Class.Insert_Certidao_Debito(cert);
            if (ex != null) {
                throw ex;
            } else {
                
                crystalReport.SetParameterValue("NUMCERTIDAO", _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000"));
                crystalReport.SetParameterValue("DATAEMISSAO", DateTime.Now.ToString("dd/MM/yyyy") + " às " + DateTime.Now.ToString("HH:mm:ss"));
                crystalReport.SetParameterValue("CONTROLE", _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + Codigo.ToString() + "-" + sSufixo);
                crystalReport.SetParameterValue("ENDERECO", sEndereco);
                crystalReport.SetParameterValue("CADASTRO", Codigo.ToString("000000"));
                crystalReport.SetParameterValue("NOME", sNome);
                crystalReport.SetParameterValue("INSCRICAO", sInscricao);
                crystalReport.SetParameterValue("BAIRRO", sBairro);
                crystalReport.SetParameterValue("TIPOCERTIDAO", sTipoCertidao);
                crystalReport.SetParameterValue("TRIBUTO", sTributo);
                crystalReport.SetParameterValue("NAO", sNao);
                crystalReport.SetParameterValue("DOC", sDoc);
                crystalReport.SetParameterValue("CIDADE", sCidade + "/" + sUF);
                crystalReport.SetParameterValue("ATIVIDADE", sAtividade);

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