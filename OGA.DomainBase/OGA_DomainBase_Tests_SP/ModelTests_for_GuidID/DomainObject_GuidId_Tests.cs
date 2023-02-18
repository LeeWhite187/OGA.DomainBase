using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OGA.DomainBase_Tests
{
    /* DomainObject Tests:
        //  1. Simple object derivation with a Guid type id.
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
    public class DomainObject_GuidId_Tests
    {
        //  1. Simple object derivation with a Guid type id.
        [TestMethod]
        public void Test1()
        {
            OGA.DomainBase.Models.DomainObject<System.Guid> dm = new OGA.DomainBase.Models.DomainObject<System.Guid>();

            var idt = dm.Id.GetType();

            if (idt != typeof(System.Guid))
                Assert.Fail("Wrong Id type.");
        }
    }
}
