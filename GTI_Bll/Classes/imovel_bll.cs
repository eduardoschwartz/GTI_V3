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


    }//end class
}
