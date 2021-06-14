namespace Application.UI
{
    partial class FrmUpdateLacteo
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
            this.btAgregarAditivo = new System.Windows.Forms.Button();
            this.btDeleteAditivo = new System.Windows.Forms.Button();
            this.btActualizaLacteo = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.dtgAditivos = new System.Windows.Forms.DataGridView();
            this.cbEnfriado = new System.Windows.Forms.CheckBox();
            this.cbPasteurizado = new System.Windows.Forms.CheckBox();
            this.cbEstandarizado = new System.Windows.Forms.CheckBox();
            this.cbMP = new System.Windows.Forms.CheckBox();
            this.btActualizarAditivo = new System.Windows.Forms.Button();
            this.lblAditivos = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.txtIdOlla = new System.Windows.Forms.TextBox();
            this.cmbMetodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAditivos)).BeginInit();
            this.SuspendLayout();
            // 
            // btAgregarAditivo
            // 
            this.btAgregarAditivo.Location = new System.Drawing.Point(12, 158);
            this.btAgregarAditivo.Name = "btAgregarAditivo";
            this.btAgregarAditivo.Size = new System.Drawing.Size(115, 23);
            this.btAgregarAditivo.TabIndex = 17;
            this.btAgregarAditivo.Text = "Agregar AditivoProducto";
            this.btAgregarAditivo.UseVisualStyleBackColor = true;
            this.btAgregarAditivo.Click += new System.EventHandler(this.btAgregarAditivo_Click);
            // 
            // btDeleteAditivo
            // 
            this.btDeleteAditivo.Location = new System.Drawing.Point(290, 158);
            this.btDeleteAditivo.Name = "btDeleteAditivo";
            this.btDeleteAditivo.Size = new System.Drawing.Size(115, 23);
            this.btDeleteAditivo.TabIndex = 18;
            this.btDeleteAditivo.Text = "Delete AditivoProducto";
            this.btDeleteAditivo.UseVisualStyleBackColor = true;
            this.btDeleteAditivo.Click += new System.EventHandler(this.btDeleteAditivo_Click);
            // 
            // btActualizaLacteo
            // 
            this.btActualizaLacteo.Location = new System.Drawing.Point(12, 432);
            this.btActualizaLacteo.Name = "btActualizaLacteo";
            this.btActualizaLacteo.Size = new System.Drawing.Size(115, 23);
            this.btActualizaLacteo.TabIndex = 20;
            this.btActualizaLacteo.Text = "Actualizar";
            this.btActualizaLacteo.UseVisualStyleBackColor = true;
            this.btActualizaLacteo.Click += new System.EventHandler(this.btActualizaLacteo_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(281, 432);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(115, 23);
            this.btCancelar.TabIndex = 21;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // dtgAditivos
            // 
            this.dtgAditivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAditivos.Location = new System.Drawing.Point(12, 20);
            this.dtgAditivos.Name = "dtgAditivos";
            this.dtgAditivos.Size = new System.Drawing.Size(393, 127);
            this.dtgAditivos.TabIndex = 22;
            // 
            // cbEnfriado
            // 
            this.cbEnfriado.AutoSize = true;
            this.cbEnfriado.Location = new System.Drawing.Point(15, 409);
            this.cbEnfriado.Name = "cbEnfriado";
            this.cbEnfriado.Size = new System.Drawing.Size(56, 17);
            this.cbEnfriado.TabIndex = 26;
            this.cbEnfriado.Text = "Enfriar";
            this.cbEnfriado.UseVisualStyleBackColor = true;
            // 
            // cbPasteurizado
            // 
            this.cbPasteurizado.AutoSize = true;
            this.cbPasteurizado.Location = new System.Drawing.Point(15, 376);
            this.cbPasteurizado.Name = "cbPasteurizado";
            this.cbPasteurizado.Size = new System.Drawing.Size(78, 17);
            this.cbPasteurizado.TabIndex = 25;
            this.cbPasteurizado.Text = "Pasteurizar";
            this.cbPasteurizado.UseVisualStyleBackColor = true;
            // 
            // cbEstandarizado
            // 
            this.cbEstandarizado.AutoSize = true;
            this.cbEstandarizado.Location = new System.Drawing.Point(15, 342);
            this.cbEstandarizado.Name = "cbEstandarizado";
            this.cbEstandarizado.Size = new System.Drawing.Size(96, 17);
            this.cbEstandarizado.TabIndex = 24;
            this.cbEstandarizado.Text = "Estandarizadar";
            this.cbEstandarizado.UseVisualStyleBackColor = true;
            // 
            // cbMP
            // 
            this.cbMP.AutoSize = true;
            this.cbMP.Location = new System.Drawing.Point(15, 309);
            this.cbMP.Name = "cbMP";
            this.cbMP.Size = new System.Drawing.Size(131, 17);
            this.cbMP.TabIndex = 23;
            this.cbMP.Text = "Ingresar Materia Prima";
            this.cbMP.UseVisualStyleBackColor = true;
            // 
            // btActualizarAditivo
            // 
            this.btActualizarAditivo.Location = new System.Drawing.Point(150, 158);
            this.btActualizarAditivo.Name = "btActualizarAditivo";
            this.btActualizarAditivo.Size = new System.Drawing.Size(115, 23);
            this.btActualizarAditivo.TabIndex = 28;
            this.btActualizarAditivo.Text = "Actualizar AditivoProducto";
            this.btActualizarAditivo.UseVisualStyleBackColor = true;
            this.btActualizarAditivo.Click += new System.EventHandler(this.btActualizarAditivo_Click);
            // 
            // lblAditivos
            // 
            this.lblAditivos.AutoSize = true;
            this.lblAditivos.Location = new System.Drawing.Point(12, 4);
            this.lblAditivos.Name = "lblAditivos";
            this.lblAditivos.Size = new System.Drawing.Size(44, 13);
            this.lblAditivos.TabIndex = 29;
            this.lblAditivos.Text = "Aditivos";
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Items.AddRange(new object[] {
            "Yogurt",
            "Leche"});
            this.cmbTipo.Location = new System.Drawing.Point(53, 235);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 30;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.cmbTipo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Id olla Presurizacion";
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Location = new System.Drawing.Point(164, 192);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(109, 13);
            this.lblMetodo.TabIndex = 33;
            this.lblMetodo.Text = "Metodo Presurizacion";
            // 
            // txtIdOlla
            // 
            this.txtIdOlla.Location = new System.Drawing.Point(15, 209);
            this.txtIdOlla.Name = "txtIdOlla";
            this.txtIdOlla.Size = new System.Drawing.Size(100, 20);
            this.txtIdOlla.TabIndex = 34;
            // 
            // cmbMetodo
            // 
            this.cmbMetodo.FormattingEnabled = true;
            this.cmbMetodo.Items.AddRange(new object[] {
            "Baja temperatura",
            "Alta temperatura"});
            this.cmbMetodo.Location = new System.Drawing.Point(161, 208);
            this.cmbMetodo.Name = "cmbMetodo";
            this.cmbMetodo.Size = new System.Drawing.Size(121, 21);
            this.cmbMetodo.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Indique las etapas de fabricacion a realizar:";
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(150, 432);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(115, 23);
            this.btEliminar.TabIndex = 37;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // FrmUpdateLacteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 465);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbMetodo);
            this.Controls.Add(this.txtIdOlla);
            this.Controls.Add(this.lblMetodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.lblAditivos);
            this.Controls.Add(this.btActualizarAditivo);
            this.Controls.Add(this.cbEnfriado);
            this.Controls.Add(this.cbPasteurizado);
            this.Controls.Add(this.cbEstandarizado);
            this.Controls.Add(this.cbMP);
            this.Controls.Add(this.dtgAditivos);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btActualizaLacteo);
            this.Controls.Add(this.btDeleteAditivo);
            this.Controls.Add(this.btAgregarAditivo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdateLacteo";
            this.Text = "FrmUpdateLacteo";
            this.Load += new System.EventHandler(this.FrmUpdateLacteo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAditivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAgregarAditivo;
        private System.Windows.Forms.Button btDeleteAditivo;
        private System.Windows.Forms.Button btActualizaLacteo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.DataGridView dtgAditivos;
        private System.Windows.Forms.CheckBox cbEnfriado;
        private System.Windows.Forms.CheckBox cbPasteurizado;
        private System.Windows.Forms.CheckBox cbEstandarizado;
        private System.Windows.Forms.CheckBox cbMP;
        private System.Windows.Forms.Button btActualizarAditivo;
        private System.Windows.Forms.Label lblAditivos;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.TextBox txtIdOlla;
        private System.Windows.Forms.ComboBox cmbMetodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btEliminar;
    }
}