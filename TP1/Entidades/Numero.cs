using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public  class Numero
    {
        private double numero;

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            this.numero = double.Parse(numero);
        }
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }
        public  string BinarioDecimal(string strBinario)
        {
            double numeroBinario = 0; ;
            if (!EsBinario(strBinario))
            {
                return "Valor Invalido";
            }
            numeroBinario = Math.Abs(int.Parse(strBinario));

            int numero = 0;
            int cociente = 0;
            const int baseAConvertir = 10;

            for (double resto = numeroBinario, exponente = 0; resto > 0; resto /= baseAConvertir, exponente++)
            {
                cociente = (int)resto % baseAConvertir;
                //validacion extra, se supone que si no es binario paso la primer validacion
                if (cociente != 1 && cociente != 0)
                {
                    return "Valor Invalido";
                }
                numero += cociente * (int)Math.Pow(2, exponente);
            }

            return numero.ToString();
        }
        public  string DecimalBinario(string numero)
        {
            double numeroAConvertir;
            if (!double.TryParse(numero, out numeroAConvertir))
            {
                return "Valor Invalido";
            }
            return DecimalBinario(numeroAConvertir);
        }
        public  string DecimalBinario(double numero)
        {
            int binario = 0;
            int numeroAConvertir = Convert.ToInt32(Math.Abs(numero));
            const int baseAConvertir = 2;
            int cociente = 0;

            for (int resto = numeroAConvertir % baseAConvertir, exponente = 0; numero > 0; numero /= baseAConvertir, resto = Convert.ToInt32(numero % baseAConvertir), exponente++)
            {
                cociente = resto % baseAConvertir;
                binario += cociente * (int)Math.Pow(10, exponente);
            }
            return binario.ToString();
        }
        private bool EsBinario(string binario)
        {
           return Regex.IsMatch(binario, "^[0-1]+$");
        }
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }
        private double ValidarNumero(string strNumero) { 
           if(!Regex.IsMatch(strNumero,"\\d+"))
            {
                return 0;
            }
            return Double.Parse(strNumero);
        }
    }
}
