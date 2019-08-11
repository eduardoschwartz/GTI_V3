﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using GTI_WebCore.Models.ReportModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace GTI_WebCore.Controllers {
    public class ReportController : Controller {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public ReportController(IEmpresaRepository empresaRepository, IHostingEnvironment hostingEnvironment) {
            _empresaRepository = empresaRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Empresa_Details_Report(int Id) {
            ReportDocument rd = new ReportDocument();
            rd.Load(hostingEnvironment.ContentRootPath + "\\Reports\\Empresa_Detalhe.rpt");
            List<Empresa_Detalhe> empresa = new List<Empresa_Detalhe>();
            EmpresaStruct _dados = _empresaRepository.Dados_Empresa(Id);
            Empresa_Detalhe reg = new Empresa_Detalhe() {
                Codigo = _dados.Codigo,
                Razao_Social = _dados.Razao_social,
                Cpf_Cnpj = _dados.Cpf_cnpj,
                Inscricao_Estadual = _dados.Inscricao_estadual,
                Endereco = _dados.Endereco_nome + ", " + _dados.Numero + " " + _dados.Complemento,
                Bairro=_dados.Bairro_nome??"",
                Cidade=_dados.Cidade_nome??"",
                Uf=_dados.UF??"",
                Data_Abertura=Convert.ToDateTime(_dados.Data_abertura).ToString("dd/MM/yyyy"),
                Data_Encerramento=_dados.Data_Encerramento==null?"":Convert.ToDateTime(_dados.Data_Encerramento).ToString("dd/MM/yyyy"),
                Atividade=_dados.Atividade_extenso,
                Situacao=_dados.Situacao,
                Cep=_dados.Cep??"",
                Area=_dados.Area==null?0:Convert.ToDecimal(_dados.Area),
                Email=_dados.Email_contato??"",
                Telefone=_dados.Fone_contato??"",
                Proprietario=_dados.prof_responsavel_nome
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