using GTI_Dal;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static GTI_Models.modelCore;

namespace GTI_Dal.Classes {
    public class Sistema_Data {

        private string _connection;
        public Sistema_Data(string sConnection) {
            _connection = sConnection;
        }

        public List<int> Lista_Codigos_Documento(string Documento,TipoDocumento _tipo) {
            List<int> _lista = new List<int>();
            using (GTI_Context db = new GTI_Context(_connection)) {
                string _doc = dalCore.RetornaNumero(Documento);

                List<int> _codigos;
                //procura imóvel
                if (_tipo == TipoDocumento.Cpf) {
                    _codigos = (from i in db.Cadimob join p in db.Proprietario on i.Codreduzido equals p.Codreduzido join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                               where p.Tipoprop == "P" && p.Principal == true && c.Cpf.Contains(_doc) select i.Codreduzido).ToList();
                } else {
                    _codigos = (from i in db.Cadimob join p in db.Proprietario on i.Codreduzido equals p.Codreduzido join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                               where p.Tipoprop == "P" && p.Principal == true && c.Cnpj.Contains(_doc) select i.Codreduzido).ToList();
                }
                foreach (int item in _codigos) {
                    _lista.Add(item);
                }

                _codigos.Clear();
                //procura empresa
                if (_tipo == TipoDocumento.Cpf) {
                    _codigos = (from m in db.Mobiliario where m.Cpf.Contains(_doc) select m.Codigomob).ToList();
                } else {
                    _codigos = (from m in db.Mobiliario where m.Cnpj.Contains(_doc) select m.Codigomob).ToList();
                }
                foreach (int item in _codigos) {
                    _lista.Add(item);
                }

                _codigos.Clear();
                //procura cidadão
                if (_tipo == TipoDocumento.Cpf) {
                    _codigos = (from c in db.Cidadao where c.Cpf.Contains(_doc) select c.Codcidadao).ToList();
                } else {
                    _codigos = (from c in db.Cidadao where c.Cnpj.Contains(_doc) select c.Codcidadao).ToList();
                }
                foreach (int item in _codigos) {
                    _lista.Add(item);
                }



            }

            return _lista;
        }



        public Contribuinte_Header_Struct Contribuinte_Header(int Codigo, TipoCadastro Tipo) {
            Contribuinte_Header_Struct reg = new Contribuinte_Header_Struct {
                Codigo = Codigo,
                Tipo = Tipo
            };
            if (Tipo == TipoCadastro.Imovel) {
                Imovel_Data imovel_Class = new Imovel_Data(_connection);
                bool Existe = imovel_Class.Existe_Imovel(Codigo);
                if (!Existe)
                    return null;
                List<ProprietarioStruct> ListaProp = imovel_Class.Lista_Proprietario(Codigo, true);
                reg.Nome = ListaProp[0].Nome;
                reg.Cpf_cnpj = ListaProp[0].CPF;
                ImovelStruct RegImovel = imovel_Class.Dados_Imovel(Codigo);
                reg.Inscricao = RegImovel.Inscricao;
                reg.Endereco = RegImovel.NomeLogradouro;
                reg.Numero = (short)RegImovel.Numero;
                reg.Complemento = RegImovel.Complemento;
                reg.Nome_bairro = RegImovel.NomeBairro;
                reg.Nome_cidade = "JABOTICABAL";
                reg.Nome_uf = "SP";
                reg.Cep = RegImovel.Cep;
                reg.Quadra_original = RegImovel.QuadraOriginal;
                reg.Lote_original = RegImovel.LoteOriginal;
                reg.Atividade = "";
                reg.TipoEndereco = RegImovel.EE_TipoEndereco == 0 ? TipoEndereco.Local : RegImovel.EE_TipoEndereco == 1 ? TipoEndereco.Proprietario : TipoEndereco.Entrega;
                reg.Ativo = (bool)RegImovel.Inativo  ? false : true;
            } else if (Tipo == TipoCadastro.Empresa) {
                Empresa_Data empresa_Class = new Empresa_Data(_connection);
                bool Existe = empresa_Class.Existe_Empresa(Codigo);
                if (!Existe)
                    return null;

                EmpresaStruct regEmpresa = empresa_Class.Retorna_Empresa(Codigo);
                reg.Nome = regEmpresa.Razao_social;
                reg.Inscricao = "";
                reg.Cpf_cnpj = regEmpresa.Cpf_cnpj;
                reg.Endereco = regEmpresa.Endereco_nome;
                reg.Numero = (short)regEmpresa.Numero;
                reg.Complemento = regEmpresa.Complemento;
                reg.Nome_bairro = regEmpresa.Bairro_nome;
                reg.Nome_cidade = regEmpresa.Cidade_nome;
                reg.Nome_uf = regEmpresa.UF;
                reg.Cep = regEmpresa.Cep;
                reg.Quadra_original = "";
                reg.Lote_original = "";
                reg.Atividade = regEmpresa.Atividade_extenso;
                reg.Ativo = regEmpresa.Data_Encerramento == null ? true : false;
            } else {
                Cidadao_Data cidadao_Class = new Cidadao_Data(_connection);
                bool Existe = cidadao_Class.ExisteCidadao(Codigo);
                if (!Existe)
                    return null;
                Cidadao regCidadao = cidadao_Class.Retorna_Cidadao(Codigo);
                reg.Nome = regCidadao.Nomecidadao;
                reg.Inscricao = "";
                reg.Cpf_cnpj = regCidadao.Cpf;
                reg.Endereco = regCidadao.Nomelogradouro;
                reg.Numero =regCidadao.Numimovel==null?(short)0:  (short)regCidadao.Numimovel;
                reg.Complemento = regCidadao.Complemento;
                reg.Nome_bairro = regCidadao.Nomebairro;
                reg.Nome_cidade = regCidadao.Nomecidade;
                reg.Nome_uf = regCidadao.Siglauf;
                reg.Cep = regCidadao.Cep.ToString();
                reg.Quadra_original = "";
                reg.Lote_original = "";
                reg.Atividade = "";
                reg.Ativo = true;
            }

            return reg;
        }

        public TipoCadastro Tipo_Cadastro(int Codigo) {
            TipoCadastro _tipo_cadastro;
            if (Codigo < 100000)
                _tipo_cadastro = TipoCadastro.Imovel;
            else {
                if (Codigo >= 100000 && Codigo < 500000)
                    _tipo_cadastro = TipoCadastro.Empresa;
                else
                    _tipo_cadastro = TipoCadastro.Cidadao;
            }
            return _tipo_cadastro;
        }

        public int Retorna_Ultima_Remessa_Cobranca() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Parametros where c.Nomeparam=="COBRANCA" select c.Valparam).FirstOrDefault();
                return Convert.ToInt32(Sql);
            }
        }

        public Exception Atualiza_Codigo_Remessa_Cobranca( ) {
            Parametros p = null;
            using (GTI_Context db = new GTI_Context(_connection)) {
                var _sql = (from c in db.Parametros where c.Nomeparam == "COBRANCA" select c.Valparam).FirstOrDefault();
                int _valor = Convert.ToInt32(_sql) + 1;

                p = db.Parametros.First(i => i.Nomeparam == "COBRANCA");
                p.Valparam = _valor.ToString();
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }




        #region Security

        public Exception Alterar_Senha(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string sLogin = reg.Nomelogin;
                Usuario b = db.Usuario.First(i => i.Nomelogin == sLogin);
                b.Senha2 = reg.Senha2;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public int? Retorna_Ultimo_Codigo_Usuario() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Usuario orderby c.Id descending select c.Id).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_FullName(string loginName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Nomelogin == loginName select u.Nomecompleto).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_FullName(int idUser) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Id == idUser select u.Nomecompleto).FirstOrDefault();
                return Sql;
            }
        }


        public string Retorna_User_LoginName(string fullName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Nomecompleto == fullName select u.Nomelogin).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_LoginName(int idUser) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Id == idUser select u.Nomelogin).FirstOrDefault();
                return Sql;
            }
        }

        public int Retorna_User_LoginId(string loginName) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int Sql = (from u in db.Usuario where u.Nomelogin == loginName select (int)u.Id).FirstOrDefault();
                return Sql;
            }
        }

        public string Retorna_User_Password(string login) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Nomelogin == login select u.Senha2).FirstOrDefault();
                return Sql;
            }
        }

        public List<security_event> Lista_Sec_Eventos() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Security_event orderby t.Id select t).ToList();
                List<security_event> Lista = new List<security_event>();
                foreach (var item in reg) {
                    security_event Linha = new security_event { Id = item.Id, IdMaster = item.IdMaster, Descricao = item.Descricao };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public int GetSizeofBinary (){
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nSize = (from t in db.Security_event orderby t.Id descending select t.Id).FirstOrDefault();
                return nSize;
            }
        }

        public string GetUserBinary(int id) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                string Sql = (from u in db.Usuario where u.Id == id select u.Userbinary).FirstOrDefault();
                if (Sql == null) {
                    Sql = "0";
                    int nSize = GetSizeofBinary();
                    int nDif = nSize - Sql.Length;
                    string sZero = new string('0', nDif);
                    Sql += sZero;
                    return dalCore.Encrypt(Sql);
                }
                    return Sql;
            }
        }

        public List<usuarioStruct> Lista_Usuarios() {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usuario
                           join cc in db.Centrocusto on t.Setor_atual equals cc.Codigo into tcc from cc in tcc.DefaultIfEmpty()
                           where t.Ativo == 1
                           orderby t.Nomecompleto select new { t.Nomelogin, t.Nomecompleto, t.Ativo, t.Id, t.Senha, t.Setor_atual, cc.Descricao }).ToList();
                List<usuarioStruct> Lista = new List<usuarioStruct>();
                foreach (var item in reg) {
                    usuarioStruct Linha = new usuarioStruct {
                        Nome_login = item.Nomelogin,
                        Nome_completo = item.Nomecompleto,
                        Ativo = item.Ativo,
                        Id=item.Id,
                        Senha=item.Senha,
                        Setor_atual=item.Setor_atual,
                        Nome_setor=item.Descricao
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public Exception Incluir_Usuario(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                try {
                    List<SqlParameter> parameters = new List<SqlParameter>();
                    parameters.Add(new SqlParameter("@id", reg.Id));
                    parameters.Add(new SqlParameter("@nomelogin", reg.Nomelogin));
                    parameters.Add(new SqlParameter("@nomecompleto", reg.Nomecompleto));
                    parameters.Add(new SqlParameter("@setor_atual", reg.Setor_atual));

                    db.Database.ExecuteSqlCommand("INSERT INTO usuario2(id,nomelogin,nomecompleto,ativo,setor_atual)" +
                                                  " VALUES(@id,@nomelogin,@nomecompleto,@ativo,@setor_atual)",parameters.ToArray());
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            } 
        }

        public Exception Alterar_Usuario(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                Usuario b = db.Usuario.First(i => i.Id == reg.Id);
                b.Nomecompleto = reg.Nomecompleto;
                b.Nomelogin = reg.Nomelogin;
                b.Setor_atual = reg.Setor_atual;
                b.Ativo = reg.Ativo;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }

        public Exception Alterar_Usuario_Local(List<Usuariocc> reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                db.Database.ExecuteSqlCommand("DELETE FROM usuariocc WHERE userid=@id" ,new SqlParameter("@id", reg[0].Userid));

                List<SqlParameter> parameters = new List<SqlParameter>();
                foreach (Usuariocc item in reg) {
                    try {
                        parameters.Add(new SqlParameter("@Userid", item.Userid));
                        parameters.Add(new SqlParameter("@Codigocc", item.Codigocc));

                        db.Database.ExecuteSqlCommand("INSERT INTO usuariocc(userid,codigocc) VALUES(@Userid,@Codigocc)", parameters.ToArray());
                        parameters.Clear();
                    } catch (Exception ex) {
                        return ex;
                    }
                }
                return null;
            }
        }

        public usuarioStruct Retorna_Usuario(int Id) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usuario
                           join cc in db.Centrocusto on t.Setor_atual equals cc.Codigo into tcc from cc in tcc.DefaultIfEmpty()
                           where t.Id==Id
                           orderby t.Nomelogin select new usuarioStruct {Nome_login= t.Nomelogin,  Nome_completo=t.Nomecompleto,Ativo= t.Ativo,
                               Id=  t.Id, Senha= t.Senha, Setor_atual= t.Setor_atual, Nome_setor= cc.Descricao }).FirstOrDefault();
                usuarioStruct Sql = new usuarioStruct();
                Sql.Id = reg.Id;
                Sql.Nome_completo = reg.Nome_completo;
                Sql.Nome_login = reg.Nome_login;
                Sql.Senha = reg.Senha;
                Sql.Setor_atual = reg.Setor_atual;
                Sql.Nome_setor = reg.Nome_setor;
                Sql.Ativo = reg.Ativo;
                return Sql;
            }
        }

        public List<Usuariocc> Lista_Usuario_Local(int Id) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                var reg = (from cc in db.Usuariocc where cc.Userid == Id orderby cc.Codigocc select cc).ToList();
                return reg;
            }
        }

        public Exception SaveUserBinary(Usuario reg) {
            using (GTI_Context db = new GTI_Context(_connection)) {
                int nId = (int)reg.Id;
                Usuario b = db.Usuario.First(i => i.Id == nId);
                b.Userbinary = reg.Userbinary;
                try {
                    db.SaveChanges();
                } catch (Exception ex) {
                    return ex;
                }
                return null;
            }
        }
        #endregion


    }
}
