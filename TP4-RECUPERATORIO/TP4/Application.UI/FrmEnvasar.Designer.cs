namespace Application.UI
{
    partial class FrmEnvasar
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTipoEnvase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTecnico = new System.Windows.Forms.ComboBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.gbPasos = new System.Windows.Forms.GroupBox();
            this.btEtiquetar = new System.Windows.Forms.Button();
            this.lblAutorizacion = new System.Windows.Forms.Label();
            this.btAutorizarAnmat = new System.Windows.Forms.Button();
            this.txtAutorizacion = new System.Windows.Forms.TextBox();
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.btEnvasar = new System.Windows.Forms.Button();
            this.chkAutorizado = new System.Windows.Forms.CheckBox();
            this.chkEtiquetar = new System.Windows.Forms.CheckBox();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbPasos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboTipoEnvase);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboTecnico);
            this.groupBox1.Controls.Add(this.lblTecnico);
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 127);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos";
            // 
            // cboTipoEnvase
            // 
            this.cboTipoEnvase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoEnvase.FormattingEnabled = true;
            this.cboTipoEnvase.Location = new System.Drawing.Point(6, 93);
            this.cboTipoEnvase.Name = "cboTipoEnvase";
            this.cboTipoEnvase.Size = new System.Drawing.Size(276, 21);
            this.cboTipoEnvase.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tipo en envase";
            // 
            // cboTecnico
            // 
            this.cboTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTecnico.FormattingEnabled = true;
            this.cboTecnico.Location = new System.Drawing.Point(6, 43);
            this.cboTecnico.Name = "cboTecnico";
            this.cboTecnico.Size = new System.Drawing.Size(276, 21);
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
            // gbPasos
            // 
            this.gbPasos.Controls.Add(this.btEtiquetar);
            this.gbPasos.Controls.Add(this.lblAutorizacion);
            this.gbPasos.Controls.Add(this.btAutorizarAnmat);
            this.gbPasos.Controls.Add(this.txtAutorizacion);
            this.gbPasos.Controls.Add(this.lblTemperatura);
            this.gbPasos.Controls.Add(this.txtTemperatura);
            this.gbPasos.Location = new System.Drawing.Point(12, 157);
            this.gbPasos.Name = "gbPasos";
            this.gbPasos.Size = new System.Drawing.Size(296, 154);
            this.gbPasos.TabIndex = 42;
            this.gbPasos.TabStop = false;
            this.gbPasos.Text = "Pasos";
            // 
            // btEtiquetar
            // 
            this.btEtiquetar.Location = new System.Drawing.Point(6, 82);
            this.btEtiquetar.Name = "btEtiquetar";
            this.btEtiquetar.Size = new System.Drawing.Size(132, 20);
            this.btEtiquetar.TabIndex = 45;
            this.btEtiquetar.Text = "Etiquetar";
            this.btEtiquetar.UseVisualStyleBackColor = true;
            this.btEtiquetar.Click += new System.EventHandler(this.btEtiquetar_Click);
            // 
            // lblAutorizacion
            // 
            this.lblAutorizacion.AutoSize = true;
            this.lblAutorizacion.Location = new System.Drawing.Point(6, 115);
            this.lblAutorizacion.Name = "lblAutorizacion";
            this.lblAutorizacion.Size = new System.Drawing.Size(115, 13);
            this.lblAutorizacion.TabIndex = 44;
            this.lblAutorizacion.Text = "Codigo de autorización";
            // 
            // btAutorizarAnmat
            // 
            this.btAutorizarAnmat.Location = new System.Drawing.Point(165, 131);
            this.btAutorizarAnmat.Name = "btAutorizarAnmat";
            this.btAutorizarAnmat.Size = new System.Drawing.Size(116, 20);
            this.btAutorizarAnmat.TabIndex = 44;
            this.btAutorizarAnmat.Text = "Autorizar en Anmat";
            this.btAutorizarAnmat.UseVisualStyleBackColor = true;
            this.btAutorizarAnmat.Click += new System.EventHandler(this.btAutorizarAnmat_Click);
            // 
            // txtAutorizacion
            // 
            this.txtAutorizacion.Location = new System.Drawing.Point(6, 131);
            this.txtAutorizacion.Name = "txtAutorizacion";
            this.txtAutorizacion.ReadOnly = true;
            this.txtAutorizacion.Size = new System.Drawing.Size(137, 20);
            this.txtAutorizacion.TabIndex = 43;
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Location = new System.Drawing.Point(7, 26);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(118, 13);
            this.lblTemperatura.TabIndex = 1;
            this.lblTemperatura.Text = "Temperatura Envasado";
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.Location = new System.Drawing.Point(6, 45);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(276, 20);
            this.txtTemperatura.TabIndex = 0;
            // 
            // btEnvasar
            // 
            this.btEnvasar.Location = new System.Drawing.Point(18, 361);
            this.btEnvasar.Name = "btEnvasar";
            this.btEnvasar.Size = new System.Drawing.Size(276, 38);
            this.btEnvasar.TabIndex = 8;
            this.btEnvasar.Text = "Envasar";
            this.btEnvasar.UseVisualStyleBackColor = true;
            this.btEnvasar.Click += new System.EventHandler(this.btEnvasar_Click);
            // 
            // chkAutorizado
            // 
            this.chkAutorizado.AutoSize = true;
            this.chkAutorizado.Enabled = false;
            this.chkAutorizado.Location = new System.Drawing.Point(18, 328);
            this.chkAutorizado.Name = "chkAutorizado";
            this.chkAutorizado.Size = new System.Drawing.Size(76, 17);
            this.chkAutorizado.TabIndex = 45;
            this.chkAutorizado.Text = "Autorizado";
            this.chkAutorizado.UseVisualStyleBackColor = true;
            // 
            // chkEtiquetar
            // 
            this.chkEtiquetar.AutoSize = true;
            this.chkEtiquetar.Enabled = false;
            this.chkEtiquetar.Location = new System.Drawing.Point(113, 328);
            this.chkEtiquetar.Name = "chkEtiquetar";
            this.chkEtiquetar.Size = new System.Drawing.Size(77, 17);
            this.chkEtiquetar.TabIndex = 46;
            this.chkEtiquetar.Text = "Etiquetado";
            this.chkEtiquetar.UseVisualStyleBackColor = true;
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.btEliminar.Location = new System.Drawing.Point(17, 452);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(276, 41);
            this.btEliminar.TabIndex = 48;
            this.btEliminar.Text = "Eliminar Informe";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.SystemColors.Control;
            this.btActualizar.Location = new System.Drawing.Point(18, 405);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(275, 41);
            this.btActualizar.TabIndex = 47;
            this.btActualizar.Text = "Actualizar Informe";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // FrmEnvasar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 495);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.chkEtiquetar);
            this.Controls.Add(this.chkAutorizado);
            this.Controls.Add(this.btEnvasar);
            this.Controls.Add(this.gbPasos);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEnvasar";
            this.Text = "FrmEnvasar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPasos.ResumeLayout(false);
            this.gbPasos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboTecnico;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.ComboBox cboTipoEnvase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbPasos;
        private System.Windows.Forms.Button btEnvasar;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.TextBox txtAutorizacion;
        private System.Windows.Forms.Button btAutorizarAnmat;
        private System.Windows.Forms.Button btEtiquetar;
        private System.Windows.Forms.Label lblAutorizacion;
        private System.Windows.Forms.CheckBox chkAutorizado;
        private System.Windows.Forms.CheckBox chkEtiquetar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btActualizar;
    }
}