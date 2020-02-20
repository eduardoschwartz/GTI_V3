using CrystalDecisions.CrystalReports.Engine;
using GTI_Bll.Classes;
using GTI_Models;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class dadosImovel : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

            if (!IsPostBack) {
                txtCNPJ.Text = "";
                txtIM.Text = "";
                lblMsg.Text = "";
            }
        }

        protected void optCNPJ_CheckedChanged(object sender, EventArgs e) {
            if (optCNPJ.Checked) {
                txtCPF.Visible = false;
                txtCNPJ.Visible = true;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                txtIM.Text = "";
            }
        }

        protected void optCPF_CheckedChanged(object sender, EventArgs e) {
            if (optCPF.Checked) {
                txtCPF.Visible = true;
                txtCNPJ.Visible = false;
                txtCPF.Text = "";
                txtCNPJ.Text = "";
                txtIM.Text = "";
            }
        }

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            txtCNPJ.Text = "";
        
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            txtCPF.Text = "";
          
        }

        protected void btPrint_Click(object sender, EventArgs e) {
            lblMsg.Text = "";
            if (txtIM.Text =="") txtIM.Text = "0";
            int Codigo = Convert.ToInt32(txtIM.Text);

            Imovel_bll imovel_class = new Imovel_bll("GTIconnection");
            if (Convert.ToInt32(txtIM.Text)==0 && string.IsNullOrWhiteSpace(txtCNPJ.Text) && string.IsNullOrWhiteSpace(txtCPF.Text))
                lblMsg.Text = "Digite IM ou CPF ou CNPJ.";
            else {

                if (Convert.ToInt32(txtIM.Text) > 0 && (!string.IsNullOrWhiteSpace(txtCNPJ.Text) || !string.IsNullOrWhiteSpace(txtCPF.Text))) {

                } else {
                    lblMsg.Text = "Erro: Digite a inscrição municipal e o CPF ou o CNPJ do proprietário.";
                    return;
                }

                if (!imovel_class.Existe_Imovel(Codigo)) {
                    lblMsg.Text = "Erro: Cadastro inexistente.";
                    return;
                }

                if (optCPF.Checked && txtCPF.Text.Length < 14) {
                    lblMsg.Text = "CPF inválido!";
                    return;
                }
                if (optCNPJ.Checked && txtCNPJ.Text.Length < 18) {
                    lblMsg.Text = "CNPJ inválido!";
                    return;
                }

                string num_cpf_cnpj = "";
                Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
                List<ProprietarioStruct> _prop = imovel_Class.Lista_Proprietario(Codigo, true);
                string _cpfcnpj = _prop[0].CPF;

                if (optCPF.Checked) {
                    num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                    if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                        lblMsg.Text = "CPF inválido!";
                        return;
                    } else {
                        if (num_cpf_cnpj != _cpfcnpj) {
                            lblMsg.Text = "CPF informado não pertence a este imóvel!";
                            return;
                        }
                    }
                } else {
                    num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                    if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                        lblMsg.Text = "CNPJ inválido!";
                        return;
                    } else {
                        if (num_cpf_cnpj != _cpfcnpj) {
                            lblMsg.Text = "CNPJ informado não pertence a este imóvel!";
                            return;
                        }
                    }
                }
                Imprimir_Ficha(Convert.ToInt32(txtIM.Text));
            }
        }

        private void Imprimir_Ficha(int Codigo) {
            ReportDocument crystalReport = new ReportDocument();
            crystalReport.Load(Server.MapPath("~/Report/Dados_Imovel.rpt"));

            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");

            ImovelStruct _dados = imovel_Class.Dados_Imovel(Codigo);
            string _ativo = "SIM";
            string _controle = "XXX";

            dados_imovel_web cert = new dados_imovel_web {
                Agrupamento = 0,
                Areaterreno = (decimal)_dados.Area_Terreno,
                Ativo = _ativo,
                Bairro = _dados.NomeBairro,
                Benfeitoria = _dados.Benfeitoria_Nome,
                Categoria = _dados.Categoria_Nome,
                Cep = _dados.Cep,
                Codigo = Codigo,
                Complemento = _dados.Complemento,
                Condominio = _dados.NomeCondominio,
                Controle = _controle,
                Endereco = _dados.NomeLogradouro,
                Imunidade = _dados.Imunidade == true ? "Sim" : "Não",
                Inscricao = _dados.Inscricao,
                Isentocip = _dados.Cip == true ? "Sim" : "Não",
                Lote = _dados.LoteOriginal,
                Mt = _dados.NumMatricula.ToString(),
                Numero = (int)_dados.Numero,
                Pedologia = _dados.Pedologia_Nome,
                Proprietario2 = "",
                Qtdeedif=0,
                Quadra=_dados.QuadraOriginal,
                Reside=(bool)_dados.ResideImovel?"Sim":"Não",
                Situacao=_dados.Situacao_Nome,
                Topografia=_dados.Topografia_Nome,
                Usoterreno=_dados.Uso_terreno_Nome
            };

            List<ProprietarioStruct> _prop = imovel_Class.Lista_Proprietario(Codigo,false);
            foreach (ProprietarioStruct item in _prop) {
                if(item.Principal)
                    cert.Proprietario = _prop[0].Nome;
                else {
                    cert.Proprietario2 += _prop[0].Nome + "; ";
                }
            }

            

            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            SpCalculo _calculo = tributario_Class.Calculo_IPTU(Codigo, DateTime.Now.Year);
            cert.Vvc = _calculo.Vvp;
            cert.Vvt = _calculo.Vvt;
            cert.Vvi = _calculo.Vvi;
            cert.Iptu = _calculo.Valoriptu==0?_calculo.Valoritu:_calculo.Valoriptu;
            cert.Testada = _calculo.Testadaprinc;
            cert.Agrupamento = _calculo.Agrupamento;
            cert.Areapredial = _calculo.Areapredial;
            cert.Fracaoideal = _calculo.Fracao;

            Exception ex = imovel_Class.Insert_Dados_Imovel(cert);
            if (ex != null) {
                throw ex;
            } else {
                crystalReport.SetParameterValue("CODIGO", cert.Codigo.ToString("000000"));
                crystalReport.SetParameterValue("INSCRICAO", cert.Inscricao);
                crystalReport.SetParameterValue("SITUACAO", cert.Ativo);
                crystalReport.SetParameterValue("MT", cert.Mt);
                crystalReport.SetParameterValue("PROPRIETARIO", cert.Proprietario);
                crystalReport.SetParameterValue("CONTROLE", cert.Controle);
                crystalReport.SetParameterValue("PROPRIETARIO2", cert.Proprietario2);
                crystalReport.SetParameterValue("ENDERECO", cert.Endereco);
                crystalReport.SetParameterValue("NUMERO", cert.Numero);
                crystalReport.SetParameterValue("COMPLEMENTO", cert.Complemento);
                crystalReport.SetParameterValue("BAIRRO", cert.Bairro);
                crystalReport.SetParameterValue("CEP", cert.Cep);
                crystalReport.SetParameterValue("QUADRA", cert.Quadra);
                crystalReport.SetParameterValue("LOTE", cert.Lote);
                crystalReport.SetParameterValue("AREATERRENO", cert.Areaterreno);
                crystalReport.SetParameterValue("FRACAO", cert.Fracaoideal);
                crystalReport.SetParameterValue("TESTADA", cert.Testada);
                crystalReport.SetParameterValue("AGRUPAMENTO", cert.Agrupamento);
                crystalReport.SetParameterValue("FATORES", cert.Somafator);
                crystalReport.SetParameterValue("AREAPREDIAL", cert.Areapredial);
                crystalReport.SetParameterValue("IMUNIDADE", cert.Imunidade);
                crystalReport.SetParameterValue("RESIDE", cert.Reside);
                crystalReport.SetParameterValue("QTDEEDIF", cert.Qtdeedif);
                crystalReport.SetParameterValue("ISENTOCIP", cert.Isentocip);
                crystalReport.SetParameterValue("SITUACAO2", cert.Situacao);
                crystalReport.SetParameterValue("PEDOLOGIA", cert.Pedologia);
                crystalReport.SetParameterValue("TOPOGRAFIA", cert.Topografia);
                crystalReport.SetParameterValue("CATEGORIA", cert.Categoria);
                crystalReport.SetParameterValue("BENFEITORIA", cert.Benfeitoria);
                crystalReport.SetParameterValue("USOTERRENO", cert.Usoterreno);
                crystalReport.SetParameterValue("CONDOMINIO", cert.Condominio);
                crystalReport.SetParameterValue("VVT", cert.Vvt);
                crystalReport.SetParameterValue("VVI", cert.Vvi);
                crystalReport.SetParameterValue("VVP", cert.Vvc);
                crystalReport.SetParameterValue("IPTU", cert.Iptu);

                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();

                try {
                    crystalReport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Ficha_Cadastral");
                } catch {
                } finally {
                    crystalReport.Close();
                    crystalReport.Dispose();
                }
            }
        }

    }
}