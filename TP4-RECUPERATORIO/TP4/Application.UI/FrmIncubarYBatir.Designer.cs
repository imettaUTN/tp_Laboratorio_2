namespace Application.UI
{
    partial class FrmIncubarYBatir
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
            this.gbPasos = new System.Windows.Forms.GroupBox();
            this.btInocular = new System.Windows.Forms.Button();
            this.lblHidrogeno = new System.Windows.Forms.Label();
            this.txtHidrogeno = new System.Windows.Forms.TextBox();
            this.txtAcidez = new System.Windows.Forms.TextBox();
            this.lblNivelAcidez = new System.Windows.Forms.Label();
            this.lblPH = new System.Windows.Forms.Label();
            this.txtPH = new System.Windows.Forms.TextBox();
            this.txtTiempoCalentamiento = new System.Windows.Forms.TextBox();
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblTemperaturaMezclado = new System.Windows.Forms.Label();
            this.txtTempMezclado = new System.Windows.Forms.TextBox();
            this.btMezclar = new System.Windows.Forms.Button();
            this.btCalentar = new System.Windows.Forms.Button();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.txtTemperaturaCalentamiento = new System.Windows.Forms.TextBox();
            this.chkInoculado = new System.Windows.Forms.CheckBox();
            this.btGenerarInforme = new System.Windows.Forms.Button();
            this.chkMezclar = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.lblTanqueIncubacion = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.txtTanqueIncubacion = new System.Windows.Forms.TextBox();
            this.chkCalentado = new System.Windows.Forms.CheckBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.gbPasos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPasos
            // 
            this.gbPasos.Controls.Add(this.btInocular);
            this.gbPasos.Controls.Add(this.lblHidrogeno);
            this.gbPasos.Controls.Add(this.txtHidrogeno);
            this.gbPasos.Controls.Add(this.txtAcidez);
            this.gbPasos.Controls.Add(this.lblNivelAcidez);
            this.gbPasos.Controls.Add(this.lblPH);
            this.gbPasos.Controls.Add(this.txtPH);
            this.gbPasos.Controls.Add(this.txtTiempoCalentamiento);
            this.gbPasos.Controls.Add(this.lblTiempo);
            this.gbPasos.Controls.Add(this.lblTemperaturaMezclado);
            this.gbPasos.Controls.Add(this.txtTempMezclado);
            this.gbPasos.Controls.Add(this.btMezclar);
            this.gbPasos.Controls.Add(this.btCalentar);
            this.gbPasos.Controls.Add(this.lblTemperatura);
            this.gbPasos.Controls.Add(this.txtTemperaturaCalentamiento);
            this.gbPasos.Location = new System.Drawing.Point(13, 158);
            this.gbPasos.Name = "gbPasos";
            this.gbPasos.Size = new System.Drawing.Size(338, 303);
            this.gbPasos.TabIndex = 23;
            this.gbPasos.TabStop = false;
            this.gbPasos.Text = "Pasos";
            // 
            // btInocular
            // 
            this.btInocular.Location = new System.Drawing.Point(186, 165);
            this.btInocular.Name = "btInocular";
            this.btInocular.Size = new System.Drawing.Size(134, 36);
            this.btInocular.TabIndex = 44;
            this.btInocular.Text = "Inocular";
            this.btInocular.UseVisualStyleBackColor = true;
            this.btInocular.Click += new System.EventHandler(this.btInocular_Click);
            // 
            // lblHidrogeno
            // 
            this.lblHidrogeno.AutoSize = true;
            this.lblHidrogeno.Location = new System.Drawing.Point(91, 136);
            this.lblHidrogeno.Name = "lblHidrogeno";
            this.lblHidrogeno.Size = new System.Drawing.Size(67, 13);
            this.lblHidrogeno.TabIndex = 43;
            this.lblHidrogeno.Text = "% Hidrogeno";
            // 
            // txtHidrogeno
            // 
            this.txtHidrogeno.Location = new System.Drawing.Point(94, 152);
            this.txtHidrogeno.Name = "txtHidrogeno";
            this.txtHidrogeno.Size = new System.Drawing.Size(65, 20);
            this.txtHidrogeno.TabIndex = 42;
            // 
            // txtAcidez
            // 
            this.txtAcidez.Location = new System.Drawing.Point(6, 204);
            this.txtAcidez.Name = "txtAcidez";
            this.txtAcidez.Size = new System.Drawing.Size(152, 20);
            this.txtAcidez.TabIndex = 41;
            // 
            // lblNivelAcidez
            // 
            this.lblNivelAcidez.AutoSize = true;
            this.lblNivelAcidez.Location = new System.Drawing.Point(7, 188);
            this.lblNivelAcidez.Name = "lblNivelAcidez";
            this.lblNivelAcidez.Size = new System.Drawing.Size(53, 13);
            this.lblNivelAcidez.TabIndex = 40;
            this.lblNivelAcidez.Text = "% Acidez ";
            // 
            // lblPH
            // 
            this.lblPH.AutoSize = true;
            this.lblPH.Location = new System.Drawing.Point(24, 136);
            this.lblPH.Name = "lblPH";
            this.lblPH.Size = new System.Drawing.Size(22, 13);
            this.lblPH.TabIndex = 39;
            this.lblPH.Text = "PH";
            // 
            // txtPH
            // 
            this.txtPH.Location = new System.Drawing.Point(6, 152);
            this.txtPH.Name = "txtPH";
            this.txtPH.Size = new System.Drawing.Size(65, 20);
            this.txtPH.TabIndex = 38;
            // 
            // txtTiempoCalentamiento
            // 
            this.txtTiempoCalentamiento.Location = new System.Drawing.Point(6, 97);
            this.txtTiempoCalentamiento.Name = "txtTiempoCalentamiento";
            this.txtTiempoCalentamiento.Size = new System.Drawing.Size(152, 20);
            this.txtTiempoCalentamiento.TabIndex = 37;
            // 
            // lblTiempo
            // 
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Location = new System.Drawing.Point(7, 81);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(137, 13);
            this.lblTiempo.TabIndex = 36;
            this.lblTiempo.Text = "Tiempo Calentamiento (HH)";
            // 
            // lblTemperaturaMezclado
            // 
            this.lblTemperaturaMezclado.AutoSize = true;
            this.lblTemperaturaMezclado.Location = new System.Drawing.Point(3, 238);
            this.lblTemperaturaMezclado.Name = "lblTemperaturaMezclado";
            this.lblTemperaturaMezclado.Size = new System.Drawing.Size(116, 13);
            this.lblTemperaturaMezclado.TabIndex = 12;
            this.lblTemperaturaMezclado.Text = "Temperatura Mezclado";
            // 
            // txtTempMezclado
            // 
            this.txtTempMezclado.Location = new System.Drawing.Point(6, 254);
            this.txtTempMezclado.Name = "txtTempMezclado";
            this.txtTempMezclado.Size = new System.Drawing.Size(153, 20);
            this.txtTempMezclado.TabIndex = 11;
            // 
            // btMezclar
            // 
            this.btMezclar.Location = new System.Drawing.Point(186, 251);
            this.btMezclar.Name = "btMezclar";
            this.btMezclar.Size = new System.Drawing.Size(134, 23);
            this.btMezclar.TabIndex = 10;
            this.btMezclar.Text = "Mezclar";
            this.btMezclar.UseVisualStyleBackColor = true;
            this.btMezclar.Click += new System.EventHandler(this.btMezclar_Click);
            // 
            // btCalentar
            // 
            this.btCalentar.Location = new System.Drawing.Point(186, 62);
            this.btCalentar.Name = "btCalentar";
            this.btCalentar.Size = new System.Drawing.Size(134, 32);
            this.btCalentar.TabIndex = 8;
            this.btCalentar.Text = "Calentar";
            this.btCalentar.UseVisualStyleBackColor = true;
            this.btCalentar.Click += new System.EventHandler(this.btCalentar_Click);
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
            // txtTemperaturaCalentamiento
            // 
            this.txtTemperaturaCalentamiento.Location = new System.Drawing.Point(6, 45);
            this.txtTemperaturaCalentamiento.Name = "txtTemperaturaCalentamiento";
            this.txtTemperaturaCalentamiento.Size = new System.Drawing.Size(152, 20);
            this.txtTemperaturaCalentamiento.TabIndex = 0;
            // 
            // chkInoculado
            // 
            this.chkInoculado.AutoSize = true;
            this.chkInoculado.Enabled = false;
            this.chkInoculado.Location = new System.Drawing.Point(36, 481);
            this.chkInoculado.Name = "chkInoculado";
            this.chkInoculado.Size = new System.Drawing.Size(73, 17);
            this.chkInoculado.TabIndex = 20;
            this.chkInoculado.Text = "Inoculado";
            this.chkInoculado.UseVisualStyleBackColor = true;
            // 
            // btGenerarInforme
            // 
            this.btGenerarInforme.BackColor = System.Drawing.SystemColors.Control;
            this.btGenerarInforme.Location = new System.Drawing.Point(13, 506);
            this.btGenerarInforme.Name = "btGenerarInforme";
            this.btGenerarInforme.Size = new System.Drawing.Size(305, 41);
            this.btGenerarInforme.TabIndex = 19;
            this.btGenerarInforme.Text = "Generar Informe";
            this.btGenerarInforme.UseVisualStyleBackColor = false;
            this.btGenerarInforme.Click += new System.EventHandler(this.btGenerarInforme_Click);
            // 
            // chkMezclar
            // 
            this.chkMezclar.AutoSize = true;
            this.chkMezclar.Enabled = false;
            this.chkMezclar.Location = new System.Drawing.Point(143, 481);
            this.chkMezclar.Name = "chkMezclar";
            this.chkMezclar.Size = new System.Drawing.Size(72, 17);
            this.chkMezclar.TabIndex = 34;
            this.chkMezclar.Text = "Mezclado";
            this.chkMezclar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTecnico);
            this.groupBox1.Controls.Add(this.lblTanqueIncubacion);
            this.groupBox1.Controls.Add(this.lblTecnico);
            this.groupBox1.Controls.Add(this.txtTanqueIncubacion);
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 116);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cboTecnico
            // 
            this.cboTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Location = new System.Drawing.Point(10, 89);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(148, 21);
            this.cboTecnico.TabIndex = 18;
            // 
            // lblTanqueIncubacion
            // 
            this.lblTanqueIncubacion.AutoSize = true;
            this.lblTanqueIncubacion.Location = new System.Drawing.Point(7, 16);
            this.lblTanqueIncubacion.Name = "lblTanqueIncubacion";
            this.lblTanqueIncubacion.Size = new System.Drawing.Size(114, 13);
            this.lblTanqueIncubacion.TabIndex = 10;
            this.lblTanqueIncubacion.Text = "ID Tanque Incubación";
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Location = new System.Drawing.Point(7, 73);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(137, 13);
            this.lblTecnico.TabIndex = 17;
            this.lblTecnico.Text = "Legajo Tecnico controlador";
            // 
            // txtTanqueIncubacion
            // 
            this.txtTanqueIncubacion.Location = new System.Drawing.Point(10, 32);
            this.txtTanqueIncubacion.Name = "txtTanqueIncubacion";
            this.txtTanqueIncubacion.Size = new System.Drawing.Size(148, 20);
            this.txtTanqueIncubacion.TabIndex = 9;
            // 
            // chkCalentado
            // 
            this.chkCalentado.AutoSize = true;
            this.chkCalentado.Enabled = false;
            this.chkCalentado.Location = new System.Drawing.Point(246, 481);
            this.chkCalentado.Name = "chkCalentado";
            this.chkCalentado.Size = new System.Drawing.Size(74, 17);
            this.chkCalentado.TabIndex = 36;
            this.chkCalentado.Text = "Calentado";
            this.chkCalentado.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btEliminar.Location = new System.Drawing.Point(12, 600);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(306, 41);
            this.btEliminar.TabIndex = 46;
            this.btEliminar.Text = "Eliminar Informe";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btActualizar.Location = new System.Drawing.Point(13, 553);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(305, 41);
            this.btActualizar.TabIndex = 45;
            this.btActualizar.Text = "Actualizar Informe";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // FrmIncubarYBatir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 642);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.chkCalentado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkMezclar);
            this.Controls.Add(this.gbPasos);
            this.Controls.Add(this.chkInoculado);
            this.Controls.Add(this.btGenerarInforme);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIncubarYBatir";
            this.Text = "Inoculación y Mezclado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIncubarYBatir_FormClosing);
            this.gbPasos.ResumeLayout(false);
            this.gbPasos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbPasos;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.TextBox txtTemperaturaCalentamiento;
        private System.Windows.Forms.CheckBox chkInoculado;
        private System.Windows.Forms.Button btGenerarInforme;
        private System.Windows.Forms.Button btCalentar;
        private System.Windows.Forms.CheckBox chkMezclar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.Label lblTanqueIncubacion;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.TextBox txtTanqueIncubacion;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.Label lblTemperaturaMezclado;
        private System.Windows.Forms.TextBox txtTempMezclado;
        private System.Windows.Forms.Button btMezclar;
        private System.Windows.Forms.TextBox txtTiempoCalentamiento;
        private System.Windows.Forms.Button btInocular;
        private System.Windows.Forms.Label lblHidrogeno;
        private System.Windows.Forms.TextBox txtHidrogeno;
        private System.Windows.Forms.TextBox txtAcidez;
        private System.Windows.Forms.Label lblNivelAcidez;
        private System.Windows.Forms.Label lblPH;
        private System.Windows.Forms.TextBox txtPH;
        private System.Windows.Forms.CheckBox chkCalentado;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btActualizar;
    }
}