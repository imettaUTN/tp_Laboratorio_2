using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using Application.UIModels;
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
            this.aditivos = new RepositorioAditivos();
            this.lacteos = lacteos;
            this.txtIdOlla.Text = lacteo.IdOllaPasteurizacion.ToString();
            this.cmbMetodo.SelectedItem = lacteo.MetodoPasteurizacion;
            this.cbEstandarizado.Checked = lacteo.Estandarizado;
            this.cbPasteurizado.Checked = lacteo.Pasteurizado;
            this.cbEnfriado.Checked = lacteo.Enfriado;
            this.cmbTipo.SelectedItem = lacteo.TipoProducto;
            this.lacteoAEditar = lacteo;

            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();
            // objects.a
            foreach (DisplayObject mp in MateriaPrimaDAO.LeerMateriaPrimaParaCombo())
            {
                objects.Add(mp);
            }
            this.cbMateriaPrima.ValueMember = null;
            this.cbMateriaPrima.DisplayMember = "Name";
            this.cbMateriaPrima.DataSource = objects;
            this.cbMateriaPrima.SelectedItem = MateriaPrimaDAO.LeerMateriaPrimaParaCombo(lacteo.IdMateriaPrima);
            this.esActualizacion = actualizo;
            foreach (AditivoProducto aditivo in lacteo.Aditivos)
            {
                aditivos.Create(aditivo);
            }
            //Suscribo al evento de mostrar pantalla
            Leche.MostrarMensajeEnPantalla += MostrarMensajePantalla;
            Yogurth.MostrarMensajeEnPantalla += MostrarMensajePantalla;
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
            if (!(this.aditivos is null))
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
                lacteoAEditar.Pasteurizado = cbPasteurizado.Checked;
                lacteoAEditar.Enfriado = cbEnfriado.Checked;
                lacteoAEditar.Estandarizado = cbEstandarizado.Checked;
                lacteoAEditar.IdOllaPasteurizacion = Convert.ToInt32(txtIdOlla.Text);
                lacteoAEditar.MetodoPasteurizacion = cmbMetodo.SelectedItem.ToString();
                lacteoAEditar.TipoProducto = cmbTipo.SelectedItem.ToString();
                lacteos.Update(lacteoAEditar);
                //actualizo a traves de hilo
                lacteoAEditar.IniciarActualizacionDB();
                this.DialogResult = DialogResult.OK;

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
                cbEstandarizado.Enabled = esActualizacion;
                cbPasteurizado.Enabled = esActualizacion;
                cbEnfriado.Enabled = esActualizacion;
                cbMateriaPrima.Enabled = esActualizacion;
                RefreshDataGrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede actualizar el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
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
                this.DialogResult = DialogResult.OK;
                //llamo mediante helido a eliminarlo  en la db
                lacteoAEditar.IniciarEliminacionDB();
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
        public void MostrarMensajePantalla(string dato)
        {
            if (this.InvokeRequired)
            {
                MostrarMensaje delegado = new MostrarMensaje(this.MostrarMensajePantalla);

                object[] arrayObjetos = new object[] { dato };

                this.Invoke(delegado, arrayObjetos);
            }
            else
            {
                MessageBox.Show(dato);
            }
        }
    }
}
