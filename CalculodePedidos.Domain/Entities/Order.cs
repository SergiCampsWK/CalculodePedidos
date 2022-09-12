using System;
using System.Collections.Generic;
using System.Text;
using CalculodePedidos.SharedKernel;
using L = CalculodePedidos.SharedKernel.CalculodePedidos_Resources;

namespace CalculodePedidos.Domain
{
    public class Order : IOrder
    {
        public int Units { get; private set; }
        public double UnitPrice { get; private set; }
        public double DiscountPercentage { get; private set; }
        public Country Country { get; private set; }
        public double TotalDiscount { get; private set; }
        public double TotalBase { get; private set; }

        public Order(string units, string unitPrice, string discountPercentage)
        {
            if (string.IsNullOrWhiteSpace(units)) throw new ArgumentException(L.UnidadesNoInformadas, nameof(units));
            if (string.IsNullOrWhiteSpace(unitPrice)) throw new ArgumentException(L.PrecioUnidadNoInformado, nameof(unitPrice));
            if (string.IsNullOrWhiteSpace(discountPercentage)) throw new ArgumentException("Es obligatorio informar el porcentaje de descuento.", nameof(discountPercentage));

            Units = int.TryParse(unitPrice, out int unidades) == true ? unidades : throw new ArgumentException("El valor para las unidades no es válido.", nameof(units));
            UnitPrice = Double.TryParse(units, out double precio) == true ? precio : throw new ArgumentException("El valor para el precio no es váldo.", nameof(units));
            DiscountPercentage = Double.TryParse(discountPercentage, out double percentage) == true ? percentage : throw new ArgumentException("El valor para el descuento no es válido.", nameof(discountPercentage));

            TotalBase = Units * UnitPrice;
            TotalDiscount = DiscountPercentage * TotalBase / 100;
        }

        public void SetCountry(Country country)
        {
            if (country is null) throw new ArgumentNullException(nameof(country));

            Country = country;
        }

        public double CalculateTotalTax()
        {
            if (Country is null) throw new InvalidOperationException("No se ha informado el pais del pedido.");
            return Country.Tax * TotalBase / 100;
        }

        public double CalculateTotalPrice()
        {
            return TotalBase - TotalDiscount + CalculateTotalTax();
        }
    }
}
