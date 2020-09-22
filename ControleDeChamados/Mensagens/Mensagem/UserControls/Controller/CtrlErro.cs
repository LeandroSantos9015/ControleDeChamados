using Mensagens.Mensagem.MensagemLivre;
using Mensagens.Mensagem.UserControls.Erro;
using Mensagens.Mensagem.UserControls.Interfaces;
using System;

namespace Mensagens.Mensagem.UserControls.Controller
{
    public class CtrlErro
    {
        public IErro Erro { get; set; }

        private string exibeMensagens = String.Empty;

        private string msgErro = String.Empty;

        private IMensagem Mensagem { get; set; }

        public CtrlErro(string exibeMensagens, string msgErro)
        {
            this.Mensagem = Mensagem;

            this.exibeMensagens = exibeMensagens;

            this.msgErro = msgErro;

            this.Erro = new UCErro();

            DelegarEventos();
        }

        private void InvocaMensagem()
        {
            new CtrlMsgLivre(this.msgErro);


        }


        private void DelegarEventos()
        {
            this.Erro.BtnOk.Click += BtnOk_Click;

            this.Erro.BtnDetalhes.Click += BtnDetalhes_Click;

        }

        void BtnDetalhes_Click(object sender, EventArgs e)
        {
            this.InvocaMensagem();
        }

        void BtnOk_Click(object sender, EventArgs e)
        {
            this.Erro.View.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
