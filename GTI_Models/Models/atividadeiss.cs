
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Atividadeiss {
        [Key]
        public int Codatividade { get; set; }
        public string Descatividade { get; set; }
        public string Item { get; set; }
        public byte? Isseletronico { get; set; }
        public string Retido { get; set; }
        public byte? Imprimir { get; set; }
    }
}
