using System;
using System.Collections.Generic;
using GTI_Models.Models;
using GTI_Dal.Classes;

namespace GTI_Bll.Classes {
    public class Tributario_bll {

        private string _connection;

        public Tributario_bll(string sConnection) {
            _connection = sConnection;
        }

        ///<summary> Retorna o dígito verificador de um númerode documento.
        ///</summary>
        public int DvDocumento(int Numero) {
            string sFromN = Numero.ToString("00000000");
            int nTotPosAtual = 0;

            nTotPosAtual = Convert.ToInt32(sFromN.Substring(0, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(1, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(2, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(3, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(4, 1)) * 3;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(5, 1)) * 9;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(6, 1)) * 7;
            nTotPosAtual += Convert.ToInt32(sFromN.Substring(7, 1)) * 3;

            string ret = nTotPosAtual.ToString();
            return Convert.ToInt32(ret.Substring(ret.Length - 1));

        }

        ///<summary> Retorna a lista dos lançamentos cadastrados.///</summary>
        public List<Lancamento> Lista_Lancamento() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Lancamento();
        }

        ///<summary> Retorna a lista dos tributos cadastrados.
        ///</summary>
        public List<Tributo> Lista_Tributo() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tributo();
        }

        ///<summary> Retorna a lista dos tipos de livros cadastrados.
        ///</summary>
        public List<Tipolivro> Lista_Tipo_Livro() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tipo_Livro();
        }

        ///<summary> Incluir lancamento na tela de cadastro de lançamentos.
        ///</summary>
        public Exception Incluir_Lancamento(Lancamento reg) {
            Exception AppEx ;
            if (String.IsNullOrWhiteSpace(reg.Descfull)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Descreduz)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (reg.Tipolivro==null||reg.Tipolivro==0|| reg.Tipolivro==-1) {
                AppEx = new Exception("Selecione o tipo de livro.");
                return AppEx;
            }
            if (Existe_Lancamento(reg)) {
                AppEx = new Exception("Já existe um lançamento com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Incluir_Lancamento(reg);
            return ex;
        }

        ///<summary> Incluir tributo na tela de cadastro de tributos.
        ///</summary>
        public Exception Incluir_Tributo(Tributo reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Desctributo)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Abrevtributo)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (Existe_Tributo(reg)) {
                AppEx = new Exception("Já existe um tributo com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Incluir_Tributo(reg);
            return ex;
        }

        ///<summary> Alterar lancamento na tela de cadastro de lançamentos.
        ///</summary>
        public Exception Alterar_Lancamento(Lancamento reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Descfull)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Descreduz)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (reg.Tipolivro == null || reg.Tipolivro == 0 || reg.Tipolivro == -1) {
                AppEx = new Exception("Selecione o tipo de livro.");
                return AppEx;
            }
            if (Existe_Lancamento(reg,false)) {
                AppEx = new Exception("Já existe um lançamento com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Lancamento(reg);
            return ex;
        }

        ///<summary> Alterar tributo na tela de cadastro de tributos.
        ///</summary>
        public Exception Alterar_Tributo(Tributo reg) {
            Exception AppEx;
            if (String.IsNullOrWhiteSpace(reg.Desctributo)) {
                AppEx = new Exception("Digite a descrição completa");
                return AppEx;
            }
            if (String.IsNullOrWhiteSpace(reg.Desctributo)) {
                AppEx = new Exception("Digite a descrição resumida");
                return AppEx;
            }
            if (Existe_Tributo(reg, false)) {
                AppEx = new Exception("Já existe um tributo com esta descrição.");
                return AppEx;
            }

            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Tributo(reg);
            return ex;
        }

        ///<summary> Verifica se já existe um lancamento com esta descrição
        ///</summary>
        public bool Existe_Lancamento(Lancamento reg, bool novo = true) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Lancamento(reg, novo);
        }

        ///<summary> Verifica se já existe um tributo com esta descrição
        ///</summary>
        public bool Existe_Tributo(Tributo reg, bool novo = true) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Tributo(reg, novo);
        }

        ///<summary> Excluir lancamento na tela de cadastro de lançamentos.
        ///</summary>
        public Exception Excluir_Lancamento(Lancamento reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = Lancamento_em_uso(reg.Codlancamento);
            if (ex == null)
                ex = obj.Excluir_Lancamento(reg);
            return ex;
        }

        ///<summary> Excluir tributo na tela de cadastro de tributos.
        ///</summary>
        public Exception Excluir_Tributo(Tributo reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = Tributo_em_uso(reg.Codtributo);
            if (ex == null)
                ex = obj.Excluir_Tributo(reg);
            return ex;
        }

        ///<summary> Verifica se o lançamento esta sendo utilizado no sistema.
        ///</summary>
        private Exception Lancamento_em_uso(int codigo_lancamento) {
            Exception AppEx = null;
            Tributario_Data obj = new Tributario_Data(_connection);
            bool bdebitoparcela = obj.Lancamento_uso_debito(codigo_lancamento);
            if (bdebitoparcela)
                AppEx = new Exception("Exclusão não permitida. Lançamento em uso - Débitos.");
            else {
                bool btributolançamento = obj.Lancamento_uso_tributo(codigo_lancamento);
                if (btributolançamento)
                    AppEx = new Exception("Exclusão não permitida. Lançamento com tributos cadastrados.");
            }
            return AppEx;
        }

        ///<summary> Verifica se o tributo esta sendo utilizado no sistema.
        ///</summary>
        private Exception Tributo_em_uso(int codigo_tributo) {
            Exception AppEx = null;
            Tributario_Data obj = new Tributario_Data(_connection);
            bool bdebitotributo = obj.Tributo_uso_debito(codigo_tributo);
            if (bdebitotributo)
                AppEx = new Exception("Exclusão não permitida. Tributo em uso - Débitos.");
            else {
                bool btributolançamento = obj.Tributo_uso_lancamento(codigo_tributo);
                if (btributolançamento)
                    AppEx = new Exception("Exclusão não permitida. Tributo em uso - Lançamentos.");
                else {
                    bool btributoaliquota = obj.Tributo_uso_aliquota(codigo_tributo);
                    if (btributoaliquota)
                        AppEx = new Exception("Exclusão não permitida. Tributo em uso - Aliquotas.");
                }
            }
            return AppEx;
        }

        ///<summary> Retorna todas as linhas da spExtratoNew
        ///</summary>
        public List<SpExtrato> Lista_Extrato_Tributo(int Codigo=3, short Ano1 = 1990, short Ano2 = 2050, short Lancamento1 = 1, short Lancamento2 = 99, short Sequencia1 = 0, short Sequencia2 = 9999,
            short Parcela1 = 0, short Parcela2 = 999, short Complemento1 = 0, short Complemento2 = 999, short Status1 = 0, short Status2 = 99, DateTime? Data_Atualizacao = null, string Usuario = "") {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Extrato_Tributo(Codigo,Ano1,Ano2,Lancamento1,Lancamento2,Sequencia1,Sequencia2,Parcela1,Parcela2,Complemento1,Complemento2,Status1,Status2,Data_Atualizacao,Usuario);
        }

        ///<summary> Agrupa as linhas da spExtratoNew por parcela
        ///</summary>
        public List<SpExtrato> Lista_Extrato_Parcela(List<SpExtrato> Lista_Debito) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Extrato_Parcela(Lista_Debito);
        }

        ///<summary> Retorna os tipos de status dos lançamentos
        ///</summary>
        public List<Situacaolancamento> Lista_Status() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Status();
        }

        ///<summary> Retorna a taxa de expediente de um lançamento
        ///</summary>
        public double Retorna_Taxa_Expediente(int codigo, short ano, short lancamento, short sequencia, short parcela, short complemento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Taxa_Expediente( codigo,  ano,  lancamento, sequencia,  parcela, complemento);
        }

        ///<summary> Retorna a lista com todas as observações das parcelas de um código
        ///</summary>
        public List<ObsparcelaStruct> Lista_Observacao_Parcela(int codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Observacao_Parcela(codigo);
        }

        ///<summary> Incluir uma nova observação na parcela
        ///</summary>
        public Exception Incluir_Observacao_Parcela(Obsparcela reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Incluir_Observacao_Parcela(reg);
            return ex;
        }

        ///<summary> Alterar uma observação na parcela cadastrada
        ///</summary>
        public Exception Alterar_Observacao_Parcela(Obsparcela reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Observacao_Parcela(reg);
            return ex;
        }

        ///<summary> Retorna a última sequência de uma observação de parcela
        ///</summary>
        public short Retorna_Ultima_Seq_Observacao_Parcela(int Codigo, int Ano, short Lanc, short Sequencia, short Parcela, short Complemento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Seq_Observacao_Parcela(Codigo,Ano,Lanc,Sequencia,Parcela,Complemento);
        }

        ///<summary> Excluir uma observação de parcela
        ///</summary>
        public Exception Excluir_Observacao_Parcela(Obsparcela reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex  = obj.Excluir_Observacao_Parcela(reg);
            return ex;
        }

        ///<summary> Retorna a lista com todas as observações de um código
        ///</summary>
        public List<DebitoobservacaoStruct> Lista_Observacao_Codigo(int codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Observacao_Codigo(codigo);
        }

        ///<summary> Incluir uma nova observação no código
        ///</summary>
        public Exception Incluir_Observacao_Codigo(Debitoobservacao reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Incluir_Observacao_Codigo(reg);
            return ex;
        }

        ///<summary> Retorna a última sequência de uma observação de um contribuinte
        ///</summary>
        public short Retorna_Ultima_Seq_Observacao_Codigo(int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Ultima_Seq_Observacao_Codigo(Codigo);
        }

        ///<summary> Alterar uma observação de um código
        ///</summary>
        public Exception Alterar_Observacao_Codigo(Debitoobservacao reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Alterar_Observacao_Codigo(reg);
            return ex;
        }

        ///<summary> Excluir uma observação de um código
        ///</summary>
        public Exception Excluir_Observacao_Codigo(int Codigo, short Seq) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Excluir_Observacao_Codigo(Codigo,Seq);
            return ex;
        }

        ///<summary> Retorna a lista de documentos de uma parcela
        ///</summary>
        public List<Numdocumento> Lista_Parcela_Documentos(Parceladocumento reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcela_Documentos(reg);
        }


    }//end class
}
