using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Models.ReportModels {
    public class Certidao {
        public int Codigo { get; set; }
        public int Ano { get; set; }
        public int Numero { get; set; }
        public string Numero_Ano { get; set; }
        public string Inscricao { get; set; }
        public string Nome_Requerente { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Quadra_Original { get; set; }
        public string Lote_Original { get; set; }
        public string Controle { get; set; }
    }
}
