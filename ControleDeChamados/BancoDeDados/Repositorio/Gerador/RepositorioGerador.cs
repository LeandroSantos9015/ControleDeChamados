using Dapper;
using Modelos.Gerador;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Repositorio.Gerador
{
    public class RepositorioGerador
    {
        private string stringConexao;

        public RepositorioGerador() { stringConexao = FabricaBancoDadosDapper.StringConexaoGerenciador(); }

        public IList<ModelColunasGerador> Buscar(string tabela)
        {
            try
            {
                string consulta =
                                    $@"SELECT distinct cln.name Coluna, sch.DATA_Type Tipo FROM sys.tables tab
                                    INNER JOIN sys.columns cln
                                    ON cln.object_id = tab.object_id
                                    INNER JOIN INFORMATION_SCHEMA.COLUMNS sch
                                    ON sch.COLUMN_NAME = cln.name
                                    where tab.name = '{tabela}'";

                using (SqlConnection sqlConnection = new SqlConnection(this.stringConexao))
                    return sqlConnection.Query<ModelColunasGerador>(consulta).ToList();
            }
            catch (Exception e)
            {
                //if (e.HResult == -2146233079)
                //    return null;

                throw;
            }
        }
    }
}