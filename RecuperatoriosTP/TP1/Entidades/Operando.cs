using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        #region Atributos

        private double numero;

        #endregion

        #region Propiedades
        /// <summary>
        /// Setter de atributo numero 
        /// </summary>
        private string Numero
        {
            set
            {
                this.numero = this.ValidarOperando(Convert.ToString(value));
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto, set atributo 0
        /// </summary>
        public Operando() : this(0)
        { }

        /// <summary>
        /// Constructor con parametro, setea double
        /// </summary>
        /// <param name="numero">Tipo double</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor con parametro, setea string
        /// </summary>
        /// <param name="strNumero">Tipo string</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Recorre cadena y valida, ademas de no estar vacia, sea un numero binario 
        /// </summary>
        /// <param name="binario">Cadena</param>
        /// <returns>True si lo es, false si no</returns>
        private bool EsBinario(string binario)
        {
            bool esBinario = true;

            if (binario.Length == 0)
            {
                esBinario = false;
            }

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    esBinario = false;
                    break;
                }
            }

            return esBinario;
        }

        /// <summary>
        /// Valida binario, convierte a decimal y pasa a string
        /// </summary>
        /// <param name="binario">A convertir tipo string</param>
        /// <returns>Si es valido, binario en tipo string sino mensaje de error</returns>
        public string BinarioDecimal(string binario)
        {
            string retornoValor = "Valor invalido";

            if (this.EsBinario(binario))
            {
                retornoValor = Convert.ToUInt64(binario, 2).ToString();
            }

            return retornoValor;
        }

        /// <summary>
        /// Convierte decimal a binario (trabaja con numeros positivos)
        /// </summary>
        /// <param name="numero">Double decimal</param>
        /// <returns>String o mensaje de error</returns>
        public string DecimalBinario(double numero)
        {
            /*
            string retornoValor = "";
            // Devuelve valor absoluto (0 ≤ numero ≤ double.maxvalue)
            ulong numeroInt = (ulong)Math.Abs(numero);

            // Valido que no sea el caso == 0
            if (numeroInt == 0)
            {
                retornoValor = "0";
            }
            else
            {
                while (numeroInt > 0)
                {
                    if (numeroInt % 2 == 0)
                    {
                        retornoValor += "0";
                    }
                    else
                    {
                        retornoValor += "1";
                    }
                    numeroInt = numeroInt / 2;
                }
            }
            return retornoValor;*/
            string binario = null;
            int numeroAux = (int)numero;
            int resto;

            while (numeroAux > 1)
            {
                resto = numeroAux % 2;
                binario = resto.ToString() + binario;
                numeroAux = numeroAux / 2;
            }
            binario = numeroAux.ToString() + binario;

            return binario;
        }

        /// <summary>
        /// Parsea cadena y convierte decimal a binario (trabaja con numeros positivos)
        /// </summary>
        /// <param name="numero">String decimal</param>
        /// <returns>String o mensaje de error</returns>
        public string DecimalBinario(string numero)
        {
            string retornoValor = "Valor invalido";

            if (double.TryParse(numero, out this.numero))
            {
                // En vez de usar Convert, reutilizo codigo
                retornoValor = DecimalBinario(this.numero);
            }

            return retornoValor;
        }

        /// <summary>
        /// Valida si valor recibido es numerico
        /// </summary>
        /// <param name="strNumero">Cadena</param>
        /// <returns>Si lo es retorna double sino 0</returns>
        private double ValidarOperando (string strNumero)
        {
            double numero = 0;

            double.TryParse(strNumero, out numero); // Intento parseo string -> double

            return numero;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Sobrecarga operador menos
        /// </summary>
        /// <param name="n1">Operando 1</param>
        /// <param name="n2">Operando 2</param>
        /// <returns>Resultado</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador multiplicacion
        /// </summary>
        /// <param name="n1">Operador 1</param>
        /// <param name="n2">Operador 2</param>
        /// <returns>Resultado</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga operador divisor
        /// </summary>
        /// <param name="n1">Operador 1</param>
        /// <param name="n2">Operador 2</param>
        /// <returns>Resultado, en caso de que n2 sea 0 minValue</returns>

        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;

            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero - n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Sobrecarga operador suma
        /// </summary>
        /// <param name="n1">Operador 1</param>
        /// <param name="n2">Operador 2</param>
        /// <returns>Resultado</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        #endregion
    }
}
