using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizados
{
    public static class ValidacaoCampos
    {
        // Estudar ainda como fazer, para validar todos de uma vez
        public static void ComposicaoVazia(string campo, TextBox textBox)
        {
            if (textBox.Text.Equals(String.Empty))
            {
                MessageBox.Show(String.Format("Campo {0} sem preencher", campo));
            }

        }

        public static string Texto(this Object dec)
        {
            if (dec != null)
                return Convert.ToString(dec);
            return String.Empty; // Caso não consiga converter não estoura exceção
        }

        public static Int64 Inteiro(this String obj)
        {
            if (obj != null && !obj.Equals(String.Empty))
                return Convert.ToInt64(obj);
            return 0;
        }

    }
}
