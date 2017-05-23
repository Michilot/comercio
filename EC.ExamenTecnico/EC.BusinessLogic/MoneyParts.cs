using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.BusinessLogic
{
    public class MoneyParts
    {

        private List<double> loDenominacion = new List<double> { 0.05, 0.1, 0.2, 0.5, 1, 2, 5, 10, 20, 50, 100, 200 };

        /// <summary>
        /// Ingresa un monto en soles y devuelve todas las combinaciones monetarias posibles de un rango.
        /// </summary>
        /// <param name="sValor"></param>
        /// <returns></returns>
        public string build(double sValor)
        {
            //string[] sResult = DenominacionCadena(sValor, TipoResiduo.Padre).Split('@');
            string sResult = DenominacionCadena(sValor, TipoResiduo.Padre).Replace("@", ",\r\n");
            return sResult;
        }



        private string DenominacionCadena(double sValor, TipoResiduo oTipoResiduo)
        {

            List<double> loDenomValidas = loDenominacionValidas(sValor);
            List<string> loCadenaSalida = new List<string>();
            Common oCommon = new Common();

            double nResiduo = 0;
            int nCantXDenominacion = 0;
            string CadenaSalida = string.Empty;
            string CadenaSalidaHija = string.Empty;

            foreach (double sDenominacion in loDenomValidas)
            {
                nCantXDenominacion = CantidadxDenominacion(sDenominacion, sValor, out nResiduo);
                if (nResiduo == 0)
                {
                    CadenaSalida = oCommon.CadenaRepetida(nCantXDenominacion, sDenominacion, ',');
                    loCadenaSalida.Add(string.Concat("[", CadenaSalida, "]"));
                }
                else
                {
                    CadenaSalida = string.Concat("[", oCommon.CadenaRepetida(nCantXDenominacion, sDenominacion, ','), "]");
                    CadenaSalidaHija = oCommon.RetirarUltimoCaracter(DenominacionCadena(nResiduo, TipoResiduo.Hijo), '-');

                    string[] loCadenaHija = CadenaSalidaHija.Split('-');
                    foreach (string sHija in loCadenaHija)
                    {
                        if (!string.IsNullOrEmpty(sHija))
                        {
                            loCadenaSalida.Add(string.Concat(CadenaSalida, ",", sHija));
                        }
                    }

                }
            }

            StringBuilder result = new StringBuilder();
            foreach (string oCadena in loCadenaSalida)
            {
                result.Append(oTipoResiduo == TipoResiduo.Hijo ? string.Concat(oCadena, "-") : string.Concat("[", oCadena, "]@"));
            }
            return oCommon.RetirarUltimoCaracter(result.ToString(), '@');
        }




        private int CantidadxDenominacion(double dDenominacion, double sValor, out double nResiduo)
        {
            int nCantXDenominacion = 0;
            nResiduo = 0;
            nCantXDenominacion = (int)(sValor / dDenominacion);
            nResiduo = Math.Round((sValor - (nCantXDenominacion * dDenominacion)), 2); // Math.Round(sValor % dDenominacion, 2);
            return nCantXDenominacion;
        }


        private List<double> loDenominacionValidas(double sValor)
        {
            List<double> loDenominacionValidas = new List<double>();
            foreach (double sDenominacion in loDenominacion)
            {
                if (sDenominacion <= sValor)
                    loDenominacionValidas.Add(sDenominacion);
                else
                    break;
            }
            return loDenominacionValidas;
        }

        private enum TipoResiduo
        {
            Padre = 0,
            Hijo = 1
        }

    }
}
