using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GTI_Dal.Classes {
    public class Empresa_Data {

        private string _connection;

        public Empresa_Data(string sConnection) {
            _connection = sConnection;
        }
        
        public bool Existe_Empresa(int nCodigo) {
            bool bRet = false;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliario.Count(a => a.Codigomob == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool Empresa_Suspensa(int nCodigo) {
            bool bRet = false;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliarioevento.Count(a => a.Codmobiliario == nCodigo);
                if (existingReg != 0) {
                    int sit = (from m in db.Mobiliarioevento where m.Codmobiliario == nCodigo orderby m.Dataevento descending select m.Codtipoevento).FirstOrDefault();
                    if (sit == 2)
                        bRet = true;
                }
            }
            return bRet;
        }

        public int Existe_EmpresaCnpj(string sCNPJ) {
            int nCodigo = 0;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliario.Count(a => a.Cnpj == sCNPJ);
                if (existingReg != 0) {
                    int reg = (from m in db.Mobiliario where m.Cnpj == sCNPJ select m.Codigomob).FirstOrDefault();
                    nCodigo = reg;
                }
            }
            return nCodigo;
        }

        public int Existe_EmpresaCpf(string sCPF) {
            int nCodigo = 0;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliario.Count(a => a.Cpf == sCPF);
                if (existingReg != 0) {
                    int reg = (from m in db.Mobiliario where m.Cpf == sCPF select m.Codigomob).FirstOrDefault();
                    nCodigo = reg;
                }
            }
            return nCodigo;
        }

        public bool Empresa_tem_VS(int nCodigo) {
            bool bRet = false;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Mobiliarioatividadevs2.Count(a => a.Codmobiliario == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public bool Empresa_tem_TL(int nCodigo) {
            bool ret = true;
            using (var db = new GTI_Context(_connection)) {
                byte? isento = (from m in db.Mobiliario where m.Codigomob == nCodigo && m.Isentotaxa ==1 select m.Isentotaxa).FirstOrDefault();
                if (Convert.ToBoolean(isento))
                    return false;
            }
            return ret;
        }

        public string Regime_Empresa(int nCodigo) {
            using (var db = new GTI_Context(_connection)) {
                int tributo = (from m in db.Mobiliarioatividadeiss where m.Codmobiliario == nCodigo select m.Codtributo).FirstOrDefault();
                if (tributo == 11)
                    return "F";
                else {
                    if (tributo == 12)
                        return "E";
                    else {
                        if (tributo == 13)
                            return "V";
                        else
                            return "N";
                    }
                }
            }
        }

        public bool Empresa_Mei(int nCodigo) {
            bool ret = true;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Mei.Count(a => a.Codigo == nCodigo);
                if (existingReg == 0) {
                    ret = false;
                } else {
                    DateTime? datafim = (from m in db.Mei where m.Codigo == nCodigo select m.Datafim).FirstOrDefault();
                    if (dalCore.IsDate(datafim))
                        return false;
                }
            }
            return ret;
        }

        public bool Empresa_Simples(int Codigo,DateTime Data) {
            using (var db = new GTI_Context(_connection)) {
                short nRet = db.Database.SqlQuery<short>("SELECT dbo.RETORNASN2(@Codigo,@Data)", new SqlParameter("@Codigo", Codigo), new SqlParameter("@Data", Data)).Single();
                return nRet == 1 ? true : false;
            }
        }

        public EmpresaStruct Retorna_Empresa(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from m in db.Mobiliario
                           join b in db.Bairro on new { p1 = (short)m.Codbairro, p2 = (short)m.Codcidade, p3 = m.Siglauf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Codcidade, p2 = m.Siglauf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           join h in db.Horariofunc on m.Horario equals h.Codhorario into hm from h in hm.DefaultIfEmpty()
                           join p in db.Cidadao on m.Codprofresp equals p.Codcidadao into mp from p in mp.DefaultIfEmpty()
                           where m.Codigomob == Codigo
                           select new EmpresaStruct{Codigo= m.Codigomob, Razao_social= m.Razaosocial,Nome_fantasia=m.Nomefantasia,Endereco_codigo=m.Codlogradouro,Endereco_nome= l.Endereco,Numero=  m.Numero,Complemento= m.Complemento,
                                                    Bairro_codigo=m.Codbairro,Bairro_nome=b.Descbairro,Cidade_codigo=m.Codcidade,Cidade_nome=c.Desccidade,UF=m.Siglauf,Cep=m.Cep,Homepage=m.Homepage,Horario=m.Horario,
                                                    Data_abertura=m.Dataabertura,Numprocesso=m.Numprocesso,Dataprocesso=m.Dataprocesso,Data_Encerramento=m.Dataencerramento,Numprocessoencerramento=m.Numprocencerramento,
                                                    Dataprocencerramento=m.Dataprocencerramento,Inscricao_estadual=m.Inscestadual,Isencao=m.Isencao,Atividade_codigo=m.Codatividade,Atividade_extenso=m.Ativextenso,Area=m.Areatl,
                                                    Codigo_aliquota=m.Codigoaliq,Data_inicial_desconto=m.Datainicialdesc,Data_final_desconto=m.Datafinaldesc,Percentual_desconto=m.Percdesconto,Capital_social=m.Capitalsocial,
                                                    Nome_orgao=m.Nomeorgao,prof_responsavel_codigo=m.Codprofresp,Numero_registro_resp=m.Numregistroresp,Qtde_socio=m.Qtdesocio,Qtde_empregado=m.Qtdeempregado,Responsavel_contabil_codigo=m.Respcontabil,
                                                    Rg_responsavel=m.Rgresp,Orgao_emissor_resp=m.Orgaoemisresp,Nome_contato=m.Nomecontato,Cargo_contato=m.Cargocontato,Fone_contato=m.Fonecontato,Fax_contato=m.Faxcontato,
                                                    Email_contato=m.Emailcontato,Vistoria=m.Vistoria,Qtde_profissionais=m.Qtdeprof,Rg=m.Rg,Orgao=m.Orgao,Nome_logradouro=m.Nomelogradouro,Simples=m.Simples,Regime_especial=m.Regespecial,
                                                    Alvara=m.Alvara,Data_simples=m.Datasimples,Isento_taxa=m.Isentotaxa,Mei=m.Mei,Horario_extenso=m.Horarioext,Iss_eletro=m.Isseletro,Dispensa_ie_data=m.Dispensaiedata,
                                                    Dispensa_ie_processo=m.Dispensaieproc,Data_alvara_provisorio=m.Dtalvaraprovisorio,Senha_iss=m.Senhaiss,Inscricao_temporaria=m.Insctemp,Horas_24=m.Horas24,Isento_iss=m.Isentoiss,
                                                    Bombonieri=m.Bombonieri,Emite_nf=m.Emitenf,Danfe=m.Danfe,Imovel=m.Imovel,Sil=m.Sil,Substituto_tributario_issqn=m.Substituto_tributario_issqn,Individual=m.Individual,
                                                    Ponto_agencia=m.Ponto_agencia,Cadastro_vre=m.Cadastro_vre,Liberado_vre=m.Liberado_vre,Cpf=m.Cpf,Cnpj=m.Cnpj,Prof_responsavel_registro=m.Numregistroresp,
                                                    Prof_responsavel_conselho=m.Nomeorgao,prof_responsavel_nome=p.Nomecidadao,Horario_Nome=h.Deschorario
                           }).FirstOrDefault();


                EmpresaStruct row = new EmpresaStruct();
                if (reg == null)
                    return row;
                row.Codigo = Codigo;
                row.Razao_social = reg.Razao_social;
                row.Nome_fantasia = reg.Nome_fantasia;
                row.Cpf_cnpj = "";
                if (!string.IsNullOrEmpty(reg.Cpf) && reg.Cpf.Length > 10) {
                    row.Juridica = false;
                    row.Cpf_cnpj = reg.Cpf;
                } else {
                    if (!string.IsNullOrEmpty(reg.Cnpj) && reg.Cnpj.Length > 13) {
                        row.Cpf_cnpj = reg.Cnpj;
                        row.Juridica = true;
                    }
                }
                if(reg.Rg!=null)
                    row.Rg = (reg.Rg.Trim() + ' ' + reg.Orgao.Trim()).Trim();
                row.Bairro_nome = reg.Bairro_nome;
                row.Cidade_nome = reg.Cidade_nome;
                row.UF = reg.UF;
                row.Endereco_codigo = reg.Endereco_codigo;
                row.Endereco_nome = reg.Endereco_nome;
                row.Numero = reg.Numero;
                row.Complemento = reg.Complemento;

                row.Inscricao_estadual = reg.Inscricao_estadual ?? "";
                row.Data_abertura = Convert.ToDateTime(reg.Data_abertura);
                row.Numprocesso = reg.Numprocesso;
                row.Dataprocesso = reg.Dataprocesso;
                row.Data_Encerramento = reg.Data_Encerramento != null ? reg.Data_Encerramento :(DateTime?)null;
                row.Numprocessoencerramento = reg.Numprocessoencerramento;
                row.Dataprocencerramento = reg.Dataprocencerramento;
                row.Horario = reg.Horario;
                row.Horario_Nome = reg.Horario_Nome;
                row.Ponto_agencia = reg.Ponto_agencia;
                string horario = reg.Horario_extenso == null || reg.Horario_extenso == "" ? "" : reg.Horario_extenso;
                row.Horario_extenso = horario;

                row.Qtde_empregado = reg.Qtde_empregado;
                row.Capital_social = reg.Capital_social;
                row.Inscricao_temporaria = reg.Inscricao_temporaria == null ? 0 : reg.Inscricao_temporaria;
                row.Substituto_tributario_issqn = reg.Substituto_tributario_issqn == null ? false : reg.Substituto_tributario_issqn;
                row.Isento_iss = reg.Isento_iss == null ? 0 : reg.Isento_iss;
                row.Isento_taxa = reg.Isento_taxa == null ? 0 : reg.Isento_taxa;
                row.Individual = reg.Individual == null ? false : reg.Individual;
                row.Liberado_vre = reg.Liberado_vre == null ? false : reg.Liberado_vre;
                row.Horas_24 = reg.Horas_24 == null ? 0 : reg.Horas_24;
                row.Bombonieri = reg.Bombonieri == null ? 0 : reg.Bombonieri;
                row.Vistoria = reg.Vistoria == null ? 0 : reg.Vistoria;

                string sSituacao = "";
                if (dalCore.IsDate(row.Data_Encerramento.ToString()))
                    sSituacao = "ENCERRADA";
                else {
                    if (Empresa_Suspensa(Codigo))
                            sSituacao = "SUSPENSA";
                    else
                        sSituacao = "ATIVA";
                }
                row.Situacao = sSituacao;
                row.Email_contato = reg.Email_contato ?? "";
                row.Fone_contato = reg.Fone_contato ?? "";
                row.Area = reg.Area == 0 ? 0 : Convert.ToSingle(reg.Area);
                

                row.Atividade_extenso = reg.Atividade_extenso ?? "";
                if (reg.Cidade_codigo == 413) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep((int)reg.Endereco_codigo, (short)reg.Numero);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                Imovel_Data imovel_Class = new Imovel_Data(_connection);
                ImovelStruct regImovel = imovel_Class.Inscricao_imovel((int)reg.Endereco_codigo,(short)reg.Numero);
                if (regImovel != null) {
                    row.Distrito = regImovel.Distrito;
                    row.Setor = regImovel.Setor;
                    row.Quadra = regImovel.Quadra;
                    row.Lote = regImovel.Lote;
                    row.Seq = regImovel.Seq;
                    row.Unidade = regImovel.Unidade;
                    row.Subunidade = regImovel.SubUnidade;
                    row.Imovel = regImovel.Codigo;
                }

                row.Nome_contato = reg.Nome_contato;
                row.Fone_contato = reg.Fone_contato;
                row.Email_contato = reg.Email_contato;
                row.Cargo_contato = reg.Cargo_contato;
                row.prof_responsavel_codigo = reg.prof_responsavel_codigo;
                row.prof_responsavel_nome = reg.prof_responsavel_nome;
                row.Prof_responsavel_registro = reg.Prof_responsavel_registro;
                row.Prof_responsavel_conselho = reg.Prof_responsavel_conselho;
                row.Responsavel_contabil_codigo = reg.Responsavel_contabil_codigo;

                return row;
            }
        }

        public List<CidadaoStruct> Lista_Socio(int nCodigo) {
            List<CidadaoStruct> Lista = new List<CidadaoStruct>();
            Cidadao_Data cidadao_classs = new Cidadao_Data(_connection);
            using (var db = new GTI_Context(_connection)) {
                List<int> Socios = (from m in db.Mobiliarioproprietario where m.Codmobiliario == nCodigo select m.Codcidadao).ToList();
                foreach (int Cod in Socios) {
                    CidadaoStruct reg = cidadao_classs.LoadReg(Cod);
                    Lista.Add(reg);
                }
                return Lista;
            }
        }

        public List<Horariofunc> Lista_Horario() {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from h in db.Horariofunc orderby h.Deschorario  select h).ToList();
                return Sql;
            }
        }

        public List<string> Lista_Placas(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from p in db.Mobiliarioplaca where p.Codigo==Codigo orderby p.placa select  p.placa).Distinct().ToList();
                return Sql;
            }
        }

        public List<sil> Lista_Sil(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from s in db.Sil where s.Codigo==Codigo orderby s.Data_emissao descending select s).ToList();
                return Sql;
            }
        }

        public mobiliarioendentrega Empresa_Endereco_entrega(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from m in db.Mobiliarioendentrega
                           join b in db.Bairro on new { p1 = m.Codbairro, p2 = m.Codcidade, p3 = m.Uf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = m.Codcidade, p2 = m.Uf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           where m.Codmobiliario == Codigo
                           select new  { m.Codmobiliario,m.Codlogradouro,Nomelogradouro=l.Endereco,m.Numimovel, m.Complemento,m.Uf,m.Codcidade,m.Codbairro,m.Cep,b.Descbairro,c.Desccidade
                           }).FirstOrDefault();

                mobiliarioendentrega row = new mobiliarioendentrega();
                if (reg == null)
                    return row;
                row.Descbairro = reg.Descbairro;
                row.Desccidade = reg.Desccidade;
                row.Uf = reg.Uf;
                row.Codlogradouro = reg.Codlogradouro;
                row.Nomelogradouro = reg.Nomelogradouro;
                row.Numimovel = reg.Numimovel;
                row.Complemento = reg.Complemento;
                row.Cep = reg.Cep;
                if (reg.Codcidade == 413) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep(reg.Codlogradouro, reg.Numimovel);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                return row;
            }
        }

        public List<MobiliarioproprietarioStruct> Lista_Empresa_Proprietario(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from m in db.Mobiliarioproprietario
                           join c in db.Cidadao on m.Codcidadao equals c.Codcidadao where  m.Codmobiliario==Codigo
                           orderby c.Nomecidadao select new MobiliarioproprietarioStruct {Codcidadao=m.Codcidadao,Nome=c.Nomecidadao }).ToList();
                return Sql;
            }
        }

        public List<Escritoriocontabil> Lista_Escritorio_Contabil() {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from e in db.Escritoriocontabil where e.Codigoesc>0 orderby e.Nomeesc  select e).ToList();
                return Sql;
            }
        }

        public EscritoriocontabilStruct Dados_Escritorio_Contabil(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from m in db.Escritoriocontabil
                           join b in db.Bairro on  m.Codbairro equals b.Codbairro  into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Codcidade, p2 = m.UF } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           where m.Codigoesc == Codigo
                           select new EscritoriocontabilStruct {Codigo=m.Codigoesc,Nome=m.Nomeesc,Logradouro_Codigo=m.Codlogradouro,Logradouro_Nome=l.Endereco,Numero=m.Numero,
                           Complemento=m.Complemento,Bairro_Codigo=m.Codbairro,Bairro_Nome=b.Descbairro,Cidade_Nome=c.Desccidade,UF=m.UF,Telefone=m.Telefone,Email=m.Email,
                           Cpf=m.Cpf,Cnpj=m.Cnpj,Im=m.Im,Crc=m.Crc,Recebecarne=m.Recebecarne,Cidade_Codigo=m.Codcidade,Logradouro_Nome_Fora  =m.Nomelogradouro
                           }).FirstOrDefault();

                EscritoriocontabilStruct row = new EscritoriocontabilStruct();
                if (reg == null)
                    return row;
                row.Codigo = reg.Codigo;
                row.Nome = reg.Nome;
                row.Logradouro_Codigo = reg.Logradouro_Codigo;
                row.Logradouro_Nome = reg.Logradouro_Nome ?? reg.Logradouro_Nome_Fora;
                row.Numero = reg.Numero;
                row.Complemento = reg.Complemento;
                row.Bairro_Codigo = reg.Bairro_Codigo;
                row.Bairro_Nome = reg.Bairro_Nome;
                row.Cidade_Codigo = reg.Cidade_Codigo;
                row.Cidade_Nome = reg.Cidade_Nome;
                row.UF = reg.UF;
                row.Cpf = reg.Cpf;
                row.Cnpj = reg.Cnpj;
                row.Crc = reg.Crc;
                row.Email = reg.Email;
                row.Im = reg.Im;
                row.Telefone = reg.Telefone;
                row.Recebecarne =  reg.Recebecarne==null?false:reg.Recebecarne;

                if (reg.Logradouro_Codigo >0) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep((int)reg.Logradouro_Codigo, (short)reg.Numero);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                return row;
            }
        }

        public Exception Incluir_escritorio(Escritoriocontabil reg) {
            using (var db = new GTI_Context(_connection)) {
                object[] Parametros = new  object[17];
                Parametros[0] = new SqlParameter { ParameterName = "@Codigoesc", SqlDbType = SqlDbType.Int, SqlValue = reg.Codigoesc };
                Parametros[1] = new SqlParameter { ParameterName = "@Nomeesc", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomeesc };
                Parametros[2] = new SqlParameter { ParameterName = "@Codlogradouro", SqlDbType = SqlDbType.Int, SqlValue = reg.Codlogradouro };
                Parametros[3] = new SqlParameter { ParameterName = "@Nomelogradouro", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Nomelogradouro };
                Parametros[4] = new SqlParameter { ParameterName = "@Numero", SqlDbType = SqlDbType.Int, SqlValue = reg.Numero };
                Parametros[5] = new SqlParameter { ParameterName = "@Codbairro", SqlDbType = SqlDbType.SmallInt, SqlValue = reg.Codbairro };
                Parametros[6] = new SqlParameter { ParameterName = "@Cep", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cep };
                Parametros[7] = new SqlParameter { ParameterName = "@UF", SqlDbType = SqlDbType.VarChar, SqlValue = reg.UF };
                Parametros[8] = new SqlParameter { ParameterName = "@Telefone", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Telefone };
                Parametros[9] = new SqlParameter { ParameterName = "@Email", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Email };
                Parametros[10] = new SqlParameter { ParameterName = "@Recebecarne", SqlDbType = SqlDbType.Bit, SqlValue = reg.Recebecarne };
                Parametros[11] = new SqlParameter { ParameterName = "@Crc", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Crc };
                Parametros[12] = new SqlParameter { ParameterName = "@Cpf", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cpf };
                Parametros[13] = new SqlParameter { ParameterName = "@Cnpj", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Cnpj };
                Parametros[14] = new SqlParameter { ParameterName = "@Im", SqlDbType = SqlDbType.Int, SqlValue = reg.Im };
                Parametros[15] = new SqlParameter { ParameterName = "@Complemento", SqlDbType = SqlDbType.VarChar, SqlValue = reg.Complemento };
                Parametros[16] = new SqlParameter { ParameterName = "@Codcidade", SqlDbType = SqlDbType.Int, SqlValue = reg.Codcidade };

                db.Database.ExecuteSqlCommand("INSERT INTO escritoriocontabil(codigoesc,nomeesc,codlogradouro,nomelogradouro,numero,codbairro,cep,uf,telefone," +
                                              "email,recebecarne,crc,cpf,cnpj,im,complemento,codcidade) VALUES(@Codigoesc,@nomeesc,@Codlogradouro,@Nomelogradouro," +
                                              "@Numero,@Codbairro,@Cep,@UF,@Telefone,@Email,@Recebecarne,@Crc,@Cpf,@Cnpj,@Im,@Complemento,@Codcidade)", Parametros);

                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_escritorio(Escritoriocontabil reg) {
            using (var db = new GTI_Context(_connection)) {
                Escritoriocontabil b = db.Escritoriocontabil.First(i => i.Codigoesc == reg.Codigoesc);
                b.Nomeesc = reg.Nomeesc;
                b.Cep = reg.Cep;
                b.Cnpj = reg.Cnpj;
                b.Cpf = reg.Cpf;
                b.Codbairro = reg.Codbairro;
                b.Codcidade = reg.Codcidade;
                b.Codlogradouro = reg.Codlogradouro;
                b.Complemento = reg.Complemento;
                b.Crc = reg.Crc;
                b.Email = reg.Email;
                b.Im = reg.Im;
                b.Nomelogradouro = reg.Nomelogradouro;
                b.Numero = reg.Numero;
                b.Recebecarne = reg.Recebecarne;
                b.Telefone = reg.Telefone;
                b.UF = reg.UF;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

       public int Retorna_Ultimo_Codigo_Escritorio() {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Escritoriocontabil orderby c.Codigoesc descending select c.Codigoesc).FirstOrDefault();
                return Sql;
            }
        }

        public Exception Excluir_Escritorio(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    Escritoriocontabil b = db.Escritoriocontabil.First(i => i.Codigoesc == Codigo);
                    db.Escritoriocontabil.Remove(b);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public bool Empresa_Escritorio(int id_escritorio) {
            int _contador = 0;
            using (var db = new GTI_Context(_connection)) {
                Inicio:;
                try {
                    _contador = (from p in db.Mobiliario where p.Respcontabil == id_escritorio select p.Codigomob).Count();
                } catch {
                    goto Inicio; //este erro só acontece no timeout, então tenta até conseguir.                   
                }
                return _contador > 0 ? true : false;
            }
        }

        public Exception Incluir_DEmp(List<DEmpresa> Lista) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    foreach (DEmpresa reg in Lista) {
                        db.DEmpresa.Add(reg);
                        db.SaveChanges();
                    }
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<DEmpresa> ListaDEmpresa(int nSid) {
            List<DEmpresa> reg;
            using (var db = new GTI_Context(_connection)) {
                reg = (from b in db.DEmpresa where b.sid == nSid select b).ToList();
                return reg;
            }
        }

        public Exception Delete_DEmpresa(int nSid) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    db.DEmpresa.RemoveRange(db.DEmpresa.Where(i => i.sid == nSid));
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public List<CnaeStruct> ListaCnae(int nCodigo) {
            List<CnaeStruct> Lista = new List<CnaeStruct>();
            using (var db = new GTI_Context(_connection)) {
                var rows = (from m in db.Mobiliariocnae join c in db.Cnaesubclasse on
                            new { p1 = m.Divisao, p2 = m.Grupo, p3 = m.Classe, p4 = m.Subclasse } equals
                            new { p1 = c.Divisao, p2 = c.Grupo, p3 = c.Classe, p4 = c.Subclasse }
                            where m.Codmobiliario == nCodigo
                            select new { m.Cnae, c.Descricao });
                foreach (var reg in rows) {
                    CnaeStruct Linha = new CnaeStruct();
                    Linha.Cnae = reg.Cnae;
                    Linha.Descricao = reg.Descricao;
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public SilStructure CarregaSil(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from s in db.Sil where s.Codigo == Codigo
                           select new {
                               s.Codigo, s.Protocolo, s.Data_emissao, s.Data_validade, s.Area_imovel
                           }).FirstOrDefault();

                SilStructure row = new SilStructure();
                if (reg == null)
                    return row;
                row.Codigo = Codigo;
                row.Data_Emissao = reg.Data_emissao;
                row.Data_Validade = reg.Data_validade;
                row.Protocolo = reg.Protocolo;
                row.AreaImovel = reg.Area_imovel;
                return (row);
            }
        }

        public bool Existe_Empresa_Vre(int nCodigo) {
            bool bRet = false;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Vre_empresa.Count(a => a.Id == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public Exception Insert_Empresa_Vre(Vre_empresa reg) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    db.Vre_empresa.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Atividade_Vre(Vre_atividade reg) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    db.Vre_atividade.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Socio_Vre(Vre_socio reg) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    db.Vre_socio.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Insert_Licenciamento_Vre(Vre_licenciamento reg) {
            using (var db = new GTI_Context(_connection)) {
                try {
                    db.Vre_licencimento.Add(reg);
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

    }
}
