using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_VS : Form {
        public CnaeStruct Item_VS { get; set; }

        public Empresa_VS(List<CnaeStruct> Lista_Cnae, List<CnaeStruct> Lista_Cnae_VS) {
            InitializeComponent();
            foreach (CnaeStruct item in Lista_Cnae) {
                bool _find = false;
                foreach (CnaeStruct itemvs in Lista_Cnae_VS) {
                    if (itemvs.CNAE == item.CNAE) {
                        _find = true;
                        break;
                    }
                }
                if (!_find) {
                    string reg = item.CNAE + "-" + item.Descricao;
                    CnaeList.Items.Add(reg);
                }
            }
            if (CnaeList.Items.Count > 0) CnaeList.SelectedIndex = 0;
        }
      

        private void CancelButton_Click(object sender, EventArgs e) {
            Item_VS = null;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e) {
            if (CnaeList.Items.Count == 0)
                MessageBox.Show("Selecione um Cnae.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Item_VS = new CnaeStruct();
                Item_VS.CNAE = CnaeList.Text.Substring(0, 9);
                Item_VS.Descricao = CnaeList.Text.Substring(10, CnaeList.Text.Length - 10);
                Close();
            }
        }

    }
}
