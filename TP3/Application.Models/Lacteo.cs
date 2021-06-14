using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Application.Models
{
    [XmlInclude(typeof(Leche))]
    [XmlInclude(typeof(Yogurth))]
    public abstract class Lacteo
    {
        private List<AditivoProducto> aditivos;
        protected int temperaturaEstandarizacion;
        protected double temperaturaPasteurizacion;
        protected int temperaturaEnfriamiento;
        protected double porcentajeTenorGraso;
        protected double porcentajeDeSolidos;
        protected double tiempoEstandarizacion;
        protected double tiempoPasteurizacion;
        protected double tiempoEnfriado;
        private int idOllaPasteurizacion;
        private string metodoPasteurizacion;
        private bool materiaPrimaAutorizada;
        private bool estandarizado;
        private bool pasteurizado;
        private bool enfriado;
        private MateriaPrima materiaPrima;
        private string tipoProducto;
        private int id;
        public Lacteo()
        {
            aditivos = new List<AditivoProducto>();
        }

        public List<AditivoProducto> Aditivos
        {
            get
            {
                return this.aditivos;
            }
            set
            {
                this.aditivos = value;
            }
        }

        public string TipoProducto
        {
            get { return this.tipoProducto; }
            set { this.tipoProducto = value; }
        }

        public MateriaPrima MateriaPrimaLecteo
        {
            get { return this.materiaPrima; }
            set { this.materiaPrima = value; }
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
        public int IdOllaPasteurizacion
        {
            get { return this.idOllaPasteurizacion; }
            set { this.idOllaPasteurizacion = value; }
        }
        public string MetodoPasteurizacion
        {
            get { return this.metodoPasteurizacion; }
            set { this.metodoPasteurizacion = value; }
        }
        public bool MateriaPrimaAutorizada
        {
            get { return this.materiaPrimaAutorizada; }
            set { this.materiaPrimaAutorizada = value; }

        }
        public bool Estandarizado
        {
            get { return this.estandarizado; }
            set { this.estandarizado = value; }

        }
        public bool Pasteurizado
        {
            get { return this.pasteurizado; }
            set { this.pasteurizado = value; }

        }

        public bool Enfriado
        {
            get { return this.enfriado; }
            set { this.enfriado = value; }

        }

        protected void RecibirMateriaPrima(MateriaPrima matPrima)
        {
            if(matPrima is null) { this.MateriaPrimaAutorizada = false; return; }
            this.materiaPrima = matPrima;
            this.MateriaPrimaAutorizada = true;
        }

        public void ProcesarProducto(MateriaPrima matPrima, int idOlla, string metodoPasteurizacion)
        {
            //cada bandera es un etapa que puedo o no hacer 
            if(materiaPrimaAutorizada)
            {
              RecibirMateriaPrima(matPrima);
            }
            if(estandarizado)
            {
             Estandarizar();
            }
            if(pasteurizado)
            {
              Pasteurizar(idOlla, metodoPasteurizacion);
            }
            if(enfriado)
            {
               Enfriar();
            }
        }
        protected abstract void Estandarizar() ;
        protected abstract void Pasteurizar(int IdOlla, string Metodo );
        protected abstract void Enfriar();
    }
}
