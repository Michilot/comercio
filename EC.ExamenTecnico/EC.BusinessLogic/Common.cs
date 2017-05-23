using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.BusinessLogic
{
    public class Common
    {
        /// <summary>
        /// Convierte a ASCII el valor ingresado
        /// </summary>
        /// <param name="sValor"></param>
        /// <returns></returns>
        public string ConvertirAscii(int sValor)
        {
            return Convert.ToChar(sValor).ToString();
        }

        /// <summary>
        /// Valida si valor ingresado en numérico
        /// </summary>
        /// <param name="sValor"></param>
        /// <returns></returns>
        public bool IsNumeric(string sValor)
        {
            float sSalida;
            return float.TryParse(sValor, out sSalida);
        }

        /// <summary>
        /// Repite valor la cantidad de veces indicada y lo concatena con un valor
        /// </summary>
        /// <param name="Cantidad"></param>
        /// <param name="sValor"></param>
        /// <returns></returns>
        public string CadenaRepetida(int Cantidad, double sValor, char sSeparador)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Cantidad; i++)
            {
                result.Append(string.Concat(sValor.ToString(), sSeparador));
            }
            return string.Concat(result.ToString().TrimEnd(sSeparador));
        }

        /// <summary>
        /// Retira el ultimo caracter indicado
        /// </summary>
        /// <param name="Cantidad"></param>
        /// <param name="sValor"></param>
        /// <param name="sSeparador"></param>
        /// <returns></returns>
        public string RetirarUltimoCaracter(string sValor, char sCaracter)
        {
            return sValor.ToString().TrimEnd(sCaracter);
        }

        /// <summary>
        /// Retorna cantidad de decimales
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ObtenerNumeroDecimales(decimal n)
        {
            n = Math.Abs(n); //make sure it is positive.
            n -= (int)n;     //remove the integer part of the number.
            var decimalPlaces = 0;
            while (n > 0)
            {
                decimalPlaces++;
                n *= 10;
                n -= (int)n;
            }
            return decimalPlaces;
        }


    }
}
