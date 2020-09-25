using System.Collections;
using Iesi.Collections;


namespace UtilitariosSistema
{
    /// <summary>
    /// Classe que implementa métodos, utilizando o conceito de Extensão, para conversão implicita de 
    /// Wrappers. 
    /// </summary>
    /// <remarks>
    /// Criado por : Fábio Vendramin Guimarães.
    /// Data       : 23/06/2008.
    /// </remarks>
    public static class TransferUtility
    {
        /// <summary>
        /// Retorna um objeto TransferEntity.
        /// </summary>
        /// <param name="entity">Tipo do objeto que poderá chamar este método.</param>
        /// <returns>Retorna um objeto TransferEntity.</returns>
        public static TransferEntity ToTransfer(this IEntity entity)
        {
            return new TransferEntity(entity);
        }

        /// <summary>
        ///  Retorna um objeto TransferType.
        /// </summary>
        /// <param name="type">Tipo do objeto que poderá chamar este método.</param>
        /// <returns>Retorna um objeto TransferType.</returns>
        //public static TransferType ToTransfer(this System.Type type)
        //{
        //    return new TransferType(type);
        //}

        ///// <summary>
        ///// Retorna um objeto TransferIList.
        ///// </summary>
        ///// <param name="list">Tipo do objeto que poderá chamar este método.</param>
        ///// <returns>Retorna um objeto TransferIList.</returns>
        //public static TransferIList ToTransfer(this IList list)
        //{
        //    return new TransferIList(list);
        //}

        ///// <summary>
        ///// Retorna um objeto TransferObject.
        ///// </summary>
        ///// <param name="objeto">Tipo do objeto que poderá chamar este método.</param>
        ///// <returns>Retorna um objeto TransferObject.</returns>
        //public static TransferObject ToTransfer(this object objeto)
        //{
        //    return new TransferObject(objeto);
        //}

        //public static TransferISet ToTransfer(this ISet list)
        //{
        //    return new TransferISet(list);
        //}

        //public static TransferConsulta ToTransfer(this ParametroConsulta parametroConsulta)
        //{
        //    return new TransferConsulta(parametroConsulta);
        //}

        //public static TransferConsultaDapper ToTransfer(this ParametroConsultaDapper parametroConsulta)
        //{
        //    return new TransferConsultaDapper(parametroConsulta);
        //}
    }
}