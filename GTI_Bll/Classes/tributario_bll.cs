using System;
using System.Collections.Generic;
using GTI_Models.Models;
using GTI_Dal.Classes;
using GTI_Models;
using static GTI_Models.modelCore;

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
        public List<Tributo> Lista_Tributo(int Codigo=0) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tributo(Codigo);
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

        /// <summary>
        /// Lista tabela parceladocumento
        /// </summary>
        /// <param name="nNumdocumento"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Tabela_Parcela_Documento(int nNumdocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Tabela_Parcela_Documento(nNumdocumento);
        }

        /// <summary>
        /// Insere na tabela boletoguia
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Boleto_Guia(Boletoguia Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Boleto_Guia(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela segunda_via_web
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Numero_Segunda_Via(Segunda_via_web Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Numero_Segunda_Via(Reg);
            return ex;
        }


        /// <summary>
        /// Lista a tabela boletoguia
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public List<Boletoguia> Lista_Boleto_Guia(int nSid) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Boleto_Guia(nSid);
        }

        /// <summary>
        /// Parcelas da CIP para impressão na Web
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_CIP(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_CIP(nCodigo,nAno);
        }

        /// <summary>
        /// Parcelas de IPTU para impressão na Web
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public List<DebitoStructure> Lista_Parcelas_IPTU(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Parcelas_IPTU(nCodigo, nAno);
        }

        /// <summary>
        /// Prepara os dados para imprimir o carnê na web
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public Exception Insert_Carne_Web(int Codigo, int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Carne_Web(Codigo, Ano);
            return ex;
        }

        /// <summary>
        /// Apaga os dados temporários do carnê na web
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public Exception Excluir_Carne(int nSid) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Excluir_Carne(nSid);
            return ex;
        }

        /// <summary>
        /// Carrega os dados de IPTU de um código no ano informado
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <param name="nAno"></param>
        /// <returns></returns>
        public Laseriptu Carrega_Dados_IPTU(int nCodigo, int nAno) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Carrega_Dados_IPTU(nCodigo, nAno);
        }

        /// <summary>
        /// Pesquisa o endereço de um terreno lançado na CIP 
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public bool Existe_Documento_CIP(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Documento_CIP(nNumDocumento);
        }

        /// <summary>
        /// Retorna o código reduzido associado a um documento
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public int Retorna_Codigo_por_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Codigo_por_Documento(nNumDocumento);
        }

        /// <summary>
        /// Retorna verdadeiro se o Refis esta ativo
        /// </summary>
        /// <returns></returns>
        public bool IsRefis() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.IsRefis();
        }

        /// <summary>
        /// Retorna verdadeiro se o Refis do Distrito Industrial esta ativo
        /// </summary>
        /// <returns></returns>
        public bool IsRefisDI() {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.IsRefisDI();
        }

        /// <summary>
        /// Grava um novo documento
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public int Insert_Documento(Numdocumento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Insert_Documento(Reg);
        }

        /// <summary>
        /// Grava na tabela parceladocumento
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Parcela_Documento(Parceladocumento Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Parcela_Documento(Reg);
            return ex;
        }

        /// <summary>
        /// Envia os débitos para serem impressos na DAM
        /// </summary>
        /// <param name="lstDebito"></param>
        /// <param name="nNumDoc"></param>
        /// <param name="DataBoleto"></param>
        /// <returns></returns>
        public Int32 Insert_Boleto_DAM(List<DebitoStructure> lstDebito, Int32 nNumDoc, DateTime DataBoleto) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Insert_Boleto_DAM(lstDebito,nNumDoc,DataBoleto);
        }

        /// <summary>
        /// Lista a tabela boleto
        /// </summary>
        /// <param name="nSid"></param>
        /// <returns></returns>
        public List<Boleto> Lista_Boleto_DAM(int nSid) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Lista_Boleto_DAM(nSid);
        }

        /// <summary>
        /// Verifica se o documento informado já foi gerado pelo comércio eletrônico
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public bool Existe_Comercio_Eletronico(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Comercio_Eletronico(nNumDocumento);
        }

        /// <summary>
        /// Grava na tabela comercio_eletronico
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Boleto_Comercio_Eletronico(comercio_eletronico Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Boleto_Comercio_Eletronico(Reg);
            return ex;
        }

        /// <summary>
        /// Verifica a existência de um número de documento
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public bool Existe_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Existe_Documento(nNumDocumento);
        }

        /// <summary>
        /// Retorna o cadastro de um documento
        /// </summary>
        /// <param name="nNumDocumento"></param>
        /// <returns></returns>
        public Numdocumento Retorna_Dados_Documento(int nNumDocumento) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Dados_Documento(nNumDocumento);
        }

        /// <summary>
        /// Retorna o próximo código da certidão requerida e incrementa a sequência
        /// </summary>
        /// <param name="tipo_certidao"></param>
        /// <returns></returns>
        public int Retorna_Codigo_Certidao(modelCore.TipoCertidao tipo_certidao) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Codigo_Certidao(tipo_certidao);
        }

        /// <summary>
        /// Insere na tabela certidaoenderecoatualizado
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Endereco(Certidao_endereco Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Endereco(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna os dados da certidão de endereço
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Endereco(Ano,Numero,Codigo);
        }

        /// <summary>
        /// Retorna os dados da certidão de valor venal
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_valor_venal Retorna_Certidao_ValorVenal(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_ValorVenal(Ano, Numero, Codigo);
        }

        /// <summary>
        /// Retorna os dados da certdão de isenção
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Isencao(Ano, Numero, Codigo);
        }

        /// <summary>
        /// Retorna os dados da certidão de débitos
        /// </summary>
        /// <param name="Ano"></param>
        /// <param name="Numero"></param>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_debito Retorna_Certidao_Debito(int Ano, int Numero, int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Retorna_Certidao_Debito(Ano, Numero, Codigo);
        }

        /// <summary>
        /// Insere na tabela certidao_valor_venal
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_ValorVenal(Certidao_valor_venal Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_ValorVenal(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_isencao
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Isencao(Certidao_isencao Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Isencao(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_inscricao
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Inscricao(Certidao_inscricao Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Inscricao(Reg);
            return ex;
        }

        /// <summary>
        /// Insere na tabela certidao_debito
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Certidao_Debito(Certidao_debito Reg) {
            Tributario_Data obj = new Tributario_Data(_connection);
            Exception ex = obj.Insert_Certidao_Debito(Reg);
            return ex;
        }

        /// <summary>
        /// Retorna as infomações para a certidão de débitos
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public Certidao_debito_detalhe Certidao_Debito(int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Certidao_Debito( Codigo);
        }

        /// <summary>
        /// Retorna o cálculo de IPTU do ano especificado
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public SpCalculo Calculo_IPTU(int Codigo, int Ano) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Calculo_IPTU(Codigo,Ano);
        }

        /// <summary>
        /// Retorna a lista das competências pagas de ISS
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<CompetenciaISS> Resumo_CompetenciaISS(int Codigo) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Resumo_CompetenciaISS(Codigo);
        }

        /// <summary>
        /// Retorna a qtde meses nas quais a compet~encia não foi encerrada
        /// </summary>
        /// <param name="Lista"></param>
        /// <returns></returns>
        public int Competencias_Nao_Encerradas(List<CompetenciaISS> Lista) {
            Tributario_Data obj = new Tributario_Data(_connection);
            return obj.Competencias_Nao_Encerradas(Lista);
        }

    }//end class
}
