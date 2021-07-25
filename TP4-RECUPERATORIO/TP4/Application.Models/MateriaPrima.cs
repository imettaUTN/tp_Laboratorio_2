using Application.File.Xml;
using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Application.Models
{
    public class MateriaPrima
    {
        private int idTanque;
        private int idTampo;
        private double indiceAcides;
        private int idCertificado;
        private int legajoTecnicoHabilitante;
        private bool habilitadoParaFabrica;
        private int idMateriaPrima;
        private string descripcionMp;

        public MateriaPrima()
        { }

        /// <summary>
        /// Crea la materia prima
        /// </summary>
        public MateriaPrima(int idTanque, int idTampo, double indiceAcidez, string descripcion) : this()
        {
            this.idTanque = idTanque;
            this.IdTampo = idTampo;
            this.IndiceAcidez = indiceAcidez;
            this.idCertificado = DateTime.Now.Millisecond;
            this.descripcionMp = descripcion;
            this.idMateriaPrima = DateTime.Now.Millisecond;
        }
        /// <summary> Tema serializacion
        /// carga el objeto a partir del xml deserializando el mismo.
        /// Tema Serializacion y archivos.
        /// </summary>
        public static List<MateriaPrima> CargarMateriaPrima()
        {
            try
            {
                List<MateriaPrima> mp;
                FXml<List<MateriaPrima>> xml = new FXml<List<MateriaPrima>>();
                string file = ConfigurationManager.AppSettings["ArchivoMateriaPrima"];
                if (xml.Read(file, out mp))
                {
                    return mp;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary> Tema Base de datos/sql
        /// Guarda el objeto en la base de datos
        /// </summary>
        public static bool GuardarMateriaPrima(MateriaPrima mp)
        {
            //LO GUARDO EN LA BASE DE DATOS 
            MateriaPrimaDAO.Save(mp);
            return true;
        }

        /// <summary> Tema Base de datos/sql
        /// lee de la base de datos las materias primas
        /// </summary>
        public static List<MateriaPrima>  LeerMateriaPrima()
        {
            return MateriaPrimaDAO.Read();
        }

        /// <summary> Tema serializacion
        /// Guarda la lista de objetos en un archivo serializado
        /// </summary>
        /// <param name="mp">lista de objetos de materia prima</param>
        /// <returns></returns>
        public static bool GuardarMateriaPrima(List<MateriaPrima> mp)
        {
            try
            {
                FXml<List<MateriaPrima>> xml = new FXml<List<MateriaPrima>>();
                string file = ConfigurationManager.AppSettings["ArchivoMateriaPrima"];
                xml.Save(file, mp);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int IdMateriaPrima
        {
            get { return this.idMateriaPrima; }
            set { this.idMateriaPrima = value; }
        }

        public string Descripcion
        {
            get { return this.descripcionMp; }
            set { this.descripcionMp = value; }
        }
        public int IdTanque
        {
            get { return this.idTanque; }
            set { this.idTanque = value; }
        }
        public bool HabilitadoParaFabrica
        {
            get { return this.habilitadoParaFabrica; }
            set { this.habilitadoParaFabrica = value; }
        }

        public int IdTampo
        {
            get { return this.idTampo; }
            set { this.idTampo = value; }
        }
        public double IndiceAcidez
        {
            get { return this.indiceAcides; }
            set { this.indiceAcides = value; }
        }
        public int IdCertificado
        {
            get { return this.idCertificado; }
            set { this.idCertificado = value; }
        }
        public int LegajoTecnicoHabilitante
        {
            get { return this.legajoTecnicoHabilitante; }
            set { this.legajoTecnicoHabilitante = value; }
        }


    }
}
