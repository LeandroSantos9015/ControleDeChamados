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
    public class RepositorioDepartamento
    {
        private string stringConexao;

        public RepositorioDepartamento() { stringConexao = FabricaBancoDadosDapper.StringConexaoGerenciador(); }

        public string SalvarAtualizar(DepartamentoDTO modelo)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(this.stringConexao))
                    sqlConnection.Execute("SalvarAtualizar_Departamento", modelo, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                return "Departamento Salvo com Sucesso!";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<ModeloDepartamento> Listar(Int64? IdParceiro = null)
        {
            try
            {
                string consulta = $@"SELECT * FROM Consultar_Departamento({IdParceiro?.ToString() ?? "null"})";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloDepartamento>(consulta).ToList();
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
        public IList<ModeloDepartamento> Listar(int teste)
        {
            try
            {
                string consulta = @"SELECT * FROM Consultar_Departamento";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloDepartamento>(consulta).ToList();
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