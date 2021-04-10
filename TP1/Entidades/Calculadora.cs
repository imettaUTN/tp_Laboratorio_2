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
        /// Dado un operador matematico indica si es valido o no
        /// </summary>
        /// <param name="operador"> Operador </param>
        /// <returns>En caso de operador valido, el mismo operador, sino + </returns>
        private static string ValidarOperador(string operador)
        {
            switch (operador)
            {
                case "+": return "+";
                case "-": return "-";
                case "/": return "/";
                case "*": return "*";
            }
            return "+";
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
            operacionARealizar = ValidarOperador(operador);
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
