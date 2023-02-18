using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OGA.DomainBase.Entities
{
    /// <summary>
    /// Holds a single configuration property that can be stored in an EF database.
    /// Includes the property name, value, and datatype.
    /// </summary>
    public class ConfigElement_v1 : NETCore_Common.Entities.cStorageBaseEntity
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
        public string DataType { get; set; }

        public ConfigElement_v1()
        {
            Key = "";
            Value = "";
            DataType = "";
        }
    }
}
