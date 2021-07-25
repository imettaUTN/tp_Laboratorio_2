namespace Application.UI
{
    partial class FrmEstandarizar
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
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.btCalentar = new System.Windows.Forms.Button();
            this.btDesengrasar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGrasa = new System.Windows.Forms.TextBox();
            this.btSolidos = new System.Windows.Forms.Button();
            this.lblSolidos = new System.Windows.Forms.Label();
            this.txtSolidos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btGenerarInforme = new System.Windows.Forms.Button();
            this.chkCalentado = new System.Windows.Forms.CheckBox();
            this.chkDesengrasado = new System.Windows.Forms.CheckBox();
            this.chkSolidoEstandarizado = new System.Windows.Forms.CheckBox();
            this.gbPasos = new System.Windows.Forms.GroupBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTamizador = new System.Windows.Forms.ComboBox();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.gbPasos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.Location = new System.Drawing.Point(16, 35);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(201, 20);
            this.txtTemperatura.TabIndex = 0;
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(17, 16);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(136, 13);
            this.lblTemperatura.TabIndex = 1;
            this.lblTemperatura.Text = "Temperatura calentamiento";
            // 
            // btCalentar
            // 
            this.btCalentar.Location = new System.Drawing.Point(58, 62);
            this.btCalentar.Name = "btCalentar";
            this.btCalentar.Size = new System.Drawing.Size(110, 23);
            this.btCalentar.TabIndex = 2;
            this.btCalentar.Text = "Calentar";
            this.btCalentar.UseVisualStyleBackColor = true;
            this.btCalentar.Click += new System.EventHandler(this.btCalentar_Click);
            // 
            // btDesengrasar
            // 
            this.btDesengrasar.Location = new System.Drawing.Point(58, 148);
            this.btDesengrasar.Name = "btDesengrasar";
            this.btDesengrasar.Size = new System.Drawing.Size(110, 23);
            this.btDesengrasar.TabIndex = 5;
            this.btDesengrasar.Text = "Desengrazar leche";
            this.btDesengrasar.UseVisualStyleBackColor = true;
            this.btDesengrasar.Click += new System.EventHandler(this.btDesengrasar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "% Tenor Graso / 100 ml";
            // 
            // txtGrasa
            // 
            this.txtGrasa.Location = new System.Drawing.Point(16, 121);
            this.txtGrasa.Name = "txtGrasa";
            this.txtGrasa.Size = new System.Drawing.Size(201, 20);
            this.txtGrasa.TabIndex = 3;
            // 
            // btSolidos
            // 
            this.btSolidos.Location = new System.Drawing.Point(58, 230);
            this.btSolidos.Name = "btSolidos";
            this.btSolidos.Size = new System.Drawing.Size(110, 23);
            this.btSolidos.TabIndex = 8;
            this.btSolidos.Text = "Quitar solidos";
            this.btSolidos.UseVisualStyleBackColor = true;
            this.btSolidos.Click += new System.EventHandler(this.btSolidos_Click);
            // 
            // lblSolidos
            // 
            this.lblSolidos.AutoSize = true;
            this.lblSolidos.Location = new System.Drawing.Point(17, 184);
            this.lblSolidos.Name = "lblSolidos";
            this.lblSolidos.Size = new System.Drawing.Size(52, 13);
            this.lblSolidos.TabIndex = 7;
            this.lblSolidos.Text = "% Solidos";
            // 
            // txtSolidos
            // 
            this.txtSolidos.Location = new System.Drawing.Point(16, 203);
            this.txtSolidos.Name = "txtSolidos";
            this.txtSolidos.Size = new System.Drawing.Size(201, 20);
            this.txtSolidos.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ID Tamizador";
            // 
            // btGenerarInforme
            // 
            this.btGenerarInforme.BackColor = System.Drawing.SystemColors.Control;
            this.btGenerarInforme.Location = new System.Drawing.Point(18, 507);
            this.btGenerarInforme.Name = "btGenerarInforme";
            this.btGenerarInforme.Size = new System.Drawing.Size(214, 41);
            this.btGenerarInforme.TabIndex = 11;
            this.btGenerarInforme.Text = "Generar Informe";
            this.btGenerarInforme.UseVisualStyleBackColor = false;
            this.btGenerarInforme.Click += new System.EventHandler(this.btGenerarInforme_Click);
            // 
            // chkCalentado
            // 
            this.chkCalentado.AutoSize = true;
            this.chkCalentado.Enabled = false;
            this.chkCalentado.Location = new System.Drawing.Point(18, 426);
            this.chkCalentado.Name = "chkCalentado";
            this.chkCalentado.Size = new System.Drawing.Size(74, 17);
            this.chkCalentado.TabIndex = 12;
            this.chkCalentado.Text = "Calentado";
            this.chkCalentado.UseVisualStyleBackColor = true;
            // 
            // chkDesengrasado
            // 
            this.chkDesengrasado.AutoSize = true;
            this.chkDesengrasado.Enabled = false;
            this.chkDesengrasado.Location = new System.Drawing.Point(18, 449);
            this.chkDesengrasado.Name = "chkDesengrasado";
            this.chkDesengrasado.Size = new System.Drawing.Size(95, 17);
            this.chkDesengrasado.TabIndex = 13;
            this.chkDesengrasado.Text = "Desengrasado";
            this.chkDesengrasado.UseVisualStyleBackColor = true;
            // 
            // chkSolidoEstandarizado
            // 
            this.chkSolidoEstandarizado.AutoSize = true;
            this.chkSolidoEstandarizado.Enabled = false;
            this.chkSolidoEstandarizado.Location = new System.Drawing.Point(18, 475);
            this.chkSolidoEstandarizado.Name = "chkSolidoEstandarizado";
            this.chkSolidoEstandarizado.Size = new System.Drawing.Size(125, 17);
            this.chkSolidoEstandarizado.TabIndex = 14;
            this.chkSolidoEstandarizado.Text = "Solido Estandarizado";
            this.chkSolidoEstandarizado.UseVisualStyleBackColor = true;
            // 
            // gbPasos
            // 
            this.gbPasos.Controls.Add(this.lblTemperatura);
            this.gbPasos.Controls.Add(this.txtTemperatura);
            this.gbPasos.Controls.Add(this.btCalentar);
            this.gbPasos.Controls.Add(this.label1);
            this.gbPasos.Controls.Add(this.txtGrasa);
            this.gbPasos.Controls.Add(this.btDesengrasar);
            this.gbPasos.Controls.Add(this.lblSolidos);
            this.gbPasos.Controls.Add(this.btSolidos);
            this.gbPasos.Controls.Add(this.txtSolidos);
            this.gbPasos.Location = new System.Drawing.Point(15, 142);
            this.gbPasos.Name = "gbPasos";
            this.gbPasos.Size = new System.Drawing.Size(257, 269);
            this.gbPasos.TabIndex = 15;
            this.gbPasos.TabStop = false;
            this.gbPasos.Text = "Pasos";
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Location = new System.Drawing.Point(15, 73);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(137, 13);
            this.lblTecnico.TabIndex = 17;
            this.lblTecnico.Text = "Legajo Tecnico controlador";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTamizador);
            this.groupBox1.Controls.Add(this.cboTecnico);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblTecnico);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 116);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cboTamizador
            // 
            this.cboTamizador.FormattingEnabled = true;
            this.cboTamizador.Location = new System.Drawing.Point(13, 32);
            this.cboTamizador.Name = "cboTamizador";
            this.cboTamizador.Size = new System.Drawing.Size(201, 21);
            this.cboTamizador.TabIndex = 19;
            // 
            // cboTecnico
            // 
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Location = new System.Drawing.Point(13, 89);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(201, 21);
            this.cboTecnico.TabIndex = 18;
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btEliminar.Location = new System.Drawing.Point(16, 601);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(216, 41);
            this.btEliminar.TabIndex = 44;
            this.btEliminar.Text = "Eliminar Informe";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btActualizar.Location = new System.Drawing.Point(18, 554);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(214, 41);
            this.btActualizar.TabIndex = 43;
            this.btActualizar.Text = "Actualizar Informe";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // FrmEstandarizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 655);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPasos);
            this.Controls.Add(this.chkSolidoEstandarizado);
            this.Controls.Add(this.chkDesengrasado);
            this.Controls.Add(this.chkCalentado);
            this.Controls.Add(this.btGenerarInforme);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEstandarizar";
            this.Text = "Estandarizar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEstandarizar_FormClosing);
            this.gbPasos.ResumeLayout(false);
            this.gbPasos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Button btCalentar;
        private System.Windows.Forms.Button btDesengrasar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGrasa;
        private System.Windows.Forms.Button btSolidos;
        private System.Windows.Forms.Label lblSolidos;
        private System.Windows.Forms.TextBox txtSolidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btGenerarInforme;
        private System.Windows.Forms.CheckBox chkCalentado;
        private System.Windows.Forms.CheckBox chkDesengrasado;
        private System.Windows.Forms.CheckBox chkSolidoEstandarizado;
        private System.Windows.Forms.GroupBox gbPasos;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.ComboBox cboTamizador;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btActualizar;
    }
}