namespace Application.UI
{
    partial class FrmPasteurizacion
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
            this.lblMetodo = new System.Windows.Forms.Label();
            this.cboTipoPasteurizacion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempEnfriamiento = new System.Windows.Forms.TextBox();
            this.btEnfriar = new System.Windows.Forms.Button();
            this.btPasteurizar = new System.Windows.Forms.Button();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.txtTemperaturaCalentamiento = new System.Windows.Forms.TextBox();
            this.chkPasteurizado = new System.Windows.Forms.CheckBox();
            this.btGenerarInforme = new System.Windows.Forms.Button();
            this.chkEnfriado = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.lblOlla = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.txtOllaPasteurizacion = new System.Windows.Forms.TextBox();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.gbPasos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPasos
            // 
            this.gbPasos.Controls.Add(this.lblMetodo);
            this.gbPasos.Controls.Add(this.cboTipoPasteurizacion);
            this.gbPasos.Controls.Add(this.label1);
            this.gbPasos.Controls.Add(this.txtTempEnfriamiento);
            this.gbPasos.Controls.Add(this.btEnfriar);
            this.gbPasos.Controls.Add(this.btPasteurizar);
            this.gbPasos.Controls.Add(this.lblTemperatura);
            this.gbPasos.Controls.Add(this.txtTemperaturaCalentamiento);
            this.gbPasos.Location = new System.Drawing.Point(13, 158);
            this.gbPasos.Name = "gbPasos";
            this.gbPasos.Size = new System.Drawing.Size(374, 199);
            this.gbPasos.TabIndex = 23;
            this.gbPasos.TabStop = false;
            this.gbPasos.Text = "Pasos";
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Location = new System.Drawing.Point(7, 81);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(109, 13);
            this.lblMetodo.TabIndex = 36;
            this.lblMetodo.Text = "Metodo Presurizacion";
            this.lblMetodo.Visible = false;
            // 
            // cboTipoPasteurizacion
            // 
            this.cboTipoPasteurizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoPasteurizacion.FormattingEnabled = true;
            this.cboTipoPasteurizacion.Location = new System.Drawing.Point(5, 97);
            this.cboTipoPasteurizacion.Name = "cboTipoPasteurizacion";
            this.cboTipoPasteurizacion.Size = new System.Drawing.Size(153, 21);
            this.cboTipoPasteurizacion.TabIndex = 13;
            this.cboTipoPasteurizacion.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Temperatura enfriamiento";
            // 
            // txtTempEnfriamiento
            // 
            this.txtTempEnfriamiento.Location = new System.Drawing.Point(5, 157);
            this.txtTempEnfriamiento.Name = "txtTempEnfriamiento";
            this.txtTempEnfriamiento.Size = new System.Drawing.Size(153, 20);
            this.txtTempEnfriamiento.TabIndex = 11;
            // 
            // btEnfriar
            // 
            this.btEnfriar.Location = new System.Drawing.Point(186, 155);
            this.btEnfriar.Name = "btEnfriar";
            this.btEnfriar.Size = new System.Drawing.Size(134, 23);
            this.btEnfriar.TabIndex = 10;
            this.btEnfriar.Text = "Enfriar";
            this.btEnfriar.UseVisualStyleBackColor = true;
            this.btEnfriar.Click += new System.EventHandler(this.btEnfriar_Click);
            // 
            // btPasteurizar
            // 
            this.btPasteurizar.Location = new System.Drawing.Point(186, 62);
            this.btPasteurizar.Name = "btPasteurizar";
            this.btPasteurizar.Size = new System.Drawing.Size(134, 32);
            this.btPasteurizar.TabIndex = 8;
            this.btPasteurizar.Text = "Pasteurizar";
            this.btPasteurizar.UseVisualStyleBackColor = true;
            this.btPasteurizar.Click += new System.EventHandler(this.btPasteurizar_Click);
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
            // chkPasteurizado
            // 
            this.chkPasteurizado.AutoSize = true;
            this.chkPasteurizado.Enabled = false;
            this.chkPasteurizado.Location = new System.Drawing.Point(19, 383);
            this.chkPasteurizado.Name = "chkPasteurizado";
            this.chkPasteurizado.Size = new System.Drawing.Size(87, 17);
            this.chkPasteurizado.TabIndex = 20;
            this.chkPasteurizado.Text = "Pasteurizado";
            this.chkPasteurizado.UseVisualStyleBackColor = true;
            // 
            // btGenerarInforme
            // 
            this.btGenerarInforme.BackColor = System.Drawing.SystemColors.Control;
            this.btGenerarInforme.Location = new System.Drawing.Point(14, 438);
            this.btGenerarInforme.Name = "btGenerarInforme";
            this.btGenerarInforme.Size = new System.Drawing.Size(319, 41);
            this.btGenerarInforme.TabIndex = 19;
            this.btGenerarInforme.Text = "Generar Informe";
            this.btGenerarInforme.UseVisualStyleBackColor = false;
            this.btGenerarInforme.Click += new System.EventHandler(this.btGenerarInforme_Click);
            // 
            // chkEnfriado
            // 
            this.chkEnfriado.AutoSize = true;
            this.chkEnfriado.Enabled = false;
            this.chkEnfriado.Location = new System.Drawing.Point(19, 406);
            this.chkEnfriado.Name = "chkEnfriado";
            this.chkEnfriado.Size = new System.Drawing.Size(65, 17);
            this.chkEnfriado.TabIndex = 34;
            this.chkEnfriado.Text = "Enfriado";
            this.chkEnfriado.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTecnico);
            this.groupBox1.Controls.Add(this.lblOlla);
            this.groupBox1.Controls.Add(this.lblTecnico);
            this.groupBox1.Controls.Add(this.txtOllaPasteurizacion);
            this.groupBox1.Location = new System.Drawing.Point(13, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 116);
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
            // lblOlla
            // 
            this.lblOlla.AutoSize = true;
            this.lblOlla.Location = new System.Drawing.Point(7, 16);
            this.lblOlla.Name = "lblOlla";
            this.lblOlla.Size = new System.Drawing.Size(111, 13);
            this.lblOlla.TabIndex = 10;
            this.lblOlla.Text = "ID Olla Pasteurizacion";
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
            // txtOllaPasteurizacion
            // 
            this.txtOllaPasteurizacion.Location = new System.Drawing.Point(10, 32);
            this.txtOllaPasteurizacion.Name = "txtOllaPasteurizacion";
            this.txtOllaPasteurizacion.Size = new System.Drawing.Size(148, 20);
            this.txtOllaPasteurizacion.TabIndex = 9;
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btActualizar.Location = new System.Drawing.Point(14, 485);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(319, 41);
            this.btActualizar.TabIndex = 36;
            this.btActualizar.Text = "Actualizar Informe";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btEliminar.Location = new System.Drawing.Point(12, 532);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(319, 41);
            this.btEliminar.TabIndex = 37;
            this.btEliminar.Text = "Eliminar Informe";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // FrmPasteurizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 579);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkEnfriado);
            this.Controls.Add(this.gbPasos);
            this.Controls.Add(this.chkPasteurizado);
            this.Controls.Add(this.btGenerarInforme);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPasteurizacion";
            this.Text = "Pasteurizacion";
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
        private System.Windows.Forms.CheckBox chkPasteurizado;
        private System.Windows.Forms.Button btGenerarInforme;
        private System.Windows.Forms.Button btPasteurizar;
        private System.Windows.Forms.CheckBox chkEnfriado;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.Label lblOlla;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.TextBox txtOllaPasteurizacion;
        private System.Windows.Forms.ComboBox cboTipoPasteurizacion;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTempEnfriamiento;
        private System.Windows.Forms.Button btEnfriar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btEliminar;
    }
}