﻿namespace Application.UI
{
    partial class FrmMateriaPrima
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtIndiceAcidez = new System.Windows.Forms.TextBox();
            this.txtLegajoTecnico = new System.Windows.Forms.TextBox();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblDesripcion = new System.Windows.Forms.Label();
            this.lblIndiceAcidez = new System.Windows.Forms.Label();
            this.lblLegajoTecnico = new System.Windows.Forms.Label();
            this.lblHabilitado = new System.Windows.Forms.Label();
            this.chHabFab = new System.Windows.Forms.CheckBox();
            this.btCargar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lblTambo = new System.Windows.Forms.Label();
            this.cbTanques = new System.Windows.Forms.ComboBox();
            this.cbTambos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(129, 105);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(367, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtIndiceAcidez
            // 
            this.txtIndiceAcidez.Location = new System.Drawing.Point(129, 147);
            this.txtIndiceAcidez.Name = "txtIndiceAcidez";
            this.txtIndiceAcidez.Size = new System.Drawing.Size(367, 20);
            this.txtIndiceAcidez.TabIndex = 2;
            // 
            // txtLegajoTecnico
            // 
            this.txtLegajoTecnico.Location = new System.Drawing.Point(129, 191);
            this.txtLegajoTecnico.Name = "txtLegajoTecnico";
            this.txtLegajoTecnico.Size = new System.Drawing.Size(367, 20);
            this.txtLegajoTecnico.TabIndex = 3;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(44, 30);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(54, 13);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "IdLacteo tanque";
            // 
            // lblDesripcion
            // 
            this.lblDesripcion.AutoSize = true;
            this.lblDesripcion.Location = new System.Drawing.Point(44, 112);
            this.lblDesripcion.Name = "lblDesripcion";
            this.lblDesripcion.Size = new System.Drawing.Size(63, 13);
            this.lblDesripcion.TabIndex = 6;
            this.lblDesripcion.Text = "Descripcion";
            // 
            // lblIndiceAcidez
            // 
            this.lblIndiceAcidez.AutoSize = true;
            this.lblIndiceAcidez.Location = new System.Drawing.Point(44, 154);
            this.lblIndiceAcidez.Name = "lblIndiceAcidez";
            this.lblIndiceAcidez.Size = new System.Drawing.Size(71, 13);
            this.lblIndiceAcidez.TabIndex = 7;
            this.lblIndiceAcidez.Text = "Indice Acidez";
            // 
            // lblLegajoTecnico
            // 
            this.lblLegajoTecnico.AutoSize = true;
            this.lblLegajoTecnico.Location = new System.Drawing.Point(44, 194);
            this.lblLegajoTecnico.Name = "lblLegajoTecnico";
            this.lblLegajoTecnico.Size = new System.Drawing.Size(81, 13);
            this.lblLegajoTecnico.TabIndex = 8;
            this.lblLegajoTecnico.Text = "Legajo Tecnico";
            // 
            // lblHabilitado
            // 
            this.lblHabilitado.AutoSize = true;
            this.lblHabilitado.Location = new System.Drawing.Point(44, 236);
            this.lblHabilitado.Name = "lblHabilitado";
            this.lblHabilitado.Size = new System.Drawing.Size(116, 13);
            this.lblHabilitado.TabIndex = 9;
            this.lblHabilitado.Text = "Habilitado para Fabrica";
            // 
            // chHabFab
            // 
            this.chHabFab.AutoSize = true;
            this.chHabFab.Location = new System.Drawing.Point(183, 236);
            this.chHabFab.Name = "chHabFab";
            this.chHabFab.Size = new System.Drawing.Size(15, 14);
            this.chHabFab.TabIndex = 10;
            this.chHabFab.UseVisualStyleBackColor = true;
            // 
            // btCargar
            // 
            this.btCargar.Location = new System.Drawing.Point(129, 281);
            this.btCargar.Name = "btCargar";
            this.btCargar.Size = new System.Drawing.Size(158, 23);
            this.btCargar.TabIndex = 11;
            this.btCargar.Text = "Crear";
            this.btCargar.UseVisualStyleBackColor = true;
            this.btCargar.Click += new System.EventHandler(this.btCargar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(338, 281);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(158, 23);
            this.btCancelar.TabIndex = 12;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lblTambo
            // 
            this.lblTambo.AutoSize = true;
            this.lblTambo.Location = new System.Drawing.Point(44, 71);
            this.lblTambo.Name = "lblTambo";
            this.lblTambo.Size = new System.Drawing.Size(50, 13);
            this.lblTambo.TabIndex = 14;
            this.lblTambo.Text = "IdLacteo tambo";
            // 
            // cbTanques
            // 
            this.cbTanques.FormattingEnabled = true;
            this.cbTanques.Location = new System.Drawing.Point(129, 30);
            this.cbTanques.Name = "cbTanques";
            this.cbTanques.Size = new System.Drawing.Size(367, 21);
            this.cbTanques.TabIndex = 15;
            this.cbTanques.SelectedValueChanged += new System.EventHandler(this.cbTanques_SelectedValueChanged);
            // 
            // cbTambos
            // 
            this.cbTambos.FormattingEnabled = true;
            this.cbTambos.Location = new System.Drawing.Point(129, 71);
            this.cbTambos.Name = "cbTambos";
            this.cbTambos.Size = new System.Drawing.Size(367, 21);
            this.cbTambos.TabIndex = 16;
            // 
            // FrmMateriaPrima
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 319);
            this.Controls.Add(this.cbTambos);
            this.Controls.Add(this.cbTanques);
            this.Controls.Add(this.lblTambo);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btCargar);
            this.Controls.Add(this.chHabFab);
            this.Controls.Add(this.lblHabilitado);
            this.Controls.Add(this.lblLegajoTecnico);
            this.Controls.Add(this.lblIndiceAcidez);
            this.Controls.Add(this.lblDesripcion);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.txtLegajoTecnico);
            this.Controls.Add(this.txtIndiceAcidez);
            this.Controls.Add(this.txtDescripcion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMateriaPrima";
            this.Text = "Materia Prima";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtIndiceAcidez;
        private System.Windows.Forms.TextBox txtLegajoTecnico;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblDesripcion;
        private System.Windows.Forms.Label lblIndiceAcidez;
        private System.Windows.Forms.Label lblLegajoTecnico;
        private System.Windows.Forms.Label lblHabilitado;
        private System.Windows.Forms.CheckBox chHabFab;
        private System.Windows.Forms.Button btCargar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lblTambo;
        private System.Windows.Forms.ComboBox cbTanques;
        private System.Windows.Forms.ComboBox cbTambos;
    }
}