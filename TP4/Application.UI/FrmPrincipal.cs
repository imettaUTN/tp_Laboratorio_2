using Application.Models;
using Application.Models.Repositorios;
using System;
using System.Windows.Forms;

namespace Application.UI
{

    public partial class FrmPrincipal : Form
    {
        private RepositorioLacteos lacteos;

        public FrmPrincipal()
        {
            InitializeComponent();
            lacteos = new RepositorioLacteos();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }
        private void RefreshDataGrid()
        {
            dtgLacteos.DataSource = null;
            if (!(this.lacteos is null) && this.lacteos.Count() >0)
            {
                dtgLacteos.DataSource = this.lacteos.GetAll();               
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            FrmAgregarLacteo frm = new FrmAgregarLacteo(ref lacteos);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                this.RefreshDataGrid();
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            System.Data.DataTable source = dtgLacteos.DataSource as System.Data.DataTable;

            if (dtgLacteos.RowCount > 0 )
            {
                FrmUpdateLacteo frm = new FrmUpdateLacteo(ref lacteos, (Lacteo)dtgLacteos.CurrentRow.DataBoundItem, true);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("No hay productos en la lista para actualizar ","Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if(dtgLacteos.RowCount > 0 )
            {
                 FrmUpdateLacteo frm = new FrmUpdateLacteo(ref lacteos, (Lacteo)dtgLacteos.CurrentRow.DataBoundItem, false);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("No hay productos en la lista para eliminar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

    }
}
