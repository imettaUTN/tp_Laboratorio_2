using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class InformePasteurizado: Informe
    {
        private int legajoTecnico;
        private double temperaturaCalentamiento;
        private bool pasteurizacionAutorizada;
        private double temperaturaEnfriamiento;
        private bool temperaturaEnfriamientoAutorizada;
        private bool informeAutorizado;
        private string metodoPasteurizacion;
        private int idOllaPasteurizacion;
        private int idInforme;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;

        public InformePasteurizado() { }
        public InformePasteurizado(int legajoTecnico, double temperaturaCalentamiento, bool pasteurizacionAutorizada, double temperaturaEnfriamiento, bool temperaturaEnfriamientoAutorizada, bool informeAutorizado, string metodoPasteurizacion, int idOllaPasteurizacion, int idInforme)
        {
            this.LegajoTecnico = legajoTecnico;
            this.TemperaturaCalentamiento = temperaturaCalentamiento;
            this.PasteurizacionAutorizada = pasteurizacionAutorizada;
            this.TemperaturaEnfriamiento = temperaturaEnfriamiento;
            this.TemperaturaEnfriamientoAutorizada = temperaturaEnfriamientoAutorizada;
            this.InformeAutorizado = informeAutorizado;
            this.MetodoPasteurizacion = metodoPasteurizacion;
            this.IdInforme = idInforme;
            this.idOllaPasteurizacion = idOllaPasteurizacion;
        }

        public InformePasteurizado(int legajoTecnico, double temperaturaCalentamiento, bool pasteurizacionAutorizada, double temperaturaEnfriamiento, bool temperaturaEnfriamientoAutorizada, bool informeAutorizado, string metodoPasteurizacion, int idOllaPasteurizacion, int idInforme, DateTime fechaCreacion, DateTime fechaModificacion):this(legajoTecnico,temperaturaCalentamiento,pasteurizacionAutorizada, temperaturaEnfriamiento,temperaturaEnfriamientoAutorizada, informeAutorizado, metodoPasteurizacion, idInforme, idOllaPasteurizacion)
        {
            this.FechaCreacion = fechaCreacion;
            this.FechaModificacion = fechaModificacion;
        }

        public int LegajoTecnico { get { return legajoTecnico; } set { legajoTecnico = value; }}
        public double TemperaturaCalentamiento { get { return temperaturaCalentamiento; } set { temperaturaCalentamiento = value; }}
        public bool PasteurizacionAutorizada { get { return pasteurizacionAutorizada; } set { pasteurizacionAutorizada = value; }}
        public double TemperaturaEnfriamiento { get { return temperaturaEnfriamiento; } set { temperaturaEnfriamiento = value; }}
        public bool TemperaturaEnfriamientoAutorizada { get { return temperaturaEnfriamientoAutorizada; } set { temperaturaEnfriamientoAutorizada = value; }}
        public bool InformeAutorizado { get { return informeAutorizado; } set { informeAutorizado = value; }}
        public string MetodoPasteurizacion { get { return metodoPasteurizacion; } set { metodoPasteurizacion = value; }}
        public int IdInforme { get { return idInforme; } set { idInforme = value; }}
        public int IdOllaPasteurizacion { get { return idOllaPasteurizacion; } set { idOllaPasteurizacion = value; }}
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; }}
        public DateTime FechaModificacion { get { return fechaModificacion; } set { fechaModificacion = value; }}

        public static InformePasteurizado Leer(int idinforme)
        {
            return InformePasteurizadoDAO.ReadById(idinforme);
        }

        public override int Grabar()
        {
            int result;
            try
            {
                result = InformePasteurizadoDAO.Save(this);
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
                result = InformePasteurizadoDAO.Update(this);
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
                result = InformePasteurizadoDAO.Delete(this.idInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
