using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace UtilitariosSistema
{
    /// <summary>
    /// Classe estática de serialização e desserialização.
    /// </summary>
    /// <remarks>
    /// Criado por : Mateus Bahis.
    /// Data       : 01/04/2008.
    /// </remarks>
    public static class BinarySerialization
    {
        #region Extensão - Extensions (this)

        /// <summary>
        /// Criado por : Fábio Vendramin Guimarães
        /// Data       : 21/06/2008
        /// Descrição  : Método de expansão que serializa um objeto.
        /// </summary>
        /// <returns>Retorna o objeto serializado. Caso o objeto seja null, será
        ///          retornado null.
        /// </returns>
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o objeto a ser serializado não possa ser 
        /// serializavel. Pode ser que a classe do objeto não esteja marcado como 
        /// [Serializable].
        /// </exception>
        public static byte[] Serializar(this Object objeto)
        {
            if (objeto != null)
            {
                using (MemoryStream mem = new MemoryStream())
                {
                    new BinaryFormatter().Serialize(mem, objeto);
                    return mem.ToArray();
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Criado por : Fábio Vendramin Guimarães
        /// Data       : 21/06/2008
        /// Descrição  : Método de extensão que desserializa um objeto serializado.
        /// </summary>
        /// <typeparam name="TCast">Tipo que será realizado Cast na desserialização.</typeparam>
        /// <param name="objetoSerializado">objeto que será desserializado.</param>
        /// <returns>Retorna o objeto desserializado. Caso o objeto seja null será 
        ///          retornado null.
        /// </returns>
        /// <exception cref="InvalidCastException">
        /// Está exception será lançada caso o objeto a ser desserializado não possa ser 
        /// convertido no tipo generics TCast.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o array de byte não seja um objeto válido.
        /// </exception>
        public static TCast Desserializar<TCast>(this byte[] objetoSerializado)
        {
            if (objetoSerializado != null)
            {
                using (MemoryStream mem = new MemoryStream(objetoSerializado))
                {
                    return (TCast)(new BinaryFormatter().Deserialize(mem));
                }
            }
            else
                return default(TCast);
        }

        /// <summary>
        /// Criado por : Mateus Bahis
        /// Data       : 30/01/2009
        /// Descrição  : Método de extensão que desserializa um objeto serializado.
        /// </summary>        
        /// <param name="objetoSerializado">objeto que será desserializado.</param>
        /// <returns>Retorna o objeto desserializado. Caso o objeto seja null será 
        ///          retornado null.
        /// </returns>        
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o array de byte não seja um objeto válido.
        /// </exception>
        public static object Desserializar(this byte[] objetoSerializado)
        {
            if (objetoSerializado != null)
            {
                using (MemoryStream mem = new MemoryStream(objetoSerializado))
                {
                    return new BinaryFormatter().Deserialize(mem);
                }
            }
            else
                return null;
        }

        #endregion
    }
}