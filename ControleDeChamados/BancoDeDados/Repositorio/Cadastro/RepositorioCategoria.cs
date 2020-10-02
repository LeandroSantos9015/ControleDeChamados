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
    public class RepositorioCategoria
    {
        private string stringConexao;

        public RepositorioCategoria() { stringConexao = FabricaBancoDadosDapper.StringConexaoGerenciador(); }

        public string SalvarAtualizar(CategoriaDTO modelo)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(this.stringConexao))
                    sqlConnection.Execute("SalvarAtualizar_Categoria", modelo, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                return "Categoria Salva com Sucesso!";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<ModeloCategoria> Listar(Int64? IdParceiro = null)
        {
            try
            {
                string consulta = $@"SELECT * FROM Consultar_Categoria({IdParceiro?.ToString() ?? "null"})";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloCategoria>(consulta).ToList();
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
        public IList<ModeloCategoria> Listar(int teste)
        {
            try
            {
                string consulta = @"SELECT * FROM Consultar_Categoria";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloCategoria>(consulta).ToList();
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