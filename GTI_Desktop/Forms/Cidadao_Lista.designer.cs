namespace GTI_Desktop.Forms {
    partial class Cidadao_Lista {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cidadao_Lista));
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Busca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.mnuTitle = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuNome = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCPF = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCNPJ = new System.Windows.Forms.ToolStripMenuItem();
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.ReturnButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TotalCidadao = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.tBar.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.CPF,
            this.columnHeader3});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(0, 28);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(632, 315);
            this.MainListView.TabIndex = 74;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.VirtualMode = true;
            this.MainListView.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvMain_RetrieveVirtualItem);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 300;
            // 
            // CPF
            // 
            this.CPF.Text = "CPF";
            this.CPF.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CNPJ";
            this.columnHeader3.Width = 120;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Busca);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 28);
            this.panel1.TabIndex = 73;
            // 
            // Busca
            // 
            this.Busca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Busca.Location = new System.Drawing.Point(74, 3);
            this.Busca.Name = "Busca";
            this.Busca.Size = new System.Drawing.Size(377, 20);
            this.Busca.TabIndex = 72;
            this.Busca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtBusca_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Pesquisa..:";
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTitle,
            this.FindButton,
            this.ReturnButton});
            this.tBar.Location = new System.Drawing.Point(558, 0);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(68, 25);
            this.tBar.TabIndex = 70;
            this.tBar.Text = "toolStrip1";
            // 
            // mnuTitle
            // 
            this.mnuTitle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNome,
            this.mnuCPF,
            this.mnuCNPJ});
            this.mnuTitle.Image = ((System.Drawing.Image)(resources.GetObject("mnuTitle.Image")));
            this.mnuTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuTitle.Name = "mnuTitle";
            this.mnuTitle.Size = new System.Drawing.Size(13, 22);
            // 
            // mnuNome
            // 
            this.mnuNome.CheckOnClick = true;
            this.mnuNome.Name = "mnuNome";
            this.mnuNome.Size = new System.Drawing.Size(107, 22);
            this.mnuNome.Text = "Nome";
            this.mnuNome.Click += new System.EventHandler(this.MnuNome_Click);
            // 
            // mnuCPF
            // 
            this.mnuCPF.CheckOnClick = true;
            this.mnuCPF.Name = "mnuCPF";
            this.mnuCPF.Size = new System.Drawing.Size(107, 22);
            this.mnuCPF.Text = "CPF";
            this.mnuCPF.Click += new System.EventHandler(this.MnuCPF_Click);
            // 
            // mnuCNPJ
            // 
            this.mnuCNPJ.CheckOnClick = true;
            this.mnuCNPJ.Name = "mnuCNPJ";
            this.mnuCNPJ.Size = new System.Drawing.Size(107, 22);
            this.mnuCNPJ.Text = "CNPJ";
            this.mnuCNPJ.Click += new System.EventHandler(this.MnuCNPJ_Click);
            // 
            // FindButton
            // 
            this.FindButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FindButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.FindButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(23, 22);
            this.FindButton.Text = "toolStripButton1";
            this.FindButton.ToolTipText = "Pesquisar";
            this.FindButton.Click += new System.EventHandler(this.BtFind_Click);
            // 
            // ReturnButton
            // 
            this.ReturnButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReturnButton.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.ReturnButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(23, 22);
            this.ReturnButton.Text = "toolStripButton2";
            this.ReturnButton.ToolTipText = "Retornar";
            this.ReturnButton.Click += new System.EventHandler(this.BtReturn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TotalCidadao});
            this.toolStrip1.Location = new System.Drawing.Point(0, 346);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 75;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(106, 22);
            this.toolStripLabel1.Text = "Total encontrado..:";
            // 
            // TotalCidadao
            // 
            this.TotalCidadao.ForeColor = System.Drawing.Color.Maroon;
            this.TotalCidadao.Name = "TotalCidadao";
            this.TotalCidadao.Size = new System.Drawing.Size(13, 22);
            this.TotalCidadao.Text = "0";
            // 
            // Cidadao_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 371);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Cidadao_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Cidadão";
            this.Activated += new System.EventHandler(this.Cidadao_Lista_Activated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader CPF;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Busca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripDropDownButton mnuTitle;
        private System.Windows.Forms.ToolStripMenuItem mnuNome;
        private System.Windows.Forms.ToolStripMenuItem mnuCPF;
        private System.Windows.Forms.ToolStripMenuItem mnuCNPJ;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton ReturnButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel TotalCidadao;
    }
}