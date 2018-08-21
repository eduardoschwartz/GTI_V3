using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Empresa : Form {
        bool bAddNew;
        string _connection = gtiCore.Connection_Name();
        int hoveredIndex = -1;

        public Empresa() {
            gtiCore.Ocupado(this);
            InitializeComponent();
            tBar.Renderer = new MySR();
            ProfissionalToolStrip.Renderer = new MySR();
            VeiculosToolStrip.Renderer = new MySR();
            SimplesToolStrip.Renderer = new MySR();
            CodigoToolStrip.Renderer = new MySR();
            SilToolStrip.Renderer = new MySR();
            EnderecoToolStrip.Renderer =new MySR();
            EnderecoentregaToolStrip.Renderer = new MySR();
            CarregaLista();
            ClearFields();
            bAddNew = false;
            ControlBehaviour(true);
            gtiCore.Liberado(this);
        }

        private void ControlBehaviour(bool bStart) {
            AddButton.Enabled = bStart;
            EditButton.Enabled = bStart;
            DelButton.Enabled = bStart;
            SairButton.Enabled = bStart;
            PrintButton.Enabled = bStart;
            FindButton.Enabled = bStart;
            GravarButton.Enabled = !bStart;
            CancelarButton.Enabled = !bStart;
            CodigoButton.Enabled = bStart;
            EnderecoButton.Enabled = !bStart;
            RemoveContadorButon.Enabled = !bStart;
            EnderecoentregaButton.Enabled = !bStart;
            ProprietarioAddButton.Enabled = !bStart;
            ProprietarioDelButton.Enabled = !bStart;
            ProfissionalAddButton.Enabled = !bStart;
            ProfissionalDelButton.Enabled = !bStart;
            PessoaList.Enabled = !bStart;
            PessoaList.Visible = !bStart;
            PessoaText.Visible = bStart;
            InscEstadual.ReadOnly = bStart;
            CNPJ.ReadOnly = bStart;
            CPF.ReadOnly = bStart;
            RazaoSocial.ReadOnly = bStart;
            RG.ReadOnly = bStart;
            NomeFantasia.ReadOnly = bStart;
            DataAbertura.ReadOnly = bStart;
            NumProcessoAbertura.ReadOnly = bStart;
            DataEncerramento.ReadOnly = bStart;
            NumProcessoEncerramento.ReadOnly = bStart;
            HorarioFuncionamento.Visible = bStart;
            HorarioList.Visible = !bStart;
            HorarioList.Enabled = !bStart;
            PontoAgencia.ReadOnly = bStart;
            HorarioExtenso.ReadOnly = bStart;
            QtdeFuncionario.ReadOnly = bStart;
            CapitalSocial.ReadOnly = bStart;
            PlacaOKButton.Enabled = !bStart;
            PlacaCancelButton.Enabled = !bStart;
            Placa.ReadOnly = bStart;
            InscTemp_chk.AutoCheck = !bStart;
            SustitutoTrib_chk.AutoCheck = !bStart;
            AlvaraAuto_chk.AutoCheck = !bStart;
            IsentoIss_chk.AutoCheck = !bStart;
            IsentoTaxa_chk.AutoCheck = !bStart;
            EmpresaInd_chk.AutoCheck = !bStart;
            LiberadoVRE_chk.AutoCheck = !bStart;
            Horas24_chk.AutoCheck = !bStart;
            Bombonieri_chk.AutoCheck = !bStart;
            Vistoria_chk.AutoCheck = !bStart;
            MesmoEndereco.AutoCheck = !bStart;
            ContatoNome.ReadOnly = bStart;
            ContatoFone.ReadOnly = bStart;
            ContatoEmail.ReadOnly = bStart;
            ContatoCargo.ReadOnly = bStart;
            ProfissionalConselho.ReadOnly = bStart;
            ProfissionalRegistro.ReadOnly = bStart;
            ContadorList.Visible = !bStart;
            ContadorList.Enabled = !bStart;

        }

        private void ClearFields() {
            Codigo.Text = "000000";
            InscEstadual.Text = "";
            PessoaText.Text = "";
            PessoaList.SelectedIndex = 1;
            CPF.Text = "";
            CNPJ.Text = "";
            RazaoSocial.Text = "";
            NomeFantasia.Text = "";
            DataAbertura.Text = "";
            NumProcessoAbertura.Text = "";
            DataProcessoAbertura.Text = "";
            DataEncerramento.Text = "";
            NumProcessoEncerramento.Text = "";
            DataProcessoEncerramento.Text = "";
            HorarioFuncionamento.Text = "";
            HorarioList.SelectedIndex = -1;
            PontoAgencia.Text = "";
            HorarioExtenso.Text = "";
            QtdeFuncionario.Text = "";
            CapitalSocial.Text = "";
            ProcessosListView.Items.Clear();
            Placa.Text = "";
            InscTemp_chk.Checked = false;
            SustitutoTrib_chk.Checked = false;
            AlvaraAuto_chk.Checked = false;
            IsentoIss_chk.Checked = false;
            IsentoTaxa_chk.Checked = false;
            EmpresaInd_chk.Checked = false;
            LiberadoVRE_chk.Checked = false;
            Horas24_chk.Checked = false;
            Bombonieri_chk.Checked = false;
            Vistoria_chk.Checked = false;
            StatusEmpresa.Text = "";
            SimplesNacional.Text = "NÃO";
            OptanteMei.Text = "NÃO";
            Logradouro.Text = "";
            Numero.Text = "";
            Complemento.Text = "";
            Cep.Text = "";
            Bairro.Text = "";
            Cidade.Text = "";
            UF.Text = "";
            CodigoImovel.Text = "000000";
            Logradouro_EE.Text = "";
            Numero_EE.Text = "";
            Complemento_EE.Text = "";
            Cep_EE.Text = "";
            Bairro_EE.Text = "";
            Cidade_EE.Text = "";
            UF_EE.Text = "";
            MesmoEndereco.Checked = false;
            Distrito.Text = "0";
            Setor.Text = "00";
            Quadra.Text = "0000";
            Lote.Text = "00000";
            Face.Text = "00";
            Unidade.Text = "00";
            Subunidade.Text = "000";
            HomePage.Text = "";
            ContatoNome.Text = "";
            ContatoCargo.Text = "";
            ContatoEmail.Text = "";
            ContatoFone.Text = "";
            ContadorNome.Text = "";
            ContadorFone.Text = "";
            ContadorEmail.Text = "";
            ProfissionalNome.Text = "";
            ProfissionalRegistro.Text = "";
            ProfissionalConselho.Text = "";

        }

        private void CarregaLista() {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            HorarioList.DataSource = empresa_Class.Lista_Horario();
            HorarioList.DisplayMember = "deschorario";
            HorarioList.ValueMember = "codhorario";

            ContadorList.DataSource = empresa_Class.Lista_Escritorio_Contabil();
            ContadorList.DisplayMember = "Nomeesc";
            ContadorList.ValueMember = "Codigoesc";
            
        }

        private void GravarButton_Click(object sender, EventArgs e) {
            if (bAddNew) {
                ControlBehaviour(true);
            }
            
        }

        private void CancelarButton_Click(object sender, EventArgs e) {
            ControlBehaviour(true);
        }

        private void AddButton_Click(object sender, EventArgs e) {
            bAddNew = true;
            ClearFields();
            ControlBehaviour(false);
        }

        private void EditButton_Click(object sender, EventArgs e) {
            bAddNew = false;
            ControlBehaviour(false);
        }

        private void PessoaList_SelectedIndexChanged(object sender, EventArgs e) {
            if (PessoaList.SelectedIndex == 0) {
                CPF.Visible = true;
                CNPJ.Visible = false;
                PessoaLabel.Text = "CPF...:";
                PessoaText.Text = "Física";
            } else if (PessoaList.SelectedIndex == 1) {
                CPF.Visible = false;
                CNPJ.Visible = true;
                PessoaLabel.Text = "CNPJ..:";
                PessoaText.Text = "Jurídica";
            }
        }

        private void HorarioList_SelectedIndexChanged(object sender, EventArgs e) {
            if (HorarioList.SelectedIndex > -1) {
                HorarioFuncionamento.Text = HorarioList.Text;
                HorarioFuncionamento.Tag = HorarioList.SelectedValue.ToString();
            } else {
                HorarioFuncionamento.Text = "";
                HorarioFuncionamento.Tag = "0";
            }
        }

        private void ContadorList_SelectedIndexChanged(object sender, EventArgs e) {
            if (ContadorList.SelectedIndex > -1) {
                ContadorNome.Text = ContadorList.Text;
                ContadorNome.Tag = ContadorList.SelectedValue.ToString();
            } else {
                ContadorNome.Text = "";
                ContadorNome.Tag = "0";
            }
        }

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void MesmoEndereco_CheckedChanged(object sender, EventArgs e) {
            if (MesmoEndereco.CheckState == CheckState.Checked) {
                Logradouro_EE.Text = Logradouro.Text;
                Logradouro_EE.Tag = Logradouro.Tag;
                Numero_EE.Text = Numero.Text;
                Complemento_EE.Text = Complemento.Text;
                Bairro_EE.Text = Bairro.Text;
                Bairro_EE.Tag = Bairro.Tag;
                Cidade_EE.Text = Cidade.Text;
                Cidade_EE.Tag = Cidade.Tag;
                UF_EE.Text = UF.Text;
                Cep_EE.Text = Cep.Text;
            }
        }

        private void SILList_MouseMove(object sender, MouseEventArgs e) {
            int newHoveredIndex = SILList.IndexFromPoint(e.Location);
            //ToolTip para a lista SIL
            if (hoveredIndex != newHoveredIndex) {
                hoveredIndex = newHoveredIndex;
                if (hoveredIndex > -1) {
                    Ttp.Active = false;
                    Ttp.SetToolTip(SILList, ((sil)SILList.Items[hoveredIndex]).Sil);
                    Ttp.Active = true;
                }
            }
        }

        private void QtdeFuncionario_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private void CapitalSocial_KeyPress(object sender, KeyPressEventArgs e) {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 44)) {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == 44) {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void CodigoButton_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite a inscrição municipal.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrEmpty(sCod)) {
                gtiCore.Ocupado(this);
                Empresa_bll empresa_Class = new Empresa_bll(_connection);
                int nCodigo = Convert.ToInt32(sCod);
                if (empresa_Class.Existe_Empresa(nCodigo)) {
                    ClearFields();
                    Codigo.Text = nCodigo.ToString("000000");
                    Carrega_Empresa(nCodigo);
                } else
                    MessageBox.Show("Empresa não cadastrada.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gtiCore.Liberado(this);
            }
        }

        private void Carrega_Empresa(int Codigo) {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            EmpresaStruct Reg = empresa_Class.Retorna_Empresa(Codigo);
            RazaoSocial.Text = Reg.Razao_social;
            NomeFantasia.Text = Reg.Nome_fantasia;
            InscEstadual.Text = Reg.Inscricao_estadual;
            if (Reg.Juridica) {
                PessoaList.SelectedIndex = 1;
                CNPJ.Text = Reg.Cpf_cnpj;
                PessoaText.Text = "Jurídica";
            } else {
                PessoaList.SelectedIndex = 0;
                CPF.Text = Reg.Cpf_cnpj;
                PessoaText.Text = "Física";
            }
            RG.Text = Reg.Rg;

            StatusEmpresa.Text =  Reg.Situacao + "  ";
            if (Reg.Situacao == "ATIVA")
                StatusEmpresa.ForeColor = Color.Green;
            else if (Reg.Situacao == "ENCERRADA")
                StatusEmpresa.ForeColor = Color.Red;
            else 
                StatusEmpresa.ForeColor = Color.Blue;

            DataAbertura.Text = Convert.ToDateTime( Reg.Data_abertura).ToString("dd/MM/yyyy");
            NumProcessoAbertura.Text = Reg.Numprocesso;
            if(gtiCore.IsDate(Reg.Dataprocesso.ToString()))
                DataProcessoAbertura.Text=Convert.ToDateTime(Reg.Dataprocesso).ToString("dd/MM/yyyy");
            if (gtiCore.IsDate(Reg.Data_Encerramento.ToString())) {
                DataEncerramento.Text = Convert.ToDateTime( Reg.Data_Encerramento).ToString("dd/MM/yyyy");
                NumProcessoEncerramento.Text = Reg.Numprocessoencerramento;
                if (gtiCore.IsDate(Reg.Dataprocencerramento.ToString()))
                    DataProcessoEncerramento.Text = Convert.ToDateTime(Reg.Dataprocencerramento).ToString("dd/MM/yyyy");
            }
            if(Reg.Horario!=null)
                HorarioList.SelectedValue = Reg.Horario;
            PontoAgencia.Text = Reg.Ponto_agencia;
            HorarioExtenso.Text = Reg.Horario_extenso;
            QtdeFuncionario.Text = Reg.Qtde_empregado.ToString();
            CapitalSocial.Text = Reg.Capital_social.ToString();
            InscTemp_chk.Checked = Reg.Inscricao_temporaria == 1 ? true : false;
            SustitutoTrib_chk.Checked = (bool)Reg.Substituto_tributario_issqn ;
            IsentoIss_chk.Checked = Reg.Isento_iss == 1 ? true : false;
            IsentoTaxa_chk.Checked = Reg.Isento_taxa == 1 ? true : false;
            EmpresaInd_chk.Checked =  (bool)Reg.Individual;
            LiberadoVRE_chk.Checked = (bool)Reg.Liberado_vre;
            Horas24_chk.Checked = Reg.Horas_24 == 1 ? true : false;
            Bombonieri_chk.Checked = Reg.Bombonieri == 1 ? true : false;
            Vistoria_chk.Checked = Reg.Vistoria == 1 ? true : false;

            PlacaLista.DataSource = empresa_Class.Lista_Placas(Codigo);
            PlacaLista.DisplayMember = "Placa";

            SILList.DataSource = empresa_Class.Lista_Sil(Codigo);
            SILList.DisplayMember = "Sil";

            bool bMei = empresa_Class.Empresa_Mei(Codigo);
            if (bMei) {
                OptanteMei.Text = "SIM";
                OptanteMei.ForeColor = Color.Green;
            }else {
                OptanteMei.Text = "NÃO";
                OptanteMei.ForeColor = Color.DarkRed;
            }

            bool bSimples = empresa_Class.Empresa_Simples(Codigo,DateTime.Now);
            if (bSimples) {
                SimplesNacional.Text =  "SIM" ;
                SimplesNacional.ForeColor = Color.Green;
                SimplesButton.Enabled = true;
            } else {
                SimplesNacional.Text = "NÃO";
                SimplesNacional.ForeColor = Color.DarkRed;
                SimplesButton.Enabled = false;
            }

            Logradouro.Text = Reg.Endereco_nome;
            Logradouro.Tag = Reg.Endereco_codigo.ToString();
            Numero.Text = Reg.Numero.ToString();
            Complemento.Text = Reg.Complemento;
            Bairro.Text = Reg.Bairro_nome;
            Bairro.Tag = Reg.Bairro_codigo.ToString();
            Cidade.Text = Reg.Cidade_nome;
            Cidade.Tag = Reg.Cidade_codigo.ToString();
            UF.Text = Reg.UF;
            Cep.Text = Reg.Cep;

            mobiliarioendentrega endEntrega = empresa_Class.Empresa_Endereco_entrega(Codigo);
            if (!string.IsNullOrWhiteSpace(endEntrega.Nomelogradouro)) {
                Logradouro_EE.Text = endEntrega.Nomelogradouro;
                Logradouro_EE.Tag = endEntrega.Codlogradouro.ToString();
                Numero_EE.Text = endEntrega.Numimovel.ToString();
                Complemento_EE.Text = endEntrega.Complemento;
                Bairro_EE.Text = endEntrega.Descbairro;
                Bairro_EE.Tag = endEntrega.Codbairro.ToString();
                Cidade_EE.Text = endEntrega.Desccidade;
                Cidade_EE.Tag = endEntrega.Codcidade.ToString();
                UF_EE.Text = endEntrega.Uf;
                Cep_EE.Text = endEntrega.Cep;
                MesmoEndereco.Checked = false;
            } else
                MesmoEndereco.Checked = true;

            Distrito.Text = Reg.Distrito.ToString();
            Setor.Text = Reg.Setor.ToString("00");
            Quadra.Text = Reg.Quadra.ToString("0000");
            Lote.Text = Reg.Lote.ToString("00000");
            Face.Text = Reg.Seq.ToString("00");
            Unidade.Text = Reg.Unidade.ToString("00");
            Subunidade.Text = Reg.Subunidade.ToString("000");
            CodigoImovel.Text =Convert.ToInt32(Reg.Imovel).ToString("000000");

            ProprietarioList.DataSource = empresa_Class.Lista_Empresa_Proprietario(Codigo);
            ProprietarioList.DisplayMember = "Nome";

            ContatoNome.Text = Reg.Nome_contato;
            ContatoCargo.Text = Reg.Cargo_contato;
            ContatoFone.Text = Reg.Fone_contato;
            ContatoEmail.Text = Reg.Email_contato;

            if (Reg.Responsavel_contabil_codigo != null && Reg.Responsavel_contabil_codigo>0) {
                ContadorList.SelectedValue = Reg.Responsavel_contabil_codigo;
                EscritoriocontabilStruct RegEsc = empresa_Class.Dados_Escritorio_Contabil((int)Reg.Responsavel_contabil_codigo);
                ContadorNome.Text = RegEsc.Nome;
                ContadorEmail.Text = RegEsc.Email;
                ContadorFone.Text = RegEsc.Telefone;
            }

            ProfissionalNome.Text = Reg.prof_responsavel_nome;
            ProfissionalNome.Tag = Reg.prof_responsavel_codigo;
            ProfissionalConselho.Text = Reg.Prof_responsavel_conselho;
            ProfissionalRegistro.Text = Reg.Prof_responsavel_registro;



        }

    }
}
