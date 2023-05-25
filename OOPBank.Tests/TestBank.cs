using Moq;
using System.Net.Http.Headers;

namespace OOPBank.Tests
{
    [TestClass]
    public class TestBank
    {
        [TestMethod]
        public void CanGetBankName()
        {
            Bank bank = new Bank();
            Assert.IsTrue(bank.Name == "Solvent Bank");
        }

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

        [TestMethod]
        public void CanDeposit()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            int x = mockCustomer.Object.ID;
            Account account = new(x);
            bank.addCustomer(mockCustomer.Object);
            bank.Deposit(account, 10M);
            Assert.IsTrue(account.Balance == 10M);

        }

    }
}