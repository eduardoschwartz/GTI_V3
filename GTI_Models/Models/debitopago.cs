using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitopago {
        [Key]
        [Column(Order = 1)]
        public int Codreduzido { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Anoexercicio { get; set; }
        [Key]
        [Column(Order = 3)]
        public short Codlancamento { get; set; }
        [Key]
        [Column(Order = 4)]
        public short Seqlancamento { get; set; }
        [Key]
        [Column(Order = 5)]
        public byte Numparcela { get; set; }
        [Key]
        [Column(Order = 6)]
        public byte Codcomplemento { get; set; }
        [Key]
        [Column(Order = 7)]
        public byte Seqpag { get; set; }
        public DateTime Datapagamento { get; set; }
        public DateTime Datarecebimento { get; set; }
        public decimal Valorpago { get; set; }
        public short? Codbanco { get; set; }
        public int? Codagencia { get; set; }
        public DateTime? Restituido { get; set; }
        public int? Numdocumento { get; set; }
        public decimal? Valorpagoreal { get; set; }
        public bool? Intacto { get; set; }
        public decimal? Valortarifa { get; set; }
        public string Arquivobanco { get; set; }
        public decimal? Valordif { get; set; }
        public DateTime? Datapagamentocalc { get; set; }
        public DateTime? Dataintegracao { get; set; }
        public string Contacorrente { get; set; }
    }

    
}
