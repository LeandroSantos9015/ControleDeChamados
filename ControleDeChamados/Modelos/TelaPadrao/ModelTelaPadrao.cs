using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelos.TelaPadrao
{
    public class ModelTelaPadrao
    {
        public Int64? Id { get; set; }

        public String Descricao { get; set; }

        public String DescricaoLabel { get; set; }

        public FlowLayoutPanel Painel { get; set; }
    }
}
