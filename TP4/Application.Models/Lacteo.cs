using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Application.Models.Excepciones;

namespace Application.Models
{
    public delegate void MostrarMensaje(string listado);

    [XmlInclude(typeof(Leche))]
    [XmlInclude(typeof(Yogurth))]

    public  class Lacteo
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
        private int materiaPrima;
        private string tipoProducto;
        private int idLacteo;
        private Thread hiloBaseDeDatos;

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

        public void IniciarGuardadoDB()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                throw new LacteoException("El lacteo se esta guardando.");
            }
            else
            {
                if(this is Leche)
                {
                    this.hiloBaseDeDatos = new Thread(Leche.GuardarEnDB);
                    this.hiloBaseDeDatos.Start((Leche)this);
                }
                else
                {
                    this.hiloBaseDeDatos = new Thread(Yogurth.GuardarEnDB);
                    this.hiloBaseDeDatos.Start((Yogurth)this);
                }
             
            }
        }

        public void IniciarActualizacionDB()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                throw new LacteoException("El lacteo se esta actualizando.");
            }
            else
            {
                if (this is Leche)
                {
                    this.hiloBaseDeDatos = new Thread(Leche.ActualizarDB);
                    this.hiloBaseDeDatos.Start((Leche)this);
                }
                else
                {
                    this.hiloBaseDeDatos = new Thread(Yogurth.ActualizarDB);
                    this.hiloBaseDeDatos.Start((Yogurth)this);
                }

            }
        }

        public void IniciarEliminacionDB()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                throw new LacteoException("El lacteo se esta eliminando.");
            }
            else
            {
                if (this is Leche)
                {
                    this.hiloBaseDeDatos = new Thread(Leche.EliminarDB);
                    this.hiloBaseDeDatos.Start((Leche)this);
                }
                else
                {
                    this.hiloBaseDeDatos = new Thread(Yogurth.EliminarDB);
                    this.hiloBaseDeDatos.Start((Yogurth)this);
                }

            }
        }
        

        public void CerrarHilos()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                this.hiloBaseDeDatos.Abort();
            }
        }
        public int IdLacteo
        {
            get
            {
                return this.idLacteo;
            }
            set
            {
                this.idLacteo = value;
            }
        }
        public string TipoProducto
        {
            get { return this.tipoProducto; }
            set { this.tipoProducto = value; }
        }

        public int IdMateriaPrima
        {
            get { return this.materiaPrima; }
            set { this.materiaPrima = value; }
        }

        // uso metodo de extension
        public String MateriaPrima
        {
            get { return this.GetDescriptionMateriaPrima(); }
        }

        public bool MpAutorizada
        {
            get { return this.materiaPrimaAutorizada; }
            set { this.materiaPrimaAutorizada = value; }
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

        protected void RecibirMateriaPrima(int matPrimaId)
        {
            if(matPrimaId <0) { this.MpAutorizada = false; return; }
            this.materiaPrima = matPrimaId;
            this.MpAutorizada = true;
        }

        public void ProcesarProducto(int matPrimaId, int idOlla, string metodoPasteurizacion)
        {
            //cada bandera es un etapa que puedo o no hacer 
            if(materiaPrimaAutorizada)
            {
              RecibirMateriaPrima(matPrimaId);
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
        protected virtual void Estandarizar() { }
        protected virtual void Pasteurizar(int IdOlla, string Metodo) { }
        protected virtual void Enfriar() { }
    }
}
