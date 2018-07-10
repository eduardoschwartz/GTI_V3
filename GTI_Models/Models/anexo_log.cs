using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class anexo_log {
        [Key]
        public int Sid { get; set; }
        public short Ano { get; set; }
        public int Numero { get; set; }
        public short Ano_anexo { get; set; }
        public int Numero_anexo { get; set; }
        public bool Removido { get; set; }
        public DateTime Data { get; set; }
        public int Userid { get; set; }
    }
}
