using Interfaces.Chamados;
using Interfaces.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Chamados
{
    public partial class FrmChamado : Form, IChamado
    {
        public FrmChamado() { InitializeComponent(); }

        public Form ChamadosView => this;

        public FlowLayoutPanel FlwInteracoes => this.flwInteracoes;

        public FlowLayoutPanel FlwPrincipal => this.flwPrincipal;
    }
}
