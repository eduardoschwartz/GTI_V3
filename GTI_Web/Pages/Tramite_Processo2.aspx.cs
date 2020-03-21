using GTI_Bll.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using UIWeb;

namespace GTI_Web.Pages {
    public partial class Tramite_Processo2 : System.Web.UI.Page {
        private string sNumProc;
        private ProcessoNumero _numeroProcesso;

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["pUserId"] == null || (int)Session["pUserId"] == 0) {
                Response.Redirect("Login.aspx");
            }
            lblMsg.Text = "";
            try {
                sNumProc = gtiCore.Decrypt(Request.QueryString["a"]);
            } catch (Exception) {
                Session["pUserId"] = 0;
                Response.Redirect("Login.aspx");
            }

            Carrega_Grid();
        }

        private void Carrega_Grid() {
            lblMsg.Text = "";
            Processo_bll processo_Class = new Processo_bll("GTIconnection");
            try {
                _numeroProcesso = gtiCore.Split_Processo_Numero(sNumProc);
                ProcessoStruct _processo = processo_Class.Dados_Processo(_numeroProcesso.Ano, _numeroProcesso.Numero);
                Processo.Text = sNumProc;
                DataAbertura.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy");
                Requerente.Text = _processo.NomeCidadao;
                Assunto.Text = _processo.Complemento;

                List<TramiteStruct> Lista_Tramite = processo_Class.DadosTramite((short)_numeroProcesso.Ano, _numeroProcesso.Numero, 0);

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[8] { new DataColumn("Seq"), new DataColumn("Local"), new DataColumn("Data"), new DataColumn("Hora"),
                    new DataColumn("Usuario1"), new DataColumn("Despacho"), new DataColumn("Data2"), new DataColumn("Usuario2") });

                foreach (TramiteStruct item in Lista_Tramite) {
                    dt.Rows.Add(item.Seq, item.CentroCustoNome, item.DataEntrada, item.HoraEntrada, item.Usuario1, item.DespachoNome, item.DataEnvio, item.Usuario2);
                }

                grdMain.DataSource = dt;
                grdMain.DataBind();


            } catch (Exception) {

                Response.Redirect("~/Pages/gtiMenu3.aspx");
            }

        }

        protected void grdMain_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e) {
            short ccusto = 0;
            int Seq = Convert.ToInt32(e.CommandArgument) + 1;
            Processo_bll processo_Class = new Processo_bll("GTIconnection");
            if (e.CommandName == "cmdReceber") {
                if (Seq > 1) {
                    bool _existeTramiteAnterior = processo_Class.Existe_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, Seq - 1);
                    if (!_existeTramiteAnterior) {
                        lblMsg.Text = "Local anterior não tramitado.";
                        return;
                    } else {
                        Tramitacao linha = processo_Class.Dados_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, Seq - 1);
                        if (linha.Dataenvio == null) {
                            lblMsg.Text = "Local anterior não tramitado.";
                            return;
                        }
                    }
                    bool _existeTramite = processo_Class.Existe_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, Seq);
                    if (_existeTramite) {
                        lblMsg.Text = "Este local já foi tramitado.";
                        return;
                    }
                } else {
                    bool _existeTramite = processo_Class.Existe_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, Seq);
                    if (_existeTramite) {
                        lblMsg.Text = "Este local já foi tramitado.";
                        return;
                    }
                }
                List<Despacho> Lista = processo_Class.Lista_Despacho();
                DespachoListReceber.DataSource = Lista;
                DespachoListReceber.DataTextField = "Descricao";
                DespachoListReceber.DataValueField = "Codigo";
                DespachoListReceber.DataBind();

                SeqReceberLabel.Text = Seq.ToString();
                divModalReceber.Visible = true;
            } else {
                if (e.CommandName == "cmdEnviar") {
                    bool _existeTramite = processo_Class.Existe_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, Seq);
                    if (!_existeTramite) {
                        lblMsg.Text = "Este processo ainda não foi recebido neste local.";
                        return;
                    } else {
                        Tramitacao linha = processo_Class.Dados_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, Seq);
                        ccusto = (short)linha.Despacho;
                        if (linha.Datahora == null) {
                            lblMsg.Text = "Este processo ainda não foi recebido neste local.";
                            return;
                        } else {
                            if (linha.Dataenvio != null) {
                                lblMsg.Text = "Processo já enviado deste local.";
                                return;
                            }
                        }
                    }
                    List<Despacho> Lista = processo_Class.Lista_Despacho();
                    DespachoListEnviar.DataSource = Lista;
                    DespachoListEnviar.DataTextField = "Descricao";
                    DespachoListEnviar.DataValueField = "Codigo";
                    DespachoListEnviar.DataBind();
                    try {
                        DespachoListEnviar.SelectedValue = ccusto.ToString();
                    } catch (Exception) {
                    }

                    SeqEnviarLabel.Text = Seq.ToString();
                    divModalEnviar.Visible = true;
                } else {
                    if (e.CommandName == "cmdAcima") {
                        Exception ex = processo_Class.Move_Sequencia_Tramite_Acima(_numeroProcesso.Numero, _numeroProcesso.Ano, Seq);
                        Response.Redirect(Request.RawUrl, true);
                    } else {
                        if (e.CommandName == "cmdAbaixo") {
                            Exception ex = processo_Class.Move_Sequencia_Tramite_Abaixo(_numeroProcesso.Numero, _numeroProcesso.Ano, Seq);
                            Response.Redirect(Request.RawUrl, true);
                        } else {
                            if (e.CommandName == "cmdInserir") {

                            } else {
                                if (e.CommandName == "cmdRemover") {
                                    Exception ex = processo_Class.Remover_Local(_numeroProcesso.Numero, _numeroProcesso.Ano, Seq);
                                    Response.Redirect(Request.RawUrl, true);
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btOkReceber_Click(object sender, EventArgs e) {
            lblMsg.Text = "";
            Processo_bll processo_Class = new Processo_bll("GTIconnection");
            int ccusto;
            int seq = Convert.ToInt32(SeqReceberLabel.Text);

            bool _existeTramite = processo_Class.Existe_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, seq);
            if (_existeTramite) {
                Tramitacao linha = processo_Class.Dados_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, seq);
                ccusto = linha.Ccusto;
            } else {
                ccusto = processo_Class.Retorna_CCusto_TramiteCC(_numeroProcesso.Ano, _numeroProcesso.Numero, seq);
            }
            Tramitacao reg = new Tramitacao() {
                Ano = (short)_numeroProcesso.Ano,
                Numero = _numeroProcesso.Numero,
                Seq = Convert.ToByte(SeqReceberLabel.Text),
                Despacho = Convert.ToInt16(DespachoListReceber.SelectedValue),
                Datahora = DateTime.Now,
                Userid = gtiCore.pUserId,
                Ccusto = (short)ccusto
            };
            Exception ex = processo_Class.Receber_Processo(reg);
            if (ex != null)
                throw ex.InnerException;
            divModalReceber.Visible = false;
            Carrega_Grid();
        }

        protected void CloseModalReceber(object sender, EventArgs e) {
            divModalReceber.Visible = false;
        }

        protected void btOkEnviar_Click(object sender, EventArgs e) {
            lblMsgEnviar.Text = "";
            if (DespachoListEnviar.SelectedIndex == 0) {
                lblMsgEnviar.Text = "Selecione um despacho!";
                return;
            }
            lblMsg.Text = "";
            Processo_bll processo_Class = new Processo_bll("GTIconnection");
            int seq = Convert.ToInt32(SeqEnviarLabel.Text);

            Tramitacao linha = processo_Class.Dados_Tramite(_numeroProcesso.Ano, _numeroProcesso.Numero, seq);
            Tramitacao reg = new Tramitacao() {
                Ano = linha.Ano,
                Numero = linha.Numero,
                Seq = linha.Seq,
                Despacho = Convert.ToInt16(DespachoListEnviar.SelectedValue),
                Datahora = linha.Datahora,
                Userid = linha.Userid,
                Ccusto = linha.Ccusto,
                Dataenvio = DateTime.Now,
                Userid2 = gtiCore.pUserId
            };
            Exception ex = processo_Class.Enviar_Processo(reg);
            if (ex != null)
                throw ex.InnerException;
            divModalEnviar.Visible = false;
            Carrega_Grid();
        }

        protected void CloseModalEnviar(object sender, EventArgs e) {
            divModalEnviar.Visible = false;
        }

        protected void btOkInserir_Click(object sender, EventArgs e) {

        }

        protected void CloseModalInserir(object sender, EventArgs e) {
            divModalInserir.Visible = false;
        }

       
    }
}