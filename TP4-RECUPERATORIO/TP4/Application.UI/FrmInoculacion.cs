using Application.Enumerados;
using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using Application.UIModels;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmInoculacion : Form
    {
        private int idinforme;
        private string regexValidationDouble = @"^[0-9]{1,2}(\.[0-9]{1,2})?$";
        private RepositorioAditivos aditivos;
        private string tipoProducto;
        private InformeInoculado inf;
        public FrmInoculacion(string tipoProducto, Operaciones eOperaciones, ref RepositorioAditivos aditivos, int idInformeP = 0)
        {
            InitializeComponent();
            this.IdInforme = idInformeP;
            if (eOperaciones == Operaciones.ALTA)
            {
                btActualizar.Visible = false;
                btEliminar.Visible = false;
            }
            else if (eOperaciones == Operaciones.MODIFICACION)
            {
                btGenerarInforme.Visible = false;
                btEliminar.Visible = false;
            }
            else
            {
                btGenerarInforme.Visible = false;
                btActualizar.Visible = false;
                btEliminar.Visible = false;

            }
            this.tipoProducto = tipoProducto;
            this.aditivos = new RepositorioAditivos();
            this.aditivos = aditivos;
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();

            foreach (DisplayObject mp in PersonaDAO.LeerTecnicosParaCombo())
            {
                objects.Add(mp);
            }
            cboTecnico.ValueMember = null;
            cboTecnico.DisplayMember = "Name";
            cboTecnico.DataSource = objects;

            if (eOperaciones == Operaciones.MODIFICACION)
            {
                this.RefreshDataGrid();
            }
            if (idInformeP > 0)
            {
                inf = InformeInoculado.Leer(idinforme);
                if (!(inf is null))
                {
                    foreach (DisplayObject dis in objects)
                    {
                        if (dis.Value == inf.LegajoTecnico)
                        {
                            cboTecnico.SelectedItem = dis;
                        }
                    }
                    txtTemperatura.Text = inf.TemperaturaCalentamiento.ToString();
                    txtEnfriamiento.Text = inf.TemperaturaEnfriamiento.ToString();
                    chkCalentado.Checked = inf.TemperaturaCalentamientoAutorizada;
                    chkEnfriado.Checked = inf.TemperaturaEnfriamientoAutorizada;
                    chkMezclado.Checked = inf.MezclaAutorizada;
                }
            }
        }

        public int IdInforme { get { return idinforme; } set { this.idinforme = value; } }

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

        private void btCalentar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            //por si cambio el separador de decimales siempre es .
            txtTemperatura.Text.Replace(",", ".");
            if (!Regex.IsMatch(txtTemperatura.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (txtTemperatura.Text.ToInt() <= 0)
            {
                MessageBox.Show("La temperatura debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (sinErrores)
            {
                MessageBox.Show("Calentando el producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Alcanzando los " + txtTemperatura.Text + " °C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Temperatura " + txtTemperatura.Text + " °C  alcanzada ...");
                Thread.Sleep(1000);
                MessageBox.Show("Calentamiento del producto finalizado ...");
                chkCalentado.Checked = true;
            }
        }

        private void btMezclarAditivos_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de mezclar el producto", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (sinErrores)
            {
                foreach (AditivoProducto aditivo in aditivos.GetAll())
                {
                    MessageBox.Show("Incorporando aditivo :" + aditivo.Descripcion);
                    Thread.Sleep(1000);
                }
                MessageBox.Show("Mezclando productos ..");
                Thread.Sleep(1000);
                MessageBox.Show("Mezcla finalizada ..");
                chkMezclado.Checked = true;
                //guardo el xml serializado de los aditivos usados, luego lo voy a pasar en la db cuando grabe el producto
                AditivoProducto.Guardar(aditivos.GetAll());
            }
        }

        private void btEnfriar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkMezclado.Checked)
            {
                MessageBox.Show("Debe mezclar el producto antes de estandarizar los solidos", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de estandarizar los solidos", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            //por si cambio el separador de decimales siempre es .
            txtEnfriamiento.Text = txtEnfriamiento.Text.Replace(",", ".");
            if (!Regex.IsMatch(txtEnfriamiento.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura de enfriamiento debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (txtEnfriamiento.Text.ToInt() <= 0)
            {
                MessageBox.Show("La temperatura de enfriamiento debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (sinErrores)
            {
                MessageBox.Show("Enfriando el producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Alcanzando los " + txtEnfriamiento.Text + " °C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Temperatura " + txtEnfriamiento.Text + " °C  alcanzada ...");
                Thread.Sleep(1000);
                MessageBox.Show("Enfriamiento del producto finalizado ...");
                chkEnfriado.Checked = true;
            }
        }

        private void btGenerarInforme_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;

            if (!chkMezclado.Checked)
            {
                MessageBox.Show("Debe mezclar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (!chkEnfriado.Checked)
            {
                MessageBox.Show("Debe enfriar el  producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkCalentado.Checked && chkMezclado.Checked && chkEnfriado.Checked;
                    inf = new InformeInoculado(legajo, txtTemperatura.Text.ToDouble(), chkCalentado.Checked, txtEnfriamiento.Text.ToDouble(), chkEnfriado.Checked, chkMezclado.Checked, informeAutorizado, 0);
                    this.IdInforme = inf.Grabar();

                    MessageBox.Show("Informe generado ok", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se puede crear el informe: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.LogException(ex.Message);
                    this.DialogResult = DialogResult.Abort;
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;

            if (!chkMezclado.Checked)
            {
                MessageBox.Show("Debe mezclar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (!chkEnfriado.Checked)
            {
                MessageBox.Show("Debe enfriar el  producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }
            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkCalentado.Checked && chkMezclado.Checked && chkEnfriado.Checked;
                    inf = new InformeInoculado(legajo, txtTemperatura.Text.ToDouble(), chkCalentado.Checked, txtEnfriamiento.Text.ToDouble(), chkEnfriado.Checked, chkMezclado.Checked, informeAutorizado, 0);
                    inf.IdInforme = this.IdInforme;
                    if (inf.Actualizar())
                    {
                        MessageBox.Show("Informe generado ok", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                    }
                    else { this.DialogResult = DialogResult.Abort; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se puede actualizar el informe: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.LogException(ex.Message);
                    this.DialogResult = DialogResult.Abort;
                }
                finally
                {
                    this.Close();
                }
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(this.inf is null))
                {
                    inf.Eliminar();
                }
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede eliminar el informe: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
