using System;
using System.Collections.Generic;
using GTI_Models.Models;
using GTI_Dal.Classes;
using GTI_Bll.Classes;

namespace GTI_Bll.Classes {
    public class Imovel_bll {
        private string _connection;

        public Imovel_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>
        /// Retorna os dados de um imóvel
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public ImovelStruct Dados_Imovel(int nCodigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_Imovel(nCodigo);
        }

        public List<ProprietarioStruct> Lista_Proprietario(int CodigoImovel, bool Principal = false) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Proprietario(CodigoImovel,Principal);
        }

        public List<LogradouroStruct> Lista_Logradouro(String Filter = "") {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Logradouro(Filter);
        }

        public bool Existe_Imovel(int nCodigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Existe_Imovel(nCodigo);
        }

        public EnderecoStruct Dados_Endereco(int Codigo, bllCore.TipoEndereco Tipo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_Endereco(Codigo,(dalCore.TipoEndereco)Tipo);
        }

        public List<Categprop> Lista_Categoria_Propriedade() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Categoria_Propriedade();
        }

        public List<Topografia> Lista_Topografia() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Topografia();
        }

        public List<Situacao> Lista_Situacao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Situacao();
        }

        public List<Benfeitoria> Lista_Benfeitoria() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Benfeitoria();
        }

        public List<Pedologia> Lista_Pedologia() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Pedologia();
        }

        public List<Usoterreno> Lista_uso_terreno() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Uso_Terreno();
        }

        public List<Testada> Lista_Testada(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Testada(Codigo);
        }

        public List<AreaStruct> Lista_Area(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Area(Codigo);
        }

        public List<Usoconstr> Lista_Uso_Construcao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Uso_Construcao();
        }

        public List<Categconstr> Lista_Categoria_Construcao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Categoria_Construcao();
        }

        public List<Tipoconstr> Lista_Tipo_Construcao() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Tipo_Construcao();
        }

        ///<summary> Retorna os dados de um condomínio
        ///</summary>
        public CondominioStruct Dados_Condominio(int nCodigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_Condominio(nCodigo);
        }

        ///<summary> Retorna a lista das áreas de um condomínio
        ///</summary>
        public List<AreaStruct> Lista_Area_Condominio(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Area_Condominio(Codigo);
        }

        /// <summary>
        /// Retorna a inscrição cadastral completa do imóvel
        /// </summary>
        /// <param name="Logradouro"></param>
        /// <param name="Numero"></param>
        /// <returns></returns>
        public ImovelStruct Inscricao_imovel(int Logradouro, short Numero) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Inscricao_imovel(Logradouro,Numero);
        }

        /// <summary>
        /// Lista dos condomínios cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Condominio> Lista_Condominio() {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Condominio();
        }

        /// <summary>
        /// Lista das testadas do condomínio
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Testadacondominio> Lista_Testada_Condominio(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Testada_Condominio(Codigo);
        }


        /// <summary>
        /// Lista das unidades do condomínio
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<Condominiounidade> Lista_Unidade_Condominio(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Unidade_Condominio(Codigo);
        }

        /// <summary>
        /// Retorna a Lista dos imóveis filtrados
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public List<ImovelStruct> Lista_Imovel(ImovelStruct Reg) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Imovel(Reg);
        }

        /// <summary>
        /// Retorna os dados de IPTU de um imóvel em um ano
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public Laseriptu Dados_IPTU(int Codigo, int Ano) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Dados_IPTU(Codigo, Ano);
        }

        /// <summary>
        /// Soma das áreas construidas do imóvel
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public decimal Soma_Area(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Soma_Area(Codigo);
        }

        /// <summary>
        /// Retorna a quantidade de imóveis que um contribuinte possui como proprietário
        /// </summary>
        /// <param name="CodigoImovel"></param>
        /// <returns></returns>
        public int Qtde_Imovel_Cidadao(int CodigoImovel) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Qtde_Imovel_Cidadao(CodigoImovel);
        }

        /// <summary>
        /// Retorna verdadeiro se o imóvel for imune e falso se não for
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public bool Verifica_Imunidade(int Codigo) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Verifica_Imunidade(Codigo);
        }

        /// <summary>
        /// Retorna a lista de isenções de um imóvel, caso o ano for especificado retorna apenas a isenção do ano.
        /// </summary>
        /// <param name="Codigo"></param>
        /// <param name="Ano"></param>
        /// <returns></returns>
        public List<IsencaoStruct> Lista_Imovel_Isencao(int Codigo, int Ano = 0) {
            Imovel_Data obj = new Imovel_Data(_connection);
            return obj.Lista_Imovel_Isencao(Codigo,Ano);
        }

    }//end class
}
