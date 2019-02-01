using GTI_Desktop.Classes;
using GTI_Models.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Parcelamento_Lista : Form {
        public Parcelamento_Lista(List<Processo_Numero> Lista) {
            InitializeComponent();

            foreach (Processo_Numero item in Lista) {
               CustomListBoxItem5 cbItem = new CustomListBoxItem5(item.Numero_processo, (int)item.Numero, (int)item.Ano);
                ProcessoList.Items.Add(cbItem);
            }
            ProcessoList.SelectedIndex = 0;

        }

        private void ProcessoList_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (ProcessoList.SelectedItem != null) {
                CustomListBoxItem5 selectedItem =(CustomListBoxItem5)ProcessoList.SelectedItem;



            }
        }
    }

}
