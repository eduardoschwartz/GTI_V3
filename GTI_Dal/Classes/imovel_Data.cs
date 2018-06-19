using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GTI_Dal.Classes {
    public class Imovel_Data {

        private string _connection;

        public Imovel_Data(string sConnection) {
            _connection = sConnection;
        }

        public ImovelStruct Dados_Imovel(int nCodigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from i in db.Cadimob
                           join c in db.Condominio on i.Codcondominio equals c.Cd_codigo into ic from c in ic.DefaultIfEmpty()
                           join b in db.Benfeitoria on i.Dt_codbenf equals b.Codbenfeitoria into ib from b in ib.DefaultIfEmpty()
                           join p in db.Pedologia on i.Dt_codpedol equals p.Codpedologia into ip from p in ip.DefaultIfEmpty()
                           join t in db.Topografia on i.Dt_codtopog equals t.Codtopografia into it from t in it.DefaultIfEmpty()
                           join s in db.Situacao on i.Dt_codsituacao equals s.Codsituacao into ist from s in ist.DefaultIfEmpty()
                           join cp in db.Categprop on i.Dt_codcategprop equals cp.Codcategprop into icp from cp in icp.DefaultIfEmpty()
                           join u in db.Usoterreno on i.Dt_codusoterreno equals u.Codusoterreno into iu from u in iu.DefaultIfEmpty()
                           where i.Codreduzido == nCodigo
                           select new ImovelStruct { Codigo = i.Codreduzido, Distrito = i.Distrito, Setor = i.Setor, Quadra = i.Quadra, Lote = i.Lote, Seq = i.Seq,
                               Unidade = i.Unidade, SubUnidade = i.Subunidade, NomeCondominio = c.Cd_nomecond, Imunidade = i.Imune, TipoMat = i.Tipomat, NumMatricula = i.Nummat,
                               Numero = i.Li_num, Complemento = i.Li_compl, QuadraOriginal = i.Li_quadras, LoteOriginal = i.Li_lotes, ResideImovel = i.Resideimovel, Inativo = i.Inativo,
                               FracaoIdeal = i.Dt_fracaoideal, Area_Terreno = i.Dt_areaterreno, Benfeitoria = i.Dt_codbenf, Categoria = i.Dt_codcategprop, Pedologia = i.Dt_codpedol, Topografia = i.Dt_codtopog,
                               Uso_terreno = i.Dt_codusoterreno, Situacao = i.Dt_codsituacao, EE_TipoEndereco = i.Ee_tipoend, Benfeitoria_Nome = b.Descbenfeitoria, Pedologia_Nome = p.Descpedologia,
                               Topografia_Nome = t.Desctopografia, Situacao_Nome = s.Descsituacao, Categoria_Nome = cp.Desccategprop, Uso_terreno_Nome = u.Descusoterreno, CodigoCondominio = c.Cd_codigo
                           }).FirstOrDefault();

                ImovelStruct row = new ImovelStruct();
                if (reg == null)
                    return row;
                row.Codigo = nCodigo;
                row.Distrito = reg.Distrito;
                row.Setor = reg.Setor;
                row.Quadra = reg.Quadra;
                row.Lote = reg.Lote;
                row.Seq = reg.Seq;
                row.Unidade = reg.Unidade;
                row.SubUnidade = reg.SubUnidade;
                row.Inscricao=  reg.Distrito.ToString() + reg.Setor.ToString("00") + reg.Quadra.ToString("0000") + reg.Lote.ToString("00000") + reg.Seq.ToString("00") + reg.Unidade.ToString("00") + reg.SubUnidade.ToString("000");
                row.CodigoCondominio = reg.CodigoCondominio;
                row.NomeCondominio = reg.NomeCondominio.ToString();
                row.Imunidade = reg.Imunidade == null ? false : Convert.ToBoolean(reg.Imunidade);
                row.ResideImovel = reg.ResideImovel == null ? false : Convert.ToBoolean(reg.ResideImovel);
                row.Inativo = reg.Inativo == null ? false : Convert.ToBoolean(reg.Inativo);
                if (reg.TipoMat == null || reg.TipoMat == "M")
                    row.TipoMat =  "M";
                else
                    row.TipoMat ="T";
                row.NumMatricula = reg.NumMatricula;
                row.QuadraOriginal = reg.QuadraOriginal == null ? "" : reg.QuadraOriginal.ToString();
                row.LoteOriginal = reg.LoteOriginal == null ? "" : reg.LoteOriginal.ToString();
                row.FracaoIdeal = reg.FracaoIdeal;
                row.Area_Terreno = reg.Area_Terreno;
                row.Benfeitoria = reg.Benfeitoria;
                row.Benfeitoria_Nome = reg.Benfeitoria_Nome;
                row.Categoria = reg.Categoria;
                row.Categoria_Nome = reg.Categoria_Nome;
                row.Pedologia = reg.Pedologia;
                row.Pedologia_Nome = reg.Pedologia_Nome;
                row.Situacao = reg.Situacao;
                row.Situacao_Nome = reg.Situacao_Nome;
                row.Topografia = reg.Topografia;
                row.Topografia_Nome = reg.Topografia_Nome;
                row.Uso_terreno = reg.Uso_terreno;
                row.Uso_terreno_Nome = reg.Uso_terreno_Nome;
                row.EE_TipoEndereco = reg.EE_TipoEndereco;

                EnderecoStruct regEnd = Dados_Endereco(nCodigo, dalCore.TipoEndereco.Local);
                row.CodigoLogradouro = regEnd.CodLogradouro;
                row.NomeLogradouro = regEnd.Endereco;
                row.Numero = regEnd.Numero;
                row.Complemento = regEnd.Complemento;
                row.Cep = regEnd.Cep;
                row.CodigoBairro = regEnd.CodigoBairro;
                row.NomeBairro = regEnd.NomeBairro;
                
                return row;
            }
        }//End LoadReg

        public decimal Soma_Area(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var sum = db.Areas.Where(x=>x.Codreduzido==Codigo).Sum(x => x.Areaconstr);
                return Convert.ToDecimal(sum);
            }
        }

        public int Qtde_Imovel_Cidadao(int CodigoImovel) {
            using (var db = new GTI_Context(_connection)) {
                int Sql = (from v in db.Vwproprietarioduplicado join p in db.Proprietario on v.Codproprietario equals p.Codcidadao where p.Codreduzido == CodigoImovel && p.Tipoprop == "P" select v.Qtdeimovel).FirstOrDefault();
                    return Sql;
            }
        }

        public List<ProprietarioStruct> Lista_Proprietario(int CodigoImovel, bool Principal = false) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from p in db.Proprietario
                           join c in db.Cidadao on p.Codcidadao equals c.Codcidadao
                           where p.Codreduzido == CodigoImovel
                           select new { p.Codcidadao, c.Nomecidadao, p.Tipoprop, p.Principal,c.Cpf,c.Cnpj });

                if (Principal)
                    reg = reg.Where(u => u.Tipoprop == "P" && u.Principal == true);

                List<ProprietarioStruct> Lista = new List<ProprietarioStruct>();
                foreach (var query in reg) {
                    string sDoc;
                    if (!string.IsNullOrEmpty(query.Cpf) && query.Cpf.ToString().Length > 5)
                        sDoc = query.Cpf;
                    else {
                        if (!string.IsNullOrEmpty(query.Cnpj) && query.Cnpj.ToString().Length > 10)
                            sDoc = query.Cnpj;
                        else
                            sDoc = "";
                    }

                    ProprietarioStruct Linha = new ProprietarioStruct {
                        Codigo = query.Codcidadao,
                        Nome = query.Nomecidadao,
                        Tipo = query.Tipoprop,
                        Principal = Convert.ToBoolean(query.Principal),
                        CPF= sDoc
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<LogradouroStruct> Lista_Logradouro(String Filter = "") {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from l in db.Logradouro
                           select new { l.Codlogradouro, l.Endereco });
                if (!String.IsNullOrEmpty(Filter))
                    reg = reg.Where(u => u.Endereco.Contains(Filter));

                List<LogradouroStruct> Lista = new List<LogradouroStruct>();
                foreach (var query in reg) {
                    LogradouroStruct Linha = new LogradouroStruct {
                        CodLogradouro = query.Codlogradouro,
                        Endereco = query.Endereco
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public bool Existe_Imovel(int nCodigo) {
            bool bRet = false;
            using (var db = new GTI_Context(_connection)) {
                var existingReg = db.Cadimob.Count(a => a.Codreduzido == nCodigo);
                if (existingReg != 0) {
                    bRet = true;
                }
            }
            return bRet;
        }

        public EnderecoStruct Dados_Endereco(int Codigo, dalCore.TipoEndereco Tipo) {
            EnderecoStruct regEnd = new EnderecoStruct();
            using (var db = new GTI_Context(_connection)) {
                if (Tipo == dalCore.TipoEndereco.Local) {
                    var reg = (from i in db.Cadimob
                               join b in db.Bairro on i.Li_codbairro equals b.Codbairro into ib from b in ib.DefaultIfEmpty()
                               join fq in db.Facequadra on new { p1 = i.Distrito, p2 = i.Setor, p3 = i.Quadra, p4 = i.Seq } equals new { p1 = fq.Coddistrito, p2 = fq.Codsetor, p3 = fq.Codquadra, p4 = fq.Codface } into ifq from fq in ifq.DefaultIfEmpty()
                               join l in db.Logradouro on fq.Codlogr equals l.Codlogradouro into lfq from l in lfq.DefaultIfEmpty()
                               where i.Codreduzido == Codigo && b.Siglauf == "SP" && b.Codcidade == 413
                               select new {
                                   i.Li_num, i.Li_codbairro, b.Descbairro, fq.Codlogr, l.Endereco, i.Li_compl
                               }).FirstOrDefault();
                    if (reg == null)
                        return regEnd;
                    else {
                        regEnd.CodigoBairro = reg.Li_codbairro;
                        regEnd.NomeBairro = reg.Descbairro.ToString();
                        regEnd.CodigoCidade = 413;
                        regEnd.NomeCidade = "JABOTICABAL";
                        regEnd.UF = "SP";
                        regEnd.CodLogradouro = reg.Codlogr;
                        regEnd.Endereco = reg.Endereco.ToString();
                        regEnd.Numero = reg.Li_num;
                        regEnd.Complemento = reg.Li_compl ?? "";
                        regEnd.CodigoBairro = reg.Li_codbairro;
                        regEnd.NomeBairro = reg.Descbairro;
                        Endereco_Data clsCep = new Endereco_Data(_connection);
                        regEnd.Cep = clsCep.RetornaCep(Convert.ToInt32(reg.Codlogr), Convert.ToInt16(reg.Li_num)) == 0 ? "14870000" : clsCep.RetornaCep(Convert.ToInt32(reg.Codlogr), Convert.ToInt16(reg.Li_num)).ToString("0000");
                    }
                } else if (Tipo == dalCore.TipoEndereco.Entrega) {
                    var reg = (from ee in db.Endentrega
                               join b in db.Bairro on new { p1 = ee.Ee_uf, p2 = ee.Ee_cidade, p3 = ee.Ee_bairro } equals new { p1 = b.Siglauf, p2 = (short?)b.Codcidade, p3 = (short?)b.Codbairro } into eeb from b in eeb.DefaultIfEmpty()
                               join c in db.Cidade on new { p1 = ee.Ee_uf, p2 = ee.Ee_cidade } equals new { p1 = c.Siglauf, p2 = (short?)c.Codcidade } into eec from c in eec.DefaultIfEmpty()
                               join l in db.Logradouro on ee.Ee_codlog equals l.Codlogradouro into lee from l in lee.DefaultIfEmpty()
                               where ee.Codreduzido == Codigo
                               select new {
                                   ee.Ee_numimovel, ee.Ee_bairro, b.Descbairro, c.Desccidade, ee.Ee_uf, ee.Ee_cidade, ee.Ee_codlog, ee.Ee_nomelog, l.Endereco, ee.Ee_complemento
                               }).FirstOrDefault();
                    if (reg == null)
                        return regEnd;
                    else {
                        regEnd.CodigoBairro = reg.Ee_bairro;
                        regEnd.NomeBairro = reg.Descbairro.ToString();
                        regEnd.CodigoCidade = reg.Ee_cidade;
                        regEnd.NomeCidade = reg.Desccidade;
                        regEnd.UF = "SP";
                        regEnd.CodLogradouro = reg.Ee_codlog;
                        regEnd.Endereco = reg.Ee_nomelog.ToString();
                        if (String.IsNullOrEmpty(regEnd.Endereco))
                            regEnd.Endereco = reg.Endereco.ToString();
                        regEnd.Numero = reg.Ee_numimovel;
                        regEnd.Complemento = reg.Ee_complemento ?? "";
                        regEnd.CodigoBairro = reg.Ee_bairro;
                        regEnd.NomeBairro = reg.Descbairro;
                        Endereco_Data clsCep = new Endereco_Data(_connection);
                        regEnd.Cep = clsCep.RetornaCep(Convert.ToInt32(regEnd.CodLogradouro), Convert.ToInt16(reg.Ee_numimovel)) == 0 ? "00000000" : clsCep.RetornaCep(Convert.ToInt32(regEnd.CodLogradouro), Convert.ToInt16(reg.Ee_numimovel)).ToString("0000");
                    }
                } else if (Tipo == dalCore.TipoEndereco.Proprietario) {
                    List<ProprietarioStruct> _lista_proprietario = Lista_Proprietario(Codigo, true);
                    int _codigo_proprietario = _lista_proprietario[0].Codigo;
                    Cidadao_Data clsCidadao = new Cidadao_Data(_connection);
                    CidadaoStruct _cidadao = clsCidadao.LoadReg(_codigo_proprietario);
                    if (_cidadao.EtiquetaC == "S" ) {
                        regEnd.Endereco = _cidadao.EnderecoC;
                        regEnd.Numero = _cidadao.NumeroC;
                        regEnd.Complemento = _cidadao.ComplementoC;
                        regEnd.CodigoBairro = _cidadao.CodigoBairroC;
                        regEnd.NomeBairro = _cidadao.NomeBairroC;
                        regEnd.CodigoCidade = _cidadao.CodigoCidadeC;
                        regEnd.NomeCidade = _cidadao.NomeCidadeC;
                        regEnd.UF = _cidadao.UfC;
                        regEnd.Cep = _cidadao.CepC.ToString();
                    } else {
                        regEnd.Endereco = _cidadao.EnderecoR;
                        regEnd.Numero = _cidadao.NumeroR;
                        regEnd.Complemento = _cidadao.ComplementoR;
                        regEnd.CodigoBairro = _cidadao.CodigoBairroR;
                        regEnd.NomeBairro = _cidadao.NomeBairroR;
                        regEnd.CodigoCidade = _cidadao.CodigoCidadeR;
                        regEnd.NomeCidade = _cidadao.NomeCidadeR;
                        regEnd.UF = _cidadao.UfR;
                        regEnd.Cep = _cidadao.CepR.ToString();
                    }
                }
            }

            return regEnd;
        }

        public List<Categprop> Lista_Categoria_Propriedade() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from c in db.Categprop where c.Codcategprop != 999 orderby c.Desccategprop select new {c.Codcategprop,c.Desccategprop}).ToList();
                List<Categprop> Lista = new List<Categprop>();
                foreach (var item in reg) {
                    Categprop Linha = new Categprop {
                        Codcategprop = item.Codcategprop,
                        Desccategprop = item.Desccategprop
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Topografia> Lista_Topografia() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Topografia where t.Codtopografia != 999 orderby t.Desctopografia select new { t.Codtopografia,t.Desctopografia }).ToList();
                List<Topografia> Lista = new List<Topografia>();
                foreach (var item in reg) {
                    Topografia Linha = new Topografia {
                        Codtopografia = item.Codtopografia,
                        Desctopografia = item.Desctopografia
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Situacao> Lista_Situacao() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Situacao where t.Codsituacao != 999 orderby t.Descsituacao select new { t.Codsituacao, t.Descsituacao }).ToList();
                List<Situacao> Lista = new List<Situacao>();
                foreach (var item in reg) {
                    Situacao Linha = new Situacao {
                        Codsituacao = item.Codsituacao,
                        Descsituacao = item.Descsituacao
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Benfeitoria> Lista_Benfeitoria() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Benfeitoria where t.Codbenfeitoria != 999 orderby t.Descbenfeitoria select new { t.Codbenfeitoria, t.Descbenfeitoria }).ToList();
                List<Benfeitoria> Lista = new List<Benfeitoria>();
                foreach (var item in reg) {
                    Benfeitoria Linha = new Benfeitoria {
                        Codbenfeitoria = item.Codbenfeitoria,
                        Descbenfeitoria = item.Descbenfeitoria
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Pedologia> Lista_Pedologia() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Pedologia where t.Codpedologia != 999 orderby t.Descpedologia select new { t.Codpedologia, t.Descpedologia }).ToList();
                List<Pedologia> Lista = new List<Pedologia>();
                foreach (var item in reg) {
                    Pedologia Linha = new Pedologia {
                        Codpedologia = item.Codpedologia,
                        Descpedologia = item.Descpedologia
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Usoterreno> Lista_Uso_Terreno() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usoterreno where t.Codusoterreno != 999 orderby t.Descusoterreno select new { t.Codusoterreno, t.Descusoterreno }).ToList();
                List<Usoterreno> Lista = new List<Usoterreno>();
                foreach (var item in reg) {
                    Usoterreno Linha = new Usoterreno {
                        Codusoterreno = item.Codusoterreno,
                        Descusoterreno = item.Descusoterreno
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Usoconstr> Lista_Uso_Construcao() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Usoconstr where t.Codusoconstr != 999 orderby t.Descusoconstr select new { t.Codusoconstr, t.Descusoconstr }).ToList();
                List<Usoconstr> Lista = new List<Usoconstr>();
                foreach (var item in reg) {
                    Usoconstr Linha = new Usoconstr {
                        Codusoconstr = item.Codusoconstr,
                        Descusoconstr = item.Descusoconstr
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Categconstr> Lista_Categoria_Construcao() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from c in db.Categconstr where c.Codcategconstr != 999 orderby c.Desccategconstr select new { c.Codcategconstr, c.Desccategconstr }).ToList();
                List<Categconstr> Lista = new List<Categconstr>();
                foreach (var item in reg) {
                    Categconstr Linha = new Categconstr {
                        Codcategconstr = item.Codcategconstr,
                        Desccategconstr = item.Desccategconstr
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Tipoconstr> Lista_Tipo_Construcao() {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from c in db.Tipoconstr where c.Codtipoconstr != 999 orderby c.Desctipoconstr select new { c.Codtipoconstr, c.Desctipoconstr }).ToList();
                List<Tipoconstr> Lista = new List<Tipoconstr>();
                foreach (var item in reg) {
                    Tipoconstr Linha = new Tipoconstr {
                        Codtipoconstr = item.Codtipoconstr,
                        Desctipoconstr = item.Desctipoconstr
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Testada> Lista_Testada(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Testada where t.Codreduzido == Codigo orderby t.Numface select t).ToList();
                List<Testada> Lista = new List<Testada>();
                foreach (var item in reg) {
                    Testada Linha = new Testada {
                        Codreduzido = item.Codreduzido,
                        Numface = item.Numface,
                        Areatestada = item.Areatestada
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<AreaStruct> Lista_Area(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from a in db.Areas
                           join c in db.Categconstr on a.Catconstr equals c.Codcategconstr into ac from c in ac.DefaultIfEmpty()
                           join t in db.Tipoconstr on a.Tipoconstr equals t.Codtipoconstr into at from t in at.DefaultIfEmpty()
                           join u in db.Usoconstr on a.Usoconstr equals u.Codusoconstr into au from u in au.DefaultIfEmpty()
                           where a.Codreduzido == Codigo orderby a.Seqarea select new AreaStruct { Codigo=a.Codreduzido,Data_Aprovacao=a.Dataaprova,Area=(decimal)a.Areaconstr,Categoria_Codigo=a.Catconstr,
                           Tipo_Nome=t.Desctipoconstr ,Categoria_Nome=c.Desccategconstr,Data_Processo=a.Dataprocesso,Numero_Processo=a.Numprocesso,Pavimentos=a.Qtdepav,Seq=a.Seqarea,Tipo_Area=a.Tipoarea,Tipo_Codigo=a.Tipoconstr,
                           Uso_Codigo=a.Usoconstr,Uso_Nome=u.Descusoconstr}).ToList();
                List<AreaStruct> Lista = new List<AreaStruct>();
                foreach (var item in reg) {
                    AreaStruct Linha = new AreaStruct {
                        Codigo = item.Codigo,
                        Seq = item.Seq,
                        Area = item.Area,
                        Categoria_Codigo = item.Categoria_Codigo,
                        Categoria_Nome = item.Categoria_Nome,
                        Uso_Codigo = item.Uso_Codigo,
                        Uso_Nome = item.Uso_Nome,
                        Tipo_Codigo = item.Tipo_Codigo,
                        Tipo_Nome = item.Tipo_Nome,
                        Pavimentos = item.Pavimentos,
                        Numero_Processo = item.Numero_Processo,
                        Data_Processo = item.Data_Processo,
                        Data_Aprovacao = item.Data_Aprovacao,
                        Tipo_Area = item.Tipo_Area
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public ImovelStruct Inscricao_imovel(int Logradouro, short Numero) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from i in db.Cadimob
                           join f in db.Facequadra on new { p1 = i.Distrito, p2 = i.Setor, p3 = i.Quadra, p4 = i.Seq } equals new { p1 = f.Coddistrito, p2 = f.Codsetor, p3 = f.Codquadra, p4 = f.Codface } into fi from f in fi.DefaultIfEmpty()
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into lf from l in lf.DefaultIfEmpty()
                           where f.Codlogr == Logradouro && i.Li_num == Numero
                           select new ImovelStruct {Codigo=i.Codreduzido,
                               Distrito = i.Distrito, Setor = i.Setor, Quadra = i.Quadra, Lote = i.Lote, Seq = i.Seq, Unidade = i.Unidade, SubUnidade = i.Subunidade
                           }).FirstOrDefault();

                ImovelStruct row = new ImovelStruct();
                if (reg == null)
                    return row;
                row.Codigo = reg.Codigo;
                row.Distrito = reg.Distrito;
                row.Setor = reg.Setor;
                row.Quadra = reg.Quadra;
                row.Lote = reg.Lote;
                row.Seq = reg.Seq;
                row.Unidade = reg.Unidade;
                row.SubUnidade = reg.SubUnidade;

                return row;
            }
        }

        public List<Condominio> Lista_Condominio() {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from e in db.Condominio where e.Cd_codigo > 0 orderby e.Cd_nomecond select e).ToList();
                return Sql;
            }
        }

        public CondominioStruct Dados_Condominio(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from m in db.Condominio
                           join b in db.Bairro on m.Cd_codbairro equals b.Codbairro into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Cd_codcidade, p2 = m.Cd_uf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join f in db.Facequadra on new { p1 = m.Cd_distrito, p2 = m.Cd_setor, p3 = m.Cd_quadra, p4 = m.Cd_seq } equals new { p1 = f.Coddistrito, p2 = f.Codsetor, p3 = f.Codquadra, p4 = f.Codface } into mf from f in mf.DefaultIfEmpty()
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           join bf in db.Benfeitoria on m.Cd_codbenf equals bf.Codbenfeitoria into ib from bf in ib.DefaultIfEmpty()
                           join pd in db.Pedologia on m.Cd_codpedol equals pd.Codpedologia into ip from pd in ip.DefaultIfEmpty()
                           join tp in db.Topografia on m.Cd_codtopog equals tp.Codtopografia into it from tp in it.DefaultIfEmpty()
                           join st in db.Situacao on m.Cd_codsituacao equals st.Codsituacao into ist from st in ist.DefaultIfEmpty()
                           join cp in db.Categprop on m.Cd_codcategprop equals cp.Codcategprop into icp from cp in icp.DefaultIfEmpty()
                           join u in db.Usoterreno on m.Cd_codusoterreno equals u.Codusoterreno into iu from u in iu.DefaultIfEmpty()
                           where m.Cd_codigo == Codigo
                           select new CondominioStruct {
                               Codigo = m.Cd_codigo, Nome = m.Cd_nomecond, Codigo_Logradouro = f.Codlogr, Nome_Logradouro = l.Endereco, Numero = m.Cd_num, Cep = m.Cd_cep,
                               Complemento = m.Cd_compl, Codigo_Bairro = m.Cd_codbairro, Nome_Bairro = b.Descbairro, Area_Construida = m.Cd_areatotconstr, Area_Terreno = m.Cd_areaterreno,
                               Benfeitoria = m.Cd_codbenf, Categoria = m.Cd_codcategprop, Fracao_Ideal = m.Cd_fracao, Pedologia = m.Cd_codpedol, Lote_Original = m.Cd_lotes, Quadra_Original = m.Cd_quadras,
                               Situacao = m.Cd_codsituacao, Topografia = m.Cd_codtopog, Uso_terreno = m.Cd_codusoterreno, Codigo_Proprietario = m.Cd_prop, Qtde_Unidade = m.Cd_numunid, Distrito = m.Cd_distrito,
                               Setor = m.Cd_setor, Quadra = m.Cd_quadra, Lote = m.Cd_lote, Seq = m.Cd_seq, Benfeitoria_Nome = bf.Descbenfeitoria, Categoria_Nome = cp.Desccategprop, Pedologia_Nome = pd.Descpedologia,
                               Situacao_Nome = st.Descsituacao, Topografia_Nome = tp.Desctopografia, Uso_terreno_Nome = u.Descusoterreno
                           }).FirstOrDefault();

                CondominioStruct row = new CondominioStruct();
                if (reg == null)
                    return row;
                row.Codigo = reg.Codigo;
                row.Nome = reg.Nome;
                row.Codigo_Logradouro = reg.Codigo_Logradouro;
                row.Nome_Logradouro = reg.Nome_Logradouro;
                row.Numero = reg.Numero;
                row.Complemento = reg.Complemento;
                row.Codigo_Bairro = reg.Codigo_Bairro;
                row.Nome_Bairro = reg.Nome_Bairro;
                row.Distrito = reg.Distrito;
                row.Setor = reg.Setor;
                row.Quadra = reg.Quadra;
                row.Lote = reg.Lote;
                row.Seq = reg.Seq;
                row.Area_Construida = reg.Area_Construida;
                row.Area_Terreno = reg.Area_Terreno;
                row.Benfeitoria = reg.Benfeitoria;
                row.Benfeitoria_Nome = reg.Benfeitoria_Nome;
                row.Categoria = reg.Categoria;
                row.Categoria_Nome = reg.Categoria_Nome;
                row.Cep = reg.Cep;
                row.Codigo_Proprietario = reg.Codigo_Proprietario;
                row.Fracao_Ideal = reg.Fracao_Ideal;
                row.Lote_Original = reg.Lote_Original;
                row.Pedologia = reg.Pedologia;
                row.Pedologia_Nome = reg.Pedologia_Nome;
                row.Qtde_Unidade = reg.Qtde_Unidade;
                row.Quadra_Original = reg.Quadra_Original;
                row.Situacao = reg.Situacao;
                row.Situacao_Nome = reg.Situacao_Nome;
                row.Topografia = reg.Topografia;
                row.Topografia_Nome = reg.Topografia_Nome;
                row.Uso_terreno = reg.Uso_terreno;
                row.Uso_terreno_Nome = reg.Uso_terreno_Nome;

                if (reg.Codigo_Logradouro > 0) {
                    Endereco_Data Cep_Class = new Endereco_Data(_connection);
                    int nCep = Cep_Class.RetornaCep((int)reg.Codigo_Logradouro, (short)reg.Numero);
                    row.Cep = nCep == 0 ? "00000000" : nCep.ToString("0000");
                }

                return row;
            }
        }

        public List<AreaStruct> Lista_Area_Condominio(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from a in db.CondominioArea
                           join c in db.Categconstr on a.Catconstr equals c.Codcategconstr into ac from c in ac.DefaultIfEmpty()
                           join t in db.Tipoconstr on a.Tipoconstr equals t.Codtipoconstr into at from t in at.DefaultIfEmpty()
                           join u in db.Usoconstr on a.Usoconstr equals u.Codusoconstr into au from u in au.DefaultIfEmpty()
                           where a.Codcondominio == Codigo orderby a.Seqarea select new AreaStruct {
                               Codigo = a.Codcondominio, Data_Aprovacao = a.Dataaprova, Area = a.Areaconstr, Categoria_Codigo = a.Catconstr, Tipo_Nome = t.Desctipoconstr, Categoria_Nome = c.Desccategconstr,
                               Data_Processo = a.Dataprocesso, Numero_Processo = a.Numprocesso, Pavimentos = a.Qtdepav, Seq = a.Seqarea, Tipo_Area = a.Tipoarea, Tipo_Codigo = a.Tipoconstr,
                               Uso_Codigo = a.Usoconstr, Uso_Nome = u.Descusoconstr
                           }).ToList();
                List<AreaStruct> Lista = new List<AreaStruct>();
                foreach (var item in reg) {
                    AreaStruct Linha = new AreaStruct {
                        Codigo = item.Codigo,
                        Seq = item.Seq,
                        Area = item.Area,
                        Categoria_Codigo = item.Categoria_Codigo,
                        Categoria_Nome = item.Categoria_Nome,
                        Uso_Codigo = item.Uso_Codigo,
                        Uso_Nome = item.Uso_Nome,
                        Tipo_Codigo = item.Tipo_Codigo,
                        Tipo_Nome = item.Tipo_Nome,
                        Pavimentos = item.Pavimentos,
                        Numero_Processo = item.Numero_Processo,
                        Data_Processo = item.Data_Processo,
                        Data_Aprovacao = item.Data_Aprovacao,
                        Tipo_Area = item.Tipo_Area
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Testadacondominio> Lista_Testada_Condominio(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.Testadacondominio where t.Codcond == Codigo orderby t.Numface select t).ToList();
                List<Testadacondominio> Lista = new List<Testadacondominio>();
                foreach (var item in reg) {
                    Testadacondominio Linha = new Testadacondominio {
                        Codcond = item.Codcond,
                        Numface = item.Numface,
                        Areatestada = item.Areatestada
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<Condominiounidade> Lista_Unidade_Condominio(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from t in db.CondominioUnidade where t.Cd_codigo == Codigo orderby new { t.Cd_unidade,t.Cd_subunidades } select t).ToList();
                List<Condominiounidade> Lista = new List<Condominiounidade>();
                foreach (var item in reg) {
                    Condominiounidade Linha = new Condominiounidade {
                        Cd_codigo = item.Cd_codigo,
                        Cd_unidade = item.Cd_unidade,
                        Cd_subunidades = item.Cd_subunidades
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }

        public List<ImovelStruct> Lista_Imovel(ImovelStruct Reg) {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from c in db.Cadimob
                           join f in db.Facequadra on new { p1 = c.Distrito, p2 = c.Setor, p3 = c.Quadra, p4 = c.Seq } equals new { p1 = f.Coddistrito, p2 = f.Codsetor, p3 = f.Codquadra, p4 = f.Codface } into fc from f in fc.DefaultIfEmpty()
                           join l in db.Logradouro on f.Codlogr equals l.Codlogradouro into fl from l in fl.DefaultIfEmpty()
                           join b in db.Bairro on new { p1 = c.Li_uf, p2 = (short)c.Li_codcidade, p3 = (short)c.Li_codbairro } equals new { p1 = b.Siglauf, p2 = b.Codcidade, p3 = b.Codbairro } into cb from b in cb.DefaultIfEmpty()
                           join o in db.Condominio on c.Codcondominio equals o.Cd_codigo into co from o in co.DefaultIfEmpty()
                           join p in db.Proprietario on c.Codreduzido equals p.Codreduzido into pc from p in pc.DefaultIfEmpty()
                           join i in db.Cidadao on p.Codcidadao equals i.Codcidadao into ip from i in ip.DefaultIfEmpty()
                           orderby c.Codreduzido
                           select new ImovelStruct {
                               Codigo = c.Codreduzido, Distrito = c.Distrito, Setor = c.Setor, Quadra = c.Quadra, Lote = c.Lote, Seq = c.Seq, Unidade = c.Unidade,
                               SubUnidade = c.Subunidade, Proprietario_Codigo = p.Codcidadao, Proprietario_Nome = i.Nomecidadao, Proprietario_Principal = p.Principal, CodigoLogradouro = f.Codlogr,
                               NomeLogradouro = l.Endereco, Numero = c.Li_num, CodigoCondominio = c.Codcondominio, NomeCondominio = o.Cd_nomecond,CodigoBairro=c.Li_codbairro,NomeBairro=b.Descbairro,
                               Complemento=c.Li_compl
                           });
                if (Reg.Codigo > 0)
                    Sql = Sql.Where(c => c.Codigo == Reg.Codigo);
                if (Reg.Proprietario_Codigo > 0)
                    Sql = Sql.Where(c => c.Proprietario_Codigo == Reg.Proprietario_Codigo);
                if (Convert.ToBoolean(Reg.Proprietario_Principal))
                    Sql = Sql.Where(c => c.Proprietario_Principal == Reg.Proprietario_Principal);
                if (Reg.Distrito > 0)
                    Sql = Sql.Where(c => c.Distrito == Reg.Distrito);
                if (Reg.Setor > 0)
                    Sql = Sql.Where(c => c.Setor == Reg.Setor);
                if (Reg.Quadra > 0)
                    Sql = Sql.Where(c => c.Quadra == Reg.Quadra);
                if (Reg.Lote > 0)
                    Sql = Sql.Where(c => c.Lote == Reg.Lote);
                if (Reg.CodigoCondominio > 0)
                    Sql = Sql.Where(c => c.CodigoCondominio == Reg.CodigoCondominio);
                if (Reg.CodigoLogradouro > 0)
                    Sql = Sql.Where(c => c.CodigoLogradouro == Reg.CodigoLogradouro);
                if (Reg.CodigoBairro > 0)
                    Sql = Sql.Where(c => c.CodigoBairro == Reg.CodigoBairro);
                if (Reg.Numero > 0)
                    Sql = Sql.Where(c => c.Numero == Reg.Numero);

                List<ImovelStruct> Lista = new List<ImovelStruct>();
                foreach (var item in Sql) {
                    ImovelStruct Linha = new ImovelStruct {
                        Codigo = item.Codigo,
                        Inscricao = item.Distrito.ToString() + "." + item.Setor.ToString("00") + "." + item.Quadra.ToString("0000") + "." + item.Lote.ToString("00000") + "." + item.Seq.ToString("00") + "." + item.Unidade.ToString("00") + "." + item.SubUnidade.ToString("000"),
                        Proprietario_Codigo =item.Proprietario_Codigo,Proprietario_Nome=item.Proprietario_Nome,CodigoLogradouro=item.CodigoLogradouro,NomeLogradouro=item.NomeLogradouro,Numero=item.Numero,NomeCondominio=item.NomeCondominio,
                        CodigoBairro=item.CodigoBairro ,NomeBairro=item.NomeBairro,CodigoCondominio=item.CodigoCondominio,Complemento=item.Complemento
                    };
                    Lista.Add(Linha);
                }
                return Lista.ToList();
            }
        }

        public Laseriptu Dados_IPTU(int Codigo,int Ano) {
            using (var db = new GTI_Context(_connection)) {
                var Sql = (from i in db.Laser_iptu where i.Ano == Ano && i.Codreduzido == Codigo select i).FirstOrDefault();
                return Sql;
            }
        }

        public bool Verifica_Imunidade(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                Cadimob Sql = (from c in db.Cadimob where c.Codreduzido == Codigo select c).FirstOrDefault();
                if (Sql.Imune == null)
                    return false;
                else
                    return Convert.ToBoolean(Sql.Imune);
            }
        }

        public List<IsencaoStruct> Lista_Imovel_Isencao(int Codigo,int Ano=0) {
            using (var db = new GTI_Context(_connection)) {
                Processo_Data processo_Class = new Processo_Data(_connection);
                
                var reg = (from t in db.Isencao where t.Codreduzido == Codigo orderby t.Anoisencao select t).ToList();
                if (Ano > 0)
                    reg = reg.Where(t => t.Anoisencao == Ano).ToList();
                List<IsencaoStruct> Lista = new List<IsencaoStruct>();
                foreach (var item in reg) {
                    IsencaoStruct Linha = new IsencaoStruct {
                        Codreduzido = item.Codreduzido,
                        Anoisencao = item.Anoisencao,
                        Anoproc = item.Anoproc,
                        Codisencao=item.Codisencao,
                        dataaltera=item.dataaltera,
                        dataprocesso= processo_Class.Dados_Processo((short)item.Anoproc,(int)item.Numproc).DataEntrada,
                        Filantropico=item.Filantropico,
                        Motivo=item.Motivo,
                        Numproc=item.Numproc,
                        Numprocesso=item.Numprocesso,
                        Percisencao=item.Percisencao,
                        Periodo=item.Periodo,
                        Userid=item.Userid
                    };
                    Lista.Add(Linha);
                }
                return Lista;
            }
        }


    }//end class
}
