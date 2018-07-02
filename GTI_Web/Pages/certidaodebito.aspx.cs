﻿using CrystalDecisions.CrystalReports.Engine;
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
            lblMsg.Text = "";
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
                            else {
                                //Verifica competência en
                                Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
                                int _holes = tributario_Class.Competencias_Nao_Encerradas(tributario_Class.Resumo_CompetenciaISS(Codigo));
                                if (_holes == 0) {
                                    lblMsg.Text = "";
                                    PrintReport(Codigo, TipoCadastro.Empresa);
                                } else
                                    lblMsg.Text = "A empresa possui uma ou mais competências não encerradas.";
                            }
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
                nRet = 3;
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
                    nRet = 4;
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
                        nRet = 5;
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
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Debito);
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
            cert.Lancamento = dadosCertidao.Descricao_Lancamentos;
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
            string sCod = Codigo.Text;
            string sTipo = "";
            lblMsg.Text = "";
            int nPos = 0, nPos2 = 0, nCodigo = 0, nAno = 0, nNumero = 0;
            if (sCod.Trim().Length < 8)
                lblMsg.Text = "Código de validação inválido.";
            else {
                nPos = sCod.IndexOf("-");
                if (nPos < 6)
                    lblMsg.Text = "Código de validação inválido.";
                else {
                    nPos2 = sCod.IndexOf("/");
                    if (nPos2 < 5 || nPos - nPos2 < 2)
                        lblMsg.Text = "Código de validação inválido.";
                    else {
                        nCodigo = Convert.ToInt32(sCod.Substring(nPos2 + 1, nPos - nPos2 - 1));
                        nAno = Convert.ToInt32(sCod.Substring(nPos2 - 4, 4));
                        nNumero = Convert.ToInt32(sCod.Substring(0, 5));
                        if (nAno < 2010 || nAno > DateTime.Now.Year + 1)
                            lblMsg.Text = "Código de validação inválido.";
                        else {
                            sTipo = sCod.Substring(sCod.Length - 2, 2);
                            if (sTipo == "CN"|| sTipo == "CP"||sTipo == "PN") {
                                Certidao_debito dados = Valida_Dados(nNumero, nAno, nCodigo);
                                if (dados != null)
                                    Exibe_Certidao_Debito(dados);
                                else
                                    lblMsg.Text = "Certidão não cadastrada.";
                            } else {
                                lblMsg.Text = "Código de validação inválido.";
                            }
                        }
                    }
                }
            }

        }

        private Certidao_debito Valida_Dados(int Numero, int Ano, int Codigo) {
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Certidao_debito dados = tributario_Class.Retorna_Certidao_Debito(Ano, Numero, Codigo);
            return dados;
        }


        private void Exibe_Certidao_Debito(Certidao_debito dados) {
            lblMsg.Text = "";
            string sEndereco = dados.Logradouro + ", " + dados.Numero.ToString();
            string sTipo = "";
            if (dados.Ret == 4)
                sTipo = "CERTDÂO POSITIVA";
            else {
                if (dados.Ret == 5)
                    sTipo = "CERTIDÃO POSITIVA EFEITO NEGATIVA";
                else
                    sTipo = "CERTIDÃO NEGATIVA";
            }

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            string sProc = dados.Processo;

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoValida.rpt"));
            crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));
            crystalReport.SetParameterValue("DATAEMISSAO", Convert.ToDateTime(dados.Datagravada).ToString("dd/MM/yyyy") + " às " + Convert.ToDateTime(dados.Datagravada).ToString("HH:mm:ss"));
            crystalReport.SetParameterValue("CONTROLE", dados.Numero.ToString("00000") + dados.Ano.ToString("0000") + "/" + dados.Codigo.ToString() + "-CI");
            crystalReport.SetParameterValue("ENDERECO", sEndereco);
            crystalReport.SetParameterValue("CADASTRO", Convert.ToInt32(dados.Codigo).ToString("000000"));
            crystalReport.SetParameterValue("NOME", dados.Nome);
            crystalReport.SetParameterValue("INSCRICAO", string.IsNullOrWhiteSpace( dados.Inscricao)?"N/A":dados.Inscricao);
            crystalReport.SetParameterValue("BAIRRO", dados.Bairro);
            crystalReport.SetParameterValue("TIPO", sTipo);
            crystalReport.SetParameterValue("PROCESSO", sProc);
            crystalReport.SetParameterValue("ATIVIDADE", string.IsNullOrWhiteSpace(dados.Atividade) ? "N/A" : dados.Atividade);
            crystalReport.SetParameterValue("TRIBUTO", string.IsNullOrWhiteSpace(dados.Lancamento) ? "N/A" : dados.Lancamento);

            HttpContext.Current.Response.Buffer = false;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();

            try {
                crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "comp" + dados.Numero.ToString() + dados.Ano.ToString());
            } catch {
            } finally {
                crystalReport.Close();
                crystalReport.Dispose();
            }

        }




    }




}