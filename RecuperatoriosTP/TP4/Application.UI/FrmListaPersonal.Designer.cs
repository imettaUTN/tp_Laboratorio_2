namespace Application.UI
{
    partial class FrmListaPersonal
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
            this.dgPersonal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPersonal
            // 
            this.dgPersonal.AllowUserToAddRows = false;
            this.dgPersonal.AllowUserToDeleteRows = false;
            this.dgPersonal.AllowUserToOrderColumns = true;
            this.dgPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonal.Location = new System.Drawing.Point(12, 12);
            this.dgPersonal.Name = "dgPersonal";
            this.dgPersonal.Size = new System.Drawing.Size(738, 233);
            this.dgPersonal.TabIndex = 1;
            // 
            // FrmListaPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 255);
            this.Controls.Add(this.dgPersonal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListaPersonal";
            this.Text = "Lista Personal";
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPersonal;
    }
}