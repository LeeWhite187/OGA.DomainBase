using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OGA.DomainBase.Entities
{
    /// <summary>
    /// Base entity for storing configuration data in an EF database backend.
    /// </summary>
    public class cStorageBaseEntity
    {
        public DateTime CreationDateUTC { get; set; }
        public DateTime ModifiedDateUTC { get; set; }

        public cStorageBaseEntity()
        {
            CreationDateUTC = new DateTime().ToUniversalTime();
            ModifiedDateUTC = new DateTime().ToUniversalTime();
        }
    }
}
