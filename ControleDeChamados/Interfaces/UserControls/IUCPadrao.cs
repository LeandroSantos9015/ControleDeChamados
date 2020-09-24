using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaces.UserControls
{
    public interface IUCPadrao
    {
        UserControl UCPadraoView { get; }

        TextBox Id { get; }

        TextBox Descricao { get; }

        GroupBox Grupo { get; }

        Label DescricaoLabel { get; }

    }
}
