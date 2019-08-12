using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace GTI_WebCore.Controllers {
    [Route("Imovel/Certidao_Endereco")]
    public class ImovelController : Controller{
        private readonly IImovelRepository _imovelRepository;

        public ImovelController(IImovelRepository imovelRepository) {
            _imovelRepository = imovelRepository;
        }

        [HttpGet]
        public ViewResult Certidao_Endereco() {
            return View();
        }

        [HttpPost]
        public ViewResult Certidao_Endereco(CertidaoViewModel model) {
            int _codigo = 0;
            bool _existeCod = false;
            CertidaoViewModel empresaDetailsViewModel = new CertidaoViewModel();

            if (model.Inscricao != null) {
                _codigo = Convert.ToInt32(model.Inscricao);
                if (_codigo < 100000) //Se estiver fora deste intervalo nem precisa checar se o imóvel existe
                    _existeCod = _imovelRepository.Existe_Imovel(_codigo);
            } 

            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                empresaDetailsViewModel.ErrorMessage = "Código de verificação inválido.";
                return View(empresaDetailsViewModel);
            }


            if (_existeCod) {
                ImovelStruct imovel = _imovelRepository.Dados_Empresa(_codigo);
                empresaDetailsViewModel.ImovelStruct = imovel;
                empresaDetailsViewModel.ErrorMessage = "";
                return View("DetailsTable", empresaDetailsViewModel);
            } else {
                empresaDetailsViewModel.ErrorMessage = "Imóvel não cadastrado.";
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