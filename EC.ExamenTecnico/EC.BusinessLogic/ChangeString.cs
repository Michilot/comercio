using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.BusinessLogic
{

    public class ChangeString
    {

        private const int nRangoInicial = 97; //Inicio de ascii alfabeto minusculas
        private const int nRangoFinal = 122; //Fin de ascii alfabeto minusculas
        private const string nEñe = "ñ";
        private const string nEne = "n";

        /// <summary>
        /// Reemplazar cada letra de la cadena con la letra siguiente en el alfabeto.
        /// </summary>
        /// <param name="sCadena"></param>
        /// <returns></returns>
        public string build(string sCadena)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < sCadena.Length; i++)
            {
                if (char.IsUpper(sCadena[i]))
                    result.Append(CambiarCadena(sCadena[i].ToString()).ToUpper());
                else
                    result.Append(CambiarCadena(sCadena[i].ToString()));
            }
            return result.ToString();
        }

        /// <summary>
        /// Obtiene la siguiente letra si esta dentro del alfabeto
        /// </summary>
        /// <param name="sLetra"></param>
        /// <returns></returns>
        private string CambiarCadena(string sLetra)
        {
            Common oCommon = new Common();
            string sCadenaSalida = string.Empty;
            int nAscii = (int)Convert.ToChar(sLetra.ToLower());
            if (Enumerable.Range(nRangoInicial, nRangoFinal).Contains(nAscii))
            {
                if (nAscii == nRangoFinal)
                    sCadenaSalida = oCommon.ConvertirAscii(nRangoInicial);
                else if (sLetra.Equals(nEne))
                    sCadenaSalida = nEñe;
                else
                    sCadenaSalida = oCommon.ConvertirAscii(nAscii + 1);
            }
            else if (sLetra.ToLower().Equals(nEñe))
            {
                sCadenaSalida = oCommon.ConvertirAscii(111);
            }
            else
            {
                sCadenaSalida = oCommon.ConvertirAscii(nAscii);
            }
            return sCadenaSalida;
        }
    }
}
