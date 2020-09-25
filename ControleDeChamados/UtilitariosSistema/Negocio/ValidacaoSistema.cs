using Customizados.ValidacoesDeMensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosSistema;

namespace Customizados.Negocio
{
    public static class ValidacaoSistema
    {
        public static string ValidaChave(string chave, string contraChave)
        {
            string valor = chave.UtilCifrar();

            // retirar caracteres
            valor = valor.Replace("+", "");
            valor = valor.Replace("/", "");
            valor = valor.Replace("=", "");

            int mes = Convert.ToInt16(DateTime.Now.ToString("MM"));

            ++mes;

            if (valor.ToUpper().StartsWith(contraChave.ToUpper()))
                return mes.ToString();

            return null;
        }
    }
}
