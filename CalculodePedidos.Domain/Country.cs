using System;
using System.Collections.Generic;
using System.Text;

namespace CalculodePedidos.Domain
{
    public class Country
    {
        public string Id { get; private set; }
        public double Tax { get; private set; }

        public Country(string id, double tax)
        {
            Id = id; 
            Tax = tax; 
        }
    }
}
