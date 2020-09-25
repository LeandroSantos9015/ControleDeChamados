using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customizados
{
    public static class SetDataSource
    {
        public static string Mostrador = "Value";

        public static string Valor = "Key";

        public static IList Carregar(Type tipo) { return EnumPelaDescricao.Listar(tipo); }


    }
}
