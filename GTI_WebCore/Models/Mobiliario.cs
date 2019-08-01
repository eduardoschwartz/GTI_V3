using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GTI_WebCore.Models {
    public class Mobiliario {
        [Key]
        public int Codigomob { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefantasia { get; set; }
        public int? Codlogradouro { get; set; }
        public short? Numero { get; set; }
        public string Complemento { get; set; }
        public short? Codbairro { get; set; }
        public short? Codcidade { get; set; }
        public string Siglauf { get; set; }
        public string Cep { get; set; }
        public string Homepage { get; set; }
        public short? Horario { get; set; }
        public DateTime Dataabertura { get; set; }
        public string Numprocesso { get; set; }
        public DateTime? Dataprocesso { get; set; }
        public DateTime? Dataencerramento { get; set; }
        public string Numprocencerramento { get; set; }
        public DateTime? Dataprocencerramento { get; set; }
        public string Inscestadual { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public short? Isencao { get; set; }
        public int? Codatividade { get; set; }
        public string Ativextenso { get; set; }
        public float? Areatl { get; set; }
        public byte? Codigoaliq { get; set; }
        public DateTime? Datainicialdesc { get; set; }
        public DateTime? Datafinaldesc { get; set; }
        public float? Percdesconto { get; set; }
        public float? Capitalsocial { get; set; }
        public string Nomeorgao { get; set; }
        public int? Codprofresp { get; set; }
        public string Numregistroresp { get; set; }
        public short? Qtdesocio { get; set; }
        public short? Qtdeempregado { get; set; }
        public short? Respcontabil { get; set; }
        public string Rgresp { get; set; }
        public string Orgaoemisresp { get; set; }
        public string Nomecontato { get; set; }
        public string Cargocontato { get; set; }
        public string Fonecontato { get; set; }
        public string Faxcontato { get; set; }
        public string Emailcontato { get; set; }
        public byte? Vistoria { get; set; }
        public short? Qtdeprof { get; set; }
        public string Rg { get; set; }
        public string Orgao { get; set; }
        public string Nomelogradouro { get; set; }
        public byte? Simples { get; set; }
        public byte? Regespecial { get; set; }
        public byte? Alvara { get; set; }
        public DateTime? Datasimples { get; set; }
        public byte? Isentotaxa { get; set; }
        public byte? Mei { get; set; }
        public string Horarioext { get; set; }
        public byte? Isseletro { get; set; }
        public DateTime? Dispensaiedata { get; set; }
        public string Dispensaieproc { get; set; }
        public DateTime? Dtalvaraprovisorio { get; set; }
        public string Senhaiss { get; set; }
        public byte? Insctemp { get; set; }
        public byte? Horas24 { get; set; }
        public byte? Isentoiss { get; set; }
        public byte? Bombonieri { get; set; }
        public byte? Emitenf { get; set; }
        public byte? Danfe { get; set; }
        public int? Imovel { get; set; }
        public string Sil { get; set; }
        public bool? Substituto_tributario_issqn { get; set; }
        public bool? Individual { get; set; }
        public string Ponto_agencia { get; set; }
        public bool? Cadastro_vre { get; set; }
        public bool? Liberado_vre { get; set; }
    }


}
