namespace GTI_Desktop.Forms {
    partial class Cnae {
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
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.SelectButton = new System.Windows.Forms.Button();
            this.Busca = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.a1Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainListView
            // 
            this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(3, 50);
            this.MainListView.MultiSelect = false;
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(602, 330);
            this.MainListView.TabIndex = 2;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "CNAE";
            this.columnHeader1.Width = 81;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Descrição";
            this.columnHeader2.Width = 490;
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.CancelButton);
            this.a1Panel1.Controls.Add(this.SelectButton);
            this.a1Panel1.Controls.Add(this.Busca);
            this.a1Panel1.Controls.Add(this.label1);
            this.a1Panel1.GradientEndColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.GradientStartColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(3, 3);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 7;
            this.a1Panel1.ShadowOffSet = 3;
            this.a1Panel1.Size = new System.Drawing.Size(605, 45);
            this.a1Panel1.TabIndex = 0;
            // 
            // SelectButton
            // 
            this.SelectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SelectButton.Image = global::GTI_Desktop.Properties.Resources.Consultar;
            this.SelectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectButton.Location = new System.Drawing.Point(383, 8);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.SelectButton.Size = new System.Drawing.Size(86, 24);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Selecionar";
            this.SelectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // Busca
            // 
            this.Busca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Busca.Location = new System.Drawing.Point(86, 10);
            this.Busca.Name = "Busca";
            this.Busca.Size = new System.Drawing.Size(291, 20);
            this.Busca.TabIndex = 0;
            this.Busca.TextChanged += new System.EventHandler(this.Busca_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pesquisa..:";
            // 
            // CancelButton
            // 
            this.CancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CancelButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(475, 8);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.CancelButton.Size = new System.Drawing.Size(86, 24);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancelar";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Cnae
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 382);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.MainListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Cnae";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lista dos Cnaes cadastardos";
            this.Load += new System.EventHandler(this.Cnae_Load);
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private Owf.Controls.A1Panel a1Panel1;
        private System.Windows.Forms.TextBox Busca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button CancelButton;
    }
}