namespace Application.UI
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.materiaPrimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarMateriaPrimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMateriaPrimaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPersonalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personalToolStripMenuItem,
            this.materiaPrimaToolStripMenuItem,
            this.productosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(844, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // materiaPrimaToolStripMenuItem
            // 
            this.materiaPrimaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarMateriaPrimaToolStripMenuItem,
            this.verMateriaPrimaToolStripMenuItem});
            this.materiaPrimaToolStripMenuItem.Name = "materiaPrimaToolStripMenuItem";
            this.materiaPrimaToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.materiaPrimaToolStripMenuItem.Text = "Materia Prima";
            // 
            // cargarMateriaPrimaToolStripMenuItem
            // 
            this.cargarMateriaPrimaToolStripMenuItem.Name = "cargarMateriaPrimaToolStripMenuItem";
            this.cargarMateriaPrimaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cargarMateriaPrimaToolStripMenuItem.Text = "Cargar Materia Prima";
            this.cargarMateriaPrimaToolStripMenuItem.Click += new System.EventHandler(this.cargarMateriaPrimaToolStripMenuItem_Click);
            // 
            // verMateriaPrimaToolStripMenuItem
            // 
            this.verMateriaPrimaToolStripMenuItem.Name = "verMateriaPrimaToolStripMenuItem";
            this.verMateriaPrimaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.verMateriaPrimaToolStripMenuItem.Text = "Ver Materia Prima";
            this.verMateriaPrimaToolStripMenuItem.Click += new System.EventHandler(this.verMateriaPrimaToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarProductoToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // cargarProductoToolStripMenuItem
            // 
            this.cargarProductoToolStripMenuItem.Name = "cargarProductoToolStripMenuItem";
            this.cargarProductoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargarProductoToolStripMenuItem.Text = "Productos";
            this.cargarProductoToolStripMenuItem.Click += new System.EventHandler(this.cargarProductoToolStripMenuItem_Click);
            // 
            // personalToolStripMenuItem
            // 
            this.personalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarPersonalToolStripMenuItem,
            this.verPersonalToolStripMenuItem});
            this.personalToolStripMenuItem.Name = "personalToolStripMenuItem";
            this.personalToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.personalToolStripMenuItem.Text = "Personal";
            // 
            // cargarPersonalToolStripMenuItem
            // 
            this.cargarPersonalToolStripMenuItem.Name = "cargarPersonalToolStripMenuItem";
            this.cargarPersonalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cargarPersonalToolStripMenuItem.Text = "Cargar Personal";
            this.cargarPersonalToolStripMenuItem.Click += new System.EventHandler(this.cargarPersonalToolStripMenuItem_Click);
            // 
            // verPersonalToolStripMenuItem
            // 
            this.verPersonalToolStripMenuItem.Name = "verPersonalToolStripMenuItem";
            this.verPersonalToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verPersonalToolStripMenuItem.Text = "Ver Personal";
            this.verPersonalToolStripMenuItem.Click += new System.EventHandler(this.verPersonalToolStripMenuItem_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Application.UI.Properties.Resources.descarga;
            this.ClientSize = new System.Drawing.Size(844, 301);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem materiaPrimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarMateriaPrimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarProductoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMateriaPrimaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarPersonalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPersonalToolStripMenuItem;
    }
}