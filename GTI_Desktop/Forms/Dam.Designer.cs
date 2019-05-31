namespace GTI_Desktop.Forms {
    partial class Dam {
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
            this.tBar = new System.Windows.Forms.ToolStrip();
            this.OKButton = new System.Windows.Forms.ToolStripButton();
            this.SairButton = new System.Windows.Forms.ToolStripButton();
            this.a1Panel1 = new Owf.Controls.A1Panel();
            this.a1Panel2 = new Owf.Controls.A1Panel();
            this.MainListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tBar.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            this.a1Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tBar
            // 
            this.tBar.AllowMerge = false;
            this.tBar.BackColor = System.Drawing.Color.LemonChiffon;
            this.tBar.Dock = System.Windows.Forms.DockStyle.None;
            this.tBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OKButton,
            this.SairButton});
            this.tBar.Location = new System.Drawing.Point(84, 381);
            this.tBar.Name = "tBar";
            this.tBar.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.tBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tBar.Size = new System.Drawing.Size(55, 25);
            this.tBar.TabIndex = 4;
            this.tBar.Text = "toolStrip1";
            // 
            // OKButton
            // 
            this.OKButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OKButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.OKButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(23, 22);
            this.OKButton.Text = "toolStripButton2";
            this.OKButton.ToolTipText = "Escrever os débitos selecionados em divida ativa";
            // 
            // SairButton
            // 
            this.SairButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SairButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.SairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SairButton.Name = "SairButton";
            this.SairButton.Size = new System.Drawing.Size(23, 22);
            this.SairButton.Text = "toolStripButton1";
            this.SairButton.ToolTipText = "Fechar a tela";
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.tBar);
            this.a1Panel1.GradientEndColor = System.Drawing.Color.LemonChiffon;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(574, 4);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.Size = new System.Drawing.Size(157, 413);
            this.a1Panel1.TabIndex = 5;
            // 
            // a1Panel2
            // 
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.MainListView);
            this.a1Panel2.GradientEndColor = System.Drawing.Color.LemonChiffon;
            this.a1Panel2.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(4, 4);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.Size = new System.Drawing.Size(570, 413);
            this.a1Panel2.TabIndex = 6;
            // 
            // MainListView
            // 
            this.MainListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainListView.BackColor = System.Drawing.Color.White;
            this.MainListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.MainListView.FullRowSelect = true;
            this.MainListView.Location = new System.Drawing.Point(3, 3);
            this.MainListView.Name = "MainListView";
            this.MainListView.Size = new System.Drawing.Size(558, 400);
            this.MainListView.TabIndex = 4;
            this.MainListView.UseCompatibleStateImageBehavior = false;
            this.MainListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ano";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Lc";
            this.columnHeader2.Width = 27;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sq";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pc";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 30;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Cp";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 27;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Dt.Vencto";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 72;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Principal";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Multa";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Juros";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Correção";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Total";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Dam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(733, 417);
            this.Controls.Add(this.a1Panel1);
            this.Controls.Add(this.a1Panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Documento de Arrecadação Municipal (D.A.M.)";
            this.tBar.ResumeLayout(false);
            this.tBar.PerformLayout();
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.a1Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tBar;
        private System.Windows.Forms.ToolStripButton OKButton;
        private System.Windows.Forms.ToolStripButton SairButton;
        private Owf.Controls.A1Panel a1Panel1;
        private Owf.Controls.A1Panel a1Panel2;
        private System.Windows.Forms.ListView MainListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
    }
}