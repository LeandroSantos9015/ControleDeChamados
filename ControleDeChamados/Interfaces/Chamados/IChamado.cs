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

        TextBox TxtAbertoPor { get; }

        ComboBox CbmOperador { get; }

        ComboBox CbmPrioridade { get; }

        ComboBox CbmEtapa { get; }

        ComboBox CbmStatus { get; }

        ComboBox CbmCategoria { get; }

        DateTimePicker DataAbertura { get; }

        DateTimePicker DataSolucao { get; }

        Button BtnAtender { get; }

        Button BtnInteragir { get; }


    }
}
