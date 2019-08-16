using System;

namespace GTI_WebCore.Models.ReportModels {
    public class Certidao {
        public int Codigo { get; set; }
        public int Ano { get; set; }
        public int Numero { get; set; }
        public string Numero_Ano { get; set; }
        public string Inscricao { get; set; }
        public string Nome_Requerente { get; set; }
        public string Endereco { get; set; }
        public int Endereco_Numero { get; set; }
        public string Endereco_Complemento { get; set; }
        public string Bairro { get; set; }
        public string Quadra_Original { get; set; }
        public string Lote_Original { get; set; }
        public string Controle { get; set; }
        public DateTime Data_Geracao { get; set; }
        public decimal Area { get; set; }
        public decimal VVT { get; set; }
        public decimal VVP { get; set; }
        public decimal VVI { get; set; }
        public string Numero_Processo { get; set; }
        public DateTime Data_Processo { get; set; }
        public decimal Percentual_Isencao { get; set; }
    }
}
