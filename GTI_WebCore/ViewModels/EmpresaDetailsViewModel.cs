using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.ViewModels {
    public class EmpresaDetailsViewModel {
        public Mobiliario Mobiliario { get; set; }
        [Display(Name = "Inscrição Municipal")]
        public string Inscricao { get; set; }
        public string CpfCnpjLabel { get; set; }
        public string CpfValue { get; set; }
        public string CnpjValue { get; set; }
        public string ErrorMessage { get; set; }
    }
}
