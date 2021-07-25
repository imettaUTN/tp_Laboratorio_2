namespace Application.UI
{
    partial class FrmVerMateriaPrima
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgMateriaPrima = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriaPrima)).BeginInit();
            this.SuspendLayout();
            // 
            // dgMateriaPrima
            // 
            this.dgMateriaPrima.AllowUserToAddRows = false;
            this.dgMateriaPrima.AllowUserToDeleteRows = false;
            this.dgMateriaPrima.AllowUserToOrderColumns = true;
            this.dgMateriaPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMateriaPrima.Location = new System.Drawing.Point(13, 22);
            this.dgMateriaPrima.Name = "dgMateriaPrima";
            this.dgMateriaPrima.Size = new System.Drawing.Size(738, 203);
            this.dgMateriaPrima.TabIndex = 0;
            // 
            // FrmVerMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 240);
            this.Controls.Add(this.dgMateriaPrima);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerMateriaPrima";
            this.Text = "Lista Materia Prima";
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriaPrima)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMateriaPrima;
    }
}