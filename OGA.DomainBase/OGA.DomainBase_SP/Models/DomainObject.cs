using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.DomainBase.Models
{
    /// <summary>
    /// Used to represent a single domain entity.
    /// The Id field can be Int32, Guid, string, etc...
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class DomainObject<TId> : OGA.DomainBase.Models.IAggregateRoot<TId> where TId : IEquatable<TId>
    {
        #region Public Properties

        /// <summary>
        /// Make the ID flexible at compile time.
        /// It can be an Int32, Int64, Guid, or String.
        /// </summary>
        public TId Id { get; protected set; }


        public DateTime? CreationDateUTC { get; protected set; }
        public DateTime? ModifiedDateUTC { get; protected set; }

        #endregion


        #region Property Accessors

        public void Set_CreationDateUTC(DateTime? creationdateutc)
        {
            //...
            // Domain rules/logic for adding the OrderItem to the order
            // ...
            //
            // Throw a business rules exception if a violation occurs, like this:
            //      throw new BusinessRuleBrokenException("vo sample must be specified!");

            this.CreationDateUTC = creationdateutc;
        }
        public void Set_ModifiedDateUTC(DateTime? modifieddateutc)
        {
            //...
            // Domain rules/logic for adding the OrderItem to the order
            // ...
            //
            // Throw a business rules exception if a violation occurs, like this:
            //      throw new BusinessRuleBrokenException("vo sample must be specified!");

            this.ModifiedDateUTC = modifieddateutc;
        }

        #endregion


        #region Propagation Methods

        /// <summary>
        /// Allows for duplication of object instance.
        /// Accepts a source instance from which to copy properties.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        virtual public void DuplicateFrom(object o)
        {
            DomainObject<TId> d = (DomainObject<TId>)o;

            this.Id = d.Id;
            this.CreationDateUTC = d.CreationDateUTC;
            this.ModifiedDateUTC = d.ModifiedDateUTC;
        }

        virtual public string ToLogString()
        {
            StringBuilder b = new StringBuilder();

            b.Append("Id = " + (Id.ToString() ?? "") + "\r\n");

            b.Append("CreationDateUTC = " + (CreationDateUTC?.ToString() ?? "null") + "\r\n");
            b.Append("ModifiedDateUTC = " + (ModifiedDateUTC?.ToString() ?? "null") + "\r\n");

            return b.ToString();
        }

        #endregion
    }
}
