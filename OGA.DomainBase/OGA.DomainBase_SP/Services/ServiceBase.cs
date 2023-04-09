using System;

namespace OGA.DomainBase.Services
{
    public interface IDomainServiceBase<TId>
    {
        #region Public Properties

        /// <summary>
        /// Passed in at construction, to give the domain service a shared context for logging and event population.
        /// </summary>
        public string CorelationId { get; set; }

        public OGA.DomainBase.Models.UserContext<TId> UserContext { get; set; }

        #endregion
    }

    /// <summary>
    /// Provides common data and methods used by domain-level services, such as User context, corelationId, etc...
    /// </summary>
    public class DomainServiceBase<TId> : IDomainServiceBase<TId>
    {
        #region Private Fields

        static protected string _classname = nameof(DomainServiceBase<TId>);

        #endregion


        #region Public Properties

        /// <summary>
        /// Passed in at construction, to give the domain service a shared context for logging and event population.
        /// </summary>
        public string CorelationId { get; set; }

        public OGA.DomainBase.Models.UserContext<TId> UserContext { get; set; }

        #endregion

        public DomainServiceBase()
        {
            CorelationId = "";
            UserContext = new OGA.DomainBase.Models.UserContext<TId>();
        }
    }
}
