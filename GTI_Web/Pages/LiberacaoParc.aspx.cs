using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class LiberacaoParc : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

                txtProcesso.Text = "";
                txtIM.Text = "";
                lblMsg.Text = "";
        }

        private bool Valida() {
            int Codigo = 0;
            lblMsg.Text = "";

            if (txtimgcode.Text != Session["randomStr"].ToString()) {
                lblMsg.Text = "Código da imagem inválido";
                return false;
            }

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

            return true;
        }


        protected void btPrint_Click(object sender, EventArgs e) {
            if (Valida()) {
                int Codigo = Convert.ToInt32(txtIM.Text);
                string sNumProc = txtProcesso.Text;
                if (sNumProc.Length < 6) {
                    lblMsg.Text = "Nº de processo inválido.";
                } else {
                    Tributario_bll tributario_class = new Tributario_bll("GTIconnection");
                    List<Destinoreparc> Lista = tributario_class.Lista_Destino_Parcelamento(sNumProc);
                    if (Lista.Count == 0) {
                        lblMsg.Text = "Processo não cadastrado.";
                    } else {
                        int _codigo = Lista[0].Codreduzido;
                        if (_codigo != Codigo) {
                            lblMsg.Text = "Processo não pertence a esta inscrição.";
                        } else {
                            int _seq = Lista[0].Numsequencia;
                            List<DebitoStructure> ListaDebito = tributario_class.Lista_Parcelas_Parcelamento_Ano(_codigo, 2020, _seq);
                            if (ListaDebito.Count == 0) {
                                lblMsg.Text = "Não existem parcelas a serem impressas.";
                            } else {
                                lblMsg.Text = "Imprimindo " + ListaDebito.Count.ToString() + " parcelas";

                                string _descricao_lancamento = "PARCELAMENTO DE DÉBITOS";
                                int nSid = gtiCore.GetRandomNumber();

                                int nPos = 0;
                                foreach (DebitoStructure item in ListaDebito) {

                                    //criamos um documento novo para cada parcela da vigilância
                                    Numdocumento regDoc = new Numdocumento();
                                    regDoc.Valorguia = item.Soma_Principal;
                                    regDoc.Emissor = "Gti.Web/2ViaVS";
                                    regDoc.Datadocumento = DateTime.Now;
                                    regDoc.Registrado = false;
                                    regDoc.Percisencao = 0;
                                    regDoc.Percisencao = 0;
                                    int _novo_documento = tributario_class.Insert_Documento(regDoc);
                                    regDoc.numdocumento = _novo_documento;
                                    ListaDebito[nPos].Numero_Documento = _novo_documento;

                                    //grava o documento na parcela
                                    Parceladocumento regParc = new Parceladocumento();
                                    regParc.Codreduzido = item.Codigo_Reduzido;
                                    regParc.Anoexercicio = Convert.ToInt16(item.Ano_Exercicio);
                                    regParc.Codlancamento = Convert.ToInt16(item.Codigo_Lancamento);
                                    regParc.Seqlancamento = Convert.ToInt16(item.Sequencia_Lancamento);
                                    regParc.Numparcela = Convert.ToByte(item.Numero_Parcela);
                                    regParc.Codcomplemento = Convert.ToByte(item.Complemento);
                                    regParc.Numdocumento = _novo_documento;
                                    regParc.Valorjuros = 0;
                                    regParc.Valormulta = 0;
                                    regParc.Valorcorrecao = 0;
                                    regParc.Plano = 0;
                                    tributario_class.Insert_Parcela_Documento(regParc);

                                    //Registrar os novos documentos
                                    //_empresa = empresa_Class.Retorna_Empresa(_codigo);
                                    //Ficha_compensacao_documento ficha = new Ficha_compensacao_documento();
                                    //ficha.Nome = _empresa.Razao_social.Length > 40 ? _empresa.Razao_social.Substring(0, 40) : _empresa.Razao_social;
                                    //string _enderecoReg = _empresa.Endereco_nome + ", " + _empresa.Numero.ToString() + " " + _empresa.Complemento;
                                    //ficha.Endereco = _enderecoReg.Length > 40 ? _enderecoReg.Substring(0, 40) : _enderecoReg;
                                    //ficha.Bairro = _empresa.Bairro_nome.Length > 15 ? _empresa.Bairro_nome.Substring(0, 15) : _empresa.Bairro_nome;
                                    //ficha.Cidade = _empresa.Cidade_nome.Length > 30 ? _empresa.Cidade_nome.Substring(0, 30) : _empresa.Cidade_nome;
                                    //ficha.Uf = _empresa.UF;
                                    //ficha.Cep = gtiCore.RetornaNumero(_empresa.Cep);
                                    //ficha.Cpf = _empresa.Cpf_cnpj;
                                    //ficha.Numero_documento = _novo_documento;
                                    //ficha.Data_vencimento = Convert.ToDateTime(item.Data_Vencimento);
                                    //ficha.Valor_documento = Convert.ToDecimal(item.Soma_Principal);
                                    //Exception ex = tributario_Class.Insert_Ficha_Compensacao_Documento(ficha);
                                    //if (ex == null)
                                    //    ex = tributario_Class.Marcar_Documento_Registrado(_novo_documento);
                                    nPos++;
                                }


                                //string _razao = _empresa.Razao_social;
                                //string _cpfcnpj;
                                //if (_empresa.Juridica)
                                //    _cpfcnpj = Convert.ToUInt64(_empresa.Cpf_cnpj).ToString(@"00\.000\.000\/0000\-00");
                                //else {
                                //    if (_empresa.Cpf_cnpj.Length > 1)
                                //        _cpfcnpj = Convert.ToUInt64(_empresa.Cpf_cnpj).ToString(@"000\.000\.000\-00");
                                //    else
                                //        _cpfcnpj = "";
                                //}
                                //string _endereco = _empresa.Endereco_nome;
                                //short _numimovel = (short)_empresa.Numero;
                                //string _complemento = _empresa.Complemento;
                                //string _bairro = _empresa.Bairro_nome;
                                //string _cep = _empresa.Cep;

                                short _index = 0;
                                string _convenio = "2873532";
                                foreach (DebitoStructure item in ListaDebito) {

                                    Boletoguia reg = new Boletoguia();
                                    reg.Usuario = "Gti.Web/2ViaVSTLL";
                                    reg.Computer = "web";
                                    reg.Sid = nSid;
                                    reg.Seq = _index;
                                    reg.Codreduzido = _codigo.ToString("000000");
                                    //reg.Nome = _razao;
                                    //reg.Cpf = _cpfcnpj;
                                    //reg.Numimovel = _numimovel;
                                    //reg.Endereco = _endereco;
                                    //reg.Complemento = _complemento;
                                    //reg.Bairro = _bairro;
                                    //reg.Cidade = "JABOTICABAL";
                                    //reg.Uf = "SP";
                                    //reg.Cep = _cep;
                                    //reg.Desclanc = _descricao_lancamento;
                                    //reg.Fulllanc = _descricao_lancamento;
                                    //reg.Numdoc = item.Numero_Documento.ToString();
                                    //reg.Numparcela = (short)item.Numero_Parcela;
                                    //reg.Datadoc = item.Data_Base;
                                    //reg.Datavencto = item.Data_Vencimento;
                                    //reg.Numdoc2 = item.Numero_Documento.ToString();
                                    //reg.Valorguia = item.Soma_Principal;
                                    //reg.Valor_ISS = 0;
                                    //reg.Valor_Taxa = _total;

                                    //***** GERA CÓDIGO DE BARRAS BOLETO REGISTRADO*****
                                    DateTime _data_base = Convert.ToDateTime("07/10/1997");
                                    TimeSpan ts = Convert.ToDateTime(item.Data_Vencimento) - _data_base;
                                    int _fator_vencto = ts.Days;
                                    string _quinto_grupo = String.Format("{0:D4}", _fator_vencto);
                                    string _valor_boleto_str = string.Format("{0:0.00}", reg.Valorguia);
                                    _quinto_grupo += string.Format("{0:D10}", Convert.ToInt64(gtiCore.RetornaNumero(_valor_boleto_str)));
                                    string _barra = "0019" + _quinto_grupo + String.Format("{0:D13}", Convert.ToInt32(_convenio));
                                    _barra += String.Format("{0:D10}", Convert.ToInt64(reg.Numdoc)) + "17";
                                    string _campo1 = "0019" + _barra.Substring(19, 5);
                                    string _digitavel = _campo1 + gtiCore.Calculo_DV10(_campo1).ToString();
                                    string _campo2 = _barra.Substring(23, 10);
                                    _digitavel += _campo2 + gtiCore.Calculo_DV10(_campo2).ToString();
                                    string _campo3 = _barra.Substring(33, 10);
                                    _digitavel += _campo3 + gtiCore.Calculo_DV10(_campo3).ToString();
                                    string _campo5 = _quinto_grupo;
                                    string _campo4 = gtiCore.Calculo_DV11(_barra).ToString();
                                    _digitavel += _campo4 + _campo5;
                                    _barra = _barra.Substring(0, 4) + _campo4 + _barra.Substring(4, _barra.Length - 4);
                                    //**Resultado final**
                                    string _linha_digitavel = _digitavel.Substring(0, 5) + "." + _digitavel.Substring(5, 5) + " " + _digitavel.Substring(10, 5) + "." + _digitavel.Substring(15, 6) + " ";
                                    _linha_digitavel += _digitavel.Substring(21, 5) + "." + _digitavel.Substring(26, 6) + " " + _digitavel.Substring(32, 1) + " " + gtiCore.StringRight(_digitavel, 14);
                                    string _codigo_barra = gtiCore.Gera2of5Str(_barra);
                                    //**************************************************
                                    reg.Totparcela = (short)ListaDebito.Count;
                                    if (item.Numero_Parcela == 0) {
                                        reg.Parcela = "Única";
                                    } else
                                        //    reg.Parcela = reg.Numparcela.ToString("00") + "/" + reg.Totparcela.ToString("00");
                                        reg.Parcela = reg.Numparcela.ToString("00") + "/" + (ListaDebito.Count - 1).ToString("00");

                                    reg.Digitavel = _linha_digitavel;
                                    reg.Codbarra = _codigo_barra;
                                    reg.Nossonumero = _convenio + String.Format("{0:D10}", Convert.ToInt64(reg.Numdoc));
                                    tributario_class.Insert_Boleto_Guia(reg);

                                    _index++;
                                }
                                Session["sid"] = nSid;
                                Response.Redirect("~/Pages/LiberacaoParcend.aspx?d=gti");

                            }
                        }
                    }
                }

            }  
        }

    }
}