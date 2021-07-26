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
    public partial class FrmEnvasar : Form
    {
        private int idinforme;
        private string regexValidationDouble = @"^[0-9]{1,2}(\.[0-9]{1,2})?$";
        private string tipoProducto;
        private InformeEnvasado inf;
        public FrmEnvasar(string tipoProducto, Operaciones eOperaciones, int idInformeP = 0)
        {
            InitializeComponent();
            if (eOperaciones == Operaciones.ALTA || idInformeP == 0)
            {
                btActualizar.Visible = false;
                btEliminar.Visible = false;
            }
            else if (eOperaciones == Operaciones.MODIFICACION)
            {
                btEnvasar.Visible = false;
                btEliminar.Visible = false;
            }
            else
            {
                btEnvasar.Visible = false;
                btActualizar.Visible = false;
                btEliminar.Visible = false;

            }


            this.tipoProducto = tipoProducto;
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();
            foreach (DisplayObject mp in PersonaDAO.LeerTecnicosParaCombo())
            {
                objects.Add(mp);
            }
            this.IdInforme = idInformeP;
            cboTecnico.ValueMember = null;
            cboTecnico.DisplayMember = "Name";
            cboTecnico.DataSource = objects;
            System.ComponentModel.BindingList<DisplayObject> envases = new System.ComponentModel.BindingList<DisplayObject>();
            if (tipoProducto.Equals("Yoghurt"))
            {
                envases.Add(new DisplayObject("Terrina", 1));
            }
            envases.Add(new DisplayObject("Sachet", 2));
            envases.Add(new DisplayObject("Tetra Pak", 3));
            envases.Add(new DisplayObject("Tetra Pak Pequeño", 3));
            cboTipoEnvase.ValueMember = null;
            cboTipoEnvase.DisplayMember = "Name";
            cboTipoEnvase.DataSource = envases;

            if (idInformeP > 0)
            {
                inf = InformeEnvasado.Leer(idInformeP);
                if (!(inf is null))
                {
                    foreach (DisplayObject dis in objects)
                    {
                        if (dis.Value == inf.LegajoTecnico)
                        {
                            cboTecnico.SelectedItem = dis;
                        }
                    }
                    foreach (DisplayObject env in envases)
                    {
                        if (env.Name == inf.TipoEnvase)
                        {
                            cboTipoEnvase.SelectedItem = env;
                        }
                    }
                    this.txtTemperatura.Text = inf.TemperaturaRefrigeracion.ToString();
                    this.txtAutorizacion.Text = inf.NroAutorizacion.ToString();
                    chkAutorizado.Checked = inf.ProductoAutorizado;
                    chkEtiquetar.Checked = inf.EtiquetaGenerada;
                }
            }

            //if(eOperaciones == Operaciones.BAJA)
            //{
            //    this.bt
            //}
        }
        public int IdInforme { get { return idinforme; } set { this.idinforme = value; } }
        private void btEnvasar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!Regex.IsMatch(txtTemperatura.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura ingresada debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (txtTemperatura.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La temperatura debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (txtAutorizacion.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La autorizacion debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    string envase = ((DisplayObject)cboTipoEnvase.SelectedValue).Name;
                    inf = new InformeEnvasado(legajo, envase, txtTemperatura.Text.ToDouble(), chkEtiquetar.Checked, chkAutorizado.Checked, txtAutorizacion.Text.ToInt(), (chkAutorizado.Checked && chkEtiquetar.Checked), 0);
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
        private void btEtiquetar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generando etiqueta ...");
            Thread.Sleep(1000);
            MessageBox.Show("Imprimiendo etiqueta ...");
            Thread.Sleep(1000);
            MessageBox.Show("Colocando etiqueta ...");
            Thread.Sleep(1000);
            MessageBox.Show("Etiqueta colocando ...");
            chkEtiquetar.Checked = true;
        }
        private void btAutorizarAnmat_Click(object sender, EventArgs e)
        {
            Random ran = new Random(DateTime.Now.Millisecond);
            MessageBox.Show("Generando informacion para enviar a anmat ...");
            Thread.Sleep(1000);
            MessageBox.Show("Conectando con anmat ...");
            Thread.Sleep(1000);
            MessageBox.Show("Solicitando autorizacion ...");
            Thread.Sleep(1000);
            MessageBox.Show("Autorizacion realizada ...");
            chkAutorizado.Checked = true;
            txtAutorizacion.Text = ran.Next().ToString();

        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            bool sinErrores = true;
            if (!Regex.IsMatch(txtTemperatura.Text, regexValidationDouble))
            {
                MessageBox.Show("La temperatura ingresada debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (txtTemperatura.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La temperatura debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (txtAutorizacion.Text.ToDouble() <= 0)
            {
                MessageBox.Show("La autorizacion debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sinErrores = false;
            }
            if (sinErrores)
            {
                try
                {
                    int legajo = ((DisplayObject)cboTecnico.SelectedValue).Value;
                    string envase = ((DisplayObject)cboTipoEnvase.SelectedValue).Name;
                    inf = new InformeEnvasado(legajo, envase, txtTemperatura.Text.ToDouble(), chkEtiquetar.Checked, chkAutorizado.Checked, txtAutorizacion.Text.ToInt(), (chkAutorizado.Checked && chkEtiquetar.Checked), 0);
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
