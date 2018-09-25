namespace GTI_Desktop.Forms {
    partial class Calculo_Imposto {
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
            this.label1 = new System.Windows.Forms.Label();
            this.ImpostoList = new System.Windows.Forms.ComboBox();
            this.PBar = new System.Windows.Forms.ProgressBar();
            this.ExecutarButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.MsgToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.ExportarButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Cálculo..:";
            // 
            // ImpostoList
            // 
            this.ImpostoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImpostoList.FormattingEnabled = true;
            this.ImpostoList.Items.AddRange(new object[] {
            "CÁLCULO DE IPTU",
            "CÁLCULO DE ISS FIXO/TLL",
            "CÁLCULO DE VIGILÂNCIA SANITÁRIA"});
            this.ImpostoList.Location = new System.Drawing.Point(108, 20);
            this.ImpostoList.Name = "ImpostoList";
            this.ImpostoList.Size = new System.Drawing.Size(243, 21);
            this.ImpostoList.TabIndex = 1;
            // 
            // PBar
            // 
            this.PBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.PBar.Location = new System.Drawing.Point(15, 71);
            this.PBar.Name = "PBar";
            this.PBar.Size = new System.Drawing.Size(157, 9);
            this.PBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PBar.TabIndex = 3;
            // 
            // ExecutarButton
            // 
            this.ExecutarButton.Image = global::GTI_Desktop.Properties.Resources.executar;
            this.ExecutarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExecutarButton.Location = new System.Drawing.Point(195, 57);
            this.ExecutarButton.Name = "ExecutarButton";
            this.ExecutarButton.Size = new System.Drawing.Size(75, 23);
            this.ExecutarButton.TabIndex = 2;
            this.ExecutarButton.Text = "Calcular";
            this.ExecutarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExecutarButton.UseVisualStyleBackColor = true;
            this.ExecutarButton.Click += new System.EventHandler(this.ExecutarButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsgToolStrip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 112);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(371, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // MsgToolStrip
            // 
            this.MsgToolStrip.Name = "MsgToolStrip";
            this.MsgToolStrip.Size = new System.Drawing.Size(177, 17);
            this.MsgToolStrip.Text = "Selecione uma opção de cálculo";
            // 
            // ExportarButton
            // 
            this.ExportarButton.Image = global::GTI_Desktop.Properties.Resources.enviar;
            this.ExportarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExportarButton.Location = new System.Drawing.Point(276, 57);
            this.ExportarButton.Name = "ExportarButton";
            this.ExportarButton.Size = new System.Drawing.Size(75, 23);
            this.ExportarButton.TabIndex = 5;
            this.ExportarButton.Text = "Exportar";
            this.ExportarButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExportarButton.UseVisualStyleBackColor = true;
            this.ExportarButton.Click += new System.EventHandler(this.ExportarButton_Click);
            // 
            // Calculo_Imposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 134);
            this.Controls.Add(this.ExportarButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PBar);
            this.Controls.Add(this.ExecutarButton);
            this.Controls.Add(this.ImpostoList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Calculo_Imposto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculo de Imposto";
            this.Load += new System.EventHandler(this.Calculo_Imposto_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ImpostoList;
        private System.Windows.Forms.Button ExecutarButton;
        private System.Windows.Forms.ProgressBar PBar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel MsgToolStrip;
        private System.Windows.Forms.Button ExportarButton;
    }
}