

namespace GTI_Models {
    /// <summary>
    /// Classe que contêm os tipos utilizados no sistema
    /// </summary>
    public class modelCore {
        public enum TipoCertidao { Endereco, ValorVenal, Isencao, Debito }
        public enum TipoCadastro { Imovel, Empresa, Cidadao }
        public enum RetornoCertidaoDebito { Negativa, Positiva, NegativaPositiva}

        /// <summary>
        /// Lista de ítens de acesso de segurança
        /// </summary>
        public enum TAcesso {
            CadastroPais = 1,
            CadastroPais_Alterar=2,
            CadastroBairro = 3,
            CadastroBairro_Alterar_Fora=4,
            CadastroBairro_Alterar_Local=5,
            CadastroProfissao = 6,
            CadastroProfissao_Alterar=7,
            CadastroImovel = 8,
            CadastroImovel_Alterar_Total=9,
            CadastroImovel_Alterar_Historico=10,
            CadastroImovel_Inativar=11,
            CadastroFaceQuadra = 12,
            CadastroFaceQuadra_Alterar=13,
            CadastroCidadao = 14,
            CadastroCidadao_Alterar_Total=15,
            ExtratoContribuinte = 16,
            CadastroProcesso = 17,
            CadastroProcesso_Alterar_Basico=18,
            CadastroProcesso_Alterar_Avancado=19,
            CadastroProcesso_Tramitar=20,
            CadastroProcesso_Novo=21,
            CadastroImovel_Novo=22,
            CadastroCondominio=23,
            CadastroCondominio_Alterar=24
        }
    }

    public class CompetenciaISS {
        public int Codigo { get; set; }
        public int Ano_Competencia { get; set; }
        public int Mes_Competencia { get; set; }
        public bool Encerrada { get; set; }
        public bool Sem_Movimento { get; set; }
        public decimal Valor { get; set; }
    }


}
