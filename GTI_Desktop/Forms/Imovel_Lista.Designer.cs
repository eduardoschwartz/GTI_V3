namespace GTI_Desktop.Forms {
    partial class Imovel_Lista {
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
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProprietarioButton = new System.Windows.Forms.Button();
            this.Proprietario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrincipalCheckBox = new System.Windows.Forms.CheckBox();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.FindButton = new System.Windows.Forms.ToolStripButton();
            this.SelectButton = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.Inscricao = new System.Windows.Forms.MaskedTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TotalImovel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.tBar.SuspendLayout();
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
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(0, 156);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(677, 266);
            this.MainListView.TabIndex = 76;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            this.MainListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.MainListView_ColumnClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Inscrição";
            this.columnHeader2.Width = 170;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Proprietário";
            this.columnHeader4.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Endereço";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Nº";
            this.columnHeader5.Width = 38;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Inscricao);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ProprietarioButton);
            this.panel1.Controls.Add(this.Proprietario);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.PrincipalCheckBox);
            this.panel1.Controls.Add(this.Codigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 150);
            this.panel1.TabIndex = 75;
            // 
            // ProprietarioButton
            // 
            this.ProprietarioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProprietarioButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.ProprietarioButton.Location = new System.Drawing.Point(419, 23);
            this.ProprietarioButton.Name = "ProprietarioButton";
            this.ProprietarioButton.Size = new System.Drawing.Size(25, 25);
            this.ProprietarioButton.TabIndex = 76;
            this.ProprietarioButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ProprietarioButton.UseVisualStyleBackColor = true;
            this.ProprietarioButton.Click += new System.EventHandler(this.ProprietarioButton_Click);
            // 
            // Proprietario
            // 
            this.Proprietario.Location = new System.Drawing.Point(79, 26);
            this.Proprietario.MaxLength = 0;
            this.Proprietario.Name = "Proprietario";
            this.Proprietario.ReadOnly = true;
            this.Proprietario.Size = new System.Drawing.Size(334, 20);
            this.Proprietario.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 74;
            this.label2.Text = "Proprietário..:";
            // 
            // PrincipalCheckBox
            // 
            this.PrincipalCheckBox.AutoSize = true;
            this.PrincipalCheckBox.Checked = true;
            this.PrincipalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PrincipalCheckBox.Location = new System.Drawing.Point(162, 6);
            this.PrincipalCheckBox.Name = "PrincipalCheckBox";
            this.PrincipalCheckBox.Size = new System.Drawing.Size(165, 17);
            this.PrincipalCheckBox.TabIndex = 73;
            this.PrincipalCheckBox.Text = "Somente proprietário principal";
            this.PrincipalCheckBox.UseVisualStyleBackColor = true;
            // 
            // Codigo
            // 
            this.Codigo.Location = new System.Drawing.Point(79, 3);
            this.Codigo.MaxLength = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(65, 20);
            this.Codigo.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 71;
            this.label1.Text = "Código.........:";
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.SystemColors.Control;
            this.tBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindButton,
            this.SelectButton,
            this.toolStripSeparator1,
            this.PBar,
            this.toolStripSeparator2,
            this.TotalImovel,
            this.toolStripLabel2});
            this.tBar.Location = new System.Drawing.Point(0, 425);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.Size = new System.Drawing.Size(677, 25);
            this.tBar.TabIndex = 70;
            this.tBar.Text = "toolStrip1";
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
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectButton.Image = global::GTI_Desktop.Properties.Resources.rightarrow;
            this.SelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(23, 22);
            this.SelectButton.Text = "toolStripButton2";
            this.SelectButton.ToolTipText = "Retornar";
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 77;
            this.label3.Text = "Inscrição.....:";
            // 
            // Inscricao
            // 
            this.Inscricao.Location = new System.Drawing.Point(542, 4);
            this.Inscricao.Mask = "9.99.9999.99999";
            this.Inscricao.Name = "Inscricao";
            this.Inscricao.PromptChar = ' ';
            this.Inscricao.Size = new System.Drawing.Size(92, 20);
            this.Inscricao.TabIndex = 78;
            this.Inscricao.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(100, 22);
            this.toolStripLabel2.Text = "Total encontrado:";
            // 
            // TotalImovel
            // 
            this.TotalImovel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.TotalImovel.ForeColor = System.Drawing.Color.Maroon;
            this.TotalImovel.Name = "TotalImovel";
            this.TotalImovel.Size = new System.Drawing.Size(13, 22);
            this.TotalImovel.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // PBar
            // 
            this.PBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PBar.AutoSize = false;
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(100, 14);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Imovel_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.MainListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tBar);
            this.MaximizeBox = false;
            this.Name = "Imovel_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista dos imóveis cadastrados";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton FindButton;
        private System.Windows.Forms.ToolStripButton SelectButton;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckBox PrincipalCheckBox;
        private System.Windows.Forms.TextBox Proprietario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ProprietarioButton;
        private System.Windows.Forms.MaskedTextBox Inscricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripProgressBar PBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel TotalImovel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}