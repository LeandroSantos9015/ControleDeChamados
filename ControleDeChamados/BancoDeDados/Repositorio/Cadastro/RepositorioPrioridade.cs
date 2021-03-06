﻿using Modelos.Cadastro;
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

        public string SalvarAtualizar(PrioridadeDTO modelo)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(this.stringConexao))
                    sqlConnection.Execute("SalvarAtualizar_Prioridade", modelo, commandType: CommandType.StoredProcedure, commandTimeout: 0);

                return "Prioridade Salva com Sucesso!";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IList<ModeloPrioridade> Listar(Int64? IdParceiro = null)
        {
            try
            {
                string consulta = $@"SELECT * FROM Consultar_Prioridade({IdParceiro?.ToString() ?? "null"})";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModeloPrioridade>(consulta).ToList();
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
