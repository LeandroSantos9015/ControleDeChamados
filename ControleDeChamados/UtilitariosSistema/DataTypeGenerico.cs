using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosSistema
{
    public static class DataTypeGenerico
    {

        public static DataTable GetTable(this IList<object> lista, object obj)
        {
            // exemplo de utilização
            //  DataTable dataTable = listaTeste.Cast<object>().ToList().GetTable(new Dto());

            IList<KeyValuePair<String, Type>> tipos = ColetaProperties(obj);

            DataTable tabela = new DataTable();

            foreach (var v in tipos)
                tabela.Columns.Add(new DataColumn(v.Key, v.Value));

            GetRows(tabela, lista);

            return tabela;
        }

        public static void GetRows(DataTable dataTable, object objeto)
        {
            dataTable.Rows.Add(objeto.ToDataRow(dataTable));
        }

        private static IList<KeyValuePair<String, Type>> ColetaProperties(object obj)
        {
            IList<KeyValuePair<String, Type>> retorno = new List<KeyValuePair<String, Type>>();

            Type t = obj.GetType();

            foreach (var prop in t.GetProperties())
                retorno.Add(new KeyValuePair<string, Type>(key: prop.Name, value: prop.PropertyType));

            return retorno;
        }

        public static void GetRows(DataTable dataTable, IList<object> objeto)
        {
            foreach (var item in objeto)
                dataTable.Rows.Add(item.ToDataRow(dataTable));
        }

        //public static DataRow ToDataRow(this object objeto, DataTable tabela)
        //{
        //    DataRow row = tabela.NewRow();

        //    PropertyInfo[] listaProperty = objeto.GetType().GetProperties();
        //    foreach (var item1 in listaProperty)
        //    {
        //        if (item1.CanRead && item1.GetIndexParameters().Length == 0)
        //        {
        //            if (tabela.Columns.Contains(item1.Name))
        //            {
        //                object o = item1.GetValue(objeto, null);
        //                row[item1.Name] = o ?? DBNull.Value;
        //            }
        //        }
        //    }
        //    return row;
        //}
    }
}
