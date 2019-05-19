using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Extrato_Debito_Cancelar : Form {
        public int ReturnValue { get; set; }
        string _connection = gtiCore.Connection_Name();

        public Extrato_Debito_Cancelar(List<SpExtrato> Lista) {
            InitializeComponent();
            foreach (SpExtrato item in Lista) {
                ListViewItem lv = new ListViewItem(item.Anoexercicio.ToString());
                lv.SubItems.Add(item.Desclancamento);
                lv.SubItems.Add(item.Seqlancamento.ToString());
                lv.SubItems.Add(item.Numparcela.ToString());
                lv.SubItems.Add(item.Codcomplemento.ToString());
                lv.SubItems.Add(item.Datavencimento.ToString("dd/MM/yyyy"));
                lv.SubItems.Add(item.Valortributo.ToString("#0.00"));
                MainListView.Items.Add(lv);
            }

            List<CustomListBoxItem> myItems = new List<CustomListBoxItem>();
            myItems.Add(new CustomListBoxItem("Cancelado pelo motivo abaixo" , 5));
            myItems.Add(new CustomListBoxItem("Cancelado por duplicidade", 12));
            myItems.Add(new CustomListBoxItem("Cancelado por recurso", 8));
            myItems.Add(new CustomListBoxItem("Compensado por recurso", 6));
            myItems.Add(new CustomListBoxItem("Compensação tributária", 32));
            myItems.Add(new CustomListBoxItem("ISS variável sem movimento", 14));
            myItems.Add(new CustomListBoxItem("Retido pelo tomador", 27));
            myItems.Add(new CustomListBoxItem("Suspensão de débito/Trâmite", 19));

            TipoList.DisplayMember = "_name";
            TipoList.ValueMember = "_value";
            TipoList.DataSource = myItems;
            TipoList.SelectedIndex = 0;
        }

        private void SairButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        private void TipoList_SelectedIndexChanged(object sender, EventArgs e) {
            CustomListBoxItem _tipo_Cancel = (CustomListBoxItem)TipoList.SelectedItem;
            if (_tipo_Cancel._value == 5 || _tipo_Cancel._value == 12) {
                DataProcessoText.Text = "";
                NumeroProcessoText.Text = "";
                NumeroProcessoText.ReadOnly = true;
                NumeroProcessoText.BackColor = BackColor;
            } else {
                NumeroProcessoText.ReadOnly = false;
                NumeroProcessoText.BackColor = Color.White;
            }
        }

        private void NumeroProcessoText_Leave(object sender, EventArgs e) {
            if (!String.IsNullOrEmpty(NumeroProcessoText.Text)) {
                Processo_bll processo_Class = new Processo_bll(_connection);
                Exception ex = processo_Class.ValidaProcesso(NumeroProcessoText.Text);
                if (ex == null) {
                    int _numero_processo = processo_Class.ExtractNumeroProcessoNoDV(NumeroProcessoText.Text);
                    int _ano_processo = processo_Class.ExtractAnoProcesso(NumeroProcessoText.Text);
                    ProcessoStruct _processo = processo_Class.Dados_Processo(_ano_processo, _numero_processo);
                    DataProcessoText.Text = Convert.ToDateTime(_processo.DataEntrada).ToString("dd/MM/yyyy");
                } else {
                    ErrorBox eBox = new ErrorBox("Atenção", ex.Message, ex);
                    DataProcessoText.Text = "";
                    NumeroProcessoText.Focus();
                    eBox.ShowDialog();
                }
            }
        }

        private void NumeroProcessoText_TextChanged(object sender, EventArgs e) {
            if (DataProcessoText.Text != "")
                DataProcessoText.Text = "";
        }

        private void NumeroProcessoText_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                NumeroProcessoText_Leave(sender, e);
        }

        private void CancelarButton_Click(object sender, EventArgs e) {
            if (NumeroProcessoText.ReadOnly == false && !gtiCore.IsDate(DataProcessoText.Text)) {
                MessageBox.Show("Número de processo não cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Confirmar operação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {


                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

    }
}
