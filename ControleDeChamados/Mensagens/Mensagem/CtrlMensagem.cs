using Mensagens.Mensagem.UserControls.Controller;
using Mensagens.Mensagem.UserControls.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mensagens.Mensagem
{
    public static class CtrlMensagem
    {
        public static IMensagem Mensagem { get; set; }

        private static void InicializaComponente(IComportamentoMensagem objeto, string local, string mensagem = null)
        {
            Mensagem = new FrmMensagem();

            if (!string.IsNullOrEmpty(mensagem))
                objeto.LblDescricao.Text = mensagem;

            Mensagem.FlwPainel.Controls.Add(objeto.View);

            Mensagem.Titulo = local;

            Mensagem.Mensagem.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            Mensagem.Mensagem.ShowDialog();

            ////Realiza o cast do objeto 
            //// da pra mudar pra comportamento
            //IInformacao Informacao = objeto as IInformacao;

            //ISucesso Sucesso = objeto as ISucesso;

            //IAlerta Alerta = objeto as IAlerta;

            //IErro Erro = objeto as IErro;

            //IPergunta Pergunta = objeto as IPergunta;


            //// Define a chamada da msg conforme o metodo que foi invocado
            //if (Informacao != null)
            //    Mensagem.FlwPainel.Controls.Add(Informacao.View);

            //else if (Sucesso != null)
            //    Mensagem.FlwPainel.Controls.Add(Sucesso.View);

            //else if (Alerta != null)
            //    Mensagem.FlwPainel.Controls.Add(Alerta.View);

            //else if (Erro != null)
            //    Mensagem.FlwPainel.Controls.Add(Erro.View);

            //else if (Pergunta != null)
            //{
            //    Pergunta.LblDescricao.Text = mensagem;


            //    Mensagem.FlwPainel.Controls.Add(Pergunta.View);
            //}




        }

        public static void Informacao(string exibeMensagens, string local)
        {
            CtrlInformacao ctrlInformacao = new CtrlInformacao(exibeMensagens);

            InicializaComponente(ctrlInformacao.Informacao, local);

        }

        public static void Salvo(string local)
        {
            CtrlSucesso ctrlSucesso = new CtrlSucesso("Salvo com Sucesso!", true);

            InicializaComponente(ctrlSucesso.SucessoView, local);

        }

        public static void Processado(string local)
        {
            CtrlSucesso ctrlSucesso = new CtrlSucesso("Salvo e Processado com Sucesso!", true);

            InicializaComponente(ctrlSucesso.SucessoView, local);

        }

        public static void Excluido(string local)
        {
            CtrlSucesso ctrlSucesso = new CtrlSucesso("Excluído com Sucesso", false);

            InicializaComponente(ctrlSucesso.SucessoView, local);

        }

        public static void Alerta(string local, string tipoAlerta)
        {
            CtrlAlerta ctrlAlerta = new CtrlAlerta(tipoAlerta);

            InicializaComponente(ctrlAlerta.Alerta, local);

        }

        public static void ErroDesconhecido(string local, string tipoDoErro, string msgErro)
        {
            CtrlErro ctrlErro = new CtrlErro(tipoDoErro, msgErro);

            InicializaComponente(ctrlErro.Erro, local);

        }

        public static DialogResult Pergunta(string local, string pergunta)
        {
            CtrlPergunta ctrlPergunta = new CtrlPergunta(local, pergunta);

            InicializaComponente(ctrlPergunta.Pergunta, local, pergunta);

            return ctrlPergunta.Pergunta.View.ParentForm.DialogResult;
        }


        private static void DefinicoesAlerta()
        {

        }

    }
}
