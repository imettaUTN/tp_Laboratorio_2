using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DATOS
{
    public static class AditivosDAO
    {
        private static SqlCommand command;
        private static string cadenaConexion = @"Data Source=LAPTOP-MR9I54DN\SQLEXPRESS;Initial Catalog=Lacteos;Persist Security Info=False;User=ivan;;Password=Utnavellaneda2021;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
        private static SqlConnection conexion;

        static AditivosDAO()
        {
            command = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
        }

        public static List<DisplayObject> LeerAditivos()
        {
            List<DisplayObject> aditivos = new List<DisplayObject>();

            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT idAditivo, descripcion FROM [aditivo]";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();

                while (oDr.Read())
                {
                    aditivos.Add(new DisplayObject(oDr["descripcion"].ToString(), Convert.ToInt32(oDr["idAditivo"])));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
            return aditivos;
        }
        public static DisplayObject LeerAditivo(string desc )
        {
            DisplayObject aditivos = new DisplayObject();

            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT idAditivo, descripcion FROM [aditivo]  where descripcion = " + "'"+ desc + "'";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();

                while (oDr.Read())
                {
                    aditivos = new DisplayObject(oDr["descripcion"].ToString(), Convert.ToInt32(oDr["idAditivo"]));
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
            return aditivos;
        }
        public static bool GrabarAditivo(AditivoProducto aditivo)
        {
            bool retorno = false;

            try
            {
                command.Parameters.Clear();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO [Aditivo] ([descripcion]) VALUES(@descripcion,@TipoAditivo)";
                command.Parameters.AddWithValue("@descripcion", aditivo.Descripcion);
                conexion.Open();
                retorno = command.ExecuteNonQuery() > 0;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
            return retorno;
        }

    }
}
