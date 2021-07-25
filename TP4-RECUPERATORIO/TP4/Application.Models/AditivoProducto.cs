using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.File.Xml;
using Application.Models.DATOS;
using Application.Models.Excepciones;

namespace Application.Models
{
    public class AditivoProducto
    {
        private int id;
        private double cantidad;
        private string descripcion;
        private string tipo;
        //private Thread hiloBaseDeDatos;
//public static event MostrarMensaje MostrarMensajeEnPantalla;

        public AditivoProducto() { }
        public AditivoProducto(double cantidad, string descripcion , string tipo, int id)
        {
            this.Cantidad = cantidad;
            this.Descripcion = descripcion;
            this.Tipo = tipo;
            this.ID = id;
        }
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                this.tipo = value;
            }
        }
        public double Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }

        public static List<AditivoProducto> LeerAditivosLacteo(int id)
        {
            return AditivosDAO.LeerAditivosLacteos(id);
        }
        public static bool Guardar(List<AditivoProducto> aditivos)
        {
            try
            {
                FXml<List<AditivoProducto>> xml = new FXml<List<AditivoProducto>>();
                string file =ConfigurationManager.AppSettings["ArchivoAditivos"];
                return  xml.Save(file, aditivos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
