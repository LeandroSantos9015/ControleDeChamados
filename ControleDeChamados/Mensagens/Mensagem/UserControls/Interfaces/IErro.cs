using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensagens.Mensagem.UserControls.Interfaces
{
    public interface IErro : IComportamentoMensagem
    {
       // UserControl View { get; }

        //Label 

        Button BtnOk { get; }

        Button BtnDetalhes { get; }

    }
}
