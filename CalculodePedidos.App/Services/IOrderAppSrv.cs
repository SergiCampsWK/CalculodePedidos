using CalculodePedidos.Domain;

namespace CalculodePedidos.App
{
    public interface IOrderAppSrv
    {
        Order CreateOrder(string units, string unitPrice, string discountPercentage);
        public string GetCountriesInfo();
        public void SetCountry(Order order, string countryId);
    }
}