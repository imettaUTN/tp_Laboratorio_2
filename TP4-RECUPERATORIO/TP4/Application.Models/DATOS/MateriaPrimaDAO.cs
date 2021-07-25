using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class MateriaPrimaDAO
    {     
        public static MateriaPrima ReadByDescripcion(string descripcion)
        {
            MateriaPrima mp = new MateriaPrima();

            foreach(MateriaPrima matp in Read())
            {
                if(matp.Descripcion.Equals(descripcion))
                {
                    mp = matp;
                }
            }
            return mp;
        }

        public static MateriaPrima ReadMateriaPrimaPorId(int id)
        {
            MateriaPrima mp = new MateriaPrima();

            foreach (MateriaPrima matp in Read())
            {
                if (matp.IdMateriaPrima == id)
                {
                    mp = matp;
                }
            }
            return mp;
        }

        public static List<MateriaPrima> Read()
        {
            List<MateriaPrima> materiasPrimas = new List<MateriaPrima>();
            SqlDataReader oDr = null;

            try
            {
                 oDr = DB.ExecuteReader("SELECT [idMateriaPrima],[idTanque],[IdTampo],[descripcion],[IndiceAcidez],[legajoTecnicoHab],[habilitadoFabrica],[idcertificado]  FROM [MateriaPrima]");
                while (oDr.Read())
                {
                    MateriaPrima mprima = new MateriaPrima();

                    mprima.IdMateriaPrima = oDr["idMateriaPrima"].ToString().ToInt();
                    mprima.IdTampo = oDr["IdTampo"].ToString().ToInt();
                    mprima.IdTanque = oDr["idTanque"].ToString().ToInt();
                    mprima.Descripcion = oDr["descripcion"].ToString();
                    mprima.IndiceAcidez = oDr["IndiceAcidez"].ToString().ToInt();
                    mprima.LegajoTecnicoHabilitante = oDr["legajoTecnicoHab"].ToString().ToInt();
                    mprima.IdCertificado = oDr["idcertificado"].ToString().ToInt();
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
                if (!(oDr is null))
                {
                    oDr.Close();
                }
            }

            return materiasPrimas;

        }
        public static string ReadMateriaPrimaById(int idMateriaPrima)
        {
            string descripcion = string.Empty;
            SqlDataReader oDr = null;

            try                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                oDr = DB.ExecuteReader("SELECT [idMateriaPrima],[idTanque],[IdTampo],[descripcion],[IndiceAcidez],[legajoTecnicoHab],[habilitadoFabrica],[idcertificado]  FROM [MateriaPrima] where idMateriaPrima = " + idMateriaPrima);               
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
                if (!(oDr is null))
                {
                    oDr.Close();
                }
            }

            return descripcion;
        }
        public static bool Save(MateriaPrima mp)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@idTanque", mp.IdTanque));
                parameters.Add(new SqlParameter("@IdTampo", mp.IdTampo));
                parameters.Add(new SqlParameter("@descripcion", mp.Descripcion));
                parameters.Add(new SqlParameter("@IndiceAcidez", mp.IndiceAcidez));
                parameters.Add(new SqlParameter("@legajoTecnicoHab", mp.LegajoTecnicoHabilitante));
                parameters.Add(new SqlParameter("@idcertificado", mp.IdCertificado));
                parameters.Add(new SqlParameter("@habilitadoFabrica", mp.HabilitadoParaFabrica));
                retorno = DB.ExecuteNoQuery("INSERT INTO [MateriaPrima] ([idTanque],[IdTampo],[descripcion],[IndiceAcidez],[legajoTecnicoHab],[habilitadoFabrica],[idcertificado]) VALUES(@idTanque, @IdTampo, @descripcion,@IndiceAcidez,@legajoTecnicoHab,@habilitadoFabrica,@idcertificado)", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }
        public static List<DisplayObject> LeerTambos()
        {
            List<DisplayObject> tambos = new List<DisplayObject>();
            SqlDataReader oDr = null;

            try
            {
                oDr =DB.ExecuteReader("SELECT idTambo, descripcion FROM [Tambo]");
                while (oDr.Read())
                {
                    tambos.Add(new DisplayObject(oDr["descripcion"].ToString(), oDr["idTambo"].ToString().ToInt()));
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
            return tambos;
        }
        public static List<DisplayObject> LeerTanques()
        {
            List<DisplayObject> tambos = new List<DisplayObject>();
            SqlDataReader oDr = null;

            try
            {
                oDr =DB.ExecuteReader("SELECT idTanque, descripcion FROM [Tanque]");               

                while (oDr.Read())
                {
                    tambos.Add(new DisplayObject(oDr["descripcion"].ToString(), oDr["idTanque"].ToString().ToInt()));
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
            SqlDataReader oDr = null;

            try
            {
                oDr= DB.ExecuteReader("SELECT idMateriaPrima, descripcion FROM [MateriaPrima]");

                while (oDr.Read())
                {
                    mps.Add(new DisplayObject(oDr["descripcion"].ToString(), oDr["idMateriaPrima"].ToString().ToInt()));
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
