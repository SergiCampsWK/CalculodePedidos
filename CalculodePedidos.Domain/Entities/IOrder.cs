using System;

namespace CalculodePedidos.Domain
{
    internal interface IOrder
    {
        int Units { get; }
        double UnitPrice { get;}
        double DiscountPercentage { get; }
        Country Country { get; }
        double TotalDiscount { get; }
        double TotalBase { get; }

        void SetCountry(Country country);
        public double CalculateTotalTax();
        public double CalculateTotalPrice();
    }
}