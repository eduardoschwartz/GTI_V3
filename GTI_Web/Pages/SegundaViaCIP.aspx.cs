using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;


namespace UIWeb.Pages {
    public partial class SegundaViaCIP : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btPrint_Click(object sender, EventArgs e) {
            int Num = 0;
            String sTextoImagem = txtimgcode.Text;
            txtimgcode.Text = "";
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            bool isNum = Int32.TryParse(txtCod.Text, out Num);
            if (!isNum) {
                lblmsg.Text = "Código do imóvel inválido!";
                return;
            } else {
                bool bExiste = imovel_Class.Existe_Imovel(Num);
                if (!bExiste) {
                    lblmsg.Text = "Código do imóvel inválido!";
                    return;
                } else {
                    if (String.IsNullOrWhiteSpace(txtIC.Text)) {
                        lblmsg.Text = "Inscrição cadastral obrigatória!";
                        return;
                    } else {
                        ImovelStruct reg = imovel_Class.Dados_Imovel(Num);
                        if (gtiCore.RetornaNumero(  txtIC.Text) != reg.Inscricao) {
                            lblmsg.Text = "Inscrição cadastral inválida!";
                            return;
                        }
                    }
                }
            }

            if (Page.IsValid && (txtimgcode.Text == Session["randomStr"].ToString())) {
                lblmsg.Text = "Código da imagem inválido.";
                return;
            }

            lblmsg.Text = "";
            this.txtimgcode.Text = "";
            int nSid = gravaCarne();
            if (nSid > 0) {
                Session["sid"] = nSid;
                Response.Redirect("~/Pages/SegundaViaCIPFim.aspx");
            }
        }


        private int gravaCarne() {
            int nSid = gtiCore.GetRandomNumber();
            int nImovel = Convert.ToInt32(txtCod.Text);
            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");
            Imovel_bll imovel_Class = new Imovel_bll("GTIconnection");
            List<DebitoStructure> Extrato_Lista = tributario_Class.Lista_Parcelas_CIP(nImovel, 2018);
            if (Extrato_Lista.Count == 0) {
                lblmsg.Text = "Não é possível emitir segunda via para este código";
                return 0;
            }

            short nSeq = 0;
            foreach (DebitoStructure item in Extrato_Lista) {
                ImovelStruct dados_imovel = imovel_Class.Dados_Imovel(nImovel);
                List<ProprietarioStruct> lstProprietario = imovel_Class.Lista_Proprietario(nImovel, true);
                Boletoguia reg = new Boletoguia();
                reg.Usuario = "Gti.Web/2ViaIPTU";
                reg.Computer = "web";
                reg.Sid = nSid;
                reg.Seq = nSeq;
                reg.Codreduzido = nImovel.ToString("000000");
                reg.Nome = lstProprietario[0].Nome;
                reg.Cpf = lstProprietario[0].CPF;
                reg.Endereco = dados_imovel.NomeLogradouro;
                reg.Numimovel = (short)dados_imovel.Numero;
                reg.Complemento = dados_imovel.Complemento.Length > 10 ? dados_imovel.Complemento.Substring(0, 10) : dados_imovel.Complemento;
                reg.Bairro = dados_imovel.NomeBairro;
                reg.Cidade = "JABOTICABAL";
                reg.Uf = "SP";
                reg.Desclanc = "CONTRIBUIÇÃO DE ILUMINAÇÃO PÚBLICA (CIP-2018)";
                reg.Fulllanc = "CONTRIBUIÇÃO DE ILUMINAÇÃO PÚBLICA (CIP-2018)";
                reg.Numdoc = item.Numero_Documento.ToString();
                reg.Numparcela = (short)item.Numero_Parcela;
                reg.Datavencto = Convert.ToDateTime(item.Data_Vencimento);
                reg.Numdoc2 = item.Numero_Documento.ToString();
                reg.Digitavel = "linha digitavel";
                reg.Valorguia = Convert.ToDecimal(item.Soma_Principal);
                reg.Totparcela = 3;
                reg.Obs = "";
                reg.Numproc = "Q:" + dados_imovel.QuadraOriginal.ToString().Trim() + " L:" + dados_imovel.LoteOriginal.ToString().Trim();
                reg.Cep = dados_imovel.Cep;

                //*** CÓDIGO DE BARRAS ***

                decimal nValorguia = Math.Truncate(Convert.ToDecimal(reg.Valorguia * 100));
                string NumBarra = gtiCore.Gera2of5Cod((nValorguia).ToString(), Convert.ToDateTime(item.Data_Vencimento), Convert.ToInt32(reg.Numdoc), Convert.ToInt32(reg.Codreduzido));
                reg.Numbarra2a = NumBarra.Substring(0, 13);
                reg.Numbarra2b = NumBarra.Substring(13, 13);
                reg.Numbarra2c = NumBarra.Substring(26, 13);
                reg.Numbarra2d = NumBarra.Substring(39, 13);
                string strBarra = gtiCore.Gera2of5Str(reg.Numbarra2a.Substring(0, 11) + reg.Numbarra2b.Substring(0, 11) + reg.Numbarra2c.Substring(0, 11) + reg.Numbarra2d.Substring(0, 11));
                reg.Codbarra = gtiCore.Mask(strBarra);

                tributario_Class.Insert_Boleto_Guia(reg);

                Segunda_via_web reg_sv = new Segunda_via_web();
                reg_sv.Numero_documento = Convert.ToInt32(item.Numero_Documento);
                reg_sv.Data = DateTime.Now;
                tributario_Class.Insert_Numero_Segunda_Via(reg_sv);

                nSeq++;
            }

            return nSid;
        }




    }
}