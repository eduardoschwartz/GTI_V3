﻿using GTI_Bll.Classes;
using GTI_Models.Models;
using GTI_Models;
using System;
using System.Collections.Generic;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class SegundaViaISS : System.Web.UI.Page {
        int _ano = 2019;

        protected void Page_Load(object sender, EventArgs e) {
            lblMsg.Text = "";
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

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

        protected void txtCPF_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void txtCNPJ_TextChanged(object sender, EventArgs e) {
            lblMsg.Text = "";
        }

        protected void VerificarButton_Click(object sender, EventArgs e) {
            string sCPF = txtCPF.Text, sCNPJ = txtCNPJ.Text, num_cpf_cnpj = "", sNome = "", sAtividade = "";
            int _codigo = 0;

            bool isNum = Int32.TryParse(Codigo.Text, out _codigo);
            if (!isNum) {
                lblMsg.Text = "Código de contribuinte inválido!";
            } else {
                if (_codigo < 100000 || _codigo >= 300000) {
                    lblMsg.Text = "Código de contribuinte inválido!";
                } else {
                    if (txtimgcode.Text != Session["randomStr"].ToString())
                        lblMsg.Text = "Código da imagem inválido";
                    else {
                        if (sCPF == "" && sCNPJ == "")
                            lblMsg.Text = "Digite o CPF/CNPJ da empresa.";
                        else {
                            if (optCPF.Checked) {
                                num_cpf_cnpj = gtiCore.RetornaNumero(txtCPF.Text);
                                if (!gtiCore.ValidaCpf(num_cpf_cnpj)) {
                                    lblMsg.Text = "CPF inválido!";
                                    return;
                                }
                            } else {
                                num_cpf_cnpj = gtiCore.RetornaNumero(txtCNPJ.Text);
                                if (!gtiCore.ValidaCNPJ(num_cpf_cnpj)) {
                                    lblMsg.Text = "CNPJ inválido!";
                                    return;
                                }
                            }

                            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
                            bool bFind = empresa_Class.Existe_Empresa(_codigo);
                            if (bFind) {
                                EmpresaStruct reg = empresa_Class.Retorna_Empresa(_codigo);
                                if (optCPF.Checked) {
                                    if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000") != num_cpf_cnpj) {
                                        lblMsg.Text = "CPF não pertence ao proprietário deste imóvel!";
                                        return;
                                    }
                                } else {
                                    if (Convert.ToInt64(gtiCore.RetornaNumero(reg.Cpf_cnpj)).ToString("00000000000000") != num_cpf_cnpj) {
                                        lblMsg.Text = "CNPJ não pertence ao proprietário deste imóvel!";
                                        return;
                                    }
                                }
                                sNome = reg.Razao_social;
                                sAtividade = reg.Atividade_extenso;
                            } else {
                                lblMsg.Text = "Inscrição Municipal não cadastrada!";
                                return;
                            }

                            Tributario_bll tributario_Class = new Tributario_bll("GTIconnection");

                            Paramparcela _parametro_parcela = tributario_Class.Retorna_Parametro_Parcela(_ano, (int)modelCore.TipoCarne.Iss_Taxa);
                            int _qtde_parcela = (int)_parametro_parcela.Qtdeparcela;
                            decimal _SomaISS = 0, _SomaTaxa = 0;

                            List<DebitoStructure> Lista_Taxa = tributario_Class.Lista_Parcelas_Taxa(_codigo, 2019);
                            List<DebitoStructure> Lista_Iss = tributario_Class.Lista_Parcelas_Iss_Fixo(_codigo, 2019);
                            bool _temtaxa = Lista_Taxa.Count > 0 ? true : false;
                            bool _temiss = Lista_Iss.Count > 0 ? true : false;

                            List<DebitoStructure> Lista_Unificada = new List<DebitoStructure>();
                            foreach (DebitoStructure item in Lista_Taxa) {//carrega a lista unificada com os dados das taxas
                                DebitoStructure reg = new DebitoStructure();
                                reg.Codigo_Tributo = item.Codigo_Tributo;
                                reg.Abreviatura_Tributo = item.Abreviatura_Tributo;
                                reg.Data_Vencimento = item.Data_Vencimento;
                                reg.Numero_Parcela = item.Numero_Parcela;
                                reg.Numero_Documento = item.Numero_Documento;
                                reg.Soma_Principal = item.Soma_Principal;
                                reg.Data_Base = item.Data_Base;
                                Lista_Unificada.Add(reg);
                                if (item.Numero_Parcela > 0)
                                    _SomaTaxa += item.Soma_Principal;
                            }

                            if (_temiss) {
                                if (_temtaxa) {//se tiver taxa, tem que juntar os dois na lista unificada
                                    bFind = false;
                                    int _index = 0;
                                    foreach (DebitoStructure item in Lista_Taxa) {
                                        decimal _valor_principal = 0;
                                        foreach (var item2 in Lista_Iss) {
                                            if (item.Numero_Documento == item2.Numero_Documento) {
                                                _valor_principal = item2.Soma_Principal;
                                                Lista_Unificada[_index].Soma_Principal+=_valor_principal;
                                                if (item.Numero_Parcela > 0)
                                                    _SomaISS += item2.Soma_Principal;
                                                _index++;
                                                break;
                                            }
                                        }
                                    }
                                } else { //se não tiver taxa, a lista unficada conterá apenas os dados de iss
                                    foreach (DebitoStructure item in Lista_Iss) {
                                        DebitoStructure reg = new DebitoStructure();
                                        reg.Codigo_Tributo = item.Codigo_Tributo;
                                        reg.Abreviatura_Tributo = item.Abreviatura_Tributo;
                                        reg.Data_Vencimento = item.Data_Vencimento;
                                        reg.Numero_Parcela = item.Numero_Parcela;
                                        reg.Numero_Documento = item.Numero_Documento;
                                        reg.Soma_Principal = item.Soma_Principal;
                                        reg.Data_Base = item.Data_Base;
                                        Lista_Unificada.Add(reg);
                                        if (item.Numero_Parcela > 0)
                                            _SomaISS += item.Soma_Principal;
                                    }
                                }
                            }

                            if (!_temtaxa && !_temiss) {
                                lblMsg.Text = "Não é possível emitir segunda via para este código";
                            } else {
                                string _descricao_lancamento;
                                if (_temtaxa && _temiss)
                                    _descricao_lancamento = "ISS FIXO/TAXA DE LICENÇA";
                                else {
                                    if (_temtaxa && !_temiss)
                                        _descricao_lancamento = "TAXA DE LICENÇA";
                                    else
                                        _descricao_lancamento = "ISS FIXO";
                                }
                                int nSid = gtiCore.GetRandomNumber();

                                EmpresaStruct _empresa = empresa_Class.Retorna_Empresa(_codigo);
                                string _razao = _empresa.Razao_social;
                                string _cpfcnpj;
                                if (_empresa.Juridica)
                                    _cpfcnpj = Convert.ToUInt64(_empresa.Cpf_cnpj).ToString(@"00\.000\.000\/0000\-00");
                                else {
                                    if (_empresa.Cpf_cnpj.Length > 1)
                                        _cpfcnpj = Convert.ToUInt64(_empresa.Cpf_cnpj).ToString(@"000\.000\.000\-00");
                                    else
                                        _cpfcnpj = "";
                                }
                                string _endereco = _empresa.Endereco_nome;
                                short _numimovel=(short)_empresa.Numero;
                                string _complemento = _empresa.Complemento;
                                string _bairro = _empresa.Bairro_nome;
                                string _cep = _empresa.Cep;

                                short _index = 0;
                                string _convenio = "2873532";
                                foreach (DebitoStructure item in Lista_Unificada) {

                                    Boletoguia reg = new Boletoguia();
                                    reg.Usuario = "Gti.Web/2ViaISSTLL";
                                    reg.Computer = "web";
                                    reg.Sid = nSid;
                                    reg.Seq =_index;
                                    reg.Codreduzido = _codigo.ToString("000000");
                                    reg.Nome = _razao;
                                    reg.Cpf = _cpfcnpj;
                                    reg.Numimovel = _numimovel;
                                    reg.Endereco = _endereco;
                                    reg.Complemento = _complemento;
                                    reg.Bairro = _bairro;
                                    reg.Cidade = "JABOTICABAL";
                                    reg.Uf = "SP";
                                    reg.Cep = _cep;
                                    reg.Desclanc = _descricao_lancamento;
                                    reg.Fulllanc = _descricao_lancamento;
                                    reg.Numdoc = item.Numero_Documento.ToString();
                                    reg.Numparcela = (short)item.Numero_Parcela;
                                    reg.Datadoc = item.Data_Base;
                                    reg.Datavencto = item.Data_Vencimento;
                                    reg.Numdoc2 = item.Numero_Documento.ToString();
                                    reg.Valorguia = item.Soma_Principal;
                                    reg.Valor_ISS = _SomaISS;
                                    reg.Valor_Taxa = _SomaTaxa;

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
                                    reg.Totparcela = (short)_qtde_parcela;
                                    if (item.Numero_Parcela == 0) {
                                            reg.Parcela = "Única";
                                    } else
                                        reg.Parcela = reg.Numparcela.ToString("00") + "/" + reg.Totparcela.ToString("00");


                                    reg.Digitavel = _linha_digitavel;
                                    reg.Codbarra = _codigo_barra;
                                    reg.Nossonumero = _convenio + String.Format("{0:D10}", Convert.ToInt64(reg.Numdoc));
                                    tributario_Class.Insert_Boleto_Guia(reg);

                                    _index++;
                                }
                                Session["sid"] = nSid;
                                Response.Redirect("~/Pages/SegundaViaISSend.aspx?d=gti");

                            }

                        }
                    }
                }
            }
            
        }



    }
}