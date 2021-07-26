using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class InformeInoculado: Informe
    {
        private int legajoTecnico;
        private double temperaturaCalentamiento;
        private bool temperaturaCalentamientoAutorizada;
        private double temperaturaEnfriamiento;
        private bool temperaturaEnfriamientoAutorizada;
        private bool mezclaAutorizada;
        private bool informeAutorizado;
        private int idInforme;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;

        public InformeInoculado() { }
        public InformeInoculado(int legajoTecnico, double temperaturaCalentamiento, bool temperaturaCalentamientoAutorizada, double temperaturaEnfriamiento, bool temperaturaEnfriamientoAutorizada, bool mezclaAutorizada, bool informeAutorizado, int idInforme)
        {
            this.LegajoTecnico = legajoTecnico;
            this.TemperaturaCalentamiento = temperaturaCalentamiento;
            this.TemperaturaCalentamientoAutorizada = temperaturaCalentamientoAutorizada;
            this.TemperaturaEnfriamiento = temperaturaEnfriamiento;
            this.TemperaturaEnfriamientoAutorizada = temperaturaEnfriamientoAutorizada;
            this.MezclaAutorizada = mezclaAutorizada;
            this.InformeAutorizado = informeAutorizado;
            this.IdInforme = idInforme;
 
        }
        public InformeInoculado(int legajoTecnico, double temperaturaCalentamiento, bool temperaturaCalentamientoAutorizada, double temperaturaEnfriamiento, bool temperaturaEnfriamientoAutorizada, bool mezclaAutorizada, bool informeAutorizado, int idInforme, DateTime fechaCreacion, DateTime fechaModificacion): this(legajoTecnico,temperaturaCalentamiento,temperaturaCalentamientoAutorizada,temperaturaEnfriamiento,temperaturaEnfriamientoAutorizada,mezclaAutorizada,informeAutorizado,idInforme)
        {
            this.FechaCreacion = fechaCreacion;
            this.FechaModificacion = fechaModificacion;
        }

        public int LegajoTecnico { get { return legajoTecnico; } set { legajoTecnico = value; } }
        public double TemperaturaCalentamiento { get { return temperaturaCalentamiento; } set { temperaturaCalentamiento = value; } }
        public bool TemperaturaCalentamientoAutorizada { get { return temperaturaCalentamientoAutorizada; } set { temperaturaCalentamientoAutorizada = value; } }
        public double TemperaturaEnfriamiento { get { return temperaturaEnfriamiento; } set { temperaturaEnfriamiento = value; } }
        public bool TemperaturaEnfriamientoAutorizada { get { return temperaturaEnfriamientoAutorizada; } set { temperaturaEnfriamientoAutorizada = value; } }
        public bool MezclaAutorizada { get { return mezclaAutorizada; } set { mezclaAutorizada = value; } }
        public bool InformeAutorizado { get { return informeAutorizado; } set { informeAutorizado = value; } }
        public int IdInforme { get { return idInforme; } set { idInforme = value; } }
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; } }
        public DateTime FechaModificacion { get { return fechaModificacion; } set { fechaModificacion = value; } }

        public static InformeInoculado Leer(int idinforme)
        {
            return InformeInoculacionDAO.ReadById(idinforme);
        }
        public override int Grabar()
        {
            int result;
            try
            {
                result = InformeInoculacionDAO.Save(this);
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
                result =InformeInoculacionDAO.Update(this);
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
                result = InformeInoculacionDAO.Delete(this.idInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


    }
}
