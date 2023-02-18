using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGA.DomainBase_Tests
{
    public class ValueObject_IntId_TestDerivedClass : OGA.DomainBase.Models.ValueObject
    {
        public int Id { get; protected set; }

        [Newtonsoft.Json.JsonProperty]
        public string strVal { get; protected set; }

        [Newtonsoft.Json.JsonProperty]
        public int intVal { get; protected set; }

        [Newtonsoft.Json.JsonProperty]
        public bool boolVal { get; protected set; }

        public ValueObject_IntId_TestDerivedClass(string strVal, int intVal, bool boolVal)
        {
            this.strVal = strVal;
            this.intVal = intVal;
            this.boolVal = boolVal;
        }

        public override string ToString()
        {
            return $"{strVal}, {intVal}, {boolVal}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return strVal;
            yield return intVal;
            yield return boolVal;
        }
    }
}
