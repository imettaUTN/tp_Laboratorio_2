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
            cboTambos.ValueMember = null;
            cboTambos.DisplayMember = "Name";
            cboTambos.DataSource = objects2;
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaPrima mp = new MateriaPrima();
                Random rd = new Random(DateTime.Now.Millisecond);

                mp.IndiceAcidez = txtIndiceAcidez.Text.ToDouble();
                mp.LegajoTecnicoHabilitante = txtLegajoTecnico.Text.ToInt();
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
