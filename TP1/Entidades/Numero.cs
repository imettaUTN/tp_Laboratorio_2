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
        public string DecimalBinario(string strNumero)
        {
            return DecimalBinario(double.Parse(strNumero));
        }
        public string BinarioDecimal(string numero)
        {
            if(!EsBinario(numero))
            {
                return "Valor Invalido";
            }
            int numeroBinario = int.Parse(numero);
            int numeroDecimal = 0;
            int baseCalculo = 1;

            while (numeroBinario > 0)
            {
                int resto = numeroBinario % 10;
                numeroBinario = numeroBinario / 10;
                numeroDecimal += resto * baseCalculo;
                baseCalculo = baseCalculo * 2;
            }
        
            return numeroDecimal.ToString();
        }
        public string DecimalBinario(double numero)
        {
            numero = Convert.ToInt32(numero);
            String cadena = "";
            if (numero == 0) { return "0"; }
            if (numero > 0)
            {
                while (numero > 0)
                {
                    cadena += (numero % 2 == 0) ?"0": "1";
                    numero = (int)(numero / 2);
                }
            }
            char[] aux = cadena.ToCharArray();
             Array.Reverse(aux);
            return new string(aux);
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
