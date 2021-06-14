using Application.Models;
using Application.Models.Logs;
using System;
using System.Windows.Forms;
namespace Application.UI
{
    public partial class FrmMateriaPrima : Form
    {
        public FrmMateriaPrima()
        {
            InitializeComponent();
        }

        private void btCargar_Click(object sender, EventArgs e)
        {
            try
            {
                MateriaPrima mp = new MateriaPrima()
                {
                    IdTanque = Convert.ToInt32(txtDescripcion.Text),
                    IdTampo = Convert.ToInt32(txtIdTambo.Text),
                    IndiceAcidez = Convert.ToDouble(txtIndiceAcidez.Text),
                    LegajoTecnicoHabilitante = Convert.ToInt32(txtLegajoTecnico.Text),
                    Descripcion = txtDescripcion.Text,
                    HabilitadoParaFabrica = chHabFab.Checked
                };
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
    }
}
