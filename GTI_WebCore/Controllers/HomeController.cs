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
           return _empresaRepository.GetEmpresaDetail(2).Razao_Social;
        }

        public ViewResult Details() {
            EmpresaDetailsViewModel empresaDetailsViewModel = new EmpresaDetailsViewModel() {
                Empresa = _empresaRepository.GetEmpresaDetail(2),
                PageTitle = "Detalhe da Empresa"
            };
            Empresa model = _empresaRepository.GetEmpresaDetail(1);
            ViewData["PageTitle"] = "Dados da Empresa";
            return View(empresaDetailsViewModel);
        }



    }
}