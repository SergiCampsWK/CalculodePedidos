using System.Collections.Generic;

namespace CalculodePedidos.Domain
{
    public interface ICountryRepo
    {
        IEnumerable<Country> GetAll();
        Country Get(string countryId);
    }
}