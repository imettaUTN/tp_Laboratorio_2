using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class LacteoDAO
    {
        private static SqlCommand command;
        private static string cadenaConexion = @"Data Source=LAPTOP-MR9I54DN\SQLEXPRESS;Initial Catalog=Lacteos;Persist Security Info=False;User=ivan;;Password=Utnavellaneda2021;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
        private static SqlConnection conexion;

        static LacteoDAO()
        {
            command = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
        }

        public static Lacteo ReadById(int idLacteo)
        {
            Lacteo lacteo = new Lacteo() ;

            foreach(Lacteo lac in LacteoDAO.Read())
            {
                if(lac.IdLacteo == idLacteo )
                {
                    lacteo = lac;
                }
            }

            return lacteo;
        }



        public static List<Lacteo> Read()
        {
            List<Lacteo> listaRetorno = new List<Lacteo>();

            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [TipoProducto],[IdMateriaPrima],[IdLacteo],[idOllaPasteurizacion],[metodoPasteurizacion],[estandarizado],[pasteurizado],[enfriado]  FROM [Lacteo]";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();
                while (oDr.Read())
                {
                    Lacteo lact = new Yogurth();
                     lact.TipoProducto = oDr["TipoProducto"].ToString();
                    lact.IdMateriaPrima = Convert.ToInt32(oDr["IdMateriaPrima"]);
                    lact.IdLacteo = Convert.ToInt32(oDr["IdLacteo"]);
                    lact.IdOllaPasteurizacion = Convert.ToInt32(oDr["idOllaPasteurizacion"]);
                    lact.MetodoPasteurizacion = oDr["metodoPasteurizacion"].ToString();
                    lact.Estandarizado = Boolean.Parse(oDr["estandarizado"].ToString());
                    lact.Pasteurizado = Boolean.Parse(oDr["pasteurizado"].ToString());
                    lact.Enfriado = Boolean.Parse(oDr["enfriado"].ToString());
                    listaRetorno.Add(lact);
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
            return listaRetorno;
        }

        public static bool Save(Lacteo lacteo)
        {
            bool retorno = false;

            try
            {
                command.Parameters.Clear();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO [Lacteo] ([TipoProducto],[IdMateriaPrima],[IdLacteo],[idOllaPasteurizacion],[metodoPasteurizacion],[estandarizado],[pasteurizado],[enfriado]) VALUES(@TipoProducto,@IdMateriaPrima,@IdLacteo,@idOllaPasteurizacion,@metodoPasteurizacion,@estandarizado,@pasteurizado,@enfriado)";
                command.Parameters.AddWithValue("@TipoProducto", lacteo.TipoProducto);
                command.Parameters.AddWithValue("@IdMateriaPrima", lacteo.IdMateriaPrima );
                command.Parameters.AddWithValue("@IdLacteo", lacteo.IdLacteo);
                command.Parameters.AddWithValue("@idOllaPasteurizacion", lacteo.IdOllaPasteurizacion);
                command.Parameters.AddWithValue("@metodoPasteurizacion", lacteo.MetodoPasteurizacion);
                command.Parameters.AddWithValue("@estandarizado", lacteo.Estandarizado);
                command.Parameters.AddWithValue("@pasteurizado", lacteo.Pasteurizado);
                command.Parameters.AddWithValue("@enfriado", lacteo.Enfriado);
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

        public static bool Update(Lacteo lacteo)
        {
            bool retorno = false;

            try
            {
                command.Parameters.Clear();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "UPDATE [Lacteo] " +
                    "SET [TipoProducto] = @TipoProducto," +
                    " [IdLacteo] = @IdLacteo," +
                    " [idOllaPasteurizacion] = @idOllaPasteurizacion," +
                    " [metodoPasteurizacion] = @metodoPasteurizacion," +
                    " [estandarizado] = @estandarizado," +
                    " [pasteurizado] = @pasteurizado," +
                    " [enfriado] = @enfriado" +
                    " WHERE [IdMateriaPrima] = @IdMateriaPrima";                    ;
                command.Parameters.AddWithValue("@TipoProducto", lacteo.TipoProducto);
                command.Parameters.AddWithValue("@IdMateriaPrima", lacteo.IdMateriaPrima);
                command.Parameters.AddWithValue("@IdLacteo", lacteo.IdLacteo);
                command.Parameters.AddWithValue("@idOllaPasteurizacion", lacteo.IdOllaPasteurizacion);
                command.Parameters.AddWithValue("@metodoPasteurizacion", lacteo.MetodoPasteurizacion);
                command.Parameters.AddWithValue("@estandarizado", lacteo.Estandarizado);
                command.Parameters.AddWithValue("@pasteurizado", lacteo.Pasteurizado);
                command.Parameters.AddWithValue("@enfriado", lacteo.Enfriado);
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

        public static bool Delete(Lacteo lacteo)
        {
            bool retorno = false;

            try
            {
                command.Parameters.Clear();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM [Lacteo] WHERE [IdMateriaPrima] = @IdMateriaPrima"; 
                command.Parameters.AddWithValue("@IdMateriaPrima", lacteo.IdMateriaPrima);

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
