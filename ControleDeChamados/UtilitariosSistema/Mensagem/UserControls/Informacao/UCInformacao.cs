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

namespace Customizados.Mensagem.UserControls.Alerta
{
    public partial class UCInformacao : UserControl, IInformacao
    {
        public UCInformacao()
        {
            InitializeComponent();
        }

        public UserControl View { get { return this; } }

        public Button BtnOk { get { return this.btnOk; } }

        public Label LblDescricao { get { return this.lblDescricaoMsg; } }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDescricaoMsg_Click(object sender, EventArgs e)
        {

        }

        private void UCAlerta_Load(object sender, EventArgs e)
        {

        }
        
    }
}
