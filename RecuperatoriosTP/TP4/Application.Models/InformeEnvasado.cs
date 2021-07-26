using Application.Models.DATOS;
using System;

namespace Application.Models
{
    public class InformeEnvasado : Informe
    {
        private int legajoTecnico;
        private string tipoEnvase;
        private double temperaturaRefrigeracion;
        private bool etiquetaGenerada;
        private bool productoAutorizado;
        private int nroAutorizacion;
        private int idInforme;
        private bool informeAutorizado;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;


        public InformeEnvasado() { }
        public InformeEnvasado(int legajoTecnico, string tipoEnvase, double temperaturaRefrigeracion, bool etiquetaGenerada, bool productoAutorizado, int nroAutorizacion, bool informeAutorizado, int idInforme)
        {
            this.LegajoTecnico = legajoTecnico;
            this.TipoEnvase = tipoEnvase;
            this.TemperaturaRefrigeracion = temperaturaRefrigeracion;
            this.EtiquetaGenerada = etiquetaGenerada;
            this.ProductoAutorizado = productoAutorizado;
            this.NroAutorizacion = nroAutorizacion;
            this.InformeAutorizado = informeAutorizado;
            this.IdInforme = idInforme;
        }

        public InformeEnvasado(int legajoTecnico, string tipoEnvase, double temperaturaRefrigeracion, bool etiquetaGenerada, bool productoAutorizado, int nroAutorizacion, bool informeAutorizado, int idInforme, DateTime fechaCreacion, DateTime fechaModificacion) : this(legajoTecnico, tipoEnvase, temperaturaRefrigeracion, etiquetaGenerada, productoAutorizado, nroAutorizacion, informeAutorizado, idInforme)
        {
            this.FechaCreacion = fechaCreacion;
            this.FechaModificacion = fechaModificacion;
        }

        public int LegajoTecnico { get { return legajoTecnico; } set { legajoTecnico = value; } }
        public string TipoEnvase { get { return tipoEnvase; } set { tipoEnvase = value; } }
        public double TemperaturaRefrigeracion { get { return temperaturaRefrigeracion; } set { temperaturaRefrigeracion = value; } }
        public bool EtiquetaGenerada { get { return etiquetaGenerada; } set { etiquetaGenerada = value; } }
        public bool ProductoAutorizado { get { return productoAutorizado; } set { productoAutorizado = value; } }
        public int NroAutorizacion { get { return nroAutorizacion; } set { nroAutorizacion = value; } }
        public int IdInforme { get { return idInforme; } set { idInforme = value; } }
        public bool InformeAutorizado { get { return informeAutorizado; } set { informeAutorizado = value; } }
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; } }
        public DateTime FechaModificacion { get { return fechaModificacion; } set { fechaModificacion = value; } }

        public static InformeEnvasado Leer(int idinforme)
        {
            return InformeEnvasadoDAO.ReadById(idinforme);
        }
        public override int Grabar()
        {
            int result;
            try
            {
                result = InformeEnvasadoDAO.Save(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public override bool Actualizar()
        {
            bool result = false;
            try
            {
                result= InformeEnvasadoDAO.Update(this);
           
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public override bool Eliminar()
        {
            bool result = false;
            try
            {
                result = InformeEnvasadoDAO.Delete(this.idInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
