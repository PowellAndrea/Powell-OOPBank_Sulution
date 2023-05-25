using Moq;
using OOPBank;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

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
            bank.addCustomer(mockCustomer.Object);
            Assert.IsNotNull(bank.getCustomer(0));
        }
    }
}