using CalculodePedidos.Domain;
using System;
using System.Linq;
using Serilog;

namespace CalculodePedidos.App
{
    public class OrderAppSrv : IOrderAppSrv
    {
        private ILogger log = new LoggerConfiguration().MinimumLevel.Debug().CreateLogger();
        private readonly ICountryRepo _countryRepo;

        public OrderAppSrv(ICountryRepo countryRepo) => _countryRepo = countryRepo;

        public Order CreateOrder(string units, string unitPrice, string discountPercentage)
        {
            if (string.IsNullOrWhiteSpace(units)) throw new ArgumentException($"\"{nameof(units)}\" no puede ser NULL ni un espacio en blanco.", nameof(units));
            if (string.IsNullOrWhiteSpace(unitPrice)) throw new ArgumentException($"\"{nameof(unitPrice)}\" no puede ser NULL ni un espacio en blanco.", nameof(unitPrice));
            if (string.IsNullOrWhiteSpace(discountPercentage)) throw new ArgumentException($"\"{nameof(discountPercentage)}\" no puede ser NULL ni un espacio en blanco.", nameof(discountPercentage));

            try
            {
                return new Order(units, unitPrice, discountPercentage);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Ha ocurrido un error creando el pedido. Unidades : {0}, Precio : {1}", units, unitPrice);
                return null;
            }

        }

        public string GetCountriesInfo() => _countryRepo.GetAll().Select(c => CountryFormatter.Format(c))
                                                                 .Aggregate((a, b) => a + Environment.NewLine + b);

        public void SetCountry(Order order, string countryId)
        {
            var country = _countryRepo.Get(countryId);
            order.SetCountry(country);
        }
    }
}
