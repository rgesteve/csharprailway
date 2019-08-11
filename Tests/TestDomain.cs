using System;
using Xunit;

using roptry.Domain;

namespace Tests
{
    public class ROPTest
    {
        [Fact]
        public void TestTariff()
        {
		decimal expected = 10;
		Tariff t = new Tariff(expected, null);
		Assert.Equal(t.OrderCharge, expected);
        }

        [Fact]
        public void TestCustomer()
        {
		decimal tariffAmount = 10;
		Tariff t = new Tariff(tariffAmount, null);
		string customerName = "John Doe";
		Customer c = new Customer(customerName, t);
		Assert.Equal(c.Name, customerName);
        }

        [Fact]
        public void TestSalesOrder()
        {
		decimal tariffAmount = 10;
		Tariff t = new Tariff(tariffAmount, null);
		string customerName = "John Doe";
		Customer c = new Customer(customerName, t);
		string sorderExpected = "testOrder";
		SalesOrder so = new SalesOrder(sorderExpected, null, c);
		Assert.Equal(so.OrderNumber, sorderExpected);
        }

	[Fact]
	public void TestCtorDoesntTakeNull()
        {
                Assert.Throws<ArgumentNullException>(() => new Invoice(null, 0, 0));
        }

    }
}
