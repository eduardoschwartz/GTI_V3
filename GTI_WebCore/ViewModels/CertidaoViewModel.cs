using GTI_WebCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.ViewModels {
    public class CertidaoViewModel {
        public ImovelStruct ImovelStruct { get; set; }
        [Display(Name = "Inscrição Municipal")]
        public string Inscricao { get; set; }
        public bool CpfCheck { get; set; } 
        public bool CnpjCheck { get; set; } 
        public string CpfValue { get; set; }
        public string CnpjValue { get; set; }
        public string ErrorMessage { get; set; }
        [Required]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
        [Display(Name = "Chave de validação")]
        public string Chave { get; set; }
        public bool Extrato { get; set; }
    }
}
