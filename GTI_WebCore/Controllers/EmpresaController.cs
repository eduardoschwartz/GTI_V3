using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GTI_WebCore.Controllers {

    [Route("Empresa/Details")]
    [Route("Empresa/exportReport")]
    public class EmpresaController : Controller {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository) {
            _empresaRepository = empresaRepository;
        }

        [HttpGet]
        public ViewResult Details() {
            return View();
        }

        [HttpPost]
        public ViewResult Details(EmpresaDetailsViewModel model) {
            int _codigo = 0;
            bool _existeCod = false;
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel();

            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
                if(_codigo>=100000 && _codigo<210000) //Se estiver fora deste intervalo nem precisa checar se a empresa existe
                    _existeCod = _empresaRepository.Existe_Empresa_Codigo(_codigo);
            } else {
                if (model.CnpjValue != null) {
                    string _cnpj = model.CnpjValue;
                    bool _valida = Functions.ValidaCNPJ(_cnpj); //CNPJ válido?
                    if (_valida) {
                        _codigo = _empresaRepository.Existe_Empresa_Cnpj(_cnpj);
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
                            _codigo = _empresaRepository.Existe_Empresa_Cpf(_cpf);
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
                EmpresaStruct empresa = _empresaRepository.Dados_Empresa(_codigo);
                empresaDetailsViewModel.EmpresaStruct = empresa;
                empresaDetailsViewModel.TaxaLicenca = _empresaRepository.Empresa_tem_TL(_codigo)?"Sim":"Não";
                empresaDetailsViewModel.Vigilancia_Sanitaria = _empresaRepository.Empresa_tem_VS(_codigo) ? "Sim" : "Não";
                empresaDetailsViewModel.Mei = _empresaRepository.Empresa_Mei(_codigo) ? "Sim" : "Não";
                List<CnaeStruct> ListaCnae = _empresaRepository.Lista_Cnae_Empresa(_codigo);
                string sCnae = "";
                foreach (CnaeStruct cnae in ListaCnae) {
                    sCnae += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
                }
                empresaDetailsViewModel.Cnae = sCnae;
                string sRegime = _empresaRepository.Regime_Empresa(_codigo);
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
                return View("DetailsTable",empresaDetailsViewModel);
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



    }
}





