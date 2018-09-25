using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Calculo_iss_vs {
        [Key]
        [Column(Order =1)]
        public short Ano { get; set; }
        public int Codigo { get; set; }
        public short Lancamento { get; set; }
        public byte Qtde_parcela { get; set; }
        public decimal? Valor0 { get; set; }
        public decimal? Valor1 { get; set; }
        public int? Documento0 { get; set; }
        public DateTime? Vencimento0 { get; set; }
        public int? Documento1 { get; set; }
        public DateTime? Vencimento1 { get; set; }
        public int? Documento2 { get; set; }
        public DateTime? Vencimento2 { get; set; }
        public int? Documento3 { get; set; }
        public DateTime? Vencimento3 { get; set; }
        public int? Documento4 { get; set; }
        public DateTime? Vencimento4 { get; set; }
    }
}
