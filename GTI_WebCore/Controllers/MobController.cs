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

            if (_existeCod) {
                Mobiliario mobiliario = _empresaRepository.GetEmpresaDetail(_codigo);
                empresaDetailsViewModel.Mobiliario = mobiliario;
                empresaDetailsViewModel.ErrorMessage = "";
            } else {
                empresaDetailsViewModel.ErrorMessage = "Empresa não cadastrada.";
            }
            return View(empresaDetailsViewModel);
        }


    }
}