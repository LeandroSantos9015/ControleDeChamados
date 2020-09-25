using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Rhino.Mocks;

namespace UtilitariosSistema
{
    /// <summary>
    /// Classe que define métodos extensions para o tipo Object, métodos: EstaNulo 
    /// </summary>
    /// <remarks>
    /// Criado por   : José Rodrigo Gaspari
    /// Data         : 23/12/2008
    ///
    /// Alterado por : Leonardo Louro Justino
    /// Data         : 31/12/2008
    /// Descrição    : Trouxe para cá os métodos da classe UtilitariosSistema.Meta.Componentes.Util.ControlsUtil
    ///                e realizei refatoração e testes.
    ///                
    /// Alterado por : Leonardo Louro Justino
    /// Data         : 15/01/2009
    /// Descrição    : Adicionado o método: NaoFazNada.
    /// </remarks>
    public static class ExtensionsObject
    {
        /// <summary>
        /// Metodo vazio usado para suprir alguns problemas de CA.
        /// </summary>
        public static void NaoFazNada(this Object objeto)
        {
            try
            {
                if (objeto.IsNotNull())
                    objeto.GetType();
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// Verifica se o objeto está nulo
        /// </summary>
        /// <param name="objeto">Object a ser verificado</param>
        /// <returns>true se objeto igual a null</returns>
        public static Boolean IsNull(this Object objeto)
        {
            return objeto == null || objeto == DBNull.Value;
        }

        /// <summary>
        /// Verifica se o objeto não está nulo
        /// </summary>
        /// <param name="objeto">Object a ser verificado</param>
        /// <returns>true se objeto diferente a null</returns>
        public static Boolean IsNotNull(this Object objeto)
        {
            return !objeto.IsNull();
        }

        /// <summary>
        /// Retorna o valor se ele não for nulo ou valor padrão.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="objeto">Objeto para validar se é nulo</param>
        /// <param name="objetoPadrao">Objeto de retorno caso valor testado se nulo.</param>
        /// <returns>objeto atribuído caso diferente de nulo ou objeto padrão</returns>
        /// <remarks>
        /// Criado por: Mateus Bahis Vieira.
        /// Data      : 07/10/2011
        /// </remarks>
        public static T ValorOuPadrao<T>(this T objeto, T objetoPadrao)
        {
            return objeto.IsNotNull() ? objeto : objetoPadrao;
        }

        public static T ValorOuPadrao<T>(this object objeto) where T : new()
        {
            return (T)(objeto.IsNotNull() ? objeto : Activator.CreateInstance<T>());
        }

        /// <summary>
        /// Criado por : Fábio Vendramin Guimarães Rosini e Mateus Bahis
        /// Data       : 15/01/2009
        /// Descrição  :
        /// Retorna todas as propriedades serializáveis e que não são arrays em um <code>IDictionary</code>,
        /// onde a chave é o nome da Propriedade e o valor é o valor desta Propriedade. Além disso, são adicionados no
        /// mapeamento todas as propriedades que possam ser lidas, independente do escopo de 
        /// visibilidade (private, protected, etc.).
        /// Para minimizar o espaço de armazenamento, este método tenta criar um objeto, igual ao passado, para 
        /// comparar as propriedades e adicionar no mapeamento somente aquelas que são diferentes do padrão.
        /// </summary>
        /// <param name="objeto">Objeto com as propriedades que serão retornadas.</param>
        /// <returns>Retorna um <code>Dictionary</code> com as propriedades do Objeto.</returns>
        /// <exception cref="ArgumentoNuloSystemMetaException">
        /// Esta exceção será lançada caso o parâmetro objeto seja nulo.
        /// </exception>
        public static IDictionary PropriedadesSerializaveisSemSerArray(this Object objeto)
        {
            if (objeto != null)
            {
                IDictionary mapeamentopropriedadesDiferentes = new Hashtable();
                Object novoObjetoComparacao = CriarObjetoAtravesConstrutorSemArgumentos(objeto.GetType());

                foreach (PropertyDescriptor propriedadesObjeto in TypeDescriptor.GetProperties(objeto))
                {
                    try
                    {
                        if (propriedadesObjeto.PropertyType.IsSerializable && !propriedadesObjeto.PropertyType.IsArray)
                        {
                            //Caso o novo objeto seja nulo, então não existe objeto para comparar
                            //as propriedades com o atual.
                            if (novoObjetoComparacao == null)
                                mapeamentopropriedadesDiferentes.Add(propriedadesObjeto.Name, propriedadesObjeto.GetValue(objeto));
                            else
                            {
                                Object valorAtual = propriedadesObjeto.GetValue(objeto);
                                if (objeto.GetType().GetProperty(propriedadesObjeto.Name).CanWrite)
                                {
                                    Object valorNovoParaComparacao = propriedadesObjeto.GetValue(novoObjetoComparacao);

                                    if (valorAtual == null && valorNovoParaComparacao != null)
                                        mapeamentopropriedadesDiferentes.Add(propriedadesObjeto.Name, null);
                                    else
                                        if (valorAtual != null && !valorAtual.Equals(valorNovoParaComparacao))
                                        mapeamentopropriedadesDiferentes.Add(propriedadesObjeto.Name, valorAtual);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        //Não tem problema na exception, pois significa que a propriedade não é valida.   
                    }
                }
                return mapeamentopropriedadesDiferentes;
            }
            else
                throw new Exception();
        }

        /// <summary>
        /// Criado por : Fábio Vendramin Guimarães Rosini e Mateus Bahis
        /// Data       : 15/01/2009
        /// Descrição  :
        /// Tenta criar objeto através do construtor sem argumentos com base em um tipo.
        /// Se não existir um construtor sem argumentos, null será retornado.
        /// </summary>
        /// <param name="tipo">Tipo que será utilizado para construir um objeto.</param>
        /// <returns>
        /// Tenta criar objeto através do construtor sem argumentos com base em um tipo.
        /// Se não existir um construtor sem argumentos, null será retornado.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private static object CriarObjetoAtravesConstrutorSemArgumentos(Type tipo)
        {
            try
            {
                if (tipo.IsSubclassOf(typeof(Form)))
                    return Activator.CreateInstance<Form>();
                else
                    //Instância um objeto do mesmo tipo para comparar as propriedades.
                    return Activator.CreateInstance(tipo);
            }
            catch (Exception)
            {
                //Caso entre aqui não tem objeto default para comparar o valor do objeto atual.
                return null;
            }
        }

        /// <summary>
        /// Criado por : Fábio Vendramin Guimarães Rosini e Mateus Bahis
        /// Data       : 15/01/2009
        /// Descrição  :
        /// Método que configura todas as propriedades, que estão em um <code>Dictionary</code> onde 
        /// a chave é o nome da Propriedade e o valor é o valor da Propriedade, no Objeto.
        /// Propriedade com o nome Visible são disprezadas, pois são gerenciadas no código que está
        /// usando o objeto.
        /// </summary>
        /// <param name="objeto">Objeto onde as propriedades serão configuradas.</param>
        /// <param name="propriedades">Lista de Propriedades que serão configuradas no Objeto.</param>
        /// <exception cref="ArgumentoNuloSystemMetaException">
        /// Esta exceção será lançada caso o parâmetro objeto seja nulo.
        /// </exception>
        /// <exception cref="ArgumentoInvalidoSystemMetaException">
        /// Esta exceção será lançada caso o valor adicionado na propriedade não seja compatível quando ao tipo.
        /// </exception>
        public static void ConfigurarPropriedades(this Object objeto, IDictionary propriedades)
        {
            if (objeto != null)
            {
                if (propriedades != null)
                {
                    PropertyDescriptorCollection colecaoDePropriedadesObjeto = TypeDescriptor.GetProperties(objeto);
                    foreach (string nomePropriedade in propriedades.Keys)
                        if (!nomePropriedade.Equals("Visible"))
                            try
                            {
                                PropertyDescriptor propriedadeObjeto = colecaoDePropriedadesObjeto.Find(nomePropriedade, false);
                                if (propriedadeObjeto != null)
                                    propriedadeObjeto.SetValue(objeto, propriedades[nomePropriedade]);
                            }
                            catch (ArgumentException innerEx)
                            {
                               // ArgumentoInvalidoSystemMetaException excecao = new ArgumentoInvalidoSystemMetaException(EMsgPadrao.MsgArgumentoInvalido, EArea.Utilitarios, innerEx, typeof(ExtensionsObject), "ConfigurarPropriedades", "propriedades");
                                //excecao.Solucoes.Add("Os valores das chaves do parâmetro propriedades deve conter valores compatíveis com o tipo que será realizado a reflexão.");
                                throw new Exception();
                            }
                }
            }
            else
                throw new Exception();
        }

        /// <summary>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 27/05/2009
        /// Descrição  : Método Para retornar o field e valor de um objeto. Usado em Debugs.                   
        /// </summary>
        /// <param name="objeto">Objeto que deseje que retorne seus fields</param>
        /// <returns>fields do objeto no formato de string.</returns>
        public static String ValoresDasPropriedades(this Object objeto)
        {
            String retorno = String.Empty;

            foreach (PropertyInfo propriedade in objeto.GetType().GetProperties())
            {
                try
                {
                    object valor = propriedade.GetValue(objeto, null);

                    string valorConcatenado = String.Concat(propriedade.Name, " = ", valor);

                    retorno += String.Concat("\n", valorConcatenado);
                }
                catch { }
            }

            return retorno;
        }

        /// <summary>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 27/05/2009
        /// Descrição  : Método que verifica se objeto é derivado do tipo atribuído.
        /// </summary>
        /// <typeparam name="T">Tipo para ser comparado.</typeparam>
        /// <param name="objeto">Objeto para ser verificado.</param>
        /// <returns>true se for uma implementação, senão false.</returns>
        public static bool IsImplementationOf<T>(this Object objeto)
        {
            return typeof(T).IsAssignableFrom(objeto.GetType());
        }

        public static bool IsImplementationOf(this Object objeto, Type tipo)
        {
            return tipo.IsAssignableFrom(objeto.GetType());
        }

        /// <summary>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 27/05/2009
        /// Descrição  : Método que converte o objeto para um tipo derivado.
        /// </summary>
        /// <typeparam name="T">Tipo derivado.</typeparam>
        /// <param name="objeto">objeto que será convertido.</param>
        /// <returns>Objeto convertido.</returns>
        /// <exception cref="InvalidCastException"/>
        public static T CastObject<T>(this Object objeto)
        {
            return (T)objeto;
        }

        /// <summary>     
        ///  Método que tenta converter o objeto para um tipo derivado, caso não consiga ele retornará um objeto simulado
        /// para que não haja exception.
        /// (Atenção Cuidado!!!) Não usar o retorno para ser atribuido para uma entidade.
        /// </summary>
        /// <typeparam name="T">Tipo derivado.</typeparam>
        /// <param name="objeto">objeto que será convertido.</param>
        /// <returns>Objeto convertido.</returns>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 27/05/2009
        /// 
        public static T TryCast<T>(this Object objeto) where T : class
        {
            if (objeto.IsNotNull() && objeto.IsImplementationOf<T>())
                return (T)objeto;
            else
            {
                MockRepository mock = new MockRepository();
                var SemValor = mock.DynamicMock<T>();
                mock.ReplayAll();
                return SemValor;
            }
        }

        /// <summary>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 18/06/2009
        /// Descrição  : Método que sobe um ArgumentoNuloSystemMetaException caso objeto for nulo.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto - Não é necessário.</typeparam>
        /// <param name="objeto">Objeto a ser verificado</param>
        public static void VerifyNull<T>(this T objeto)
        {
            VerifyNull(objeto, typeof(T).ToString());
        }

        public static void VerifyNull<T>(this T objeto, string nomeObjeto)
        {
            if (objeto == null)
            {
                //  EArea area = (EArea)Enum.Parse(typeof(EArea), Assembly.GetCallingAssembly().ManifestModule.Name.Split('.')[0]);
                //                throw new ArgumentoNuloSystemMetaException(EMsgPadrao.MsgArgumentoNulo, area, nomeObjeto);
                throw new Exception();
            }
        }

        /// <summary>
        /// Método que sobe uma ArgumentoNuloSystemMetaException encapsulada em uma FaultException do tipo WrapperRemoteMetaException.
        /// </summary>
        /// <typeparam name="T">Tipo do Objeto - Não é necessário.</typeparam>
        /// <param name="objeto">Objeto a ser verificado</param>     
        /// <exception cref="FaultException|WrapperRemoteMetaException| Detail ArgumentoNuloSystemMetaException"/>
        public static void VerifyNullWrapper<T>(this T objeto)
        {
            if (objeto == null)
            {
                //  EArea area = (EArea)Enum.Parse(typeof(EArea), Assembly.GetCallingAssembly().ManifestModule.Name.Split('.')[0]);
                //                throw new ArgumentoNuloSystemMetaException(EMsgPadrao.MsgArgumentoNulo, area, typeof(T).ToString()).ToTransferException();
                throw new Exception();
            }
        }

        /// <summary>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 30/11/2009
        /// Descrição  : Coverte o tipo do objeto e o retorna, caso não seja compatíveis retorna o valor default.
        /// <typeparam name="T">Tipo que vai ser convertido</typeparam>
        /// <param name="objeto">Objeto que será convertido.</param>
        /// <param name="defaultConvert">Caso não for possível a conversão retornará esse padrão.</param>
        /// <returns>Entidade do tipo especificado</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "ConvertOr")]
        public static T ConvertOrDefault<T>(this object objeto, T defaultConvert)
        {
            try
            {
                Type type = Nullable.GetUnderlyingType(typeof(T));

                if (type.IsNull())
                    type = typeof(T);

                return (T)Convert.ChangeType(objeto, type);
            }
            catch
            {
                return defaultConvert;
            }
        }

        /// <summary>
        /// Obtem o valor da propriedade informada.
        /// </summary>
        /// <param name="objeto">Objeto que possui a propriedade</param>
        /// <param name="nomePropriedade">Nome da propriedade</param>
        /// <returns>Valor da propriedade</returns>
        public static object GetValorPropriedade(this object objeto, string nomePropriedade)
        {
            var propriedade = objeto.GetType().GetProperty(nomePropriedade);
            if (propriedade.IsNull())
                return null;

            return propriedade.GetValue(objeto, null);
        }

        public static object GetValorPropriedadeComposta(this object objeto, string caminhoPropriedadeComposta)
        {
            if (String.IsNullOrEmpty(caminhoPropriedadeComposta))
                return null;
            else
            {
                Object valor = null;

                String[] propriedades = caminhoPropriedadeComposta.Split('.');

                valor = objeto.GetType().GetProperty(propriedades[0]).GetValue(objeto, null);

                if (valor != null)
                {
                    for (int proximoCampo = 1; proximoCampo < propriedades.Length; proximoCampo++)
                    {
                        valor = valor.GetType().GetProperty(propriedades[proximoCampo]).GetValue(valor, null);
                        if (valor == null)
                            return null;
                    }
                }

                return valor;
            }
        }

        /// <summary>
        /// Criado por : Mateus Bahis Vieira
        /// Data       : 19/02/2010
        /// Descrição  : Cria um clone do objeto.
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="objeto">Objeto para ser clonado.</param>
        /// <returns>Clone</returns>
        /// <exception cref="SerializationException">
      //  public static T Clonar<T>(this T objeto)
        //{
         //   return null; 
            //return (T)objeto.ToTransfer().Value;
       // }

        /// <summary>
        /// Verifica se o tipo do objeto é nullable
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        /// Criado por: Mateus Bahis Vieira
        /// Data      : 17/05/2010
        /// 
        public static bool IsNullable(this object objeto)
        {
            Type type = objeto.GetType();
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }

        /// <summary>
        /// Copia o valor das propriedades de um objeto de origem para
        /// um objeto de destino, que tenha propriedades com o mesmo nome e tipo do de origem.
        /// </summary>
        /// <param name="origem">Objeto de origem a ser copiado.</param>
        /// <param name="destino">Objeto de destino para receber os valores copiados.</param>
        /// <returns>Objeto destino com as propriedades atualizadas a partir do objeto de origem.</returns>
        public static object CopiarPropriedades(this object origem, object destino)
        {
            if (origem.IsNull() || destino.IsNull()) return null;

            BindingFlags bindingConsultarPropriedades = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            PropertyInfo[] arrayPropriedades = origem.GetType().GetProperties(bindingConsultarPropriedades);

            foreach (var propertyInfoOrigem in arrayPropriedades)
            {
                if (propertyInfoOrigem.GetIndexParameters().Length == 0)
                {
                    PropertyInfo propertyInfoDestino = destino.GetType().GetProperty(
                        propertyInfoOrigem.Name, bindingConsultarPropriedades | BindingFlags.SetProperty);
                    //existe a propriedade no objeto de destino.
                    if (!propertyInfoDestino.IsNull())
                    {
                        if (!propertyInfoOrigem.CanRead) continue;

                        if (!propertyInfoDestino.CanWrite) continue;

                        var valorPropriedadeOrigem = propertyInfoOrigem.GetValue(origem, null);
                        propertyInfoDestino.SetValue(destino, valorPropriedadeOrigem, null);
                    }
                }
            }
            return destino;
        }

        /// <summary>
        /// Copia o valor das propriedades de um objeto de origem
        /// para um novo objeto criado a partir do genérics passado, 
        /// que tenha propriedades com o mesmo nome e tipo do de origem.
        /// </summary>
        /// <typeparam name="T">Genérics do tipo a ser criado e copiado da origem.</typeparam>
        /// <param name="origem">Objeto de origem a ser copiado.</param>
        /// <returns>Objeto destino com as propriedades atualizadas a partir do objeto de origem.</returns>
        public static T CopiarPropriedades<T>(this object origem) where T : class, new()
        {
            return (T)origem.CopiarPropriedades(new T());
        }

        /// <summary>
        /// Método de extensão para cria uma lista de cópias de um objeto
        /// </summary>
        /// <remarks>
        /// Criado por   : Paulo César B. S.
        /// Data         : 24/10/2012
        /// </remarks>
        /// <typeparam name="T">Tipo ou interface</typeparam>
        /// <param name="origem">objeto de origem</param>
        /// <param name="numeroCopias">quantidade de cópias</param>
        /// <returns>IList de T com os objetos gerados</returns>
        public static IList<T> CriarCopias<T>(this object origem, long numeroCopias)
        {
            return origem.CriarCopias<T>(numeroCopias, false, null, null);
        }

        /// <summary>
        /// Método de extensão para cria uma lista de cópias de um objeto
        /// </summary>
        /// <remarks>
        /// Criado por   : Paulo César B. S.
        /// Data         : 24/10/2012
        /// </remarks>
        /// <typeparam name="T">Tipo ou interface</typeparam>
        /// <param name="origem">objeto de origem</param>
        /// <param name="numeroCopias">quantidade de cópias</param>
        /// <param name="retornoInclusivo">Se true, inclui o objeto original na lista de retorno</param>
        /// <returns>IList de T com os objetos gerados</returns>
        public static IList<T> CriarCopias<T>(this object origem, long numeroCopias, bool retornoInclusivo)
        {
            return origem.CriarCopias<T>(numeroCopias, retornoInclusivo, null, null);
        }

        /// <summary>
        /// Método de extensão para cria uma lista de cópias de um objeto
        /// </summary>
        /// <remarks>
        /// Criado por   : Paulo César B. S.
        /// Data         : 24/10/2012
        /// </remarks>
        /// <typeparam name="T">Tipo ou interface</typeparam>
        /// <param name="origem">objeto de origem</param>
        /// <param name="numeroCopias">quantidade de cópias</param>
        /// <param name="retornoInclusivo">Se true, inclui o objeto original na lista de retorno</param>
        /// <param name="aposCopiar">Action a executar a cada cópia: 
        /// Argumento 1 - T - Objeto origem
        /// Argumento 2 - T - Objeto destino 
        /// Argumento 3 - long - Numero da cópia base zero (0 = primeira cópia) 
        /// </param>
        /// <returns>IList de T com os objetos gerados</returns>
        public static IList<T> CriarCopias<T>(this object origem, long numeroCopias, bool retornoInclusivo, Action<T, T, long> aposCopiar)
        {
            return origem.CriarCopias<T>(numeroCopias, retornoInclusivo, aposCopiar, null);
        }

        /// <summary>
        /// Método de extensão para cria uma lista de cópias de um objeto
        /// </summary>
        /// <remarks>
        /// Criado por   : Paulo César B. S.
        /// Data         : 24/10/2012
        /// </remarks>
        /// <typeparam name="T">Tipo ou interface</typeparam>
        /// <param name="origem">objeto de origem</param>
        /// <param name="numeroCopias">quantidade de cópias</param>
        /// <param name="retornoInclusivo">Se true, inclui o objeto original na lista de retorno</param>
        /// <param name="aposCopiar">Action a executar a cada cópia: 
        /// Argumento 1 - T - Objeto origem
        /// Argumento 2 - T - Objeto destino 
        /// Argumento 3 - long - Numero da cópia base zero (0 = primeira cópia) 
        /// </param>
        /// <param name="aposCopiarTodos">Action a executar ao final das cópias
        /// Argumento 1 T - Objeto origem 
        /// Argumento 2 IList de T - Lista com os objetos gerados: 
        /// Argumento 3 bool - Se true, indica que o objeto original está incluido na lista de objetos
        /// </param>
        /// <returns>IList de T com os objetos gerados</returns>
        public static IList<T> CriarCopias<T>(this object origem, long numeroCopias, bool retornoInclusivo, Action<T, T, long> aposCopiar, Action<T, IList<T>, bool> aposCopiarTodos)
        {
            List<T> listaRetorno = new List<T>();
            if (retornoInclusivo)
                listaRetorno.Add((T)origem);
            for (long i = 0; i < numeroCopias; i++)
            {
                T novoObjeto = (T)Activator.CreateInstance(origem.GetType());
                origem.CopiarPropriedades(novoObjeto);
                if (aposCopiar.IsNotNull())
                    aposCopiar((T)origem, (T)novoObjeto, i);
                listaRetorno.Add((T)novoObjeto);
            }

            if (aposCopiarTodos.IsNotNull())
                aposCopiarTodos((T)origem, listaRetorno, retornoInclusivo);

            return listaRetorno;
        }

        public static object PegarValorPropriedade(object objetoOrigem, String nomePropriedade)
        {
            string[] propriedades = nomePropriedade.Split('.');
            Object valorDaPropriedade = objetoOrigem;

            foreach (string item in propriedades)
            {
                PropertyInfo info = valorDaPropriedade.GetType().GetProperty(item);

                if (info.IsNull())
                    throw new Exception();

                nomePropriedade = info.Name;
                valorDaPropriedade = info.GetValue(valorDaPropriedade, null);
            }

            return valorDaPropriedade;
        }

        public static PropertyInfo PegarPropriedade(object objetoOrigem, String nomePropriedade)
        {
            string[] propriedades = nomePropriedade.Split('.');
            Object valorDaPropriedade = objetoOrigem;
            PropertyInfo info = null;

            foreach (string item in propriedades)
            {
                info = valorDaPropriedade.GetType().GetProperty(item);

                if (info.IsNull())
                    throw new Exception();

                valorDaPropriedade = info.GetValue(valorDaPropriedade, null);
            }

            return info;
        }

        public static Object ObterValorParametroPorIndiceOuNulo(this object[] parametros, int indice)
        {
            if (parametros.IsNotNull())
                if (indice < parametros.Length)
                    return parametros[indice];

            return null;
        }

        public static T ObterValorParametroPorIndiceOuNulo<T>(this object[] parametros, int indice)
        {
            try
            {
                return (T)ObterValorParametroPorIndiceOuNulo(parametros, indice);
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }

        /// <summary>
        /// Se a posição do indice na array não retornar nulo, a ação é executada.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parametros">array a verificar</param>
        /// <param name="indice">indice a verificar</param>
        /// <param name="acao">delegate com assinatura: void acao(T objeto)</param>
        public static void SeParametroNaoNuloExecutar<T>(this object[] parametros, int indice, Action<T> acao)
        {
            if (parametros.ObterValorParametroPorIndiceOuNulo(indice).IsNotNull())
                acao(parametros.ObterValorParametroPorIndiceOuNulo<T>(indice));
        }

        public static String RetornaStringPropriedadeOuVazio<T>(this T objeto, Func<T, String> funcPropriedade, String prefixo)
        {
            String valorPro = null;
            if (objeto.IsNotNull() && (valorPro = funcPropriedade(objeto)).IsNotNull())
                return (prefixo ?? String.Empty) + valorPro;
            else
                return String.Empty;
        }

        public static String RetornaStringPropriedadeOuVazio<T>(this T objeto, Func<T, String> funcPropriedade)
        {
            return objeto.RetornaStringPropriedadeOuVazio(funcPropriedade, null);
        }

        public static T UsarRetornar<T>(this T objeto, Action<T> acao)
        {
            acao(objeto);
            return objeto;
        }

        public static TResult UsarAvaliar<T, TResult>(this T objeto, Func<T, TResult> funcao)
        {
            return funcao(objeto);
        }

        // Convert an object to a byte array
        public static byte[] ObjectToByteArray(this Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public static T ByteArrayToObject<T>(this byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return (T)obj;
        }

        //Recuperar Tamanho Objeto Bytes
        public static long PegarTamanhoObjeto(this object o)
        {
            long size;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }
            return size;
        }




    }
}