using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaces.UserControls;

namespace View.UserControlPadrao
{
    public partial class UCPadrao : UserControl, IUCPadrao
    {
        public UCPadrao() { InitializeComponent(); }

        public UserControl UCPadraoView => this;

        public TextBox Id => this.txtId;

        public TextBox Descricao => this.txtDescricao;

        public GroupBox Grupo => this.grp;

        public Label DescricaoLabel => this.descLabel;

        public Label LblAtivo => lblAtivo;

    }
}
