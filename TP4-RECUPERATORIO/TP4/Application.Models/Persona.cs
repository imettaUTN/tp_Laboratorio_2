using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Persona(int legajo, int dni, string nombre, string apellido , string cargo, string genero,bool esTenico)
        {
            this.Legajo = legajo;
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Cargo = cargo;
            this.Genero = genero;
            this.EsTecnico = EsTecnico;

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

        public  bool Guardar()
        {
            return PersonaDAO.Save(this);
        }

        public static bool ExisteLegajo(int legajo)
        {
            return PersonaDAO.ExistesLegajo(legajo);
        }

        public static List<Persona> Leer()
        {
            return PersonaDAO.Read();
        }
        public static Persona LeerByLegajo(int legajo)
        {
            return PersonaDAO.ReadPersonaByLegajo(legajo);
        }


    }
}
