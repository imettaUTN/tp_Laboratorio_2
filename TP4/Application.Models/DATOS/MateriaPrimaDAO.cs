using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class MateriaPrimaDAO
    {
        private static SqlCommand command;
        private static string cadenaConexion = @"Data Source=LAPTOP-MR9I54DN\SQLEXPRESS;Initial Catalog=Lacteos;Persist Security Info=False;User=ivan;;Password=Utnavellaneda2021;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True";
        private static SqlConnection conexion;

        static MateriaPrimaDAO()
        {
            command = new SqlCommand();
            conexion = new SqlConnection(cadenaConexion);
        }

        public static List<MateriaPrima> Read()
        {
            List<MateriaPrima> materiasPrimas = new List<MateriaPrima>();
            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [idMateriaPrima],[idTanque],[IdTampo],[descripcion],[IndiceAcidez],[legajoTecnicoHab],[habilitadoFabrica],[idcertificado]  FROM [MateriaPrima]";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();
                while (oDr.Read())
                {
                    MateriaPrima mprima = new MateriaPrima();

                    mprima.IdMateriaPrima = Convert.ToInt32(oDr["idMateriaPrima"]);
                    mprima.IdTampo = Convert.ToInt32(oDr["IdTampo"]);
                    mprima.IdTanque = Convert.ToInt32(oDr["idTanque"]);
                    mprima.Descripcion = oDr["descripcion"].ToString();
                    mprima.IndiceAcidez = Convert.ToInt32(oDr["IndiceAcidez"]);
                    mprima.LegajoTecnicoHabilitante = Convert.ToInt32(oDr["legajoTecnicoHab"]);
                    mprima.IdCertificado = Convert.ToInt32(oDr["idcertificado"]);
                    mprima.HabilitadoParaFabrica = Boolean.Parse(oDr["habilitadoFabrica"].ToString());
                    materiasPrimas.Add(mprima);
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

            return materiasPrimas;

        }

        public static string ReadMateriaPrimaById(int idMateriaPrima)
        {
            string descripcion = string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT [idMateriaPrima],[idTanque],[IdTampo],[descripcion],[IndiceAcidez],[legajoTecnicoHab],[habilitadoFabrica],[idcertificado]  FROM [MateriaPrima] where idMateriaPrima = " + idMateriaPrima;
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();
                while (oDr.Read())
                {
                    descripcion = oDr["descripcion"].ToString();
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

            return descripcion;
        }

        public static bool Save(MateriaPrima mp)
        {
            bool retorno = false;

            try
            {
                command.Parameters.Clear();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO [MateriaPrima] ([idTanque],[IdTampo],[descripcion],[IndiceAcidez],[legajoTecnicoHab],[habilitadoFabrica],[idcertificado]) VALUES(@idTanque, @IdTampo, @descripcion,@IndiceAcidez,@legajoTecnicoHab,@habilitadoFabrica,@idcertificado)";
                command.Parameters.AddWithValue("@idTanque", mp.IdTanque);
                command.Parameters.AddWithValue("@IdTampo", mp.IdTampo);
                command.Parameters.AddWithValue("@descripcion", mp.Descripcion);
                command.Parameters.AddWithValue("@IndiceAcidez", mp.IndiceAcidez);
                command.Parameters.AddWithValue("@legajoTecnicoHab", mp.LegajoTecnicoHabilitante);
                command.Parameters.AddWithValue("@idcertificado", mp.IdCertificado);
                command.Parameters.AddWithValue("@habilitadoFabrica", mp.HabilitadoParaFabrica);
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


        public static List<DisplayObject> LeerTambos()
        {
            List<DisplayObject> tambos = new List<DisplayObject>();

            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT idTambo, descripcion FROM [Tambo]";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();

                while (oDr.Read())
                {
                    tambos.Add(new DisplayObject(oDr["descripcion"].ToString(), Convert.ToInt32(oDr["idTambo"])));
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
            return tambos;
        }
        public static List<DisplayObject> LeerTanques()
        {
            List<DisplayObject> tambos = new List<DisplayObject>();

            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT idTanque, descripcion FROM [Tanque]";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();

                while (oDr.Read())
                {
                    tambos.Add(new DisplayObject(oDr["descripcion"].ToString(), Convert.ToInt32(oDr["idTanque"])));
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
            return tambos;
        }
        public static DisplayObject LeerMateriaPrimaParaCombo(int idMateriaPrima)
        {
            DisplayObject dobj = new DisplayObject();

            foreach(DisplayObject d in LeerMateriaPrimaParaCombo())
            {
                if(d.Value == idMateriaPrima)
                {
                    dobj= d;
                }
            }
            return dobj;
        }
            public static List<DisplayObject> LeerMateriaPrimaParaCombo()
        {
            List<DisplayObject> mps= new List<DisplayObject>();

            try
            {
                StringBuilder sb = new StringBuilder();
                command.Connection = conexion;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT idMateriaPrima, descripcion FROM [MateriaPrima]";
                conexion.Open();
                SqlDataReader oDr = command.ExecuteReader();

                while (oDr.Read())
                {
                    mps.Add(new DisplayObject(oDr["descripcion"].ToString(), Convert.ToInt32(oDr["idMateriaPrima"])));
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
            return mps;
        }
    }
}
