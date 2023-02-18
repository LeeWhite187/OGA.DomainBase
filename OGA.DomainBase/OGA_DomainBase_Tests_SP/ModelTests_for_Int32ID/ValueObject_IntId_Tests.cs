using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OGA.DomainBase_Tests
{
    /* ValueObject Tests:
     *  1. Simple VO derivation.
     *  2. 
     *  3. 
     *  4. 
     *  5. 
     *  6. 
     *  7. 
     *  8. 
     *  9. 
     * 10. 
     */

    [TestClass]
    public class ValueObject_IntId_Tests
    {
        [TestMethod]
        public void Test1()
        {
            // Declare an instance of our test class...
            ValueObject_IntId_TestDerivedClass r = new ValueObject_IntId_TestDerivedClass("sdfsdfsd", -9999, true);

            if (r.strVal != "sdfsdfsd")
                Assert.Fail("Value not correct.");
            if (r.intVal != -9999)
                Assert.Fail("Value not correct.");
            if (r.boolVal != true)
                Assert.Fail("Value not correct.");
        }
    }
}
