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
                CodigoList.Items.Clear();
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                CodigoList.Items.Clear();
            }
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text,sCNPJ=txtCNPJ.Text;
            int Codigo = 0;

            if (sCPF == "" && sCNPJ=="")
                lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
            else {
                
                if (CodigoList.Items.Count > 0) {
                    Codigo = Convert.ToInt32(CodigoList.Text);
                }
                lblMsg.Text = "";
                if (Codigo > 0) {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else
                        PrintReport(Codigo, TipoCadastro.Empresa);
                } else {
                    lblMsg.Text = "Selecione uma inscrição municipal da lista.";
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
            sRG = Reg.Rg ?? "";
            sDoc = gtiCore.FormatarCpfCnpj( Reg.Cpf_cnpj);
            sProcAbertura = Reg.Numprocesso.ToString();
            dDataAbertura = Reg.Data_abertura;
            if (Reg.Data_Encerramento != null) {
                dDataEncerramento = Reg.Data_Encerramento;
                sProcEncerramento = Reg.Numprocessoencerramento.ToString();
            }
            sAtividade = Reg.Atividade_extenso;

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            int _numero_certidao = tributario_Class.Retorna_Codigo_Certidao(modelCore.TipoCertidao.Debito);
            int _ano_certidao = DateTime.Now.Year;


            if (ExtratoCheckBox.Checked) {
                
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                if (dDataEncerramento != null) {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoExtratoEncerrada.rpt"));
                    sSufixo = "XE";
                } else {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoExtratoAtiva.rpt"));
                    sSufixo = "XA";
                }
                string Controle = Grava_Extrato_Pagamento(Codigo, _numero_certidao, _ano_certidao,sSufixo);
                crystalReport.RecordSelectionFormula = "{Certidao_inscricao_extrato.Id}='" + Controle + "'";
                crConnectionInfo.ServerName = "200.232.123.115";
                crConnectionInfo.DatabaseName = "Tributacao";
                crConnectionInfo.UserID = "gtisys";
                crConnectionInfo.Password = "everest";

                CrTables = crystalReport.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables) {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

            } else {
                if (dDataEncerramento != null) {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoEncerrada.rpt"));
                    sSufixo = "IE";
                } else {
                    crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoAtiva.rpt"));
                    sSufixo = "IA";
                }
            }

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
            if (dDataEncerramento != null) {
                cert.Processo_encerramento = sProcEncerramento;
                cert.Data_encerramento =  Convert.ToDateTime(dDataEncerramento);
            }
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
                if (dDataEncerramento != null) {
                    crystalReport.SetParameterValue("DATAENCERRAMENTO", dDataEncerramento);
                    crystalReport.SetParameterValue("PROCESSOENCERRAMENTO", sProcEncerramento);
                }

                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

                try {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "certidao" + _numero_certidao.ToString() + _ano_certidao.ToString());
                } catch (Exception ex2){
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
                            if (sTipo == "IE" || sTipo == "IA" ) {
                                Certidao_inscricao dados = Valida_Dados(nNumero, nAno, nCodigo);
                                if (dados != null)
                                    Exibe_Certidao_Inscricao(dados);
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
        
        private Certidao_inscricao Valida_Dados(int Numero, int Ano, int Codigo) {
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Certidao_inscricao dados = tributario_Class.Retorna_Certidao_Inscricao(Ano, Numero, Codigo);
            return dados;
        }

        private void Exibe_Certidao_Inscricao(Certidao_inscricao dados) {
            lblMsg.Text = "";
            string sEndereco = dados.Endereco ;
            string sTipo = "";
            if (dados.Data_encerramento == null)
                sTipo = "ABERTA";
            else {
                sTipo = "ENCERRADA";
            }

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");

            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/CertidaoInscricaoValida.rpt"));
            crystalReport.SetParameterValue("NUMCERTIDAO", dados.Numero.ToString("00000") + "/" + dados.Ano.ToString("0000"));
            crystalReport.SetParameterValue("DATAEMISSAO", Convert.ToDateTime(dados.Data_emissao).ToString("dd/MM/yyyy") + " às " + Convert.ToDateTime(dados.Data_emissao).ToString("HH:mm:ss"));
            crystalReport.SetParameterValue("ENDERECO", sEndereco);
            crystalReport.SetParameterValue("CADASTRO", Convert.ToInt32(dados.Cadastro).ToString("000000"));
            crystalReport.SetParameterValue("NOME", dados.Nome);
            crystalReport.SetParameterValue("BAIRRO", dados.Bairro);
            crystalReport.SetParameterValue("SITUACAO", sTipo);
            crystalReport.SetParameterValue("ATIVIDADE", string.IsNullOrWhiteSpace(dados.Atividade) ? "N/A" : dados.Atividade);
            crystalReport.SetParameterValue("PROCESSOABERTURA", dados.Processo_abertura);
            crystalReport.SetParameterValue("DATAABERTURA", Convert.ToDateTime(dados.Data_abertura).ToString("dd/MM/yyyy"));
            crystalReport.SetParameterValue("PROCESSOENCERRAMENTO",dados.Processo_encerramento??"N/A");
            crystalReport.SetParameterValue("DATAENCERRAMENTO", dados.Data_encerramento==null?"N/A": Convert.ToDateTime(dados.Data_encerramento).ToString("dd/MM/yyyy"));

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

        private string Grava_Extrato_Pagamento(int Codigo, int NumeroCertidao,int AnoCertidao,string Sufixo) {
            string Controle = NumeroCertidao.ToString("00000") + AnoCertidao.ToString("0000") + "/" + Codigo.ToString() + "-" + Sufixo;
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            List<SpExtrato> ListaTributo = tributario_Class.Lista_Extrato_Tributo(Codigo, 1980, 2050, 0, 99, 0, 99, 0, 999, 0, 99, 0, 99, DateTime.Now, "Web");
            List<SpExtrato> ListaParcela = tributario_Class.Lista_Extrato_Parcela(ListaTributo);
            
            foreach (SpExtrato item in ListaParcela.Where(x=>(x.Codlancamento==2 ||x.Codlancamento==6 || x.Codlancamento==14) && x.Statuslanc<3) ) {
                Certidao_inscricao_extrato reg = new Certidao_inscricao_extrato();
                reg.Id = Controle;
                reg.Ano = item.Anoexercicio;
                reg.Codigo = item.Codreduzido;
                reg.Complemento = item.Codcomplemento;
                if (item.Datapagamento != null)
                    reg.Data_Pagamento = Convert.ToDateTime(item.Datapagamento);
                reg.Data_Vencimento = item.Datavencimento;
                reg.Lancamento_Codigo = item.Codlancamento;
                reg.Lancamento_Descricao = item.Desclancamento;
                reg.Parcela = (byte)item.Numparcela;
                reg.Sequencia= (byte)item.Seqlancamento;
                reg.Valor_Pago = (decimal)item.Valorpagoreal;
                Exception ex = tributario_Class.Insert_Certidao_Inscricao_Extrato(reg);
                if (ex != null)
                    throw ex;
            }
            
            return Controle;
        }

        protected void VerificarButton_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text;
            List<int> _codigos = new List<int>();
            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            if (sCPF != "")
               _codigos = empresa_Class.Retorna_Codigo_por_CPF(gtiCore.RetornaNumero(sCPF));
            else {
                if (sCNPJ != "")
                    _codigos = empresa_Class.Retorna_Codigo_por_CNPJ(gtiCore.RetornaNumero(sCNPJ));
            }
            CodigoList.Items.Clear();
            foreach (int item in _codigos) {
                CodigoList.Items.Add(item.ToString());
            }
            if (CodigoList.Items.Count > 0)
                CodigoList.Items[0].Selected = true;

        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            if (CodigoList.Items.Count > 0)
                CodigoList.Items.Clear();
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            if (CodigoList.Items.Count > 0)
                CodigoList.Items.Clear();
        }

        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber() {
            lock (syncLock) { // synchronize
                return getrandom.Next(1, 2000000);
            }
        }


    }
}