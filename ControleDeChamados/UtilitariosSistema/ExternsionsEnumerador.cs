using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosSistema
{
   public static class ExternsionsEnumerador
    {

        public static String GetCategory(this Enum en)
        {
            //Verifica se o parâmetro é null
            FieldInfo elementEnum = (en != null) ? en.GetType().GetField(en.ToString()) : null;
            //Se o Length for 0, significa que o Enum não tem nenhum elemento
            if (elementEnum != null)
            {
                object[] customDescription = elementEnum.GetCustomAttributes(typeof(CategoryAttribute), false);
                return (customDescription.Length == 0) ? en.ToString() : ((CategoryAttribute)customDescription[0]).Category;
            }
            else
                return null;
        }
    }
}
