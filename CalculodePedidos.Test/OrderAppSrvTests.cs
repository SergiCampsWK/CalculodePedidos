using CalculodePedidos.App;
using CalculodePedidos.Domain;
using CalculodePedidos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculodePedidos.UnitTest
{
    public class OrderAppSrvTests
    {
        private static readonly ICountryRepo repo = new CountryRepo();
        private readonly IOrderAppSrv orderService = new OrderAppSrv(repo);

        [Fact]
        public void CreateOrder_ValidArguments_ReturnValidTotalBase()
        {
            var units = "100";
            var unitPrice = "2";
            var discountPercentage = "10";

            var order = orderService.CreateOrder(units, unitPrice, discountPercentage);

            Assert.Equal(200, order.TotalBase);
        }

        [Fact]
        public void CreateOrder_ValidArguments_ReturnValidTotalDiscount()
        {
            var units = "100";
            var unitPrice = "2";
            var discountPercentage = "10";

            var order = orderService.CreateOrder(units, unitPrice, discountPercentage);

            Assert.Equal(20, order.TotalDiscount);
        }

        [Fact]
        public void CreateOrder_InvalidUnits_ThrowsArgumentException()
        {
            var units = "AAA";
            var unitPrice = "2";
            var discountPercentage = "10";

            Assert.Throws<ArgumentException>(() => orderService.CreateOrder(units, unitPrice, discountPercentage));
        }

        [Fact]
        public void CreateOrder_InvalidUnitPrice_ThrowsArgumentException()
        {
            var units = "100";
            var unitPrice = "AAA";
            var discountPercentage = "10";

            Assert.Throws<ArgumentException>(() => orderService.CreateOrder(units, unitPrice, discountPercentage));
        }

        [Fact]
        public void CreateOrder_InvalidDiscountPercentage_ThrowsArgumentException()
        {
            var units = "100";
            var unitPrice = "2";
            var discountPercentage = "AAA";

            Assert.Throws<ArgumentException>(() => orderService.CreateOrder(units, unitPrice, discountPercentage));
        }
    }
}
