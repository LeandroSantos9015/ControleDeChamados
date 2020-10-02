using GeradorComandosSQLServer.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorComandosSQLServer
{
    public partial class FrmGerador : Form, IGerador
    {
        public FrmGerador()
        {
            InitializeComponent();
        }

        public Form Principal => this;

        public Button BtnCopiar => btnCopiar;

        public Button BtnGerar => btnGerar;

        public RichTextBox RchResultado => rchResultado;

        public TextBox TxtBanco => txtBanco;
    }
}
