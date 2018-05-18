using GTI_Dal.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;

namespace GTI_Bll.Classes {
    public class Empresa_bll {
        private string _connection;
        public Empresa_bll(string sConnection) {
            _connection = sConnection;
        }

        public bool Existe_Empresa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_Empresa(nCodigo);

        }

        public EmpresaStruct Retorna_Empresa(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Retorna_Empresa(Codigo);
        }

        public bool EmpresaSuspensa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Suspensa(nCodigo);
        }

        public int ExisteEmpresaCnpj(string sCNPJ) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_EmpresaCnpj(sCNPJ);
        }

        public int ExisteEmpresaCpf(string sCPF) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Existe_EmpresaCpf(sCPF);
        }

        public bool Empresa_tem_VS(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_tem_VS(nCodigo);
        }

        public bool Empresa_tem_TL(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_tem_TL(nCodigo);
        }

        /// <summary>
        /// Retorna o regime da empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public string RegimeEmpresa(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Regime_Empresa(nCodigo);
        }

        /// <summary>
        /// Verifica se a empresa esta no Mei
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public bool Empresa_Mei(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Empresa_Mei(nCodigo);
        }

        /// <summary>
        /// Lista dos sócios de uma empresa
        /// </summary>
        /// <param name="nCodigo"></param>
        /// <returns></returns>
        public List<CidadaoStruct> ListaSocio(int nCodigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Socio(nCodigo);
        }

        /// <summary>
        /// Lista dos horários de funcionamento
        /// </summary>
        /// <returns></returns>
        public List<Horariofunc> Lista_Horario() {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Horario();
        }

        /// <summary>
        /// Lista as placas dos veículos de uma empresa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<string> Lista_Placas(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Placas(Codigo);
        }

        /// <summary>
        /// Retorna a lista de protocolos do VRE
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<sil> Lista_Sil(int Codigo) {
            Empresa_Data obj = new Empresa_Data(_connection);
            return obj.Lista_Sil(Codigo);
        }

    }
}
