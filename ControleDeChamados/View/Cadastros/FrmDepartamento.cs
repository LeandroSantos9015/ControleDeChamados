using Interfaces.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Cadastros
{
    public partial class FrmDepartamento : Form, IDepartamento
    {
        public FrmDepartamento() { InitializeComponent(); }

        public Form Formulario => this;

        public FlowLayoutPanel Painel => flwPanel;
    }
}
