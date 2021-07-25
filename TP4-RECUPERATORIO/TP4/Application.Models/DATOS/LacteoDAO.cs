using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Application.Models.DATOS
{
    public static class LacteoDAO
    {
        public static Lacteo ReadById(int idLacteo)
        {
            Lacteo lacteo = new Lacteo();

            foreach (Lacteo lac in LacteoDAO.Read())
            {
                if (lac.IdLacteo == idLacteo)
                {
                    lacteo = lac;
                }
            }
            return lacteo;
        }

        public static List<Lacteo> Read()
        {
            List<Lacteo> listaRetorno = new List<Lacteo>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT [TipoProducto],[IdMateriaPrima],[IdLacteo],[estandarizado],[idInformeEstandarizado],[inoculado],[idInformeInoculacion],[pasteurizado],[IdInformePasteurizacion],[incubadoyMezclado],[IdInformeIncubadoYMezclado],[envasado],[IdInformeEnvasado],[fechaCreacion],isnull(fechaModificacion,fechaCreacion) as fechaModificacion FROM [dbo].[Lacteo]");
                while (oDr.Read())
                {
                    Lacteo lact;
                    if (oDr["TipoProducto"].ToString().Equals("Yogurth"))
                    {
                        Yogurth lact2 = new Yogurth();
                        lact2.IncubadoyMezclado = Boolean.Parse(oDr["incubadoyMezclado"].ToString());
                        lact2.InformeIncubacionYMezcla = oDr["IdInformeIncubadoYMezclado"].ToString().ToInt();
                        lact = lact2;
                    }
                    else
                    {
                        lact = new Leche();
                    }
                    lact.IdMateriaPrima = oDr["IdMateriaPrima"].ToString().ToInt();
                    lact.IdLacteo = oDr["IdLacteo"].ToString().ToInt();
                    lact.Estandarizado = Boolean.Parse(oDr["estandarizado"].ToString());
                    lact.InformeEstandarizado = oDr["idInformeEstandarizado"].ToString().ToInt();
                    lact.Inoculado = Boolean.Parse(oDr["inoculado"].ToString());
                    lact.InformeInoculado = oDr["idInformeInoculacion"].ToString().ToInt();
                    lact.Pasteurizado = Boolean.Parse(oDr["pasteurizado"].ToString());
                    lact.InformePasteurizado = oDr["IdInformePasteurizacion"].ToString().ToInt();
                    lact.Envasado = Boolean.Parse(oDr["envasado"].ToString());
                    lact.InformeEnvasado = oDr["IdInformeEnvasado"].ToString().ToInt();
                    lact.FechaCreacion = Convert.ToDateTime(oDr["fechaCreacion"].ToString());
                    lact.FechaModificacion = Convert.ToDateTime(oDr["fechaModificacion"].ToString());
                    listaRetorno.Add(lact);
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
            return listaRetorno;
        }

        public static bool Save(Lacteo lacteo)
        {
            bool retorno = false;
            int idLacteo = 0;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@TipoProducto", lacteo.TipoProducto));
                parameters.Add(new SqlParameter("@IdMateriaPrima", lacteo.IdMateriaPrima));
                parameters.Add(new SqlParameter("@estandarizado", lacteo.Estandarizado));
                parameters.Add(new SqlParameter("@idInformeEstandarizado", lacteo.InformeEstandarizado));
                parameters.Add(new SqlParameter("@inoculado", lacteo.Inoculado));
                parameters.Add(new SqlParameter("@idInformeInoculacion", lacteo.InformeInoculado));
                parameters.Add(new SqlParameter("@pasteurizado", lacteo.Pasteurizado));
                parameters.Add(new SqlParameter("@IdInformePasteurizacion", lacteo.InformePasteurizado));
                if (lacteo.TipoProducto.Equals("Yogurth"))
                {
                    parameters.Add(new SqlParameter("@incubadoyMezclado", ((Yogurth)lacteo).IncubadoyMezclado));
                    parameters.Add(new SqlParameter("@IdInformeIncubadoYMezclado", ((Yogurth)lacteo).InformeIncubacionYMezcla));
                }

                parameters.Add(new SqlParameter("@envasado", lacteo.Envasado));
                parameters.Add(new SqlParameter("@IdInformeEnvasado", lacteo.InformeEnvasado));

                string inserts = "[TipoProducto]" +
                                ",[IdMateriaPrima]" +
                                ",[estandarizado]" +
                                ",[idInformeEstandarizado]" +
                                ",[inoculado]" +
                                ",[idInformeInoculacion]" +
                                ",[pasteurizado]" +
                                ",[IdInformePasteurizacion]" +
                                ",[envasado]" +
                                ",[IdInformeEnvasado]";
                if (lacteo.TipoProducto.Equals("Yogurth"))
                {
                    inserts += ",[incubadoyMezclado]" +
                               ",[IdInformeIncubadoYMezclado]";
                }

                string parametros = "@TipoProducto, " +
                                    "@IdMateriaPrima, " +
                                    "@estandarizado, " +
                                    "@idInformeEstandarizado, " +
                                    "@inoculado, " +
                                    "@idInformeInoculacion, " +
                                    "@pasteurizado, " +
                                    "@IdInformePasteurizacion, " +
                                    "@envasado, " +
                                    "@IdInformeEnvasado";

                if (lacteo.TipoProducto.Equals("Yogurth"))
                {
                    parametros += ",@incubadoyMezclado " +
                                   ",@IdInformeIncubadoYMezclado ";
                }


                retorno = DB.ExecuteNoQuery("INSERT INTO [dbo].[Lacteo]" +
                                           "(" + inserts + ")" +
                                     "VALUES " +
                                           "(" + parametros + ")", parameters);

                SqlDataReader oDr = DB.ExecuteReader("Select top 1 IdLacteo from Lacteo order by IdLacteo desc");
                while (oDr.Read())
                {
                    idLacteo = oDr["IdLacteo"].ToString().ToInt();
                }


                if (lacteo.Aditivos.Count > 0)
                {
                    foreach (AditivoProducto aditivo in lacteo.Aditivos)
                    {
                        retorno = AditivosDAO.SaveAditivoLacteo(aditivo, idLacteo);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }

        public static bool Update(Lacteo lacteo)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@TipoProducto", lacteo.TipoProducto));
                parameters.Add(new SqlParameter("@IdMateriaPrima", lacteo.IdMateriaPrima));
                parameters.Add(new SqlParameter("@estandarizado", lacteo.Estandarizado));
                parameters.Add(new SqlParameter("@idInformeEstandarizado", lacteo.InformeEstandarizado));
                parameters.Add(new SqlParameter("@inoculado", lacteo.Inoculado));
                parameters.Add(new SqlParameter("@idInformeInoculacion", lacteo.InformeInoculado));
                parameters.Add(new SqlParameter("@pasteurizado", lacteo.Pasteurizado));
                parameters.Add(new SqlParameter("@IdInformePasteurizacion", lacteo.InformePasteurizado));
                if (lacteo.TipoProducto.Equals("Yogurth"))
                {
                    parameters.Add(new SqlParameter("@incubadoyMezclado", ((Yogurth)lacteo).IncubadoyMezclado));
                    parameters.Add(new SqlParameter("@IdInformeIncubadoYMezclado", ((Yogurth)lacteo).InformeIncubacionYMezcla));
                }
                else
                {
                    parameters.Add(new SqlParameter("@incubadoyMezclado", false));
                    parameters.Add(new SqlParameter("@IdInformeIncubadoYMezclado", 0));
                }
                parameters.Add(new SqlParameter("@envasado", lacteo.Envasado));
                parameters.Add(new SqlParameter("@IdInformeEnvasado", lacteo.InformeEnvasado));
                parameters.Add(new SqlParameter("@IdLacteo", lacteo.IdLacteo));

                retorno = DB.ExecuteNoQuery("UPDATE [dbo].[Lacteo]" +
                                            "SET[TipoProducto] = @TipoProducto, " +
                                            "[IdMateriaPrima] = @IdMateriaPrima, " +
                                            "[estandarizado] = @estandarizado, " +
                                            "[idInformeEstandarizado] = @idInformeEstandarizado, " +
                                            "[inoculado] = @inoculado, " +
                                            "[idInformeInoculacion] = @idInformeInoculacion, " +
                                            "[pasteurizado] = @pasteurizado, " +
                                            "[IdInformePasteurizacion] = @IdInformePasteurizacion, " +
                                            "[incubadoyMezclado] = @incubadoyMezclado, " +
                                            "[IdInformeIncubadoYMezclado] = @IdInformeIncubadoYMezclado, " +
                                            "[envasado] = @envasado, " +
                                            "[IdInformeEnvasado] = @IdInformeEnvasado, " +
                                            "[fechaModificacion] = GETDATE()" +
                                            " WHERE [IdLacteo] = @IdLacteo", parameters);
                if (lacteo.Aditivos.Count > 0)
                {
                    AditivosDAO.DeleteAditivoLacteo(lacteo.IdLacteo);

                    foreach (AditivoProducto aditivo in lacteo.Aditivos)
                    {
                         retorno = AditivosDAO.SaveAditivoLacteo(aditivo, lacteo.IdLacteo);
                    }

                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        public static bool Delete(int IdLacteo)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();

            try
            {
                parameters.Add(new SqlParameter("@IdLacteo", IdLacteo));
                retorno = DB.ExecuteNoQuery("DELETE FROM [Lacteo] WHERE [IdLacteo] = @IdLacteo", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        public static bool DeleteInformes(Dictionary<string, int> informes)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                foreach (KeyValuePair<string, int> informe in informes)
                {
                    switch (informe.Key)
                    {
                        case "Estandarizar":
                            InformeEstandarizadoDAO.Delete(informe.Value);
                            break;
                        case "Pasteurizar":
                            InformePasteurizadoDAO.Delete(informe.Value);
                            break;
                        case "Inocular":
                            InformeInoculacionDAO.Delete(informe.Value);
                            break;
                        case "Envasar":
                            InformeEnvasadoDAO.Delete(informe.Value);
                            break;
                        case "MezclarEIncubar":
                            InformeIncubacionYMezcladoDAO.Delete(informe.Value);
                            break;
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }


    }
}
