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
    public class InformeEstandarizado: Informe
    {
        private int idTamizador;
        private int legajoTecnico;
        private double temperaturaCalentamiento;
        private double porcentajeTenorGraso;
        private double porcentajeSolidos;
        private bool temperaturaAutorizada;
        private bool tenorGrasoAutorizado;
        private bool porcentajeSolidoAutorizado;
        private bool informeAutorizado;
        private int idInforme;
        private DateTime fechaCreacion;
        private DateTime fechaModificacion;
        public static event MostrarMensaje MostrarMensajeEnPantallaInfome;

        public int IdTamizador { get { return idTamizador; } set { idTamizador = value; } }
        public int LegajoTecnico { get { return legajoTecnico; } set { legajoTecnico = value; } }
        public double TemperaturaCalentamiento { get { return temperaturaCalentamiento; } set { temperaturaCalentamiento = value; } }
        public double PorcentajeTenorGraso { get { return porcentajeTenorGraso; } set { porcentajeTenorGraso = value; } }
        public double PorcentajeSolidos { get { return porcentajeSolidos; } set { porcentajeSolidos = value; } }
        public bool TemperaturaAutorizada { get { return temperaturaAutorizada; } set { temperaturaAutorizada = value; } }
        public bool TenorGrasoAutorizado { get { return tenorGrasoAutorizado; } set { tenorGrasoAutorizado = value; } }
        public bool PorcentajeSolidoAutorizado { get { return porcentajeSolidoAutorizado; } set { porcentajeSolidoAutorizado = value; } }
        public bool InformeAutorizado { get { return informeAutorizado; } set { informeAutorizado = value; } }
        public int IdInforme { get { return idInforme; } set { idInforme = value; } }
        public DateTime FechaCreacion { get { return fechaCreacion; } set { fechaCreacion = value; } }
        public DateTime FechaModificacion { get { return fechaModificacion; } set { fechaModificacion = value; } }

        public InformeEstandarizado()
        { }
        public InformeEstandarizado(int idTamizador, int legajoTecnico, double temperaturaCalentamiento, double porcentajeTenorGraso, double porcentajeSolidos, bool temperaturaAutorizada, bool tenorGrasoAutorizado, bool porcentajeSolidoAutorizado, bool informeAutorizado, int idInforme)
        {
            this.IdTamizador = idTamizador;
            this.LegajoTecnico = legajoTecnico;
            this.TemperaturaCalentamiento = temperaturaCalentamiento;
            this.PorcentajeTenorGraso = porcentajeTenorGraso;
            this.PorcentajeSolidos = porcentajeSolidos;
            this.TemperaturaAutorizada = temperaturaAutorizada;
            this.TenorGrasoAutorizado = tenorGrasoAutorizado;
            this.PorcentajeSolidoAutorizado = porcentajeSolidoAutorizado;
            this.InformeAutorizado = informeAutorizado;
            this.IdInforme = idInforme;
        }

        public InformeEstandarizado(int idTamizador, int legajoTecnico, double temperaturaCalentamiento, double porcentajeTenorGraso, double porcentajeSolidos, bool temperaturaAutorizada, bool tenorGrasoAutorizado, bool porcentajeSolidoAutorizado, bool informeAutorizado, int idInforme, DateTime fechaCreacion, DateTime fechaModificacion) : this(idTamizador, legajoTecnico, temperaturaCalentamiento, porcentajeTenorGraso, porcentajeSolidos, temperaturaAutorizada, tenorGrasoAutorizado, porcentajeSolidoAutorizado, informeAutorizado, idInforme)
        {
            this.fechaCreacion = fechaCreacion;
            this.FechaModificacion = fechaModificacion;
        }

        public static InformeEstandarizado Leer(int idinforme)
        {
            return InformeEstandarizadoDAO.ReadById(idinforme);
        }

        public override int Grabar()
        {
            int result ;
            try
            {
                result= InformeEstandarizadoDAO.Save(this);
            }
            catch(Exception ex)
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
                result = InformeEstandarizadoDAO.Update(this);          
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
                result = InformeEstandarizadoDAO.Delete(this.idInforme);
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
                throw new LacteoException("El informe se esta guardando.");
            }
            {
                this.hiloInformes = new Thread(GenerarInforme);
                this.hiloInformes.Start();
            }
        }
        public void GenerarInforme()
        {
            try
            {
                Persona tecnico = Persona.LeerByLegajo(this.legajoTecnico);
                String resultado;
                if (this.informeAutorizado) { resultado = "AUTORIZADO"; } else { resultado = "PENDIENTE"; }

                if(tecnico is null)
                {
                    throw new Exception("El tecnico con el legajo :" + this.legajoTecnico + " no existe" );
                }                               
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("                     Informe Estandarizacion : " + resultado+ "                       Fecha Creacion:" + this.fechaCreacion.ToString("yyyy-MM-dd hh:mm") + "  ");
                sb.AppendLine(" Tecnico Autorizante:" + tecnico.Nombre + " " + tecnico.Apellido + "                                                                                          ");
                sb.AppendLine(" Legajo: " + tecnico.Legajo + "     Dni:" + tecnico.Dni + "     Cargo: " + tecnico.Cargo + "                                                                  ");
                sb.AppendLine("                                                       RESULTADOS:                                                                                            ");
                sb.AppendLine(" Temperatura en que se calento producto: "+ this.TemperaturaCalentamiento+"                                                                                   ");
                sb.AppendLine(" Porcentaje tenor graso : "+ this.PorcentajeTenorGraso+"                                                                                                      ");
                sb.AppendLine(" Porcentaje solidos : "+ this.porcentajeSolidos +"                                                                                                            ");
                sb.AppendLine("                                                                                                                                  FIRMADO DIGITALMENTE        ");

                FTexto<string> textF = new FTexto<string>();

                string baseD = AppDomain.CurrentDomain.BaseDirectory + @"\Informes\";
                string ruta = baseD + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + "Informe Estandarizado.txt" ;
                if(!System.IO.Directory.Exists(baseD))
                {
                    System.IO.Directory.CreateDirectory(baseD);
                }           
                 textF.Save(ruta, sb.ToString());
                 InformeEstandarizado.MostrarMensajeEnPantallaInfome.Invoke("Informe estandarizado generado ok");

            }
            catch (Exception ex)
            {
                Logger.LogException(ex.Message);
            }
        }

    }
}
