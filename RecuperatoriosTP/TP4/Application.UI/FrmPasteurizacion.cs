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
   
    public partial class FrmPasteurizacion : Form
    {
        private int idinforme;
        private string regexValidationDouble = @"^[0-9]{1,2}(\.[0-9]{1,2})?$";
        private string tipoProducto;
        InformePasteurizado inf;
        public FrmPasteurizacion(string tipoProducto, Operaciones eOperaciones, int idInformeP = 0)
        {
            InitializeComponent();

            this.IdInforme = idInformeP;
            if(eOperaciones ==  Operaciones.ALTA || idInformeP == 0)
            {
                btActualizar.Visible = false;
                btEliminar.Visible = false;
            }
            else if(eOperaciones == Operaciones.MODIFICACION)
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
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();
            foreach (DisplayObject mp in PersonaDAO.LeerTecnicosParaCombo())
            {
                objects.Add(mp);
            }

            cboTecnico.ValueMember = null;
            cboTecnico.DisplayMember = "Name";
            cboTecnico.DataSource = objects;
            System.ComponentModel.BindingList<DisplayObject> objects2 = new System.ComponentModel.BindingList<DisplayObject>();

            if (tipoProducto.Equals("Yogurth"))
            {
                objects2.Add(new DisplayObject("Baja temperatura", 0));
                objects2.Add(new DisplayObject("Alta temperatura", 1));
                cboTipoPasteurizacion.ValueMember = null;
                cboTipoPasteurizacion.DisplayMember = "Name";
                cboTipoPasteurizacion.DataSource = objects2;
                cboTipoPasteurizacion.Visible = true;
                lblMetodo.Visible = true;
            }
            if(idInformeP > 0)
            {
                inf = InformePasteurizado.Leer(idinforme);
                if(!(inf is null))
                {
                    foreach (DisplayObject dis in objects)
                    {
                        if (dis.Value == inf.LegajoTecnico)
                        {
                            cboTecnico.SelectedItem = dis;
                        }
                    }

                    foreach (DisplayObject dis in objects2)
                    {
                        if (dis.Name == inf.MetodoPasteurizacion)
                        {
                            cboTipoPasteurizacion.SelectedItem = dis;
                        }
                    }
                    txtOllaPasteurizacion.Text = inf.IdOllaPasteurizacion.ToString();
                    txtTemperaturaCalentamiento.Text = inf.TemperaturaCalentamiento.ToString();
                    chkEnfriado.Checked = inf.TemperaturaEnfriamientoAutorizada;
                    chkPasteurizado.Checked = inf.PasteurizacionAutorizada;
                    txtTempEnfriamiento.Text = inf.TemperaturaEnfriamiento.ToString();
                }

            }     
            
        }

        public int IdInforme { get { return idinforme; } set { this.idinforme = value; } }
        private void btEnfriar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
    
            if (!chkPasteurizado.Checked)
            {
                MessageBox.Show("Debe calentar el producto antes de estandarizar los solidos", "Error en el proceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 sinErrores = false;  return;
            }

            //por si cambio el separador de decimales siempre es .
            txtTempEnfriamiento.Text = txtTempEnfriamiento.Text.Replace(",", ".");
            if (!Regex.IsMatch(txtTempEnfriamiento.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura de enfriamiento debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 sinErrores = false;  return;
            }

            if (txtTempEnfriamiento.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La temperatura de enfriamiento debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 sinErrores = false;  return;
            }

            if (sinErrores)
            {
                MessageBox.Show("Enfriando el producto ...");
                Thread.Sleep(1000);
                MessageBox.Show("Alcanzando los " + txtTempEnfriamiento.Text + " °C ...");
                Thread.Sleep(1000);
                MessageBox.Show("Temperatura " + txtTempEnfriamiento.Text + " °C  alcanzada ...");
                Thread.Sleep(1000);
                MessageBox.Show("Enfriamiento del producto finalizado ...");
                chkEnfriado.Checked = true;
            }
        }

        private void btPasteurizar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            //por si cambio el separador de decimales siempre es .
            txtTemperaturaCalentamiento.Text = txtTemperaturaCalentamiento.Text.Replace(",", ".");
            int metodoPasteurizacion = -1;
            if(!(cboTipoPasteurizacion.SelectedValue is null))
            {
                metodoPasteurizacion = ((DisplayObject)cboTipoPasteurizacion.SelectedValue).Value;
            }
            if (!Regex.IsMatch(txtTemperaturaCalentamiento.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 sinErrores = false;  return;
            }

            if (txtTemperaturaCalentamiento.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La temperatura debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 sinErrores = false;  return;
            }

            if (sinErrores)
            {
                MessageBox.Show("Calentando el producto ...");
                Thread.Sleep(1000);

                if (cboTipoPasteurizacion.Visible && metodoPasteurizacion == 1)
                {
                    MessageBox.Show("Subiendo la  temperatura a 400 °C ...");
                    Thread.Sleep(1000);
                    MessageBox.Show("estabilizando  temperatura en 400 °C ...");
                    Thread.Sleep(1000);
                    MessageBox.Show("Bajando temperatura preparacion ...");
                    Thread.Sleep(1000);
                }

                if (cboTipoPasteurizacion.Visible && metodoPasteurizacion == 0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        MessageBox.Show("Subiendo 1° la  temperatura ...");
                        Thread.Sleep(1000);
                    }
                }
                MessageBox.Show("Temperatura " + txtTemperaturaCalentamiento.Text + " °C  alcanzada ...");
                Thread.Sleep(1000);
                MessageBox.Show("Realizando analisis de producto PH y acidez ...");
                Thread.Sleep(1000);
                MessageBox.Show("Analisis finalizado ok ...");
                MessageBox.Show("Pasteurizacion del producto finalizado ...");
                chkPasteurizado.Checked = true;
            }
        }

        private void btGenerarInforme_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;

            if(!(chkEnfriado.Checked || chkPasteurizado.Checked))
            {
                MessageBox.Show("Debe Pasteurizar y Enfriar el producto para generar el informe", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (!Regex.IsMatch(txtOllaPasteurizacion.Text, @"\d+"))
            {
                MessageBox.Show("El id de olla debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  sinErrores = false;  return; 
            }

            if (txtOllaPasteurizacion.Text.ToInt() <= 0)
            {
                MessageBox.Show("El id de olla debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 sinErrores = false;  return;
            }

            if(sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    string metodo = string.Empty;
                    if(cboTipoPasteurizacion.Visible)
                    {
                        metodo =  ((DisplayObject)cboTipoPasteurizacion.SelectedValue).Name;
                    }                  
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkPasteurizado.Checked && chkEnfriado.Checked;
                    inf = new InformePasteurizado(legajo, txtTemperaturaCalentamiento.Text.ToDouble(), chkPasteurizado.Checked, txtTempEnfriamiento.Text.ToDouble(), chkEnfriado.Checked,informeAutorizado, metodo, txtOllaPasteurizacion.Text.ToInt(),0);
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

            if (!(chkEnfriado.Checked || chkPasteurizado.Checked))
            {
                MessageBox.Show("Debe Pasteurizar y Enfriar el producto para generar el informe", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (!Regex.IsMatch(txtOllaPasteurizacion.Text, @"\d+"))
            {
                MessageBox.Show("El id de olla debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (txtOllaPasteurizacion.Text.ToInt() <= 0)
            {
                MessageBox.Show("El id de olla debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false; return;
            }

            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    string metodo = string.Empty;
                    if (cboTipoPasteurizacion.Visible)
                    {
                        metodo = ((DisplayObject)cboTipoPasteurizacion.SelectedValue).Name;
                    }
                    //solo se autoriza si se realizaron todos los pasos
                    bool informeAutorizado = chkPasteurizado.Checked && chkEnfriado.Checked;
                    inf = new InformePasteurizado(legajo, txtTemperaturaCalentamiento.Text.ToDouble(), chkPasteurizado.Checked, txtTempEnfriamiento.Text.ToDouble(), chkEnfriado.Checked, informeAutorizado, metodo, txtOllaPasteurizacion.Text.ToInt(), 0);
                    inf.IdInforme = this.IdInforme;
                    if (inf.Actualizar())
                    {
                        MessageBox.Show("Informe generado ok", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Abort;
                    }
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
                if(!(this.inf is null))
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
