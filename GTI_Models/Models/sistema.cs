

using System;

namespace GTI_Models.Models {
    public class Sistema {
    }

    public class Contribuinte_Header_Struct {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf_cnpj { get; set; }
        public string Inscricao { get; set; }
        public string Endereco { get; set; }
        public short Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public string Nome_bairro { get; set; }
        public string Nome_cidade { get; set; }
        public string Nome_uf { get; set; }
        public string Quadra_original { get; set; }
        public string Lote_original { get; set; }
    }

    public class Report_Data {
        public string Numero_Certidao { get; set; }
        public string Controle { get; set; }
        public int? Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf_cnpj { get; set; }
        public string Inscricao { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Nome_bairro { get; set; }
        public string Nome_cidade { get; set; }
        public string Quadra_original { get; set; }
        public string Lote_original { get; set; }
        public string Atividade { get; set; }
        public string Tributos { get; set; }
        public string Processo_Isencao { get; set; }
        public DateTime? Data_Processo_Isencao { get; set; }
        public decimal? Perc_Isencao { get; set; }
        public int? AnoIsencao { get; set; }
        public string Processo { get; set; }
        public DateTime? Data_Processo { get; set; }
        public int? UserId { get; set; }
        public bool? Assinatura_Hide { get; set; }
        public decimal? Area { get; set; }
    }



}
