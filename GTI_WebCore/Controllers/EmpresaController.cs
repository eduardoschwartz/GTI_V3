﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.Models.ReportModels;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GTI_WebCore.Controllers {

    [Route("Empresa")]
    public class EmpresaController : Controller {
        private readonly IEmpresaRepository empresaRepository;
        private readonly ITributarioRepository tributarioRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public EmpresaController(IEmpresaRepository empresaRepository, ITributarioRepository tributarioRepository,IHostingEnvironment hostingEnvironment) {
            this.empresaRepository = empresaRepository;
            this.tributarioRepository = tributarioRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        [Route("Details")]
        [HttpGet]
        public ViewResult Details() {
            return View();
        }

       
        [Route("Details")]
        [HttpPost]
        public ViewResult Details(EmpresaDetailsViewModel model) {
            int _codigo = 0;
            bool _existeCod = false;
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel();

            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
                if (_codigo >= 100000 && _codigo < 210000) //Se estiver fora deste intervalo nem precisa checar se a empresa existe
                    _existeCod = empresaRepository.Existe_Empresa_Codigo(_codigo);
            } else {
                if (model.CnpjValue != null) {
                    string _cnpj = model.CnpjValue;
                    bool _valida = Functions.ValidaCNPJ(_cnpj); //CNPJ válido?
                    if (_valida) {
                        _codigo = empresaRepository.Existe_Empresa_Cnpj(_cnpj);
                        if (_codigo > 0)
                            _existeCod = true;
                    } else {
                        empresaDetailsViewModel.ErrorMessage = "Cnpj inválido.";
                        return View(empresaDetailsViewModel);
                    }
                } else {
                    if (model.CpfValue != null) {
                        string _cpf = model.CpfValue;
                        bool _valida = Functions.ValidaCpf(_cpf); //CPF válido?
                        if (_valida) {
                            _codigo = empresaRepository.Existe_Empresa_Cpf(_cpf);
                            if (_codigo > 0)
                                _existeCod = true;

                        } else {
                            empresaDetailsViewModel.ErrorMessage = "Cpf inválido.";
                            return View(empresaDetailsViewModel);
                        }
                    }
                }
            }


            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                empresaDetailsViewModel.ErrorMessage = "Código de verificação inválido.";
                return View(empresaDetailsViewModel);
            }


            if (_existeCod) {
                EmpresaStruct empresa = empresaRepository.Dados_Empresa(_codigo);
                empresaDetailsViewModel.EmpresaStruct = empresa;
                empresaDetailsViewModel.TaxaLicenca = empresaRepository.Empresa_tem_TL(_codigo) ? "Sim" : "Não";
                empresaDetailsViewModel.Vigilancia_Sanitaria = empresaRepository.Empresa_tem_VS(_codigo) ? "Sim" : "Não";
                empresaDetailsViewModel.Mei = empresaRepository.Empresa_Mei(_codigo) ? "Sim" : "Não";
                List<CnaeStruct> ListaCnae = empresaRepository.Lista_Cnae_Empresa(_codigo);
                string sCnae = "";
                foreach (CnaeStruct cnae in ListaCnae) {
                    sCnae += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
                }
                empresaDetailsViewModel.Cnae = sCnae;
                string sRegime = empresaRepository.Regime_Empresa(_codigo);
                if (sRegime == "F")
                    sRegime = "ISS FIXO";
                else {
                    if (sRegime == "V")
                        sRegime = "ISS VARIÁVEL";
                    else {
                        if (sRegime == "E")
                            sRegime = "ISS ESTIMADO";
                        else
                            sRegime = "NENHUM";
                    }
                }
                empresaDetailsViewModel.Regime_Iss = sRegime;
                empresaDetailsViewModel.ErrorMessage = "";
                return View("DetailsTable", empresaDetailsViewModel);
            } else {
                empresaDetailsViewModel.ErrorMessage = "Empresa não cadastrada.";
                return View(empresaDetailsViewModel);
            }

        }

        [Route("get-captcha-image")]
        public IActionResult GetCaptchaImage() {
            int width = 100;
            int height = 36;
            var captchaCode = Captcha.GenerateCaptchaCode();
            var result = Captcha.GenerateCaptchaImage(width, height, captchaCode);
            HttpContext.Session.SetString("CaptchaCode", result.CaptchaCode);
            Stream s = new MemoryStream(result.CaptchaByteData);
            return new FileStreamResult(s, "image/png");
        }

        [Route("Certidao/Certidao_Inscricao")]
        [HttpGet]
        public ViewResult Certidao_Inscricao() {
            return View();
        }


        [Route("Retorna_Codigos")]
        [Route("Certidao/Retorna_Codigos")]
        public IActionResult Retorna_Codigos(CertidaoViewModel model) {
            if(model.CpfValue!=null || model.CnpjValue != null) {
                List<int> _lista = new List<int>();
                if (model.CpfValue != null) {
                    _lista = empresaRepository.Retorna_Codigo_por_CPF(Functions.RetornaNumero(model.CpfValue));
                } else {
                    if (model.CnpjValue != null) {
                        _lista = empresaRepository.Retorna_Codigo_por_CNPJ(Functions.RetornaNumero(model.CnpjValue));
                    }
                }
                if (_lista.Count > 0) {
                    ViewBag.Lista_Codigo = _lista;
                    return View("Certidao_Inscricao");
                } else {
                    ViewBag.Result = "Não foi localizada nenhuma empresa cadastrada com o CPF/CNPJ informado.";
                    return View("Certidao_Inscricao");
                }
            }
            ViewBag.Result = "Informe o CPF ou o CNPJ para busca.";
            return View("Certidao_Inscricao");
        }

        [HttpPost]
        [Route("Validate_CI")]
        [Route("Certidao/Validate_CI")]
        public IActionResult Validate_CI(CertidaoViewModel model) {
            ViewBag.Lista_Codigo = new List<int>() { 4, 5, 6 };
            return View("Certidao_Inscricao");
        }


        [Route("Certidao_Inscricao")]
        [Route("Certidao/Certidao_Inscricao")]
        [HttpPost]
        public IActionResult Certidao_Inscricao(CertidaoViewModel model) {
            int _codigo;
            bool _valida = false;
            int _numero = tributarioRepository.Retorna_Codigo_Certidao(Functions.TipoCertidao.Comprovante_Pagamento);
            CertidaoViewModel certidaoViewModel = new CertidaoViewModel();
            ViewBag.Result = "";

            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                ViewBag.Result = "Código de verificação inválido.";
                return View(certidaoViewModel);
            }

            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
            } else {
                ViewBag.Result = "Erro ao recuperar as informações.";
                return View(certidaoViewModel);
            }

            EmpresaStruct _dados = empresaRepository.Dados_Empresa(_codigo);
            string _sufixo = model.Extrato ? _dados.Data_Encerramento == null ? "XA" : "XE" : "IE";
            List<CnaeStruct> ListaCnae = empresaRepository.Lista_Cnae_Empresa(_codigo);
            string _cnae = "", _cnae2 = "";
            foreach (CnaeStruct cnae in ListaCnae) {
                if (cnae.Principal)
                    _cnae = cnae.CNAE + "-" + cnae.Descricao;
                else
                    _cnae2 += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
            }

            Comprovante_Inscricao reg = new Comprovante_Inscricao() {
                Codigo = _codigo,
                Inscricao_Estadual = _dados.Inscricao_estadual,
                Endereco = _dados.Nome_logradouro,
                Complemento = _dados.Complemento,
                Bairro = _dados.Bairro_nome ?? "",
                Ano = DateTime.Now.Year,
                Numero = _numero,
                Controle = _numero.ToString("00000") + DateTime.Now.Year.ToString("0000") + "/" + _codigo.ToString() + "-" + _sufixo,
                Atividade = _cnae,
                Atividade2 = _cnae2,
                Cpf_Cnpj = _dados.Cpf_cnpj,
                Data_Abertura = (DateTime)_dados.Data_abertura,
                Processo_Abertura = _dados.Numprocesso,
                Processo_Encerramento = _dados.Numprocessoencerramento
            };
            if (_dados.Data_Encerramento != null)
                reg.Data_Encerramento = (DateTime)_dados.Data_Encerramento;

            List<Comprovante_Inscricao> certidao = new List<Comprovante_Inscricao> {
                reg
            };
            ReportDocument rd = new ReportDocument();
            if (model.Extrato) {
            } else
                if (_valida)
                rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Comprovante_InscricaoValida");
            else
                rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Comprovante_Inscricao");
            try {
                rd.SetDataSource(certidao);
                Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                return File(stream, "application/pdf", "Certidao_Inscricao.pdf");
            } catch {
                throw;
            }

        }


    }
}





