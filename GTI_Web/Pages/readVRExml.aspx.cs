using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace UIWeb.Pages {
    public partial class readVRExml : System.Web.UI.Page {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e) {
            String s = Request.QueryString["d"];
            if (s != "gti")
                Response.Redirect("~/Pages/gtiMenu.aspx");

        }

        protected void btEnviar_Click(object sender, EventArgs e) {
            if (!FileUpload1.HasFile) {
                Statuslbl.Text = "Selecione um arquivo para enviar";
                return;
            }
//            if (FileUpload1.PostedFile.ContentType.CompareTo("text/xml") == 0 || FileUpload1.PostedFile.ContentType.CompareTo("text/csv") == 0) {
                try {
                    int _value = Convert.ToInt32(TipoArquivoList.SelectedValue);
                    if(_value==1)
                        UploadArquivo();
                    else {
                        if (_value == 2)
                            UploadRedeSimViabilidade();
                    }
                } catch {
                    Statuslbl.Text = "Arquivo inválido!";
                }
        //    } else {
        //        Statuslbl.Text = "Apenas arquivos em Xml ou Csv podem ser enviados";
        //    }
        }

        private void UploadArquivo() {
            String path = Server.MapPath("~/VRExml/");

            if (FileUpload1.PostedFile.ContentLength < 5102400) {
                //string MyPath = @""; // \\networkmachine\foo\bar OR C:\foo\bar
                string MyPathWithoutDriveOrNetworkShare = FileUpload1.PostedFile.FileName.Substring(Path.GetPathRoot(FileUpload1.PostedFile.FileName).Length);

                try {
                    FileUpload1.SaveAs(path + System.IO.Path.GetFileName(MyPathWithoutDriveOrNetworkShare));
                    List<EmpresaStruct>Lista= ReadFile(path +   System.IO.Path.GetFileName( MyPathWithoutDriveOrNetworkShare));
                    if (Lista.Count > 0) {
                        FillListView(Lista);
                        Grava_Empresas_Vre(Lista);
                        foreach (EmpresaStruct reg in Lista) {
                            foreach (DataRow dr in dt.Rows) {
                                if ((string)dr["Seq"] == reg.id) {
                                    if (reg.Already_inDB)
                                        dr["Sit"] = "Duplicado";
                                    else
                                        dr["Sit"] = "Importado";
                                }
                            }
                        }
                        grdMain.DataSource = dt;
                        grdMain.DataBind();
                    } else {
                        Statuslbl.Text = "Arquivo inválido";
                    }
                    Statuslbl.Text = Lista.Count.ToString() + " Empresas analisadas.";
                } catch  {
                    Statuslbl.Text = "Arquivo inválido";
                    throw;
                }
                
            } else
                Statuslbl.Text = "Upload status: Tamanho máximo 5Mb!";
        }

        private void UploadRedeSimViabilidade() {
            String path = Server.MapPath("~/VRExml/");

            if (FileUpload1.PostedFile.ContentLength < 5102400) {
                //string MyPath = @""; // \\networkmachine\foo\bar OR C:\foo\bar
                string MyPathWithoutDriveOrNetworkShare = FileUpload1.PostedFile.FileName.Substring(Path.GetPathRoot(FileUpload1.PostedFile.FileName).Length);

                try {
                    FileUpload1.SaveAs(path + System.IO.Path.GetFileName(MyPathWithoutDriveOrNetworkShare));
                    List<Redesim_viabilidade> Lista = ReadFileViabilidade(path + System.IO.Path.GetFileName(MyPathWithoutDriveOrNetworkShare));
                    if (Lista.Count > 0) {
                        //FillListView(Lista);
                        //Grava_Empresas_Vre(Lista);
                        //foreach (EmpresaStruct reg in Lista) {
                        //    foreach (DataRow dr in dt.Rows) {
                        //        if ((string)dr["Seq"] == reg.id) {
                        //            if (reg.Already_inDB)
                        //                dr["Sit"] = "Duplicado";
                        //            else
                        //                dr["Sit"] = "Importado";
                        //        }
                        //    }
                        //}
                        //grdMain.DataSource = dt;
                        //grdMain.DataBind();
                        Statuslbl.Text = Lista.Count.ToString() + " Empresas analisadas.";
                    } else {
                        Statuslbl.Text = "Arquivo inválido";
                    }
                } catch {
                    Statuslbl.Text = "Arquivo inválido";
                    throw;
                }

            } else
                Statuslbl.Text = "Upload status: Tamanho máximo 5Mb!";
        }


        private void FillListView(List<EmpresaStruct>Lista) {
            try { 
            DataColumn cl = new DataColumn("Seq"); 
            dt.Columns.Add(cl); 
            cl = new DataColumn("Nome"); 
            dt.Columns.Add(cl);
            cl = new DataColumn("Doc");
            dt.Columns.Add(cl);
            cl = new DataColumn("Sit");
            dt.Columns.Add(cl);

            foreach (EmpresaStruct reg in Lista) {
                DataRow dr = dt.NewRow();
                dr[0] = reg.id;
                dr[1] = reg.Nome.Replace ("&amp;","&");
                dr[2] = reg.Cnpj;
                dr[3] = "";
                dt.Rows.Add(dr);  
            }
            grdMain.DataSource = dt;
            grdMain.DataBind();
            } catch  {
                Statuslbl.Text = "Arquivo inválido";
                throw;
            }

        }

        private List<EmpresaStruct> ReadFile(string sFileName) {
            XElement xmlDoc = XElement.Load(sFileName);
            var empresas = (from cust in xmlDoc.Descendants("Empresa")
                            select new EmpresaStruct {
                                id = cust.Attribute("id").Value,
                                Nome = cust.Element("NomeEmpresarial").Value,
                                Cnpj = cust.Element("CNPJ").Value,
                                DataAbertura = Convert.ToDateTime(cust.Element("DataAbertura").Value),
                                Porte = cust.Element("Porte").Value,
                                NumeroRegistro = cust.Element("NumeroRegistro").Value,
                                TipoRegistro = cust.Element("TipoRegistro").Value,
                                TipoMei = cust.Element("TipoMEI").Value,
                                NomeResponsavel = cust.Element("NomeResponsavel").Value,
                                CpfResponsavel = cust.Element("CPFResponsavel").Value,
                                DDDContato1 = (cust.Elements("DDD1").Any() ? cust.Element("DDD1").Value : ""),
                                FoneContato1 = (cust.Elements("Telefone1").Any() ? cust.Element("Telefone1").Value : ""),
                                DDDContato2 = (cust.Elements("DDD2").Any() ? cust.Element("DDD2").Value : ""),
                                FoneContato2 = (cust.Elements("Telefone2").Any() ? cust.Element("Telefone2").Value : ""),
                                EmailContato = (cust.Elements("Email").Any() ? cust.Element("Email").Value : ""),
                                Endereco = (from end in cust.Descendants("Endereco")
                                            select new EnderecoStruct {
                                                Logradouro = end.Element("Logradouro").Value!=null? end.Element("Logradouro").Value:"",
                                                Numero = end.Element("NumeroLogradouro").Value!=null? end.Element("NumeroLogradouro").Value:"",
                                                SetorQuadraLote = end.Element("SetorQuadraLote").Value,
                                                TipoLogradouro = end.Element("TipoLogradouro").Value!=null? end.Element("TipoLogradouro").Value:"",
                                                Complemento = end.Elements("Complemento").Any() ? end.Element("Complemento").Value : "",
                                                Bairro = end.Element("Bairro").Value,
                                                Cidade = end.Element("Municipio") == null ? "" : end.Element("Municipio").Value,
                                                UF = end.Element("UF").Value,
                                                Cep = end.Element("CEP").Value
                                            }).FirstOrDefault(),
                                Atividade = (from atv in cust.Descendants("Atividades")
                                             select new AtividadeStruct {
                                                 Codigo = atv.Elements("CNAE").Select(x => x.Attribute("codigo").Value).Where(s => s != string.Empty).ToArray(),
                                                 Principal = atv.Elements("CNAE").Select(x => x.Attribute("principal").Value).Where(s => s != string.Empty).ToArray(),
                                                 Exercida = atv.Elements("CNAE").Select(x => x.Attribute("exercida").Value).Where(s => s != string.Empty).ToArray()
                                             }).ToList(),
                                ClassifCRCPJ = cust.Element("ClassificacaoCRCContadorPJ").Value,
                                NumeroCRCPJ = cust.Element("NumeroCRCContadorPJ").Value,
                                CNPJContador = cust.Element("CNPJContador").Value,
                                TipoCRCPF = cust.Elements("TipoCRCContadorPF").Any() ? cust.Element("TipoCRCContadorPF").Value : "",
                                TipoCRCPJ = cust.Elements("TipoCRCContadorPJ").Any() ? cust.Element("TipoCRCContadorPJ").Value : "",
                                ClassifCRCPF = cust.Elements("ClassificacaoCRCContadorPF").Any() ? cust.Element("ClassificacaoCRCContadorPF").Value : "",
                                NumeroCRCPF = cust.Elements("NumeroCRCContadorPF").Any() ? cust.Element("NumeroCRCContadorPF").Value : "",
                                UFCRCPF = cust.Elements("UFCRCContadorPF").Any() ? cust.Element("UFCRCContadorPF").Value : "",
                                UFCRCPJ = cust.Elements("UFCRCContadorPJ").Any() ? cust.Element("UFCRCContadorPJ").Value : "",
                                CPFContador = cust.Elements("CPFContador").Any() ? cust.Element("CPFContador").Value : "",
                                Licenciamento = (from lic in cust.Descendants("Licenciamento")
                                                 select new LicenciamentoStruct {
                                                     Solicitacao = lic.Elements("Solicitacao").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).FirstOrDefault(),
                                                     Orgao = lic.Elements("Orgao").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).FirstOrDefault(),
                                                     Status = lic.Elements("Status").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).FirstOrDefault(),
                                                     Risco = lic.Elements("Risco").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).FirstOrDefault(),
                                                     Numero = lic.Elements("Numero").Any() ? lic.Element("Numero").Value : "",
                                                     DataEmissao = lic.Elements("DataEmissao").Any() ? Convert.ToDateTime(lic.Element("DataEmissao").Value) : Convert.ToDateTime("01/01/1900"),
                                                     DataVencimento = lic.Elements("DataVencimento").Any() ? Convert.ToDateTime(lic.Element("DataVencimento").Value) : Convert.ToDateTime("01/01/1900"),
                                                     Pergunta = lic.Elements("Pergunta").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).ToList(),
                                                     Resposta = lic.Elements("Pergunta").Select(x => x.Attribute("resposta").Value).Where(s => s != string.Empty).ToList(),
                                                     Declaracao = lic.Elements("Declaracao").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).ToList(),
                                                     Imovel = (from imv in lic.Descendants("Imovel")
                                                               select new ImovelStruct {
                                                                   AreaEstabelecimento = imv.Element("AreaEstabelecimento").Value,
                                                                   NomeProprietario = imv.Element("NomeProprietario").Value,
                                                                   EmailProprietario = imv.Element("EmailProprietario").Value,
                                                                   TelefoneProprietario = imv.Element("TelefoneProprietario").Value,
                                                                   NomeResponsavelUso = imv.Element("NomeResponsavelUso").Value,
                                                                   TelefoneResponsavelUso = imv.Element("TelefoneResponsavelUso").Value,
                                                                   AreaTotal = imv.Element("AreaTotal").Value,
                                                                   Pavimentos = imv.Element("Pavimentos").Value,
                                                                   Contiguo = imv.Element("Contiguo").Value,
                                                                   OutrosUsos = imv.Element("OutrosUsos").Value
                                                               }).FirstOrDefault()
                                                 }).ToList(),
                                Viabilidade = (from via in cust.Descendants("Viabilidade")
                                               select new ViabilidadeStruct {
                                                   Solicitacao = via.Elements("Solicitacao").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).ToArray(),
                                                   Status = via.Elements("Status").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).ToArray(),
                                                   DataStatus = via.Elements("DataStatus").Any() ? via.Element("DataStatus").Value : "",
                                                   RestricaoOperacao = via.Elements("RestricaoOperacao").Select(x => x.Attribute("id").Value).Where(s => s != string.Empty).ToArray()
                                               }).ToList(),
                                Sociedade = (from soc in cust.Descendants("Sociedade")
                                             select new SociedadeStruct {
                                                 Socio = (from sc in soc.Descendants("Socio")
                                                          select new SocioStruct {
                                                              Tipo = sc.Element("Tipo").Value,
                                                              Nome = sc.Element("Nome").Value,
                                                              Numero = sc.Element("Numero").Value,
                                                              PaisOrigem = sc.Element("CodigoPaisOrigem").Value
                                                          }
                                                          ).ToList()
                                             }).ToList()
                            }).ToList();



            return empresas;
        }

        private List<Redesim_viabilidade> ReadFileViabilidade(string sFileName) {
            List<Redesim_viabilidade> empresas = new List<Redesim_viabilidade>();
            using (var reader = new StreamReader(sFileName)) {
                int pos = 0;
                while (!reader.EndOfStream) {
                    Redesim_viabilidade reg = new Redesim_viabilidade();
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (values.Length > 1) {
                        reg.Protocolo = values[0];
                        if (reg.Protocolo.Length == 13 && reg.Protocolo.Substring(0, 2) == "SP") {
                            reg.Analise = values[1];
                            if (pos > 0)
                                empresas.Add(reg);
                        }
                    }
                    pos++;
                }
            }



            //try {
            //    XElement xmlDoc = XElement.Load(sFileName);
            //    empresas = (from cust in xmlDoc.Descendants("Viabilidade")
            //                    select new Redesim_viabilidade {
            //                        Protocolo = cust.Element("Protocolo").Value,
            //                        Analise = cust.Element("Analise").Value,
            //                        Nire = cust.Element("Nire").Value,
            //                        Cnpj = cust.Element("CNPJ").Value,
            //                        RazaoSocial = cust.Element("RazaoSocial").Value,
            //                        AreaEstabelecimento = Convert.ToDecimal(cust.Element("Area Estabelecimento").Value)
            //                    }).ToList();

            //} catch (Exception ex) {

            //    throw;
            //}
            return empresas;
        }
        

        private void Grava_Empresas_Vre(List<EmpresaStruct> Lista) {
            Empresa_bll empresa_Class = new Empresa_bll("GTIconnection");
            foreach (EmpresaStruct item in Lista) {
                if (empresa_Class.Existe_Empresa_Vre(Convert.ToInt32(item.id))) {
                    item.Already_inDB = true;
                } else {
                    try {
                        Vre_empresa reg = new Vre_empresa();
                        reg.Nome_arquivo =Path.GetFileName( FileUpload1.PostedFile.FileName);
                        reg.Data_importacao = DateTime.Now;
                        reg.Id = Convert.ToInt32(item.id);
                        reg.Razao_social = item.Nome.ToString().Replace("&amp;", "&");
                        reg.Cnpj = item.Cnpj;
                        reg.Data_abertura = item.DataAbertura;
                        reg.Porte = Convert.ToByte(item.Porte);
                        reg.Numero_registro = item.NumeroRegistro;
                        reg.Tipo_registro = Convert.ToByte(item.TipoRegistro);
                        reg.Tipo_mei = Convert.ToByte(item.TipoMei);
                        reg.Cpf_responsavel = item.CpfResponsavel;
                        reg.Nome_responsavel = item.NomeResponsavel;
                        reg.Fone_contato1 = item.DDDContato1 + " " + item.FoneContato1;
                        reg.Fone_contato2 = item.DDDContato2 + " " + item.FoneContato2;
                        reg.Email_contato = item.EmailContato;
                        reg.Setor_quadra_lote = item.Endereco.SetorQuadraLote;
                        reg.Tipo_logradouro =  item.Endereco.TipoLogradouro.Length>15? item.Endereco.TipoLogradouro.Substring(0,15): item.Endereco.TipoLogradouro;
                        reg.Nome_logradouro = item.Endereco.Logradouro;
                        reg.Numero_imovel = gtiCore.IsNumeric(item.Endereco.Numero.ToString()) ? Convert.ToInt32(gtiCore.RetornaNumero(item.Endereco.Numero)) : 0;
                        reg.Complemento = gtiCore.Truncate(item.Endereco.Complemento, 47, "...").ToString().TrimEnd();
                        reg.Bairro = item.Endereco.Bairro;
                        reg.Cidade = item.Endereco.Cidade;
                        reg.UF = item.Endereco.UF;
                        reg.Cep = item.Endereco.Cep;
                        reg.Area_estabelecimento = item.Licenciamento[0].Imovel == null ? 0 : Convert.ToSingle(item.Licenciamento[0].Imovel.AreaEstabelecimento);
                        reg.Nome_proprietario = item.Licenciamento[0].Imovel == null ? "" : item.Licenciamento[0].Imovel.NomeProprietario;
                        reg.Email_proprietario = item.Licenciamento[0].Imovel == null ? "" : item.Licenciamento[0].Imovel.EmailProprietario;
                        reg.Fone_proprietario = item.Licenciamento[0].Imovel== null ? "" : item.Licenciamento[0].Imovel.TelefoneProprietario;
                        reg.Email_proprietario = item.Licenciamento[0].Imovel == null ? "" : item.Licenciamento[0].Imovel.EmailProprietario;
                        reg.Nome_responsavel_uso = item.Licenciamento[0].Imovel == null ? "" : item.Licenciamento[0].Imovel.NomeResponsavelUso;
                        reg.Fone_responsavel_uso = item.Licenciamento[0].Imovel == null ? "" : item.Licenciamento[0].Imovel.TelefoneResponsavelUso;
                        reg.Area_total = item.Licenciamento[0].Imovel == null ? 0 : Convert.ToSingle(item.Licenciamento[0].Imovel.AreaTotal);
                        reg.Pavimentos = item.Licenciamento[0].Imovel == null ? Convert.ToByte(0) : Convert.ToByte(item.Licenciamento[0].Imovel.Pavimentos);
                        reg.Contiguo = item.Licenciamento[0].Imovel == null ? Convert.ToByte(0) : Convert.ToByte(item.Licenciamento[0].Imovel.Contiguo);
                        reg.Outros_usos = item.Licenciamento[0].Imovel== null ? Convert.ToByte(0) : Convert.ToByte(item.Licenciamento[0].Imovel.OutrosUsos);
                        reg.Classif_CRC_PJ = item.ClassifCRCPJ == null ? Convert.ToByte(0) : Convert.ToByte(item.ClassifCRCPJ);
                        reg.Classif_CRC_PF = item.ClassifCRCPF == null ? Convert.ToByte(0) : Convert.ToByte(item.ClassifCRCPF);
                        reg.Numero_CRC_PJ = item.NumeroCRCPJ;
                        reg.Cnpj_contador = item.CNPJContador;
                        reg.Tipo_CRC_PF = item.TipoCRCPF;
                        reg.Tipo_CRC_PJ = item.TipoCRCPJ;
                        reg.Numero_CRC_PF = item.NumeroCRCPF;
                        reg.Uf_CRC_PF = item.UFCRCPF;
                        reg.Uf_CRC_PJ = item.UFCRCPJ;
                        reg.Cpf_contador = item.CPFContador;

                        empresa_Class.Insert_Empresa_Vre(reg);
                    } catch (Exception ex) {
                        throw ex;
                    }

                    item.Already_inDB = false;

                    for (int i = 0; i < item.Atividade[0].Codigo.Count(); i++) {
                        Vre_atividade regatv = new Vre_atividade();
                        regatv.Id = Convert.ToInt32(item.id);
                        regatv.Cnae = item.Atividade[0].Codigo[i].ToString();
                        regatv.Principal =Convert.ToBoolean( Convert.ToInt16(item.Atividade[0].Principal[i].ToString()));
                        regatv.Exercida = Convert.ToBoolean(Convert.ToInt16(item.Atividade[0].Exercida[i].ToString()));

                        try {
                            empresa_Class.Insert_Atividade_Vre(regatv);
                        } catch (Exception ex) {
                            throw ex;
                        }
                                               
                    }
                    for (int i = 0; i < item.Sociedade[0].Socio.Count(); i++) {
                        Vre_socio regsoc = new Vre_socio();
                        regsoc.Id = Convert.ToInt32(item.id);
                        regsoc.Nome = item.Sociedade[0].Socio[i].Nome.ToString();
                        regsoc.Numero = item.Sociedade[0].Socio[i].Numero.ToString();
                        try {
                            empresa_Class.Insert_Socio_Vre(regsoc);
                        } catch (Exception ex) {
                            throw ex;
                        }
                        
                    }
                    for (int i = 0; i < item.Licenciamento.Count(); i++) {
                        Vre_licenciamento reglic = new Vre_licenciamento();
                        reglic.Empresa_id = Convert.ToInt32(item.id);
                        reglic.Solicitacao_id = Convert.ToInt32(item.Licenciamento[i].Solicitacao);
                        reglic.Orgao_id = Convert.ToInt32(item.Licenciamento[i].Orgao);
                        reglic.Status = Convert.ToInt32(item.Licenciamento[i].Status);
                        reglic.Numero = item.Licenciamento[i].Numero;
                        reglic.Risco = Convert.ToBoolean(Convert.ToInt16(item.Licenciamento[i].Risco));
                        reglic.Data_emissao = Convert.ToDateTime(item.Licenciamento[i].DataEmissao);
                        reglic.Data_vencimento = Convert.ToDateTime(item.Licenciamento[i].DataVencimento);
                       
                        try {
                            empresa_Class.Insert_Licenciamento_Vre(reglic);
                        } catch (Exception ex) {
                            throw ex;
                        }

                    }
                }
            }
        }

        class EmpresaStruct {
            public string id { get; set; }
            public string Nome { get; set; }
            public string Cnpj { get; set; }
            public DateTime DataAbertura { get; set; }
            public string Porte { get; set; }
            public string NumeroRegistro { get; set; }
            public string TipoRegistro { get; set; }
            public string TipoMei { get; set; }
            public string CpfResponsavel { get; set; }
            public string NomeResponsavel { get; set; }
            public string DDDContato1 { get; set; }
            public string FoneContato1 { get; set; }
            public string DDDContato2 { get; set; }
            public string FoneContato2 { get; set; }
            public string EmailContato { get; set; }
            public EnderecoStruct Endereco { get; set; }
            public List<AtividadeStruct> Atividade { get; set; }
            public string ClassifCRCPJ { get; set; }
            public string TipoCRCPJ { get; set; }
            public string NumeroCRCPJ { get; set; }
            public string CNPJContador { get; set; }
            public string TipoCRCPF { get; set; }
            public string ClassifCRCPF { get; set; }
            public string NumeroCRCPF { get; set; }
            public string UFCRCPF { get; set; }
            public string UFCRCPJ { get; set; }
            public string CPFContador { get; set; }
            public List<LicenciamentoStruct> Licenciamento { get; set; }
            public List<ViabilidadeStruct> Viabilidade { get; set; }
            public List<SociedadeStruct> Sociedade { get; set; }
            public bool Already_inDB { get; set; }
        }

        class EnderecoStruct {
            public string SetorQuadraLote { get; set; }
            public string TipoLogradouro { get; set; }
            public string Logradouro { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string Cep { get; set; }
            public string UF { get; set; }
            public string Cidade { get; set; }
        }

        class AtividadeStruct {
            public string[] Codigo { get; set; }
            public string[] Principal { get; set; }
            public string[] Exercida { get; set; }
        }

        class ViabilidadeStruct {
            public string[] Solicitacao { get; set; }
            public string[] Status { get; set; }
            public string DataStatus { get; set; }
            public string[] RestricaoOperacao { get; set; }
        }

        class LicenciamentoStruct {
            public string Solicitacao { get; set; }
            public string Orgao { get; set; }
            public string Status { get; set; }
            public string Risco { get; set; }
            public string Numero { get; set; }
            public DateTime DataEmissao { get; set; }
            public DateTime DataVencimento { get; set; }
            public List<string> Pergunta { get; set; }
            public List<string> Resposta { get; set; }
            public List<string> Declaracao { get; set; }
            public ImovelStruct Imovel { get; set; }
        }

        class ImovelStruct {
            public string AreaEstabelecimento { get; set; }
            public string NomeProprietario { get; set; }
            public string EmailProprietario { get; set; }
            public string TelefoneProprietario { get; set; }
            public string NomeResponsavelUso { get; set; }
            public string TelefoneResponsavelUso { get; set; }
            public string AreaTotal { get; set; }
            public string Pavimentos { get; set; }
            public string Contiguo { get; set; }
            public string OutrosUsos { get; set; }
        }

        class SociedadeStruct {
            public List<SocioStruct> Socio { get; set; }
        }

        class SocioStruct {
            public string Tipo { get; set; }
            public string Nome { get; set; }
            public string Numero { get; set; }
            public string PaisOrigem { get; set; }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("~/Pages/alvara_vre.aspx");
        }









    }
}