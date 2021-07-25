using Application.Enumerados;
using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.UIModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmEstandarizar : Form
    {
        private int idinforme;
        private string regexValidationDouble = @"^[0-9]{1,2}(\.[0-9]{1,2})?$";
        private string tipoProducto;
        private InformeEstandarizado inf;
        public FrmEstandarizar( string tipoProducto, Operaciones eOperaciones, int idInformeP = 0)
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
            this.tipoProducto = tipoProducto;
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();
            System.ComponentModel.BindingList<DisplayObject> objects2 = new System.ComponentModel.BindingList<DisplayObject>();

            foreach (DisplayObject mp in PersonaDAO.LeerTecnicosParaCombo())
            {
                objects.Add(mp);
            }
            cboTecnico.ValueMember = null;
            cboTecnico.DisplayMember = "Name";
            cboTecnico.DataSource = objects;

            foreach (DisplayObject mp in Tamizador.LeerTamizadoresParaCombo())
            {
                objects2.Add(mp);
            }
            cboTamizador.ValueMember = null;
            cboTamizador.DisplayMember = "Name";
            cboTamizador.DataSource = objects2;
            InformeEstandarizado.MostrarMensajeEnPantallaInfome += MostrarMensajeEnPantalla;
            if(idInformeP > 0)
            {
                inf = InformeEstandarizado.Leer(idInformeP);
                if(!(inf is null))
                {
                    txtTemperatura.Text = inf.TemperaturaCalentamiento.ToString();
                    txtGrasa.Text = inf.PorcentajeTenorGraso.ToString();
                    txtSolidos.Text = inf.PorcentajeSolidos.ToString();
                    chkCalentado.Checked = inf.TemperaturaAutorizada;
                    chkDesengrasado.Checked = inf.TenorGrasoAutorizado;
                    chkSolidoEstandarizado.Checked = inf.PorcentajeSolidoAutorizado;
                }
            }


        }

        public int IdInforme { get { return idinforme; } set { this.idinforme = value; } }

        private void btCalentar_Click(object sender, EventArgs e)
        {
             bool sinErrores = true;
            //por si cambio el separador de decimales siempre es 
            txtTemperatura.Text.Replace(",", ".");
            if (!Regex.IsMatch(txtTemperatura.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if(txtTemperatura.Text.ToInt() <= 0)
            {
                MessageBox.Show("La temperatura debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            
            if(sinErrores)
            {
                // ver si con un hilo no muestro algun mensaje loco de que se esta calentando
                MessageBox.Show("Calentando el producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Alcanzando los " + txtTemperatura.Text  + " °C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Calentamiento del producto finalizado ...");
                chkCalentado.Checked = true;
            }
        }

        private void btDesengrasar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            //por si cambio el separador de decimales siempre es 
            txtGrasa.Text.Replace(",", ".");
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de desengrazar el producto", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (!Regex.IsMatch(txtGrasa.Text, regexValidationDouble))
            {
                MessageBox.Show("El porcentaje de tenor graso debe ser numerico", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;

            }
            
            if(sinErrores)
            {
                MessageBox.Show("Mezclando el producto...");
                Thread.Sleep(1000);
                MessageBox.Show("Quitando grasa excedente ...");
                Thread.Sleep(1000);
                MessageBox.Show("Desengrazamiento correcto, el producto pose un porcentaje de grasa " + txtGrasa.Text + " / 100 ml ...");
                chkDesengrasado.Checked = true;
            }
        }

        private void btSolidos_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            //por si cambio el separador de decimales siempre es 
            txtSolidos.Text.Replace(",", ".");
            if (!Regex.IsMatch(txtSolidos.Text, regexValidationDouble))
            {
                MessageBox.Show("El % de solidos debe ser numerico", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!chkDesengrasado.Checked)
            {
                MessageBox.Show("Debe desengrazar el producto antes de estandarizar los solidos", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de estandarizar los solidos", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if (txtSolidos.Text.ToDouble() <= 0)
            {
                MessageBox.Show("El % de solidos debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }

            if(sinErrores)
            {
                // ver si con un hilo no muestro algun mensaje loco de que se esta calentando
                MessageBox.Show("Filtrando el producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Quitando solidos excedentes ...");
                Thread.Sleep(1000);
                MessageBox.Show("Filtrando nuevamente producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Reduccion de solidos correcto, el producto pose un porcentaje de solidos de " + txtSolidos.Text + " / 100 ml ...");
                chkSolidoEstandarizado.Checked = true;
            }
        }

        private void btGenerarInforme_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!chkDesengrasado.Checked)
            {
                MessageBox.Show("Debe desengrazar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!chkSolidoEstandarizado.Checked)
            {
                MessageBox.Show("Debe estandarizar los solidos del producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if(sinErrores)
            {
                try
                {
                    int idTamizador = ((DisplayObject)cboTamizador.SelectedValue).Value;
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkCalentado.Checked && chkDesengrasado.Checked && chkSolidoEstandarizado.Checked;
                    inf = new InformeEstandarizado(idTamizador, legajo, txtTemperatura.Text.ToDouble(), txtGrasa.Text.ToDouble(), txtSolidos.Text.ToDouble(), chkCalentado.Checked, chkDesengrasado.Checked, chkSolidoEstandarizado.Checked, informeAutorizado, 0);
                    IdInforme = inf.Grabar();
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

        private void FrmEstandarizar_FormClosing(object sender, FormClosingEventArgs e)
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
            if (!chkDesengrasado.Checked)
            {
                MessageBox.Show("Debe desengrazar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!chkCalentado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (!chkSolidoEstandarizado.Checked)
            {
                MessageBox.Show("Debe estandarizar los solidos del producto antes de generar el informe", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (sinErrores)
            {
                try
                {
                    int idTamizador = ((DisplayObject)cboTamizador.SelectedValue).Value;
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkCalentado.Checked && chkDesengrasado.Checked && chkSolidoEstandarizado.Checked;
                    inf = new InformeEstandarizado(idTamizador, legajo, txtTemperatura.Text.ToDouble(), txtGrasa.Text.ToDouble(), txtSolidos.Text.ToDouble(), chkCalentado.Checked, chkDesengrasado.Checked, chkSolidoEstandarizado.Checked, informeAutorizado, 0);
                    inf.IdInforme = this.IdInforme;
                    if (inf.Actualizar())
                    {
                        // Genero en un hilo nuevo el informe de incubado y batido
                        inf.GenerarInformeTecnico();
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
