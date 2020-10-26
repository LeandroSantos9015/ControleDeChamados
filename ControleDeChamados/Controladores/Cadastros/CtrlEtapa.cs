using BancoDeDados.Repositorio.Cadastro;
using Controladores.Pesquisar;
using Controladores.TelaPadrao;
using Interfaces;
using Interfaces.Cadastros;
using Modelos.Cadastro;
using Modelos.TelaPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Cadastros;

namespace Controladores.Cadastros
{
    public class CtrlEtapa : CtrlTelaPadrao
    {
        public IEtapa EtapaView = new FrmEtapa();

        private RepositorioEtapa repositorioEtapa = new RepositorioEtapa();

        public CtrlEtapa(ITelaPrincipal Pai) : base(Pai)
        {
            this.DelegarEventos();
        }

        private void DelegarEventos()
        {

        }

        #region Métodos overrides

        public override object ValoresTelaPadrao()
        {
            ModelTelaPadrao tela = base.TelaParaObjeto();

            return new ModeloEtapa
            {
                Id = tela.Id,
                Descricao = tela.Descricao,
            };
        }

        public override ModelTelaPadrao ModeloTelaPadrao =>
           new ModelTelaPadrao
           {
               Formulario = EtapaView,
               Descricao = null,
               DescricaoLabel = null,
               Id = null
           };

        public override void BtnImprimir_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnExcluir_Click(object sender, EventArgs e)
        {
            ModelTelaPadrao obj = this.TelaParaObjeto();

            string retornoSalvar = repositorioEtapa.SalvarAtualizar(new EtapaDTO { Id = obj.Id, Descricao = obj.Descricao, Ativo = false });
            if (retornoSalvar.Contains("Salva com Sucesso"))
            {
                base.HabilitaDesabilitaSequenciaBotoes();
                ExcluidoComSucesso("Cadastro excluído com sucesso");
                base.ObjetoParaTela(true);
            }
            else
                ErroDesconhecido("Cadastro de Etapa", "Erro ao Tentar Salvar", retornoSalvar);
        }

        public override void BtnSalvar_Click(object sender, EventArgs e)
        {
            ModelTelaPadrao obj = this.TelaParaObjeto();

            string retornoSalvar = repositorioEtapa.SalvarAtualizar(new EtapaDTO { Id = obj.Id, Descricao = obj.Descricao, Ativo = true });
            if (retornoSalvar.Contains("Salva com Sucesso"))
            {
                base.HabilitaDesabilitaSequenciaBotoes();
                SalvoComSucesso(retornoSalvar);
                base.ObjetoParaTela(true);
            }
            else
                ErroDesconhecido("Cadastro de Etapa", "Erro ao Tentar Salvar", retornoSalvar);
        }

        public override void BtnConfirmar_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnPesquisar_Click(object sender, EventArgs e)
        {
            RepositorioEtapa repositorioEtapa = new RepositorioEtapa();

            int status = base.HabilitaDesabilitaSequenciaBotoes();

            // sem tratamento para ativo no momento, criar uma sobrecarga depois
            CtrlPesquisar Pesquisa = new CtrlPesquisar(base.Pai, repositorioEtapa.Listar().Cast<Object>().ToList(), 330, "Pesquisa de Etapas");

            ModeloEtapa cat = Pesquisa.RetornaObjetoSelecionado() as ModeloEtapa;

            if (cat is null)
            {
                base.SequenciaBotoesEstadoOriginal();
                return;
            }

            base.ObjetoParaTela(cat.Ativo, new ModelTelaPadrao { Id = cat.Id, Descricao = cat.Descricao });
        }

        public override void BtnCancelar_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();

            base.ObjetoParaTela(true);
        }

        public override void BtnNovo_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnAjuda_Click(object sender, EventArgs e)
        {
            const string cabecalho = "Cadastro de Etapa";
            string corpo = @"Responsável pela parte de cadastro de Etapa que influencia no Cadastro de Chamado.";

            MessageBox.Show(corpo, cabecalho);
        }

        #endregion
    }
}