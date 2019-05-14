using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Parcelamento_Lista : Form {
        string _connection = gtiCore.Connection_Name();

        public Parcelamento_Lista(List<Processo_Numero> Lista) {
            InitializeComponent();

            foreach (Processo_Numero item in Lista) {
               CustomListBoxItem5 cbItem = new CustomListBoxItem5(item.Numero_processo, (int)item.Numero, (int)item.Ano);
                ProcessoList.Items.Add(cbItem);
            }
            ProcessoList.SelectedIndex = 0;
        }

        private void ProcessoList_SelectedIndexChanged(object sender, System.EventArgs e) {
            gtiCore.Ocupado(this);
            OrigemListView.Items.Clear();
            if (ProcessoList.SelectedItem != null) {
                CustomListBoxItem5 selectedItem =(CustomListBoxItem5)ProcessoList.SelectedItem;
                int _numero_processo = selectedItem._value;
                int _ano_processo = selectedItem._value2;

                Tributario_bll tributario_Class = new Tributario_bll(_connection);
                List<OrigemReparcStruct> Lista = tributario_Class.Lista_Origem_Parcelamento(_ano_processo, _numero_processo);
                foreach (OrigemReparcStruct item in Lista) {
                    ListViewItem lv = new ListViewItem(item.Exercicio.ToString());
                    lv.SubItems.Add(item.Lancamento_Codigo.ToString("00") + "-" + item.Lancamento_Descricao   );
                    lv.SubItems.Add(item.Sequencia.ToString());
                    lv.SubItems.Add(item.Parcela.ToString("00"));
                    lv.SubItems.Add(item.Complemento.ToString("00"));
                    OrigemListView.Items.Add(lv);
                }
            }
            gtiCore.Liberado(this);
        }


    }
}
