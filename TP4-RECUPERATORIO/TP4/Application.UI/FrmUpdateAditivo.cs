using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using Application.UIModels;
using System;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmUpdateAditivo : Form
    {
        private RepositorioAditivos repositorioAditivos;
        private AditivoProducto aditivoProducto;
        private bool esActualizacion;
        public FrmUpdateAditivo(ref RepositorioAditivos repositorioAditivos, AditivoProducto aditivo, bool actualizacion)
        {
            InitializeComponent();
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();

            foreach (DisplayObject tanque in AditivosDAO.LeerAditivos())
            {
                objects.Add(tanque);
            }
            cboDescripcion.ValueMember = null;
            cboDescripcion.DisplayMember = "Name";
            cboDescripcion.DataSource = objects;
            this.txtCantidad.Text = aditivo.Cantidad.ToString();
            this.cboDescripcion.SelectedItem = AditivosDAO.LeerAditivo(aditivo.Descripcion);
            this.cbTipo.SelectedItem = aditivo.Tipo;
            this.repositorioAditivos = repositorioAditivos;
            esActualizacion = actualizacion;
            aditivoProducto = aditivo;
        }

        /// <summary>
        /// Actualiza un aditivo de la lista
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                AditivoProducto aditivo = new AditivoProducto()
                {
                    Cantidad = this.txtCantidad.Text.ToDouble(),
                    Descripcion = ((DisplayObject)cboDescripcion.SelectedValue).Name,
                    Tipo = cbTipo.SelectedItem.ToString(),
                    ID = aditivoProducto.ID
                };
                this.repositorioAditivos.Update(aditivo);
                this.DialogResult = DialogResult.OK;

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
        /// Elimina un aditivo de la lista
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                this.repositorioAditivos.Remove(aditivoProducto);
                this.DialogResult = DialogResult.OK;
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
        private void FrmUpdateAditivo_Load(object sender, EventArgs e)
        {
            this.btActualizar.Visible = esActualizacion;
            this.btEliminar.Visible = !esActualizacion;
        }
    }
}

