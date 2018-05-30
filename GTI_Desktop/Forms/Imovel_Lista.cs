using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Imovel_Lista : Form {
        string _connection = gtiCore.Connection_Name();
        public int ReturnValue { get; set; }
        private ListViewColumnSorter lvwColumnSorter;
        List<ArrayList> aDatResult;

        public Imovel_Lista() {
            InitializeComponent();
            tBar.Renderer = new MySR();
            EnderecoToolStrip.Renderer = new MySR();
            ProprietarioToolStrip.Renderer = new MySR();
            CondominioToolStrip.Renderer = new MySR();
            lvwColumnSorter = new ListViewColumnSorter();
            ReadDatFile();
        }

        private void SelectButton_Click(object sender, EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count>0) {
                DialogResult = DialogResult.OK;
                ReturnValue = Convert.ToInt32(MainListView.Items[col[0]].Text);
                SaveDatFile();
                Close();
            } else {
                MessageBox.Show("Selecione um imóvel.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        

        private void SaveDatFile() {
            List<string> aLista = new List<string>();
            string[] aReg = new string[3];

            aLista.Add( gtiCore.ConvertDatReg("CD", Codigo.Text.Split()));
            for (int i = 0; i < MainListView.VirtualListSize; i++) {
                aReg[0] = MainListView.Items[i].Text;
                aReg[1] = MainListView.Items[i].SubItems[1].Text;
                aReg[2] = MainListView.Items[i].SubItems[2].Text;
                aLista.Add(gtiCore.ConvertDatReg("IM", aReg));
            }

            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            gtiCore.CreateDatFile(sDir + "\\cd.dat", aLista);

        }

        private void ReadDatFile (){
            string sDir = AppDomain.CurrentDomain.BaseDirectory;
            
            aDatResult = gtiCore.ReadFromDatFile(sDir + "\\cd.dat", "CD", "");
            if(aDatResult[0].Count>0)
                Codigo.Text = aDatResult[0][0].ToString();
            aDatResult = gtiCore.ReadFromDatFile(sDir + "\\cd.dat", "IM", "");
            MainListView.VirtualListSize = aDatResult.Count;
        }


        private void ProprietarioButton_Click(object sender, EventArgs e) {
            using (var form = new Cidadao_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    Sistema_bll sistema_Class = new Sistema_bll(_connection);
                    Contribuinte_Header_Struct reg = sistema_Class.Contribuinte_Header(val);
                    Proprietario.Text = reg.Nome;
                    Proprietario.Tag = val.ToString();
                }
            }
        }

        private void CallPB(System.Windows.Forms.ToolStripProgressBar pBar,  int nPos,int nTot) {
            pBar.Value = nPos * 100 / nTot;
        }

        private void MainListView_ColumnClick(object sender, ColumnClickEventArgs e) {
            if (e.Column == lvwColumnSorter.SortColumn) {
                if (lvwColumnSorter.Order == SortOrder.Ascending) {
                    lvwColumnSorter.Order = SortOrder.Descending;
                } else {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }
            MainListView.Sort();
        }

        private void FindButton_Click(object sender, EventArgs e) {

            MainListView.Items.Clear();
            gtiCore.Ocupado(this);
            Imovel_bll imovel_Class = new Imovel_bll(_connection);

            ImovelStruct Reg = new ImovelStruct();
            Reg.Codigo = string.IsNullOrEmpty(Codigo.Text) ? 0 : Convert.ToInt32(Codigo.Text);
            Reg.Proprietario_Principal = PrincipalCheckBox.Checked;
            Reg.Proprietario_Codigo = Proprietario.Tag == null ? 0 : Convert.ToInt32(Proprietario.Tag.ToString());
            Reg.Distrito = Inscricao.Text.Substring(0, 1).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(0, 1).Trim());
            Reg.Setor = Inscricao.Text.Substring(2, 2).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(2, 2).Trim());
            Reg.Quadra = Inscricao.Text.Substring(5, 4).Trim() == "" ? (short)0 : Convert.ToInt16(Inscricao.Text.Substring(5, 4).Trim());
            Reg.Lote = Inscricao.Text.Substring(10, 5).Trim() == "" ? 0 : Convert.ToInt32(Inscricao.Text.Substring(10, 5).Trim());
            Condominio.Tag = Condominio.Tag ?? "";
            Reg.CodigoCondominio= string.IsNullOrWhiteSpace(Condominio.Tag.ToString()) ? 0 : Convert.ToInt32(Condominio.Tag.ToString());
            Logradouro.Tag = Logradouro.Tag ?? "";
            Reg.CodigoLogradouro = string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            Bairro.Tag = Bairro.Tag ?? "";
            Reg.CodigoBairro = string.IsNullOrWhiteSpace(Bairro.Tag.ToString()) ? (short)0 : Convert.ToInt16(Bairro.Tag.ToString());
            Reg.Numero = Numero.Text.Trim() == "" ? (short)0 : Convert.ToInt16(Numero.Text);

            if(Reg.Codigo==0 && Reg.Proprietario_Codigo==0 && Reg.Distrito==0 && Reg.Setor==0 & Reg.Quadra==0 & Reg.Lote==0 && Reg.CodigoCondominio==0 && 
                Reg.CodigoLogradouro==0 && Reg.Numero==0 && Reg.CodigoBairro == 0) {
                gtiCore.Liberado(this);
                MessageBox.Show("Selecione ao menos um critério para filtrar.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            MainListView.ListViewItemSorter = null;
            List<ImovelStruct> Lista = imovel_Class.Lista_Imovel(Reg);

            int _pos = 0, _total = Lista.Count;

            ArrayList itemlv = new ArrayList(3);
            foreach (var item in Lista) {
                itemlv.Add( item.Codigo.ToString("000000"));
                itemlv.Add( item.Inscricao.ToString());
                itemlv.Add( item.Proprietario_Nome.ToString());
                aDatResult.Add(itemlv);
            }
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = aDatResult.Count;
            MainListView.EndUpdate();

            /*            MainListView.BeginUpdate();
                        foreach (var item in Lista) {
                            ListViewItem lvi = new ListViewItem(item.Codigo.ToString("000000"));
                            lvi.SubItems.Add(item.Inscricao.ToString());
                            lvi.SubItems.Add(item.Proprietario_Nome.ToString());
                            lvi.SubItems.Add(item.NomeLogradouro);
                            lvi.SubItems.Add(item.Numero.ToString());
                            lvi.SubItems.Add(item.Complemento);
                            lvi.SubItems.Add(item.NomeBairro);
                            lvi.SubItems.Add(item.CodigoCondominio==999?"": item.NomeCondominio);
                            MainListView.Items.Add(lvi);
                            if (_pos % 20 == 0)
                                CallPB(PBar, _pos, _total);
                            _pos++;
                        }
                        MainListView.EndUpdate();*/
            MainListView.ListViewItemSorter = lvwColumnSorter;
            TotalImovel.Text = _total.ToString();
            PBar.Value = 0;
            gtiCore.Liberado(this);
            if(MainListView.Items.Count==0)
                MessageBox.Show("Nenhum imóvel coincide com os critérios especificados","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void CondominioButton_Click(object sender, EventArgs e) {
            using (var form = new Condominio_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    short val = form.ReturnValue;
                    Imovel_bll imovel_Class = new Imovel_bll(_connection);
                    Condominio.Text = imovel_Class.Dados_Condominio(val).Nome;
                    Condominio.Tag = val.ToString();
                }
            }
        }

        private void ProprietarioDelButton_Click(object sender, EventArgs e) {
            Proprietario.Text = "";
            Proprietario.Tag = "";
        }

        private void CondominioDelButton_Click(object sender, EventArgs e) {
            Condominio.Text = "";
            Condominio.Tag = "";
        }

        private void EnderecoAddButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
            };
            if (Bairro.Tag == null) Bairro.Tag = "0";
            reg.Id_bairro = string.IsNullOrWhiteSpace(Bairro.Tag.ToString()) ? 0 : Convert.ToInt32(Bairro.Tag.ToString());
            if (Logradouro.Tag == null) Logradouro.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()))
                Logradouro.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro.Text) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            reg.Nome_logradouro = Logradouro.Text ;
            reg.Numero_imovel = Numero.Text == "" ? 0 : Convert.ToInt32(Numero.Text);
            reg.Complemento = "";
            reg.Email = "";

            Forms.Endereco f1 = new Forms.Endereco(reg, true, true,false);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                Bairro.Text = f1.EndRetorno.Nome_bairro;
                Bairro.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero.Text = f1.EndRetorno.Numero_imovel.ToString();
            }
        }

        private void EnderecoDelButton_Click(object sender, EventArgs e) {
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Numero.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
        }

        private void ExcelButton_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog() {
                Filter = "Excel |* .xls",
                InitialDirectory = @"c:\dados\xls",
                FileName = "DadosListView_Excel_" + DateTime.Now.Millisecond.ToString() + ".xls",
                ValidateNames = true
            }) {
                if (sfd.ShowDialog() == DialogResult.OK) {
                    gtiCore.Ocupado(this);
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    ws.Cells[1, 1] = "Código";
                    ws.Cells[1, 2] = "Inscrição";
                    ws.Cells[1, 3] = "Proprietário";
                    ws.Cells[1, 4] = "Endereço";

                    int i = 2;
                    foreach (ListViewItem item in MainListView.Items) {
                        ws.Cells[i, 1] = item.SubItems[0].Text;
                        ws.Cells[i, 2] = item.SubItems[1].Text;
                        
                        ws.Cells[i, 3] = item.SubItems[2].Text;
                        ws.Cells[i, 4] = item.SubItems[3].Text;
                        i++;
                    }

//                    ws.Range["B2", "B10"].Style.NumberFormatLocal = "0";

                    ws.Columns.AutoFit();
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange,
                                XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
                    app.Quit();
                    gtiCore.Liberado(this);
                    MessageBox.Show("Seus dados foram exportados para o Excel com sucesso.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,"","","","",""}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };


        }
    }
}
