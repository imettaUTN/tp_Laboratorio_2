using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Application.Models.DATOS
{
    public class InformePasteurizadoDAO
    {
        public static InformePasteurizado ReadById(int idInforme)
        {
            InformePasteurizado informe = null;

            foreach (InformePasteurizado inf in InformePasteurizadoDAO.Read())
            {
                if (inf.IdInforme == idInforme)
                {
                    return inf;
                }
            }
            return informe;
        }
        public static List<InformePasteurizado> Read()
        {
            List<InformePasteurizado> informes = new List<InformePasteurizado>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT [legajoTecnico],[TemperaturaCalentamiento],[PasteurizacionAutorizada],[TemperaturaEnfriamiento],[TemperaturaEnfriamientoAutorizada],[InformeAutorizado],[MetodoPasteurizacion],[idInforme],[fechaCreacion],isnull(fechaModificacion,fechaCreacion) as fechaModificacion,IdOllaPasteurizacion  FROM [dbo].[InformePasteurizado]");
                while (oDr.Read())
                {
                    InformePasteurizado infor = new InformePasteurizado();

                    infor.IdInforme = oDr["idInforme"].ToString().ToInt();
                    infor.LegajoTecnico = oDr["legajoTecnico"].ToString().ToInt();
                    infor.TemperaturaCalentamiento = oDr["TemperaturaCalentamiento"].ToString().ToDouble();
                    infor.PasteurizacionAutorizada = Boolean.Parse(oDr["PasteurizacionAutorizada"].ToString());
                    infor.TemperaturaEnfriamiento = oDr["TemperaturaEnfriamiento"].ToString().ToDouble();
                    infor.TemperaturaEnfriamientoAutorizada = Boolean.Parse(oDr["TemperaturaEnfriamientoAutorizada"].ToString());
                    infor.MetodoPasteurizacion = oDr["MetodoPasteurizacion"].ToString();
                    infor.InformeAutorizado = Boolean.Parse(oDr["InformeAutorizado"].ToString());
                    infor.FechaCreacion = Convert.ToDateTime(oDr["fechaCreacion"].ToString());
                    infor.FechaModificacion = Convert.ToDateTime(oDr["fechaModificacion"].ToString());
                    infor.IdOllaPasteurizacion = oDr["IdOllaPasteurizacion"].ToString().ToInt();
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

        public static int Save(InformePasteurizado inf)
        {
            int idInforme = -1;
            SqlDataReader oDr = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@PasteurizacionAutorizada", inf.PasteurizacionAutorizada));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamiento", inf.TemperaturaEnfriamiento));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamientoAutorizada", inf.TemperaturaEnfriamientoAutorizada));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@MetodoPasteurizacion", inf.MetodoPasteurizacion));
                parameters.Add(new SqlParameter("@IdOllaPasteurizacion", inf.IdOllaPasteurizacion));
                if (DB.ExecuteNoQuery("INSERT INTO [dbo].[InformePasteurizado] ([legajoTecnico],[TemperaturaCalentamiento],[PasteurizacionAutorizada],[TemperaturaEnfriamiento],[TemperaturaEnfriamientoAutorizada],[InformeAutorizado],[MetodoPasteurizacion],[IdOllaPasteurizacion]) VALUES (@legajoTecnico,@TemperaturaCalentamiento,@PasteurizacionAutorizada,@TemperaturaEnfriamiento,@TemperaturaEnfriamientoAutorizada,@InformeAutorizado,@MetodoPasteurizacion,@IdOllaPasteurizacion)", parameters))
                {
                    oDr = DB.ExecuteReader("SELECT top 1 [idInforme] FROM [dbo].[InformePasteurizado] order by [idInforme] desc");
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

        public static bool Update(InformePasteurizado inf)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TemperaturaCalentamiento", inf.TemperaturaCalentamiento));
                parameters.Add(new SqlParameter("@PasteurizacionAutorizada", inf.PasteurizacionAutorizada));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamiento", inf.TemperaturaEnfriamiento));
                parameters.Add(new SqlParameter("@TemperaturaEnfriamientoAutorizada", inf.TemperaturaEnfriamientoAutorizada));
                parameters.Add(new SqlParameter("@MetodoPasteurizacion", inf.MetodoPasteurizacion));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@idInforme", inf.IdInforme));
                parameters.Add(new SqlParameter("@IdOllaPasteurizacion", inf.IdOllaPasteurizacion));
                retorno = DB.ExecuteNoQuery("UPDATE [dbo].[InformePasteurizado] "+
                                            "SET [legajoTecnico] = @legajoTecnico "+
                                            ",[TemperaturaCalentamiento] = @TemperaturaCalentamiento "+
                                            ",[PasteurizacionAutorizada] = @PasteurizacionAutorizada " +
                                            ",[TemperaturaEnfriamiento] = @TemperaturaEnfriamiento "+
                                            ",[TemperaturaEnfriamientoAutorizada] = @TemperaturaEnfriamientoAutorizada "+
                                            ",[MetodoPasteurizacion] = @MetodoPasteurizacion " +
                                            ",[InformeAutorizado] = @InformeAutorizado " +
                                            ",[fechaModificacion] = getdate()," +
                                            " [IdOllaPasteurizacion] = @IdOllaPasteurizacion"+
                                            "  WHERE [idInforme] = @idInforme", parameters);
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
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[InformePasteurizado] where idInforme = @idInforme ", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
    }
}
