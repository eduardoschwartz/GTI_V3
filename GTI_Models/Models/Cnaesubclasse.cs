using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Cnaesubclasse {
        [Key]
        [Column(Order = 1)]
        public string Secao { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Divisao { get; set; }
        [Key]
        [Column(Order = 3)]
        public int Grupo { get; set; }
        [Key]
        [Column(Order = 4)]
        public int Classe { get; set; }
        [Key]
        [Column(Order = 5)]
        public int Subclasse { get; set; }
        public string Descricao { get; set; }
    }
}
