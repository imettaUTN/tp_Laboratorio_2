using Application.Models.DATOS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public static class StringExtension
    {
        public static string GetMensaje(this string dato)
        {
            return dato + " a las :" + DateTime.Now.ToString("yyyy-MM-dd hh:mm");
        }

        public static double ToDouble(this string dato)
        {
            if(String.IsNullOrEmpty(dato))
            {
                return Double.MinValue;
            }
            var culture = new CultureInfo("en-US");
           return  Double.Parse(dato.Replace(",", "."), culture.NumberFormat);
        }

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
