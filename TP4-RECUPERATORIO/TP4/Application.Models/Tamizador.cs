using Application.Models.DATOS;
using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Tamizador
    {
        private int idTamizador;
        private string descripcion;
        public Tamizador(){}

        public int IdTamizador
        {
            get { return this.idTamizador; }
            set { this.idTamizador = value; }
        }
        public string Descripcion
        {
            get { return this.descripcion; }
            set { this.descripcion = value; }
        }

        public static List<DisplayObject> LeerTamizadoresParaCombo()
        {
            return TamizadorDAO.LeerTamizadoresParaCombo();
        }

    }
}
