using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.File.Text
{
    /// <summary>
    /// Clase que se encarga de leer y grabar archivos. 
    /// Implementa una interfaz de genericos.
    /// Tema: interfaces, archivos y genericos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FTexto<T> : IFile<T>
    {
        /// <summary>
        /// lee el contenido de un achivo
        /// </summary>
        /// <param name="file"> ruta del archivo </param>
        /// <param name="data"> data donde se devolvera el archivo</param>
        /// <returns></returns>
        public bool Read(string file, out string data)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(file);

                string text = string.Empty;
                string newLine = streamReader.ReadLine();

                while (newLine != null)
                {
                    text += newLine + "\n";
                    newLine = streamReader.ReadLine();
                }
                data = text;
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
            return true;
        }

        public bool Save(string file, T data)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(file, true);
                streamWriter.WriteLine(data);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
            return true;
        }
    }
}
