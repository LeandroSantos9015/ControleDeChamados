using Mensagens.Mensagem.UserControls.Alerta;
using Mensagens.Mensagem.UserControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensagens.Mensagem.UserControls.Controller
{
    public class CtrlInformacao
    {
        public IInformacao Informacao { get; set; }

        private string exibeMensagens = String.Empty;

        private IMensagem Mensagem { get; set; }

        public CtrlInformacao(string exibeMensagens)
        {
            this.Mensagem = Mensagem;
            
            this.exibeMensagens = exibeMensagens;

            this.Informacao = new UCInformacao();

            DelegarEventos();
        }

        private void DelegarEventos()
        {
            this.Informacao.LblDescricao.Text = exibeMensagens;

            this.Informacao.BtnOk.Click += BtnOk_Click;

        }

        void BtnOk_Click(object sender, EventArgs e)
        {
            this.Informacao.View.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
