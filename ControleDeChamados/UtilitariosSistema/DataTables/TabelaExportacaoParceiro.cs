
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosSistema;

namespace Customizados.DataTables
{
    public static class TabelaExportacaoParceiro
    {
        public static DataTable GetTable()
        {
            DataColumn[] columns =
                    {
                new DataColumn("Id",typeof(Int64)),
                new DataColumn("NomeRazao",typeof(String)),
                new DataColumn("CpfCnpj",typeof(String)),
                new DataColumn("RgIe",typeof(String)),
                new DataColumn("ApelidoFantasia",typeof(String)),
                new DataColumn("Endereco",typeof(String)),
                new DataColumn("Numero",typeof(String)),
                new DataColumn("Cep",typeof(String)),
                new DataColumn("Estado",typeof(Int64)),
                new DataColumn("NomeCidade",typeof(String)),
                new DataColumn("Cidade",typeof(Int64)),
                new DataColumn("Complemento",typeof(String)),
                new DataColumn("Bairro",typeof(String)),
                new DataColumn("Fone",typeof(String)),
                new DataColumn("Email",typeof(String)),
                new DataColumn("Obs",typeof(String)),
                new DataColumn("IdEstado",typeof(Int64)),
                new DataColumn("DataCadastro",typeof(DateTime)),
                new DataColumn("DataNascimento",typeof(DateTime)),
                new DataColumn("Ativo",typeof(Boolean)),
                new DataColumn("ParceiroPrazo",typeof(Boolean)),
                new DataColumn("Saldo",typeof(Decimal)),
                new DataColumn("VenderPrazo",typeof(Boolean)),
                new DataColumn("Limite",typeof(Decimal))
            };


            DataTable dataTable = new DataTable();

            dataTable.Columns.AddRange(columns);

            return dataTable;
        }

        public static void GetRows(DataTable dataTable, object objeto)
        {
            dataTable.Rows.Add(objeto.ToDataRow(dataTable));
        }

        public static void GetRows(DataTable dataTable, IList<object> objeto)
        {
            foreach (var item in objeto)
                dataTable.Rows.Add(item.ToDataRow(dataTable));
        }
    }
}

