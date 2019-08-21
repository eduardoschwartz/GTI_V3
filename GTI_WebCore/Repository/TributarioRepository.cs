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
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
                                    goto fim;
                            } else if (sTipo == "VV") {
                                Certidao_valor_venal dados = Retorna_Certidao_Valor_Venal(nAno, nNumero, nCodigo);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
                                    goto fim;
                            } else if (sTipo == "CI") {
                                Certidao_isencao dados = Retorna_Certidao_Isencao(nAno, nNumero, nCodigo);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                }
                            } else if (sTipo == "IE" || sTipo == "XE" || sTipo == "XA") {
                                Certidao_Inscricao dados = Retorna_Certidao_Inscricao(nAno, nNumero);
                                if (dados != null) {
                                    chaveStruct reg = new chaveStruct {
                                        Codigo = nCodigo,
                                        Ano = nAno,
                                        Numero = nNumero,
                                        Tipo = sTipo,
                                        Valido = true
                                    };
                                    return reg;
                                } else
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
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Valor_Venal(Certidao_valor_venal Reg) {

            object[] Parametros = new object[16];
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
            Parametros[11] = new SqlParameter { ParameterName = "@descbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Descbairro };
            Parametros[12] = new SqlParameter { ParameterName = "@areaterreno", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Areaterreno };
            Parametros[13] = new SqlParameter { ParameterName = "@vvt", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vvt };
            Parametros[14] = new SqlParameter { ParameterName = "@vvp", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vvp };
            Parametros[15] = new SqlParameter { ParameterName = "@vvi", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Vvi };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_valor_venal(numero,ano,data,codigo,nomecidadao,inscricao,logradouro,li_num,li_compl,li_quadras,li_lotes," +
                "descbairro,areaterreno,vvt,vvp,vvi) VALUES(@numero,@ano,@data,@codigo,@nomecidadao,@inscricao,@logradouro,@li_num,@li_compl,@li_quadras,@li_lotes," +
                "@descbairro,@areaterreno,@vvt,@vvp,@vvi)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Isencao(Certidao_isencao Reg) {

            object[] Parametros = new object[16];
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
            Parametros[11] = new SqlParameter { ParameterName = "@descbairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Descbairro };
            Parametros[12] = new SqlParameter { ParameterName = "@percisencao", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Percisencao };
            Parametros[13] = new SqlParameter { ParameterName = "@Area", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Area };
            Parametros[14] = new SqlParameter { ParameterName = "@numprocesso", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Numprocesso };
            Parametros[15] = new SqlParameter { ParameterName = "@dataprocesso", SqlDbType = SqlDbType.SmallDateTime,IsNullable=true,  SqlValue = DBNull.Value };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_isencao(numero,ano,data,codigo,nomecidadao,inscricao,logradouro,li_num,li_compl,li_quadras,li_lotes," +
                "descbairro,percisencao,area,numprocesso,dataprocesso) VALUES(@numero,@ano,@data,@codigo,@nomecidadao,@inscricao,@logradouro,@li_num,@li_compl,@li_quadras,@li_lotes," +
                "@descbairro,@percisencao,@area,@numprocesso,@dataprocesso)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Exception Insert_Certidao_Inscricao(Certidao_Inscricao Reg) {
            object[] Parametros = new object[27];
            Parametros[0] = new SqlParameter { ParameterName = "@numero", SqlDbType = SqlDbType.Int, SqlValue = Reg.Numero };
            Parametros[1] = new SqlParameter { ParameterName = "@ano", SqlDbType = SqlDbType.Int, SqlValue = Reg.Ano };
            Parametros[2] = new SqlParameter { ParameterName = "@data_emissao", SqlDbType = SqlDbType.SmallDateTime ,SqlValue=Reg.Data_emissao};
            Parametros[3] = new SqlParameter { ParameterName = "@endereco", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Endereco };
            Parametros[4] = new SqlParameter { ParameterName = "@bairro", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Bairro };
            Parametros[5] = new SqlParameter { ParameterName = "@cadastro", SqlDbType = SqlDbType.Int, SqlValue = Reg.Cadastro };
            Parametros[6] = new SqlParameter { ParameterName = "@nome", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Nome };
            Parametros[7] = new SqlParameter { ParameterName = "@rg", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Rg };
            Parametros[8] = new SqlParameter { ParameterName = "@documento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Documento };
            Parametros[9] = new SqlParameter { ParameterName = "@cidade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cidade };
            Parametros[10] = new SqlParameter { ParameterName = "@atividade", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade };
            Parametros[11] = new SqlParameter { ParameterName = "@data_abertura", SqlDbType = SqlDbType.SmallDateTime, SqlValue = Reg.Data_abertura };
            Parametros[12] = new SqlParameter { ParameterName = "@processo_abertura", SqlDbType = SqlDbType.VarChar,  SqlValue = Reg.Processo_abertura };
            Parametros[13] = new SqlParameter { ParameterName = "@data_encerramento", SqlDbType = SqlDbType.SmallDateTime,  IsNullable = true, SqlValue = DBNull.Value };
            Parametros[14] = new SqlParameter { ParameterName = "@processo_encerramento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Processo_encerramento };
            Parametros[15] = new SqlParameter { ParameterName = "@inscricao_estadual", SqlDbType = SqlDbType.VarChar,  SqlValue = Reg.Inscricao_estadual };
            Parametros[16] = new SqlParameter { ParameterName = "@nome_fantasia", SqlDbType = SqlDbType.VarChar,  SqlValue = Reg.Nome_fantasia };
            Parametros[17] = new SqlParameter { ParameterName = "@atividade_secundaria", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Atividade_secundaria };
            Parametros[18] = new SqlParameter { ParameterName = "@complemento", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Complemento };
            Parametros[19] = new SqlParameter { ParameterName = "@cep", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Cep };
            Parametros[20] = new SqlParameter { ParameterName = "@situacao", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Situacao };
            Parametros[21] = new SqlParameter { ParameterName = "@telefone", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Telefone };
            Parametros[22] = new SqlParameter { ParameterName = "@email", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Email };
            Parametros[23] = new SqlParameter { ParameterName = "@taxa_licenca", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Taxa_licenca };
            Parametros[24] = new SqlParameter { ParameterName = "@vigilancia_sanitaria", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Vigilancia_sanitaria };
            Parametros[25] = new SqlParameter { ParameterName = "@mei", SqlDbType = SqlDbType.VarChar, SqlValue = Reg.Mei };
            Parametros[26] = new SqlParameter { ParameterName = "@area", SqlDbType = SqlDbType.Decimal, SqlValue = Reg.Area };

            context.Database.ExecuteSqlCommand("INSERT INTO certidao_inscricao(numero,ano,data_emissao,endereco,bairro,cadastro,nome,rg,documento,cidade,atividade,data_abertura," +
                "processo_abertura,data_encerramento,processo_encerramento,inscricao_estadual,nome_fantasia,atividade_secundaria,complemento,cep,situacao,telefone,email,taxa_licenca," +
                "vigilancia_sanitaria,mei,area) VALUES(@numero,@ano,@data_emissao,@endereco,@bairro,@cadastro,@nome,@rg,@documento,@cidade,@atividade,@data_abertura," +
                "@processo_abertura,@data_encerramento,@processo_encerramento,@inscricao_estadual,@nome_fantasia,@atividade_secundaria,@complemento,@cep,@situacao,@telefone,@email," +
                "@taxa_licenca,@vigilancia_sanitaria,@mei,@area)", Parametros);

            try {
                context.SaveChanges();
            } catch (Exception ex) {
                return ex;
            }
            return null;
        }

        public Certidao_valor_venal Retorna_Certidao_Valor_Venal(int Ano, int Numero, int Codigo) {
            var Sql = (from p in context.Certidao_Valor_Venal where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
            return Sql;
        }

        public Certidao_isencao Retorna_Certidao_Isencao(int Ano, int Numero, int Codigo) {
                var Sql = (from p in context.Certidao_Isencao where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
                return Sql;
        }

        public Certidao_endereco Retorna_Certidao_Endereco(int Ano, int Numero, int Codigo) {
            var Sql = (from p in context.Certidao_Endereco where p.Ano == Ano && p.Numero == Numero && p.Codigo == Codigo select p).FirstOrDefault();
            return Sql;
        }

        public Certidao_Inscricao Retorna_Certidao_Inscricao(int Ano, int Numero) {
            var Sql = (from c in context.Certidao_Inscricao where c.Ano == Ano && c.Numero == Numero select c).FirstOrDefault();
            return Sql;
        }
    }
}
