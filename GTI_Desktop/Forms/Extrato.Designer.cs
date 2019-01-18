namespace GTI_Desktop.Forms {
    partial class Extrato {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalNPago = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalVenc = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalSel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BtSelectLancamento = new System.Windows.Forms.Button();
            this.BtSelectStatus = new System.Windows.Forms.Button();
            this.ConsultarCodigoButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.mnuMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditaParcela = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtratoDataGrid = new System.Windows.Forms.DataGridView();
            this.imgCol = new System.Windows.Forms.DataGridViewImageColumn();
            this.Ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lancamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sequencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parcela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.complemento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_vencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_lancado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor_atual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notificado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exec_fiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.certidao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_remessa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label1 = new System.Windows.Forms.Label();
            this.CodigoText = new System.Windows.Forms.TextBox();
            this.ChkAllExercicio = new System.Windows.Forms.CheckBox();
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.FiltroPanel = new Owf.Controls.A1Panel();
            this.OcultarButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbDivAtiva = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CmbAjuizado = new System.Windows.Forms.ComboBox();
            this.ChkParcelaOculta = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FiltroButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbAnoFinal = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbAnoInicial = new System.Windows.Forms.ComboBox();
            this.GridPanel = new Owf.Controls.A1Panel();
            this.DocumentoPanel = new Owf.Controls.A1Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PesquisarDocumentoButton = new System.Windows.Forms.ToolStripButton();
            this.SairDocumentoButton = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.DocumentoListView = new System.Windows.Forms.ListView();
            this.Doc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DataDoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValorGuia = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ObservacaoPanel = new Owf.Controls.A1Panel();
            this.TituloObsLabel = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.NovaObsButton = new System.Windows.Forms.ToolStripButton();
            this.AlterarObsButton = new System.Windows.Forms.ToolStripButton();
            this.ExcluirObsButton = new System.Windows.Forms.ToolStripButton();
            this.GravarObsButton = new System.Windows.Forms.ToolStripButton();
            this.CancelarObsButton = new System.Windows.Forms.ToolStripButton();
            this.SairObsButton = new System.Windows.Forms.ToolStripButton();
            this.ZoomButton = new System.Windows.Forms.ToolStripButton();
            this.ObservacaoText = new System.Windows.Forms.TextBox();
            this.ObservacaoListView = new System.Windows.Forms.ListView();
            this.Seq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Data = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Obs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FiltroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ObsGeralMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Detalhemenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExtratoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DocumentoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ParcelamentoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DamMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExecFiscalMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OutrosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuParametros = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroBairroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroPaisMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroProfissaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImobiliario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroImovelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroCondominioMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.FaceQuadraMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.relatórioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComunicadoIsencaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMobiliario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMobiliarioCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroEmpresaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EscritorioContabilMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AtividadeEmpresaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAtendimento = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroCidadaoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTributario = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTributarioTabelas = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroLancamentoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroTributosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dividaAtivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CartaCobrancaMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.bancosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistroBancarioMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProtocolo = new System.Windows.Forms.ToolStripMenuItem();
            this.tabelasBásicasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentaçãoParaProcessosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.despachosDosTrâmitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assuntosDoProcessoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDeTramitaçãoDeProcessosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuControleProcesso = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProcessoAtrasoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOutros = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSecurity = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroUsuariosMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CadastroEventoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AtribuicaoAcessoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CalculoImpostoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJanela = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizarTodasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarTodasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharTodasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.emCascataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladoALadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sBar.SuspendLayout();
            this.mnuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExtratoDataGrid)).BeginInit();
            this.a1Panel2.SuspendLayout();
            this.FiltroPanel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.GridPanel.SuspendLayout();
            this.DocumentoPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.ObservacaoPanel.SuspendLayout();
            this.tBar.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sBar
            // 
            this.sBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTotalNPago,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel3,
            this.lblTotalVenc,
            this.toolStripStatusLabel8,
            this.toolStripStatusLabel5,
            this.lblTotalSel});
            this.sBar.Location = new System.Drawing.Point(0, 571);
            this.sBar.Name = "sBar";
            this.sBar.Size = new System.Drawing.Size(964, 22);
            this.sBar.TabIndex = 118;
            this.sBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(105, 17);
            this.toolStripStatusLabel1.Text = "Não Pago (Total)..:";
            // 
            // lblTotalNPago
            // 
            this.lblTotalNPago.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalNPago.Name = "lblTotalNPago";
            this.lblTotalNPago.Size = new System.Drawing.Size(28, 17);
            this.lblTotalNPago.Text = "0,00";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel7.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(121, 17);
            this.toolStripStatusLabel3.Text = "Não Pago (Vencido)..:";
            // 
            // lblTotalVenc
            // 
            this.lblTotalVenc.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalVenc.Name = "lblTotalVenc";
            this.lblTotalVenc.Size = new System.Drawing.Size(28, 17);
            this.lblTotalVenc.Text = "0,00";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel8.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel5.Text = "Total Selecionado..:";
            // 
            // lblTotalSel
            // 
            this.lblTotalSel.ForeColor = System.Drawing.Color.Maroon;
            this.lblTotalSel.Name = "lblTotalSel";
            this.lblTotalSel.Size = new System.Drawing.Size(28, 17);
            this.lblTotalSel.Text = "0,00";
            // 
            // BtSelectLancamento
            // 
            this.BtSelectLancamento.Location = new System.Drawing.Point(8, 21);
            this.BtSelectLancamento.Name = "BtSelectLancamento";
            this.BtSelectLancamento.Size = new System.Drawing.Size(86, 22);
            this.BtSelectLancamento.TabIndex = 8;
            this.BtSelectLancamento.Text = "Selecionar";
            this.toolTip1.SetToolTip(this.BtSelectLancamento, "Escolher quais lançamentos serão exibidos");
            this.BtSelectLancamento.UseVisualStyleBackColor = true;
            this.BtSelectLancamento.Click += new System.EventHandler(this.BtSelectLancamento_Click);
            // 
            // BtSelectStatus
            // 
            this.BtSelectStatus.Location = new System.Drawing.Point(6, 21);
            this.BtSelectStatus.Name = "BtSelectStatus";
            this.BtSelectStatus.Size = new System.Drawing.Size(86, 22);
            this.BtSelectStatus.TabIndex = 9;
            this.BtSelectStatus.Text = "Selecionar";
            this.toolTip1.SetToolTip(this.BtSelectStatus, "Escolher quais situações de lançamento serão exibidas");
            this.BtSelectStatus.UseVisualStyleBackColor = true;
            this.BtSelectStatus.Click += new System.EventHandler(this.BtSelectStatus_Click);
            // 
            // ConsultarCodigoButton
            // 
            this.ConsultarCodigoButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.ConsultarCodigoButton.Location = new System.Drawing.Point(134, 7);
            this.ConsultarCodigoButton.Name = "ConsultarCodigoButton";
            this.ConsultarCodigoButton.Size = new System.Drawing.Size(22, 22);
            this.ConsultarCodigoButton.TabIndex = 1;
            this.toolTip1.SetToolTip(this.ConsultarCodigoButton, "Pesquisar código");
            this.ConsultarCodigoButton.UseVisualStyleBackColor = true;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = global::GTI_Desktop.Properties.Resources.refresh_16x16;
            this.RefreshButton.Location = new System.Drawing.Point(158, 7);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(22, 22);
            this.RefreshButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.RefreshButton, "Atualizar o extrato");
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.BtRefresh_Click);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditaParcela});
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(167, 26);
            this.mnuMain.Text = "Principal";
            // 
            // mnuEditaParcela
            // 
            this.mnuEditaParcela.Name = "mnuEditaParcela";
            this.mnuEditaParcela.Size = new System.Drawing.Size(166, 22);
            this.mnuEditaParcela.Text = "Edição da parcela";
            this.mnuEditaParcela.Click += new System.EventHandler(this.MnuEditaDebito_Click);
            // 
            // ExtratoDataGrid
            // 
            this.ExtratoDataGrid.AllowUserToAddRows = false;
            this.ExtratoDataGrid.AllowUserToDeleteRows = false;
            this.ExtratoDataGrid.AllowUserToResizeRows = false;
            this.ExtratoDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtratoDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.ExtratoDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtratoDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.ExtratoDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtratoDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.imgCol,
            this.Ano,
            this.lancamento,
            this.sequencia,
            this.parcela,
            this.complemento,
            this.status,
            this.data_vencimento,
            this.DA,
            this.AJ,
            this.valor_lancado,
            this.valor_atual,
            this.notificado,
            this.exec_fiscal,
            this.certidao,
            this.data_remessa});
            this.ExtratoDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ExtratoDataGrid.EnableHeadersVisualStyles = false;
            this.ExtratoDataGrid.GridColor = System.Drawing.Color.Gainsboro;
            this.ExtratoDataGrid.Location = new System.Drawing.Point(3, 54);
            this.ExtratoDataGrid.MultiSelect = false;
            this.ExtratoDataGrid.Name = "ExtratoDataGrid";
            this.ExtratoDataGrid.ReadOnly = true;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtratoDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.ExtratoDataGrid.RowHeadersVisible = false;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.White;
            this.ExtratoDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.ExtratoDataGrid.RowTemplate.DefaultCellStyle.NullValue = "N/D";
            this.ExtratoDataGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.DarkRed;
            this.ExtratoDataGrid.RowTemplate.Height = 17;
            this.ExtratoDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExtratoDataGrid.ShowCellErrors = false;
            this.ExtratoDataGrid.ShowCellToolTips = false;
            this.ExtratoDataGrid.ShowEditingIcon = false;
            this.ExtratoDataGrid.ShowRowErrors = false;
            this.ExtratoDataGrid.Size = new System.Drawing.Size(948, 396);
            this.ExtratoDataGrid.StandardTab = true;
            this.ExtratoDataGrid.TabIndex = 3;
            this.ExtratoDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtratoDataGrid_CellClick);
            this.ExtratoDataGrid.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExtratoDataGrid_CellMouseEnter);
            this.ExtratoDataGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ExtratoDataGrid_MouseClick);
            // 
            // imgCol
            // 
            this.imgCol.HeaderText = "Obs";
            this.imgCol.Name = "imgCol";
            this.imgCol.ReadOnly = true;
            this.imgCol.Width = 30;
            // 
            // Ano
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Ano.DefaultCellStyle = dataGridViewCellStyle16;
            this.Ano.HeaderText = "Ano";
            this.Ano.Name = "Ano";
            this.Ano.ReadOnly = true;
            this.Ano.Width = 42;
            // 
            // lancamento
            // 
            this.lancamento.HeaderText = "Lançamento";
            this.lancamento.Name = "lancamento";
            this.lancamento.ReadOnly = true;
            this.lancamento.Width = 175;
            // 
            // sequencia
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sequencia.DefaultCellStyle = dataGridViewCellStyle17;
            this.sequencia.HeaderText = "Sq";
            this.sequencia.Name = "sequencia";
            this.sequencia.ReadOnly = true;
            this.sequencia.Width = 28;
            // 
            // parcela
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.parcela.DefaultCellStyle = dataGridViewCellStyle18;
            this.parcela.HeaderText = "Pc";
            this.parcela.Name = "parcela";
            this.parcela.ReadOnly = true;
            this.parcela.Width = 28;
            // 
            // complemento
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.complemento.DefaultCellStyle = dataGridViewCellStyle19;
            this.complemento.HeaderText = "Cp";
            this.complemento.Name = "complemento";
            this.complemento.ReadOnly = true;
            this.complemento.Width = 28;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 110;
            // 
            // data_vencimento
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_vencimento.DefaultCellStyle = dataGridViewCellStyle20;
            this.data_vencimento.HeaderText = "Dt.Vencto";
            this.data_vencimento.Name = "data_vencimento";
            this.data_vencimento.ReadOnly = true;
            this.data_vencimento.Width = 70;
            // 
            // DA
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DA.DefaultCellStyle = dataGridViewCellStyle21;
            this.DA.HeaderText = "D";
            this.DA.Name = "DA";
            this.DA.ReadOnly = true;
            this.DA.Width = 20;
            // 
            // AJ
            // 
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AJ.DefaultCellStyle = dataGridViewCellStyle22;
            this.AJ.HeaderText = "A";
            this.AJ.Name = "AJ";
            this.AJ.ReadOnly = true;
            this.AJ.Width = 20;
            // 
            // valor_lancado
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.valor_lancado.DefaultCellStyle = dataGridViewCellStyle23;
            this.valor_lancado.HeaderText = "Vl.Lanc";
            this.valor_lancado.Name = "valor_lancado";
            this.valor_lancado.ReadOnly = true;
            this.valor_lancado.Width = 75;
            // 
            // valor_atual
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.valor_atual.DefaultCellStyle = dataGridViewCellStyle24;
            this.valor_atual.HeaderText = "Vl.Atual";
            this.valor_atual.Name = "valor_atual";
            this.valor_atual.ReadOnly = true;
            this.valor_atual.Width = 75;
            // 
            // notificado
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.notificado.DefaultCellStyle = dataGridViewCellStyle25;
            this.notificado.HeaderText = "N";
            this.notificado.Name = "notificado";
            this.notificado.ReadOnly = true;
            this.notificado.Width = 35;
            // 
            // exec_fiscal
            // 
            this.exec_fiscal.HeaderText = "Exec.Fiscal";
            this.exec_fiscal.Name = "exec_fiscal";
            this.exec_fiscal.ReadOnly = true;
            // 
            // certidao
            // 
            this.certidao.HeaderText = "Certidão";
            this.certidao.Name = "certidao";
            this.certidao.ReadOnly = true;
            this.certidao.Width = 70;
            // 
            // data_remessa
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.data_remessa.DefaultCellStyle = dataGridViewCellStyle26;
            this.data_remessa.HeaderText = "Dt.Remessa";
            this.data_remessa.Name = "data_remessa";
            this.data_remessa.ReadOnly = true;
            this.data_remessa.Width = 70;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 35;
            this.Label1.Text = "Código....:";
            // 
            // CodigoText
            // 
            this.CodigoText.Location = new System.Drawing.Point(69, 7);
            this.CodigoText.MaxLength = 6;
            this.CodigoText.Name = "CodigoText";
            this.CodigoText.Size = new System.Drawing.Size(63, 20);
            this.CodigoText.TabIndex = 0;
            this.CodigoText.TextChanged += new System.EventHandler(this.TxtCodigo_TextChanged);
            this.CodigoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCodigo_KeyDown);
            this.CodigoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCodigo_KeyPress);
            // 
            // ChkAllExercicio
            // 
            this.ChkAllExercicio.AutoSize = true;
            this.ChkAllExercicio.Location = new System.Drawing.Point(8, 0);
            this.ChkAllExercicio.Name = "ChkAllExercicio";
            this.ChkAllExercicio.Size = new System.Drawing.Size(15, 14);
            this.ChkAllExercicio.TabIndex = 3;
            this.ChkAllExercicio.UseVisualStyleBackColor = true;
            this.ChkAllExercicio.CheckedChanged += new System.EventHandler(this.ChkAllExercicio_CheckedChanged);
            // 
            // a1Panel2
            // 
            this.a1Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.a1Panel2.BackColor = System.Drawing.Color.White;
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.menuStrip1);
            this.a1Panel2.Controls.Add(this.txtNome);
            this.a1Panel2.Controls.Add(this.ConsultarCodigoButton);
            this.a1Panel2.Controls.Add(this.RefreshButton);
            this.a1Panel2.Controls.Add(this.CodigoText);
            this.a1Panel2.Controls.Add(this.Label1);
            this.a1Panel2.Controls.Add(this.MainMenu);
            this.a1Panel2.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel2.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(9, 5);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.ShadowOffSet = 3;
            this.a1Panel2.Size = new System.Drawing.Size(952, 88);
            this.a1Panel2.TabIndex = 0;
            // 
            // txtNome
            // 
            this.txtNome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNome.Location = new System.Drawing.Point(186, 8);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(755, 20);
            this.txtNome.TabIndex = 36;
            // 
            // FiltroPanel
            // 
            this.FiltroPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FiltroPanel.BackColor = System.Drawing.Color.Linen;
            this.FiltroPanel.BorderColor = System.Drawing.Color.Gray;
            this.FiltroPanel.Controls.Add(this.OcultarButton);
            this.FiltroPanel.Controls.Add(this.label5);
            this.FiltroPanel.Controls.Add(this.CmbDivAtiva);
            this.FiltroPanel.Controls.Add(this.label4);
            this.FiltroPanel.Controls.Add(this.CmbAjuizado);
            this.FiltroPanel.Controls.Add(this.ChkParcelaOculta);
            this.FiltroPanel.Controls.Add(this.groupBox3);
            this.FiltroPanel.Controls.Add(this.groupBox2);
            this.FiltroPanel.Controls.Add(this.FiltroButton);
            this.FiltroPanel.Controls.Add(this.groupBox1);
            this.FiltroPanel.GradientEndColor = System.Drawing.Color.Linen;
            this.FiltroPanel.GradientStartColor = System.Drawing.Color.Linen;
            this.FiltroPanel.Image = null;
            this.FiltroPanel.ImageLocation = new System.Drawing.Point(4, 4);
            this.FiltroPanel.Location = new System.Drawing.Point(6, 498);
            this.FiltroPanel.Name = "FiltroPanel";
            this.FiltroPanel.Size = new System.Drawing.Size(956, 74);
            this.FiltroPanel.TabIndex = 4;
            // 
            // OcultarButton
            // 
            this.OcultarButton.ForeColor = System.Drawing.Color.Navy;
            this.OcultarButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.OcultarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OcultarButton.Location = new System.Drawing.Point(852, 36);
            this.OcultarButton.Name = "OcultarButton";
            this.OcultarButton.Size = new System.Drawing.Size(92, 24);
            this.OcultarButton.TabIndex = 14;
            this.OcultarButton.Text = "Ocultar Filtro";
            this.OcultarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OcultarButton.UseVisualStyleBackColor = true;
            this.OcultarButton.Click += new System.EventHandler(this.BTOcultar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(458, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Div.Ativa.:";
            // 
            // CmbDivAtiva
            // 
            this.CmbDivAtiva.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDivAtiva.FormattingEnabled = true;
            this.CmbDivAtiva.Items.AddRange(new object[] {
            "(Todos)",
            "Sim",
            "Não"});
            this.CmbDivAtiva.Location = new System.Drawing.Point(520, 11);
            this.CmbDivAtiva.Name = "CmbDivAtiva";
            this.CmbDivAtiva.Size = new System.Drawing.Size(57, 21);
            this.CmbDivAtiva.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(458, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ajuizado..:";
            // 
            // CmbAjuizado
            // 
            this.CmbAjuizado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAjuizado.FormattingEnabled = true;
            this.CmbAjuizado.Items.AddRange(new object[] {
            "(Todos)",
            "Sim",
            "Não"});
            this.CmbAjuizado.Location = new System.Drawing.Point(520, 38);
            this.CmbAjuizado.Name = "CmbAjuizado";
            this.CmbAjuizado.Size = new System.Drawing.Size(57, 21);
            this.CmbAjuizado.TabIndex = 11;
            // 
            // ChkParcelaOculta
            // 
            this.ChkParcelaOculta.AutoSize = true;
            this.ChkParcelaOculta.Location = new System.Drawing.Point(598, 13);
            this.ChkParcelaOculta.Name = "ChkParcelaOculta";
            this.ChkParcelaOculta.Size = new System.Drawing.Size(131, 17);
            this.ChkParcelaOculta.TabIndex = 12;
            this.ChkParcelaOculta.Text = "Exibir parcelas ocultas";
            this.ChkParcelaOculta.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Linen;
            this.groupBox3.Controls.Add(this.BtSelectStatus);
            this.groupBox3.Location = new System.Drawing.Point(341, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(105, 54);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Status da Parcela";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Linen;
            this.groupBox2.Controls.Add(this.BtSelectLancamento);
            this.groupBox2.Location = new System.Drawing.Point(232, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(103, 54);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lançamentos";
            // 
            // FiltroButton
            // 
            this.FiltroButton.ForeColor = System.Drawing.Color.Navy;
            this.FiltroButton.Image = global::GTI_Desktop.Properties.Resources.funnel;
            this.FiltroButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FiltroButton.Location = new System.Drawing.Point(852, 9);
            this.FiltroButton.Name = "FiltroButton";
            this.FiltroButton.Size = new System.Drawing.Size(92, 24);
            this.FiltroButton.TabIndex = 13;
            this.FiltroButton.Text = "Aplicar Filtro";
            this.FiltroButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FiltroButton.UseVisualStyleBackColor = true;
            this.FiltroButton.Click += new System.EventHandler(this.BtFiltro_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Linen;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.CmbAnoFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbAnoInicial);
            this.groupBox1.Controls.Add(this.ChkAllExercicio);
            this.groupBox1.Location = new System.Drawing.Point(11, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "      Todos os exercícios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Até.:";
            // 
            // CmbAnoFinal
            // 
            this.CmbAnoFinal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAnoFinal.FormattingEnabled = true;
            this.CmbAnoFinal.Location = new System.Drawing.Point(147, 22);
            this.CmbAnoFinal.Name = "CmbAnoFinal";
            this.CmbAnoFinal.Size = new System.Drawing.Size(57, 21);
            this.CmbAnoFinal.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "De..:";
            // 
            // CmbAnoInicial
            // 
            this.CmbAnoInicial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbAnoInicial.FormattingEnabled = true;
            this.CmbAnoInicial.Location = new System.Drawing.Point(45, 22);
            this.CmbAnoInicial.Name = "CmbAnoInicial";
            this.CmbAnoInicial.Size = new System.Drawing.Size(57, 21);
            this.CmbAnoInicial.TabIndex = 6;
            // 
            // GridPanel
            // 
            this.GridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPanel.BackColor = System.Drawing.SystemColors.Control;
            this.GridPanel.BorderColor = System.Drawing.Color.Gray;
            this.GridPanel.Controls.Add(this.ObservacaoPanel);
            this.GridPanel.Controls.Add(this.DocumentoPanel);
            this.GridPanel.Controls.Add(this.ExtratoDataGrid);
            this.GridPanel.GradientEndColor = System.Drawing.SystemColors.Control;
            this.GridPanel.GradientStartColor = System.Drawing.Color.White;
            this.GridPanel.Image = null;
            this.GridPanel.ImageLocation = new System.Drawing.Point(4, 4);
            this.GridPanel.Location = new System.Drawing.Point(6, 113);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.ShadowOffSet = 3;
            this.GridPanel.Size = new System.Drawing.Size(955, 454);
            this.GridPanel.TabIndex = 120;
            // 
            // DocumentoPanel
            // 
            this.DocumentoPanel.BorderColor = System.Drawing.Color.Gray;
            this.DocumentoPanel.Controls.Add(this.toolStrip1);
            this.DocumentoPanel.Controls.Add(this.label6);
            this.DocumentoPanel.Controls.Add(this.DocumentoListView);
            this.DocumentoPanel.GradientEndColor = System.Drawing.Color.Aquamarine;
            this.DocumentoPanel.GradientStartColor = System.Drawing.Color.White;
            this.DocumentoPanel.Image = null;
            this.DocumentoPanel.ImageLocation = new System.Drawing.Point(4, 4);
            this.DocumentoPanel.Location = new System.Drawing.Point(347, 91);
            this.DocumentoPanel.Name = "DocumentoPanel";
            this.DocumentoPanel.Size = new System.Drawing.Size(250, 214);
            this.DocumentoPanel.TabIndex = 5;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PesquisarDocumentoButton,
            this.SairDocumentoButton});
            this.toolStrip1.Location = new System.Drawing.Point(10, 179);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(49, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PesquisarDocumentoButton
            // 
            this.PesquisarDocumentoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PesquisarDocumentoButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.PesquisarDocumentoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PesquisarDocumentoButton.Name = "PesquisarDocumentoButton";
            this.PesquisarDocumentoButton.Size = new System.Drawing.Size(23, 22);
            this.PesquisarDocumentoButton.Text = "toolStripButton1";
            this.PesquisarDocumentoButton.Click += new System.EventHandler(this.PesquisarDocumentoButton_Click);
            // 
            // SairDocumentoButton
            // 
            this.SairDocumentoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairDocumentoButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.SairDocumentoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairDocumentoButton.Name = "SairDocumentoButton";
            this.SairDocumentoButton.Size = new System.Drawing.Size(23, 22);
            this.SairDocumentoButton.Text = "toolStripButton2";
            this.SairDocumentoButton.Click += new System.EventHandler(this.SairDocumentoButton_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.SkyBlue;
            this.label6.Location = new System.Drawing.Point(1, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Documentos Emitidos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DocumentoListView
            // 
            this.DocumentoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Doc,
            this.DataDoc,
            this.ValorGuia});
            this.DocumentoListView.FullRowSelect = true;
            this.DocumentoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.DocumentoListView.Location = new System.Drawing.Point(5, 23);
            this.DocumentoListView.Name = "DocumentoListView";
            this.DocumentoListView.Size = new System.Drawing.Size(235, 153);
            this.DocumentoListView.TabIndex = 0;
            this.DocumentoListView.UseCompatibleStateImageBehavior = false;
            this.DocumentoListView.View = System.Windows.Forms.View.Details;
            // 
            // Doc
            // 
            this.Doc.Text = "Documento";
            this.Doc.Width = 80;
            // 
            // DataDoc
            // 
            this.DataDoc.Text = "Data";
            this.DataDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DataDoc.Width = 70;
            // 
            // ValorGuia
            // 
            this.ValorGuia.Text = "Valor";
            this.ValorGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ObservacaoPanel
            // 
            this.ObservacaoPanel.BorderColor = System.Drawing.Color.Gray;
            this.ObservacaoPanel.Controls.Add(this.TituloObsLabel);
            this.ObservacaoPanel.Controls.Add(this.tBar);
            this.ObservacaoPanel.Controls.Add(this.ObservacaoText);
            this.ObservacaoPanel.Controls.Add(this.ObservacaoListView);
            this.ObservacaoPanel.GradientEndColor = System.Drawing.Color.Aquamarine;
            this.ObservacaoPanel.GradientStartColor = System.Drawing.Color.Linen;
            this.ObservacaoPanel.Image = null;
            this.ObservacaoPanel.ImageLocation = new System.Drawing.Point(4, 4);
            this.ObservacaoPanel.Location = new System.Drawing.Point(176, 68);
            this.ObservacaoPanel.Name = "ObservacaoPanel";
            this.ObservacaoPanel.Size = new System.Drawing.Size(595, 315);
            this.ObservacaoPanel.TabIndex = 4;
            // 
            // TituloObsLabel
            // 
            this.TituloObsLabel.BackColor = System.Drawing.Color.Teal;
            this.TituloObsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TituloObsLabel.Location = new System.Drawing.Point(1, 1);
            this.TituloObsLabel.Name = "TituloObsLabel";
            this.TituloObsLabel.Size = new System.Drawing.Size(588, 17);
            this.TituloObsLabel.TabIndex = 26;
            this.TituloObsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.AutoSize = false;
            this.tBar.BackColor = System.Drawing.Color.Aquamarine;
            this.tBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NovaObsButton,
            this.AlterarObsButton,
            this.ExcluirObsButton,
            this.GravarObsButton,
            this.CancelarObsButton,
            this.SairObsButton,
            this.ZoomButton});
            this.tBar.Location = new System.Drawing.Point(10, 282);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(574, 25);
            this.tBar.TabIndex = 25;
            this.tBar.Text = "toolStrip1";
            // 
            // NovaObsButton
            // 
            this.NovaObsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NovaObsButton.Image = global::GTI_Desktop.Properties.Resources.add_file;
            this.NovaObsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NovaObsButton.Name = "NovaObsButton";
            this.NovaObsButton.Size = new System.Drawing.Size(23, 22);
            this.NovaObsButton.Text = "toolStripButton1";
            this.NovaObsButton.ToolTipText = "Nova observação";
            this.NovaObsButton.Click += new System.EventHandler(this.NovaObsButton_Click);
            // 
            // AlterarObsButton
            // 
            this.AlterarObsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AlterarObsButton.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.AlterarObsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AlterarObsButton.Name = "AlterarObsButton";
            this.AlterarObsButton.Size = new System.Drawing.Size(23, 22);
            this.AlterarObsButton.Text = "toolStripButton2";
            this.AlterarObsButton.ToolTipText = "Alterar observação";
            this.AlterarObsButton.Click += new System.EventHandler(this.AlterarObsButton_Click);
            // 
            // ExcluirObsButton
            // 
            this.ExcluirObsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExcluirObsButton.Image = global::GTI_Desktop.Properties.Resources.delete;
            this.ExcluirObsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExcluirObsButton.Name = "ExcluirObsButton";
            this.ExcluirObsButton.Size = new System.Drawing.Size(23, 22);
            this.ExcluirObsButton.Text = "toolStripButton3";
            this.ExcluirObsButton.ToolTipText = "Excluir observação";
            this.ExcluirObsButton.Click += new System.EventHandler(this.ExcluirObsButton_Click);
            // 
            // GravarObsButton
            // 
            this.GravarObsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GravarObsButton.Image = global::GTI_Desktop.Properties.Resources.gravar;
            this.GravarObsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GravarObsButton.Name = "GravarObsButton";
            this.GravarObsButton.Size = new System.Drawing.Size(23, 22);
            this.GravarObsButton.Text = "toolStripButton1";
            this.GravarObsButton.ToolTipText = "Gravar observação";
            this.GravarObsButton.Click += new System.EventHandler(this.GravarObsButton_Click);
            // 
            // CancelarObsButton
            // 
            this.CancelarObsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelarObsButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelarObsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelarObsButton.Name = "CancelarObsButton";
            this.CancelarObsButton.Size = new System.Drawing.Size(23, 22);
            this.CancelarObsButton.Text = "toolStripButton2";
            this.CancelarObsButton.ToolTipText = "Cancelar operação";
            this.CancelarObsButton.Click += new System.EventHandler(this.CancelarObsButton_Click);
            // 
            // SairObsButton
            // 
            this.SairObsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairObsButton.Image = global::GTI_Desktop.Properties.Resources.Exit;
            this.SairObsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairObsButton.Name = "SairObsButton";
            this.SairObsButton.Size = new System.Drawing.Size(23, 22);
            this.SairObsButton.Text = "toolStripButton5";
            this.SairObsButton.ToolTipText = "Fechar tela de observação";
            this.SairObsButton.Click += new System.EventHandler(this.SairObsButton_Click);
            // 
            // ZoomButton
            // 
            this.ZoomButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ZoomButton.Image = global::GTI_Desktop.Properties.Resources.more_1_;
            this.ZoomButton.ImageTransparentColor = System.Drawing.Color.White;
            this.ZoomButton.Name = "ZoomButton";
            this.ZoomButton.Size = new System.Drawing.Size(59, 22);
            this.ZoomButton.Text = "Zoom";
            this.ZoomButton.Click += new System.EventHandler(this.ZoomButton_Click);
            // 
            // ObservacaoText
            // 
            this.ObservacaoText.Location = new System.Drawing.Point(6, 192);
            this.ObservacaoText.MaxLength = 2000;
            this.ObservacaoText.Multiline = true;
            this.ObservacaoText.Name = "ObservacaoText";
            this.ObservacaoText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ObservacaoText.Size = new System.Drawing.Size(578, 84);
            this.ObservacaoText.TabIndex = 1;
            // 
            // ObservacaoListView
            // 
            this.ObservacaoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Seq,
            this.Data,
            this.User,
            this.Obs});
            this.ObservacaoListView.FullRowSelect = true;
            this.ObservacaoListView.Location = new System.Drawing.Point(6, 23);
            this.ObservacaoListView.Name = "ObservacaoListView";
            this.ObservacaoListView.Size = new System.Drawing.Size(578, 164);
            this.ObservacaoListView.TabIndex = 0;
            this.ObservacaoListView.UseCompatibleStateImageBehavior = false;
            this.ObservacaoListView.View = System.Windows.Forms.View.Details;
            this.ObservacaoListView.SelectedIndexChanged += new System.EventHandler(this.ObservacaoListView_SelectedIndexChanged);
            // 
            // Seq
            // 
            this.Seq.Text = "Seq";
            this.Seq.Width = 0;
            // 
            // Data
            // 
            this.Data.Text = "Data";
            this.Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Data.Width = 70;
            // 
            // User
            // 
            this.User.Text = "Usuário";
            this.User.Width = 180;
            // 
            // Obs
            // 
            this.Obs.Text = "Observação";
            this.Obs.Width = 300;
            // 
            // MainMenu
            // 
            this.MainMenu.BackColor = System.Drawing.Color.White;
            this.MainMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FiltroMenu,
            this.ObsGeralMenu,
            this.Detalhemenu,
            this.ExtratoMenu,
            this.DocumentoMenu,
            this.ParcelamentoMenu,
            this.DamMenu,
            this.ExecFiscalMenu,
            this.OutrosMenu});
            this.MainMenu.Location = new System.Drawing.Point(11, 32);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenu.Size = new System.Drawing.Size(736, 24);
            this.MainMenu.TabIndex = 45;
            this.MainMenu.Text = "menuStrip1";
            // 
            // FiltroMenu
            // 
            this.FiltroMenu.BackColor = System.Drawing.Color.Aqua;
            this.FiltroMenu.ForeColor = System.Drawing.Color.White;
            this.FiltroMenu.Name = "FiltroMenu";
            this.FiltroMenu.Size = new System.Drawing.Size(84, 20);
            this.FiltroMenu.Text = "Filtrar dados";
            this.FiltroMenu.Click += new System.EventHandler(this.FiltroMenu_Click);
            // 
            // ObsGeralMenu
            // 
            this.ObsGeralMenu.ForeColor = System.Drawing.Color.Maroon;
            this.ObsGeralMenu.Name = "ObsGeralMenu";
            this.ObsGeralMenu.Size = new System.Drawing.Size(81, 20);
            this.ObsGeralMenu.Text = "Observação";
            this.ObsGeralMenu.Click += new System.EventHandler(this.ObsGeralMenu_Click);
            // 
            // Detalhemenu
            // 
            this.Detalhemenu.ForeColor = System.Drawing.Color.Maroon;
            this.Detalhemenu.Name = "Detalhemenu";
            this.Detalhemenu.Size = new System.Drawing.Size(116, 20);
            this.Detalhemenu.Text = "Detalhe da parcela";
            this.Detalhemenu.Click += new System.EventHandler(this.Detalhemenu_Click);
            // 
            // ExtratoMenu
            // 
            this.ExtratoMenu.ForeColor = System.Drawing.Color.Maroon;
            this.ExtratoMenu.Name = "ExtratoMenu";
            this.ExtratoMenu.Size = new System.Drawing.Size(55, 20);
            this.ExtratoMenu.Text = "Extrato";
            this.ExtratoMenu.Click += new System.EventHandler(this.ExtratoMenu_Click);
            // 
            // DocumentoMenu
            // 
            this.DocumentoMenu.ForeColor = System.Drawing.Color.Maroon;
            this.DocumentoMenu.Name = "DocumentoMenu";
            this.DocumentoMenu.Size = new System.Drawing.Size(87, 20);
            this.DocumentoMenu.Text = "Documentos";
            this.DocumentoMenu.Click += new System.EventHandler(this.DocumentoMenu_Click);
            // 
            // ParcelamentoMenu
            // 
            this.ParcelamentoMenu.ForeColor = System.Drawing.Color.Maroon;
            this.ParcelamentoMenu.Name = "ParcelamentoMenu";
            this.ParcelamentoMenu.Size = new System.Drawing.Size(97, 20);
            this.ParcelamentoMenu.Text = "Parcelamentos";
            this.ParcelamentoMenu.Click += new System.EventHandler(this.ParcelamentoMenu_Click);
            // 
            // DamMenu
            // 
            this.DamMenu.ForeColor = System.Drawing.Color.Maroon;
            this.DamMenu.Name = "DamMenu";
            this.DamMenu.Size = new System.Drawing.Size(55, 20);
            this.DamMenu.Text = "D.A.M.";
            // 
            // ExecFiscalMenu
            // 
            this.ExecFiscalMenu.ForeColor = System.Drawing.Color.Maroon;
            this.ExecFiscalMenu.Name = "ExecFiscalMenu";
            this.ExecFiscalMenu.Size = new System.Drawing.Size(98, 20);
            this.ExecFiscalMenu.Text = "Execução fiscal";
            // 
            // OutrosMenu
            // 
            this.OutrosMenu.ForeColor = System.Drawing.Color.Maroon;
            this.OutrosMenu.Name = "OutrosMenu";
            this.OutrosMenu.Size = new System.Drawing.Size(55, 20);
            this.OutrosMenu.Text = "Outros";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuParametros,
            this.mnuImobiliario,
            this.mnuMobiliario,
            this.mnuAtendimento,
            this.mnuTributario,
            this.mnuProtocolo,
            this.mnuOutros,
            this.mnuJanela,
            this.testeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(21, 56);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(616, 24);
            this.menuStrip1.TabIndex = 46;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuParametros
            // 
            this.mnuParametros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroBairroMenu,
            this.CadastroPaisMenu,
            this.CadastroProfissaoMenu});
            this.mnuParametros.Name = "mnuParametros";
            this.mnuParametros.Size = new System.Drawing.Size(79, 20);
            this.mnuParametros.Text = "Parâmetros";
            // 
            // CadastroBairroMenu
            // 
            this.CadastroBairroMenu.Name = "CadastroBairroMenu";
            this.CadastroBairroMenu.Size = new System.Drawing.Size(193, 22);
            this.CadastroBairroMenu.Text = "Cadastro de Bairros";
            // 
            // CadastroPaisMenu
            // 
            this.CadastroPaisMenu.Name = "CadastroPaisMenu";
            this.CadastroPaisMenu.Size = new System.Drawing.Size(193, 22);
            this.CadastroPaisMenu.Text = "Cadastro de Países";
            // 
            // CadastroProfissaoMenu
            // 
            this.CadastroProfissaoMenu.Name = "CadastroProfissaoMenu";
            this.CadastroProfissaoMenu.Size = new System.Drawing.Size(193, 22);
            this.CadastroProfissaoMenu.Text = "Cadastro de Profissões";
            // 
            // mnuImobiliario
            // 
            this.mnuImobiliario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastro,
            this.relatórioToolStripMenuItem});
            this.mnuImobiliario.Name = "mnuImobiliario";
            this.mnuImobiliario.Size = new System.Drawing.Size(76, 20);
            this.mnuImobiliario.Text = "Imobiliário";
            // 
            // mnuCadastro
            // 
            this.mnuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroImovelMenu,
            this.CadastroCondominioMenu,
            this.FaceQuadraMenu});
            this.mnuCadastro.Name = "mnuCadastro";
            this.mnuCadastro.Size = new System.Drawing.Size(121, 22);
            this.mnuCadastro.Text = "Cadastro";
            // 
            // CadastroImovelMenu
            // 
            this.CadastroImovelMenu.Name = "CadastroImovelMenu";
            this.CadastroImovelMenu.Size = new System.Drawing.Size(156, 22);
            this.CadastroImovelMenu.Text = "Imóvel";
            // 
            // CadastroCondominioMenu
            // 
            this.CadastroCondominioMenu.Name = "CadastroCondominioMenu";
            this.CadastroCondominioMenu.Size = new System.Drawing.Size(156, 22);
            this.CadastroCondominioMenu.Text = "Condomínios";
            // 
            // FaceQuadraMenu
            // 
            this.FaceQuadraMenu.Name = "FaceQuadraMenu";
            this.FaceQuadraMenu.Size = new System.Drawing.Size(156, 22);
            this.FaceQuadraMenu.Text = "Face de Quadra";
            // 
            // relatórioToolStripMenuItem
            // 
            this.relatórioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComunicadoIsencaoMenu});
            this.relatórioToolStripMenuItem.Name = "relatórioToolStripMenuItem";
            this.relatórioToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.relatórioToolStripMenuItem.Text = "Relatório";
            // 
            // ComunicadoIsencaoMenu
            // 
            this.ComunicadoIsencaoMenu.Name = "ComunicadoIsencaoMenu";
            this.ComunicadoIsencaoMenu.Size = new System.Drawing.Size(202, 22);
            this.ComunicadoIsencaoMenu.Text = "Comunicado de Isenção";
            // 
            // mnuMobiliario
            // 
            this.mnuMobiliario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMobiliarioCadastro,
            this.tabelasToolStripMenuItem});
            this.mnuMobiliario.Name = "mnuMobiliario";
            this.mnuMobiliario.Size = new System.Drawing.Size(73, 20);
            this.mnuMobiliario.Text = "Mobiliário";
            // 
            // mnuMobiliarioCadastro
            // 
            this.mnuMobiliarioCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroEmpresaMenu,
            this.EscritorioContabilMenu});
            this.mnuMobiliarioCadastro.Name = "mnuMobiliarioCadastro";
            this.mnuMobiliarioCadastro.Size = new System.Drawing.Size(121, 22);
            this.mnuMobiliarioCadastro.Text = "Cadastro";
            // 
            // CadastroEmpresaMenu
            // 
            this.CadastroEmpresaMenu.Name = "CadastroEmpresaMenu";
            this.CadastroEmpresaMenu.Size = new System.Drawing.Size(169, 22);
            this.CadastroEmpresaMenu.Text = "Empresa";
            // 
            // EscritorioContabilMenu
            // 
            this.EscritorioContabilMenu.Name = "EscritorioContabilMenu";
            this.EscritorioContabilMenu.Size = new System.Drawing.Size(169, 22);
            this.EscritorioContabilMenu.Text = "Escritório contábil";
            // 
            // tabelasToolStripMenuItem
            // 
            this.tabelasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AtividadeEmpresaMenu});
            this.tabelasToolStripMenuItem.Name = "tabelasToolStripMenuItem";
            this.tabelasToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.tabelasToolStripMenuItem.Text = "Tabelas";
            // 
            // AtividadeEmpresaMenu
            // 
            this.AtividadeEmpresaMenu.Name = "AtividadeEmpresaMenu";
            this.AtividadeEmpresaMenu.Size = new System.Drawing.Size(203, 22);
            this.AtividadeEmpresaMenu.Text = "Atividades das empresas";
            // 
            // mnuAtendimento
            // 
            this.mnuAtendimento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroCidadaoMenu,
            this.toolStripMenuItem1});
            this.mnuAtendimento.Name = "mnuAtendimento";
            this.mnuAtendimento.Size = new System.Drawing.Size(89, 20);
            this.mnuAtendimento.Text = "Atendimento";
            // 
            // CadastroCidadaoMenu
            // 
            this.CadastroCidadaoMenu.Name = "CadastroCidadaoMenu";
            this.CadastroCidadaoMenu.Size = new System.Drawing.Size(195, 22);
            this.CadastroCidadaoMenu.Text = "Cadastro de cidadão";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(195, 22);
            this.toolStripMenuItem1.Text = "Extrato do contribuinte";
            // 
            // mnuTributario
            // 
            this.mnuTributario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTributarioTabelas,
            this.dividaAtivaToolStripMenuItem,
            this.bancosToolStripMenuItem});
            this.mnuTributario.Name = "mnuTributario";
            this.mnuTributario.Size = new System.Drawing.Size(70, 20);
            this.mnuTributario.Text = "Tributário";
            // 
            // mnuTributarioTabelas
            // 
            this.mnuTributarioTabelas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroLancamentoMenu,
            this.CadastroTributosMenu});
            this.mnuTributarioTabelas.Name = "mnuTributarioTabelas";
            this.mnuTributarioTabelas.Size = new System.Drawing.Size(137, 22);
            this.mnuTributarioTabelas.Text = "Tabelas";
            // 
            // CadastroLancamentoMenu
            // 
            this.CadastroLancamentoMenu.Name = "CadastroLancamentoMenu";
            this.CadastroLancamentoMenu.Size = new System.Drawing.Size(208, 22);
            this.CadastroLancamentoMenu.Text = "Cadastro de lançamentos";
            // 
            // CadastroTributosMenu
            // 
            this.CadastroTributosMenu.Name = "CadastroTributosMenu";
            this.CadastroTributosMenu.Size = new System.Drawing.Size(208, 22);
            this.CadastroTributosMenu.Text = "Cadastro de tributos";
            // 
            // dividaAtivaToolStripMenuItem
            // 
            this.dividaAtivaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CartaCobrancaMenu});
            this.dividaAtivaToolStripMenuItem.Name = "dividaAtivaToolStripMenuItem";
            this.dividaAtivaToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.dividaAtivaToolStripMenuItem.Text = "Divida Ativa";
            // 
            // CartaCobrancaMenu
            // 
            this.CartaCobrancaMenu.Name = "CartaCobrancaMenu";
            this.CartaCobrancaMenu.Size = new System.Drawing.Size(170, 22);
            this.CartaCobrancaMenu.Text = "Carta de cobrança";
            // 
            // bancosToolStripMenuItem
            // 
            this.bancosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RegistroBancarioMenu});
            this.bancosToolStripMenuItem.Name = "bancosToolStripMenuItem";
            this.bancosToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.bancosToolStripMenuItem.Text = "Bancos";
            // 
            // RegistroBancarioMenu
            // 
            this.RegistroBancarioMenu.Name = "RegistroBancarioMenu";
            this.RegistroBancarioMenu.Size = new System.Drawing.Size(166, 22);
            this.RegistroBancarioMenu.Text = "Registro bancário";
            // 
            // mnuProtocolo
            // 
            this.mnuProtocolo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabelasBásicasToolStripMenuItem,
            this.mnuControleProcesso,
            this.relatóriosToolStripMenuItem});
            this.mnuProtocolo.Name = "mnuProtocolo";
            this.mnuProtocolo.Size = new System.Drawing.Size(71, 20);
            this.mnuProtocolo.Text = "Protocolo";
            // 
            // tabelasBásicasToolStripMenuItem
            // 
            this.tabelasBásicasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentaçãoParaProcessosToolStripMenuItem,
            this.despachosDosTrâmitesToolStripMenuItem,
            this.assuntosDoProcessoToolStripMenuItem,
            this.localDeTramitaçãoDeProcessosToolStripMenuItem});
            this.tabelasBásicasToolStripMenuItem.Name = "tabelasBásicasToolStripMenuItem";
            this.tabelasBásicasToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.tabelasBásicasToolStripMenuItem.Text = "Tabelas básicas";
            // 
            // documentaçãoParaProcessosToolStripMenuItem
            // 
            this.documentaçãoParaProcessosToolStripMenuItem.Name = "documentaçãoParaProcessosToolStripMenuItem";
            this.documentaçãoParaProcessosToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.documentaçãoParaProcessosToolStripMenuItem.Text = "Documentação para processos";
            // 
            // despachosDosTrâmitesToolStripMenuItem
            // 
            this.despachosDosTrâmitesToolStripMenuItem.Name = "despachosDosTrâmitesToolStripMenuItem";
            this.despachosDosTrâmitesToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.despachosDosTrâmitesToolStripMenuItem.Text = "Despachos dos trâmites";
            // 
            // assuntosDoProcessoToolStripMenuItem
            // 
            this.assuntosDoProcessoToolStripMenuItem.Name = "assuntosDoProcessoToolStripMenuItem";
            this.assuntosDoProcessoToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.assuntosDoProcessoToolStripMenuItem.Text = "Assuntos do processo";
            // 
            // localDeTramitaçãoDeProcessosToolStripMenuItem
            // 
            this.localDeTramitaçãoDeProcessosToolStripMenuItem.Name = "localDeTramitaçãoDeProcessosToolStripMenuItem";
            this.localDeTramitaçãoDeProcessosToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.localDeTramitaçãoDeProcessosToolStripMenuItem.Text = "Local de tramitação de processos";
            // 
            // mnuControleProcesso
            // 
            this.mnuControleProcesso.Name = "mnuControleProcesso";
            this.mnuControleProcesso.Size = new System.Drawing.Size(191, 22);
            this.mnuControleProcesso.Text = "Controle de processos";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProcessoAtrasoMenu});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // ProcessoAtrasoMenu
            // 
            this.ProcessoAtrasoMenu.Name = "ProcessoAtrasoMenu";
            this.ProcessoAtrasoMenu.Size = new System.Drawing.Size(181, 22);
            this.ProcessoAtrasoMenu.Text = "Processos em atraso";
            // 
            // mnuOutros
            // 
            this.mnuOutros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigMenu,
            this.mnuSecurity,
            this.administrativoToolStripMenuItem});
            this.mnuOutros.Name = "mnuOutros";
            this.mnuOutros.Size = new System.Drawing.Size(55, 20);
            this.mnuOutros.Text = "Outros";
            // 
            // ConfigMenu
            // 
            this.ConfigMenu.Name = "ConfigMenu";
            this.ConfigMenu.Size = new System.Drawing.Size(152, 22);
            this.ConfigMenu.Text = "Configuração";
            // 
            // mnuSecurity
            // 
            this.mnuSecurity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CadastroUsuariosMenu,
            this.CadastroEventoMenu,
            this.AtribuicaoAcessoMenu});
            this.mnuSecurity.Name = "mnuSecurity";
            this.mnuSecurity.Size = new System.Drawing.Size(152, 22);
            this.mnuSecurity.Text = "Segurança";
            // 
            // CadastroUsuariosMenu
            // 
            this.CadastroUsuariosMenu.Name = "CadastroUsuariosMenu";
            this.CadastroUsuariosMenu.Size = new System.Drawing.Size(188, 22);
            this.CadastroUsuariosMenu.Text = "Cadastro de usuários";
            // 
            // CadastroEventoMenu
            // 
            this.CadastroEventoMenu.Name = "CadastroEventoMenu";
            this.CadastroEventoMenu.Size = new System.Drawing.Size(188, 22);
            this.CadastroEventoMenu.Text = "Eventos do sistema";
            // 
            // AtribuicaoAcessoMenu
            // 
            this.AtribuicaoAcessoMenu.Name = "AtribuicaoAcessoMenu";
            this.AtribuicaoAcessoMenu.Size = new System.Drawing.Size(188, 22);
            this.AtribuicaoAcessoMenu.Text = "Atribuição de acessos";
            // 
            // administrativoToolStripMenuItem
            // 
            this.administrativoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CalculoImpostoMenu});
            this.administrativoToolStripMenuItem.Name = "administrativoToolStripMenuItem";
            this.administrativoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.administrativoToolStripMenuItem.Text = "Administrativo";
            // 
            // CalculoImpostoMenu
            // 
            this.CalculoImpostoMenu.Name = "CalculoImpostoMenu";
            this.CalculoImpostoMenu.Size = new System.Drawing.Size(177, 22);
            this.CalculoImpostoMenu.Text = "Calculo de Imposto";
            // 
            // mnuJanela
            // 
            this.mnuJanela.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minimizarTodasToolStripMenuItem,
            this.restaurarTodasToolStripMenuItem,
            this.fecharTodasToolStripMenuItem,
            this.toolStripSeparator1,
            this.emCascataToolStripMenuItem,
            this.ladoALadoToolStripMenuItem});
            this.mnuJanela.Name = "mnuJanela";
            this.mnuJanela.Size = new System.Drawing.Size(51, 20);
            this.mnuJanela.Text = "Janela";
            // 
            // minimizarTodasToolStripMenuItem
            // 
            this.minimizarTodasToolStripMenuItem.Name = "minimizarTodasToolStripMenuItem";
            this.minimizarTodasToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.minimizarTodasToolStripMenuItem.Text = "Minimizar todas";
            // 
            // restaurarTodasToolStripMenuItem
            // 
            this.restaurarTodasToolStripMenuItem.Name = "restaurarTodasToolStripMenuItem";
            this.restaurarTodasToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.restaurarTodasToolStripMenuItem.Text = "Restaurar todas";
            // 
            // fecharTodasToolStripMenuItem
            // 
            this.fecharTodasToolStripMenuItem.Name = "fecharTodasToolStripMenuItem";
            this.fecharTodasToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.fecharTodasToolStripMenuItem.Text = "Fechar todas";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // emCascataToolStripMenuItem
            // 
            this.emCascataToolStripMenuItem.Name = "emCascataToolStripMenuItem";
            this.emCascataToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.emCascataToolStripMenuItem.Text = "Em cascata";
            // 
            // ladoALadoToolStripMenuItem
            // 
            this.ladoALadoToolStripMenuItem.Name = "ladoALadoToolStripMenuItem";
            this.ladoALadoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ladoALadoToolStripMenuItem.Text = "Lado a lado";
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.testeToolStripMenuItem.Text = "teste";
            // 
            // Extrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 593);
            this.Controls.Add(this.FiltroPanel);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.sBar);
            this.Controls.Add(this.a1Panel2);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(850, 400);
            this.Name = "Extrato";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extrato do contribuinte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Extrato_FormClosing);
            this.sBar.ResumeLayout(false);
            this.sBar.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExtratoDataGrid)).EndInit();
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            this.FiltroPanel.ResumeLayout(false);
            this.FiltroPanel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GridPanel.ResumeLayout(false);
            this.DocumentoPanel.ResumeLayout(false);
            this.DocumentoPanel.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ObservacaoPanel.ResumeLayout(false);
            this.ObservacaoPanel.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip sBar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalNPago;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalVenc;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalSel;
        internal System.Windows.Forms.ContextMenuStrip mnuMain;
        internal System.Windows.Forms.ToolStripMenuItem mnuEditaParcela;
        internal System.Windows.Forms.DataGridView ExtratoDataGrid;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox CodigoText;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Button ConsultarCodigoButton;
        private System.Windows.Forms.CheckBox ChkAllExercicio;
        private Owf.Controls.A1Panel a1Panel2;
        private System.Windows.Forms.TextBox txtNome;
        private Owf.Controls.A1Panel FiltroPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CmbAnoInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbAnoFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FiltroButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtSelectLancamento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtSelectStatus;
        private Owf.Controls.A1Panel GridPanel;
        private System.Windows.Forms.CheckBox ChkParcelaOculta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbDivAtiva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CmbAjuizado;
        private System.Windows.Forms.Button OcultarButton;
        private System.Windows.Forms.DataGridViewImageColumn imgCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn lancamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcela;
        private System.Windows.Forms.DataGridViewTextBoxColumn complemento;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_vencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn DA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_lancado;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor_atual;
        private System.Windows.Forms.DataGridViewTextBoxColumn notificado;
        private System.Windows.Forms.DataGridViewTextBoxColumn exec_fiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn certidao;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_remessa;
        private Owf.Controls.A1Panel ObservacaoPanel;
        private System.Windows.Forms.TextBox ObservacaoText;
        private System.Windows.Forms.ListView ObservacaoListView;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton NovaObsButton;
        private System.Windows.Forms.ToolStripButton AlterarObsButton;
        private System.Windows.Forms.ToolStripButton ExcluirObsButton;
        private System.Windows.Forms.ToolStripButton SairObsButton;
        private System.Windows.Forms.ToolStripButton GravarObsButton;
        private System.Windows.Forms.ToolStripButton CancelarObsButton;
        private System.Windows.Forms.Label TituloObsLabel;
        private System.Windows.Forms.ColumnHeader Seq;
        private System.Windows.Forms.ColumnHeader Data;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ColumnHeader Obs;
        private System.Windows.Forms.ToolStripButton ZoomButton;
        private Owf.Controls.A1Panel DocumentoPanel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton PesquisarDocumentoButton;
        private System.Windows.Forms.ToolStripButton SairDocumentoButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView DocumentoListView;
        private System.Windows.Forms.ColumnHeader Doc;
        private System.Windows.Forms.ColumnHeader DataDoc;
        private System.Windows.Forms.ColumnHeader ValorGuia;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FiltroMenu;
        private System.Windows.Forms.ToolStripMenuItem ObsGeralMenu;
        private System.Windows.Forms.ToolStripMenuItem Detalhemenu;
        private System.Windows.Forms.ToolStripMenuItem ExtratoMenu;
        private System.Windows.Forms.ToolStripMenuItem DocumentoMenu;
        private System.Windows.Forms.ToolStripMenuItem ParcelamentoMenu;
        private System.Windows.Forms.ToolStripMenuItem DamMenu;
        private System.Windows.Forms.ToolStripMenuItem ExecFiscalMenu;
        private System.Windows.Forms.ToolStripMenuItem OutrosMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuParametros;
        private System.Windows.Forms.ToolStripMenuItem CadastroBairroMenu;
        private System.Windows.Forms.ToolStripMenuItem CadastroPaisMenu;
        private System.Windows.Forms.ToolStripMenuItem CadastroProfissaoMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuImobiliario;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastro;
        private System.Windows.Forms.ToolStripMenuItem CadastroImovelMenu;
        private System.Windows.Forms.ToolStripMenuItem CadastroCondominioMenu;
        private System.Windows.Forms.ToolStripMenuItem FaceQuadraMenu;
        private System.Windows.Forms.ToolStripMenuItem relatórioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComunicadoIsencaoMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMobiliario;
        private System.Windows.Forms.ToolStripMenuItem mnuMobiliarioCadastro;
        private System.Windows.Forms.ToolStripMenuItem CadastroEmpresaMenu;
        private System.Windows.Forms.ToolStripMenuItem EscritorioContabilMenu;
        private System.Windows.Forms.ToolStripMenuItem tabelasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AtividadeEmpresaMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuAtendimento;
        private System.Windows.Forms.ToolStripMenuItem CadastroCidadaoMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuTributario;
        private System.Windows.Forms.ToolStripMenuItem mnuTributarioTabelas;
        private System.Windows.Forms.ToolStripMenuItem CadastroLancamentoMenu;
        private System.Windows.Forms.ToolStripMenuItem CadastroTributosMenu;
        private System.Windows.Forms.ToolStripMenuItem dividaAtivaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CartaCobrancaMenu;
        private System.Windows.Forms.ToolStripMenuItem bancosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RegistroBancarioMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuProtocolo;
        private System.Windows.Forms.ToolStripMenuItem tabelasBásicasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentaçãoParaProcessosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem despachosDosTrâmitesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assuntosDoProcessoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDeTramitaçãoDeProcessosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuControleProcesso;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProcessoAtrasoMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuOutros;
        private System.Windows.Forms.ToolStripMenuItem ConfigMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuSecurity;
        private System.Windows.Forms.ToolStripMenuItem CadastroUsuariosMenu;
        private System.Windows.Forms.ToolStripMenuItem CadastroEventoMenu;
        private System.Windows.Forms.ToolStripMenuItem AtribuicaoAcessoMenu;
        private System.Windows.Forms.ToolStripMenuItem administrativoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CalculoImpostoMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuJanela;
        private System.Windows.Forms.ToolStripMenuItem minimizarTodasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarTodasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharTodasToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem emCascataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladoALadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testeToolStripMenuItem;
    }
}