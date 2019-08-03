using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.ViewModels {
    public class EmpresaDetailsViewModel {
        [Display(Name = "Inscrição Municipal")]
        public int Inscricao { get; set; }
        public string CpfCnpjLabel { get; set; }
        public string CpfCnpjValue { get; set; }
    }
}
