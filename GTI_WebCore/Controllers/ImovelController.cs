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

    [Route("Imovel/Certidao")]
    public class ImovelController : Controller{
        private readonly IImovelRepository _imovelRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ITributarioRepository tributarioRepository;

        public ImovelController(IImovelRepository imovelRepository, IHostingEnvironment hostingEnvironment,ITributarioRepository tributarioRepository) {
            _imovelRepository = imovelRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.tributarioRepository = tributarioRepository;
        }

        [Route("Certidao_Endereco")]
        [HttpGet]
        public ViewResult Certidao_Endereco() {
            return View();
        }

        [Route("Certidao_Endereco")]
        [HttpPost]
        public IActionResult Certidao_Endereco(CertidaoViewModel model) {
            int _codigo = 0,_ano=0;
            int _numero = tributarioRepository.Retorna_Codigo_Certidao(Functions.TipoCertidao.Endereco);
            bool _existeCod = false,_Valida=false;
            string _chave = model.Chave;
            CertidaoViewModel certidaoViewModel = new CertidaoViewModel();
            ViewBag.Result = "";

            if (!string.IsNullOrWhiteSpace(_chave)) {
                chaveStruct _chaveStruct = tributarioRepository.Valida_Certidao(_chave);
                if (!_chaveStruct.Valido) {
                    ViewBag.Result = "Chave de autenticação da certidão inválida.";
                    return View(certidaoViewModel);
                } else {
                    _codigo = _chaveStruct.Codigo;
                    _numero = _chaveStruct.Numero;
                    _ano = _chaveStruct.Ano;
                    

                    _Valida = true;
                }
            } else {
                if (model.Inscricao != null) {
                    _codigo = Convert.ToInt32(model.Inscricao);
                    if (_codigo < 100000)
                        _existeCod = _imovelRepository.Existe_Imovel(_codigo);
                }
            }

            if (!Captcha.ValidateCaptchaCode(model.CaptchaCode, HttpContext)) {
                ViewBag.Result = "Código de verificação inválido.";
                return View(certidaoViewModel);
            }

            if (!_existeCod && !_Valida) {
                ViewBag.Result = "Imóvel não cadastrado.";
                return View(certidaoViewModel);
            }
            
            List<Certidao> certidao = new List<Certidao>();
            List<ProprietarioStruct> listaProp = _imovelRepository.Lista_Proprietario(_codigo, true);
            ImovelStruct _dados = _imovelRepository.Dados_Imovel(_codigo);
            Certidao reg = new Certidao() {
                Codigo = _dados.Codigo,
                Inscricao = _dados.Inscricao,
                Endereco = _dados.NomeLogradouro,
                Endereco_Numero= (int)_dados.Numero,
                Endereco_Complemento=_dados.Complemento,
                Bairro = _dados.NomeBairro ?? "",
                Nome_Requerente = listaProp[0].Nome,
                Ano = DateTime.Now.Year,
                Numero = _numero,
                Quadra_Original = _dados.QuadraOriginal ?? "",
                Lote_Original = _dados.LoteOriginal ?? "",
                Controle = _numero.ToString("00000") + DateTime.Now.Year.ToString("0000") + "/" + _codigo.ToString() + "-EA"
            };

            if (_Valida) {
                reg.Codigo = _codigo;
                reg.Ano = _ano;
                reg.Numero = _numero;
                Certidao_endereco certidaoGerada = tributarioRepository.Retorna_Certidao_Endereco(_ano, _numero, _codigo);
                reg.Endereco = certidaoGerada.Logradouro;
                reg.Endereco_Numero = certidaoGerada.Li_num;
                reg.Endereco_Complemento = certidaoGerada.Li_compl??"";
                reg.Bairro = certidaoGerada.descbairro;
                reg.Nome_Requerente = certidaoGerada.Nomecidadao;
                reg.Data_Geracao = certidaoGerada.Data;
                reg.Inscricao = certidaoGerada.Inscricao;
            }
            reg.Numero_Ano = reg.Numero.ToString("00000") + "/" + reg.Ano;
            certidao.Add(reg);

            if (!_Valida) {
                Models.Certidao_endereco regCert = new Certidao_endereco() {
                    Ano=reg.Ano,
                    Codigo=reg.Codigo,
                    Data=DateTime.Now,
                    descbairro=reg.Bairro,
                    Inscricao=reg.Inscricao,
                    Logradouro=reg.Endereco,
                    Nomecidadao=reg.Nome_Requerente,
                    Li_lotes=reg.Lote_Original,
                    Li_compl=reg.Endereco_Complemento,
                    Li_num=reg.Endereco_Numero,
                    Li_quadras=reg.Quadra_Original,
                    Numero=reg.Numero
                };
                Exception ex = tributarioRepository.Insert_Certidao_Endereco(regCert);
                if (ex != null) {
                    ViewBag.Result = "Ocorreu um erro no processamento das informações.";
                    return View(certidaoViewModel);
                }
            }

            ReportDocument rd = new ReportDocument();
            if(_Valida)
                rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Certidao_Endereco_Valida.rpt");
            else
                rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Certidao_Endereco.rpt");

            try {
                rd.SetDataSource(certidao);
                Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                return File(stream, "application/pdf", "Certidao_Endereco.pdf");
            } catch {

                throw;
            }

        }

       
        [Route("Certidao_Valor_Venal")]
        [HttpGet]
        public ViewResult Certidao_Valor_Venal() {
            return View();
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