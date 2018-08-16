using GTI_Bll.Classes;
using GTI_Desktop.Classes;
using GTI_Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace GTI_Desktop.Forms {
    public partial class Main : Form {
        string _connection = gtiCore.Connection_Name();
        private const int CP_NOCLOSE_BUTTON = 0x200;

        protected override CreateParams CreateParams {
            get {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                myCp.ExStyle=myCp.ExStyle | 0x2000000;
                return myCp;
            }
        }

        public Main() {
            InitializeComponent();
            this.DoubleBuffered = true;
            DateTimePicker t = new DateTimePicker {
                AutoSize = false,
                Width = 100,
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Name = "sbDataBase"
            };
            topBar.Renderer = new MySR();
            t.CloseUp += new System.EventHandler(SbDataBase_CloseUp);
            sBar.Items.Insert(17, new ToolStripControlHost(t));
            sbMaquina.Text = Environment.MachineName;
            sbDataBase.Text = Properties.Settings.Default.DataBaseReal;
        }

        private void Main_Load(object sender, EventArgs e) {
            this.IsMdiContainer = true;
            this.Refresh();
            CorFundo();
            sbServidor.Text = Properties.Settings.Default.ServerName;
            sbVersao.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            LockForm(true);
            Forms.Login login = new Forms.Login();
            login.ShowDialog();
        }

        private void CorFundo() {
            MdiClient ctlMDI;

            foreach (Control ctl in this.Controls) {
                try {
                    ctlMDI = (MdiClient)ctl;
                    ctlMDI.BackColor = this.BackColor;
                } catch  {
                }
            }
        }

        private void SbDataBase_CloseUp(object sender, EventArgs e) {
            MessageBox.Show(ReturnDataBaseValue().ToString());
        }

        public DateTime ReturnDataBaseValue() {
            DateTime dValue = DateTime.Today;

            DateTimePicker dbox;
            foreach (Control c in sBar.Controls) {
                if (c is DateTimePicker) {
                    dbox = c as DateTimePicker;
                    dValue = dbox.Value.Date;
                }
            }
            return dValue;
        }

        public void LockForm(bool bLocked) {
            foreach (ToolStripItem ts in topBar.Items) {
                ts.Enabled = !bLocked;
            }

            List<ToolStripMenuItem> mItems = gtiCore.GetItems(this.menuStrip1);
            foreach (var item in mItems) {
                item.Enabled = !bLocked;
            }
            optDv1.Enabled = !bLocked;
            optDv2.Enabled = !bLocked;
            txtDV.ReadOnly = bLocked;
            lblDV.Enabled = !bLocked;
            lblDV2.Enabled = !bLocked;
            lblDV3.Enabled = !bLocked;
        }

        public void Main_FormClosing(object sender, FormClosingEventArgs e) {
             Application.Exit();
        }

        private void BtSair_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deseja fechar todas as janelas e retornar a tela de login?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                Form[] charr = this.MdiChildren;
                foreach (Form chform in charr) {
                    chform.Close();
                }

                LockForm(true);
                Forms.Login login = new Forms.Login();
                login.ShowDialog();
            }
        }
        
        

        private void MnuConfig_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Config);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Forms.Config f1 = new Forms.Config {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void BtConfig_Click(object sender, EventArgs e) {
            MnuConfig_Click(sender, e);
        }

        private void BaseRealToolStripMenuItem_Click(object sender, EventArgs e) {
            sbDataBase.Text = Properties.Settings.Default.DataBaseReal;
            this.Refresh();
        }

        private void BaseDeTestesToolStripMenuItem_Click(object sender, EventArgs e) {
            sbDataBase.Text = Properties.Settings.Default.DataBaseTeste;
            this.Refresh();
        }

        private void BtCidadao_Click(object sender, EventArgs e) {
            MnuCidadao_Click(sender, e);
        }

        private void MnuCidadao_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCidadao);
            if (bAllow) {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Cidadao);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Cidadao f1 = new Cidadao {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

      

        private void DocumentaçãoParaProcessosToolStripMenuItem_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Documento);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Processo_Documento f1 = new Processo_Documento {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void DespachosDosTrâmitesToolStripMenuItem_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Despacho);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Processo_Despacho f1 = new Processo_Despacho {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void AssuntosDoProcessoToolStripMenuItem_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Assunto);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Processo_Assunto f1 = new Processo_Assunto {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void LocalDeTramitaçãoDeProcessosToolStripMenuItem_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo_Local);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Processo_Local f1 = new Processo_Local {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
        }

        private void MinimizarTodasToolStripMenuItem_Click(object sender, EventArgs e) {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }

        private void RestaurarTodasToolStripMenuItem_Click(object sender, EventArgs e) {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Normal;
        }

        private void FecharTodasToolStripMenuItem_Click(object sender, EventArgs e) {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.Close();
        }

        private void EmCascataToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void LadoALadoToolStripMenuItem_Click(object sender, EventArgs e) {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void ControleDeProcessosToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void BtProtocolo_Click(object sender, EventArgs e) {
            MnuControleProcesso_Click(sender, e);
        }

        private void MnuControleProcesso_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProcesso);
            if (bAllow) {

                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Processo);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Processo f1 = new Processo {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            }else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MnuCadImob_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroImovel);
            if (bAllow) {
                gtiCore.Ocupado(this);
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Imovel);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Imovel f1 = new Imovel {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
                gtiCore.Liberado(this);
            }else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtImobiliario_Click(object sender, EventArgs e) {
            MnuCadImob_Click(null, null);
        }

        private void TxtDV_TextChanged(object sender, EventArgs e) {
            if (txtDV.Text == "")
                lblDV.Text = "X";
            else
                lblDV.Text = RetornaDV().ToString();
        }

        private void TxtDV_KeyPress(object sender, KeyPressEventArgs e) {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        private short RetornaDV() {
            short ret = 0;
            if (txtDV.Text == "") txtDV.Text = "0";
            int Numero = Convert.ToInt32(txtDV.Text);
            if (optDv1.Checked) {
                Processo_bll clsProcesso = new Processo_bll(_connection);
                ret = Convert.ToInt16(clsProcesso.DvProcesso(Numero));
            } else {
                Tributario_bll clsTributario = new Tributario_bll(_connection);
                ret = Convert.ToInt16(clsTributario.DvDocumento(Numero));
            }

            return ret;
        }

        private void OptDv1_CheckedChanged(object sender, EventArgs e) {
            lblDV.Text= RetornaDV().ToString();
            txtDV.Focus();
        }

        private void OptDv2_CheckedChanged(object sender, EventArgs e) {
            lblDV.Text = RetornaDV().ToString();
            txtDV.Focus();
        }

        private void TxtDV_Enter(object sender, EventArgs e) {
            txtDV.SelectionStart = 0;
            txtDV.SelectionLength = txtDV.Text.Length;
        }

        private void MnuCadastroLancamento_Click(object sender, EventArgs e) {
            gtiCore.Ocupado(this);
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Lancamento);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Lancamento f1 = new Lancamento {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
            gtiCore.Liberado(this);
        }

        private void MnuTributos_Click(object sender, EventArgs e) {
            gtiCore.Ocupado(this);
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Tributo);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Tributo f1 = new Tributo {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
            gtiCore.Liberado(this);
        }

        private void MnuExtrato_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.ExtratoContribuinte);
            if (bAllow) {
                gtiCore.Ocupado(this);
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Extrato);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Extrato f1 = new Extrato {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
                gtiCore.Liberado(this);
            }else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtExtrato_Click(object sender, EventArgs e) {
            MnuExtrato_Click(null,null);
        }

        private void MnuEmpresa_Click(object sender, EventArgs e) {
            gtiCore.Ocupado(this);
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Empresa);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Empresa f1 = new Empresa {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
            }
            gtiCore.Liberado(this);
        }

        private void BtMobiliario_Click(object sender, EventArgs e) {
            MnuEmpresa_Click(null, null);
        }

        private void mnuCadastroEvento_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.SecurityEventForm);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Forms.SecurityEventForm f1 = new Forms.SecurityEventForm {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void mnuAtribuicaoAcesso_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.SecurityUserForm);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Forms.SecurityUserForm f1 = new Forms.SecurityUserForm {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void mnuCadastroUsuario_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Usuario);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Forms.Usuario f1 = new Forms.Usuario {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void CadastroUsuarioMenu_Click(object sender, EventArgs e) {
            mnuCadastroUsuario_Click(null, null);
        }

        private void EventosDoSistemaMenu_Click(object sender, EventArgs e) {
            mnuCadastroEvento_Click(null, null);
        }

        private void AtribuicaoDeAcessoMenu_Click(object sender, EventArgs e) {
            mnuAtribuicaoAcesso_Click(null, null);
        }

       
        private void mnuEscritorioContabil_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Escritorio_Contabil);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Forms.Escritorio_Contabil f1 = new Forms.Escritorio_Contabil {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void mnuCadastroCondominio_Click(object sender, EventArgs e) {

            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroCondominio);
            if (bAllow) {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Condominio);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Forms.Condominio f1 = new Forms.Condominio {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                    f1.BringToFront();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CertidaoButton_Click(object sender, EventArgs e) {
            var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Certidao);
            if (formToShow != null) {
                formToShow.Show();
            } else {
                Certidao f1 = new Certidao {
                    Tag = "Menu",
                    MdiParent = this
                };
                f1.Show();
                f1.BringToFront();
            }
        }

        private void mnuCadastroBairro_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroBairro);
            if (bAllow) {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Bairro);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Forms.Bairro f1 = new Forms.Bairro {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCadastroPais_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroPais);
            if (bAllow) {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Pais);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Pais f1 = new Pais {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuCadastroProfissao_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.CadastroProfissao);
            if (bAllow) {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Forms.Profissao);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Profissao f1 = new Profissao {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CartaCobrancaMenu_Click(object sender, EventArgs e) {
            bool bAllow = gtiCore.GetBinaryAccess((int)TAcesso.Carta_Cobranca);
            if (bAllow) {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Carta_Cobranca);
                if (formToShow != null) {
                    formToShow.Show();
                } else {
                    Carta_Cobranca f1 = new Carta_Cobranca {
                        Tag = "Menu",
                        MdiParent = this
                    };
                    f1.Show();
                }
            } else
                MessageBox.Show("Acesso não permitido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }//end class
}
