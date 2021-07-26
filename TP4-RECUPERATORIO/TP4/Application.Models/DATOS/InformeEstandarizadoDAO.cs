using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Models.DATOS
{
    public class InformeEstandarizadoDAO
    {

        /// <summary> TEMA DB/SQL
        /// Busca un informe por el ID
        /// </summary>
        /// <param name="idInforme"> id informe</param>
        /// <returns> objeto del informe</returns>
        public static InformeEstandarizado ReadById(int idInforme)
        {
            InformeEstandarizado informe = null;

            foreach(InformeEstandarizado inf in InformeEstandarizadoDAO.Read())
            {
                if(inf.IdInforme == idInforme)
                {
                    return inf;
                }
            }
            return informe;
        }

        /// <summary> TEMA DB/SQL
        /// Busca todos los informes cargados en la db 
        /// </summary>
        /// <returns> lista de objeto del informe</returns>
        public static List<InformeEstandarizado> Read()
        {
            List<InformeEstandarizado> informes = new List<InformeEstandarizado>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT [idInforme],[idTamizador],[legajoTecnico],[TemperaturaCalentamiento],[PorcentajeTenorGraso],[PorcentajeSolidos],[TemperaturaAutorizada],[GrasaAutorizada],[SolidosAutorizados],[InformeAutorizado],[fechaCreacion],isnull(fechaModificacion,fechaCreacion) as fechaModificacion FROM [dbo].[InformeEstandarizacion]");
                while (oDr.Read())
                {
                    InformeEstandarizado infor = new InformeEstandarizado();

                    infor.IdInforme = oDr["idInforme"].ToString().ToInt();
                    infor.IdTamizador = oDr["idTamizador"].ToString().ToInt();
                    infor.LegajoTecnico = oDr["legajoTecnico"].ToString().ToInt();
                    infor.TemperaturaCalentamiento = oDr["TemperaturaCalentamiento"].ToString().ToDouble();
                    infor.PorcentajeTenorGraso = oDr["PorcentajeTenorGraso"].ToString().ToDouble();
                    infor.PorcentajeSolidos = oDr["PorcentajeSolidos"].ToString().ToDouble();
                    infor.TemperaturaAutorizada = Boolean.Parse(oDr["TemperaturaAutorizada"].ToString());
                    infor.TenorGrasoAutorizado = Boolean.Parse(oDr["GrasaAutorizada"].ToString());
                    infor.PorcentajeSolidoAutorizado = Boolean.Parse(oDr["SolidosAutorizados"].ToString());
                    infor.InformeAutorizado = Boolean.Parse(oDr["InformeAutorizado"].ToString());
                    infor.FechaCreacion = Convert.ToDateTime(oDr["fechaCreacion"].ToString());
                    infor.FechaModificacion = Convert.ToDateTime(oDr["fechaModificacion"].ToString());
                    informes.Add(infor);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (!(oDr is null))
                {
                    oDr.Close();
                }
            }
            return informes;
        }

        /// <summary>
        /// Guarda un informe en la base de datos
        /// </summary>
        /// <param name="inf">objeto informe</param>
        /// <returns> id informe generado</returns>
        public static int  Save(InformeEstandarizado inf)
       {
            int idInforme = -1;
            SqlDataReader oDr = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idTamizador", inf.IdTamizador));
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@PorcentajeTenorGraso", inf.PorcentajeTenorGraso));
                parameters.Add(new SqlParameter("@PorcentajeSolidos", inf.PorcentajeSolidos));
                parameters.Add(new SqlParameter("@TemperaturaAutorizada", inf.TemperaturaAutorizada));
                parameters.Add(new SqlParameter("@GrasaAutorizada", inf.TenorGrasoAutorizado));
                parameters.Add(new SqlParameter("@SolidosAutorizados", inf.PorcentajeSolidoAutorizado));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                if (DB.ExecuteNoQuery("INSERT INTO [dbo].[InformeEstandarizacion]([idTamizador],[legajoTecnico],[TemperaturaCalentamiento],[PorcentajeTenorGraso],[PorcentajeSolidos],[TemperaturaAutorizada],[GrasaAutorizada],[SolidosAutorizados],[InformeAutorizado])  VALUES (@idTamizador,@legajoTecnico,@TemperaturaCalentamiento,@PorcentajeTenorGraso,@PorcentajeSolidos,@TemperaturaAutorizada,@GrasaAutorizada,@SolidosAutorizados,@InformeAutorizado)", parameters))
                {
                    oDr = DB.ExecuteReader("SELECT top 1 [idInforme] FROM [dbo].[InformeEstandarizacion] order by [idInforme] desc");
                    while (oDr.Read())
                    {
                        idInforme = oDr["idInforme"].ToString().ToInt();
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return idInforme;

        }

        /// <summary>
        /// Actualizad un informe en la base de datos
        /// </summary>
        /// <param name="inf"> objeto informe a actualizar</param>
        /// <returns></returns>
        public static bool Update(InformeEstandarizado inf)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idTamizador", inf.IdTamizador));
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@PorcentajeTenorGraso", inf.PorcentajeTenorGraso));
                parameters.Add(new SqlParameter("@PorcentajeSolidos", inf.PorcentajeSolidos));
                parameters.Add(new SqlParameter("@TemperaturaAutorizada", inf.TemperaturaAutorizada));
                parameters.Add(new SqlParameter("@GrasaAutorizada", inf.TenorGrasoAutorizado));
                parameters.Add(new SqlParameter("@SolidosAutorizados", inf.PorcentajeSolidoAutorizado));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@idInforme", inf.IdInforme));
                retorno = DB.ExecuteNoQuery("UPDATE [dbo].[InformeEstandarizacion]" +
                                            "SET [idTamizador] = @idTamizador," +
                                            "[legajoTecnico] = @legajoTecnico ," +
                                            "[TemperaturaCalentamiento] = @TemperaturaCalentamiento," +
                                            "[PorcentajeTenorGraso] = @PorcentajeTenorGraso," +
                                            "[PorcentajeSolidos] = @PorcentajeSolidos," +
                                            "[TemperaturaAutorizada] = @TemperaturaAutorizada," +
                                            "[GrasaAutorizada] = @GrasaAutorizada," +
                                            "[SolidosAutorizados] = @SolidosAutorizados," +
                                            "[InformeAutorizado] = @InformeAutorizado," +
                                            "[fechaModificacion] = getdate()" +
                                            " where idInforme = @idInforme", parameters); 
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;

        }

        /// <summary>
        /// Borra un informe de la base de datos
        /// </summary>
        /// <param name="idInforme"> id informe a eliminar</param>
        /// <returns> booleando incando si se elimino bien o no </returns>
        public static bool Delete(int idInforme)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idInforme", idInforme));
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[InformeEstandarizacion] where idInforme = @idInforme ", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
    }
}
