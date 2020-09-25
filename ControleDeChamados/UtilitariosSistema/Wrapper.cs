using System;
//using UtilitariosSistema.Meta.Compactacao;
//using UtilitariosSistema.Meta.Serializacao;

namespace UtilitariosSistema
{
    /// <summary>
    /// Classe empacotadora (Wrapper) de um objeto serializado. Pode ser utilizado como tipo, para
    /// abstrair o processo de serialização e desserialização. Além disso, esta classe Compacta o
    /// dado serializado, otimizando o processo de transferência. O processo de compactação utilizado é o Deflate.
    /// O Generics é usado para que o método Value retorne o objeto com o tipo correto, sem a necessidade de Casting.
    /// </summary>
    /// <typeparam name="TTypeData">Tipo que será empacotado.</typeparam>
    /// <remarks>
    /// Criado por : Fábio Vendramin Guimarães.
    /// Data       : 23/06/2008.
    /// </remarks>
    [Serializable]
    public abstract class Wrapper<TTypeData>
    {
        #region Propriedades

        /// <summary>
        /// Atributo que armazena o objeto compactado e serializado.
        /// </summary>
        protected Compactador DataCompactador { get; set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor responsável em armazenar o objeto a ser serializado.
        /// </summary>
        /// <param name="obj">Objeto que será serializado.</param>
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o objeto a ser serializado não possa ser 
        /// serializavel. Pode ser que a classe do objeto não esteja marcado como 
        /// [Serializable].
        /// </exception>
        protected Wrapper(TTypeData objeto)
        {
            this.DataCompactador = new Compactador(EAlgoritmoCompactacao.Deflate);
            this.SetValue(objeto.Serializar());
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método responsável em armazenar o objeto serializado.
        /// </summary>
        /// <param name="value">Bytes do objeto serializado.</param>
        private void SetValue(byte[] value)
        {
            this.DataCompactador.Compactar(value);
        }

        /// <summary>
        /// Método responsável em Desserializar e retornar o objeto TTypeData.
        /// </summary>
        /// <returns>Retorna o objeto desserializado com o tipo TTypeData</returns>        
        public virtual TTypeData Value
        {
            get
            {
                return this.GetCastValue<TTypeData>();
            }
        }

        /// <summary>
        /// Método responsável em Desserializar e retornar o objeto TTypeSpecific.
        /// </summary>
        /// <typeparam name="TTypeSpecific">Tipo que será convertido o objeto desserializado.</typeparam>
        /// <returns>Retorna o objeto desserializado.</returns>
        /// <exception cref="InvalidCastException">
        /// Está exception será lançada caso o objeto a ser desserializado não possa ser 
        /// convertido no tipo generics TTypeSpecific.
        /// </exception>
        public virtual TTypeSpecific GetCastValue<TTypeSpecific>()
        {
            //default(T): Este comando retorna null para um tipo Generics
            byte[] data = this.DataCompactador.Descompactar();
            return (data == null) ? default(TTypeSpecific) : data.Desserializar<TTypeSpecific>();
        }

        #endregion
    }
}