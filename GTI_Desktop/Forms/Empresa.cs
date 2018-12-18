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
        List<CnaeStruct> Lista_Cnae;
        List<CnaeStruct> Lista_Cnae_VS;

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
            SilAddButton.Enabled = !bStart;
            SilDelButton.Enabled = !bStart;
            SilEditButton.Enabled = !bStart;
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
            CnaeVSButton.Enabled = !bStart;
            CnaeVSDelButton.Enabled = !bStart;
            Atividade_Principal.ReadOnly = bStart;
            Atividade_Extenso.ReadOnly = bStart;
            QtdeProfissional.ReadOnly = bStart;
            Area.ReadOnly = bStart;
            AtividadePrincipalButton.Enabled = !bStart;
            CnaeButton.Enabled = !bStart;
            AtividadeISSButton.Enabled = !bStart;
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
            AtividadeISSListView.Items.Clear();
            AtividadeVSListView.Items.Clear();
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
            Cnae.Text = "";
            if(Lista_Cnae!=null) Lista_Cnae.Clear();
            if (Lista_Cnae_VS != null) Lista_Cnae_VS.Clear();
            Cnae.Text = "";
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
            if (Convert.ToInt32(Codigo.Text) == 0)
                MessageBox.Show("Selecione uma empresa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                bAddNew = false;
                ControlBehaviour(false);
            }
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
                    try {
                        Ttp.SetToolTip(SILList, ((sil)SILList.Items[hoveredIndex]).Sil);
                    } catch {
                    }
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

            List<string>_placas = empresa_Class.Lista_Placas(Codigo);
            foreach (string item in _placas) {
                PlacaLista.Items.Add(item);
            }

            List<sil>_lista_sil = empresa_Class.Lista_Sil(Codigo);
            foreach (sil _sil in _lista_sil) {
                SILList.Items.Add(_sil.Sil);
            }

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

            Area.Text = Convert.ToDecimal(Reg.Area).ToString("#0.00");
            QtdeProfissional.Text = Reg.Qtde_profissionais.ToString();
            Atividade_Principal.Text = Reg.Atividade_codigo + " - " + Reg.Atividade_nome;
            Atividade_Extenso.Text = Reg.Atividade_extenso;
            Nivel.Text = Reg.Codigo_aliquota.ToString();
            Aliquota.Text = empresa_Class.Aliquota_Taxa_Licenca(Codigo).ToString("#0.00");

            List<MobiliarioproprietarioStruct>Lista_Prop = empresa_Class.Lista_Empresa_Proprietario(Codigo);
            foreach (MobiliarioproprietarioStruct _prop in Lista_Prop) {
                CustomListBoxItem listBoxItem = new CustomListBoxItem(_prop.Nome, _prop.Codcidadao);
                ProprietarioList.Items.Add(listBoxItem);
            }

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

            //CNAE
            Lista_Cnae = empresa_Class.Lista_Cnae_Empresa(Codigo);
            Lista_Cnae_VS = empresa_Class.Lista_Cnae_Empresa_VS(Codigo);

            //Remove Cnae Duplicado
Inicio:;
            foreach (CnaeStruct itemCnaeVS in Lista_Cnae_VS) {
                foreach (CnaeStruct itemCnae in Lista_Cnae) {
                    if (itemCnaeVS.CNAE == itemCnae.CNAE) {
                        Lista_Cnae_VS.Remove(itemCnaeVS);
                        goto Inicio;
                    }
                }
            }

            //Preenche lista de Atividade ISS
            List<MobiliarioAtividadeISSStruct> Lista_ISS = empresa_Class.Lista_AtividadeISS_Empresa(Codigo);
            foreach (MobiliarioAtividadeISSStruct item in Lista_ISS) {
                ListViewItem lvItem = new ListViewItem(item.Codigo_tributo == 11 ? "F" : item.Codigo_tributo == 12 ? "E" : "V");
                lvItem.SubItems.Add(item.Codigo_atividade.ToString("000"));
                lvItem.SubItems.Add(item.Descricao);
                lvItem.SubItems.Add(item.Quantidade.ToString("00"));
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valor));
                AtividadeISSListView.Items.Add(lvItem);
            }


            //Preenche lista da Vigilânica Sanitária
            foreach (CnaeStruct item in Lista_Cnae_VS) {
                ListViewItem lvItem = new ListViewItem(item.CNAE);
                lvItem.SubItems.Add(item.Descricao);
                lvItem.SubItems.Add(item.Criterio.ToString("00"));
                lvItem.SubItems.Add(item.Qtde.ToString("00"));
                lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valor));
                AtividadeVSListView.Items.Add(lvItem);
            }

            //Exibe Cnae Principal
            foreach (CnaeStruct item in Lista_Cnae) {
                if (item.Principal) {
                    Cnae.Text = item.CNAE;
                    break;
                }
            }
            if (Cnae.Text == "") {
                foreach (CnaeStruct item in Lista_Cnae_VS) {
                    if (item.Principal) {
                        Cnae.Text = item.CNAE;
                        break;
                    }
                }
            }

        }

        private void EnderecoentregaButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
                Id_bairro = string.IsNullOrWhiteSpace(Bairro_EE.Text) ? 0 : Convert.ToInt32(Bairro_EE.Tag.ToString())
            };
            if (Logradouro_EE.Tag == null) Logradouro_EE.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro_EE.Tag.ToString()))
                Logradouro_EE.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro_EE.Text) ? 0 : Convert.ToInt32(Logradouro_EE.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? Logradouro.Text : "";
            reg.Numero_imovel = Numero_EE.Text == "" ? 0 : Convert.ToInt32(Numero_EE.Text);
            reg.Complemento = Complemento_EE.Text;
            reg.Email = "";

            Forms.Endereco f1 = new Forms.Endereco(reg, false, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                UF_EE.Text = f1.EndRetorno.Sigla_uf;
                Cidade_EE.Text = f1.EndRetorno.Nome_cidade;
                Cidade_EE.Tag = f1.EndRetorno.Id_cidade.ToString();
                Bairro_EE.Text = f1.EndRetorno.Nome_bairro;
                Bairro_EE.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro_EE.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro_EE.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero_EE.Text = f1.EndRetorno.Numero_imovel.ToString();
                Complemento_EE.Text = f1.EndRetorno.Complemento;
                Cep_EE.Text = f1.EndRetorno.Cep.ToString("00000-000");
            }
        }

        private void EnderecoButton_Click(object sender, EventArgs e) {
            GTI_Models.Models.Endereco reg = new GTI_Models.Models.Endereco {
                Id_pais = 1,
                Sigla_uf = "SP",
                Id_cidade = 413,
                Id_bairro = string.IsNullOrWhiteSpace(Bairro.Text) ? 0 : Convert.ToInt32(Bairro.Tag.ToString())
            };
            if (Logradouro.Tag == null) Logradouro.Tag = "0";
            if (string.IsNullOrWhiteSpace(Logradouro.Tag.ToString()))
                Logradouro.Tag = "0";
            reg.Id_logradouro = string.IsNullOrWhiteSpace(Logradouro.Text) ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            reg.Nome_logradouro = reg.Id_cidade != 413 ? Logradouro.Text : "";
            reg.Numero_imovel = Numero.Text == "" ? 0 : Convert.ToInt32(Numero.Text);
            reg.Complemento = Complemento.Text;
            reg.Email = "";

            Forms.Endereco f1 = new Forms.Endereco(reg, false, true);
            f1.ShowDialog();
            if (!f1.EndRetorno.Cancelar) {
                UF.Text = f1.EndRetorno.Sigla_uf;
                Cidade.Text = f1.EndRetorno.Nome_cidade;
                Cidade.Tag = f1.EndRetorno.Id_cidade.ToString();
                Bairro.Text = f1.EndRetorno.Nome_bairro;
                Bairro.Tag = f1.EndRetorno.Id_bairro.ToString();
                Logradouro.Text = f1.EndRetorno.Nome_logradouro;
                Logradouro.Tag = f1.EndRetorno.Id_logradouro.ToString();
                Numero.Text = f1.EndRetorno.Numero_imovel.ToString();
                Complemento.Text = f1.EndRetorno.Complemento;
                Cep.Text = f1.EndRetorno.Cep.ToString("00000-000");
                if (MesmoEndereco.Checked) {
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
            Carrega_Inscricao_Cadastral();
        }

        private void Carrega_Inscricao_Cadastral() {
            int _logradouro = Logradouro.Tag == null ? 0 : Convert.ToInt32(Logradouro.Tag.ToString());
            short _numero = string.IsNullOrWhiteSpace(Numero.Text) ? (short)0 : Convert.ToInt16(Numero.Text);
            if (_logradouro == 0) return;

            Imovel_bll imovel_Class = new Imovel_bll(_connection);
            ImovelStruct _reg = new ImovelStruct {
                CodigoLogradouro = _logradouro,
                Numero = _numero
            };

            List<ImovelStruct> Lista = imovel_Class.Lista_Imovel(_reg);
            if (Lista.Count > 0) {
                Distrito.Text = Lista[0].Distrito.ToString();
                Setor.Text = Lista[0].Setor.ToString("00");
                Quadra.Text = Lista[0].Quadra.ToString("0000");
                Lote.Text = Lista[0].Lote.ToString("00000");
                Face.Text = Lista[0].Seq.ToString("00");
                Unidade.Text = Lista[0].Unidade.ToString("00");
                Subunidade.Text = Lista[0].SubUnidade.ToString("000");
            }
        }

        private void PlacaOKButton_Click(object sender, EventArgs e) {
            if (Placa.MaskFull) {
                bool _find = false;
                for (int i = 0; i < PlacaLista.Items.Count; i++) {
                    if ((string)PlacaLista.Items[i] == Placa.Text)
                        _find = true;
                }
                if (!_find) {
                    PlacaLista.Items.Add(Placa.Text);
                    Placa.Text = "";
                }else
                    MessageBox.Show("Placa já cadastrada!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
                MessageBox.Show("Placa incompleta!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PlacaCancelButton_Click(object sender, EventArgs e) {
            if(PlacaLista.SelectedItems.Count==0)
                MessageBox.Show("Selecione a placa a ser removida.","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else {
                PlacaLista.Items.Remove(PlacaLista.SelectedItem);
            }
        }

        private void SilAddButton_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            String _protocolo = z.Show("", "Protocolo VRE", "Digite o número SIL.", 100, gtiCore.eTweakMode.AlphaNumeric);
            if (!string.IsNullOrWhiteSpace(_protocolo)) {
                bool _find = false;
                for (int i = 0; i < SILList.Items.Count; i++) {
                    if (SILList.Items[i].ToString() == _protocolo)
                        _find = true;
                }
                if (!_find)
                    SILList.Items.Add(_protocolo);
                else
                    MessageBox.Show("Protocolo já cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilEditButton_Click(object sender, EventArgs e) {
            if (SILList.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o protocolo a ser alterado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                inputBox z = new inputBox();
                String _protocolo = z.Show(SILList.SelectedItem.ToString(), "Protocolo VRE", "Digite o número SIL.", 100, gtiCore.eTweakMode.AlphaNumericAllCaps);
                if (!string.IsNullOrEmpty(_protocolo)) {
                    bool _find = false;
                    for (int i = 0; i < SILList.Items.Count; i++) {
                        if (SILList.SelectedIndex != i && SILList.Items[i].ToString() == _protocolo)
                            _find = true;
                    }
                    if (!_find)
                        SILList.Items[SILList.SelectedIndex] = _protocolo;
                    else
                        MessageBox.Show("Protocolo já cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SilDelButton_Click(object sender, EventArgs e) {
            if (SILList.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o protocolo a ser alterado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                SILList.Items.Remove(SILList.SelectedItem);
        }

        private void ProprietarioAddButton_Click(object sender, EventArgs e) {
            inputBox z = new inputBox();
            Cidadao_bll cidadao_Class = new Cidadao_bll(_connection);
            String _prop = z.Show("", "Propritários", "Digite o código do proprietário.", 6, gtiCore.eTweakMode.IntegerPositive);
            if (!string.IsNullOrWhiteSpace(_prop)) {
                int _codigo = Convert.ToInt32(_prop);
                bool _find = false;

                for (int i = 0; i < ProprietarioList.Items.Count; i++) {
                    CustomListBoxItem _selectedItem = (CustomListBoxItem)ProprietarioList.Items[i];
                    if (_selectedItem._value == _codigo)
                        _find = true;
                }

                if (!_find) {
                    string _nome = cidadao_Class.Retorna_Nome_Cidadao(_codigo);
                    if (_nome != null) {
                        CustomListBoxItem listBoxItem = new CustomListBoxItem(_nome, _codigo);
                        ProprietarioList.Items.Add(listBoxItem);
                    }else
                        MessageBox.Show("Proprietário não cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                    MessageBox.Show("Proprietário já cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProprietarioDelButton_Click(object sender, EventArgs e) {
            if (ProprietarioList.SelectedItems.Count == 0)
                MessageBox.Show("Selecione o proprietário a ser alterado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ProprietarioList.Items.Remove(ProprietarioList.SelectedItem);
        }

        private void AtividadePrincipalButton_Click(object sender, EventArgs e) {
            if (Convert.ToInt32(Codigo.Text) == 0 && !bAddNew)
                MessageBox.Show("Selecione uma empresa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (Atividade_Principal.Tag == null || Atividade_Principal.Tag.ToString() == "")
                    Atividade_Principal.Tag = "0";
                Empresa_Atividade f1 = new Empresa_Atividade(Convert.ToInt32(Atividade_Principal.Tag.ToString()));
                f1.Tag = Name;
                var result = f1.ShowDialog(this);
                if (result == DialogResult.OK) {
                    int _id_atividade = f1.ReturnValue;
                    Empresa_bll empresa_Class = new Empresa_bll(_connection);
                    string _nome_atividade = empresa_Class.Retorna_Nome_Atividade(_id_atividade);
                    Atividade_Principal.Text = _id_atividade.ToString() + " - " + _nome_atividade;
                    Atividade_Principal.Tag = _id_atividade.ToString();
                    Aliquota.Text = f1.ReturnAliquota;
                }
            }
        }

        private void CnaeButton_Click(object sender, EventArgs e) {
            if (Convert.ToInt32(Codigo.Text) == 0 && !bAddNew)
                MessageBox.Show("Selecione uma empresa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (Lista_Cnae == null) Lista_Cnae = new List<CnaeStruct>();
                if (Lista_Cnae_VS == null) Lista_Cnae_VS = new List<CnaeStruct>();
                Empresa_Cnae frm = new Empresa_Cnae(Lista_Cnae,Lista_Cnae_VS,AddButton.Enabled);
                frm.ShowDialog(this);
                Lista_Cnae = frm.Lista_Cnae;
                Cnae.Text = "";
                foreach (CnaeStruct item in Lista_Cnae) {
                    if (item.Principal == true) {
                        Cnae.Text = item.CNAE;
                        break;
                    }
                }
            }
        }

        private void CnaeVSButton_Click(object sender, EventArgs e) {

            if (Convert.ToInt32(Codigo.Text) == 0 && !bAddNew)
                MessageBox.Show("Selecione uma empresa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                if (Lista_Cnae_VS == null) Lista_Cnae_VS = new List<CnaeStruct>();
                Empresa_VS frm = new Empresa_VS(Lista_Cnae, Lista_Cnae_VS,AddButton.Enabled); 
                frm.ShowDialog(this);
                CnaeStruct itemVS = frm.Item_VS;
                if (itemVS != null) {
                    foreach (CnaeStruct item in Lista_Cnae_VS) {
                        if (itemVS.CNAE == item.CNAE) {
                            MessageBox.Show("CNAE já inserido na lista de atividades.","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
                            return;
                        }
                    }
                    Lista_Cnae_VS.Add(itemVS);
                }

                AtividadeVSListView.Items.Clear();
                foreach (CnaeStruct item in Lista_Cnae_VS) {
                    ListViewItem lvItem = new ListViewItem(item.CNAE);
                    lvItem.SubItems.Add(item.Descricao);
                    lvItem.SubItems.Add(item.Criterio.ToString("00"));
                    lvItem.SubItems.Add(item.Qtde.ToString("00"));
                    lvItem.SubItems.Add(string.Format("{0:0.00}", item.Valor));
                    AtividadeVSListView.Items.Add(lvItem);
                }
            }
        }

        private void CnaeVSDelButton_Click(object sender, EventArgs e) {
            if (AtividadeVSListView.SelectedItems.Count > 0) {
                string _cnae = AtividadeVSListView.SelectedItems[0].Text;
                foreach (CnaeStruct item in Lista_Cnae_VS) {
                    if (item.CNAE == _cnae) {
                        Lista_Cnae_VS.Remove(item);
                        break;
                    }
                }
                AtividadeVSListView.SelectedItems[0].Remove();
            }
        }


                
       
    }
}
