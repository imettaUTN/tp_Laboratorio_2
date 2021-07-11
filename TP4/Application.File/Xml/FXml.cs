using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Application.File.Xml
{
    /// <summary>
    /// Clase que se encarga de serializar y deserializar objetos. 
    /// Implementa una interfaz de genericos.
    /// Tema: interfaces, genericos y serializacion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FXml<T> : IFile<T>
    {
        public bool Read(string file, out T data) 
        {
            string ruta = AppDomain.CurrentDomain.BaseDirectory + @"\"+file+".xml";
            if(!System.IO.File.Exists(ruta))
            {
                //devuelvo un valor por default si no exite el archivo
                data = default(T);
                return false;
            }

            using (XmlTextReader reader = new XmlTextReader(ruta))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                data = (T)serializer.Deserialize(reader);
            }
            return true;
        }

        public bool Save(string file, T data)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;
            string ruta = AppDomain.CurrentDomain.BaseDirectory + @"\" + file + ".xml";

            try
            {
                writer = new XmlTextWriter(ruta, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, data);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return true;
        
    }
    }
}
