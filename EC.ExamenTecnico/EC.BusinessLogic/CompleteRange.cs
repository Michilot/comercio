using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.BusinessLogic
{
    public class CompleteRange
    {

        /// <summary>
        /// Completar rango de numeros y devolverlo ordenado completando los faltantes
        /// </summary>
        /// <param name="sCadena"></param>
        /// <returns></returns>
        public string build(string sCadena)
        {
            int nMax = 0;
            int nValor = 0;
            Common oCommon = new Common();
            string[] numeros = sCadena.Split(',');
            foreach (var sValor in numeros)
            {
                if (oCommon.IsNumeric(sValor))
                {
                    nValor = int.Parse(sValor);
                    if (nValor > nMax)
                    {
                        nMax = nValor;
                    }
                }
            }
            return GenerarRango(nMax);
        }

        /// <summary>
        /// Generar rango desde el numero 1 hasta un maximo indicado
        /// </summary>
        /// <param name="Maximo"></param>
        /// <returns></returns>
        private string GenerarRango(int Maximo)
        {
            StringBuilder result = new StringBuilder();
            string sSalida = string.Empty;
            for (int i = 1; i <= Maximo; i++)
            {
                result.Append(i).Append(',');
            }
            sSalida = result.ToString().TrimEnd(',');
            return sSalida;
        }

    }
}
