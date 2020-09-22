using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensagens.Mensagem.UserControls.Interfaces
{
    public interface IComportamentoMensagem
    {
        UserControl View { get; }

        Label LblDescricao { get; }

    }
}
