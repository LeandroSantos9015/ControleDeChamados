using System;
using System.Collections.Generic;
//using UtilitariosSistema.Meta.Exceptions.Base.Enums;

namespace Customizados.Excecoes
{
    /// <summary>
    /// Interface com as propriedades que todo esquema de exceção do sistema deverá conter.
    /// </summary>
    /// <remarks>
    /// Criado por   : Fábio Vendramin Guimarães Rosini
    /// Data         : 08/01/2009
    ///              
    /// Alterado por : Michel Banagouro.
    /// Data         : 26/08/2009.
    /// Descrição    : Retirado a propriedade Mensagem que não estava sendo utilizado.
    /// </remarks>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix")]
    public interface IBaseException
    {
        /// <summary>
        /// Armazena uma lista com as possíveis soluções da exceção.
        /// </summary>
        IList<string> Solucoes { get; }

        /// <summary>
        /// Define a classificação da exceção.
        /// </summary>
       // EClassificacao Classificacao { get; set; }

        /// <summary>
        /// Define a Area onde a exceção ocorreu.
        /// </summary>
        //EArea Area { get; set; }

        /// <summary>
        /// Define a classe onde a exceção ocorreu.
        /// </summary>
        String ClasseOrigem { get; set; }

        /// <summary>
        /// Define o nome do construtor, método ou propriedade onde ocorreu a exceção.
        /// </summary>
        String OperacaoOrigem { get; set; }

        /// <summary>
        /// Armazena os parâmetros de formatação da Mensagem.
        /// </summary>
        object[] Parametros { get; }
    }
}