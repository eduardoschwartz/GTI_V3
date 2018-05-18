namespace GTI_Desktop.Forms {
    partial class Endereco {
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
            this.cmbUF = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCidade = new System.Windows.Forms.ComboBox();
            this.cmbBairro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPais = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btPais_Refresh = new System.Windows.Forms.Button();
            this.btBairro_Refresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btReturn = new System.Windows.Forms.Button();
            this.mskCep = new System.Windows.Forms.MaskedTextBox();
            this.txtLogradouro = new System.Windows.Forms.TextBox();
            this.lstLogr = new System.Windows.Forms.ComboBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbUF
            // 
            this.cmbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUF.FormattingEnabled = true;
            this.cmbUF.Location = new System.Drawing.Point(287, 18);
            this.cmbUF.Name = "cmbUF";
            this.cmbUF.Size = new System.Drawing.Size(163, 21);
            this.cmbUF.TabIndex = 1;
            this.cmbUF.SelectedIndexChanged += new System.EventHandler(this.CmbUF_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Estado.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cidade.:";
            // 
            // cmbCidade
            // 
            this.cmbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCidade.FormattingEnabled = true;
            this.cmbCidade.Location = new System.Drawing.Point(52, 46);
            this.cmbCidade.Name = "cmbCidade";
            this.cmbCidade.Size = new System.Drawing.Size(157, 21);
            this.cmbCidade.TabIndex = 2;
            this.cmbCidade.SelectedIndexChanged += new System.EventHandler(this.CmbCidade_SelectedIndexChanged);
            // 
            // cmbBairro
            // 
            this.cmbBairro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBairro.FormattingEnabled = true;
            this.cmbBairro.Location = new System.Drawing.Point(264, 47);
            this.cmbBairro.Name = "cmbBairro";
            this.cmbBairro.Size = new System.Drawing.Size(162, 21);
            this.cmbBairro.TabIndex = 3;
            this.cmbBairro.SelectedIndexChanged += new System.EventHandler(this.CmbBairro_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(217, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bairro...:";
            // 
            // cmbPais
            // 
            this.cmbPais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPais.FormattingEnabled = true;
            this.cmbPais.Location = new System.Drawing.Point(52, 17);
            this.cmbPais.Name = "cmbPais";
            this.cmbPais.Size = new System.Drawing.Size(157, 21);
            this.cmbPais.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "País.....:";
            // 
            // btPais_Refresh
            // 
            this.btPais_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btPais_Refresh.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.btPais_Refresh.Location = new System.Drawing.Point(209, 15);
            this.btPais_Refresh.Name = "btPais_Refresh";
            this.btPais_Refresh.Size = new System.Drawing.Size(25, 25);
            this.btPais_Refresh.TabIndex = 7;
            this.btPais_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPais_Refresh.UseVisualStyleBackColor = true;
            this.btPais_Refresh.Click += new System.EventHandler(this.BtPais_Refresh_Click);
            // 
            // btBairro_Refresh
            // 
            this.btBairro_Refresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btBairro_Refresh.Image = global::GTI_Desktop.Properties.Resources.Alterar;
            this.btBairro_Refresh.Location = new System.Drawing.Point(426, 45);
            this.btBairro_Refresh.Name = "btBairro_Refresh";
            this.btBairro_Refresh.Size = new System.Drawing.Size(25, 25);
            this.btBairro_Refresh.TabIndex = 10;
            this.btBairro_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btBairro_Refresh.UseVisualStyleBackColor = true;
            this.btBairro_Refresh.Click += new System.EventHandler(this.BtBairro_Refresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Logradouro....:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(368, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nº..:";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(396, 76);
            this.txtNum.MaxLength = 4;
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(54, 20);
            this.txtNum.TabIndex = 5;
            this.txtNum.TextChanged += new System.EventHandler(this.TxtNum_TextChanged);
            this.txtNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNum_KeyDown);
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(82, 102);
            this.txtComplemento.MaxLength = 50;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(163, 20);
            this.txtComplemento.TabIndex = 6;
            this.txtComplemento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtComplemento_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Complemento.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "CEP..:";
            // 
            // btReturn
            // 
            this.btReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btReturn.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.btReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btReturn.Location = new System.Drawing.Point(385, 122);
            this.btReturn.Name = "btReturn";
            this.btReturn.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btReturn.Size = new System.Drawing.Size(32, 25);
            this.btReturn.TabIndex = 9;
            this.btReturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btReturn, "Retornar o endereço");
            this.btReturn.UseVisualStyleBackColor = true;
            this.btReturn.Click += new System.EventHandler(this.BtReturn_Click);
            // 
            // mskCep
            // 
            this.mskCep.Location = new System.Drawing.Point(294, 102);
            this.mskCep.Mask = "99999-999";
            this.mskCep.Name = "mskCep";
            this.mskCep.Size = new System.Drawing.Size(68, 20);
            this.mskCep.TabIndex = 7;
            this.mskCep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MskCep_KeyDown);
            // 
            // txtLogradouro
            // 
            this.txtLogradouro.Location = new System.Drawing.Point(82, 76);
            this.txtLogradouro.MaxLength = 50;
            this.txtLogradouro.Name = "txtLogradouro";
            this.txtLogradouro.Size = new System.Drawing.Size(280, 20);
            this.txtLogradouro.TabIndex = 4;
            this.txtLogradouro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLogradouro_KeyDown);
            // 
            // lstLogr
            // 
            this.lstLogr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstLogr.FormattingEnabled = true;
            this.lstLogr.Location = new System.Drawing.Point(82, 76);
            this.lstLogr.Name = "lstLogr";
            this.lstLogr.Size = new System.Drawing.Size(280, 21);
            this.lstLogr.TabIndex = 21;
            this.lstLogr.TabStop = false;
            this.lstLogr.Visible = false;
            this.lstLogr.TextChanged += new System.EventHandler(this.LstLogr_TextChanged);
            this.lstLogr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstLogr_KeyDown);
            this.lstLogr.Leave += new System.EventHandler(this.LstLogr_Leave);
            // 
            // btCancel
            // 
            this.btCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancel.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.btCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancel.Location = new System.Drawing.Point(418, 122);
            this.btCancel.Name = "btCancel";
            this.btCancel.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btCancel.Size = new System.Drawing.Size(32, 25);
            this.btCancel.TabIndex = 10;
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btCancel, "Cancelar operação");
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.BtCancel_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(82, 126);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "E-mail............:";
            // 
            // Endereco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(457, 153);
            this.ControlBox = false;
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.lstLogr);
            this.Controls.Add(this.mskCep);
            this.Controls.Add(this.btReturn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtComplemento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLogradouro);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btBairro_Refresh);
            this.Controls.Add(this.btPais_Refresh);
            this.Controls.Add(this.cmbPais);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbBairro);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Endereco";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de endereço";
            this.Load += new System.EventHandler(this.Endereco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCidade;
        private System.Windows.Forms.ComboBox cmbBairro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPais;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPais_Refresh;
        private System.Windows.Forms.Button btBairro_Refresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btReturn;
        private System.Windows.Forms.MaskedTextBox mskCep;
        private System.Windows.Forms.TextBox txtLogradouro;
        private System.Windows.Forms.ComboBox lstLogr;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label9;
    }
}