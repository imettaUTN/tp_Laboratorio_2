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
    public partial class FrmAddAditivo : Form
    {
        private RepositorioAditivos repositorioAditivos;

        public FrmAddAditivo(ref RepositorioAditivos repositorioAditivos)
        {
            this.repositorioAditivos = repositorioAditivos;
            InitializeComponent();
        }

        /// <summary>
        /// Agrega un aditivo a la lista de aditivos del producto
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            { 
                AditivoProducto aditivo = new AditivoProducto()
                {
                    Cantidad = Convert.ToDouble(this.txtCantidad.Text),
                    Descripcion = this.txtDescripcion.Text,
                    Tipo = cbTipo.SelectedItem.ToString()
                };
                repositorioAditivos.Create(aditivo);
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
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
