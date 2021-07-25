using Application.Enumerados;
using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.Models.Repositorios;
using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmLacteo : Form
    {
        private RepositorioAditivos aditivos;
        private RepositorioLacteos lacteos;
        private string tipoProducto;
        private Dictionary<string, int> IdInformes;
        Lacteo lacteoNuevo;
        private Operaciones operacion;
        private int idLacteoProducto;
        private bool borroInformesAsociados;
        public FrmLacteo(ref RepositorioLacteos lacteos, Operaciones operacion, int IdLacteo = 0)
        {
            InitializeComponent();
            borroInformesAsociados = true;
            this.IdLacteo = IdLacteo;
            if (operacion == Operaciones.ALTA)
            {
                btActualizar.Visible = false;
                btEliminar.Visible = false;
            }
            else if (operacion == this.operacion)
            {
                btAgregarLacteo.Visible = false;
                btEliminar.Visible = false;
            }
            else
            {
                btAgregarLacteo.Visible = false;
                btActualizar.Visible = false;
            }

            MateriaPrima materiaPrima = null;
            this.lacteos = lacteos;
            this.operacion = operacion;
            this.aditivos = new RepositorioAditivos();
            DisplayObject selectedMateriaPrima = null;
            System.ComponentModel.BindingList<DisplayObject> tiposProducto = new System.ComponentModel.BindingList<DisplayObject>();

            if (operacion != Operaciones.ALTA)
            {
                lacteoNuevo = LacteoDAO.ReadById(IdLacteo);
                if (!(lacteoNuevo is null))
                {
                    materiaPrima = MateriaPrimaDAO.ReadMateriaPrimaPorId(lacteoNuevo.IdMateriaPrima);
                    lblIdInformeEstandarizado.Text = lacteoNuevo.InformeEstandarizado.ToString();
                    lblIdInformePasteurizar.Text = lacteoNuevo.InformePasteurizado.ToString();
                    lblIdInformeInoculacion.Text = lacteoNuevo.InformeInoculado.ToString();
                    if (lacteoNuevo.TipoProducto.Equals("Yogurth"))
                    {
                        lblIdInformeIncubarYMezclar.Text = ((Yogurth)lacteoNuevo).InformeIncubacionYMezcla.ToString();
                        chkIncubadoMezclado.Checked = ((Yogurth)lacteoNuevo).IncubadoyMezclado;
                        tiposProducto.Add(new DisplayObject("Yogurth", 2));
                    }
                    else
                    {
                        tiposProducto.Add(new DisplayObject("Leche", 1));
                    }
                    lblInformeEnvasado.Text = lacteoNuevo.InformeEnvasado.ToString();
                    chkEstandarizar.Checked = lacteoNuevo.Estandarizado;
                    chkPasteurizar.Checked = lacteoNuevo.Pasteurizado;
                    chkInoculacion.Checked = lacteoNuevo.Inoculado;
                    chkEnvasar.Checked = lacteoNuevo.Envasado;

                }
            }
            else
            {
                tiposProducto.Add(new DisplayObject("Leche", 1));
                tiposProducto.Add(new DisplayObject("Yogurth", 2));
            }

            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();

            foreach (DisplayObject mp in MateriaPrimaDAO.LeerMateriaPrimaParaCombo())
            {
                if (!(materiaPrima is null))
                {
                    if (mp.Value == materiaPrima.IdMateriaPrima)
                    {
                        selectedMateriaPrima = mp;
                    }
                }
                objects.Add(mp);
            }
            cboMateriaPrima.ValueMember = null;
            cboMateriaPrima.DisplayMember = "Name";
            cboMateriaPrima.DataSource = objects;

            cboTipo.ValueMember = null;
            cboTipo.DisplayMember = "Name";
            cboTipo.DataSource = tiposProducto;

            if (!(selectedMateriaPrima is null))
            {
                cboMateriaPrima.SelectedItem = selectedMateriaPrima;
            }
            IdInformes = new Dictionary<string, int>();
            //Suscribo al evento de mostrar pantalla
            Leche.MostrarMensajeEnPantalla += MostrarMensajePantalla;
            Yogurth.MostrarMensajeEnPantalla += MostrarMensajePantalla;
        }


        public int IdLacteo
        {
            get { return this.idLacteoProducto; }
            set { this.idLacteoProducto = value; }
        }
        public bool BorroInformesAsociados
        {
            get { return this.borroInformesAsociados; }
            set { this.borroInformesAsociados = value; }
        }

        /// <summary>
        /// Agrega un lacteo a la lista de productos
        /// Tema exepciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAgregarLacteo_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (((DisplayObject)cboTipo.SelectedValue).Name.Equals("Leche"))
                {
                    lacteoNuevo = new Leche();
                }
                else
                {
                    lacteoNuevo = new Yogurth(chkIncubadoMezclado.Checked, lblIdInformeIncubarYMezclar.Text.ToInt());
                }
                lacteoNuevo.Aditivos = aditivos.GetAll();
                lacteoNuevo.Pasteurizado = chkPasteurizar.Checked;
                lacteoNuevo.InformePasteurizado = lblIdInformePasteurizar.Text.ToInt();
                lacteoNuevo.Estandarizado = chkEstandarizar.Checked;
                lacteoNuevo.InformeEstandarizado = lblIdInformeEstandarizado.Text.ToInt();
                lacteoNuevo.Inoculado = chkInoculacion.Checked;
                lacteoNuevo.InformeInoculado = lblIdInformeInoculacion.Text.ToInt();
                lacteoNuevo.Envasado = chkEnvasar.Checked;
                lacteoNuevo.InformeEnvasado = lblInformeEnvasado.Text.ToInt();
                lacteoNuevo.IdMateriaPrima = ((DisplayObject)cboMateriaPrima.SelectedValue).Value;
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

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.BorroInformesAsociados = false;
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
                MessageBox.Show(dato.GetMensaje());
            }
        }

        private void cmbTipo_SelectedValueChanged(object sender, EventArgs e)
        {
            this.tipoProducto = ((DisplayObject)cboTipo.SelectedValue).Name;
            lblIdInformeIncubarYMezclar.Visible = (this.tipoProducto == "Yogurth");
            btInocularYMezclar.Visible = (this.tipoProducto == "Yogurth");
            chkIncubadoMezclado.Visible = (this.tipoProducto == "Yogurth");
            lblInocularYBatir.Visible = (this.tipoProducto == "Yogurth");
        }

        private void btEstandarización_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmEstandarizar frm = null;
            if (this.operacion != Operaciones.ALTA)
            {
                if (!(lacteoNuevo is null))
                {
                    frm = new FrmEstandarizar(lacteoNuevo.TipoProducto, this.operacion, lacteoNuevo.InformeEstandarizado);
                }
            }
            else { frm = new FrmEstandarizar(this.tipoProducto, Operaciones.ALTA); }

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                IdInformes.Add("Estandarizar", frm.IdInforme);
                chkEstandarizar.Checked = true;
                lblIdInformeEstandarizado.Text = frm.IdInforme.ToString();
                if (operacion == Operaciones.ALTA)
                {
                    btEstandarización.Visible = false;
                }
            }
        }

        private void btPasteurizar_Click(object sender, EventArgs e)
        {
            if (!chkEstandarizar.Checked)
            {
                MessageBox.Show("Primero debe estandarizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmPasteurizacion frm = null;

            if (this.operacion != Operaciones.ALTA)
            {
                if (!(lacteoNuevo is null))
                {
                    frm = new FrmPasteurizacion(lacteoNuevo.TipoProducto, this.operacion, lacteoNuevo.InformePasteurizado);
                }
            }
            else { frm = new FrmPasteurizacion(this.tipoProducto, Operaciones.ALTA); }

            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                IdInformes.Add("Pasteurizar", frm.IdInforme);
                chkPasteurizar.Checked = true;
                lblIdInformePasteurizar.Text = frm.IdInforme.ToString();
                if (operacion == Operaciones.ALTA)
                {
                    btPasteurizar.Visible = false;
                }
            }
        }

        private void btInoculacion_Click(object sender, EventArgs e)
        {
            if (!chkEstandarizar.Checked)
            {
                MessageBox.Show("Primero debe estandarizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkPasteurizar.Checked)
            {
                MessageBox.Show("Primero debe pasteurizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmInoculacion frm = null;
            if (this.operacion != Operaciones.ALTA)
            {
                if (!(lacteoNuevo is null))
                {
                    foreach (AditivoProducto ad in AditivoProducto.LeerAditivosLacteo(lacteoNuevo.IdLacteo))
                    {
                        aditivos.Create(ad);
                    }

                    frm = new FrmInoculacion(lacteoNuevo.TipoProducto, this.operacion, ref aditivos, lacteoNuevo.InformeInoculado);
                }
            }
            else
            {
                frm = new FrmInoculacion(this.tipoProducto, Operaciones.ALTA, ref aditivos);
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                IdInformes.Add("Inocular", frm.IdInforme);
                chkInoculacion.Checked = true;
                lblIdInformeInoculacion.Text = frm.IdInforme.ToString();
                if (operacion == Operaciones.ALTA)
                {
                    btInoculacion.Visible = false;
                }
            }
        }

        private void btEnvasar_Click(object sender, EventArgs e)
        {
            if (!chkEstandarizar.Checked)
            {
                MessageBox.Show("Primero debe estandarizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkPasteurizar.Checked)
            {
                MessageBox.Show("Primero debe pasteurizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkInoculacion.Checked)
            {
                MessageBox.Show("Primero debe pasteurizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (btInocularYMezclar.Visible && !chkInoculacion.Checked)
            {
                MessageBox.Show("Primero debe incubar y mezclar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmEnvasar frm = null;
            if (this.operacion != Operaciones.ALTA)
            {
                if (!(lacteoNuevo is null))
                {
                    frm = new FrmEnvasar(lacteoNuevo.TipoProducto, this.operacion, lacteoNuevo.InformeEnvasado);
                }
            }
            else
            {
                frm = new FrmEnvasar(this.tipoProducto, Operaciones.ALTA);
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                IdInformes.Add("Envasar", frm.IdInforme);
                chkEnvasar.Checked = true;
                lblInformeEnvasado.Text = frm.IdInforme.ToString();
                if (operacion == Operaciones.ALTA)
                {
                    btEnvasar.Visible = false;
                }
            }
        }

        private void btInocularYMezclar_Click(object sender, EventArgs e)
        {
            if (!chkEstandarizar.Checked)
            {
                MessageBox.Show("Primero debe estandarizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkPasteurizar.Checked)
            {
                MessageBox.Show("Primero debe pasteurizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!chkInoculacion.Checked)
            {
                MessageBox.Show("Primero debe pasteurizar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FrmIncubarYBatir frm = new FrmIncubarYBatir(Operaciones.ALTA);
            if (this.operacion != Operaciones.ALTA)
            {
                if (!(lacteoNuevo is null))
                {
                    if (lacteoNuevo.TipoProducto.Equals("Yogurth"))
                    {
                        frm = new FrmIncubarYBatir(this.operacion, ((Yogurth)lacteoNuevo).InformeIncubacionYMezcla);
                    }
                }
            }
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                IdInformes.Add("MezclarEIncubar", frm.IdInforme);
                chkIncubadoMezclado.Checked = true;
                lblIdInformeIncubarYMezclar.Text = frm.IdInforme.ToString();
                if (operacion == Operaciones.ALTA)
                {
                    btInocularYMezclar.Visible = false;
                }
            }
        }

        private void FrmAgregarLacteo_FormClosing(object sender, FormClosingEventArgs e)
        {
         //si es un alta y cancelo la creacion del producto eliminos los informes generados
            if (this.operacion == Operaciones.ALTA || ( this.operacion == Operaciones.BAJA && this.BorroInformesAsociados))
            {
                if (chkEstandarizar.Checked || chkPasteurizar.Checked || chkInoculacion.Checked || chkEnvasar.Checked || (chkIncubadoMezclado.Visible && chkIncubadoMezclado.Checked))
                {
                    if (lacteoNuevo is null)
                    {
                        if (((DisplayObject)cboTipo.SelectedValue).Name.Equals("Leche"))
                        {
                            lacteoNuevo = new Leche();
                        }
                        else
                        {
                            lacteoNuevo = new Yogurth();
                        }
                        //mediante un hilo llamo a eliminar los informes generados, ya que si cancelo la creacion del producto no deberia tener asociados informes
                        lacteoNuevo.IniciarEliminacionInformesDB(IdInformes);
                    }
                }
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (cboTipo.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar un tipo de producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMateriaPrima.SelectedItem is null)
            {
                MessageBox.Show("Primero debe seleccionar una materia prima", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (((DisplayObject)cboTipo.SelectedValue).Name.Equals("Leche"))
                {
                    lacteoNuevo = new Leche();
                }
                else
                {
                    lacteoNuevo = new Yogurth(chkIncubadoMezclado.Checked, lblIdInformeIncubarYMezclar.Text.ToInt());
                }
                lacteoNuevo.IdLacteo = IdLacteo;
                lacteoNuevo.Aditivos = aditivos.GetAll();
                lacteoNuevo.Pasteurizado = chkPasteurizar.Checked;
                lacteoNuevo.InformePasteurizado = lblIdInformePasteurizar.Text.ToInt();
                lacteoNuevo.Estandarizado = chkEstandarizar.Checked;
                lacteoNuevo.InformeEstandarizado = lblIdInformeEstandarizado.Text.ToInt();
                lacteoNuevo.Inoculado = chkInoculacion.Checked;
                lacteoNuevo.InformeInoculado = lblIdInformeInoculacion.Text.ToInt();
                lacteoNuevo.Envasado = chkEnvasar.Checked;
                lacteoNuevo.InformeEnvasado = lblInformeEnvasado.Text.ToInt();
                lacteoNuevo.IdMateriaPrima = ((DisplayObject)cboMateriaPrima.SelectedValue).Value;
                lacteos.Create(lacteoNuevo);
                //llamo mediante hilo al guardado en la db
                lacteoNuevo.IniciarActualizacionDB();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede actualizar el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogException(ex.Message);
                this.DialogResult = DialogResult.Abort;
            }
            finally
            {

                this.Close();
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(lacteoNuevo is null))
                {
                    lacteoNuevo.IniciarEliminacionDB();
                }
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede eliminar el lacteo: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
