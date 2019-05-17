using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Extrato_Debito_Cancelar : Form {
        public int ReturnValue { get; set; }

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

        private void CancelarButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();

        }
    }
}
