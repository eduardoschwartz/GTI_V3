using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTI_WebCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}