using System;
using Xunit;

namespace CalculodePedidos.Test
{
    public class OrderTests
    {
        [Fact]
        public void CalculateTotalTax_ValidUnitsAndUnitPrice_ReturnCalculatedTotalBase()
        {
            var units = 100;
            var unitPrice = 2;
                
            //var resultado = CalculodePedidos.CalculateTotalBase(units, unitPrice);

        }

        [Fact]
        public void CalculateTotalBase_InvalidUnits_ThrowsException()
        {


        }

        [Fact]
        public void CalculateTotalBase_InvalidUnitPrice_ThrowsException()
        {


        }

    }
}
