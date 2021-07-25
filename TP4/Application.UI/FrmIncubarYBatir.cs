using Application.Enumerados;
using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.UIModels;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Application.UI
{

    public partial class FrmIncubarYBatir : Form
    {
        private int idinforme;
        private InformeIncubacionYMezclado inf;
        public FrmIncubarYBatir(Operaciones eOperaciones, int idInformeP = 0)
        {
            InitializeComponent();
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
            this.IdInforme = idInformeP;
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();
            foreach (DisplayObject mp in PersonaDAO.LeerTecnicosParaCombo())
            {
                objects.Add(mp);
            }
            cboTecnico.ValueMember = null;
            cboTecnico.DisplayMember = "Name";
            cboTecnico.DataSource = objects;
            InformeIncubacionYMezclado.MostrarMensajeEnPantallaInfome += MostrarMensajeEnPantalla;
            if (idInformeP > 0)
            {
                inf = InformeIncubacionYMezclado.Leer(idinforme);
                if (!(inf is null))
                {

                    txtTanqueIncubacion.Text = inf.IdTanqueIncubacion.ToString();
                    txtTanqueIncubacion.Text = inf.IdTanqueIncubacion.ToString();
                    txtTemperaturaCalentamiento.Text = inf.TemperaturaCalentamiento.ToString();
                    txtTiempoCalentamiento.Text = inf.TiempoCalentamiento.ToString();
                    txtPH.Text = inf.Ph.ToString();
                    txtHidrogeno.Text = inf.Hidrogeno.ToString();
                    txtAcidez.Text = inf.Acidez.ToString();
                    txtTemperaturaCalentamiento.Text = inf.TemperaturaMezclado.ToString();
                    foreach (DisplayObject dis in objects)
                    {
                        if (dis.Value == inf.LegajoTecnico)
                        {
                            cboTecnico.SelectedItem = dis;
                        }
                    }
                    chkCalentado.Checked = inf.Calentado;
                    chkInoculado.Checked = inf.Inoculado;
                    chkMezclar.Checked = inf.Mezclado;
                }
            }
        }

        public int IdInforme { get { return idinforme; } set { this.idinforme = value; } }
        private void btGenerarInforme_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!chkMezclar.Checked)
            {
                MessageBox.Show("Debe mezclar el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!chkInoculado.Checked)
            {
                MessageBox.Show("Debe inocular el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    // string metodo = ((DisplayObject)cbTipoPasteurizacion.SelectedValue).Name;
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkInoculado.Checked && chkMezclar.Checked;
                    inf = new InformeIncubacionYMezclado(legajo, txtTanqueIncubacion.Text.ToInt(), txtTemperaturaCalentamiento.Text.ToDouble(), txtTiempoCalentamiento.Text.ToInt(), txtPH.Text.ToDouble(), txtHidrogeno.Text.ToDouble(), txtAcidez.Text.ToDouble(), txtTempMezclado.Text.ToDouble(), chkCalentado.Checked, chkInoculado.Checked, chkMezclar.Checked, informeAutorizado, 0);
                    this.IdInforme = inf.Grabar();
                    // Genero en un hilo nuevo el informe de incubado y batido
                    inf.GenerarInformeTecnico();
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

        private void btCalentar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!Regex.IsMatch(txtTanqueIncubacion.Text, @"\d+"))
            {
                MessageBox.Show("El id del tanque debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (txtTemperaturaCalentamiento.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La temperatura debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (txtTiempoCalentamiento.Text.ToDouble() <= 0)
            {
                MessageBox.Show("El tiempo de calentamiento debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (sinErrores)
            {
                MessageBox.Show("Calentando el producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Alcanzando los " + txtTemperaturaCalentamiento.Text + " °C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Aplicando la temperatura durante " + txtTiempoCalentamiento.Text + " horas...");
                Thread.Sleep(1000);
                MessageBox.Show("Calentamiento del producto finalizado ...");
                chkCalentado.Checked = sinErrores;
            }
        }

        private void btInocular_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Primero debe calentar el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!Regex.IsMatch(txtPH.Text, @"\d+"))
            {
                MessageBox.Show("El PH debe ser numerico", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (txtPH.Text.ToDouble() <= 0)
            {
                MessageBox.Show("El PG debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!Regex.IsMatch(txtHidrogeno.Text, @"\d+"))
            {
                MessageBox.Show("El % de hidrogeno debe ser numerico", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (txtHidrogeno.Text.ToDouble() <= 0)
            {
                MessageBox.Show("El % de hidrogeno debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!Regex.IsMatch(txtAcidez.Text, @"\d+"))
            {
                MessageBox.Show("El % de acidez debe ser numerico", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (txtAcidez.Text.ToDouble() <= 0)
            {
                MessageBox.Show("El % de acidez debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (sinErrores)
            {
                MessageBox.Show("Volviendo a calentar el producto a 45 ° C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Midiendo PH producto...");
                Thread.Sleep(1000);
                MessageBox.Show("Validando que el PH sea igual a " + txtPH.Text + "...");
                Thread.Sleep(1000);
                MessageBox.Show("Midiendo % de hidrogeno...");
                Thread.Sleep(1000);
                MessageBox.Show("Validando que el  % de hidrogeno sea igual a " + txtAcidez.Text + "...");
                Thread.Sleep(1000);
                MessageBox.Show("Midiendo % de acidez...");
                Thread.Sleep(1000);
                MessageBox.Show("Validando que el  % de acidez sea igual a " + txtAcidez.Text + "...");
                Thread.Sleep(1000);
                MessageBox.Show("PH, % de Hidrogeno, % Acidez correcto...");
                Thread.Sleep(1000);
                MessageBox.Show("Inoculación del producto finalizada ...");
                chkInoculado.Checked = sinErrores;
            }
        }

        private void btMezclar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkInoculado.Checked)
            {
                MessageBox.Show("Primero debe inocular el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!Regex.IsMatch(txtTempMezclado.Text, @"\d+"))
            {
                MessageBox.Show("La temperatura de mezclado debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (txtTempMezclado.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La temperatura de mezclado debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (sinErrores)
            {
                MessageBox.Show("Volviendo a calentar el producto a " + txtTempMezclado.Text + " ° C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Mezclando el producto...");
                Thread.Sleep(1000);
                MessageBox.Show("Mezclando correcto...");
                Thread.Sleep(1000);
                chkMezclar.Checked = sinErrores;
            }
        }

        private void FrmIncubarYBatir_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(this.inf is null))
            {
                inf.CerrarHilos();
            }
        }

        public void MostrarMensajeEnPantalla(string dato)
        {
            if (this.InvokeRequired)
            {
                MostrarMensaje delegado = new MostrarMensaje(this.MostrarMensajeEnPantalla);

                object[] arrayObjetos = new object[] { dato };

                this.Invoke(delegado, arrayObjetos);
            }
            else
            {
                MessageBox.Show(dato.GetMensaje());
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!chkMezclar.Checked)
            {
                MessageBox.Show("Debe mezclar el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!chkInoculado.Checked)
            {
                MessageBox.Show("Debe inocular el producto", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    // string metodo = ((DisplayObject)cbTipoPasteurizacion.SelectedValue).Name;
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkInoculado.Checked && chkMezclar.Checked;
                    inf = new InformeIncubacionYMezclado(legajo, txtTanqueIncubacion.Text.ToInt(), txtTemperaturaCalentamiento.Text.ToDouble(), txtTiempoCalentamiento.Text.ToInt(), txtPH.Text.ToDouble(), txtHidrogeno.Text.ToDouble(), txtAcidez.Text.ToDouble(), txtTempMezclado.Text.ToDouble(), chkCalentado.Checked, chkInoculado.Checked, chkMezclar.Checked, informeAutorizado, 0);
                    inf.IdInforme = this.IdInforme;
                    if (inf.Actualizar())
                    {// Genero en un hilo nuevo el informe de incubado y batido
                        inf.GenerarInformeTecnico();
                        MessageBox.Show("Informe generado ok", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                    }
                    else { this.DialogResult = DialogResult.Abort; }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se actualizar crear el informe: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
