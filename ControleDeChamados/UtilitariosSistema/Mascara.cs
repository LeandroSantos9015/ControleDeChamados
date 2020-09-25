using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosSistema.Mascaras
{
    public static class Mascara
    {
        public static string CpfCnpj(this string formatoMascara)
        {
            string temp = formatoMascara;

            formatoMascara = temp.SomenteNumeros();

            if (formatoMascara.Length == 14) return formatoMascara.Substring(0, 2) + "." + formatoMascara.Substring(2, 3) + "."
                    + formatoMascara.Substring(5, 3) + "." + formatoMascara.Substring(8, 4) + "/" + formatoMascara.Substring(12, 2);

            else if (formatoMascara.Length == 11) return formatoMascara.Substring(0, 3) + "." + formatoMascara.Substring(3, 3) + "."
                    + formatoMascara.Substring(6, 3) + "-" + formatoMascara.Substring(9, 2);

            else return formatoMascara;
        }

        public static string RemoveMascara(this string texto)
        {
            return texto.Trim()
               .Replace(".", "")
               .Replace(",", "")
               .Replace("-", "")
               .Replace("/", "")
               .Replace("(", "")
               .Replace(")", "")
               .Replace(@"\", "")
               .Replace(@" ", "")
               .Replace(@"'", "");

        }

        public static string RemoveCaracter(this string texto)
        {
            return texto.Trim().Replace(@"'", "");
        }

        public static string CEP(this string texto)
        {
            if (texto.Length >= 8) return texto.Substring(0, 5) + "-" + texto.Substring(5, 3);
            return texto;

        }

    }
}