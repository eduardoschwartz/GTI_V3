using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.Models.ReportModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GTI_WebCore.Controllers
{
    public class ReportController : Controller {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ReportController(IEmpresaRepository empresaRepository, IHostingEnvironment hostingEnvironment) {
            _empresaRepository = empresaRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Empresa_Details_Report(int Id) {
            ReportDocument rd = new ReportDocument();
            rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Teste.rpt");
            List<Empresa_Detalhe> empresa = new List<Empresa_Detalhe>();
            EmpresaStruct _dados = _empresaRepository.Dados_Empresa(Id);
            Empresa_Detalhe reg = new Empresa_Detalhe() {
                Codigo = _dados.Codigo,
                Razao_Social = _dados.Razao_social
            };
            empresa.Add(reg);
            try {
                rd.SetDataSource(empresa);
                Stream stream = rd.ExportToStream(ExportFormatType.PortableDocFormat);
                return File(stream, "application/pdf", "Relatorioteste.pdf");
            } catch {

                throw;
            }
        }

        

    }
}