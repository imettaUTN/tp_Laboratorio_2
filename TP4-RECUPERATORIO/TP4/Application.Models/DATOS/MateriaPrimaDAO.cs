using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class MateriaPrimaDAO
    {
        /// <summary>
        /// Lee un materia en base a su descripcion
        /// </summary>
        /// <param name="descripcion"> descripcion de la materia prima</param>
        /// <returns> objeto materia prima</returns>
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

        /// <summary>
        /// Busca una materia prima en base a su id
        /// </summary>
        /// <param name="id"> id materia prima</param>
        /// <returns> objeto materia prima </returns>
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

        /// <summary>
        /// lee todas las materia primas de la db
        /// </summary>
        /// <returns>lista de todos las materias primas cargadas en la db</returns>
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
       
        /// <summary>
        /// Guarda una materia en la base de datos
        /// </summary>
        /// <param name="mp"> objeto materia prima a guardar</param>
        /// <returns>booleando indicando si se guardo ok o no</returns>
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

        /// <summary>
        /// Lee los datos en la db para los combos de la aplicacion
        /// </summary>
        /// <returns>Lista de tambos</returns>
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

        /// <summary>
        /// Lee los datos en la db para los combos de la aplicacion
        /// </summary>
        /// <returns>Lista de tanques</returns>
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

        /// <summary>
        /// Lee una materia prima para segun id
        /// </summary>
        /// <param name="idMateriaPrima"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Lee materias primas para la aplicacion en la db
        /// </summary>
        /// <returns> lista de objetos de mp</returns>
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
