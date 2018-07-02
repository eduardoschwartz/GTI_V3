namespace GTI_Desktop.Forms {
    partial class Certidao {
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
            this.pGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // pGrid
            // 
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.HelpVisible = false;
            this.pGrid.Location = new System.Drawing.Point(0, 0);
            this.pGrid.Name = "pGrid";
            this.pGrid.Size = new System.Drawing.Size(357, 347);
            this.pGrid.TabIndex = 2;
            // 
            // Certidao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 347);
            this.Controls.Add(this.pGrid);
            this.MaximizeBox = false;
            this.Name = "Certidao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emissão de Certidões";
            this.Load += new System.EventHandler(this.Certidao_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PropertyGrid pGrid;
    }
}