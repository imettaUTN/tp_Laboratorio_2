using Application.Models.Excepciones;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;

namespace Application.Models
{
    public delegate void MostrarMensaje(string mensaje);

    [XmlInclude(typeof(Leche))]
    [XmlInclude(typeof(Yogurth))]

    public class Lacteo
    {
        private List<AditivoProducto> aditivos;

        private bool estandarizado;
        private bool pasteurizado;
        private bool inoculado;
        private bool envasado;
        private int informeEstandarizado;
        private int informePasteurizado;
        private int informeInoculado;
        private int informeEnvasado;
        private string tipoProducto;
        private int idLacteo;
        private int idMateriaPrima;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;
        private Thread hiloBaseDeDatos;

        public Lacteo()
        {
            aditivos = new List<AditivoProducto>();
        }

        public List<AditivoProducto> Aditivos
        {
            get { return this.aditivos; }
            set { this.aditivos = value; }
        }

        /// <summary> tema threads
        /// Invoca hilos para el guardado del lacteo en la base de datos
        /// </summary>
        public void IniciarGuardadoDB()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                throw new LacteoException("El lacteo se esta guardando.");
            }
            else
            {
                if (this is Leche)
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

        /// <summary> tema threads
        /// Invoca hilos para la actualizacion del lacteo en la base de datos
        /// </summary>
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

        /// <summary> tema threads
        /// Invoca hilos para eliminar un lacteo en la base de datos
        /// </summary>
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

        /// <summary>
        /// Borra los informes de la db
        /// </summary>
        /// <param name="informes"></param>
        public void IniciarEliminacionInformesDB(Dictionary<string, int> informes)
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                throw new LacteoException("los informes del lacteo se estan eliminando.");
            }
            else
            {
                if (this is Leche)
                {
                    this.hiloBaseDeDatos = new Thread(Leche.EliminarInformesDB);
                    this.hiloBaseDeDatos.Start(informes);
                }
                else
                {
                    this.hiloBaseDeDatos = new Thread(Yogurth.EliminarInformesDB);
                    this.hiloBaseDeDatos.Start(informes);
                }

            }
        }

        /// <summary>
        /// cierra los hilos si es que estan abiertos 
        /// </summary>
        public void CerrarHilos()
        {
            if (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive)
            {
                this.hiloBaseDeDatos.Abort();
            }
        }

        public bool HiloAbierto()
        {
            return (this.hiloBaseDeDatos != null && this.hiloBaseDeDatos.IsAlive);
        }
        public int IdLacteo
        {
            get { return this.idLacteo; }
            set { this.idLacteo = value; }
        }
        public string TipoProducto
        {
            get { return this.tipoProducto; }
            set { this.tipoProducto = value; }
        }
        public int IdMateriaPrima
        {
            get { return this.idMateriaPrima; }
            set { this.idMateriaPrima = value; }
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
        public bool Inoculado
        {
            get { return this.inoculado; }
            set { this.inoculado = value; }
        }

        public bool Envasado
        {
            get { return this.envasado; }
            set { this.envasado = value; }
        }

        public int InformeEstandarizado { get { return informeEstandarizado; } set { informeEstandarizado = value; } }
        public int InformePasteurizado { get { return informePasteurizado; } set { informePasteurizado = value; } }
        public int InformeInoculado { get { return informeInoculado; } set { informeInoculado = value; } }
        public int InformeEnvasado { get { return informeEnvasado; } set { informeEnvasado = value; } }
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; } }
        public DateTime FechaModificacion { get { return fechaModificacion; } set { fechaModificacion = value; } }
        protected virtual void Estandarizar() { }
        protected virtual void Pasteurizar() { }
        protected virtual void Inocular() { }
        protected virtual void Envasar() { }

    }
}
