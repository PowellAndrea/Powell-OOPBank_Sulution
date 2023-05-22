using Moq;

namespace OOPBank.Tests
{
    [TestClass]
    public class UnitTest
    {
        static int actNum = 1;

        [TestMethod]
        public void TestCustomer()
        {
            var mockAccount = new Mock<IAccount>();
            mockAccount.SetupProperty(e => e._balance, 500M);
            mockAccount.SetupProperty(e => e._accountNumber, actNum);
            mockAccount.Setup(e => e.Deposit(10.00M));

            Customer customer = new Customer("Andrea");
            customer._savings.Equals(mockAccount.Object);
            
        }

        public void TestWithdrawlOK()
        {

        }

        public void TestWithdrawlOD()
        {

        }

        public void TestMinBal0() { }
        public void TestMinBalNegative() { }
        public void TestMinBalPositive() { }


    }
}