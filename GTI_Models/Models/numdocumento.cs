using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Numdocumento {
        [Key]
        public int numdocumento { get; set; }
        public DateTime? Datadocumento { get; set; }
        public short? Codbanco { get; set; }
        public string Agencia { get; set; }
        public decimal? Valorpago { get; set; }
        public decimal? Valortaxadoc { get; set; }
        public byte? Isentomj { get; set; }
        public decimal? Percisencao { get; set; }
        public short? Tipodoc { get; set; }
        public string Emissor { get; set; }
        public decimal? Valorguia { get; set; }
        public bool? Registrado { get; set; }
    }
}
