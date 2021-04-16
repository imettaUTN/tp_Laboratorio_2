using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor por default
        /// </summary>
        public Numero()
        {
            numero = 0;
        }

        /// <summary>
        /// Sobrecarga constructor donde se asigna  un numero 
        /// </summary>
        /// <param name="numero" type ="Double">Parametro numero</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Sobrecarga constructor donde se asigna  un numero 
        /// </summary>
        /// <param name="numero" type ="String">Parametro Numero</param>
        public Numero(string numero)
        {
            var culture = new CultureInfo("en-US");
            this.numero = Double.Parse(numero.Replace(",", "."), culture.NumberFormat);
        }

        /// <summary>
        /// Asigna un valor al atributo numero, previa validacion.
        /// </summary>
        public string SetNumero
        {
            set { numero = ValidarNumero(value); }
        }
        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="strNumero"> numero decimal a convertir</param>
        /// <returns>Numero decimal convertido a binario, en caso de error indica "Valor invalido" </returns>
        public string DecimalBinario(string strNumero)
        {
            if(string.IsNullOrEmpty(strNumero))
            {
                return "Valor Invalido";
            }
            var culture = new CultureInfo("en-US");
            return DecimalBinario(Double.Parse(strNumero.Replace(",", "."), culture.NumberFormat));
        }
        /// <summary>
        /// Convierte un numero binario a decimal
        /// </summary>
        /// <param name="numero"> Numero binario a convertir </param>
        /// <returns> Numero binario convertido a decimal, en caso de error indica "Valor invalido"</returns>
        public string BinarioDecimal(string numero)
        {
            if (!EsBinario(numero))
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
        /// <summary>
        /// Convierte un numero decimal a binario
        /// </summary>
        /// <param name="strNumero"> numero decimal a convertir</param>
        /// <returns>Numero decimal convertido a binario, en caso de error indica "Valor invalido"</returns>
        public string DecimalBinario(double numero)
        {
            //Convierto explicitamente el numero doble a entero, para quedarme solo con la parte entera.
            numero = (int)numero;
            if (numero < 0)
            {
                numero *= -1;
            }
            String cadena = "";
            if (numero == 0) { return "0"; }

            while (numero > 0)
            {
                cadena += (numero % 2 == 0) ? "0" : "1";
                numero = (int)(numero / 2);
            }

            char[] aux = cadena.ToCharArray();
            Array.Reverse(aux);
            return new string(aux);
        }
        /// <summary>
        /// Indica si un valor es Binario
        /// </summary>
        /// <param name="binario">String del numero binario a validar</param>
        /// <returns>Es valido? true /  false </returns>
        private bool EsBinario(string binario)
        {
            return Regex.IsMatch(binario, "^[0-1]+$");
        }

        /// <summary>
        /// Suma dos numeros
        /// </summary>
        /// <param name="n1" type= "Numero"> Operando 1 </param>
        /// <param name="n2" type= "Numero"> Operando 2</param>
        /// <returns>Valor de la suma de los dos numeros en formato double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Resta dos numeros
        /// </summary>
        /// <param name="n1" type= "Numero"> Operando 1 </param>
        /// <param name="n2" type= "Numero"> Operando 2</param>
        /// <returns>Valor de la resta de los dos numeros en formato double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Multiplica dos numeros
        /// </summary>
        /// <param name="n1" type= "Numero"> Operando 1 </param>
        /// <param name="n2" type= "Numero"> Operando 2</param>
        /// <returns>Valor de la multiplicacion de los dos numeros en formato double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Division de dos numeros
        /// </summary>
        /// <param name="n1" type= "Numero"> Operando 1 </param>
        /// <param name="n2" type= "Numero"> Operando 2</param>
        /// <returns>Valor de la division de los dos numeros en formato double, 
        /// en caso de division por 0 devuelve double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if(n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Comprueba que el valor recibido sea numerico y lo retorna en formato double. 
        /// Caso contrario devuelve 0
        /// </summary>
        /// <param name="strNumero"> Numero en formato string</param>
        /// <returns>Numero en formato doble, 0 en caso que no sea numerico</returns>
        /// Segun la cultura instalada usa el . o la , como separador de decimales. Por eso permito ambos en los numeros al 
        /// momento de hacer la conversion si es valido lo pasara a double sino deja solo la parte entera
        private double ValidarNumero(string strNumero)
        {
            //Expresion regular para validar que sean todos numeros
            if (!Regex.IsMatch(strNumero, "\\d+(,?.?\\d+)?"))
            {
                return 0;
            }

            var culture = new CultureInfo("en-US");
            return Double.Parse(strNumero.Replace(",", "."), culture.NumberFormat);
        }

    }
}
