using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application.UI
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void cargarMateriaPrimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMateriaPrima frm = new FrmMateriaPrima();
            frm.Show();
        }

        private void cargarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
            FrmPrincipal frm = new FrmPrincipal();
            frm.Show();
 
        }
    }
}
