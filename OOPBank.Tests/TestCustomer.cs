using Moq;

namespace OOPBank.Tests
{
    [TestClass]

    internal class TestCustomer
    {
        [TestMethod]
        public void NewCustomerHasChecking()
        {
            Customer customer = new("Andrea");

        }

       // var mockCustomer = new Mock<Customer>();
        //mockCustomer.SetupProperty(e => e.ID, 1);
        //    mockCustomer.SetupProperty(e => e.Savings, savings);
        //    //mockCustomer.SetupProperty(e => e.Checking, checking);

        //    Customer newCustomer = mockCustomer.Object;
        //savings.Deposit(200M);



        [TestMethod]
        public void NewCustomerHasSavings()
        {

        }

        [TestMethod]
        public void CanGetCustomerName()
        {

        }


    }
}
