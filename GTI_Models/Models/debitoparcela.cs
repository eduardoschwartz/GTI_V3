using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Debitoparcela {
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
        public byte Statuslanc { get; set; }
        public DateTime Datavencimento { get; set; }
        public DateTime Datadebase { get; set; }
        public short? Codmoeda { get; set; }
        public int? Numerolivro { get; set; }
        public int? Paginalivro { get; set; }
        public int? Numcertidao { get; set; }
        public DateTime? Datainscricao { get; set; }
        public DateTime? Dataajuiza { get; set; }
        public decimal Valorjuros { get; set; }
        public string Numprocesso { get; set; }
        public bool? Intacto { get; set; }
        public bool? Notificado { get; set; }
        public int? Numexecfiscal { get; set; }
        public short? Anoexecfiscal { get; set; }
        public string Processocnj { get; set; }
        public bool? Simplesnacional { get; set; }
        public int? Protesto_nro_titulo { get; set; }
        public short? Protesto_data_remessa { get; set; }
        public int Userid { get; set; }
    }
         
   


}
