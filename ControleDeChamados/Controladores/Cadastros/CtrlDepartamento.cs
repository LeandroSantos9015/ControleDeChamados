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
    public class CtrlDepartamento : CtrlTelaPadrao
    {
        public IDepartamento DepartamentoView = new FrmDepartamento();

        private RepositorioDepartamento repositorioDepartamento = new RepositorioDepartamento();

        public CtrlDepartamento(ITelaPrincipal Pai) : base(Pai)
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

            return new ModeloDepartamento
            {
                Id = tela.Id,
                Descricao = tela.Descricao,
            };
        }

        public override ModelTelaPadrao ModeloTelaPadrao =>
           new ModelTelaPadrao
           {
               Formulario = DepartamentoView,
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

            string retornoSalvar = repositorioDepartamento.SalvarAtualizar(new DepartamentoDTO { Id = obj.Id, Descricao = obj.Descricao, Ativo = false });
            if (retornoSalvar.Contains("Salva com Sucesso"))
            {
                base.HabilitaDesabilitaSequenciaBotoes();
                ExcluidoComSucesso("Cadastro excluído com sucesso");
                base.ObjetoParaTela(true);
            }
            else
                ErroDesconhecido("Cadastro de Departamento", "Erro ao Tentar Salvar", retornoSalvar);
        }

        public override void BtnSalvar_Click(object sender, EventArgs e)
        {
            ModelTelaPadrao obj = this.TelaParaObjeto();

            string retornoSalvar = repositorioDepartamento.SalvarAtualizar(new DepartamentoDTO { Id = obj.Id, Descricao = obj.Descricao });
            if (retornoSalvar.Contains("Salva com Sucesso"))
            {
                base.HabilitaDesabilitaSequenciaBotoes();
                SalvoComSucesso(retornoSalvar);
                base.ObjetoParaTela(true);
            }
            else
                ErroDesconhecido("Cadastro de Departamento", "Erro ao Tentar Salvar", retornoSalvar);
        }

        public override void BtnConfirmar_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnPesquisar_Click(object sender, EventArgs e)
        {
            RepositorioDepartamento repositorioDepartamento = new RepositorioDepartamento();

            int status = base.HabilitaDesabilitaSequenciaBotoes();

            // sem tratamento para ativo no momento, criar uma sobrecarga depois
            CtrlPesquisar Pesquisa = new CtrlPesquisar(base.Pai, repositorioDepartamento.Listar().Cast<Object>().ToList(), 330, "Pesquisa de Departamentos");

            ModeloDepartamento cat = Pesquisa.RetornaObjetoSelecionado() as ModeloDepartamento;

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
            const string cabecalho = "Cadastro de Departamento";
            string corpo = @"Responsável pela parte de cadastro de Departamento que influencia no Cadastro de Chamado.";

            MessageBox.Show(corpo, cabecalho);
        }

        #endregion
    }
}