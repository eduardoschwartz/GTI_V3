using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GTI_WebCore.Models;
using GTI_WebCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GTI_WebCore.Controllers
{
    public class HomeController : Controller    {
        private readonly IEmpresaRepository _empresaRepository;

        public HomeController(IEmpresaRepository empresaRepository) {
            _empresaRepository = empresaRepository;

        }

        public string Index()
        {
           return _empresaRepository.GetEmpresaDetail(100090).Razaosocial;
        }

        public ViewResult Details(int? id) {
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel() {
                Mobiliario = _empresaRepository.GetEmpresaDetail(id ??1),
                PageTitle = "Detalhe da Empresa"
            };

            return View(empresaDetailsViewModel);
        }



    }
}