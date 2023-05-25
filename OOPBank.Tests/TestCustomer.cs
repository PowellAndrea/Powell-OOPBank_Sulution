using Moq;

namespace OOPBank.Tests
{
    [TestClass]
    public class TestCustomer
    {
        [TestMethod]
        public void NewCustomerHasChecking()
        {
            Customer customer = new("Andrea");
            Assert.IsNotNull(customer.Checking);
        }

        [TestMethod]
        public void NewCustomerHasSavings()
        {
            Customer customer = new("Andrea");
            Assert.IsNotNull(customer.Savings);
        }

        [TestMethod]
        public void CanGetCustomerName()
        {
            Customer customer = new("Andrea");
            Assert.AreEqual(customer.Name, "Andrea");
        }

        [TestMethod]
        public void CustomerHasID()
        {
            Customer customer = new("Andrea");
            Assert.IsNotNull(customer.ID);
        }

    }
}
