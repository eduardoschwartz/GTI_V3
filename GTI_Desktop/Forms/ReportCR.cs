using GTI_Desktop.Classes;
using GTI_Desktop.Report;
using GTI_Models.Models;
using System;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class ReportCR : Form {
        public ReportCR(String ReportName,Report_Data Dados) {
            InitializeComponent();
            showReport(ReportName,Dados);
        }

        private void showReport(String _nome,Report_Data _dados) {

            switch (_nome) {
                case "CertidaoEndereco":
                    Text = "Certidão de Endereço";
                    CertidaoEndereco rpt = new CertidaoEndereco();
                    crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
                    rpt.SetDatabaseLogon(gtiCore.Ul, gtiCore.Up, Properties.Settings.Default.ServerName, Properties.Settings.Default.DataBaseReal);
                    rpt.SetParameterValue("NUMCERTIDAO", _dados.Numero_Certidao);
                    rpt.SetParameterValue("DATAEMISSAO", DateTime.Now);
                    rpt.SetParameterValue("CONTROLE", _dados.Controle);
                    rpt.SetParameterValue("BAIRRO", _dados.Nome_bairro);
                    rpt.SetParameterValue("ENDERECO", _dados.Endereco);
                    rpt.SetParameterValue("CADASTRO", _dados.Codigo);
                    rpt.SetParameterValue("INSCRICAO", _dados.Inscricao);
                    rpt.SetParameterValue("NOME", _dados.Nome);
                    rpt.SetParameterValue("PROCESSO", _dados.Processo);
                    rpt.SetParameterValue("DATAPROCESSO", _dados.Data_Processo);
                    rpt.SetParameterValue("QUADRA", _dados.Quadra_original);
                    rpt.SetParameterValue("LOTE", _dados.Lote_original);
                    rpt.SetParameterValue("DOCUMENTO", _dados.Cpf_cnpj==null?"": _dados.Cpf_cnpj);
                    rpt.RecordSelectionFormula = "{Assinatura.Usuario}='" + "RENATA" + "'";
                    crViewer.ReportSource = rpt;
                    break;

                default:
                    break;
            }

        }//End showReport


    }
}
