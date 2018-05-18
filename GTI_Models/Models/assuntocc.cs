﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Assuntocc {
        [Key]
        [Column(Order = 1)]
        [Index("AssuntoLocal_Index", IsUnique = true, Order = 1)]
        public int Codassunto { get; set; }
        [Key]
        [Column(Order = 2)]
        [Index("AssuntoLocal_Index", IsUnique = true, Order = 2)]
        public int Seq { get; set; }
        public int Codcc { get; set; }

       // public List<processo_assunto> assuntos { get; set; }

    }
}
