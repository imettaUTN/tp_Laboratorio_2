using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class TamizadorDAO
    {
        /// <summary>
        /// Guarda un tamizador en la db
        /// </summary>
        /// <param name="tamizador"></param>
        /// <returns></returns>
      public static bool Save(Tamizador tamizador)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@descripcion", tamizador.Descripcion));
                retorno = DB.ExecuteNoQuery("INSERT INTO [dbo].[Tamizador]([descripcion]) VALUES (@descripcion)", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        /// <summary>
        /// lista los tamizadores guardados en la db
        /// </summary>
        /// <returns></returns>
        public static List<DisplayObject> LeerTamizadoresParaCombo()
        {
            List<DisplayObject> mps = new List<DisplayObject>();
            SqlDataReader oDr = null;
            try
            {
                oDr = DB.ExecuteReader("SELECT idTamizador, descripcion FROM [Tamizador]");

                while (oDr.Read())
                {
                    mps.Add(new DisplayObject(oDr["descripcion"].ToString(), oDr["idTamizador"].ToString().ToInt()));
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
            return mps;
        }

    }
}
