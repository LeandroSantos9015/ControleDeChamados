using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.PesquisarDTO
{
    /// <summary>
    /// Implementar esta interface nos modelos que vão para salvar no banco para utilizar na tela de pesquisa
    /// </summary>
    public interface IConsultaPesquisar
    {

        string Consulta { get; }

    }
}
