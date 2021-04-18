using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Dado un operador matematico devuelve un operador valido
        /// </summary>
        /// <param name="operador"> Operador </param>
        /// <returns>En caso de operador valido, el mismo operador, sino + </returns>
        private static string ValidarOperador(char operador)
        {
            //lo hago con un switch para validar los operadores validos +/*-
            switch (operador)
            {
                case '+': return "+";
                case '-': return "-";
                case '/': return "/";
                case '*': return "*";
                default: return "+";
            }
            
        }
        /// <summary>
        /// Realiza la operacion entre los dos operandos y el operador, validando el operador.
        /// </summary>
        /// <param name="num1"> Operando 1 del tipo Numero</param>
        /// <param name="num2"> Operando 2 del tipo Numero</param>
        /// <param name="operador"> Operacionn a realizar</param>
        /// <returns> Resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            string operacionARealizar = string.Empty;
            char operacionValidaAHacer = new char();

            operacionValidaAHacer = Convert.ToChar(operador);
            if (string.IsNullOrEmpty(operador))
            {
                operacionARealizar = ValidarOperador(operacionValidaAHacer);
            }

            double resultado = 0;
            switch(operador)
            {
                case "+": resultado = num1 + num2; break;
                case "-": resultado = num1 - num2; break;
                case "/": resultado = num1 / num2; break;
                case "*": resultado = num1 * num2; break;
            }
            return resultado;
        }
    }
}
