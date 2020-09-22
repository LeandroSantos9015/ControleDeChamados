using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mensagens.Mensagem.UserControls.Interfaces;

namespace Mensagens.Mensagem.UserControls.Alerta
{
    public partial class UCAlerta : UserControl, IAlerta
    {
        public UCAlerta()
        {
            InitializeComponent();
        }

        public UserControl View { get { return this; } }

        public Button BtnOk { get { return this.btnOk; } }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public Label LblDescricao { get; }


    }
}
