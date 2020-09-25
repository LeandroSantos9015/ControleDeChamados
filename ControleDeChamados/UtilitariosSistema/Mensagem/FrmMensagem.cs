using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizados.Mensagem
{
    public partial class FrmMensagem : Form, IMensagem
    {
        public FrmMensagem()
        {
            InitializeComponent();
        }

        public Form Mensagem { get { return this; } }

        public FlowLayoutPanel FlwPainel { get { return this.flwPainel; } }

        public String Titulo
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

    }
}
