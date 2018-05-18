using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Desktop.Properties;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace GTI_Desktop.Forms {
    public partial class Documento_Detalhe : Form {


        public Documento_Detalhe(int Numero=0) {
            InitializeComponent();
            if (Numero > 0) {
                NumDocumentoText.Text = Numero.ToString("00000000");
            }
        }

        private void Carrega_Parcelas(int Numero) {

        }


    }
}
