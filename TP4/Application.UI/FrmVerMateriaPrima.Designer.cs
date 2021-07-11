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
            this.btSerializar = new System.Windows.Forms.Button();
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
            // btSerializar
            // 
            this.btSerializar.Location = new System.Drawing.Point(210, 241);
            this.btSerializar.Name = "btSerializar";
            this.btSerializar.Size = new System.Drawing.Size(123, 35);
            this.btSerializar.TabIndex = 1;
            this.btSerializar.Text = "Generar Serializacion";
            this.btSerializar.UseVisualStyleBackColor = true;
            this.btSerializar.Click += new System.EventHandler(this.btSerializar_Click);
            // 
            // FrmVerMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 319);
            this.Controls.Add(this.btSerializar);
            this.Controls.Add(this.dgMateriaPrima);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVerMateriaPrima";
            this.Text = "Materia Prima";
            ((System.ComponentModel.ISupportInitialize)(this.dgMateriaPrima)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgMateriaPrima;
        private System.Windows.Forms.Button btSerializar;
    }
}