using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Escritorio_Contabil : Form {

        bool bAddNew;
        int _CodEscritorio = 0;
        string _connection = gtiCore.Connection_Name();

        public int CodCidadao {
            get { return (_CodEscritorio); }
            set {
                _CodEscritorio = value;
                bAddNew = false;
                CarregaDados(_CodEscritorio);
            }
        }

        public Escritorio_Contabil() {
            InitializeComponent();
            
            tBar.Renderer = new MySR();
            Clear_Reg();
            ControlBehaviour(true);
        }

        private void Clear_Reg() {
            Nome.Text = "";
            Nome.Tag = "";
            CPF.Text = "";
            CNPJ.Text = "";
            IM.Text = "";
            Logradouro.Text = "";
            Logradouro.Tag = "";
            Numero.Text = "";
            Complemento.Text = "";
            Bairro.Text = "";
            Bairro.Tag = "";
            Cidade.Text = "";
            Cidade.Tag = "";
            UF.Text = "";
            Cep.Text = "";
            Pais.Text = "";
            Fone.Text = "";
            Email.Text = "";
            RecebeCarneCheck.Checked = false;
        }

        private void IM_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void ControlBehaviour(bool bStart) {
            Color color_disable = !bStart ? Color.White : BackColor;
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            FindButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            EnderecoButton.Enabled = !bStart;

            Nome.ReadOnly = bStart;
            CPF.ReadOnly = bStart;
            CNPJ.ReadOnly = bStart;
            IM.ReadOnly = bStart;
            IM.BackColor = color_disable;
            RecebeCarneCheck.Enabled = !bStart;

        }

        private void CancelButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bAddNew = true;
            ControlBehaviour(false);
        }

        private void EditButton_Click(object sender, EventArgs e) {
            bAddNew=false;
            ControlBehaviour(false);
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void FindButton_Click(object sender, EventArgs e) {
            using (var form = new Escritorio_Contabil_Lista()) {
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int val = form.ReturnValue;
                    CarregaDados(val);
                }
            }
        }

        private void CarregaDados(int Codigo) {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            EscritoriocontabilStruct reg = empresa_Class.Dados_Escritorio_Contabil(Codigo);
            Nome.Text = reg.Nome;
            CPF.Text = reg.Cpf;
            CNPJ.Text = reg.Cnpj;
            IM.Text = reg.Im.ToString();
            Logradouro.Text = reg.Logradouro_Nome;
            Logradouro.Tag = reg.Logradouro_Codigo.ToString();
            Numero.Text = reg.Numero.ToString();
            Complemento.Text = reg.Complemento;
            Bairro.Text = reg.Bairro_Nome;
            Bairro.Tag = reg.Bairro_Codigo.ToString();
            Cidade.Text = reg.Cidade_Nome;
            Cidade.Tag = reg.Cidade_Codigo.ToString();
            UF.Text = reg.UF;
            Cep.Text = reg.Cep;
            Fone.Text = reg.Telefone;
            Email.Text = reg.Email;
            Pais.Text = "BRASIL";
            RecebeCarneCheck.Checked = (bool)reg.Recebecarne;
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            Escritoriocontabil reg = new Escritoriocontabil();
            reg.Cep = Cep.Text;
            reg.Cnpj = CNPJ.Text;
            reg.Codbairro = Convert.ToInt16(Bairro.Tag);
            reg.Codcidade = Convert.ToInt32(Cidade.Tag);
            reg.Codigoesc = Convert.ToInt16(Codigo.Text);
            reg.Codlogradouro = Convert.ToInt32(Logradouro.Tag);
            reg.Complemento = Complemento.Text;
            reg.Cpf = CPF.Text;
            reg.Crc = Crc.Text;
            reg.Email = Email.Text;
            reg.Im = Convert.ToInt32(IM.Text);
            reg.Nomeesc = Nome.Text;
            reg.Nomelogradouro = Logradouro.Text;
            reg.Numero = Convert.ToInt32(Numero.Text);
            reg.Recebecarne = RecebeCarneCheck.Checked;
            reg.Telefone = Fone.Text;
            reg.UF = UF.Text;


            ControlBehaviour(true);
        }


    }
}
