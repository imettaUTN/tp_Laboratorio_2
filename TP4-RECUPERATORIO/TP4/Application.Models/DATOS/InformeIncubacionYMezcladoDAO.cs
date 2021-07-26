using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Application.Models.DATOS
{
    public class InformeIncubacionYMezcladoDAO
    {
        /// <summary> TEMA DB/SQL
        /// Busca un informe por el ID
        /// </summary>
        /// <param name="idInforme"> id informe</param>
        /// <returns> objeto del informe</returns>
        public static InformeIncubacionYMezclado ReadById(int idInforme)
        {
            InformeIncubacionYMezclado informe = null;

            foreach (InformeIncubacionYMezclado inf in InformeIncubacionYMezcladoDAO.Read())
            {
                if (inf.IdInforme == idInforme)
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
        public static List<InformeIncubacionYMezclado> Read()
        {
            List<InformeIncubacionYMezclado> informes = new List<InformeIncubacionYMezclado>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT [legajoTecnico],[idTanqueIncubacion],[TemperaturaCalentamiento],[tiempoCalentamiento],[PH],[Hidrogeno],[Acidez],[TemperaturaMezclado],[calentado],[inoculado],[InformeAutorizado],[mezclado],[idInforme],[fechaCreacion],isnull(fechaModificacion,fechaCreacion) as fechaModificacion  FROM [dbo].[InformeIncubacionYMezclado]");
                while (oDr.Read())
                {
                    InformeIncubacionYMezclado infor = new InformeIncubacionYMezclado();

                    infor.IdInforme = oDr["idInforme"].ToString().ToInt();
                    infor.LegajoTecnico = oDr["legajoTecnico"].ToString().ToInt();
                    infor.IdTanqueIncubacion = oDr["idTanqueIncubacion"].ToString().ToInt();
                    infor.TemperaturaCalentamiento = oDr["TemperaturaCalentamiento"].ToString().ToDouble();
                    infor.TiempoCalentamiento = oDr["tiempoCalentamiento"].ToString().ToInt();
                    infor.Ph = oDr["PH"].ToString().ToDouble();
                    infor.Hidrogeno = oDr["Hidrogeno"].ToString().ToDouble();
                    infor.Acidez = oDr["Acidez"].ToString().ToDouble();
                    infor.TemperaturaMezclado = oDr["TemperaturaMezclado"].ToString().ToDouble();
                    infor.Calentado = Boolean.Parse(oDr["calentado"].ToString());
                    infor.Inoculado = Boolean.Parse(oDr["inoculado"].ToString());
                    infor.Mezclado = Boolean.Parse(oDr["mezclado"].ToString());
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
        public static int Save(InformeIncubacionYMezclado inf)
        {
            int idInforme = -1;
            SqlDataReader oDr = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@idTanqueIncubacion", inf.IdTanqueIncubacion));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@tiempoCalentamiento", inf.TiempoCalentamiento));
                parameters.Add(new SqlParameter("@PH", inf.Ph));
                parameters.Add(new SqlParameter("@Hidrogeno", inf.Hidrogeno));
                parameters.Add(new SqlParameter("@Acidez", inf.Acidez));
                parameters.Add(new SqlParameter("@TemperaturaMezclado", inf.TemperaturaMezclado));
                parameters.Add(new SqlParameter("@calentado", inf.Calentado));
                parameters.Add(new SqlParameter("@inoculado", inf.Inoculado));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@mezclado", inf.Mezclado));
                if (DB.ExecuteNoQuery("INSERT INTO [dbo].[InformeIncubacionYMezclado] ([legajoTecnico],[idTanqueIncubacion],[TemperaturaCalentamiento],[tiempoCalentamiento],[PH],[Hidrogeno],[Acidez],[TemperaturaMezclado],[calentado],[inoculado],[InformeAutorizado],[mezclado]) VALUES (@legajoTecnico,@idTanqueIncubacion,@TemperaturaCalentamiento,@tiempoCalentamiento,@PH,@Hidrogeno,@Acidez,@TemperaturaMezclado,@calentado,@inoculado,@InformeAutorizado,@mezclado)", parameters))
                {
                    oDr = DB.ExecuteReader("SELECT top 1 [idInforme] FROM [dbo].[InformeIncubacionYMezclado] order by [idInforme] desc");
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
        public static bool Update(InformeIncubacionYMezclado inf)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@idTanqueIncubacion", inf.IdTanqueIncubacion));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@tiempoCalentamiento", inf.TiempoCalentamiento));
                parameters.Add(new SqlParameter("@PH", inf.Ph));
                parameters.Add(new SqlParameter("@Hidrogeno", inf.Hidrogeno));
                parameters.Add(new SqlParameter("@Acidez", inf.Acidez));
                parameters.Add(new SqlParameter("@TemperaturaMezclado", inf.TemperaturaMezclado));
                parameters.Add(new SqlParameter("@calentado", inf.Calentado));
                parameters.Add(new SqlParameter("@inoculado", inf.Inoculado));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@mezclado", inf.Mezclado));
                parameters.Add(new SqlParameter("@idInforme", inf.IdInforme));
                retorno = DB.ExecuteNoQuery("UPDATE [dbo].[InformeIncubacionYMezclado] "+
                                              "SET[legajoTecnico] = @legajoTecnico " +
                                              ",[idTanqueIncubacion] = @idTanqueIncubacion " +
                                              ",[TemperaturaCalentamiento] = @TemperaturaCalentamiento " +
                                              ",[tiempoCalentamiento] = @tiempoCalentamiento " +
                                              ",[PH] = @PH " +
                                              ",[Hidrogeno] = @Hidrogeno " +
                                              ",[Acidez] = @Acidez " +
                                              ",[TemperaturaMezclado] = @TemperaturaMezclado " +
                                              ",[calentado] = @calentado " +
                                              ",[inoculado] = @inoculado " +
                                              ",[InformeAutorizado] = @InformeAutorizado " +
                                              ",[mezclado] = @mezclado " +
                                              ",[fechaCreacion] = @fechaCreacion " +
                                             ",[fechaModificacion] = @fechaModificacion " +
                                            " WHERE  [idInforme] = @idInforme", parameters);
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
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[InformeIncubacionYMezclado] where idInforme = @idInforme ", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
    }
}
