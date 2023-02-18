using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.DomainBase.SampleUsage
{
    /// <summary>
    /// Represents a sample value object that can be copied for its implementation.
    /// </summary>
    public class cItem_SampleValueObject : OGA.DomainBase.Models.ValueObject
    {
        public string Address { get; private set; }

        public string Subnet { get; private set; }
        public int Mask { get; private set; }

        public bool Is_V4 { get; private set; }

        public cItem_SampleValueObject(string address, string subnet, int mask, bool is_v4)
        {
            Address = address;
            Subnet = subnet;
            Mask = mask;
            Is_V4 = is_v4;
        }

        public override string ToString()
        {
            return $"{Address}, {Subnet}, {Mask} {Is_V4}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
            yield return Subnet;
            yield return Mask;
            yield return Is_V4;
        }
    }
}
