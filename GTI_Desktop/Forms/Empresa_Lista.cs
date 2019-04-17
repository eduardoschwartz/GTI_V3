using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        List<ArrayList> aDatResult;

        public Empresa_Lista() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            EnderecoToolStrip.Renderer = new MySR();
            ProprietarioToolStrip.Renderer = new MySR();
            AtividadeToolStrip.Renderer = new MySR();
            ReadDatFile();
            string[] _ordem = new string[] { "Código", "Inscrição", "Proprietário", "Endereco", "Bairro", "Condomínio" };
            OrdemList.Items.AddRange(_ordem);
            OrdemList.SelectedIndex = 0;
        }

        private void FindButton_Click(object sender, EventArgs e) {

        }

        private void SelectButton_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.Items[col[0]].Text);
                SaveDatFile();
                Close();
            } else {
                MessageBox.Show("Selecione um imóvel.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SaveDatFile() {
            List<string> aLista = new List<string>();
            string[] aReg = new string[8];
            string[] aTmp = new string[1];

            aLista.Add(gtiCore.ConvertDatReg("CD", Codigo.Text.Split()));

            for (int i = 0; i < MainListView.VirtualListSize; i++) {
                aReg[0] = MainListView.Items[i].Text;
                aReg[1] = MainListView.Items[i].SubItems[1].Text;
                aReg[2] = MainListView.Items[i].SubItems[2].Text;
                aReg[3] = MainListView.Items[i].SubItems[3].Text == "" ? " " : MainListView.Items[i].SubItems[3].Text;
                aReg[4] = MainListView.Items[i].SubItems[4].Text == "" ? " " : MainListView.Items[i].SubItems[4].Text;
                aReg[5] = MainListView.Items[i].SubItems[5].Text == "" ? " " : MainListView.Items[i].SubItems[5].Text;
                aReg[6] = MainListView.Items[i].SubItems[6].Text == "" ? " " : MainListView.Items[i].SubItems[6].Text;
                aReg[7] = MainListView.Items[i].SubItems[7].Text == "" ? " " : MainListView.Items[i].SubItems[7].Text;
                aLista.Add(gtiCore.ConvertDatReg("IM", aReg));
            }

            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            gtiCore.CreateDatFile(sDir + "\\gti004.dat", aLista);
        }

        private void ReadDatFile() {
            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            string sFileName = "\\gti004.dat";
            //se o arquivo não existir, então não tem o que ler.
            if (!File.Exists(sDir + sFileName)) return;
            //se o arquivo for de outro dia, então não ler.
            if (File.GetLastWriteTime(sDir + sFileName).ToString("MM/dd/yyyy") != DateTime.Now.ToString("MM/dd/yyyy")) return;
            //lê o q arquivo
            try {
                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "CD");
                if (aDatResult[0].Count > 0)
                    Codigo.Text = aDatResult[0][0].ToString();

                aDatResult = gtiCore.ReadFromDatFile(sDir + sFileName, "IM", false);
                MainListView.VirtualListSize = aDatResult.Count;
            } catch {
            }

        }

        private void CallPB(ToolStripProgressBar pBar, int nPos, int nTot) {
            pBar.Value = nPos * 100 / nTot;
        }

        private void EnderecoAddButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
            };
            if (BairroText.Tag == null) BairroText.Tag = "0";
            reg.Id_bairro = string.IsNullOrWhiteSpace(BairroText.Tag.ToString()) ? 0 : Convert.ToInt32(BairroText.Tag.ToString());
            if (LogradouroText.Tag == null) LogradouroText.Tag = "0";
            if (string.IsNullOrWhiteSpace(LogradouroText.Tag.ToString()))
                LogradouroText.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(LogradouroText.Text) ? 0 : Convert.ToInt32(LogradouroText.Tag.ToString());
            reg.Nome_logradouro = LogradouroText.Text;
            reg.Numero_imovel = NumeroText.Text == "" ? 0 : Convert.ToInt32(NumeroText.Text);
            reg.Complemento = "";
            reg.Email = "";

            Forms.Endereco f1 = new Forms.Endereco(reg, true, true, false, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                BairroText.Text = f1.EndRetorno.Nome_bairro;
                BairroText.Tag = f1.EndRetorno.Id_bairro.ToString();
                LogradouroText.Text = f1.EndRetorno.Nome_logradouro;
                LogradouroText.Tag = f1.EndRetorno.Id_logradouro.ToString();
                NumeroText.Text = f1.EndRetorno.Numero_imovel.ToString();
            }
        }

        private void EnderecoDelButton_Click(object sender, EventArgs e) {
            LogradouroText.Text = "";
            LogradouroText.Tag = "";
            NumeroText.Text = "";
            BairroText.Text = "";
            BairroText.Tag = "";
        }

        private void ExcelButton_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel |* .xlsx",
                InitialDirectory = @"c:\dados\xlsx",
                FileName = "Consulta_Empresa.xlsx",
                ValidateNames = true
            }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    gtiCore.Ocupado(this);
                    string file = sfd.FileName;

                    ExcelPackage package = new ExcelPackage();
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Lista");
                    worksheet.Cells[1, 1].Value = "Código";
                    worksheet.Cells[1, 2].Value = "Inscrição";
                    worksheet.Cells[1, 3].Value = "Proprietário";
                    worksheet.Cells[1, 4].Value = "Endereço";
                    worksheet.Cells[1, 5].Value = "Nº";
                    worksheet.Cells[1, 6].Value = "Compl.";
                    worksheet.Cells[1, 7].Value = "Bairro";
                    worksheet.Cells[1, 8].Value = "Condomínio";

                    int r = 2;
                    for (int i = 0; i < MainListView.VirtualListSize; i++) {
                        worksheet.Cells[i + r, 1].Value = MainListView.Items[i].Text;
                        worksheet.Cells[i + r, 2].Value = MainListView.Items[i].SubItems[1].Text;
                        worksheet.Cells[i + r, 3].Value = MainListView.Items[i].SubItems[2].Text;
                        worksheet.Cells[i + r, 4].Value = MainListView.Items[i].SubItems[3].Text;
                        worksheet.Cells[i + r, 5].Value = MainListView.Items[i].SubItems[4].Text;
                        worksheet.Cells[i + r, 6].Value = MainListView.Items[i].SubItems[5].Text;
                        worksheet.Cells[i + r, 7].Value = MainListView.Items[i].SubItems[6].Text;
                        worksheet.Cells[i + r, 8].Value = MainListView.Items[i].SubItems[7].Text;
                    }

                    worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells
                    var xlFile = gtiCore.GetFileInfo(sfd.FileName);
                    package.SaveAs(xlFile);

                    gtiCore.Liberado(this);
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,acc[3].ToString(),acc[4].ToString(),acc[5].ToString(),acc[6].ToString(),acc[7].ToString()}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };

        }

        private void Codigo_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                FindButton_Click(sender, e);
        }

        private void OrdemList_SelectedIndexChanged(object sender, EventArgs e) {
            FindButton_Click(sender, e);
        }

        private void ClearButton_Click(object sender, EventArgs e) {
            Codigo.Text = "";
            CNPJOption.Checked = true;
            RazaoSocialText.Text = "";
            AtividadeText.Text = "";
            AtividadeText.Tag = "";
            LogradouroText.Text = "";
            BairroText.Text = "";
            BairroText.Tag = "";
            NumeroText.Text = "";
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = 0;
            MainListView.EndUpdate();
            TotalImovel.Text = "0";
            SaveDatFile();
        }

        private void CPFOption_CheckedChanged(object sender, EventArgs e) {
            CNPJText.Text = "";
            CNPJText.Visible = false;
            CPFText.Visible = true;
            CPFText.Focus();
        }

        private void CNPJOption_CheckedChanged(object sender, EventArgs e) {
            CPFText.Text = "";
            CPFText.Visible = false;
            CNPJText.Visible = true;
            CNPJText.Focus();
        }
    }
}
