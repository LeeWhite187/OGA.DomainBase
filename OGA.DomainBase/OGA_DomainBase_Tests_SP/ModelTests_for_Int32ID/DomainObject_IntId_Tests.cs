using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OGA.DomainBase_Tests
{
    /* DomainObject Tests:
        //  1. Simple object derivation with an Int32 type id.
        //  2. 
        //  3. 
        //  4. 
        //  5. 
        //  6. 
        //  7. 
        //  8. 
        //  9. 
        // 10. 
     */

    [TestClass]
    public class DomainObject_IntId_Tests
    {
        //  1. Simple object derivation with an Int32 type id.
        [TestMethod]
        public void Test1()
        {
            OGA.DomainBase.Models.DomainObject<System.Int32> dm = new OGA.DomainBase.Models.DomainObject<System.Int32>();

            var idt = dm.Id.GetType();

            if (idt != typeof(System.Int32))
                Assert.Fail("Wrong Id type.");
        }
    }
}
