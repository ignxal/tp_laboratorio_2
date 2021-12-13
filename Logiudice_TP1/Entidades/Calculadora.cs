using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    #region Metodos
    public static class Calculadora
    {
        /// <summary>
        /// Realiza operacion segun operador obtenido y validado
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador tipo char</param>
        /// <returns>Resultado de la operacion en tipo double</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            switch (ValidarOperador(operador))
            {
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                default:
                    resultado = num1 + num2;
                    break;
            }

            return resultado;
        }

        /// <summary>
        /// Valida parametro sea operador deseado
        /// </summary>
        /// <param name="operador">Operador a Validar</param>
        /// <returns>Si es correcto, operador de tipo string
        ///          Si no lo es, "+" de tipo char</returns>

        private static string ValidarOperador(char operador)
        {
            string operadorValidado = "+";

            if (operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                operadorValidado = operador.ToString();
            }

            return operadorValidado;
        }
        #endregion

    }
}
