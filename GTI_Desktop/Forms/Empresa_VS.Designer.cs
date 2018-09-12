namespace GTI_Desktop.Forms {
    partial class Empresa_VS {
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
            this.CnaeToolStrip = new System.Windows.Forms.ToolStrip();
            this.OkButton = new System.Windows.Forms.ToolStripButton();
            this.CancelButton = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.CnaeList = new System.Windows.Forms.ComboBox();
            this.CnaeToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CnaeToolStrip
            // 
            this.CnaeToolStrip.AllowMerge = false;
            this.CnaeToolStrip.BackColor = System.Drawing.Color.Transparent;
            this.CnaeToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CnaeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.CnaeToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OkButton,
            this.CancelButton});
            this.CnaeToolStrip.Location = new System.Drawing.Point(0, 228);
            this.CnaeToolStrip.Name = "CnaeToolStrip";
            this.CnaeToolStrip.Padding = new System.Windows.Forms.Padding(6, 0, 1, 0);
            this.CnaeToolStrip.Size = new System.Drawing.Size(498, 25);
            this.CnaeToolStrip.TabIndex = 28;
            this.CnaeToolStrip.Text = "toolStrip1";
            // 
            // OkButton
            // 
            this.OkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OkButton.Image = global::GTI_Desktop.Properties.Resources.OK;
            this.OkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(23, 22);
            this.OkButton.Text = "toolStripButton1";
            this.OkButton.ToolTipText = "Adicionar Cnae";
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CancelButton.Image = global::GTI_Desktop.Properties.Resources.cancel2;
            this.CancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(23, 22);
            this.CancelButton.Text = "toolStripButton3";
            this.CancelButton.ToolTipText = "Remover Cnae";
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Cnae..:";
            // 
            // CnaeList
            // 
            this.CnaeList.DropDownWidth = 550;
            this.CnaeList.FormattingEnabled = true;
            this.CnaeList.Location = new System.Drawing.Point(59, 16);
            this.CnaeList.Name = "CnaeList";
            this.CnaeList.Size = new System.Drawing.Size(427, 21);
            this.CnaeList.TabIndex = 30;
            // 
            // Empresa_VS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 253);
            this.ControlBox = false;
            this.Controls.Add(this.CnaeList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CnaeToolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Empresa_VS";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro das Cnaes para vigilância sanitária";
            this.CnaeToolStrip.ResumeLayout(false);
            this.CnaeToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip CnaeToolStrip;
        private System.Windows.Forms.ToolStripButton OkButton;
        private System.Windows.Forms.ToolStripButton CancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CnaeList;
    }
}