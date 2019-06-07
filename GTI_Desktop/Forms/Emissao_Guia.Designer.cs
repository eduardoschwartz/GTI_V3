namespace GTI_Desktop.Forms {
    partial class Emissao_Guia {
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
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.DocText = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.NomeText = new System.Windows.Forms.TextBox();
            this.ConsultarCodigoButton = new System.Windows.Forms.Button();
            this.CodigoText = new System.Windows.Forms.TextBox();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.LoteText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.QuadraText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.UFText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CidadeText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CepText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InscricaoText = new System.Windows.Forms.TextBox();
            this.BairroText = new System.Windows.Forms.TextBox();
            this.EnderecoText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.a1Panel3 = new Owf.Controls.A1Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.UFEntText = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.CidadeEntText = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CepEntText = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.BairroEntText = new System.Windows.Forms.TextBox();
            this.EnderecoEntText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.HeaderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ImovelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EmpresaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CidadaoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.a1Panel2.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            this.a1Panel3.SuspendLayout();
            this.HeaderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Panel2
            // 
            this.a1Panel2.BackColor = System.Drawing.Color.Linen;
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.DocText);
            this.a1Panel2.Controls.Add(this.Label1);
            this.a1Panel2.Controls.Add(this.NomeText);
            this.a1Panel2.Controls.Add(this.ConsultarCodigoButton);
            this.a1Panel2.Controls.Add(this.CodigoText);
            this.a1Panel2.GradientEndColor = System.Drawing.Color.Linen;
            this.a1Panel2.GradientStartColor = System.Drawing.Color.Linen;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(4, 4);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.ShadowOffSet = 3;
            this.a1Panel2.Size = new System.Drawing.Size(522, 60);
            this.a1Panel2.TabIndex = 1;
            // 
            // DocText
            // 
            this.DocText.BackColor = System.Drawing.Color.Linen;
            this.DocText.Location = new System.Drawing.Point(362, 30);
            this.DocText.Name = "DocText";
            this.DocText.ReadOnly = true;
            this.DocText.Size = new System.Drawing.Size(149, 20);
            this.DocText.TabIndex = 47;
            this.DocText.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Linen;
            this.Label1.Location = new System.Drawing.Point(8, 10);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 13);
            this.Label1.TabIndex = 46;
            this.Label1.Text = "Código....:";
            // 
            // NomeText
            // 
            this.NomeText.BackColor = System.Drawing.Color.Linen;
            this.NomeText.Location = new System.Drawing.Point(11, 30);
            this.NomeText.Name = "NomeText";
            this.NomeText.ReadOnly = true;
            this.NomeText.Size = new System.Drawing.Size(345, 20);
            this.NomeText.TabIndex = 36;
            this.NomeText.TabStop = false;
            // 
            // ConsultarCodigoButton
            // 
            this.ConsultarCodigoButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.ConsultarCodigoButton.Location = new System.Drawing.Point(134, 6);
            this.ConsultarCodigoButton.Name = "ConsultarCodigoButton";
            this.ConsultarCodigoButton.Size = new System.Drawing.Size(23, 22);
            this.ConsultarCodigoButton.TabIndex = 1;
            this.ConsultarCodigoButton.UseVisualStyleBackColor = true;
            this.ConsultarCodigoButton.Click += new System.EventHandler(this.ConsultarCodigoButton_Click);
            // 
            // CodigoText
            // 
            this.CodigoText.Location = new System.Drawing.Point(69, 7);
            this.CodigoText.MaxLength = 6;
            this.CodigoText.Name = "CodigoText";
            this.CodigoText.Size = new System.Drawing.Size(63, 20);
            this.CodigoText.TabIndex = 0;
            this.CodigoText.TextChanged += new System.EventHandler(this.CodigoText_TextChanged);
            this.CodigoText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CodigoText_KeyDown);
            this.CodigoText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CodigoText_KeyPress);
            // 
            // a1Panel1
            // 
            this.a1Panel1.BackColor = System.Drawing.Color.Linen;
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.label10);
            this.a1Panel1.Controls.Add(this.LoteText);
            this.a1Panel1.Controls.Add(this.label9);
            this.a1Panel1.Controls.Add(this.QuadraText);
            this.a1Panel1.Controls.Add(this.label8);
            this.a1Panel1.Controls.Add(this.UFText);
            this.a1Panel1.Controls.Add(this.label7);
            this.a1Panel1.Controls.Add(this.CidadeText);
            this.a1Panel1.Controls.Add(this.label6);
            this.a1Panel1.Controls.Add(this.CepText);
            this.a1Panel1.Controls.Add(this.label5);
            this.a1Panel1.Controls.Add(this.label4);
            this.a1Panel1.Controls.Add(this.label3);
            this.a1Panel1.Controls.Add(this.InscricaoText);
            this.a1Panel1.Controls.Add(this.BairroText);
            this.a1Panel1.Controls.Add(this.EnderecoText);
            this.a1Panel1.GradientEndColor = System.Drawing.Color.Linen;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.Linen;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(4, 73);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.ShadowOffSet = 3;
            this.a1Panel1.Size = new System.Drawing.Size(522, 87);
            this.a1Panel1.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Linen;
            this.label10.Location = new System.Drawing.Point(395, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Lote..:";
            // 
            // LoteText
            // 
            this.LoteText.BackColor = System.Drawing.Color.Linen;
            this.LoteText.Location = new System.Drawing.Point(438, 56);
            this.LoteText.Name = "LoteText";
            this.LoteText.ReadOnly = true;
            this.LoteText.Size = new System.Drawing.Size(73, 20);
            this.LoteText.TabIndex = 58;
            this.LoteText.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Linen;
            this.label9.Location = new System.Drawing.Point(246, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Quadra..:";
            // 
            // QuadraText
            // 
            this.QuadraText.BackColor = System.Drawing.Color.Linen;
            this.QuadraText.Location = new System.Drawing.Point(301, 56);
            this.QuadraText.Name = "QuadraText";
            this.QuadraText.ReadOnly = true;
            this.QuadraText.Size = new System.Drawing.Size(87, 20);
            this.QuadraText.TabIndex = 56;
            this.QuadraText.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Linen;
            this.label8.Location = new System.Drawing.Point(443, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 55;
            this.label8.Text = "UF....:";
            // 
            // UFText
            // 
            this.UFText.BackColor = System.Drawing.Color.Linen;
            this.UFText.Location = new System.Drawing.Point(485, 33);
            this.UFText.Name = "UFText";
            this.UFText.ReadOnly = true;
            this.UFText.Size = new System.Drawing.Size(26, 20);
            this.UFText.TabIndex = 54;
            this.UFText.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Linen;
            this.label7.Location = new System.Drawing.Point(246, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Cidade..:";
            // 
            // CidadeText
            // 
            this.CidadeText.BackColor = System.Drawing.Color.Linen;
            this.CidadeText.Location = new System.Drawing.Point(301, 33);
            this.CidadeText.Name = "CidadeText";
            this.CidadeText.ReadOnly = true;
            this.CidadeText.Size = new System.Drawing.Size(128, 20);
            this.CidadeText.TabIndex = 52;
            this.CidadeText.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Linen;
            this.label6.Location = new System.Drawing.Point(394, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Cep..:";
            // 
            // CepText
            // 
            this.CepText.BackColor = System.Drawing.Color.Linen;
            this.CepText.Location = new System.Drawing.Point(435, 10);
            this.CepText.Name = "CepText";
            this.CepText.ReadOnly = true;
            this.CepText.Size = new System.Drawing.Size(76, 20);
            this.CepText.TabIndex = 50;
            this.CepText.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Linen;
            this.label5.Location = new System.Drawing.Point(8, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Inscrição....:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Linen;
            this.label4.Location = new System.Drawing.Point(8, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Bairro.........:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Linen;
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Endereço...:";
            // 
            // InscricaoText
            // 
            this.InscricaoText.BackColor = System.Drawing.Color.Linen;
            this.InscricaoText.Location = new System.Drawing.Point(78, 56);
            this.InscricaoText.Name = "InscricaoText";
            this.InscricaoText.ReadOnly = true;
            this.InscricaoText.Size = new System.Drawing.Size(156, 20);
            this.InscricaoText.TabIndex = 38;
            this.InscricaoText.TabStop = false;
            // 
            // BairroText
            // 
            this.BairroText.BackColor = System.Drawing.Color.Linen;
            this.BairroText.Location = new System.Drawing.Point(78, 33);
            this.BairroText.Name = "BairroText";
            this.BairroText.ReadOnly = true;
            this.BairroText.Size = new System.Drawing.Size(156, 20);
            this.BairroText.TabIndex = 37;
            this.BairroText.TabStop = false;
            // 
            // EnderecoText
            // 
            this.EnderecoText.BackColor = System.Drawing.Color.Linen;
            this.EnderecoText.Location = new System.Drawing.Point(78, 10);
            this.EnderecoText.Name = "EnderecoText";
            this.EnderecoText.ReadOnly = true;
            this.EnderecoText.Size = new System.Drawing.Size(310, 20);
            this.EnderecoText.TabIndex = 36;
            this.EnderecoText.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Linen;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(8, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Endereço de Localização";
            // 
            // a1Panel3
            // 
            this.a1Panel3.BackColor = System.Drawing.Color.Linen;
            this.a1Panel3.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel3.Controls.Add(this.label13);
            this.a1Panel3.Controls.Add(this.UFEntText);
            this.a1Panel3.Controls.Add(this.label14);
            this.a1Panel3.Controls.Add(this.CidadeEntText);
            this.a1Panel3.Controls.Add(this.label15);
            this.a1Panel3.Controls.Add(this.CepEntText);
            this.a1Panel3.Controls.Add(this.label17);
            this.a1Panel3.Controls.Add(this.label18);
            this.a1Panel3.Controls.Add(this.BairroEntText);
            this.a1Panel3.Controls.Add(this.EnderecoEntText);
            this.a1Panel3.GradientEndColor = System.Drawing.Color.Linen;
            this.a1Panel3.GradientStartColor = System.Drawing.Color.Linen;
            this.a1Panel3.Image = null;
            this.a1Panel3.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel3.Location = new System.Drawing.Point(4, 171);
            this.a1Panel3.Name = "a1Panel3";
            this.a1Panel3.ShadowOffSet = 3;
            this.a1Panel3.Size = new System.Drawing.Size(522, 64);
            this.a1Panel3.TabIndex = 47;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Linen;
            this.label13.Location = new System.Drawing.Point(443, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 55;
            this.label13.Text = "UF....:";
            // 
            // UFEntText
            // 
            this.UFEntText.BackColor = System.Drawing.Color.Linen;
            this.UFEntText.Location = new System.Drawing.Point(485, 33);
            this.UFEntText.Name = "UFEntText";
            this.UFEntText.ReadOnly = true;
            this.UFEntText.Size = new System.Drawing.Size(26, 20);
            this.UFEntText.TabIndex = 54;
            this.UFEntText.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Linen;
            this.label14.Location = new System.Drawing.Point(246, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Cidade..:";
            // 
            // CidadeEntText
            // 
            this.CidadeEntText.BackColor = System.Drawing.Color.Linen;
            this.CidadeEntText.Location = new System.Drawing.Point(301, 33);
            this.CidadeEntText.Name = "CidadeEntText";
            this.CidadeEntText.ReadOnly = true;
            this.CidadeEntText.Size = new System.Drawing.Size(128, 20);
            this.CidadeEntText.TabIndex = 52;
            this.CidadeEntText.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Linen;
            this.label15.Location = new System.Drawing.Point(394, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Cep..:";
            // 
            // CepEntText
            // 
            this.CepEntText.BackColor = System.Drawing.Color.Linen;
            this.CepEntText.Location = new System.Drawing.Point(435, 10);
            this.CepEntText.Name = "CepEntText";
            this.CepEntText.ReadOnly = true;
            this.CepEntText.Size = new System.Drawing.Size(76, 20);
            this.CepEntText.TabIndex = 50;
            this.CepEntText.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Linen;
            this.label17.Location = new System.Drawing.Point(8, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 13);
            this.label17.TabIndex = 48;
            this.label17.Text = "Bairro.........:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Linen;
            this.label18.Location = new System.Drawing.Point(8, 14);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 13);
            this.label18.TabIndex = 47;
            this.label18.Text = "Endereço...:";
            // 
            // BairroEntText
            // 
            this.BairroEntText.BackColor = System.Drawing.Color.Linen;
            this.BairroEntText.Location = new System.Drawing.Point(78, 33);
            this.BairroEntText.Name = "BairroEntText";
            this.BairroEntText.ReadOnly = true;
            this.BairroEntText.Size = new System.Drawing.Size(156, 20);
            this.BairroEntText.TabIndex = 37;
            this.BairroEntText.TabStop = false;
            // 
            // EnderecoEntText
            // 
            this.EnderecoEntText.BackColor = System.Drawing.Color.Linen;
            this.EnderecoEntText.Location = new System.Drawing.Point(78, 10);
            this.EnderecoEntText.Name = "EnderecoEntText";
            this.EnderecoEntText.ReadOnly = true;
            this.EnderecoEntText.Size = new System.Drawing.Size(310, 20);
            this.EnderecoEntText.TabIndex = 36;
            this.EnderecoEntText.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Linen;
            this.label11.ForeColor = System.Drawing.Color.Maroon;
            this.label11.Location = new System.Drawing.Point(8, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 48;
            this.label11.Text = "Endereço de Entrega";
            // 
            // HeaderMenu
            // 
            this.HeaderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImovelMenuItem,
            this.EmpresaMenuItem,
            this.CidadaoMenuItem});
            this.HeaderMenu.Name = "HeaderMenu";
            this.HeaderMenu.Size = new System.Drawing.Size(181, 92);
            // 
            // ImovelMenuItem
            // 
            this.ImovelMenuItem.Image = global::GTI_Desktop.Properties.Resources.Home;
            this.ImovelMenuItem.Name = "ImovelMenuItem";
            this.ImovelMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ImovelMenuItem.Text = "Imóvel";
            this.ImovelMenuItem.Click += new System.EventHandler(this.ImovelMenuItem_Click);
            // 
            // EmpresaMenuItem
            // 
            this.EmpresaMenuItem.Image = global::GTI_Desktop.Properties.Resources.fabrica;
            this.EmpresaMenuItem.Name = "EmpresaMenuItem";
            this.EmpresaMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EmpresaMenuItem.Text = "Empresa";
            this.EmpresaMenuItem.Click += new System.EventHandler(this.EmpresaMenuItem_Click);
            // 
            // CidadaoMenuItem
            // 
            this.CidadaoMenuItem.Image = global::GTI_Desktop.Properties.Resources.Pessoas;
            this.CidadaoMenuItem.Name = "CidadaoMenuItem";
            this.CidadaoMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CidadaoMenuItem.Text = "Cidadão";
            this.CidadaoMenuItem.Click += new System.EventHandler(this.CidadaoMenuItem_Click);
            // 
            // Emissao_Guia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(529, 242);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.a1Panel3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.a1Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Emissao_Guia";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emissão de guia";
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.a1Panel3.ResumeLayout(false);
            this.a1Panel3.PerformLayout();
            this.HeaderMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Owf.Controls.A1Panel a1Panel2;
        private System.Windows.Forms.TextBox DocText;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox NomeText;
        private System.Windows.Forms.Button ConsultarCodigoButton;
        private System.Windows.Forms.TextBox CodigoText;
        private Owf.Controls.A1Panel a1Panel1;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InscricaoText;
        private System.Windows.Forms.TextBox BairroText;
        private System.Windows.Forms.TextBox EnderecoText;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox LoteText;
        internal System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox QuadraText;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox UFText;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox CidadeText;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox CepText;
        private Owf.Controls.A1Panel a1Panel3;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox UFEntText;
        internal System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox CidadeEntText;
        internal System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox CepEntText;
        internal System.Windows.Forms.Label label17;
        internal System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox BairroEntText;
        private System.Windows.Forms.TextBox EnderecoEntText;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.ContextMenuStrip HeaderMenu;
        private System.Windows.Forms.ToolStripMenuItem ImovelMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmpresaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CidadaoMenuItem;
    }
}