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

        public Tamizador(int idTamizador, string descripcion)
        {
            this.IdTamizador = idTamizador;
            this.Descripcion = descripcion;
        }

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

        /// <summary>
        /// Lee los tamizadores de la db
        /// </summary>
        /// <returns></returns>
        public static List<DisplayObject> LeerTamizadoresParaCombo()
        {
            return TamizadorDAO.LeerTamizadoresParaCombo();
        }

    }
}
