using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeradores
{
    /// <summary>
    /// Flag para tipo ativo
    /// </summary>
    //[Flags]
    public enum EAtivo
    {
        [Description("ATIVO")]
        Ativo = 1,
        [Description("INATIVO")]
        Inativo = 2,
        [Description("TODOS")]
        Todos = 4
    }
}
