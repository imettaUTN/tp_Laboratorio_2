using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
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
