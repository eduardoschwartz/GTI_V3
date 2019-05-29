using GTI_Dal.Classes;
using GTI_Models.Models;
using System;

namespace GTI_Bll.Classes {
    public class Integrativa_bll {
        private static string _connection;

        public Integrativa_bll(string sConnection) {
            _connection = sConnection;
        }

        /// <summary>
        /// Insere um registro na tabela Cdas (Intgrativa)
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public int Insert_Integrativa_Cda(Cdas Reg) {
            Integrativa_Data obj = new Integrativa_Data(_connection);
            return obj.Insert_Integrativa_Cda(Reg);
        }

        /// <summary>
        /// Inserir um registro na tabela Cancelamentos da Integrativa
        /// </summary>
        /// <param name="Reg"></param>
        /// <returns></returns>
        public Exception Insert_Integrativa_Cancelamento(Cancelamentos Reg) {
            Integrativa_Data obj = new Integrativa_Data(_connection);
            Exception ex = obj.Insert_Integrativa_Cancelamento(Reg);
            return ex;
        }

    }
}
