using Application.File.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        {  }

        /// <summary>
        /// Crea la materia prima
        /// </summary>
        public MateriaPrima(int idTanque,int idTampo, double indiceAcidez, string descripcion) : this()
        {
            this.idTanque = idTanque;
            this.IdTampo = idTampo;
            this.IndiceAcidez = indiceAcidez;
            this.idCertificado = DateTime.Now.Millisecond;
            this.descripcionMp = descripcion;
            this.idMateriaPrima = DateTime.Now.Millisecond;
        }
        /// <summary>
        /// carga el objeto a partir del xml deserializando el mismo.
        /// Tema Serializacion y archivos.
        /// </summary>
        public static MateriaPrima CargarMateriaPrima()
       {
            MateriaPrima mp;
            FXml<MateriaPrima> xml =new FXml<MateriaPrima>();
            string file = ConfigurationManager.AppSettings["ArchivoMateriaPrima"];
            //nose porque el united test no te toma el config
            if (file is null)
            {
                file = "MateriaPrima.xml";
            }
            xml.Read(file,out mp);
            return mp;
        }

        /// <summary>
        /// Guarda el objeto en un archivo xml serializando.
        /// Tema Serializacion y archivos.
        /// </summary>
        public static bool GuardarMateriaPrima(MateriaPrima mp)
        {
            FXml<MateriaPrima> xml = new FXml<MateriaPrima>();
            if(mp is null)
            {
                throw new Exception("Materia prima no puede ser nula");
            }
            string file = ConfigurationManager.AppSettings["ArchivoMateriaPrima"];
            //nose porque el united test no te toma el config
            if (file is null)
            {
                file = "MateriaPrima.xml";
            }
            xml.Save(file,  mp);
            return true;
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
