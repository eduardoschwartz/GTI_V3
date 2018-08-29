namespace GTI_Desktop.Forms {
    partial class Registro_Bancario {
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
            this.CalcularButton = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CalcularButton
            // 
            this.CalcularButton.ForeColor = System.Drawing.Color.Navy;
            this.CalcularButton.Image = global::GTI_Desktop.Properties.Resources.download;
            this.CalcularButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CalcularButton.Location = new System.Drawing.Point(340, 125);
            this.CalcularButton.Name = "CalcularButton";
            this.CalcularButton.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.CalcularButton.Size = new System.Drawing.Size(76, 24);
            this.CalcularButton.TabIndex = 38;
            this.CalcularButton.Text = "Calcular";
            this.CalcularButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CalcularButton.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(86, 97);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(70, 13);
            this.Label1.TabIndex = 39;
            this.Label1.Text = "Código de....:";
            // 
            // Registro_Bancario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 247);
            this.Controls.Add(this.CalcularButton);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Registro_Bancario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro Bancário";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CalcularButton;
        internal System.Windows.Forms.Label Label1;
    }
}