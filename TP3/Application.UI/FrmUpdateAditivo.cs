using Application.Models;
using Application.Models.Logs;
using Application.Models.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.txtCantidad.Text = aditivo.Cantidad.ToString();
            this.txtDescripcion.Text = aditivo.Descripcion;
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
                    Cantidad = Convert.ToDouble(this.txtCantidad.Text),
                    Descripcion = this.txtDescripcion.Text,
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
            Close();
            }
        }
 }

