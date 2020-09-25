using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizados.Mensagem.UserControls.Interfaces
{
    public interface ISucesso : IComportamentoMensagem
    {
       // UserControl View { get; }

        Button BtnOk { get; }

        

        void RealizaAlteracoes(Color cor, string mens);

    }
}
