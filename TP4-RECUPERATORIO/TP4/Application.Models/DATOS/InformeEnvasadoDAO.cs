using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;

namespace Application.Models.DATOS
{
    public class InformeEnvasadoDAO
    {
        public static InformeEnvasado ReadById(int idInforme)
        {
            InformeEnvasado informe = null;

            foreach (InformeEnvasado inf in InformeEnvasadoDAO.Read())
            {
                if (inf.IdInforme == idInforme)
                {
                    return inf;
                }
            }
            return informe;
        }
        public static List<InformeEnvasado> Read()
        {
            List<InformeEnvasado> informes = new List<InformeEnvasado>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT [legajoTecnico],[TipoEnvase],[TemperaturaRefigeracion],[EtiquetaGenerada],[ProductoAutorizado],[InformeAutorizado],[NroAutorizacion],[idInforme],[fechaCreacion],isnull(fechaModificacion,fechaCreacion) as fechaModificacion FROM [dbo].[InformeEnvasado]");
                while (oDr.Read())
                {
                    InformeEnvasado infor = new InformeEnvasado();

                    infor.IdInforme = oDr["idInforme"].ToString().ToInt();
                    infor.TipoEnvase = oDr["TipoEnvase"].ToString();
                    infor.LegajoTecnico = oDr["legajoTecnico"].ToString().ToInt();
                    infor.TemperaturaRefrigeracion = oDr["TemperaturaRefigeracion"].ToString().ToDouble();
                    infor.EtiquetaGenerada = Convert.ToBoolean(oDr["EtiquetaGenerada"]);
                    infor.ProductoAutorizado = Convert.ToBoolean(oDr["ProductoAutorizado"]);
                    infor.InformeAutorizado = Convert.ToBoolean(oDr["InformeAutorizado"]);
                    infor.NroAutorizacion = oDr["NroAutorizacion"].ToString().ToInt();
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

       public static int  Save(InformeEnvasado inf)
       {
            int idInforme = -1;
            SqlDataReader oDr = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TipoEnvase", inf.TipoEnvase));
                parameters.Add(new SqlParameter("@TemperaturaRefigeracion", inf.TemperaturaRefrigeracion));
                parameters.Add(new SqlParameter("@EtiquetaGenerada", inf.EtiquetaGenerada));
                parameters.Add(new SqlParameter("@ProductoAutorizado", inf.ProductoAutorizado));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@NroAutorizacion", inf.NroAutorizacion));
                if (DB.ExecuteNoQuery("INSERT INTO [dbo].[InformeEnvasado] ([legajoTecnico],[TipoEnvase],[TemperaturaRefigeracion],[EtiquetaGenerada],[ProductoAutorizado],[InformeAutorizado],[NroAutorizacion]) VALUES (@legajoTecnico,@TipoEnvase,@TemperaturaRefigeracion,@EtiquetaGenerada,@ProductoAutorizado,@InformeAutorizado,@NroAutorizacion)", parameters))
                {
                    oDr = DB.ExecuteReader("SELECT top 1 [idInforme] FROM [dbo].[InformeEnvasado] order by [idInforme] desc");
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

        public static bool Update(InformeEnvasado inf)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajoTecnico", inf.LegajoTecnico));
                parameters.Add(new SqlParameter("@TipoEnvase", inf.TipoEnvase));
                parameters.Add(new SqlParameter("@TemperaturaRefigeracion", inf.TemperaturaRefrigeracion));
                parameters.Add(new SqlParameter("@EtiquetaGenerada", inf.EtiquetaGenerada));
                parameters.Add(new SqlParameter("@ProductoAutorizado", inf.ProductoAutorizado));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@NroAutorizacion", inf.NroAutorizacion));
                parameters.Add(new SqlParameter("@InformeAutorizado", inf.InformeAutorizado));
                parameters.Add(new SqlParameter("@idInforme", inf.IdInforme));
                retorno = DB.ExecuteNoQuery(" UPDATE [dbo].[InformeEnvasado] " +
                                            "SET [legajoTecnico] = @legajoTecnico, " +
                                            "[TipoEnvase] = @TipoEnvase, " +
                                            "[TemperaturaRefigeracion]  = @TemperaturaRefigeracion, " +
                                            "[EtiquetaGenerada] = @EtiquetaGenerada, " +
                                            "[ProductoAutorizado] = @ProductoAutorizado, " +
                                            "[InformeAutorizado] = @InformeAutorizado, " +
                                            "[NroAutorizacion]  = @NroAutorizacion, " +
                                            "[fechaModificacion] = getdate() " +
                                            " where idInforme = @idInforme", parameters); 
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
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[InformeEnvasado] where idInforme = @idInforme ", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
    }
}
