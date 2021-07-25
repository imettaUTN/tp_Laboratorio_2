using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class TamizadorDAO
    {  
       public static bool Save(Tamizador persona)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@descripcion", persona.Descripcion));
                retorno = DB.ExecuteNoQuery("INSERT INTO [dbo].[Tamizador]([descripcion]) VALUES (@descripcion)", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }              
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
