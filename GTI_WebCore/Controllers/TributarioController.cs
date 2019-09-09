using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.Models.ReportModels;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GTI_WebCore.Controllers {
    [Route("Tributario")]
    public class TributarioController : Controller
    {
        private readonly ITributarioRepository tributarioRepository;
        private readonly IImovelRepository imovelRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public TributarioController(ITributarioRepository tributarioRepository,IImovelRepository imovelRepository,IEmpresaRepository empresaRepository,IHostingEnvironment hostingEnvironment) {
            this.tributarioRepository = tributarioRepository;
            this.imovelRepository = imovelRepository;
            this.empresaRepository = empresaRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("Certidao/Certidao_Debito_Codigo")]
        [HttpGet]
        public ViewResult Certidao_Debito_Codigo() {
            return View();
        }

        [Route("Certidao/Certidao_Debito_Codigo")]
        [HttpPost]
        public IActionResult Certidao_Debito_Codigo(CertidaoViewModel model) {
            int _codigo = 0;
            short _ret =0;
            int _numero = tributarioRepository.Retorna_Codigo_Certidao(Functions.TipoCertidao.Debito);
            bool _existeCod = false;
            string _tipoCertidao = "",_nao="", _sufixo = "XX",_reportName="", _numProcesso = "9222-3/2012", _dataProcesso = "18/04/2012"; 
            Functions.TipoCadastro _tipoCadastro=new Functions.TipoCadastro();

            CertidaoViewModel certidaoViewModel = new CertidaoViewModel();
            ViewBag.Result = "";

            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
                if (_codigo < 100000) {
                    _existeCod = imovelRepository.Existe_Imovel(_codigo);
                    _tipoCadastro = Functions.TipoCadastro.Imovel;
                } else {
                    if (_codigo >= 100000 && _codigo < 500000) {
                        _existeCod = empresaRepository.Existe_Empresa_Codigo(_codigo);
                        _tipoCadastro = Functions.TipoCadastro.Empresa;
                    } else {
                        _tipoCadastro = Functions.TipoCadastro.Cidadao;
                        ViewBag.Result = "Inscrição inválida.";
                        return View(certidaoViewModel);
                    }
                }
            }

            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                ViewBag.Result = "Código de verificação inválido.";
                return View(certidaoViewModel);
            }

            if (!_existeCod) {
                ViewBag.Result = "Inscrição não cadastrada.";
                return View(certidaoViewModel);
            }


            //***Verifica débito

            Certidao_debito_detalhe dadosCertidao = tributarioRepository.Certidao_Debito(_codigo);
            if (dadosCertidao.Tipo_Retorno == Functions.RetornoCertidaoDebito.Negativa) {
                _tipoCertidao = "NEGATIVA";
                _nao = "não ";
                _ret = 3;
                _sufixo = "CN";
                if (_tipoCadastro == Functions.TipoCadastro.Imovel)
                    _reportName = "Certidao_Debito_Imovel.rpt";
            }
            //else {
            //    if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.Positiva) {
            //        sTipoCertidao = "POSITIVA";
            //        nRet = 4;
            //        sSufixo = "CP";
            //        if (_tipo_cadastro == TipoCadastro.Imovel) {
            //            bool bCertifica = tributario_Class.Parcela_Unica_IPTU_NaoPago(Codigo, DateTime.Now.Year);
            //            if (bCertifica) {
            //                sCertifica = " embora conste parcela(s) não paga(s) do IPTU de " + DateTime.Now.Year.ToString() + ", em razão da possibilidade do pagamento integral deste imposto em data futura";
            //                nRet = 3;
            //                sTipoCertidao = "NEGATIVA";
            //                sSufixo = "CN";
            //                sNao = "não ";
            //            } else
            //                sCertifica = " até a presente data";
            //            crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoImovel.rpt"));

            //        } else {
            //            if (_tipo_cadastro == TipoCadastro.Empresa)
            //                crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoEmpresa.rpt"));
            //        }
            //    } else {
            //        if (dadosCertidao.Tipo_Retorno == RetornoCertidaoDebito.NegativaPositiva) {
            //            sTipoCertidao = "POSITIVA COM EFEITO NEGATIVA";
            //            nRet = 5;
            //            sSufixo = "PN";
            //            if (_tipo_cadastro == TipoCadastro.Imovel)
            //                crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoImovelPN.rpt"));
            //            else {
            //                if (_tipo_cadastro == TipoCadastro.Empresa)
            //                    crystalReport.Load(Server.MapPath("~/Report/CertidaoDebitoEmpresaPN.rpt"));
            //            }
            //        }
            //    }
            //}
            string _tributo = dadosCertidao.Descricao_Lancamentos;

            int _numero_certidao =tributarioRepository.Retorna_Codigo_Certidao(Functions.TipoCertidao.Debito);
            int _ano_certidao = DateTime.Now.Year;
            

            List<Certidao> certidao = new List<Certidao>();
            List<ProprietarioStruct> listaProp = imovelRepository.Lista_Proprietario(_codigo, true);
            ImovelStruct _dados = imovelRepository.Dados_Imovel(_codigo);
            Certidao reg = new Certidao() {
                Codigo = _dados.Codigo,
                Inscricao = _dados.Inscricao,
                Endereco = _dados.NomeLogradouro,
                Endereco_Numero = (int)_dados.Numero,
                Endereco_Complemento = _dados.Complemento,
                Bairro = _dados.NomeBairro ?? "",
                Cidade="JABOTICABAL",
                Uf="SP",
                Atividade_Extenso="",
                Nome_Requerente = listaProp[0].Nome,
                Ano = DateTime.Now.Year,
                Numero = _numero,
                Quadra_Original = _dados.QuadraOriginal ?? "",
                Lote_Original = _dados.LoteOriginal ?? "",
                Controle = _numero_certidao.ToString("00000") + _ano_certidao.ToString("0000") + "/" + _codigo.ToString() + "-" + _sufixo,
                Tipo_Certidao = _tipoCertidao,
                Nao=_nao,
                Tributo=_tributo
            };

            reg.Numero_Ano = _numero_certidao.ToString("00000") + "/" + _ano_certidao.ToString("0000");
            certidao.Add(reg);

            
            Certidao_debito cert = new Certidao_debito {
                Codigo = _codigo,
                Ano = (short)DateTime.Now.Year,
                Ret = _ret,
                Numero = _numero_certidao,
                Datagravada = DateTime.Now,
                Inscricao = reg.Inscricao,
                Nome = reg.Nome_Requerente,
                Logradouro = reg.Endereco,
                Numimovel = (short)reg.Endereco_Numero,
                Bairro = reg.Bairro,
                Cidade = reg.Cidade,
                UF = reg.Uf,
                Processo = _numProcesso,
                Dataprocesso = Convert.ToDateTime(_dataProcesso),
                Atendente = "GTI.Web",
                Cpf = listaProp[0].CPF,
                Cnpj = listaProp[0].CNPJ,
                Atividade = reg.Atividade_Extenso,
                Suspenso="",
                Lancamento = dadosCertidao.Descricao_Lancamentos
            };
            Exception ex = tributarioRepository.Insert_Certidao_Debito(cert);
            if (ex != null) {
                ViewBag.Result = "Ocorreu um erro no processamento das informações.";
                return View("Certidao_Debito_Codigo");
            }

            ReportDocument rd = new ReportDocument();
            rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\" + _reportName);

            try {
                rd.SetDataSource(certidao);
                Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                return File(stream, "application/pdf", "Certidao_Debito.pdf");
            } catch {
                throw;
            }
        }










        [Route("Certidao/Certidao_Debito_Doc")]
        [HttpGet]
        public ViewResult Certidao_Debito_Doc() {
            CertidaoViewModel model = new CertidaoViewModel {
                OptionList = new List<SelectListItem> {
                new SelectListItem { Text = " CPF", Value = "cpfCheck", Selected = true },
                new SelectListItem { Text = " CNPJ", Value = "cnpjCheck", Selected = false }
            },
                SelectedValue = "cpfCheck"
            };
            return View(model);
        }



    }
}