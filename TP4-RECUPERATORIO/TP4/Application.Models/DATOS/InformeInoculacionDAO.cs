using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Application.Models.DATOS
{
    public class InformeInoculacionDAO
    {
        public static InformeInoculado ReadById(int idInforme)
        {
            InformeInoculado informe = null;

            foreach (InformeInoculado inf in InformeInoculacionDAO.Read())
            {
                if (inf.IdInforme == idInforme)
                {
                    return inf;
                }
            }
            return informe;
        }
        public static List<InformeInoculado> Read()
        {
            List<InformeInoculado> informes = new List<InformeInoculado>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT [legajoTecnico],[TemperaturaCalentamiento],[TemperaturaCalentamientoAutorizada],[TemperaturaEnfriamiento],[TemperaturaEnfriamientoAutorizada],[InformeAutorizado],[MezcladoAutorizado],[idInforme],[fechaCreacion],isnull(fechaModificacion,fechaCreacion) as fechaModificacion  FROM [dbo].[InformeInoculacion]");
                while (oDr.Read())
                {
                    InformeInoculado infor = new InformeInoculado();

                    infor.IdInforme = oDr["idInforme"].ToString().ToInt();
                    infor.LegajoTecnico = oDr["legajoTecnico"].ToString().ToInt();
                    infor.TemperaturaCalentamiento = oDr["TemperaturaCalentamiento"].ToString().ToDouble();
                    infor.TemperaturaCalentamientoAutorizada = Boolean.Parse(oDr["TemperaturaCalentamientoAutorizada"].ToString());
                    infor.TemperaturaEnfriamiento = oDr["TemperaturaEnfriamiento"].ToString().ToDouble();
                    infor.TemperaturaEnfriamientoAutorizada = Boolean.Parse(oDr["TemperaturaEnfriamientoAutorizada"].ToString());
                    infor.MezclaAutorizada = Boolean.Parse(oDr["MezcladoAutorizado"].ToString());
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

        public static int Save(InformeInoculado inf)
        {
            int idInforme = -1;
            SqlDataReader oDr = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@TemperaturaCalentamientoAutorizada", inf.TemperaturaCalentamientoAutorizada));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamiento", inf.TemperaturaEnfriamiento));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamientoAutorizada", inf.TemperaturaEnfriamientoAutorizada));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@MezcladoAutorizado", inf.MezclaAutorizada));
                if (DB.ExecuteNoQuery("INSERT INTO [dbo].[InformeInoculacion] ([legajoTecnico],[TemperaturaCalentamiento],[TemperaturaCalentamientoAutorizada],[TemperaturaEnfriamiento],[TemperaturaEnfriamientoAutorizada],[InformeAutorizado],[MezcladoAutorizado]) VALUES (@legajoTecnico,@TemperaturaCalentamiento,@TemperaturaCalentamientoAutorizada,@TemperaturaEnfriamiento,@TemperaturaEnfriamientoAutorizada,@InformeAutorizado,@MezcladoAutorizado)", parameters))
                {
                    oDr = DB.ExecuteReader("SELECT top 1 [idInforme] FROM [dbo].[InformeInoculacion] order by [idInforme] desc");
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

        public static bool Update(InformeInoculado inf)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@TemperaturaCalentamientoAutorizada", inf.TemperaturaCalentamientoAutorizada));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamiento", inf.TemperaturaEnfriamiento));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamientoAutorizada", inf.TemperaturaEnfriamientoAutorizada));
                parameters.Add(new SqlParameter("@MezcladoAutorizado", inf.MezclaAutorizada));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@idInforme", inf.IdInforme));
                retorno = DB.ExecuteNoQuery("UPDATE [dbo].[InformeInoculacion] "+
                                            "SET [legajoTecnico] = @legajoTecnico "+
                                            ",[TemperaturaCalentamiento] = @TemperaturaCalentamiento "+
                                            ",[TemperaturaCalentamientoAutorizada] = @TemperaturaCalentamientoAutorizada "+
                                            ",[TemperaturaEnfriamiento] = @TemperaturaEnfriamiento "+
                                            ",[TemperaturaEnfriamientoAutorizada] = @TemperaturaEnfriamientoAutorizada "+
                                            ",[InformeAutorizado] = @InformeAutorizado "+
                                            ",[MezcladoAutorizado] = @MezcladoAutorizado "+
                                            ",[fechaModificacion] = getdate()" +
                                            " WHERE [idInforme] = @idInforme", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;

        }

        public static bool Delete(int idInforme)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idInforme", idInforme));
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[InformeInoculacion] where idInforme = @idInforme ", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
    }
}
