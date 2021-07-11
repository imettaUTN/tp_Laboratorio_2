using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using Application.UIModels;
using System;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmAgregarLacteo : Form
    {
        private RepositorioAditivos aditivos = new RepositorioAditivos();
        private RepositorioLacteos lacteos;
        Lacteo lacteoNuevo;

        public FrmAgregarLacteo(ref RepositorioLacteos lacteos)
        {
            this.lacteos = lacteos;

            InitializeComponent();

            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();

            foreach (DisplayObject mp in MateriaPrimaDAO.LeerMateriaPrimaParaCombo())
            {
                objects.Add(mp);
            }
            cbMateriaPrima.ValueMember = null;
            cbMateriaPrima.DisplayMember = "Name";
            cbMateriaPrima.DataSource = objects;
            //Suscribo al evento de mostrar pantalla
            Leche.MostrarMensajeEnPantalla += MostrarMensajePantalla;
            Yogurth.MostrarMensajeEnPantalla += MostrarMensajePantalla;


        }
        /// <summary>
        /// Agrega un aditivo de la lista
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarAditivo_Click(object sender, EventArgs e)
        {
            try
            {
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
        /// Actualiza un aditivo de la lista
        /// Tema exepciones
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
                    MessageBox.Show("No hay aditivos en la lista para eliminar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"No se puede actualizar el aditivo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
        }


        /// <summary>
        /// Elimina un aditivo de la lista
        /// Tema exepciones
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
        }

        /// <summary>
        /// Agrega un lacteo a la lista de productos
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarLacteo_Click(object sender, EventArgs e)
        {
            try
            {
                cbPasteurizado.Enabled = false;
                cbEnfriado.Enabled = false;
                cbEstandarizado.Enabled = false;

                if (cmbTipo.SelectedItem.Equals("Leche"))
                {
                    lacteoNuevo = new Leche();
                }
                else
                {
                    lacteoNuevo = new Yogurth();
                }
                
                //le asigno los aditivos al lacteo
                lacteoNuevo.Aditivos = aditivos.GetAll();
                lacteoNuevo.MetodoPasteurizacion = cmbMetodo.SelectedItem.ToString();
                lacteoNuevo.MpAutorizada = true;
                lacteoNuevo.Pasteurizado = cbPasteurizado.Checked;
                lacteoNuevo.Enfriado = cbEnfriado.Checked;
                lacteoNuevo.Estandarizado = cbEstandarizado.Checked;
                lacteoNuevo.IdLacteo = DateTime.Now.Millisecond;
                lacteoNuevo.ProcesarProducto(((DisplayObject)cbMateriaPrima.SelectedValue).Value, Convert.ToInt32(txtIdOlla.Text), cmbMetodo.SelectedItem.ToString());
                lacteos.Create(lacteoNuevo);
                //llamo mediante hilo al guardado en la db
                lacteoNuevo.IniciarGuardadoDB();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede agregar el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
