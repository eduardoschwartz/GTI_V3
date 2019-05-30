using GTI_Models.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace GTI_Dal.Classes {
    public class Integrativa_Data {
        private static string _connection;

        public Integrativa_Data(string sConnection) {
            _connection = sConnection;
        }

        public int Insert_Integrativa_Cda(Cdas Reg) {
            int _id = 0;
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                try {
                    db.Cdas.Add(Reg);
                    db.SaveChanges();
                    _id = Reg.Idcda;
                } catch {

                }
                return _id;
            }
        }

        public Exception Insert_Integrativa_Cancelamento(Cancelamentos Reg) {
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                try {
                    db.Cancelamentos.Add(Reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Integrativa_Cadastro(Cadastro Reg) {
            using (Integrativa_Context db = new Integrativa_Context(_connection)) {
                object[] Parametros = new object[15];
                Parametros[0] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.SmallInt, SqlValue = Reg.Ano };

                db.Database.ExecuteSqlCommand("INSERT INTO cadastro(ano,) " +
                    "VALUES(@ano)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

    }
}
