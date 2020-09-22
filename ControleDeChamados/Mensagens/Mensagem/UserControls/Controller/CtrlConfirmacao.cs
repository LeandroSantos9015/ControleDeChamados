using Mensagens.Mensagem.UserControls.Sucesso;
using Mensagens.Mensagem.UserControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mensagens.Mensagem.UserControls.Controller
{
    public class CtrlSucesso
    {
        public ISucesso SucessoView { get; set; }

        private string exibeMensagens = String.Empty;

        private IMensagem Mensagem { get; set; }

        public CtrlSucesso(string exibeMensagens, bool ativo)
        {
            this.Mensagem = Mensagem;

            this.exibeMensagens = exibeMensagens;

            this.SucessoView = new UCSucesso();

            this.SucessoView.LblDescricao.Text = exibeMensagens;

            if (!ativo)
            {
                DadosExcluidosComSucesso();
            }

            DelegarEventos();
        }

        private void DelegarEventos()
        {
            //            this.ConfirmacaoView.LblDescricao.Text = exibeMensagens;

            this.SucessoView.BtnOk.Click += BtnOk_Click;

        }

        void BtnOk_Click(object sender, EventArgs e)
        {
            this.SucessoView.View.ParentForm.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void DadosExcluidosComSucesso()
        {
            this.SucessoView.RealizaAlteracoes(Color.Gray, this.exibeMensagens);
        }

    }
}
