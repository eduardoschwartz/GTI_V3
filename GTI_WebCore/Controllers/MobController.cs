using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GTI_WebCore.Controllers {

    [Route("Mob/Details")]
    public class MobController : Controller {
        private readonly IEmpresaRepository _empresaRepository;

        public MobController(IEmpresaRepository empresaRepository) {
            _empresaRepository = empresaRepository;
        }

        [HttpGet]
        public ViewResult Details() {
            return View();
        }

        [HttpPost]
        public ViewResult Details(EmpresaDetailsViewModel model) {
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel();
            bool _existeCod = _empresaRepository.Existe_Empresa_Codigo(Convert.ToInt32(model.Inscricao));

            if (_existeCod) {
                Mobiliario mobiliario = _empresaRepository.GetEmpresaDetail(Convert.ToInt32(model.Inscricao));
                empresaDetailsViewModel.Mobiliario = mobiliario;
                empresaDetailsViewModel.ErrorMessage = "";
            } else {
                empresaDetailsViewModel.ErrorMessage = "Empresa não cadastrada.";
            }
            return View(empresaDetailsViewModel);
        }


    }
}