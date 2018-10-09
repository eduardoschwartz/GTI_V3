using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa_VS : Form {
        private string _connection = gtiCore.Connection_Name();
        public CnaeStruct Item_VS { get; set; }

        public Empresa_VS(List<CnaeStruct> Lista_Cnae, List<CnaeStruct> Lista_Cnae_VS) {
            InitializeComponent();
            if (Lista_Cnae == null)
                Lista_Cnae = new List<CnaeStruct>();

            foreach (CnaeStruct item in Lista_Cnae_VS) {
                string reg = item.CNAE + "-" + item.Descricao;
                CnaeList.Items.Add(reg);
            }

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

        private void CnaeList_SelectedIndexChanged(object sender, EventArgs e) {
            if (CnaeList.SelectedIndex > -1) {
                Empresa_bll empresa_Class = new Empresa_bll(_connection);
                string _cnae = gtiCore.ExtractNumber(CnaeList.Text.Substring(0,9));
                List<CnaecriterioStruct>  ListaCriterio = empresa_Class.Lista_Cnae_Criterio(_cnae);
                CriterioList.Items.Clear();
                foreach (var item in CriterioList.Items) {

                }
            }
        }



    }
}
