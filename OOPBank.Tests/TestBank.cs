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

        [TestMethod]
        public void CanWithdraw()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            int x = mockCustomer.Object.ID;
            Account account = new(x);
            bank.Deposit(account, 100M);
            bank.Withdraw(account, 50M);
          
            Assert.IsTrue(account.Balance == 50M);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Transfer failed")]
        public void TestODFail()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            Checking checking = new Checking(mockCustomer.Object.ID);
            Savings savings = new Savings(mockCustomer.Object.ID);
            mockCustomer.SetupProperty(e => e.Savings, savings);
            mockCustomer.SetupProperty(e => e.Checking, checking);
            bank.Deposit(savings, 10M);
            bank.Deposit(checking, 45M);
            bank.Withdraw(checking, 50M);
        }

        [TestMethod]
        public void TestODSucess()
        {
            Bank bank = new Bank();
            Customer customer = new("Andrea");
            bank.addCustomer(customer);

            bank.Deposit(customer.Savings, 3000M);
            bank.Deposit(customer.Checking, 2000M);

            bank.Withdraw(customer.Checking, 2500M);

            Assert.IsTrue(customer.Savings.Balance == 2500M && customer.Checking.Balance == 0);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Transfer Failed")]
        public void TransferFails()
        {
            Bank bank = new Bank();
            var mockCustomer = new Mock<Customer>("Andrea");
            int x = mockCustomer.Object.ID;
            Savings savings = new(x);
            bank.Deposit(savings, 15);
            Checking checking = new(x);
            bank.Transfer(savings, checking, 10);

        }

    }
}