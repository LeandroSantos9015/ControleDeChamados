using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizados
{
    public static class RetornoEventosCustomizados
    {

        public static string RetornaTextoParaBusca(this object sender, KeyPressEventArgs e)
        {
            string stringDigitada = "";

            if (e.KeyChar == '\b')
                (sender as TextBox).SelectionStart = (sender as TextBox).Text.Length;

            else
                stringDigitada = e.KeyChar.ToString();

            string texto = (sender as TextBox).Text + stringDigitada;

            if (e.KeyChar == '\b')
            {
                if (texto.Length > 0)
                    texto = texto.Substring(0, texto.Length - 1);
            }

            return texto;
        }
    }
}
