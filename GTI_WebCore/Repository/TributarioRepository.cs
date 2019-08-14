using GTI_WebCore.Interfaces;
using GTI_WebCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GTI_WebCore.Repository {
    public class TributarioRepository : ITributarioRepository {
        private readonly AppDbContext context;

        public TributarioRepository(AppDbContext context) {
            this.context = context;
        }

        public int Retorna_Codigo_Certidao(Functions.TipoCertidao tipo_certidao) {
            int nRet = 0;
                var Sql = (from p in context.Parametros select p);
                if (tipo_certidao == Functions.TipoCertidao.Endereco)
                    Sql = Sql.Where(c => c.Nomeparam == "CETEND");
                else {
                    if (tipo_certidao == Functions.TipoCertidao.ValorVenal)
                        Sql = Sql.Where(c => c.Nomeparam == "CETVVN");
                    else {
                        if (tipo_certidao == Functions.TipoCertidao.Isencao)
                            Sql = Sql.Where(c => c.Nomeparam == "CETISE");
                        else {
                            if (tipo_certidao == Functions.TipoCertidao.Debito)
                                Sql = Sql.Where(c => c.Nomeparam == "CDB");
                            else {
                                if (tipo_certidao == Functions.TipoCertidao.Comprovante_Pagamento)
                                    Sql = Sql.Where(c => c.Nomeparam == "CPAGTO");
                                else {
                                    if (tipo_certidao == Functions.TipoCertidao.Alvara)
                                        Sql = Sql.Where(c => c.Nomeparam == "ALVARA");
                                    else {
                                        if (tipo_certidao == Functions.TipoCertidao.Debito_Doc)
                                            Sql = Sql.Where(c => c.Nomeparam == "CDB_DOC");
                                    }
                                }
                            }
                        }
                    }
                }
                try {
                    foreach (Parametros item in Sql) {
                        nRet = Convert.ToInt32(item.Valparam) + 1;
                        break;
                    }
                } catch (Exception ex2) {

                    throw ex2;
                }
            Exception ex = Atualiza_Codigo_Certidao(tipo_certidao, nRet);
            if (ex == null)
                return nRet;
            else
                return 0;
        }

        public Exception Atualiza_Codigo_Certidao(Functions.TipoCertidao tipo_certidao, int Valor) {
            Parametros p = null;
                if (tipo_certidao == Functions.TipoCertidao.Endereco)
                    p = context.Parametros.First(i => i.Nomeparam == "CETEND");
                else {
                    if (tipo_certidao == Functions.TipoCertidao.ValorVenal)
                        p = context.Parametros.First(i => i.Nomeparam == "CETVVN");
                    else {
                        if (tipo_certidao == Functions.TipoCertidao.Isencao)
                            p = context.Parametros.First(i => i.Nomeparam == "CETISE");
                        else {
                            if (tipo_certidao == Functions.TipoCertidao.Debito)
                                p = context.Parametros.First(i => i.Nomeparam == "CDB");
                            else {
                                if (tipo_certidao == Functions.TipoCertidao.Comprovante_Pagamento)
                                    p = context.Parametros.First(i => i.Nomeparam == "CPAGTO");
                                else {
                                    if (tipo_certidao == Functions.TipoCertidao.Alvara)
                                        p = context.Parametros.First(i => i.Nomeparam == "ALVARA");
                                    else {
                                        if (tipo_certidao == Functions.TipoCertidao.Debito_Doc)
                                            p = context.Parametros.First(i => i.Nomeparam == "CDB_DOC");
                                    }
                                }
                            }
                        }
                    }
                }
                p.Valparam = Valor.ToString();
                try {
                    context.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
        }

        public Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo) {
            var Sql = (from p in context.Certidao_Endereco where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
            return Sql;
        }

        public chaveStruct Valida_Certidao(string Chave) {
            bool _valido = false;
            if (Chave.Trim().Length < 8)
                goto fim;
            else {
                int nPos = Chave.IndexOf("-");
                if (nPos < 6)
                    goto fim;
                else {
                    int nPos2 = Chave.IndexOf("/");
                    if (nPos2 < 5 || nPos - nPos2 < 2)
                        goto fim;
                    else {
                        int nCodigo = Convert.ToInt32(Chave.Substring(nPos2 + 1, nPos - nPos2 - 1));
                        int nAno = Convert.ToInt32(Chave.Substring(nPos2 - 4, 4));
                        int nNumero = Convert.ToInt32(Chave.Substring(0, 5));
                        if (nAno < 2010 || nAno > DateTime.Now.Year + 1)
                            goto fim;
                        else {
                            string sTipo = Chave.Substring(Chave.Length - 2, 2);
                            if (sTipo == "EA") {
                                Certidao_endereco dados = Retorna_Certidao_Endereco(nAno, nNumero, nCodigo);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero=nNumero,
                                        Tipo=sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
                                    goto fim;
                            } else {
                                goto fim;
                            }
                        }
                    }
                }
            }
        fim:;
            chaveStruct _reg = new chaveStruct {
                Valido = _valido
            };
            return _reg;
        }

        public Exception Insert_Certidao_Endereco(Certidao_endereco Reg) {

            object[] Parametros = new object[12];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@data", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data };
            Parametros[3] = new SqlParameter { ParameterName = "@codigo", SqlDbType = SqlDbType.Int, SqlValue = Reg.Codigo };
            Parametros[4] = new SqlParameter { ParameterName = "@nomecidadao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nomecidadao };
            Parametros[5] = new SqlParameter { ParameterName = "@inscricao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Inscricao };
            Parametros[6] = new SqlParameter { ParameterName = "@logradouro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Logradouro };
            Parametros[7] = new SqlParameter { ParameterName = "@li_num", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_num };
            Parametros[8] = new SqlParameter { ParameterName = "@li_compl", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_compl };
            Parametros[9] = new SqlParameter { ParameterName = "@li_quadras", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_quadras };
            Parametros[10] = new SqlParameter { ParameterName = "@li_lotes", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Li_lotes };
            Parametros[11] = new SqlParameter { ParameterName = "@descbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.descbairro };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_endereco(numero,ano,data,codigo,nomecidadao,inscricao,logradouro,li_num,li_compl,li_quadras,li_lotes,descbairro)" +
                " VALUES(@numero,@ano,@data,@codigo,@nomecidadao,@inscricao,@logradouro,@li_num,@li_compl,@li_quadras,@li_lotes,@descbairro)", Parametros);

            try {
//                context.Certidao_Endereco.Add(Reg);
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }
        
    }
}
