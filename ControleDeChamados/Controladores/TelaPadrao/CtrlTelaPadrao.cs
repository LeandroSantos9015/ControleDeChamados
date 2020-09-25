using Interfaces;
using Interfaces.UserControls;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilitariosSistema;
using View.UserControlPadrao;

namespace Controladores.TelaPadrao
{
    public abstract class CtrlTelaPadrao : CtrlBotoes
    {
        public IUCPadrao IdDescricaoPadrao = new UCPadrao();

        public abstract ModelTelaPadrao ModeloTelaPadrao { get; }

        private ITelaPrincipal Pai { get; set; }

        public CtrlTelaPadrao(ITelaPrincipal Pai)
        {
            this.Pai = Pai;

            ModelTelaPadrao modelo = ModeloTelaPadrao;

            IGenerica form = modelo.Formulario;

            this.DelegarEventos(Pai, form);

            PreencheCamposFormatacao(modelo);

            FlowLayoutPanel painel = modelo.Formulario.Painel;

            painel.Controls.Add(IdDescricaoPadrao.UCPadraoView);
        }

        private void DelegarEventos(ITelaPrincipal Pai, IGenerica form)
        {
            HabilitaDesabilitaBotoesPai(ultimoEventoBotoes, this.Pai);

            form.Formulario.StartPosition = FormStartPosition.CenterScreen;

            form.Formulario.MdiParent = Pai.PrincipalView;

            form.Formulario.Activated += FormAtivado;
            //// verificar se da pra por no abstract passando o Form como extension ou parametro
            form.Formulario.Deactivate += FormDesativado;

            form.Formulario.FormClosing += base.FormClosing;

            form.Formulario.Show();
        }

        public int HabilitaDesabilitaSequenciaBotoes() { return base.HabilitaDesabilitaSequenciaBotoes(IdDescricaoPadrao.Id); }

        private void PreencheCamposFormatacao(ModelTelaPadrao modelo)
        {
            this.IdDescricaoPadrao.Id.Text = modelo.Id is null ? "" : modelo.Id.Value.ToString();
            this.IdDescricaoPadrao.Descricao.Text = modelo.Descricao;
            this.IdDescricaoPadrao.DescricaoLabel.Text = (modelo.DescricaoLabel ?? this.IdDescricaoPadrao.DescricaoLabel.Text) + ":";

            this.IdDescricaoPadrao.Grupo.Width = modelo.Formulario.Painel.Width - 10;
            this.IdDescricaoPadrao.UCPadraoView.Width = modelo.Formulario.Painel.Width;
            this.IdDescricaoPadrao.Descricao.Width = modelo.Formulario.Painel.Width - 83;
        }

        protected void FormAtivado(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoesPai(ultimoEventoBotoes, this.Pai);
            DelegarEventosPai(this.Pai);

        }

        protected void FormDesativado(object sender, EventArgs e)
        {
            HabilitaDesabilitaBotoesPai(new bool[] { false, false, false, false, false, false, false, false }, this.Pai);
            RetirarEventosPai(this.Pai);
        }

        protected ModelTelaPadrao TelaParaObjeto()
        {
            Int64.TryParse(this.IdDescricaoPadrao.Id.ToString(), out Int64 num);

            return new ModelTelaPadrao
            {
                Id = num,
                Descricao = this.IdDescricaoPadrao.Descricao.Text
            };
        }
    }
}
