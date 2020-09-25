using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customizados.Mensagem.MensagemLivre
{
    public partial class FrmMsgLivre : Form, IMsgLivre
    {
        public FrmMsgLivre()
        {
            InitializeComponent();
        }

        public Form MensagemLivreView { get { return this; } }

        public Button BtnCopiar { get { return this.btnCopiar; } }

        public Button BtnSair { get { return this.btnSair; } }

        public RichTextBox Texto { get { return this.richTexto; } }

        public String Titulo { get { return this.Text; } }
    }
}
