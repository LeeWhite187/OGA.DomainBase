using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.DomainBase.Models
{
    /// <summary>
    /// Contains the id or other relevant info for a user or account.
    /// Is passed to domain-level service instances, so they can apply user security, during command or queries, at the entity or node level.
    /// </summary>
    public class UserContext<TId>
    {
        // Make the userid flexible at compile time.
        // It can be an Int32, Int64, Guid, or String.
        public TId userid { get; set; }

        public string[] roles  { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserContext()
        {
            roles = new string[] { };
        }
    }
}
