using BancoDeDados.Repositorio.Gerador;
using GeradorComandosSQLServer.Impl;
using GeradorComandosSQLServer.Interface;
using Modelos.Cadastro;
using Modelos.Gerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosSistema;

namespace GeradorComandosSQLServer.Controlador
{
    public class Controle
    {

        public IGerador GeradorView { get; set; }

        public Controle()
        {
            this.GeradorView = new FrmGerador();

            this.DelegarEventos();
        }

        private void DelegarEventos()
        {
            this.GeradorView.BtnGerar.Click += BtnGerar_Click;
        }

        private void BtnGerar_Click(object sender, EventArgs e)
        {
            RepositorioGerador repositorioGerador = new RepositorioGerador();

            string tabela = this.GeradorView.TxtBanco.Text;

            IList<ModelColunasGerador> retorno = repositorioGerador.Buscar(tabela);

            string proc = Regra.CriarProcedureSalvarAtualizar(retorno, tabela);

            string func = Regra.CriarFuncaoDeConsultar(retorno, tabela);

            this.GeradorView.RchResultado.AppendText(proc + "\n\n\n");

            this.GeradorView.RchResultado.AppendText(func + "\n\n\n");

        }
    }
}
