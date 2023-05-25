using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace OOPBank.Tests
{
    [TestClass]
    public class TestAccount
    {
        [TestMethod]
        public void CanGetOdFlag()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account checking = new(mockCustomer.Object.ID);
            Assert.IsNotNull(checking.ODProtection);
        }

        [TestMethod]
        public void SavingsOdOffByDefault()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Savings savings = new(mockCustomer.Object.ID);
            Assert.IsFalse(savings.ODProtection);
        }

        [TestMethod]
        public void AccountDefaultMinIs0()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            decimal min = account.MIN_Balance;
            Assert.IsTrue(min == 0M);
        }

        [TestMethod]
        public void SavingsMinimumBalance10()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Savings savings = new(mockCustomer.Object.ID);
            decimal min = savings.MIN_Balance;
            Assert.IsTrue(min == 10M);
        }

        [TestMethod]
        public void CheckingOdOnByDefault()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Checking checking = new(mockCustomer.Object.ID);
            Assert.IsTrue(checking.ODProtection);
        }

        [TestMethod]
        public void CanTurnOnOverdraftProtection()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            account.turnOnOd();
            Assert.IsTrue(account.ODProtection);
        }

        [TestMethod]
        public void CanTurnOffOverdraftProtection()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            account.turnOffOd();
            Assert.IsFalse(account.ODProtection);
        }

        [TestMethod]
        public void CanGetBalance()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            Assert.IsTrue(account.Balance == 0M);
        }

        [TestMethod]
        public void CanGetAccountNumber()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            int n = account.AccountNumber;
            Assert.IsTrue(n == mockCustomer.Object.ID);
        }

        [TestMethod]
        public void CanGetCustomerID()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            int x = mockCustomer.Object.ID;
            Account account = new(mockCustomer.Object.ID);
        }

        [TestMethod]
        public void CanDeposit()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            account.Deposit(200M);
            Assert.IsTrue(account.Balance == 200M);
        }

        [TestMethod]
        public void CanWithdraw()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            Account account = new(mockCustomer.Object.ID);
            account.Deposit(200M);
            account.Withdraw(50M);
            Assert.IsTrue(account.Balance == 150M);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Withdraw failed.  Under minimum balance")]
        public void NoWithdrawUnderMinBalance()
        {
            var mockCustomer = new Mock<Customer>("Andrea");
            int x = mockCustomer.Object.ID;
            Savings savings = new(x);
            savings.Deposit(50);
            savings.Withdraw(45);
        }
    }
}
