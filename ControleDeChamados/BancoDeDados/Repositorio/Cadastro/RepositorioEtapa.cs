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
    public class RepositorioEtapa
    {
        private string stringConexao;

        public RepositorioEtapa() { stringConexao = FabricaBancoDadosDapper.StringConexaoGerenciador(); }

        public string SalvarAtualizar(EtapaDTO modelo)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(this.stringConexao))
                    sqlConnection.Execute("SalvarAtualizar_Etapa", modelo, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                return "Etapa Salva com Sucesso!";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<ModeloEtapa> Listar(Int64? IdParceiro = null)
        {
            try
            {
                string consulta = $@"SELECT * FROM Consultar_Etapa({IdParceiro?.ToString() ?? "null"})";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloEtapa>(consulta).ToList();
            }
            catch (Exception e)
            {
                if (e.HResult == -2146233079)
                    return null;

                throw e;
            }
        }

        /// <summary>
        /// Colocar sobrecarga de ativo
        /// </summary>
        /// <param name="teste"></param>
        /// <returns></returns>
        public IList<ModeloEtapa> Listar(int teste)
        {
            try
            {
                string consulta = @"SELECT * FROM Consultar_Etapa";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloEtapa>(consulta).ToList();
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