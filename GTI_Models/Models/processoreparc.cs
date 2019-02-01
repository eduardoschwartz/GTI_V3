using System;
using System.ComponentModel.DataAnnotations;

namespace GTI_Models.Models {
    public class Processoreparc {
        [Key]
        public string Numprocesso { get; set; }
        public int? Numproc { get; set; }
        public short? Anoproc { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public DateTime? Datareparc { get; set; }
        public byte? Qtdeparcela { get; set; }
        public decimal? Valorentrada { get; set; }
        public decimal? Percentrada { get; set; }
        public bool? Calculamulta { get; set; }
        public bool? Calculajuros { get; set; }
        public bool? Calculacorrecao { get; set; }
        public bool? Penhora { get; set; }
        public bool? Honorario { get; set; }
        public int Codigoresp { get; set; }
        public string Funcionario { get; set; }
        public bool? Cancelado { get; set; }
        public DateTime? Datacancel { get; set; }
        public string Funcionariocancel { get; set; }
        public string Numprotocolo { get; set; }
        public string Plano { get; set; }
        public bool? Novo { get; set; }
        public DateTime? Data_exportacao { get; set; }
        public int? Userid { get; set; }
    }

    public class Processo_Numero {
        public string Numero_processo { get; set; }
        public int? Numero { get; set; }
        public short? Ano { get; set; }
    }

}
