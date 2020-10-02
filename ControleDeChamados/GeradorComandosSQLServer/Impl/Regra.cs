using Modelos.Gerador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorComandosSQLServer.Impl
{
    public static class Regra
    {
        public static string CriarProcedureSalvarAtualizar(IList<ModelColunasGerador> colunas, string tabela)
        {
            string parte1 = "";
            string insert = "";
            string insertValue = "";
            string update = "";

            foreach (var val in colunas)
            {
                parte1 += "\n@" + val.Coluna + " " + val.Tipo;

                switch (val.Tipo.ToUpper())
                {
                    case "VARCHAR":
                        parte1 += "(MAX),";
                        break;

                    case "DECIMAL":
                        parte1 += "(11,2),";
                        break;

                    default:
                        parte1 += ",";
                        break;
                }

                if (!val.Coluna.Equals("Id"))
                {
                    insert += val.Coluna + ",";
                    insertValue += "@" + val.Coluna + ",";
                    update += val.Coluna + " = @" + val.Coluna + ",";
                }
            }
            string sql =
$@"CREATE PROCEDURE SalvarAtualizar_{tabela}
({parte1.Substring(0, parte1.Length - 1) + '\n'}
)
AS BEGIN

	IF(@Id IS NULL OR @Id = 0)
		INSERT INTO {tabela} ({insert.Substring(0, insert.Length - 1)})
        SELECT {insertValue.Substring(0, insertValue.Length - 1)}
	ELSE
		UPDATE {tabela} SET {update.Substring(0, update.Length - 1)} WHERE Id = @Id
END

GO";
            return sql;
        }

        public static string CriarFuncaoDeConsultar(IList<ModelColunasGerador> colunas, string tabela)
        {
            string parte1 = "";
            string insert = "";
            //string insertValue = "";
            //string update = "";



            foreach (var val in colunas)
            {
                parte1 += "\n" + val.Coluna + " " + val.Tipo;

                switch (val.Tipo.ToUpper())
                {
                    case "VARCHAR":
                        parte1 += "(MAX),";
                        break;

                    case "DECIMAL":
                        parte1 += "(11,2),";
                        break;

                    default:
                        parte1 += ",";
                        break;
                }
                    insert += val.Coluna + ",";
                    //insertValue += "@" + val.Coluna + ",";
                    //update += val.Coluna + " = @" + val.Coluna + ",";
                
            }

            string sql =
$@"CREATE FUNCTION Consultar_{tabela} (@Id BIGINT = NULL)
RETURNS 
@retorno TABLE 
(
{parte1.Substring(0, parte1.Length - 1) + '\n'})
AS BEGIN

IF(@Id IS NULL OR @Id = 0)
	INSERT @retorno
	SELECT {insert.Substring(0, insert.Length - 1)} FROM {tabela} WHERE Id = @Id
ELSE
	INSERT @retorno
	SELECT {insert.Substring(0, insert.Length - 1)} FROM {tabela}

RETURN
END";

            return sql;

        }
    }
}