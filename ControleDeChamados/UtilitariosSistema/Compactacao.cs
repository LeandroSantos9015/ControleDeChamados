using System;
using System.IO;
using System.IO.Compression;
///using UtilitariosSistema.Meta.Serializacao;

namespace UtilitariosSistema
{
    /// <summary>
    /// Classe responsável em realizar compactação de dados serializáveis.
    /// A forma de compactação disponível é o GZip e Deflate. Em testes 
    /// realizados, o Deflate realiza a melhor compactação para tamanhos:
    /// pequenos, médios e grandes em relação ao tamanho do elemento compactado.
    /// </summary>
    /// <remarks>
    /// Criado por : Fábio Vendramin Guimarães Rosini
    /// Data       : 30/12/2008
    /// </remarks>
    [Serializable]
    public class Compactador
    {
        #region Constantes

        private const int BufferSize = 200;

        #endregion

        #region Atributos

        /// <summary>
        /// Tipo de compactação escolhida
        /// </summary>
        private EAlgoritmoCompactacao tipoCompactacao;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor que seta o tipo de compactação que será utilizada.
        /// </summary>
        /// <param name="tipoCompactacao">Tipo de compactação.</param>
        public Compactador(EAlgoritmoCompactacao tipoCompactacao)
        {
            this.tipoCompactacao = tipoCompactacao;
        }

        /// <summary>
        /// Construtor que seta o tipo de compactação Deflate como padrão.
        /// </summary>
        public Compactador()
            : this(EAlgoritmoCompactacao.Deflate)
        {
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Retorna o tipo de compactação.
        /// </summary>
        public EAlgoritmoCompactacao TipoCompactacao
        {
            get
            {
                return this.tipoCompactacao;
            }
        }

        /// <summary>
        /// Retorna o dado compactado.
        /// </summary>
        public byte[] DadoCompactado { get; private set; }

        #endregion

        #region Compactação e Descompatação

        /// <summary>
        /// Método responsável em compactar o parâmetro passado.
        /// </summary>
        /// <param name="compactarDado">Dado a ser compactado.</param>
        public void Compactar(byte[] compactarDado)
        {
            this.DadoCompactado = Compactar(compactarDado, this.TipoCompactacao);
        }

        /// <summary>
        /// Método responsável em compactar o parâmetro passado.
        /// </summary>
        /// <param name="compactarObjeto">Dado a ser compactado.</param>
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o objeto a ser serializado não possa ser 
        /// serializavel. Pode ser que a classe do objeto não esteja marcado como 
        /// [Serializable].
        /// </exception>
        public void Compactar(object compactarObjeto)
        {
            this.Compactar(compactarObjeto.Serializar());
        }

        /// <summary>
        /// Descompacta um dado previamente compactado.
        /// </summary>
        /// <returns>Retorna o dado descompactado.</returns>
        public byte[] Descompactar()
        {
            return Descompactar(this.DadoCompactado, this.TipoCompactacao);
        }

        /// <summary>
        /// Descompacta um dado previamente compactado.
        /// </summary>
        /// <returns>Retorna o dado descompactado.</returns>
        /// <exception cref="InvalidCastException">
        /// Está exception será lançada caso o objeto a ser desserializado não possa ser 
        /// convertido no tipo generics TCast.
        /// </exception>
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o array de byte não seja um objeto válido.
        /// </exception>
        public TTipo Descompactar<TTipo>()
        {
            return this.Descompactar().Desserializar<TTipo>();
        }

        #endregion

        #region Métodos Estáticos

        /// <summary>
        /// Método responsável em compactar o parâmetro passado e retorna-lo compactado.
        /// </summary>
        /// <param name="compactarObjeto">Dado a ser compactado.</param>
        /// <param name="tipoCompactacao">Algoritmo de compatação.</param>
        /// <returns>
        ///     Retorna o dado compactado com base no algoritmo de compactação.
        ///     Se for passado dado nulo, será retornado nulo.
        /// </returns>
        /// <exception cref="SerializationException">
        /// Está exception será lançada caso o objeto a ser serializado não possa ser 
        /// serializavel. Pode ser que a classe do objeto não esteja marcado como 
        /// [Serializable].
        /// </exception>
        public static byte[] Compactar(object compactarObjeto, EAlgoritmoCompactacao tipoCompactacao)
        {
            return Compactar(compactarObjeto.Serializar(), tipoCompactacao);
        }

        /// <summary>
        /// Método responsável em compactar o parâmetro passado e retorna-lo compactado.
        /// </summary>
        /// <param name="compactarDado">Dado a ser compactado.</param>
        /// <param name="tipoCompactacao">Algoritmo de compatação.</param>
        /// <returns>
        ///     Retorna o dado compactado com base no algoritmo de compactação.
        ///     Se for passado dado nulo, será retornado nulo.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static byte[] Compactar(byte[] compactarDado, EAlgoritmoCompactacao tipoCompactacao)
        {
            if (compactarDado != null)
            {
                MemoryStream ondeSeraCompactado = new MemoryStream();
                Stream algoritmo = CriarStreamCompactacao(tipoCompactacao, ondeSeraCompactado, CompressionMode.Compress);

                algoritmo.Write(compactarDado, 0, compactarDado.Length);
                algoritmo.Close();

                return ondeSeraCompactado.ToArray();
            }
            else
                return compactarDado;
        }

        /// <summary>
        /// Descompacta o dado passado como parâmetro.
        /// </summary>
        /// <typeparam name="TTipo">Tipo utilizado para cast do dado descompactado.</typeparam>
        /// <param name="dadoCompactado">Dado a ser descompactado.</param>
        /// <param name="tipoCompactacao">Algoritmo de descompactação.</param>
        /// <returns>Retorna o dado descompactado.</returns>
        /// <exception cref="InvalidDataException">
        ///     Está exception será lançada caso o byte[] passado para descompactação
        ///     não seja válido. Por exemplo, se tentar descompactar um dado que não foi
        ///     compactado ou usar um algoritmo diferente para descompactar com relação
        ///     ao compactado.
        /// </exception>
        public static TTipo Descompactar<TTipo>(byte[] dadoCompactado, EAlgoritmoCompactacao tipoCompactacao)
        {
            return Descompactar(dadoCompactado, tipoCompactacao).Desserializar<TTipo>();
        }

        /// <summary>
        /// Descompacta o dado passado como parâmetro.
        /// </summary>
        /// <param name="dadoCompactado">Dado a ser descompactado.</param>
        /// <param name="tipoCompactacao">Algoritmo de descompactação.</param>
        /// <returns>Retorna o dado descompactado.</returns>
        /// <exception cref="InvalidDataException">
        ///     Está exception será lançada caso o byte[] passado para descompactação
        ///     não seja válido. Por exemplo, se tentar descompactar um dado que não foi
        ///     compactado ou usar um algoritmo diferente para descompactar com relação
        ///     ao compactado.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        public static byte[] Descompactar(byte[] dadoCompactado, EAlgoritmoCompactacao tipoCompactacao)
        {
            if (dadoCompactado != null)
            {
                MemoryStream ondeSeraCompactado = new MemoryStream(dadoCompactado);
                Stream algoritmo = CriarStreamCompactacao(tipoCompactacao, ondeSeraCompactado, CompressionMode.Decompress);

                return RetornaTodosBytesDoStream(algoritmo);
            }
            else
                return dadoCompactado;
        }

        #endregion

        #region Utilitario

        /// <summary>
        /// Retorna um byte[] de um Stream.
        /// </summary>
        /// <param name="stream">Stream que será utilizado para ler os bytes.</param>
        /// <returns>Retorna o byte[] do Stream passado como parâmetro.</returns>
        /// <exception cref="InvalidDataException">
        ///     Está exception será lançada caso o byte[] passado para descompactação
        ///     não seja válido. Por exemplo, se tentar descompactar um dado que não foi
        ///     compactado ou usar um algoritmo diferente para descompactar com relação
        ///     ao compactado.
        /// </exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private static byte[] RetornaTodosBytesDoStream(Stream stream)
        {
            byte[] buffer = new byte[BufferSize];
            MemoryStream armazenaBytesLidos = new MemoryStream();
            int bytesLidos;

            do
            {
                bytesLidos = stream.Read(buffer, 0, BufferSize);
                armazenaBytesLidos.Write(buffer, 0, bytesLidos);
            }
            while (bytesLidos != 0);

            return armazenaBytesLidos.ToArray();
        }

        /// <summary>
        /// Cria o tipo de compactação com base no primeiro parâmetro.
        /// </summary>
        /// <param name="algoritmo">Tipo de compactação.</param>
        /// <param name="ondeSeraCompactadoDescompactado">Stream onde o dado será compactado ou descompactado.</param>
        /// <param name="modoDeCompactacao">Especifica se o dado será compactado ou descompactado.</param>
        /// <returns>Retorna um Strem do tipo DeflateStream ou  GZipStream de acordo com o tipo de compactação.</returns>
        private static Stream CriarStreamCompactacao(EAlgoritmoCompactacao algoritmo, Stream ondeSeraCompactadoDescompactado, CompressionMode modoDeCompactacao)
        {
            if (EAlgoritmoCompactacao.Deflate.Equals(algoritmo))
                return new DeflateStream(ondeSeraCompactadoDescompactado, modoDeCompactacao, true);
            else
                return new GZipStream(ondeSeraCompactadoDescompactado, modoDeCompactacao, true);
        }

        #endregion
    }

    #region Enum do tipo de compactação

    /// <summary>
    /// Enum que representa o tipo de compactação disponível.
    /// </summary>
    public enum EAlgoritmoCompactacao : byte
    {
        Deflate = 0,
        Gzip = 1
    }

    #endregion
}