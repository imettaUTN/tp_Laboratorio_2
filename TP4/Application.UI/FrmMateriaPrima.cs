using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.UIModels;
using System;
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
            cbTambos.ValueMember = null;
            cbTambos.DisplayMember = "Name";
            cbTambos.DataSource = objects2;
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaPrima mp = new MateriaPrima();

                mp.IndiceAcidez = Convert.ToDouble(txtIndiceAcidez.Text);
                mp.LegajoTecnicoHabilitante = Convert.ToInt32(txtLegajoTecnico.Text);
                mp.Descripcion = txtDescripcion.Text;
                mp.HabilitadoParaFabrica = chHabFab.Checked;            

                if (cbTambos.SelectedValue != null)
                {
                    mp.IdTampo = ((DisplayObject)cbTambos.SelectedValue).Value;
                }
                if (cbTanques.SelectedValue != null)
                {
                    mp.IdTanque = ((DisplayObject)cbTanques.SelectedValue).Value;
                }


                if (MateriaPrima.GuardarMateriaPrima(mp))
                {
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
