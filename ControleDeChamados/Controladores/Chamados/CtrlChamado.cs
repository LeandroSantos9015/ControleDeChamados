using BancoDeDados.Repositorio.Cadastro;
using Controladores.TelaPadrao;
using Interfaces;
using Interfaces.Chamados;
using Interfaces.UserControls;
using Modelos.Cadastro;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Chamados;

namespace Controladores.Chamados
{
    public class CtrlChamado : CtrlTelaPadrao
    {
        public IChamado ChamadoView = new FrmChamado();

        private RepositorioCategoria repCat = new RepositorioCategoria();
        private RepositorioDepartamento repDept = new RepositorioDepartamento();
        private RepositorioEtapa repEtapa = new RepositorioEtapa();
        private RepositorioPrioridade repPrio = new RepositorioPrioridade();
        private RepositorioStatus repStatus = new RepositorioStatus();

        public override ModelTelaPadrao ModeloTelaPadrao =>
            new ModelTelaPadrao
            {
                Formulario = this.ChamadoView,
                Descricao = "Descrição do chamado aqui",
                DescricaoLabel = "Assunto",
                Id = 9992111
            };

        public CtrlChamado(ITelaPrincipal Pai) : base(Pai)
        {
            this.TelaInteracoes();

            this.DelegarEventos();

            this.CarregarCombos();

        }

        private void DelegarEventos()
        {

        }

        private void TelaInteracoes()
        {

            CtrlInteracoes interacoes = new CtrlInteracoes(null);

            this.ChamadoView.FlwInteracoes.Controls.Add(interacoes.InteracaoView.UCInteracaoView);
            //this.ChamadoView.FlwInteracoes.Controls.Add(interacoes2.InteracaoView.UCInteracaoView);

            int tamanho = this.ChamadoView.FlwInteracoes.VerticalScroll.Maximum - this.ChamadoView.FlwInteracoes.VerticalScroll.LargeChange;

            //bug --> tem q setar 2 vezes pra funcionar
            this.ChamadoView.FlwInteracoes.VerticalScroll.Value = tamanho;
            this.ChamadoView.FlwInteracoes.VerticalScroll.Value = tamanho;

        }

        public override void BtnNovo_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override object ValoresTelaPadrao()
        {
            ModelTelaPadrao tela = base.TelaParaObjeto();

            return new ModeloChamado
            {
                Id = tela.Id,
                Descricao = tela.Descricao,
            };
        }

        private void CarregarCombos()
        {
            this.ChamadoView.CbmCategoria.DataSource = repCat.Listar();
            this.ChamadoView.CbmCategoria.DisplayMember = "Descricao";
            this.ChamadoView.CbmCategoria.ValueMember = "Id";

            this.ChamadoView.CbmEtapa.DataSource = repEtapa.Listar();
            this.ChamadoView.CbmEtapa.DisplayMember = "Descricao";
            this.ChamadoView.CbmEtapa.ValueMember = "Id";

            //this.ChamadoView.CbmOperador.DataSource = null;
            //this.ChamadoView.CbmCategoria.DisplayMember = "Descricao";
            //this.ChamadoView.CbmCategoria.ValueMember = "Id";

            this.ChamadoView.CbmPrioridade.DataSource = repPrio.Listar();
            this.ChamadoView.CbmPrioridade.DisplayMember = "Descricao";
            this.ChamadoView.CbmPrioridade.ValueMember = "Id";

            this.ChamadoView.CbmStatus.DataSource = repStatus.Listar();
            this.ChamadoView.CbmStatus.DisplayMember = "Descricao";
            this.ChamadoView.CbmStatus.ValueMember = "Id";
        }
    }
}