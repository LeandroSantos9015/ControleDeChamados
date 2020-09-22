using Mensagens.Mensagem.UserControls.Alerta;
using Mensagens.Mensagem.UserControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensagens.Mensagem.UserControls.Controller
{
    public class CtrlAlerta
    {
        public IAlerta Alerta { get; set; }

        private string exibeMensagens = String.Empty;

        private IMensagem Mensagem { get; set; }

        public CtrlAlerta(string exibeMensagens)
        {
            this.Mensagem = Mensagem;

            this.exibeMensagens = exibeMensagens;

            this.Alerta = new UCAlerta();

            DelegarEventos();
        }

        private void DelegarEventos()
        {
            this.Alerta.BtnOk.Click += BtnOk_Click;

        }

        void BtnOk_Click(object sender, EventArgs e)
        {
            this.Alerta.View.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
