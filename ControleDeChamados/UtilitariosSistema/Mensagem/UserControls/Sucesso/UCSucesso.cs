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

namespace Customizados.Mensagem.UserControls.Sucesso
{
    public partial class UCSucesso : UserControl, ISucesso
    {
        public UCSucesso()
        {
            InitializeComponent();
        }

        public UserControl View { get { return this; } }

        public Button BtnOk { get { return this.btnOk; } }

        public Label LblDescricao { get { return this.lblDdescricao; } }

        public void RealizaAlteracoes(Color cor, string mens)
        {
            this.lblDdescricao.Text = mens;

            this.lblDdescricao.BackColor = cor;

            this.label2.BackColor = cor;

            this.label2.Image = this.reciclar.Image;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



    }
}
