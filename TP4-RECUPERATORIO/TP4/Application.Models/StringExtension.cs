using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    /// <summary>
    /// Tema: extensiones
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Modifica el mensaje a mostrar al final de un proceso
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static string GetMensaje(this string dato)
        {
            return dato + " a las :" + DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        }

        /// <summary>
        /// Convierte un texto en un doble
        /// </summary>
        /// <param name="dato">dato</param>
        /// <returns> texto convertido a doble</returns>
        public static double ToDouble(this string dato)
        {
            if(String.IsNullOrEmpty(dato))
            {
                return Double.MinValue;
            }
            var culture = new CultureInfo("en-US");
           return  Double.Parse(dato.Replace(",", "."), culture.NumberFormat);
        }

        /// <summary>
        /// Convierte un texto en un integer
        /// </summary>
        /// <param name="dato">dato</param>
        /// <returns> texto convertido a int</returns>
        public static int ToInt(this string dato)
        {
            if (String.IsNullOrEmpty(dato))
            {
                return int.MinValue;
            }
            var culture = new CultureInfo("en-US");
            return int.Parse(dato.Replace(",", "."), culture.NumberFormat);
        }
    }
}
