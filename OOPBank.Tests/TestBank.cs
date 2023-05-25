using Moq;

namespace OOPBank.Tests
{
    [TestClass]
    public class TestBank
    {
        [TestMethod]
        public void CanAddNewCustomer()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            bank.addCustomer(mockCustomer.Object);
            Assert.IsTrue(bank.CustomerCount() == 1);
        }

        [TestMethod]
        public void NewCustomerCanBeFoundByName()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            bank.addCustomer(mockCustomer.Object);
            Assert.IsNotNull(bank.getCustomer("Andrea"));
        }

        [TestMethod]
        public void NewCustomerCanBeFoundByID()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            int i = mockCustomer.Object.ID;
            //mockCustomer.SetupProperty(e => e.Id, 1);
            bank.addCustomer(mockCustomer.Object);
            Assert.IsNotNull(bank.getCustomer(i).Name == "Andrea");
        }
    }
}