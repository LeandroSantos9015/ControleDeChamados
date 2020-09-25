using BancoDeDados.Repositorio.Cadastro;
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


        public override ModelTelaPadrao ModeloTelaPadrao =>
           new ModelTelaPadrao
           {
               Formulario = CategoriaView,
               Descricao = "Categoria Aqui",
               DescricaoLabel = "Descrição",
               Id = null
           };

        public CtrlCategoria(ITelaPrincipal Pai) : base(Pai)
        {
            this.DelegarEventos();
        }

        private void DelegarEventos()
        {

        }

        public override void BtnNovo_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
        }

        public override void BtnCancelar_Click(object sender, EventArgs e)
        {
            base.HabilitaDesabilitaSequenciaBotoes();
            //MapeiaObjetoNaTela(null);
        }

        public override void BtnSalvar_Click(object sender, EventArgs e)
        {
            string retornoSalvar = repositorioCategoria.SalvarAtualizar(Converte());
            base.HabilitaDesabilitaSequenciaBotoes();

            this.SalvoComSucesso(retornoSalvar);
        }

        private ModeloCategoria Converte()
        {
            ModelTelaPadrao tela = base.TelaParaObjeto();

            return new ModeloCategoria
            {
                Id = tela.Id,
                Descricao = tela.Descricao,
                
            };
        }
    }
}