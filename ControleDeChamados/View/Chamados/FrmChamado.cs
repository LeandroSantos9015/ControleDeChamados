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

        public Form Formulario => this;

        public FlowLayoutPanel Painel => this.flwPrincipal;

        public FlowLayoutPanel FlwInteracoes => this.flwInteracoes;

    }
}
