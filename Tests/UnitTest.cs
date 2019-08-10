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
    }
}
