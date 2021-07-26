using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Application.Models.DATOS
{
    public static class AditivosDAO
    {
        public static List<DisplayObject> LeerAditivos()
        {
            List<DisplayObject> aditivos = new List<DisplayObject>();
            SqlDataReader oDr = null;

            try
            {
                oDr = DB.ExecuteReader("SELECT idAditivo, descripcion FROM [aditivo]");
                while (oDr.Read())
                {
                    aditivos.Add(new DisplayObject(oDr["descripcion"].ToString(), oDr["idAditivo"].ToString().ToInt()));
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

            return aditivos;
        }
        public static DisplayObject LeerAditivo(string desc)
        {
            DisplayObject aditivos = new DisplayObject();
            SqlDataReader oDr = null;
            try
            {

                oDr = DB.ExecuteReader("SELECT idAditivo, descripcion FROM [aditivo]  where descripcion = " + "'" + desc + "'");

                while (oDr.Read())
                {
                    aditivos = new DisplayObject(oDr["descripcion"].ToString(), oDr["idAditivo"].ToString().ToInt());
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
            return aditivos;
        }
        public static bool Save(AditivoProducto aditivo)
        {
            bool retorno = false;

            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@descripcion", aditivo.Descripcion));
                retorno = DB.ExecuteNoQuery("INSERT INTO [Aditivo] ([descripcion]) VALUES(@descripcion,@TipoAditivo)", parameters);

            }
            catch (Exception e)
            {
                throw e;
            }

            return retorno;
        }

        public static List<AditivoProducto> LeerAditivosLacteos(int idLacteo)
        {
            List<AditivoProducto> lista = new List<AditivoProducto>();
            SqlDataReader oDr = null;
            try
            {
                oDr = DB.ExecuteReader("SELECT [idAditivo],[cantidad],[descripcion],[tipo] FROM [Aditivos_lacteos]  where id_lacteo = " + "'" + idLacteo + "'");

                while (oDr.Read())
                {
                    AditivoProducto al = new AditivoProducto();
                    al.ID = oDr["idAditivo"].ToString().ToInt();
                    al.Cantidad = oDr["cantidad"].ToString().ToDouble();
                    al.Descripcion = oDr["descripcion"].ToString();
                    al.Tipo = oDr["tipo"].ToString();
                    lista.Add(al);
                }

            }
            catch(Exception e)
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

            return lista;
        }

        public static bool SaveAditivoLacteo(AditivoProducto aditivo, int idLacteo)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idAditivo", aditivo.ID));
                parameters.Add(new SqlParameter("@cantidad", aditivo.Cantidad));
                parameters.Add(new SqlParameter("@descripcion", aditivo.Descripcion));
                parameters.Add(new SqlParameter("@tipo", aditivo.Tipo));
                parameters.Add(new SqlParameter("@idLacteo", idLacteo));
                retorno = DB.ExecuteNoQuery("INSERT INTO [Aditivos_lacteos] ([idAditivo],[cantidad],[descripcion],[tipo],[id_lacteo]) VALUES(@idAditivo,@cantidad,@descripcion,@tipo,@idLacteo)", parameters);

            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        public static bool DeleteAditivoLacteo(int idLacteo)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idLacteo", idLacteo));
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[aditivos_lacteos] where id_lacteo = @idLacteo ", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
    }
}

