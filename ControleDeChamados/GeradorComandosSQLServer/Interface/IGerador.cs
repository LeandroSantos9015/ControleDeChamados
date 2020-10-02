using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorComandosSQLServer.Interface
{
    public interface IGerador
    {
        Form Principal { get; }

        Button BtnCopiar { get; }

        Button BtnGerar{ get; }

        RichTextBox RchResultado { get; }

        TextBox TxtBanco { get; }



    }
}
