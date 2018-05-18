using System;   
using System.Windows.Forms;
using System.Data;
using Microsoft.Reporting.WinForms;
using GTI_Desktop.Forms;

namespace GTI_Desktop.Forms {
    public partial class Report:Form {

        public Report(String ReportName,DataSet Ds,int nTable,bool ShowDialog,ReportParameter[] rParam) {
            InitializeComponent();
            if(!ShowDialog) {
                Main MdiForm = (Main)Application.OpenForms["MainForm"];
                this.MdiParent = MdiForm;
            }
            ShowReport(ReportName,Ds,nTable,rParam);
        }

        private void ShowReport(String ReportName,DataSet Ds,int nTable,ReportParameter[] rParam) {
            String sFullReportName = "GTI_Desktop.Report." + ReportName + ".rdlc";
            try {
                reportViewer.LocalReport.ReportEmbeddedResource = sFullReportName;
                ReportDataSource rds = new ReportDataSource(Ds.DataSetName, Ds.Tables[nTable]);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(rds);
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                this.reportViewer.ZoomMode = ZoomMode.PageWidth;
                this.reportViewer.LocalReport.Refresh();
                if(rParam != null)
                    this.reportViewer.LocalReport.SetParameters(rParam);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Report_Load(object sender, EventArgs e) {
            this.reportViewer.RefreshReport();
        }

    }
}
