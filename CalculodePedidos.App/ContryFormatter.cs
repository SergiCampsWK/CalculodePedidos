using CalculodePedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L = CalculodePedidos.SharedKernel.CalculodePedidos_Resources;

namespace CalculodePedidos.App
{
    public static class CountryFormatter
    {
        public static string Format(Country country) => $"{L.Pais} : {country.Id} {L.Impuesto} : {country.Tax}";
    }
}
