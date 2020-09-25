using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosSistema.Conversores
{
    public static class Conversor
    {
        /// <summary>
        /// Retorna uma lista de ids separados por virgula
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        /// 

        public static Decimal ValorOuPadrao(this decimal? numero, decimal valor)
        {
            return numero == null ? valor : numero.Value;
        }

        public static Int64 ValorOuPadrao(this Int64? numero, Int64 valor)
        {
            return numero == null ? valor : numero.Value;
        }
    }
}
