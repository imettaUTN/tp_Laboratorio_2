using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = string.Empty;
            txtNumero2.Text = string.Empty;
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        private void btnOperador_Click(object sender, EventArgs e)
        {
            lblResultado.Text = this.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero nroResultado = new Numero();
            lblResultado.Text = nroResultado.DecimalBinario(lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero nroResultado = new Numero();
            lblResultado.Text = nroResultado.BinarioDecimal(lblResultado.Text);
        }
        private double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero() ;
            Numero n2 = new Numero();
            n1.SetNumero = numero1;
            n2.SetNumero = numero2;

            return Calculadora.Operar(n1, n2, operador);
        }
    }
}
