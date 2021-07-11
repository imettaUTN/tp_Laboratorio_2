using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace Application.UI
{
    public partial class FrmVerMateriaPrima : Form
    {
        private List<MateriaPrima> materiasPrimas;
        public FrmVerMateriaPrima()
        {
            InitializeComponent();
            //Levanto las materias primas del archivo serializado
            materiasPrimas = MateriaPrimaDAO.Read();
            List<MateriaPrima> listaAux = MateriaPrima.CargarMateriaPrima();

            if (!(listaAux is null))
            {
                foreach (MateriaPrima mp in listaAux)
                {
                    //Si no existe en la lista de la base de datos , lo agrego y luego actualizo la db
                    if (!Contains(materiasPrimas, mp))
                    {
                        materiasPrimas.Add(mp);
                        //Si no existe en la db lo guardo
                        MateriaPrimaDAO.Save(mp);
                    }
                }

            }
            System.ComponentModel.BindingList<MateriaPrima> myBind = new System.ComponentModel.BindingList<MateriaPrima>(materiasPrimas);




            this.dgMateriaPrima.DataSource = myBind;

        }
          
        private void btSerializar_Click(object sender, EventArgs e)
        {
            if (MateriaPrima.GuardarMateriaPrima(materiasPrimas))
            {
                MessageBox.Show("Se guardo la materia prima");
            }
        }

        private bool Contains(List<MateriaPrima> lista , MateriaPrima materiaPrima)
        {
            if(lista is null || materiaPrima is null)
            { return false; }
            foreach(MateriaPrima mp in lista)
            {
                if(mp.IdMateriaPrima == materiaPrima.IdMateriaPrima)
                {
                    return true;
                }
            }
            return false;

        }      
    }
 
}
