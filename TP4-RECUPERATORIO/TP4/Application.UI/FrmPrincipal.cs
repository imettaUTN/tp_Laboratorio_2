using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading;
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
            RefreshDataGrid();

        }
        private void RefreshDataGrid()
        {
            try
            {
                dtgLacteos.DataSource = null;
                List<Lacteo> lacteosList = LacteoDAO.Read();
                System.ComponentModel.BindingList<Lacteo> lacteosDG = new System.ComponentModel.BindingList<Lacteo>(lacteosList);
                dtgLacteos.DataSource = lacteosDG;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede actualizar el listado de lacteos: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            FrmLacteo frm = new FrmLacteo(ref lacteos, Enumerados.Operaciones.ALTA);
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
                FrmLacteo frm = new FrmLacteo(ref lacteos, Enumerados.Operaciones.MODIFICACION, ((Lacteo)dtgLacteos.CurrentRow.DataBoundItem).IdLacteo);
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
                FrmLacteo frm = new FrmLacteo(ref lacteos, Enumerados.Operaciones.BAJA, ((Lacteo)dtgLacteos.CurrentRow.DataBoundItem).IdLacteo);
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

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtgLacteos.RowCount > 0)
            {
                //cierro los hilos abiertos si aun continuan abiertos
                ((Lacteo)dtgLacteos.CurrentRow.DataBoundItem).CerrarHilos();
            }
        }
    }
}
