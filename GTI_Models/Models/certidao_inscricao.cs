using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GTI_Models.Models {
    public class Certidao_inscricao {
        [Key]
        [Column(Order = 1)]
        public int Numero { get; set; }
        [Key]
        [Column(Order = 2)]
        public int Ano { get; set; }
        public DateTime? Data_emissao { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int Cadastro { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Documento { get; set; }
        public string Cidade { get; set; }
        public string Atividade { get; set; }
        public DateTime?  Data_abertura { get; set; }
        public string Processo_abertura { get; set; }
        public DateTime? Data_encerramento { get; set; }
        public string Processo_encerramento { get; set; }
    }
}
