using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Report;
using GTI_Models.Models;
using System;
using System.Windows.Forms;
using static GTI_Models.modelCore;

namespace GTI_Desktop.Forms {
    public partial class ReportCR : Form {
        private string _connection = gtiCore.Connection_Name();

        public ReportCR(String ReportName,Report_Data Dados) {
            InitializeComponent();
            showReport(ReportName,Dados);
        }

        private void showReport(String _nome,Report_Data _dados) {
            crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            string _usuario = Properties.Settings.Default.LastUser;

            switch (_nome) {
                case "CertidaoEndereco":
                    Text = "Certidão de Endereço";
                    CertidaoEndereco rpt_endereco = new CertidaoEndereco();
                    rpt_endereco.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt_endereco.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt_endereco.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt_endereco.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt_endereco.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt_endereco.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt_endereco.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt_endereco.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt_endereco.SetParameterValue("NOME", _dados.Nome);
                    rpt_endereco.SetParameterValue("PROCESSO", _dados.Processo);
                    rpt_endereco.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt_endereco.SetParameterValue("QUADRA", _dados.Quadra_original);
                    rpt_endereco.SetParameterValue("LOTE", _dados.Lote_original);
                    rpt_endereco.SetParameterValue("DOCUMENTO", _dados.Cpf_cnpj==null?"": _dados.Cpf_cnpj);
                    rpt_endereco.RecordSelectionFormula = "{Assinatura.Usuario}='" + _usuario + "'";
                    crViewer.ReportSource = rpt_endereco;
                    break;
                case "CertidaoImunidade":
                    Text = "Certidão de Isenção";
                    CertidaoImunidade rpt_imunidade = new CertidaoImunidade();
                    rpt_imunidade.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt_imunidade.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt_imunidade.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt_imunidade.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt_imunidade.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt_imunidade.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt_imunidade.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt_imunidade.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt_imunidade.SetParameterValue("NOME", _dados.Nome);
                    rpt_imunidade.SetParameterValue("PROCESSO", _dados.Processo);
                    rpt_imunidade.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt_imunidade.SetParameterValue("ANO", _dados.AnoIsencao);
                    rpt_imunidade.SetParameterValue("AREA", _dados.Area);
                    rpt_imunidade.SetParameterValue("PERC", _dados.Perc_Isencao);
                    rpt_imunidade.SetParameterValue("DOC", _dados.Cpf_cnpj == null ? "" : _dados.Cpf_cnpj);
                    rpt_imunidade.RecordSelectionFormula = "{Assinatura.Usuario}='" + _usuario + "'";
                    crViewer.ReportSource = rpt_imunidade;
                    break;
                case "CertidaoIsencaoProcesso":
                    Text = "Certidão de Isenção";
                    CertidaoIsencaoProcesso rpt_isencao = new CertidaoIsencaoProcesso();
                    rpt_isencao.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt_isencao.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt_isencao.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt_isencao.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt_isencao.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt_isencao.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt_isencao.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt_isencao.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt_isencao.SetParameterValue("NOME", _dados.Nome);
                    rpt_isencao.SetParameterValue("NUMPROCESSO", _dados.Processo);
                    rpt_isencao.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt_isencao.SetParameterValue("NUMPROCESSOISENCAO", _dados.Processo_Isencao);
                    rpt_isencao.SetParameterValue("DATAPROCESSOISENCAO", _dados.Data_Processo_Isencao);
                    rpt_isencao.SetParameterValue("ANO", _dados.AnoIsencao);
                    rpt_isencao.SetParameterValue("AREA", _dados.Area);
                    rpt_isencao.SetParameterValue("PERC", _dados.Perc_Isencao);
                    rpt_isencao.SetParameterValue("DOC", _dados.Cpf_cnpj == null ? "" : _dados.Cpf_cnpj);
                    rpt_isencao.RecordSelectionFormula = "{Assinatura.Usuario}='" + _usuario + "'";
                    crViewer.ReportSource = rpt_isencao;
                    break;
                case "CertidaoIsencao65":
                    Text = "Certidão de Isenção";
                    CertidaoIsencao65 rpt_isencao65 = new CertidaoIsencao65();
                    rpt_isencao65.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt_isencao65.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt_isencao65.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt_isencao65.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt_isencao65.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt_isencao65.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt_isencao65.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt_isencao65.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt_isencao65.SetParameterValue("NOME", _dados.Nome);
                    rpt_isencao65.SetParameterValue("NUMPROCESSO", _dados.Processo);
                    rpt_isencao65.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt_isencao65.SetParameterValue("ANO", _dados.AnoIsencao);
                    rpt_isencao65.SetParameterValue("AREA", _dados.Area);
                    rpt_isencao65.SetParameterValue("PERC", _dados.Perc_Isencao);
                    rpt_isencao65.SetParameterValue("DOC", _dados.Cpf_cnpj == null ? "" : _dados.Cpf_cnpj);
                    rpt_isencao65.RecordSelectionFormula = "{Assinatura.Usuario}='" + _usuario + "'";
                    crViewer.ReportSource = rpt_isencao65;
                    break;
                case "CertidaoValorVenal":
                    Text = "Certidão de Valor Venal";
                    CertidaoValorVenal rpt_vvenal = new CertidaoValorVenal();
                    Tributario_bll tributario_Class = new Tributario_bll(_connection);
                    SpCalculo RegCalculo = tributario_Class.Calculo_IPTU(Convert.ToInt32( _dados.Codigo), DateTime.Now.Year);
                    rpt_vvenal.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt_vvenal.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt_vvenal.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt_vvenal.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt_vvenal.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt_vvenal.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt_vvenal.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt_vvenal.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt_vvenal.SetParameterValue("NOME", _dados.Nome);
                    rpt_vvenal.SetParameterValue("PROCESSO", _dados.Processo);
                    rpt_vvenal.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt_vvenal.SetParameterValue("QUADRA", _dados.Quadra_original);
                    rpt_vvenal.SetParameterValue("LOTE", _dados.Lote_original);
                    rpt_vvenal.SetParameterValue("DOCUMENTO", _dados.Cpf_cnpj == null ? "" : _dados.Cpf_cnpj);
                    rpt_vvenal.SetParameterValue("VVT", RegCalculo.Vvt);
                    rpt_vvenal.SetParameterValue("VVP", RegCalculo.Vvp);
                    rpt_vvenal.SetParameterValue("VVI", RegCalculo.Vvi);
                    rpt_vvenal.RecordSelectionFormula = "{Assinatura.Usuario}='" + _usuario + "'";
                    crViewer.ReportSource = rpt_vvenal;
                    break;
                case "CertidaoDebitoImovel":
                    Text = "Certidão de Débito";
                    CertidaoDebitoImovel rpt_cdebitoimovel = new CertidaoDebitoImovel();
                    rpt_cdebitoimovel.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt_cdebitoimovel.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt_cdebitoimovel.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt_cdebitoimovel.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt_cdebitoimovel.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt_cdebitoimovel.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt_cdebitoimovel.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt_cdebitoimovel.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt_cdebitoimovel.SetParameterValue("NOME", _dados.Nome);

                    rpt_cdebitoimovel.SetParameterValue("TIPOCERTIDAO", _dados.TipoCertidao);
                    rpt_cdebitoimovel.SetParameterValue("TRIBUTO", _dados.Tributos);
                    rpt_cdebitoimovel.SetParameterValue("NAO", _dados.Nao);
                    rpt_cdebitoimovel.SetParameterValue("ATIVIDADE", _dados.Atividade);
                    rpt_cdebitoimovel.SetParameterValue("CIDADE", _dados.Nome_cidade);

                    rpt_cdebitoimovel.SetParameterValue("PROCESSO", _dados.Processo);
                    rpt_cdebitoimovel.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt_cdebitoimovel.SetParameterValue("DOCUMENTO", _dados.Cpf_cnpj == null ? "" : _dados.Cpf_cnpj);
                    rpt_cdebitoimovel.RecordSelectionFormula = "{Assinatura.Usuario}='" + _usuario + "'";
                    crViewer.ReportSource = rpt_cdebitoimovel;
                    break;
                default:
                    break;
            }

        }//End showReport


    }
}
