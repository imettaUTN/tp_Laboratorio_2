using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.UIModels;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Application.UI
{
    public partial class FrmMateriaPrima : Form
    {
        public FrmMateriaPrima()
        {
            InitializeComponent();
            System.ComponentModel.BindingList<DisplayObject> objects = new System.ComponentModel.BindingList<DisplayObject>();                       
            
            foreach(DisplayObject tanque in MateriaPrimaDAO.LeerTanques())
            {
                objects.Add(tanque);
            }
            cbTanques.ValueMember = null;
            cbTanques.DisplayMember = "Name";
            cbTanques.DataSource = objects;

            System.ComponentModel.BindingList<DisplayObject> objects2 = new System.ComponentModel.BindingList<DisplayObject>();


            foreach (DisplayObject tambo in MateriaPrimaDAO.LeerTambos())
            {
                objects2.Add(tambo);
            }
            cboTambos.ValueMember = null;
            cboTambos.DisplayMember = "Name";
            cboTambos.DataSource = objects2;

            System.ComponentModel.BindingList<DisplayObject> objects3 = new System.ComponentModel.BindingList<DisplayObject>();
            foreach (DisplayObject mp in PersonaDAO.LeerTecnicosParaCombo())
            {
                objects3.Add(mp);
            }
            cboTecnico.ValueMember = null;
            cboTecnico.DisplayMember = "Name";
            cboTecnico.DataSource = objects3;


        }

        private void btCargar_Click(object sender, EventArgs e)
        {

            string regexValidationDouble = @"^[0-9]{1,2}(\.[0-9]{1,2})?$";

            if (this.txtIndiceAcidez.Text.ToDouble() <= 0)
            {
                MessageBox.Show("El indice de acidez debe ser mayor a 0", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Debe ingresar una descripcion", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(txtIndiceAcidez.Text, regexValidationDouble))
            {
                MessageBox.Show("El indice de acidez debe ser numerica", "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                MateriaPrima mp = new MateriaPrima();
                Random rd = new Random(DateTime.Now.Millisecond);

                mp.IndiceAcidez = txtIndiceAcidez.Text.ToDouble();
                mp.LegajoTecnicoHabilitante = ((DisplayObject)cboTecnico.SelectedValue).Value;
                mp.Descripcion = txtDescripcion.Text;
                mp.HabilitadoParaFabrica = chkHabFab.Checked;
                mp.IdCertificado = rd.Next();
                if (cboTambos.SelectedValue != null)
                {
                    mp.IdTampo = ((DisplayObject)cboTambos.SelectedValue).Value;
                }
                if (cbTanques.SelectedValue != null)
                {
                    mp.IdTanque = ((DisplayObject)cbTanques.SelectedValue).Value;
                }


                if (MateriaPrima.GuardarMateriaPrima(mp))
                {
                    MateriaPrima.GuardarMateriaPrima(MateriaPrima.LeerMateriaPrima());
                    MessageBox.Show("Se guardo la materia prima");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se puede crear la materia prima: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Close();
        }

        private void cbTanques_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
 
}
