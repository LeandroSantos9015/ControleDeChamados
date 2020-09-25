using Interfaces.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces.Chamados
{
    public interface IChamado : IGenerica
    {
        FlowLayoutPanel FlwInteracoes { get; }
    }
}
