using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTI_WebCore.Interfaces;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GTI_WebCore.Controllers{

    [Route("Mob/Details")]
    public class MobController : Controller{
        private readonly IEmpresaRepository _empresaRepository;

        public MobController(IEmpresaRepository empresaRepository) {
            _empresaRepository = empresaRepository;
        }

        [HttpGet]
        public ViewResult Details() {
            return View();
        }

        [HttpPost]
        public ViewResult Details(int? id) {
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel() {
//                Mobiliario = _empresaRepository.GetEmpresaDetail((int)id)
            };

            return View(empresaDetailsViewModel);
        }

    }
}