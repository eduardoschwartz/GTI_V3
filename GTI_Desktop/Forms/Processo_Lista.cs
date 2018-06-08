using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Processo_Lista : Form
    {
        string _connection = gtiCore.Connection_Name();
        public ProcessoNumero ReturnValue { get; set; } = new ProcessoNumero();
        List<ArrayList> aDatResult;

        public Processo_Lista()
        {
            InitializeComponent();
            ProprietarioToolStrip.Renderer = new MySR();
            SetorToolStrip.Renderer = new MySR();
            AssuntoToolStrip.Renderer = new MySR();
            InternoList.SelectedIndex = 0;
            FisicoList.SelectedIndex = 0;
            ReadDatFile();
        }

        private void ReadDatFile() {

        }

        private void SaveDatFile() {

        }

        private void SelectButton_Click(object sender, System.EventArgs e) {
            ListView.SelectedIndexCollection col = MainListView.SelectedIndices;
            if (col.Count > 0) {
                DialogResult = DialogResult.OK;
                ReturnValue.Ano = Convert.ToInt32(MainListView.Items[col[0]].Text);
                ReturnValue.Numero = Convert.ToInt32(MainListView.Items[col[0]].SubItems[1].Text.Substring(0,5));
                SaveDatFile();
                Close();
            } else {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show("Selecione um Cidadão.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Close();
        }

        private void AnoInicial_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void AnoFinal_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Fill_List() {
            gtiCore.Ocupado(this);

            //***Construção do filtro ****
            Processo_bll processo_Class = new Processo_bll(_connection);
            ProcessoFilter Reg = new ProcessoFilter();
            if (!String.IsNullOrEmpty(NumeroProcesso.Text)) {
                Reg.Ano = processo_Class.ExtractAnoProcesso(NumeroProcesso.Text);
                Reg.Numero = processo_Class.NumProcessoNoDV(NumeroProcesso.Text);
                Reg.SNumProcesso = NumeroProcesso.Text;
            } else {
                Reg.Ano = 0;
                Reg.Numero = 0;
                Reg.SNumProcesso = "";
            }
            Reg.AnoIni = AnoInicial.Text.Trim() == "" ? 0 : Convert.ToInt32(AnoInicial.Text);
            Reg.AnoFim = AnoFinal.Text.Trim() == "" ? 0 : Convert.ToInt32(AnoFinal.Text);

            //********************************



            List<ProcessoStruct> Lista = processo_Class.Lista_Processos(Reg);
            List<ProcessoNumero> aCount = new List<ProcessoNumero>(); //usado na totalização dos processos
            
            int _total = 0;
            if (aDatResult == null) aDatResult = new List<ArrayList>();
            aDatResult.Clear();
            foreach (var item in Lista) {

                //Array para totalizar os processos distintos, desta forma processos com mais de um endereço serão contados apenas 1 vez.
                bool bFind = false;
                for (int i = 0; i < aCount.Count; i++) {
                    if (aCount[i].Ano==item.Ano && aCount[i].Numero == item.Numero) {
                        bFind = true;
                        break;
                    }
                }
                if (!bFind) {
                    aCount.Add(new ProcessoNumero { Ano = item.Ano, Numero = item.Numero });
                    _total++;
                }
                //******************************************

                ArrayList itemlv = new ArrayList();
                itemlv.Add(item.Ano.ToString());
                itemlv.Add(item.Numero.ToString("00000") + "-" +  processo_Class.DvProcesso( item.Numero));
                itemlv.Add(item.NomeCidadao);
                itemlv.Add(item.Assunto);
                itemlv.Add(Convert.ToDateTime(item.DataEntrada).ToString("dd/MM/yyyy"));
                if (item.DataCancelado != null)
                    itemlv.Add(Convert.ToDateTime(item.DataCancelado).ToString("dd/MM/yyyy"));
                else
                    itemlv.Add("");
                if (item.DataArquivado != null)
                    itemlv.Add(Convert.ToDateTime(item.DataArquivado).ToString("dd/MM/yyyy"));
                else
                    itemlv.Add("");
                if (item.DataReativacao != null)
                    itemlv.Add(Convert.ToDateTime(item.DataReativacao).ToString("dd/MM/yyyy"));
                else
                    itemlv.Add("");
                if (item.Interno )
                    itemlv.Add("S");
                else
                    itemlv.Add("N");
                if (item.Fisico)
                    itemlv.Add("S");
                else
                    itemlv.Add("N");
                string sEndereco = item.LogradouroNome ?? "";
                string sNumero = item.LogradouroNumero ?? "";
                if (sEndereco != "")
                    itemlv.Add(sEndereco + ", " + sNumero ?? "");
                else
                    itemlv.Add("");

                aDatResult.Add(itemlv);
            }
            MainListView.BeginUpdate();
            MainListView.VirtualListSize = aDatResult.Count;
            MainListView.EndUpdate();

            Total.Text = _total.ToString();
            gtiCore.Liberado(this);
            if (MainListView.Items.Count == 0)
                MessageBox.Show("Nenhum contribuinte coincide com os critérios especificados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void MainListView_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            var acc = aDatResult[e.ItemIndex];
            e.Item = new ListViewItem(
                new string[]
                { acc[0].ToString(), acc[1].ToString(), acc[2].ToString() ,acc[3].ToString(),acc[4].ToString(),acc[5].ToString(),acc[6].ToString(),acc[7].ToString(),
                    acc[8].ToString(),acc[9].ToString(),acc[10].ToString()}) {
                Tag = acc,
                BackColor = e.ItemIndex % 2 == 0 ? Color.Beige : Color.White
            };
        }

        private void FindButton_Click(object sender, EventArgs e) {
            MainListView.Items.Clear();
            if (ValidaProcesso())
                Fill_List();
            else
                MessageBox.Show("Nenhum processo coincide com o filtro selecionado.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NumeroProcesso_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && NumeroProcesso.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && NumeroProcesso.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private bool ValidaProcesso() {
            bool bRet = true;
            if (!String.IsNullOrEmpty(NumeroProcesso.Text)) {
                Processo_bll clsProcesso = new Processo_bll(_connection);
                Exception ex = clsProcesso.ValidaProcesso(NumeroProcesso.Text);
                if (ex != null) 
                    bRet = false;
            } 
            return bRet;
        }


    }
}
