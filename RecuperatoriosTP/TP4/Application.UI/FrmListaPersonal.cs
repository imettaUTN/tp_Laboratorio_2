using Application.Models;
using Application.Models.DATOS;
using Application.Models.Logs;
using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Application.UI
{
    public partial class FrmListaPersonal : Form
    {
        public FrmListaPersonal()
        {
            InitializeComponent();
            //Levanto las materias primas del archivo serializado
            List<Persona> personas = Persona.Leer();
            System.ComponentModel.BindingList<Persona> myBind = new System.ComponentModel.BindingList<Persona>(personas);
            this.dgPersonal.DataSource = myBind;
        }
    }
}
