using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using Application.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();

            foreach (DisplayObject mp in AditivosDAO.LeerAditivos())
            {
                objects.Add(mp);
            }
            cboDescripcion.ValueMember = null;
            cboDescripcion.DisplayMember = "Name";
            cboDescripcion.DataSource = objects;
        }

        /// <summary>
        /// Agrega un aditivo a la lista de aditivos del producto
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAdd_Click(object sender, EventArgs e)
        {
           string regexValidationDouble = @"^[0-9]{1,2}(\.[0-9]{1,2})?$";

            if (this.txtCantidad.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(txtCantidad.Text, regexValidationDouble))
            {
                MessageBox.Show("La cantidad debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            { 
                AditivoProducto aditivo = new AditivoProducto()
                {
                    Cantidad = this.txtCantidad.Text.ToDouble(),
                    Descripcion = ((DisplayObject)cboDescripcion.SelectedValue).Name,
                    ID = ((DisplayObject)cboDescripcion.SelectedValue).Value,
                    Tipo = cboTipo.SelectedItem.ToString()
                };
                repositorioAditivos.Create(aditivo);
                this.DialogResult = DialogResult.OK;
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
        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
