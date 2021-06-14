using Application.Models;
using Application.Models.Logs;
using Application.Models.Repositorios;
using System;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmUpdateLacteo : Form
    {
        private RepositorioLacteos lacteos;
        private RepositorioAditivos aditivos;
        private bool esActualizacion;
        private Lacteo lacteoAEditar;
        public FrmUpdateLacteo(ref RepositorioLacteos lacteos, Lacteo lacteo, bool actualizo)
        {
            InitializeComponent();
            this.lacteos = lacteos;
            this.txtIdOlla.Text = lacteo.IdOllaPasteurizacion.ToString();
            this.cmbMetodo.SelectedItem = lacteo.MetodoPasteurizacion;
            this.cmbTipo.SelectedItem = lacteo.TipoProducto;
            this.cbMP.Checked = lacteo.MateriaPrimaAutorizada;
            this.cbEstandarizado.Checked = lacteo.Estandarizado;
            this.cbPasteurizado.Checked = lacteo.Pasteurizado;
            this.cbEnfriado.Checked = lacteo.Enfriado;
            this.lacteoAEditar = lacteo;
            this.esActualizacion = actualizo;
            foreach (AditivoProducto aditivo in lacteo.Aditivos)
            {
                aditivos.Create(aditivo);
            }
        }

        public RepositorioLacteos ListaLacteos
        {
            get { return this.lacteos; }
        }

        /// <summary>
        /// Agrega un aditivo a la lista de aditivos
        /// Tema: Exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarAditivo_Click(object sender, EventArgs e)
        {
            try
            {
                //paso la coleccion de aditivos por referencia para tener los cambios
                FrmAddAditivo frm = new FrmAddAditivo(ref aditivos);
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    this.RefreshDataGrid();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede crear el aditivo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {
                this.Close();
            }

        }
        private void RefreshDataGrid()
        {
            dtgAditivos.DataSource = null;
            if (this.aditivos is null)
            {
                dtgAditivos.DataSource = this.aditivos.GetAll();
            }
        }

        /// <summary>
        /// Actualizar un aditivo
        /// Tema: Exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btActualizarAditivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgAditivos.RowCount > 0)
                {
                    FrmUpdateAditivo frm = new FrmUpdateAditivo(ref this.aditivos, (AditivoProducto)dtgAditivos.CurrentRow.DataBoundItem, true);
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
                    MessageBox.Show("No hay aditivos en la lista para actualizar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede actualizar el aditivo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {
                this.Close();
            }

        }

        /// <summary>
        /// borrar un aditivo a la lista de aditivos
        /// Tema: Exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btDeleteAditivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgAditivos.RowCount > 0)
                {
                    FrmUpdateAditivo frm = new FrmUpdateAditivo(ref this.aditivos, (AditivoProducto)dtgAditivos.CurrentRow.DataBoundItem, false);
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
                    MessageBox.Show("No hay aditivos en la lista para eliminar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede eliminar el aditivo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {
                this.Close();
            }
        }



        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblMetodo.Visible = !cmbTipo.SelectedItem.Equals("Leche");
            cmbMetodo.Visible = !cmbTipo.SelectedItem.Equals("Leche");

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Actualiza un producto  en la lista de productos lacteos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btActualizaLacteo_Click(object sender, EventArgs e)
        {
            try
            {
                lacteoAEditar.Aditivos = aditivos.GetAll();
                lacteoAEditar.MateriaPrimaAutorizada = cbMP.Checked;
                lacteoAEditar.Pasteurizado = cbPasteurizado.Checked;
                lacteoAEditar.Enfriado = cbEnfriado.Checked;
                lacteoAEditar.Estandarizado = cbEstandarizado.Checked;
                lacteoAEditar.IdOllaPasteurizacion = Convert.ToInt32(txtIdOlla.Text);
                lacteoAEditar.MetodoPasteurizacion = cmbMetodo.SelectedItem.ToString();
                lacteoAEditar.TipoProducto = cmbTipo.SelectedItem.ToString();
                lacteos.Update(lacteoAEditar);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede crear el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {
                this.Close();
            }
        }

        private void FrmUpdateLacteo_Load(object sender, EventArgs e)
        {
            try
            {
                this.btActualizaLacteo.Visible = esActualizacion;
                this.btEliminar.Visible = !esActualizacion;
                this.btAgregarAditivo.Visible = esActualizacion;
                this.btActualizarAditivo.Visible = esActualizacion;
                this.btDeleteAditivo.Visible = esActualizacion;
                txtIdOlla.Enabled = esActualizacion;
                cmbMetodo.Enabled = esActualizacion;
                cmbTipo.Enabled = esActualizacion;
                cbMP.Enabled = esActualizacion;
                cbEstandarizado.Enabled = esActualizacion;
                cbPasteurizado.Enabled = esActualizacion;
                cbEnfriado.Enabled = esActualizacion;
                RefreshDataGrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede actualizar el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// Elimina un lacteo de la lista de productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.lacteos.Remove(lacteoAEditar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede eliminar el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {
                this.Close();
            }
        }
    }
}
