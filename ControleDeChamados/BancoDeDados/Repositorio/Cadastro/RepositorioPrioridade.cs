using Modelos.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace BancoDeDados.Repositorio.Cadastro
{
    public class RepositorioPrioridade
    {
        private string stringConexao;

        public RepositorioPrioridade() { stringConexao = FabricaBancoDadosDapper.StringConexaoGerenciador(); }

        public string SalvarAtualizar(ModeloCategoria modelo)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(this.stringConexao))
                    sqlConnection.Execute("SalvarAtualizar_Categoria", modelo, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                return "Categoria Salva com Sucesso!";
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
