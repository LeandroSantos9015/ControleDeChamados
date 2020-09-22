using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensagens.Mensagem
{
    public interface IMensagem
    {
        Form Mensagem { get; }

        FlowLayoutPanel FlwPainel { get; }

        String Titulo { get; set; }
    }
}
