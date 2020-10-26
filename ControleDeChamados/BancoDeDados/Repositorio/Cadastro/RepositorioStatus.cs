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
    public class RepositorioStatus
    {
        private string stringConexao;

        public RepositorioStatus() { stringConexao = FabricaBancoDadosDapper.StringConexaoGerenciador(); }

        public string SalvarAtualizar(ModeloStatus modelo)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(this.stringConexao))
                    sqlConnection.Execute("SalvarAtualizar_Status", modelo, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                return "Status Salvo com Sucesso!";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ModeloStatus> Listar(Int64? IdParceiro = null)
        {
            try
            {
                string consulta = $@"SELECT * FROM Consultar_Status({IdParceiro?.ToString() ?? "null"})";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloStatus>(consulta).ToList();
            }
            catch (Exception e)
            {
                if (e.HResult == -2146233079)
                    return null;

                throw e;
            }
        }
    }
}
