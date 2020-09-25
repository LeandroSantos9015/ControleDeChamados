using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizados.Mensagem.UserControls.Interfaces
{
    public interface IPergunta : IComportamentoMensagem
    {
       // UserControl View { get; }

       // UserControl SucessoView { get; }

        Button BtnNao { get; }

        Button BtnSim { get; }

       // Label LblDescricao { get; }

        void RealizaAlteracoes(Color cor, string mens);
    }
}



