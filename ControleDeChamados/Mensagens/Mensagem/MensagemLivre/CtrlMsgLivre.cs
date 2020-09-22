using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensagens.Mensagem.MensagemLivre
{
    public class CtrlMsgLivre
    {
        IMsgLivre MsgLivre { get; set; }

        public CtrlMsgLivre(string mensagem)
        {
            this.MsgLivre = new FrmMsgLivre();

            DelegarEventos();

            this.MsgLivre.Texto.Text = mensagem;

            this.MsgLivre.MensagemLivreView.ShowDialog();
        }

        private void DelegarEventos()
        {
            this.MsgLivre.BtnCopiar.Click += BtnCopiar_Click;

            this.MsgLivre.BtnSair.Click += BtnSair_Click;
        }

        void BtnSair_Click(object sender, EventArgs e)
        {
            this.MsgLivre.MensagemLivreView.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        void BtnCopiar_Click(object sender, EventArgs e)
        {
            //this.MsgLivre.Texto.Text.CopyTo
        }
    }
}
