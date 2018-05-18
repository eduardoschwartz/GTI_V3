﻿using GTI_Models.Models;
using System;
using System.Collections.Generic;
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

        public EmpresaStruct Retorna_Empresa(int Codigo) {
            using (var db = new GTI_Context(_connection)) {
                var reg = (from m in db.Mobiliario
                           join b in db.Bairro on new { p1 = (short)m.Codbairro, p2 = (short)m.Codcidade, p3 = m.Siglauf } equals new { p1 = b.Codbairro, p2 = b.Codcidade, p3 = b.Siglauf } into mb from b in mb.DefaultIfEmpty()
                           join c in db.Cidade on new { p1 = (short)m.Codcidade, p2 = m.Siglauf } equals new { p1 = c.Codcidade, p2 = c.Siglauf } into mc from c in mc.DefaultIfEmpty()
                           join l in db.Logradouro on m.Codlogradouro equals l.Codlogradouro into lm from l in lm.DefaultIfEmpty()
                           join h in db.Horariofunc on m.Horario equals h.Codhorario into hm from h in hm.DefaultIfEmpty()
                           where m.Codigomob == Codigo
                           select new EmpresaStruct{Codigo= m.Codigomob, Razao_social= m.Razaosocial,Nome_fantasia=m.Nomefantasia,Endereco_codigo=m.Codlogradouro,Endereco_nome= l.Endereco,Numero=  m.Numero,Complemento= m.Complemento,
                                                    Bairro_codigo=m.Codbairro,Bairro_nome=b.Descbairro,Cidade_codigo=m.Codcidade,Cidade_nome=c.Desccidade,UF=m.Siglauf,Cep=m.Cep,Homepage=m.Homepage,Horario=m.Horario,
                                                    Data_abertura=m.Dataabertura,Numprocesso=m.Numprocesso,Dataprocesso=m.Dataprocesso,Data_Encerramento=m.Dataencerramento,Numprocessoencerramento=m.Numprocencerramento,
                                                    Dataprocencerramento=m.Dataprocencerramento,Inscricao_estadual=m.Inscestadual,Isencao=m.Isencao,Atividade_codigo=m.Codatividade,Atividade_extenso=m.Ativextenso,Area=m.Areatl,
                                                    Codigo_aliquota=m.Codigoaliq,Data_inicial_desconto=m.Datainicialdesc,Data_final_desconto=m.Datafinaldesc,Percentual_desconto=m.Percdesconto,Capital_social=m.Capitalsocial,
                                                    Nome_orgao=m.Nomeorgao,prof_responsavel_codigo=m.Codprofresp,Numero_registro_resp=m.Numregistroresp,Qtde_socio=m.Qtdesocio,Qtde_empregado=m.Qtdeempregado,Responsavel_contabil=m.Respcontabil,
                                                    Rg_responsavel=m.Rgresp,Orgao_emissor_resp=m.Orgaoemisresp,Nome_contato=m.Nomecontato,Cargo_contato=m.Cargocontato,Fone_contato=m.Fonecontato,Fax_contato=m.Faxcontato,
                                                    Email_contato=m.Emailcontato,Vistoria=m.Vistoria,Qtde_profissionais=m.Qtdeprof,Rg=m.Rg,Orgao=m.Orgao,Nome_logradouro=m.Nomelogradouro,Simples=m.Simples,Regime_especial=m.Regespecial,
                                                    Alvara=m.Alvara,Data_simples=m.Datasimples,Isento_taxa=m.Isentotaxa,Mei=m.Mei,Horario_extenso=m.Horarioext,Iss_eletro=m.Isseletro,Dispensa_ie_data=m.Dispensaiedata,
                                                    Dispensa_ie_processo=m.Dispensaieproc,Data_alvara_provisorio=m.Dtalvaraprovisorio,Senha_iss=m.Senhaiss,Inscricao_temporaria=m.Insctemp,Horas_24=m.Horas24,Isento_iss=m.Isentoiss,
                                                    Bombonieri=m.Bombonieri,Emite_nf=m.Emitenf,Danfe=m.Danfe,Imovel=m.Imovel,Sil=m.Sil,Substituto_tributario_issqn=m.Substituto_tributario_issqn,Individual=m.Individual,
                                                    Ponto_agencia=m.Ponto_agencia,Cadastro_vre=m.Cadastro_vre,Liberado_vre=m.Liberado_vre,Cpf=m.Cpf,Cnpj=m.Cnpj
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
                Endereco_Data Cep_Class = new Endereco_Data(_connection);
                //row.Cep = Cep_Class.RetornaCep(Convert.ToInt32(reg.Clogradouro), Convert.ToInt16(reg.Numero)) == 0 ? "00000000" : Cep_Class.RetornaCep(Convert.ToInt32(reg.Codlogradouro), Convert.ToInt16(reg.Numero)).ToString("0000");

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

    }
}
