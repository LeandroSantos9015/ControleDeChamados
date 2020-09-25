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

namespace Customizados.Mensagem.UserControls.Erro
{
    public partial class UCErro : UserControl, IErro
    {
        public UCErro()
        {
            InitializeComponent();
        }

        public UserControl View { get { return this; } }

        public Button BtnOk { get { return this.btnOk; } }

        public Button BtnDetalhes { get { return this.btnDetalhes; } }

        public Label LblDescricao { get; }


    }
}
