using System;
using System.Data.SqlClient;

namespace Application.Models.DATOS
{
    public  class DB
    {
        public static string connectionstring
        {
            get { return @"Data Source=LAPTOP-MR9I54DN\SQLEXPRESS;Initial Catalog=Lacteos;Persist Security Info=False;User=ivan;Password=Utnavellaneda2021;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True"; }
        }

        public static SqlDataReader ExecuteReader(string sqlQuery, System.Collections.Generic.List<SqlParameter> parameters)
        {
           
            SqlConnection cn;
            SqlCommand cm;
            cn = new SqlConnection(DB.connectionstring);
            cm = new SqlCommand(sqlQuery, cn);
            try
            {
                cm.Parameters.AddRange(parameters.ToArray());
                cm.CommandTimeout = 0;
                cn.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return cm.ExecuteReader();
        }

        public static SqlDataReader ExecuteReader(string sqlQuery)
        {
            SqlConnection cn;
            SqlCommand cm;
            cn = new SqlConnection(DB.connectionstring);
            cm = new SqlCommand(sqlQuery, cn);
            cm.CommandTimeout = 0;
            cn.Open();
            return cm.ExecuteReader();
        }

        public static bool ExecuteNoQuery(string sqlQuery, System.Collections.Generic.List<SqlParameter> parameters)
        {
            SqlConnection cn;
            SqlCommand cm;
            bool respuesta = false;
            cn = new SqlConnection(DB.connectionstring);
            cm = new SqlCommand(sqlQuery, cn);
            try
            {
                cm.Parameters.AddRange(parameters.ToArray());
                cn.Open();
                respuesta = cm.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return respuesta;
        }

        public static bool ExecuteNoQuery(string sqlQuery)
        {
            SqlConnection cn;
            SqlCommand cm;
            bool respuesta = false;
            cn = new SqlConnection(DB.connectionstring);
            cm = new SqlCommand(sqlQuery, cn);
            try
            {
                cn.Open();
                respuesta = cm.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State == System.Data.ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return respuesta;
        }

    }
}
