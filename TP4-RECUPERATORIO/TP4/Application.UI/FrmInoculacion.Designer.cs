namespace Application.UI
{
    partial class FrmInoculacion
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
            this.gbAditivos = new System.Windows.Forms.GroupBox();
            this.dtgAditivos = new System.Windows.Forms.DataGridView();
            this.btActualizarAditivo = new System.Windows.Forms.Button();
            this.btAgregarAditivo = new System.Windows.Forms.Button();
            this.btDeleteAditivo = new System.Windows.Forms.Button();
            this.chkEnfriado = new System.Windows.Forms.CheckBox();
            this.gbPasos = new System.Windows.Forms.GroupBox();
            this.btEnfriar = new System.Windows.Forms.Button();
            this.btMezclarAditivos = new System.Windows.Forms.Button();
            this.btCalentar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnfriamiento = new System.Windows.Forms.TextBox();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.chkMezclado = new System.Windows.Forms.CheckBox();
            this.chkCalentado = new System.Windows.Forms.CheckBox();
            this.btGenerarInforme = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.gbAditivos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAditivos)).BeginInit();
            this.gbPasos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAditivos
            // 
            this.gbAditivos.Controls.Add(this.dtgAditivos);
            this.gbAditivos.Controls.Add(this.btActualizarAditivo);
            this.gbAditivos.Controls.Add(this.btAgregarAditivo);
            this.gbAditivos.Controls.Add(this.btDeleteAditivo);
            this.gbAditivos.Location = new System.Drawing.Point(13, 98);
            this.gbAditivos.Name = "gbAditivos";
            this.gbAditivos.Size = new System.Drawing.Size(412, 199);
            this.gbAditivos.TabIndex = 34;
            this.gbAditivos.TabStop = false;
            // 
            // dtgAditivos
            // 
            this.dtgAditivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAditivos.Location = new System.Drawing.Point(6, 19);
            this.dtgAditivos.Name = "dtgAditivos";
            this.dtgAditivos.Size = new System.Drawing.Size(393, 127);
            this.dtgAditivos.TabIndex = 31;
            // 
            // btActualizarAditivo
            // 
            this.btActualizarAditivo.Location = new System.Drawing.Point(144, 157);
            this.btActualizarAditivo.Name = "btActualizarAditivo";
            this.btActualizarAditivo.Size = new System.Drawing.Size(115, 23);
            this.btActualizarAditivo.TabIndex = 32;
            this.btActualizarAditivo.Text = "Actualizar AditivoProducto";
            this.btActualizarAditivo.UseVisualStyleBackColor = true;
            this.btActualizarAditivo.Click += new System.EventHandler(this.btActualizarAditivo_Click);
            // 
            // btAgregarAditivo
            // 
            this.btAgregarAditivo.Location = new System.Drawing.Point(6, 157);
            this.btAgregarAditivo.Name = "btAgregarAditivo";
            this.btAgregarAditivo.Size = new System.Drawing.Size(115, 23);
            this.btAgregarAditivo.TabIndex = 29;
            this.btAgregarAditivo.Text = "Agregar AditivoProducto";
            this.btAgregarAditivo.UseVisualStyleBackColor = true;
            this.btAgregarAditivo.Click += new System.EventHandler(this.btAgregarAditivo_Click);
            // 
            // btDeleteAditivo
            // 
            this.btDeleteAditivo.Location = new System.Drawing.Point(284, 157);
            this.btDeleteAditivo.Name = "btDeleteAditivo";
            this.btDeleteAditivo.Size = new System.Drawing.Size(115, 23);
            this.btDeleteAditivo.TabIndex = 30;
            this.btDeleteAditivo.Text = "Delete AditivoProducto";
            this.btDeleteAditivo.UseVisualStyleBackColor = true;
            this.btDeleteAditivo.Click += new System.EventHandler(this.btDeleteAditivo_Click);
            // 
            // chkEnfriado
            // 
            this.chkEnfriado.AutoSize = true;
            this.chkEnfriado.Enabled = false;
            this.chkEnfriado.Location = new System.Drawing.Point(18, 556);
            this.chkEnfriado.Name = "chkEnfriado";
            this.chkEnfriado.Size = new System.Drawing.Size(65, 17);
            this.chkEnfriado.TabIndex = 39;
            this.chkEnfriado.Text = "Enfriado";
            this.chkEnfriado.UseVisualStyleBackColor = true;
            // 
            // gbPasos
            // 
            this.gbPasos.Controls.Add(this.btEnfriar);
            this.gbPasos.Controls.Add(this.btMezclarAditivos);
            this.gbPasos.Controls.Add(this.btCalentar);
            this.gbPasos.Controls.Add(this.label2);
            this.gbPasos.Controls.Add(this.txtEnfriamiento);
            this.gbPasos.Controls.Add(this.lblTemperatura);
            this.gbPasos.Controls.Add(this.txtTemperatura);
            this.gbPasos.Location = new System.Drawing.Point(13, 303);
            this.gbPasos.Name = "gbPasos";
            this.gbPasos.Size = new System.Drawing.Size(412, 189);
            this.gbPasos.TabIndex = 38;
            this.gbPasos.TabStop = false;
            this.gbPasos.Text = "Pasos";
            // 
            // btEnfriar
            // 
            this.btEnfriar.Location = new System.Drawing.Point(191, 148);
            this.btEnfriar.Name = "btEnfriar";
            this.btEnfriar.Size = new System.Drawing.Size(137, 23);
            this.btEnfriar.TabIndex = 10;
            this.btEnfriar.Text = "Enfriar";
            this.btEnfriar.UseVisualStyleBackColor = true;
            this.btEnfriar.Click += new System.EventHandler(this.btEnfriar_Click);
            // 
            // btMezclarAditivos
            // 
            this.btMezclarAditivos.Location = new System.Drawing.Point(82, 89);
            this.btMezclarAditivos.Name = "btMezclarAditivos";
            this.btMezclarAditivos.Size = new System.Drawing.Size(137, 23);
            this.btMezclarAditivos.TabIndex = 9;
            this.btMezclarAditivos.Text = "Incorporar Aditivos";
            this.btMezclarAditivos.UseVisualStyleBackColor = true;
            this.btMezclarAditivos.Click += new System.EventHandler(this.btMezclarAditivos_Click);
            // 
            // btCalentar
            // 
            this.btCalentar.Location = new System.Drawing.Point(190, 42);
            this.btCalentar.Name = "btCalentar";
            this.btCalentar.Size = new System.Drawing.Size(98, 23);
            this.btCalentar.TabIndex = 8;
            this.btCalentar.Text = "Calentar";
            this.btCalentar.UseVisualStyleBackColor = true;
            this.btCalentar.Click += new System.EventHandler(this.btCalentar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Temperatura enfriamiento";
            // 
            // txtEnfriamiento
            // 
            this.txtEnfriamiento.Location = new System.Drawing.Point(7, 151);
            this.txtEnfriamiento.Name = "txtEnfriamiento";
            this.txtEnfriamiento.Size = new System.Drawing.Size(137, 20);
            this.txtEnfriamiento.TabIndex = 6;
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(7, 26);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(136, 13);
            this.lblTemperatura.TabIndex = 1;
            this.lblTemperatura.Text = "Temperatura calentamiento";
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.Location = new System.Drawing.Point(6, 45);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(137, 20);
            this.txtTemperatura.TabIndex = 0;
            // 
            // chkMezclado
            // 
            this.chkMezclado.AutoSize = true;
            this.chkMezclado.Enabled = false;
            this.chkMezclado.Location = new System.Drawing.Point(18, 527);
            this.chkMezclado.Name = "chkMezclado";
            this.chkMezclado.Size = new System.Drawing.Size(117, 17);
            this.chkMezclado.TabIndex = 37;
            this.chkMezclado.Text = "Aditivos Mezclados";
            this.chkMezclado.UseVisualStyleBackColor = true;
            // 
            // chkCalentado
            // 
            this.chkCalentado.AutoSize = true;
            this.chkCalentado.Enabled = false;
            this.chkCalentado.Location = new System.Drawing.Point(19, 500);
            this.chkCalentado.Name = "chkCalentado";
            this.chkCalentado.Size = new System.Drawing.Size(74, 17);
            this.chkCalentado.TabIndex = 36;
            this.chkCalentado.Text = "Calentado";
            this.chkCalentado.UseVisualStyleBackColor = true;
            // 
            // btGenerarInforme
            // 
            this.btGenerarInforme.BackColor = System.Drawing.SystemColors.Control;
            this.btGenerarInforme.Location = new System.Drawing.Point(18, 579);
            this.btGenerarInforme.Name = "btGenerarInforme";
            this.btGenerarInforme.Size = new System.Drawing.Size(394, 41);
            this.btGenerarInforme.TabIndex = 35;
            this.btGenerarInforme.Text = "Generar Informe";
            this.btGenerarInforme.UseVisualStyleBackColor = false;
            this.btGenerarInforme.Click += new System.EventHandler(this.btGenerarInforme_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTecnico);
            this.groupBox1.Controls.Add(this.lblTecnico);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 80);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cboTecnico
            // 
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Location = new System.Drawing.Point(6, 43);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(148, 21);
            this.cboTecnico.TabIndex = 18;
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Location = new System.Drawing.Point(7, 16);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(137, 13);
            this.lblTecnico.TabIndex = 17;
            this.lblTecnico.Text = "Legajo Tecnico controlador";
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btEliminar.Location = new System.Drawing.Point(16, 673);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(394, 41);
            this.btEliminar.TabIndex = 42;
            this.btEliminar.Text = "Eliminar Informe";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btActualizar.Location = new System.Drawing.Point(18, 626);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(394, 41);
            this.btActualizar.TabIndex = 41;
            this.btActualizar.Text = "Actualizar Informe";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // FrmInoculacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 711);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkEnfriado);
            this.Controls.Add(this.gbPasos);
            this.Controls.Add(this.chkMezclado);
            this.Controls.Add(this.chkCalentado);
            this.Controls.Add(this.btGenerarInforme);
            this.Controls.Add(this.gbAditivos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInoculacion";
            this.Text = "Inoculación";
            this.gbAditivos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgAditivos)).EndInit();
            this.gbPasos.ResumeLayout(false);
            this.gbPasos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAditivos;
        private System.Windows.Forms.DataGridView dtgAditivos;
        private System.Windows.Forms.Button btActualizarAditivo;
        private System.Windows.Forms.Button btAgregarAditivo;
        private System.Windows.Forms.Button btDeleteAditivo;
        private System.Windows.Forms.CheckBox chkEnfriado;
        private System.Windows.Forms.GroupBox gbPasos;
        private System.Windows.Forms.Button btMezclarAditivos;
        private System.Windows.Forms.Button btCalentar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnfriamiento;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.CheckBox chkMezclado;
        private System.Windows.Forms.CheckBox chkCalentado;
        private System.Windows.Forms.Button btGenerarInforme;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.Button btEnfriar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btActualizar;
    }
}