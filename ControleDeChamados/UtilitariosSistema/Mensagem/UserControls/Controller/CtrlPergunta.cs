using Customizados.Mensagem.MensagemLivre;
using Customizados.Mensagem.UserControls.Erro;
using Customizados.Mensagem.UserControls.Interfaces;
using Customizados.Mensagem.UserControls.SimNao;
using System;

namespace Customizados.Mensagem.UserControls.Controller
{
    public class CtrlPergunta
    {
        public IPergunta Pergunta { get; set; }

        private string local = String.Empty;

        private string msgPergunta = String.Empty;

        private IMensagem Mensagem { get; set; }

        public CtrlPergunta(string local, string msgPergunta)
        {
            this.Mensagem = Mensagem;

            this.local = local;

            this.msgPergunta = msgPergunta;

            this.Pergunta = new UCPergunta();

            DelegarEventos();
        }

        private void InvocaMensagem()
        {
            new CtrlMsgLivre(this.msgPergunta);


        }


        private void DelegarEventos()
        {
            this.Pergunta.BtnNao.Click += BtnNao_Click;

            this.Pergunta.BtnSim.Click += BtnSim_Click;

        }



        void BtnSim_Click(object sender, EventArgs e)
        {
            this.Pergunta.View.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;

            //this.InvocaMensagem();
        }

        void BtnNao_Click(object sender, EventArgs e)
        {
            this.Pergunta.View.ParentForm.DialogResult = System.Windows.Forms.DialogResult.No;
        }
    }
}
