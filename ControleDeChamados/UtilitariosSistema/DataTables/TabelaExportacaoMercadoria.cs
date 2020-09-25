using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitariosSistema;

namespace Customizados.DataTables
{
    public static class TabelaExportacaoMercadoria
    {

        public static DataTable GetTable()
        {
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(Int64)),
                new DataColumn("CodigoBarra", typeof(string)),
                new DataColumn("Descricao", typeof(String)),
                new DataColumn("proxyUnidade", typeof(int)),
                new DataColumn("PrecoCompra", typeof(Decimal)),
                new DataColumn("PrecoVenda", typeof(Decimal)),
                new DataColumn("IdEstoque", typeof(Int64)),
                new DataColumn("Estoque", typeof(Decimal)),
                new DataColumn("Ativo", typeof(Boolean)),
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
 