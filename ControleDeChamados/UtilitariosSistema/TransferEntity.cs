using System;


namespace UtilitariosSistema
{
    /// <summary>
    /// Classe empacotadora (Wrapper) de um IEntity serializado.
    /// </summary>
    /// <remarks>
    /// Criado por : Fábio Vendramin Guimarães.
    /// Data       : 23/06/2008.
    /// </remarks>
    [Serializable]
    public class TransferEntity : Wrapper<IEntity>
    {
        #region Construtor

        /// <summary>
        /// Construtor responsável em armazenar o Objeto a ser serializado.
        /// </summary>
        /// <param name="entity">Objeto a ser serializado.</param>
        public TransferEntity(IEntity entity)
            : base(entity)
        {
        }

        #endregion
    }
}

public interface IEntity
{
    Int64? Id { get; set; }
}