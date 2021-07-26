using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application.Models;
using Application.Models.Logs;

namespace Application.UI
{
    public partial class FrmPersonal : Form
    {
        public FrmPersonal()
        {
            InitializeComponent();
        }

        private void btGrabar_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            bool valido = true;          

            if(string.IsNullOrEmpty(txtLegajo.Text))
            {
                valido = false;
                sb.AppendLine("El legajo no puede estar vacio");
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                sb.AppendLine("El nombre no puede estar vacio");
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                sb.AppendLine("El apellido no puede estar vacio");
            }
            if (string.IsNullOrEmpty(txtDni.Text))
            {
                valido = false;
                sb.AppendLine("El dni no puede estar vacio");
            }
            if (string.IsNullOrEmpty(txtCargo.Text))
            {
                valido = false;
                sb.AppendLine("El cargo no puede estar vacio");
            }

            if (!Regex.IsMatch(txtLegajo.Text, @"\d+"))
            {
                valido = false;
                sb.AppendLine("El legajo debe contenter solo numero");
            }

            if (!Regex.IsMatch(txtDni.Text, @"\d+"))
            {
                valido = false;
                sb.AppendLine("El dni debe contenter solo numero");
            }
            if(!(rbFemenino.Checked || rbMasculino.Checked || rbOtro.Checked))
            {
                valido = false;
                sb.AppendLine("Debe seleccionar un genero");
            }

            if(Persona.ExisteLegajo(txtLegajo.Text.ToInt()))
            {
                valido = false;
                sb.AppendLine("El legajo ya esta asignado a otra persona. Debe indicar uno distinto");
            }

            if(!valido)
            {
                MessageBox.Show(sb.ToString(), "Error en el formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string genero = string.Empty;
                if(rbFemenino.Checked)
                {
                    genero = "F";
                }
                if (rbMasculino.Checked)
                {
                    genero = "M";
                }
                if (rbOtro.Checked)
                {
                    genero = "O";
                }

                try
                {
                    Persona persona = new Persona(txtLegajo.Text.ToInt(), txtDni.Text.ToInt(), txtNombre.Text, txtApellido.Text, txtCargo.Text, genero, chkEsTecnico.Checked);
                    if (!persona.Guardar())
                    {
                        throw new Exception("Error al guardar la Persona");
                    }
                    MessageBox.Show("Guardado OK");                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se puede guardar el personal: {ex.Message}", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}
