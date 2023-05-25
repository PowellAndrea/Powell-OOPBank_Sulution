using Moq;

namespace OOPBank.Tests
{
    [TestClass]
    public class TestAccount
    {
        [TestMethod]
        public void CanDepositToSavings()
        {
            Savings savings = new(1);
            //Checking checking = new(1);

            var mockCustomer = new Mock<Customer>();
            mockCustomer.SetupProperty(e => e.ID, 1);
            mockCustomer.SetupProperty(e => e.Savings, savings);
            //mockCustomer.SetupProperty(e => e.Checking, checking);

            Customer newCustomer = mockCustomer.Object;
            savings.Deposit(200M);

        }

        [TestMethod]
        // here or bank?  Override Withdrawl action in Checking account?
        public void CheckingHasOverdraftProtection()
        {

        }


    }
}
