using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private Thread hiloBaseDeDatos;
        public static event MostrarMensaje MostrarMensajeEnPantalla;

        public AditivoProducto() { }
        public AditivoProducto(double cantidad, string descripcion , string tipo)
        {
            this.Cantidad = cantidad;
            this.Descripcion = descripcion;
            this.Tipo = tipo;
        }
        public void IniciarGuardadoDB()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                throw new AditivoException("El Aditivo se esta guardando.");
            }
            else
            {
                this.hiloBaseDeDatos = new Thread(AditivoProducto.GuardarEnDB);
                this.hiloBaseDeDatos.Start(this);
            }
        }

        public static void GuardarEnDB(object aditivo)
        {
            try
            {
                if (AditivosDAO.GrabarAditivo((AditivoProducto)aditivo))
                {
                    AditivoProducto.MostrarMensajeEnPantalla.Invoke("El aditivo se guardo ok"); ;
                }
            }
            catch(AditivoException ex)
            {
                AditivoProducto.MostrarMensajeEnPantalla.Invoke(ex.Message);
            }
            catch (Exception ex)
            {
                AditivoProducto.MostrarMensajeEnPantalla.Invoke(ex.Message);
            }
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
    }
}
