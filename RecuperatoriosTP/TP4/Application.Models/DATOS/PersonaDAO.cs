using Application.UIModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Application.Models.DATOS
{
    public static class PersonaDAO
    {
        /// <summary>
        /// Lee una persona de la db en base al legajo
        /// </summary>
        /// <param name="legajo">legajo</param>
        /// <returns>objeto persona</returns>
        public static Persona ReadPersonaByLegajo(int legajo)
        {
            Persona persona = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            SqlDataReader oDr = null;

            try
            {
                parameters.Add(new SqlParameter("@legajo", legajo));
                oDr = DB.ExecuteReader("SELECT [legajo],[dni],[nombre],[apellido],[cargo],[genero],[esTecnico] FROM [dbo].[Personal ]where legajo = @legajo", parameters);
                while (oDr.Read())
                {
                    Persona per = new Persona();
                    per.Legajo = oDr["legajo"].ToString().ToInt();
                    per.Dni = oDr["dni"].ToString().ToInt();
                    per.Nombre = oDr["nombre"].ToString();
                    per.Apellido = oDr["apellido"].ToString();
                    per.Cargo = oDr["cargo"].ToString();
                    per.Genero = oDr["genero"].ToString();
                    persona = per;
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
            return persona;
        }

        /// <summary>
        /// Leee una lista de personas de la db
        /// </summary>
        /// <returns>lista de personas</returns>
        public static List<Persona> Read()
        {
            List<Persona> personas = new List<Persona>();
            SqlDataReader oDr = null;

            try
            {
                 oDr = DB.ExecuteReader("SELECT [legajo],[dni],[nombre],[apellido],[cargo],[genero],[esTecnico] FROM [dbo].[Personal] ");
                while (oDr.Read())
                {
                    Persona persona = new Persona();
                    persona.Legajo = oDr["legajo"].ToString().ToInt();
                    persona.Dni = oDr["dni"].ToString().ToInt();
                    persona.Nombre = oDr["nombre"].ToString();
                    persona.Apellido = oDr["apellido"].ToString();
                    persona.Cargo = oDr["cargo"].ToString();
                    persona.Genero = oDr["genero"].ToString();
                    persona.EsTecnico = Boolean.Parse(oDr["esTecnico"].ToString());
                    personas.Add(persona);
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
            return personas;
        }

        /// <summary>
        /// Guarda una persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public static bool Save(Persona persona)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajo", persona.Legajo));
                parameters.Add(new SqlParameter("@dni", persona.Dni));
                parameters.Add(new SqlParameter("@nombre", persona.Nombre));
                parameters.Add(new SqlParameter("@apellido", persona.Apellido));
                parameters.Add(new SqlParameter("@cargo", persona.Cargo));
                parameters.Add(new SqlParameter("@genero", persona.Genero));
                parameters.Add(new SqlParameter("@esTecnico", persona.EsTecnico));
                retorno = DB.ExecuteNoQuery("INSERT INTO [dbo].[Personal]([legajo],[dni],[nombre],[apellido],[cargo],[genero],[esTecnico]) VALUES (@legajo,@dni,@nombre,@apellido,@cargo,@genero,@esTecnico)", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        /// <summary>
        /// Elimina una persona de la db
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public static bool Eliminar(int legajo)
        {
            bool retorno = false;
            List<SqlParameter> parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(new SqlParameter("@legajo", legajo));
                retorno = DB.ExecuteNoQuery("DELETE FROM [dbo].[Personal] WHERE legajo = @legajo", parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
            return retorno;
        }

        /// <summary>
        /// Indica si existe un legajo en la db
        /// </summary>
        /// <param name="legajo">legajo</param>
        /// <returns></returns>
        public static bool ExistesLegajo(int legajo)
        {
            SqlDataReader oDr = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            bool retorno = false;
            try
            {
                parameters.Add(new SqlParameter("@legajo",legajo));
                oDr = DB.ExecuteReader("SELECT [legajo],[dni],[nombre],[apellido],[cargo],[genero] FROM [dbo].[Personal] where legajo = @legajo",parameters);
                retorno = oDr.HasRows;

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
            return retorno;
        }

        /// <summary>
        /// Lista las personas que son tecnicas para la aplicacion
        /// </summary>
        /// <returns></returns>
        public static List<DisplayObject> LeerTecnicosParaCombo()
        {
            List<DisplayObject> mps = new List<DisplayObject>();
            SqlDataReader oDr = null;
            try
            {
                oDr = DB.ExecuteReader("SELECT legajo, apellido FROM [Personal] where esTecnico = 1 ");

                while (oDr.Read())
                {
                    mps.Add(new DisplayObject(oDr["apellido"].ToString(), oDr["legajo"].ToString().ToInt()));
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
