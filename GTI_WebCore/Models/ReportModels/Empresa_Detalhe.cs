using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models.ReportModels {
    public class Empresa_Detalhe {
        public int Codigo { get; set; }
        public string Razao_Social { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string Inscricao_Estadual { get; set; }
        public string Endereco { get; set; }
        public string Data_Abertura { get; set; }
        public string Data_Encerramento { get; set; }
        public string Atividade { get; set; }
    }
}
