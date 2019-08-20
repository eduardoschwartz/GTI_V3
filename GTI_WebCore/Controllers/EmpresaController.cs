using CrystalDecisions.CrystalReports.Engine;
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
        private readonly IEmpresaRepository _empresaRepository;
        private readonly ITributarioRepository tributarioRepository;

        public EmpresaController(IEmpresaRepository empresaRepository, ITributarioRepository tributarioRepository) {
            _empresaRepository = empresaRepository;
            this.tributarioRepository = tributarioRepository;
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
                empresaDetailsViewModel.TaxaLicenca = _empresaRepository.Empresa_tem_TL(_codigo) ? "Sim" : "Não";
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
                    _lista = _empresaRepository.Retorna_Codigo_por_CPF(Functions.RetornaNumero(model.CpfValue));
                } else {
                    if (model.CnpjValue != null) {
                        _lista = _empresaRepository.Retorna_Codigo_por_CNPJ(Functions.RetornaNumero(model.CnpjValue));
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
            int _codigo = 0;
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

            EmpresaStruct _dados = _empresaRepository.Dados_Empresa(_codigo);
            Certidao reg = new Certidao() {
                Codigo = _dados.Codigo,
                Insc_Estadual = _dados.Inscricao_estadual,
                Endereco = _dados.Nome_logradouro,
                Endereco_Numero = (int)_dados.Numero,
                Endereco_Complemento = _dados.Complemento,
                Bairro = _dados.Bairro_nome ?? "",
                Ano = DateTime.Now.Year,
                Numero = _numero,
                Controle = _numero.ToString("00000") + DateTime.Now.Year.ToString("0000") + "/" + _codigo.ToString() + "-CI"
            };



            
            //certidaoViewModel.EmpresaStruct.Codigo = empresa.Codigo;
            //certidaoViewModel.EmpresaStruct.Razao_social = empresa.Razao_social;
            //certidaoViewModel.EmpresaStruct.Nome_fantasia = empresa.Nome_fantasia;
            //certidaoViewModel.EmpresaStruct.Cpf_cnpj = empresa.Cpf_cnpj;
            //certidaoViewModel.EmpresaStruct.Inscricao_estadual = empresa.Inscricao_estadual;
            //certidaoViewModel.EmpresaStruct.Data_abertura = empresa.Data_abertura;
            //certidaoViewModel.EmpresaStruct.Data_Encerramento = empresa.Data_Encerramento;
            //certidaoViewModel.EmpresaStruct.Cpf_cnpj = empresa.Numprocesso;
            //certidaoViewModel.EmpresaStruct.Cpf_cnpj = empresa.Numprocessoencerramento;
            //certidaoViewModel.EmpresaStruct.Endereco_nome = empresa.Endereco_nome;
            //certidaoViewModel.EmpresaStruct.Numero = empresa.Numero;
            //certidaoViewModel.EmpresaStruct.Complemento = empresa.Complemento;
            //certidaoViewModel.EmpresaStruct.Bairro_nome = empresa.Bairro_nome;
            //certidaoViewModel.EmpresaStruct.Cidade_nome = empresa.Cidade_nome;
            //certidaoViewModel.EmpresaStruct.UF = empresa.UF;
            //certidaoViewModel.EmpresaStruct.Cep = empresa.Cep;
            //certidaoViewModel.EmpresaStruct.Atividade_extenso = empresa.Atividade_extenso;
            //List<CnaeStruct> ListaCnae = _empresaRepository.Lista_Cnae_Empresa(_codigo);
            //string sCnae = "",sCnae2="";
            //foreach (CnaeStruct cnae in ListaCnae) {
            //    if (cnae.Principal)
            //        sCnae = cnae.CNAE + "-" + cnae.Descricao;
            //    else
            //        sCnae2 += cnae.CNAE + "-" + cnae.Descricao + System.Environment.NewLine;
            //}
            //certidaoViewModel.Cnae_Principal = sCnae;
            //certidaoViewModel.Cnae_Secundario = sCnae2;

            return View(certidaoViewModel);
        }



    }
}





