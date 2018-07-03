using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Certidao : Form {
        private string _connection = gtiCore.Connection_Name();

        public Certidao() {
            InitializeComponent();
            TBar.Renderer = new MySR();
            TipoList.SelectedIndex = 0;
        }

        private void ClearFields() {
            Nome.Text = "";
            Endereco.Text = "";
            Bairro.Text = "";
            Cidade.Text = "";
            Cep.Text = "";
            Quadra.Text = "";
            Lote.Text = "";
            Atividade.Text = "";
            Inscricao.Text = "";
            Doc.Text = "";
        }
        
        private void Dados_Impressao(int Codigo) {
            Sistema_bll sistema_Class = new Sistema_bll(_connection);
            Contribuinte_Header_Struct header = sistema_Class.Contribuinte_Header(Codigo);
            if (header == null)
                MessageBox.Show("Código não cadastrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                Nome.Text = header.Nome;
                Endereco.Text = header.Endereco + ", " + header.Numero.ToString();
                Bairro.Text = header.Nome_bairro;
                Cidade.Text = header.Nome_cidade + "/" + header.Nome_uf;
                Cep.Text = header.Cep;
                Inscricao.Text = header.Inscricao;
                if (header.Cpf_cnpj != "") {
                    if (header.Cpf_cnpj.Length == 11)
                        Doc.Text = Convert.ToInt64(header.Cpf_cnpj).ToString(@"000\.000\.000\-00");
                    else
                        Doc.Text = Convert.ToInt64(header.Cpf_cnpj).ToString(@"00\.000\.000\/0000\-00");
                }
                Quadra.Text = header.Quadra_original;
                Lote.Text = header.Lote_original;
                if (Codigo >= 100000 && Codigo < 500000) {
                    Empresa_bll empresa_Class = new Empresa_bll(_connection);
                    EmpresaStruct dados = empresa_Class.Retorna_Empresa(Codigo);
                    Atividade.Text = dados.Atividade_extenso;
                }
            }
        }

        private void Codigo_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void Processo_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char)Keys.Return && e.KeyChar != (char)Keys.Tab) {
                const char Delete = (char)8;
                const char Minus = (char)45;
                const char Barra = (char)47;
                if (e.KeyChar == Minus && Processo.Text.Contains("-"))
                    e.Handled = true;
                else {
                    if (e.KeyChar == Barra && Processo.Text.Contains("/"))
                        e.Handled = true;
                    else
                        e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Barra && e.KeyChar != Minus;
                }
            }
        }

        private void VerificarButton_Click(object sender, EventArgs e) {
            int _codigo;

            if (Codigo.Text.Trim() == "")
                MessageBox.Show("Código não informado.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                if (Processo.Text.Trim() == "")
                    MessageBox.Show("Processo não informado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    Processo_bll processo_Class = new Processo_bll(_connection);
                    Exception ex = processo_Class.ValidaProcesso(Processo.Text);
                    if(ex!=null)
                        MessageBox.Show("Processo não cadastrado ou inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else {
                        _codigo = Convert.ToInt32(Codigo.Text);
                        Dados_Impressao(_codigo);



                    }
                }
            }

        }

        




    }
}
