namespace Application.UI
{
    partial class FrmLacteo
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
            this.btAgregarLacteo = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lblAditivos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMateriPrima = new System.Windows.Forms.Label();
            this.cboMateriaPrima = new System.Windows.Forms.ComboBox();
            this.btEstandarización = new System.Windows.Forms.Button();
            this.lblEstandarizar = new System.Windows.Forms.Label();
            this.lblIdInformeEstandarizado = new System.Windows.Forms.Label();
            this.lblIdInformePasteurizar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btPasteurizar = new System.Windows.Forms.Button();
            this.lblIdInformeInoculacion = new System.Windows.Forms.Label();
            this.lblInoculación = new System.Windows.Forms.Label();
            this.btInoculacion = new System.Windows.Forms.Button();
            this.lblIdInformeIncubarYMezclar = new System.Windows.Forms.Label();
            this.lblInocularYBatir = new System.Windows.Forms.Label();
            this.btInocularYMezclar = new System.Windows.Forms.Button();
            this.chkEstandarizar = new System.Windows.Forms.CheckBox();
            this.chkPasteurizar = new System.Windows.Forms.CheckBox();
            this.chkInoculacion = new System.Windows.Forms.CheckBox();
            this.chkEnvasar = new System.Windows.Forms.CheckBox();
            this.lblInformeEnvasado = new System.Windows.Forms.Label();
            this.lblInformeEnvasar = new System.Windows.Forms.Label();
            this.btEnvasar = new System.Windows.Forms.Button();
            this.chkIncubadoMezclado = new System.Windows.Forms.CheckBox();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAgregarLacteo
            // 
            this.btAgregarLacteo.Location = new System.Drawing.Point(14, 445);
            this.btAgregarLacteo.Name = "btAgregarLacteo";
            this.btAgregarLacteo.Size = new System.Drawing.Size(115, 23);
            this.btAgregarLacteo.TabIndex = 20;
            this.btAgregarLacteo.Text = "Agregar";
            this.btAgregarLacteo.UseVisualStyleBackColor = true;
            this.btAgregarLacteo.Click += new System.EventHandler(this.btAgregarLacteo_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(166, 445);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(115, 23);
            this.btCancelar.TabIndex = 21;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tipo de producto";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 162);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(256, 13);
            this.lblTitulo.TabIndex = 36;
            this.lblTitulo.Text = "Indique las etapas de fabricacion a realizar:";
            // 
            // lblMateriPrima
            // 
            this.lblMateriPrima.AutoSize = true;
            this.lblMateriPrima.Location = new System.Drawing.Point(14, 41);
            this.lblMateriPrima.Name = "lblMateriPrima";
            this.lblMateriPrima.Size = new System.Drawing.Size(116, 13);
            this.lblMateriPrima.TabIndex = 37;
            this.lblMateriPrima.Text = "Materia Prima Utillizada";
            // 
            // cboMateriaPrima
            // 
            this.cboMateriaPrima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMateriaPrima.FormattingEnabled = true;
            this.cboMateriaPrima.Location = new System.Drawing.Point(15, 61);
            this.cboMateriaPrima.Name = "cboMateriaPrima";
            this.cboMateriaPrima.Size = new System.Drawing.Size(326, 21);
            this.cboMateriaPrima.TabIndex = 38;
            // 
            // btEstandarización
            // 
            this.btEstandarización.Location = new System.Drawing.Point(225, 195);
            this.btEstandarización.Name = "btEstandarización";
            this.btEstandarización.Size = new System.Drawing.Size(114, 23);
            this.btEstandarización.TabIndex = 40;
            this.btEstandarización.Text = "Estandarizar";
            this.btEstandarización.UseVisualStyleBackColor = true;
            this.btEstandarización.Click += new System.EventHandler(this.btEstandarización_Click);
            // 
            // lblEstandarizar
            // 
            this.lblEstandarizar.AutoSize = true;
            this.lblEstandarizar.Location = new System.Drawing.Point(17, 200);
            this.lblEstandarizar.Name = "lblEstandarizar";
            this.lblEstandarizar.Size = new System.Drawing.Size(138, 13);
            this.lblEstandarizar.TabIndex = 41;
            this.lblEstandarizar.Text = "Nro informe estandarización";
            // 
            // lblIdInformeEstandarizado
            // 
            this.lblIdInformeEstandarizado.AutoSize = true;
            this.lblIdInformeEstandarizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdInformeEstandarizado.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblIdInformeEstandarizado.Location = new System.Drawing.Point(171, 200);
            this.lblIdInformeEstandarizado.Name = "lblIdInformeEstandarizado";
            this.lblIdInformeEstandarizado.Size = new System.Drawing.Size(14, 13);
            this.lblIdInformeEstandarizado.TabIndex = 42;
            this.lblIdInformeEstandarizado.Text = "0";
            // 
            // lblIdInformePasteurizar
            // 
            this.lblIdInformePasteurizar.AutoSize = true;
            this.lblIdInformePasteurizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdInformePasteurizar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblIdInformePasteurizar.Location = new System.Drawing.Point(171, 240);
            this.lblIdInformePasteurizar.Name = "lblIdInformePasteurizar";
            this.lblIdInformePasteurizar.Size = new System.Drawing.Size(14, 13);
            this.lblIdInformePasteurizar.TabIndex = 45;
            this.lblIdInformePasteurizar.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Nro informe pasteurizacion:";
            // 
            // btPasteurizar
            // 
            this.btPasteurizar.Location = new System.Drawing.Point(225, 235);
            this.btPasteurizar.Name = "btPasteurizar";
            this.btPasteurizar.Size = new System.Drawing.Size(114, 23);
            this.btPasteurizar.TabIndex = 43;
            this.btPasteurizar.Text = "Pasteurizar";
            this.btPasteurizar.UseVisualStyleBackColor = true;
            this.btPasteurizar.Click += new System.EventHandler(this.btPasteurizar_Click);
            // 
            // lblIdInformeInoculacion
            // 
            this.lblIdInformeInoculacion.AutoSize = true;
            this.lblIdInformeInoculacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdInformeInoculacion.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblIdInformeInoculacion.Location = new System.Drawing.Point(171, 280);
            this.lblIdInformeInoculacion.Name = "lblIdInformeInoculacion";
            this.lblIdInformeInoculacion.Size = new System.Drawing.Size(14, 13);
            this.lblIdInformeInoculacion.TabIndex = 48;
            this.lblIdInformeInoculacion.Text = "0";
            // 
            // lblInoculación
            // 
            this.lblInoculación.AutoSize = true;
            this.lblInoculación.Location = new System.Drawing.Point(17, 280);
            this.lblInoculación.Name = "lblInoculación";
            this.lblInoculación.Size = new System.Drawing.Size(118, 13);
            this.lblInoculación.TabIndex = 47;
            this.lblInoculación.Text = "Nro informe inoculación";
            // 
            // btInoculacion
            // 
            this.btInoculacion.Location = new System.Drawing.Point(225, 275);
            this.btInoculacion.Name = "btInoculacion";
            this.btInoculacion.Size = new System.Drawing.Size(114, 23);
            this.btInoculacion.TabIndex = 46;
            this.btInoculacion.Text = "Inoculacion";
            this.btInoculacion.UseVisualStyleBackColor = true;
            this.btInoculacion.Click += new System.EventHandler(this.btInoculacion_Click);
            // 
            // lblIdInformeIncubarYMezclar
            // 
            this.lblIdInformeIncubarYMezclar.AutoSize = true;
            this.lblIdInformeIncubarYMezclar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdInformeIncubarYMezclar.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblIdInformeIncubarYMezclar.Location = new System.Drawing.Point(171, 319);
            this.lblIdInformeIncubarYMezclar.Name = "lblIdInformeIncubarYMezclar";
            this.lblIdInformeIncubarYMezclar.Size = new System.Drawing.Size(14, 13);
            this.lblIdInformeIncubarYMezclar.TabIndex = 51;
            this.lblIdInformeIncubarYMezclar.Text = "0";
            // 
            // lblInocularYBatir
            // 
            this.lblInocularYBatir.AutoSize = true;
            this.lblInocularYBatir.Location = new System.Drawing.Point(17, 319);
            this.lblInocularYBatir.Name = "lblInocularYBatir";
            this.lblInocularYBatir.Size = new System.Drawing.Size(155, 13);
            this.lblInocularYBatir.TabIndex = 50;
            this.lblInocularYBatir.Text = "Nro informe incubado y mezclar";
            // 
            // btInocularYMezclar
            // 
            this.btInocularYMezclar.Location = new System.Drawing.Point(225, 314);
            this.btInocularYMezclar.Name = "btInocularYMezclar";
            this.btInocularYMezclar.Size = new System.Drawing.Size(114, 23);
            this.btInocularYMezclar.TabIndex = 49;
            this.btInocularYMezclar.Text = "Incubar  y Batir";
            this.btInocularYMezclar.UseVisualStyleBackColor = true;
            this.btInocularYMezclar.Click += new System.EventHandler(this.btInocularYMezclar_Click);
            // 
            // chkEstandarizar
            // 
            this.chkEstandarizar.AutoSize = true;
            this.chkEstandarizar.Enabled = false;
            this.chkEstandarizar.Location = new System.Drawing.Point(20, 386);
            this.chkEstandarizar.Name = "chkEstandarizar";
            this.chkEstandarizar.Size = new System.Drawing.Size(93, 17);
            this.chkEstandarizar.TabIndex = 52;
            this.chkEstandarizar.Text = "Estandarizado";
            this.chkEstandarizar.UseVisualStyleBackColor = true;
            // 
            // chkPasteurizar
            // 
            this.chkPasteurizar.AutoSize = true;
            this.chkPasteurizar.Enabled = false;
            this.chkPasteurizar.Location = new System.Drawing.Point(149, 386);
            this.chkPasteurizar.Name = "chkPasteurizar";
            this.chkPasteurizar.Size = new System.Drawing.Size(87, 17);
            this.chkPasteurizar.TabIndex = 53;
            this.chkPasteurizar.Text = "Pasteurizado";
            this.chkPasteurizar.UseVisualStyleBackColor = true;
            // 
            // chkInoculacion
            // 
            this.chkInoculacion.AutoSize = true;
            this.chkInoculacion.Enabled = false;
            this.chkInoculacion.Location = new System.Drawing.Point(20, 413);
            this.chkInoculacion.Name = "chkInoculacion";
            this.chkInoculacion.Size = new System.Drawing.Size(81, 17);
            this.chkInoculacion.TabIndex = 54;
            this.chkInoculacion.Text = "Inoculación";
            this.chkInoculacion.UseVisualStyleBackColor = true;
            // 
            // chkEnvasar
            // 
            this.chkEnvasar.AutoSize = true;
            this.chkEnvasar.Enabled = false;
            this.chkEnvasar.Location = new System.Drawing.Point(149, 413);
            this.chkEnvasar.Name = "chkEnvasar";
            this.chkEnvasar.Size = new System.Drawing.Size(65, 17);
            this.chkEnvasar.TabIndex = 55;
            this.chkEnvasar.Text = "Envasar";
            this.chkEnvasar.UseVisualStyleBackColor = true;
            this.chkEnvasar.Click += new System.EventHandler(this.btEnvasar_Click);
            // 
            // lblInformeEnvasado
            // 
            this.lblInformeEnvasado.AutoSize = true;
            this.lblInformeEnvasado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformeEnvasado.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblInformeEnvasado.Location = new System.Drawing.Point(171, 353);
            this.lblInformeEnvasado.Name = "lblInformeEnvasado";
            this.lblInformeEnvasado.Size = new System.Drawing.Size(14, 13);
            this.lblInformeEnvasado.TabIndex = 58;
            this.lblInformeEnvasado.Text = "0";
            // 
            // lblInformeEnvasar
            // 
            this.lblInformeEnvasar.AutoSize = true;
            this.lblInformeEnvasar.Location = new System.Drawing.Point(17, 353);
            this.lblInformeEnvasar.Name = "lblInformeEnvasar";
            this.lblInformeEnvasar.Size = new System.Drawing.Size(102, 13);
            this.lblInformeEnvasar.TabIndex = 57;
            this.lblInformeEnvasar.Text = "Nro informe envasar";
            // 
            // btEnvasar
            // 
            this.btEnvasar.Location = new System.Drawing.Point(225, 348);
            this.btEnvasar.Name = "btEnvasar";
            this.btEnvasar.Size = new System.Drawing.Size(114, 23);
            this.btEnvasar.TabIndex = 56;
            this.btEnvasar.Text = "Envasar";
            this.btEnvasar.UseVisualStyleBackColor = true;
            this.btEnvasar.Click += new System.EventHandler(this.btEnvasar_Click);
            // 
            // chkIncubadoMezclado
            // 
            this.chkIncubadoMezclado.AutoSize = true;
            this.chkIncubadoMezclado.Enabled = false;
            this.chkIncubadoMezclado.Location = new System.Drawing.Point(254, 386);
            this.chkIncubadoMezclado.Name = "chkIncubadoMezclado";
            this.chkIncubadoMezclado.Size = new System.Drawing.Size(128, 17);
            this.chkIncubadoMezclado.TabIndex = 59;
            this.chkIncubadoMezclado.Text = "Incubado y Mezclado";
            this.chkIncubadoMezclado.UseVisualStyleBackColor = true;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(15, 115);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(326, 21);
            this.cboTipo.TabIndex = 60;
            this.cboTipo.SelectedValueChanged += new System.EventHandler(this.cboTipo_SelectedValueChanged);
            // 
            // btActualizar
            // 
            this.btActualizar.Location = new System.Drawing.Point(12, 474);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(115, 23);
            this.btActualizar.TabIndex = 61;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = true;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.Location = new System.Drawing.Point(166, 474);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(115, 23);
            this.btEliminar.TabIndex = 62;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = true;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // FrmLacteo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 498);
            this.Controls.Add(this.btEliminar);
            this.Controls.Add(this.btActualizar);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.chkIncubadoMezclado);
            this.Controls.Add(this.lblInformeEnvasado);
            this.Controls.Add(this.lblInformeEnvasar);
            this.Controls.Add(this.btEnvasar);
            this.Controls.Add(this.chkEnvasar);
            this.Controls.Add(this.chkInoculacion);
            this.Controls.Add(this.chkPasteurizar);
            this.Controls.Add(this.chkEstandarizar);
            this.Controls.Add(this.lblIdInformeIncubarYMezclar);
            this.Controls.Add(this.lblInocularYBatir);
            this.Controls.Add(this.btInocularYMezclar);
            this.Controls.Add(this.lblIdInformeInoculacion);
            this.Controls.Add(this.lblInoculación);
            this.Controls.Add(this.btInoculacion);
            this.Controls.Add(this.lblIdInformePasteurizar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btPasteurizar);
            this.Controls.Add(this.lblIdInformeEstandarizado);
            this.Controls.Add(this.lblEstandarizar);
            this.Controls.Add(this.btEstandarización);
            this.Controls.Add(this.cboMateriaPrima);
            this.Controls.Add(this.lblMateriPrima);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAditivos);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btAgregarLacteo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLacteo";
            this.Text = "Crear Lacteo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAgregarLacteo_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btAgregarLacteo;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lblAditivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMateriPrima;
        private System.Windows.Forms.ComboBox cboMateriaPrima;
        private System.Windows.Forms.Button btEstandarización;
        private System.Windows.Forms.Label lblEstandarizar;
        private System.Windows.Forms.Label lblIdInformeEstandarizado;
        private System.Windows.Forms.Label lblIdInformePasteurizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPasteurizar;
        private System.Windows.Forms.Label lblIdInformeInoculacion;
        private System.Windows.Forms.Label lblInoculación;
        private System.Windows.Forms.Button btInoculacion;
        private System.Windows.Forms.Label lblIdInformeIncubarYMezclar;
        private System.Windows.Forms.Label lblInocularYBatir;
        private System.Windows.Forms.Button btInocularYMezclar;
        private System.Windows.Forms.CheckBox chkEstandarizar;
        private System.Windows.Forms.CheckBox chkPasteurizar;
        private System.Windows.Forms.CheckBox chkInoculacion;
        private System.Windows.Forms.CheckBox chkEnvasar;
        private System.Windows.Forms.Label lblInformeEnvasado;
        private System.Windows.Forms.Label lblInformeEnvasar;
        private System.Windows.Forms.Button btEnvasar;
        private System.Windows.Forms.CheckBox chkIncubadoMezclado;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btEliminar;
    }
}