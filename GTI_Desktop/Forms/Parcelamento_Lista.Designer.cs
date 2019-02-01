namespace GTI_Desktop.Forms {
    partial class Parcelamento_Lista {
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
            this.ProcessoList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº do processo..:";
            // 
            // ProcessoList
            // 
            this.ProcessoList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProcessoList.FormattingEnabled = true;
            this.ProcessoList.Location = new System.Drawing.Point(107, 11);
            this.ProcessoList.Name = "ProcessoList";
            this.ProcessoList.Size = new System.Drawing.Size(104, 21);
            this.ProcessoList.TabIndex = 1;
            this.ProcessoList.SelectedIndexChanged += new System.EventHandler(this.ProcessoList_SelectedIndexChanged);
            // 
            // Parcelamento_Lista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 381);
            this.Controls.Add(this.ProcessoList);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Parcelamento_Lista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista de Parcelamentos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProcessoList;
    }
}