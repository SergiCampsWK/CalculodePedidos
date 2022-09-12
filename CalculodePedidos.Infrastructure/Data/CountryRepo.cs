using System;
using System.Collections.Generic;
using CalculodePedidos.Domain;
using System.Text;
using System.Linq;

namespace CalculodePedidos.Infrastructure
{
    public class CountryRepo : ICountryRepo
    {
        public CountryRepo() { }

        List<Country> countries = new List<Country>()
                {
                    new Country("UT", 6.85),
                    new Country("NV", 8),
                    new Country("TX", 6.25),
                    new Country("AL", 4),
                    new Country("CA", 8.25)
                };

        public Country Get(string countryId)
        {
            return countries.Find(c => String.Equals(c.Id, countryId, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Country> GetAll()
        {
            return countries;
        }
    }
}
