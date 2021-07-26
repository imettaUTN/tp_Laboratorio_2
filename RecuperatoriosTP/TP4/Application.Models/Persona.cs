using Application.Models.DATOS;
using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class Persona
    {
        private int legajo;
        private int dni;
        private string nombre;
        private string apellido;
        private string cargo;
        private string genero;
        private bool esTecnico;

        public Persona() { }
        public Persona(int legajo, int dni, string nombre, string apellido, string cargo, string genero, bool esTenico)
        {
            this.Legajo = legajo;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Cargo = cargo;
            this.Genero = genero;
            this.EsTecnico = esTenico;

        }

        public bool EsTecnico
        {
            get { return this.esTecnico; }
            set { this.esTecnico = value; }
        }
        public int Legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }
        public int Dni
        {
            get { return this.dni; }
            set { this.dni = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public string Apellido
        {
            get { return this.apellido; }
            set { this.apellido = value; }
        }
        public string Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public string Genero
        {
            get { return this.genero; }
            set { this.genero = value; }
        }

        /// <summary>
        /// Guarda una persona en la db
        /// </summary>
        /// <returns></returns>
        public bool Guardar()
        {
            bool result = false;
            try
            {
                result = PersonaDAO.Save(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Elimina una persona
        /// </summary>
        /// <returns></returns>
        public bool Eliminar()
        {
            bool result = false;
            try
            {
                result = PersonaDAO.Eliminar(this.Legajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Indica si existe un legajo en la base de datos
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public static bool ExisteLegajo(int legajo)
        {
            bool result = false;
            try
            {
                result = PersonaDAO.ExistesLegajo(legajo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Lee las personas de la db
        /// </summary>
        /// <returns></returns>
        public static List<Persona> Leer()
        {
            return PersonaDAO.Read();
        }

        /// <summary>
        /// Lee una persona de la db segun su legajo
        /// </summary>
        /// <param name="legajo"></param>
        /// <returns></returns>
        public static Persona LeerByLegajo(int legajo)
        {
            return PersonaDAO.ReadPersonaByLegajo(legajo);
        }


    }
}
