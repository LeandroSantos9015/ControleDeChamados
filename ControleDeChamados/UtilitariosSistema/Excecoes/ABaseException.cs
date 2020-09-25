using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
//using UtilitariosSistema.Meta.Enumerator;
//using UtilitariosSistema.Meta.Exceptions.Base.Enums;
//using UtilitariosSistema.Meta.Extensions;
//using UtilitariosSistema.Meta.Internacionalizacao;
//using UtilitariosSistema.Meta.Validacao;

namespace Customizados.Excecoes
{
    /// <summary>
    /// Classe Abstrata que contém a implementação básica do esquema de exceção.
    /// </summary>
    /// <remarks>
    /// Criado por   : Fábio Vendramin Guimarães Rosini
    /// Data         : 08/01/2009
    ///              
    /// Alterado por : Michel Banagouro.
    /// Data         : 09/10/2009.
    /// Descrição    : Implementado o construtor protegido e o método GetObjectData para customizar
    ///                a serialização do objeto.
    ///                Alterado o tipo da propriedade ClasseOrigem pra String.
    ///                
    /// Alterado por : José Rodrigo Gaspari
    /// Data         : 10/10/2011
    /// Descrição    : Adicionada as propriedades ProgramadorLancouExcecao e PrioridadeCorrecao, para controle de correção dos erros.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "ABase"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2240:ImplementISerializableCorrectly"), Serializable]
    public abstract class ABaseException : Exception, IBaseException
    {


        #region Propriedades

        /// <summary>
        /// Armazena uma lista com as possíveis soluções da exceção.
        /// </summary>
        public IList<string> Solucoes { get; private set; }

        /// <summary>
        /// Define a classificação da exceção.
        /// O valor default é EClassification.Error
        /// </summary>
        //public EClassificacao Classificacao { get; set; }

        /// <summary>
        /// Define a Area onde a exceção ocorreu.
        /// O valor default é EArea.None
        /// </summary>
        //public EArea Area { get; set; }

        /// <summary>
        /// Define a classe onde a exceção ocorreu.
        /// </summary>
        public String ClasseOrigem { get; set; }

        /// <summary>
        /// Define o nome do construtor, método ou propriedade onde ocorreu a exceção.
        /// </summary>
        public String OperacaoOrigem { get; set; }

        /// <summary>
        /// Define o nome do programador que lançou a exceção.
        /// </summary>
        //public EAnalistaProgramador ProgramadorLancouExcecao { get; set; }

        /// <summary>
        /// Define o nível de prioridade para a correção do erro.
        /// </summary>
       // public EPrioridadeCorrecao PrioridadeCorrecao { get; set; }

        /// <summary>
        /// Armazena os parâmetros de formatação da Mensagem.
        /// </summary>
        public object[] Parametros { get; protected set; }

        #endregion

        #region Construtor

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        protected ABaseException()
        {
            this.Solucoes = new List<string>();
        }

        /// <summary>
        /// Construtor que na hora da desserialização é chamado.
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        protected ABaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Solucoes = (List<string>)info.GetValue("Solucoes", typeof(object));
           // this.Classificacao = (EClassificacao)info.GetValue("Classificacao", typeof(object));
           // this.Area = (EArea)info.GetValue("Area", typeof(object));
            this.ClasseOrigem = info.GetString("ClasseOrigem");
            this.OperacaoOrigem = info.GetString("OperacaoOrigem");
            this.Parametros = (object[])info.GetValue("Parametros", typeof(object[]));
            //this.ProgramadorLancouExcecao = (EAnalistaProgramador)info.GetValue("ProgramadorLancouExcecao", typeof(object));


        }

        /// <summary>
        /// Construtor que define as propriedades básicas da exceção.
        /// </summary>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <param name="area">Area da Exceção.</param>
        /// <param name="valoresFormatarMensagem">Lista de parâmetros que serão substituídos na menssagem, utilizando String.Format</param>
        //protected ABaseException(EMsgPadrao mensagem, EArea area, params object[] valoresFormatarMensagem)
        //    : this(mensagem, area, null, valoresFormatarMensagem) { }

        /// <summary>
        /// Construtor que define as propriedades básicas da exceção.
        /// </summary>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <param name="innerException">Exceção gerada.</param>
        /// <param name="area">Area da Exceção.</param>
        /// <param name="valoresFormatarMensagem">Lista de parâmetros que serão substituídos na menssagem, utilizando String.Format</param>
        //protected ABaseException(EMsgPadrao mensagem, EArea area, Exception innerException, params object[] valoresFormatarMensagem)
        //    : this(mensagem, area, innerException, null, null, valoresFormatarMensagem) { }

        /// <summary>
        /// Construtor que define as propriedades básicas da exceção.
        /// </summary>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <param name="innerException">Exceção gerada.</param>
        /// <param name="area">Area da Exceção.</param>
        /// <param name="classeOrigem">Classe onde ocorreu a exceção.</param>
        /// <param name="operacaoOrigem">Nome do construtor, método ou propriedade onde ocorreu a exceção.</param>
        /// <param name="valoresFormatarMensagem">Lista de parâmetros que serão substituídos na menssagem, utilizando String.Format</param>
        //protected ABaseException(EMsgPadrao mensagem, EArea area, Exception innerException, Type classeOrigem, String operacaoOrigem, params object[] valoresFormatarMensagem)
        //    : this(mensagem.GetDescription(), area, innerException, classeOrigem, operacaoOrigem, valoresFormatarMensagem) { }

        /// <summary>
        /// Construtor que define as propriedades básicas da exceção.
        /// </summary>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <param name="classeOrigem">Classe onde ocorreu a exceção.</param>
        /// <param name="area">Area da Exceção.</param>
        /// <param name="operacaoOrigem">Nome do construtor, método ou propriedade onde ocorreu a exceção.</param>
        /// <param name="valoresFormatarOrigem">Lista de parâmetros que serão substituídos na menssagem, utilizando String.Format</param>
        //protected ABaseException(EMsgPadrao mensagem, EArea area, Type classeOrigem, String operacaoOrigem, params object[] valoresFormatarOrigem)
        //    : this(mensagem.GetDescription(), area, null, classeOrigem, operacaoOrigem, valoresFormatarOrigem) { }

        /// <summary>
        /// Construtor que define as propriedades básicas da exceção.
        /// </summary>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <param name="innerException">Exceção gerada.</param>
        /// <param name="area">Area da Exceção.</param>
        /// <param name="classeOrigem">Classe onde ocorreu a exceção.</param>
        /// <param name="operacaoOrigem">Nome do construtor, método ou propriedade onde ocorreu a exceção.</param>
        /// <param name="valoresFormatarMensagem">Lista de parâmetros que serão substituídos na menssagem, utilizando String.Format</param>
        //protected ABaseException(string mensagem, EArea area, Exception innerException, Type classeOrigem, String operacaoOrigem, params object[] valoresFormatarMensagem)
        //    : base(String.Format(Internacionalizar.PegarInstancia.PegarTraducao(mensagem), (valoresFormatarMensagem == null || valoresFormatarMensagem.Length.Equals(0)) ? new string[] { "" } : valoresFormatarMensagem), innerException)
        //{
        //    this.Solucoes = new List<string>();
        //    this.Classificacao = EClassificacao.Erro;
        //    this.Area = area;
        //    this.ClasseOrigem = classeOrigem.IsNull() ? String.Empty : classeOrigem.FullName;
        //    this.OperacaoOrigem = operacaoOrigem;
        //    this.Parametros = valoresFormatarMensagem;
        //}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "e")]
        //protected ABaseException(ESqlExceptionNumber eSqlExceptionNumber, params object[] valoresFormatarMensagem)
        //    : this(eSqlExceptionNumber.GetDescription(), EArea.SQLServer, null, null, "", valoresFormatarMensagem) { }

        /// <summary>
        /// Construtor que define as propriedades básicas da exceção.
        /// </summary>
        /// <param name="mensagem">Mensagem da exceção.</param>
        /// <param name="innerException">Exceção gerada.</param>
        /// <param name="area">Area da Exceção.</param>
        /// <param name="programador">Programador que lançou a exceção.</param>
        /// <param name="classeOrigem">Classe onde ocorreu a exceção.</param>
        /// <param name="operacaoOrigem">Nome do construtor, método ou propriedade onde ocorreu a exceção.</param>
        /// <param name="valoresFormatarMensagem">Lista de parâmetros que serão substituídos na menssagem, utilizando String.Format</param>
        //protected ABaseException(EMsgPadrao mensagem, EArea area, EAnalistaProgramador programador, Exception innerException, Type classeOrigem, String operacaoOrigem, params object[] valoresFormatarMensagem)
        //    : this(mensagem.GetDescription(), area, innerException, classeOrigem, operacaoOrigem, valoresFormatarMensagem)
        //{
        //    this.ProgramadorLancouExcecao = programador;
        //}

        #endregion

        #region Métodos

        public void AdicionarSolucoes(IEnumerable<String> solucoes)
        {
            if (solucoes != null)
                foreach (var solucao in solucoes)
                    this.Solucoes.Add(solucao);
        }

        #endregion

        #region Métodos Sobrecarregados

        /// <summary>
        /// Método para salvar as propriedades para serialização.
        /// </summary>
        /// <param name="info">SerializationInfo</param>
        /// <param name="context">StreamingContext</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
         //   info.AddValue("Classificacao", this.Classificacao, this.Classificacao.GetType());
         //   info.AddValue("Area", this.Area, this.Area.GetType());

            //if (this.ProgramadorLancouExcecao.IsNotNull())
            //    info.AddValue("ProgramadorLancouExcecao", this.ProgramadorLancouExcecao, this.ProgramadorLancouExcecao.GetType());

            //if (!this.Solucoes is null)
                info.AddValue("Solucoes", this.Solucoes, this.Solucoes.GetType());

            if (!String.IsNullOrEmpty(this.ClasseOrigem))
                info.AddValue("ClasseOrigem", this.ClasseOrigem, this.ClasseOrigem.GetType());
            else
                info.AddValue("ClasseOrigem", String.Empty, typeof(String));

            if (!String.IsNullOrEmpty(this.OperacaoOrigem))
                info.AddValue("OperacaoOrigem", this.OperacaoOrigem, this.OperacaoOrigem.GetType());
            else
                info.AddValue("OperacaoOrigem", String.Empty, typeof(String));

            //if (!this.Parametros is null)
            //    info.AddValue("Parametros", this.Parametros, this.Parametros.GetType());
            //else
            //    info.AddValue("Parametros", new object[] { }, typeof(object[]));


            base.GetObjectData(info, context);
        }

        #endregion
    }
}


public enum EMsgPadrao
{


}