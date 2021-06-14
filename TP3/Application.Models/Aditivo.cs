using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AditivoProducto
    {
        private int id;
        private double cantidad;
        private string descripcion;
        private string tipo;
        public AditivoProducto() { }
        public AditivoProducto(double cantidad, string descripcion , string tipo)
        {
            this.Cantidad = cantidad;
            this.Descripcion = descripcion;
            this.Tipo = tipo;
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
