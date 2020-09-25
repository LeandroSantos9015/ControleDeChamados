using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customizados.Mensagem.UserControls.Interfaces;

namespace Customizados.Mensagem.UserControls.SimNao
{
    public partial class UCPergunta : UserControl, IPergunta
    {
        public UCPergunta()
        {
            InitializeComponent();
        }

        public UserControl View { get { return this; } }

        public Button BtnNao { get { return this.btnNao; } }

        public Button BtnSim { get { return this.btnSim; } }

        public Label LblDescricao { get { return this.lblDescricao; } }

        public void RealizaAlteracoes(Color cor, string mens)
        {
            this.lblDescricao.Text = mens;

            this.lblDescricao.BackColor = cor;

            this.label2.BackColor = cor;

            this.label2.Image = this.reciclar.Image;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}

