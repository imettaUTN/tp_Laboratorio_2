namespace Application.UI
{
    partial class FrmUpdateAditivo
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
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.cboDescripcion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(107, 49);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(261, 20);
            this.txtCantidad.TabIndex = 0;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(33, 49);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(33, 119);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // cbTipo
            // 
            this.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Items.AddRange(new object[] {
            "Espesante",
            "Potenciador del sabor",
            "Colorante"});
            this.cbTipo.Location = new System.Drawing.Point(107, 190);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(260, 21);
            this.cbTipo.TabIndex = 5;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(33, 198);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 6;
            this.lblTipo.Text = "Tipo";
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(36, 234);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(139, 23);
            this.btActualizar.TabIndex = 7;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(228, 234);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(139, 23);
            this.btEliminar.TabIndex = 8;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // cboDescripcion
            // 
            this.cboDescripcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescripcion.FormattingEnabled = true;
            this.cboDescripcion.Location = new System.Drawing.Point(107, 119);
            this.cboDescripcion.Name = "cboDescripcion";
            this.cboDescripcion.Size = new System.Drawing.Size(260, 21);
            this.cboDescripcion.TabIndex = 9;
            // 
            // FrmUpdateAditivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 289);
            this.Controls.Add(this.cboDescripcion);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cbTipo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCantidad);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateAditivo";
            this.Text = "Actualizar Aditivo";
            this.Load += new System.EventHandler(this.FrmUpdateAditivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox txtCantidad;
        protected System.Windows.Forms.Label lblCantidad;
        protected System.Windows.Forms.Label lblDescripcion;
        protected System.Windows.Forms.ComboBox cbTipo;
        protected System.Windows.Forms.Label lblTipo;
        protected System.Windows.Forms.Button btActualizar;
        protected System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.ComboBox cboDescripcion;
    }
}