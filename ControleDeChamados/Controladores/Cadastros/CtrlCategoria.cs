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
    public class CtrlCategoria : CtrlTelaPadrao
    {
        public ICategoria CategoriaView = new FrmCategoria();

        private RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        public CtrlCategoria(ITelaPrincipal Pai) : base(Pai)
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

            return new ModeloCategoria
            {
                Id = tela.Id,
                Descricao = tela.Descricao,
            };
        }

        public override ModelTelaPadrao ModeloTelaPadrao =>
           new ModelTelaPadrao
           {
               Formulario = CategoriaView,
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
            // SalvarOuAtualizar(MapeiaTelaParaObjeto(false));

            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnSalvar_Click(object sender, EventArgs e)
        {
            ModelTelaPadrao obj = this.TelaParaObjeto();

            string retornoSalvar = repositorioCategoria.SalvarAtualizar(new CategoriaDTO { Id = obj.Id, Descricao = obj.Descricao });
            if (retornoSalvar.Contains("Salva com Sucesso"))
            {
                base.HabilitaDesabilitaSequenciaBotoes();
                SalvoComSucesso(retornoSalvar);
                base.ObjetoParaTela();
            }
            else
                ErroDesconhecido("Cadastro de Categoria", "Erro ao Tentar Salvar", retornoSalvar);
        }

        public override void BtnConfirmar_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnPesquisar_Click(object sender, EventArgs e)
        {
            RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

            int status = base.HabilitaDesabilitaSequenciaBotoes();

            // sem tratamento para ativo no momento, criar uma sobrecarga depois
            CtrlPesquisar Pesquisa = new CtrlPesquisar(base.Pai, repositorioCategoria.Listar().Cast<Object>().ToList(), 741, "Pesquisa de Categorias");

            ModeloCategoria cat = Pesquisa.RetornaObjetoSelecionado() as ModeloCategoria;

            base.ObjetoParaTela(new ModelTelaPadrao { Id = cat.Id, Descricao = cat.Descricao });
        }

        public override void BtnCancelar_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();

            base.ObjetoParaTela(null);
        }

        public override void BtnNovo_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnAjuda_Click(object sender, EventArgs e)
        {
            const string cabecalho = "Cadastro de Categoria";
            string corpo = @"Responsável pela parte de cadastro de categoria que influencia no Cadastro de Chamado.";

            MessageBox.Show(corpo, cabecalho);
        }

        #endregion
    }
}