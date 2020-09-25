using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeradores
{
    /// <summary>
    /// Interface apenas para controlar os tipos de campos a serem validados se seus valores estiverem incorrettos
    /// </summary>
    public enum ETipoCampo
    {
        [Description("CEP")]
        Cep = 1,
        [Description("CPF")]
        Cpf = 2,
        [Description("CNPJ")]
        Cnpj = 3,
        [Description("CPF e CPNJ")]
        CpfCnpj = 4,

    }
}
