using Iesi.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;


namespace UtilitariosSistema
{
    /// <summary>
    /// Classe que define métodos extensions para o tipo IList.
    /// </summary>
    /// <remarks>
    /// Criado por   : José Rodrigo Gaspari
    /// Data         : 23/12/2008
    /// 
    /// Alterado por : Leonardo Justino
    /// Data         : 17/02/2009
    /// Descrição    : adicionado a versão genérica do método PegarPrimeiroElemento
    /// </remarks>
    public static class ExtensionsIList
    {
        /// <summary>
        /// Método extension para verificar se lista está vazia
        /// </summary>
        /// <param name="lista">lista para verificacao</param>
        /// <returns>true se vazia</returns>
        /// <exception cref="ArgumentNullException">Caso a lista passada esteja null</exception>
        public static Boolean EstaVazia(this IList lista)
        {
            if (lista.IsNull())
                throw new ArgumentNullException("lista", "Parâmetro passado está nulo");

            return lista.PegarPrimeiroElemento<Object>().IsNull();
        }

        public static void AdicionarElementosTipado<TDestino>(this IList<TDestino> listaDestino, IList<TDestino> listaOrigem)
        {
            if (listaOrigem != null)
                foreach (var elemento in listaOrigem)
                    listaDestino.Add((TDestino)elemento);
        }

        public static Boolean IsNotEmpty<T>(this IList<T> objeto)
        {
            if (objeto.IsNotNull())
                return (objeto.Count<T>() > 0);
            else
                return false;
        }

        public static Boolean IsEmpty<T>(this IList<T> objeto)
        {
            return (objeto.IsNull() || objeto.Count<T>() == 0);                               
        }

        /// <summary>
        /// Método que recupera o primeiro elemento não nulo da lista.
        /// </summary>
        /// <param name="lista">lista a ser verificada</param>
        /// <returns>Object da lista</returns>
        public static Object PegarPrimeiroElemento(this IList lista)
        {
            if (!lista.IsNull())
                foreach (Object objeto in lista)
                    if (!objeto.IsNull())
                        return objeto;

            return null;
        }

        /// <summary>
        /// Método que recupera o primeiro elemento não nulo da lista.
        /// </summary>
        /// <param name="lista">lista a ser verificada</param>
        /// <returns>Object da lista</returns>
        public static TTipoDoRetorno PegarPrimeiroElemento<TTipoDoRetorno>(this IList lista)
        {
            if (!lista.IsNull())
                foreach (TTipoDoRetorno item in lista)
                    if (!item.IsNull())
                        return item;

            return default(TTipoDoRetorno);
        }

        /// <summary>
        /// Recupera o tipo do primeiro elemento da lista.
        /// </summary>
        /// <param name="lista">lista a ser verificada</param>
        /// <returns>Type do objeto</returns>
        public static Type PegarTipoDosElementos(this IList lista)
        {
            if ((!lista.IsNull()) && (!lista.EstaVazia()))
                return lista.PegarPrimeiroElemento<Object>().GetType();
            else
                return null;
        }

        /// <summary>
        /// Criado por   : José Rodrigo Gaspari
        /// Data         : 12/09/2009
        /// Descrição    : Método extension que adiciona uma lista de elementos no IList.
        /// </summary>
        /// <param name="listaAdicionar">lista do item a serem adicionados à lista</param>
        public static void AdicionarElementos(this IList lista, ICollection listaAdicionar)
        {
            if ((!lista.IsNull()) && !listaAdicionar.IsNull())
                foreach (var item in listaAdicionar)
                    lista.Add(item);
        }


        /// <summary>
        /// Criado por   : Marcos César Dias
        /// Data         : 14/01/2015
        /// Descrição    : Método extension que adiciona uma lista de Enumerador no IList.
        /// </summary>
        /// <param name="listaAdicionar">lista do item a serem adicionados à lista</param>
        public static void AdicionarEnumerador<T>(this IList lista)
        {
            if (!lista.IsNull())
            {
                IEnumerable l = (T[])Enum.GetValues(typeof(T));
                foreach (var item in l)
                    lista.Add(item);
            }
        }

        /// <summary>
        /// Criado por   : Mateus Pozzi Vianna de Carvalho
        /// Data         : 06/04/2011
        /// Descrição    : Método extension que remove uma lista de elementos no IList.
        /// </summary>
        /// <param name="listaAdicionar">lista do item a serem adicionados à lista</param>
        public static void RemoverElementos(this IList lista, ICollection listaRemover)
        {
            if ((!lista.IsNull()) && !listaRemover.IsNull())
                foreach (var item in listaRemover)
                    lista.Remove(item);
        }

        /// <summary>
        /// Adiciona os elementos da listaOrigem para a listaDestino.
        /// </summary>
        /// <typeparam name="TDestino">Tipo dos elementos da listaDestino.</typeparam>
        /// <param name="listaDestino">Lista onde serão adicionados os elementos da listaOrigem.</param>
        /// <param name="listaOrigem">Lista dos elementos que serão adicionados na listaDestino.</param>
        /// <exception cref="NullReferenteException">
        /// Esta exceção será lançada caso o parâmetro listaDestino seja nulo.
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// Esta exceção será lançada caso o TDestino não seja o tipo dos elementos da listaOrigem.
        /// </exception>
        public static void AdicionarElementos<TDestino>(this IList<TDestino> listaDestino, IList listaOrigem)
        {
            if (listaOrigem != null)
                foreach (var elemento in listaOrigem)
                    listaDestino.Add((TDestino)elemento);
        }

        /// <summary>
        /// Retorna o tamanho de uma lista. 
        /// </summary>
        /// <param name="lista">
        ///     Lista que será verificada o tamanho.
        /// </param>
        /// <returns>
        ///     Retorna o tamanho da lista. Caso a lista seja nula, será retornado 0.
        /// </returns>
        public static Int32 Tamanho(this IList lista)
        {
            if (lista != null)
                return lista.Count;
            else
                return 0;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static DataTable ToDataTable(this IEnumerable lista, Type tipoLista)
        {
            DataTable tabela;
            DataColumn column1;
            DataRow row;

            tabela = new DataTable(tipoLista.Name);

            foreach (var item in tipoLista.GetProperties())
            {
                column1 = new DataColumn();

                if (item.CanRead && item.GetIndexParameters().Length == 0)
                {
                    Type tipo = Nullable.GetUnderlyingType(item.PropertyType);

                    if (tipo.IsNull())
                        column1.DataType = item.PropertyType;
                    else
                        column1.DataType = tipo;

                    column1.ColumnName = item.Name;

                    tabela.Columns.Add(column1);
                }
            }

            foreach (var item in lista)
            {
                row = tabela.NewRow();

                PropertyInfo[] listaProperty = item.GetType().GetProperties();
                foreach (var item1 in listaProperty)
                {
                    if (item1.CanRead && item1.GetIndexParameters().Length == 0)
                    {
                        if (tabela.Columns.Contains(item1.Name))
                        {
                            object objeto = item1.GetValue(item, null);
                            row[item1.Name] = objeto.IsNull() ? DBNull.Value : objeto;
                        }
                    }
                }

                tabela.Rows.Add(row);
            }

            return tabela;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static DataTable ConfigurarDataTable(this Type tipoEntidade)
        {
            DataTable tabela;
            DataColumn column1;

            tabela = new DataTable(tipoEntidade.Name);

            foreach (var item in tipoEntidade.GetProperties())
            {
                column1 = new DataColumn();

                if (item.CanRead && item.GetIndexParameters().Length == 0)
                {
                    Type tipo = Nullable.GetUnderlyingType(item.PropertyType);

                    if (tipo.IsNull())
                        column1.DataType = item.PropertyType;
                    else
                        column1.DataType = tipo;

                    column1.ColumnName = item.Name;

                    tabela.Columns.Add(column1);
                }
            }

            return tabela;
        }

        public static DataRow ToDataRow(this object objeto, DataTable tabela)
        {
            DataRow row = tabela.NewRow();

            PropertyInfo[] listaProperty = objeto.GetType().GetProperties();
            foreach (var item1 in listaProperty)
            {
                if (item1.CanRead && item1.GetIndexParameters().Length == 0)
                {
                    if (tabela.Columns.Contains(item1.Name))
                    {
                        object o = item1.GetValue(objeto, null);
                        row[item1.Name] = o.IsNull() ? DBNull.Value : o;
                    }
                }
            }

            return row;
        }

        public static DataTable ToDataTable<TTipoItemLista>(this IEnumerable<TTipoItemLista> lista)
        {
            Type tipoLista;

            if (lista.Count() > 0)
                tipoLista = lista.First().GetType();
            else
                tipoLista = typeof(TTipoItemLista);

            return lista.ToDataTable(tipoLista);
        }

        public static TTipoItemLista ToObject<TTipoItemLista>(this DataRow row) //where TTipoItemLista : new()
        {
            TTipoItemLista objeto = Activator.CreateInstance<TTipoItemLista>();// new TTipoItemLista();

            foreach (DataColumn item in row.Table.Columns)
            {
                Object valor = row[item.ColumnName];

                if (valor.IsNotNull())
                {
                    PropertyInfo propriedade = objeto.GetType().GetProperty(item.ColumnName);

                    if (propriedade.IsNotNull())
                    {
                        Type tipo = propriedade.PropertyType;

                        Type tipoFiltrado = Nullable.GetUnderlyingType(tipo) ?? objeto.GetType().GetProperty(item.ColumnName).GetType();

                        if (!tipoFiltrado.IsEnum && propriedade.CanWrite)
                        {
                            objeto.GetType().GetProperty(item.ColumnName).SetValue(objeto, DBNull.Value.Equals(valor) ? null : valor, null);
                        }
                    }
                }
            }

            return objeto;
        }

        public static Iesi.Collections.Generic.ISet<T> ConverterList<T>(this IList<T> lista)
        {
            Iesi.Collections.Generic.ISet<T> listaNova = new HashedSet<T>();

            foreach (var item in lista)
                listaNova.Add(item);

            return listaNova;
        }

        public static List<T> ConverterList<T>(this Iesi.Collections.Generic.ISet<T> lista)
        {
            List<T> listaNova = new List<T>();

            foreach (var item in lista)
                listaNova.Add(item);

            return listaNova;
        }

        public static void RemoveWhere<T>(this IList<T> lista, Func<T, bool> condicao)
        {
            if (lista.IsNotNull() && lista.Count() > 0)
            {
                IList<T> objetosRemover = new List<T>();

                foreach (var item in lista)
                {
                    if (condicao(item))
                        objetosRemover.Add(item);
                }

                foreach (var itemRemover in objetosRemover)
                    lista.Remove(itemRemover);
            }
        }

        public static void RemoverEspacoBrancoFinal(this IList<String> lista)
        {
            String[] listaRemoverEspacoBrancoFinal = lista.ToArray();

            Boolean continuarRemocaoEspacoBranco = true;

            for (int indicelistaRemoverEspacoBrancoFinal = listaRemoverEspacoBrancoFinal.Length - 1; listaRemoverEspacoBrancoFinal.Count() >= 0 && continuarRemocaoEspacoBranco; indicelistaRemoverEspacoBrancoFinal--)
            {
                continuarRemocaoEspacoBranco = String.IsNullOrWhiteSpace(listaRemoverEspacoBrancoFinal[indicelistaRemoverEspacoBrancoFinal]);

                if (continuarRemocaoEspacoBranco)
                    lista.RemoveAt(indicelistaRemoverEspacoBrancoFinal);
            }
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                if (chunksize <= 0)
                   throw new ArgumentException("Chunk size must be greater than zero.", "chunksize");
                
                yield return source.Take(chunksize);

                source = source.Skip(chunksize);
            }
        }


    }
}
