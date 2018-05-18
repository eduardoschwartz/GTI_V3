using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static GTI_Desktop.Classes.GtiTypes;

namespace GTI_Desktop.Forms {
    public partial class Empresa : Form {
        bool bAddNew;
        string _connection = gtiCore.Connection_Name();
        int hoveredIndex = -1;

        public Empresa() {
            gtiCore.Ocupado(this);
            InitializeComponent();
            VeiculosToolStrip.Renderer = new MySR();
            SimplesToolStrip.Renderer = new MySR();
            CodigoToolStrip.Renderer = new MySR();
            SilToolStrip.Renderer = new MySR();
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
            PhotoButton.Enabled = bStart;
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
            SimplesButton.Enabled = !bStart;
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
        }

        private void CarregaLista() {
            Empresa_bll empresa_Class = new Empresa_bll(_connection);
            HorarioList.DataSource = empresa_Class.Lista_Horario();
            HorarioList.DisplayMember = "deschorario";
            HorarioList.ValueMember = "codhorario";
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

        private void SairButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void CodigoButton_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String sCod = z.Show("", "Informação", "Digite ó código do imóvel.", 6, gtiCore.eTweakMode.IntegerPositive);
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


            DataAbertura.Text = Reg.Data_abertura.ToString("dd/MM/yyyy");
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



    }
}
