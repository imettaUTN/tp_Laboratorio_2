using Application.File.Text;
using Application.Models.DATOS;
using Application.Models.Excepciones;
using Application.Models.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Models
{
    public class InformeIncubacionYMezclado : Informe
    {
        private int legajoTecnico;
        private int idTanqueIncubacion;
        private double temperaturaCalentamiento;
        private int tiempoCalentamiento;
        private double ph;
        private double hidrogeno;
        private double acidez;
        private double temperaturaMezclado;
        private bool calentado;
        private bool inoculado;
        private bool mezclado;
        private bool informeAutorizado;
        private int idInforme;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;
        public static event MostrarMensaje MostrarMensajeEnPantallaInfome;

        public int LegajoTecnico { get { return legajoTecnico; } set { legajoTecnico = value; }}
        public int IdTanqueIncubacion { get { return idTanqueIncubacion; } set { idTanqueIncubacion = value; }}
        public double TemperaturaCalentamiento { get { return temperaturaCalentamiento; } set { temperaturaCalentamiento = value; }}
        public int TiempoCalentamiento { get { return tiempoCalentamiento; } set { tiempoCalentamiento = value; }}
        public double Ph { get { return ph; } set { ph = value; }}
        public double Hidrogeno { get { return hidrogeno; } set { hidrogeno = value; }}
        public double Acidez { get { return acidez; } set { acidez = value; }}
        public double TemperaturaMezclado { get { return temperaturaMezclado; } set { temperaturaMezclado = value; }}
        public bool Calentado { get { return calentado; } set { calentado = value; }}
        public bool Inoculado { get { return inoculado; } set { inoculado = value; }}
        public bool Mezclado { get { return mezclado; } set { mezclado = value; }}
        public bool InformeAutorizado { get { return informeAutorizado; } set { informeAutorizado = value; }}
        public int IdInforme { get { return idInforme; } set { idInforme = value; }}
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; }}
        public DateTime FechaModificacion { get { return fechaModificacion; } set { fechaModificacion = value; }}

        public InformeIncubacionYMezclado() { }
        public InformeIncubacionYMezclado(int legajoTecnico, int idTanqueIncubacion, double temperaturaCalentamiento, int tiempoCalentamiento, double ph, double hidrogeno, double acidez, double temperaturaMezclado, bool calentado, bool inoculado, bool mezclado, bool informeAutorizado, int idInformeDateTime,DateTime fechaCreacion, DateTime fechaModificacion) : this(legajoTecnico, idTanqueIncubacion, temperaturaCalentamiento, tiempoCalentamiento, ph, hidrogeno, acidez, temperaturaMezclado, calentado, inoculado, mezclado, informeAutorizado, idInformeDateTime)
        {
            this.FechaCreacion = fechaCreacion;
            this.FechaModificacion = fechaModificacion;
        }

        public InformeIncubacionYMezclado(int legajoTecnico, int idTanqueIncubacion, double temperaturaCalentamiento, int tiempoCalentamiento, double ph, double hidrogeno, double acidez, double temperaturaMezclado, bool calentado, bool inoculado, bool mezclado, bool informeAutorizado, int idInforme)
        {
            this.LegajoTecnico = legajoTecnico;
            this.IdTanqueIncubacion = idTanqueIncubacion;
            this.TemperaturaCalentamiento = temperaturaCalentamiento;
            this.TiempoCalentamiento = tiempoCalentamiento;
            this.Ph = ph;
            this.Hidrogeno = hidrogeno;
            this.Acidez = acidez;
            this.TemperaturaMezclado = temperaturaMezclado;
            this.Calentado = calentado;
            this.Inoculado = inoculado;
            this.Mezclado = mezclado;
            this.InformeAutorizado = informeAutorizado;
            this.IdInforme = idInforme;
        }

        public static InformeIncubacionYMezclado Leer(int idinforme)
        {
            return InformeIncubacionYMezcladoDAO.ReadById(idinforme);
        }
        public override int Grabar()
        {
            int result;
            try
            {
                result = InformeIncubacionYMezcladoDAO.Save(this);
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
               result = InformeIncubacionYMezcladoDAO.Update(this);

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
                result = InformeIncubacionYMezcladoDAO.Delete(this.idInforme);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public void GenerarInformeTecnico()
        {
            if (this.hiloInformes != null && this.hiloInformes.IsAlive)
            {
                throw new LacteoException("El lacteo se esta guardando.");
            }
            {
                this.hiloInformes = new Thread(GenerarInforme);
                this.hiloInformes.Start();
            }
        }

        public  void GenerarInforme()
        {
            try
            {
                Persona tecnico = Persona.LeerByLegajo(this.legajoTecnico);
                String resultado;
                if (this.informeAutorizado) { resultado = "AUTORIZADO"; } else { resultado = "PENDIENTE"; }

                if (tecnico is null)
                {
                    throw new Exception("El tecnico con el legajo :" + this.legajoTecnico + " no existe");
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("                     Informe de Mezclado y Batido : " + resultado + "                 Fecha Creacion:" + this.fechaCreacion.ToString("yyyy-MM-dd hh:mm") + "  ");
                sb.AppendLine(" Tecnico Autorizante:" + tecnico.Nombre + " " + tecnico.Apellido + "                                                                                          ");
                sb.AppendLine(" Legajo: " + tecnico.Legajo + "     Dni:" + tecnico.Dni + "     Cargo: " + tecnico.Cargo + "                                                                  ");
                sb.AppendLine(" Id tanque incubacion " + this.idTanqueIncubacion + "                                                                                                         ");
                sb.AppendLine("                                                       RESULTADOS:                                                                                            ");
                sb.AppendLine(" Temperatura en que se calento producto: " + this.TemperaturaCalentamiento + "                                                                                ");
                sb.AppendLine(" Tiempo de calentamiento : " + this.tiempoCalentamiento + "                                                                                                   ");
                sb.AppendLine(" % PH: " + this.ph + "                                                                                                                                        ");
                sb.AppendLine(" % Hidrogeno : " + this.hidrogeno + "                                                                                                                         ");                                                          
                sb.AppendLine(" % Acidez : " + this.acidez + "                                                                                                                               ");                                                          
                sb.AppendLine(" Temperatura de mezclado : " + this.temperaturaMezclado + "                                                                                                   ");                                                          
                sb.AppendLine("                                                                                                                                  FIRMADO DIGITALMENTE        ");

                FTexto<string> textF = new FTexto<string>();

                string baseD = AppDomain.CurrentDomain.BaseDirectory + @"\Informes\";
                string ruta = baseD + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + "Informe Incubado y Mezclado.txt";
                if (!System.IO.Directory.Exists(baseD))
                {
                    System.IO.Directory.CreateDirectory(baseD);
                }
                textF.Save(ruta, sb.ToString());
                 InformeIncubacionYMezclado.MostrarMensajeEnPantallaInfome.Invoke("Informe Incubado y Mezclado generado ok");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
            }
        }
    }
}
