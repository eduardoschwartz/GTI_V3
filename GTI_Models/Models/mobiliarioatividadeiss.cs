using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GTI_Models.Models {
    public class Mobiliarioatividadeiss {
        [Key]
        [Column(Order = 1)]
        public int Codmobiliario { get; set; }
        [Key]
        [Column(Order = 2)]
        public short Codtributo { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Codatividade { get; set; }
        [Key]
        [Column(Order = 4)]
        public byte Seq { get; set; }
        public short Qtdeiss { get; set; }
        public decimal Valoriss { get; set; }
    }
}