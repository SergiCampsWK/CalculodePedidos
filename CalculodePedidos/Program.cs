using System;
using System.Collections.Generic;

namespace CalculodePedidos
{
    internal class Program
    {        
        protected static void Main(string[] args)
        {
            Console.WriteLine("Introduzca la cantidad de unidades");
            var units = Console.ReadLine();
            Console.WriteLine("Introduzca el precio por unidad");
            var unitPrice = Console.ReadLine();
            var totalBase = Double.Parse(unitPrice) * Double.Parse(units);


            Console.WriteLine("Introduzca el porcentage de descuento a aplicar en base 100");
            var percentatgeDiscount = Console.ReadLine();
            var totalDiscount = Double.Parse(percentatgeDiscount) * totalBase / 100;
            Console.WriteLine("El descuento aplicado es:");
            Console.WriteLine(totalDiscount);


            Dictionary<string, Double > countries = new Dictionary<string, Double>()
                {
                    { "UT",  6.85},
                    { "NV",  8},
                    { "TX",  6.25},
                    { "AL",  4},
                    { "CA", 8.25}
            };

            Console.WriteLine("Seleccione un pais a aplicar el impuesto:");
            foreach (KeyValuePair<string, Double > country in countries) {                
                Console.WriteLine( "Pais: " + country.Key + " Impuesto:" + country.Value);
            }

            Console.WriteLine("Introduzca el porcentage de impuesto a aplicar en base 100");
            var paisImpuesto = Console.ReadLine();
            var totalImpuesto = countries[paisImpuesto] * totalBase / 100;
            Console.WriteLine("El impuesto aplicado es:");
            Console.WriteLine(totalImpuesto);


            Console.WriteLine("Precio total");
            Console.WriteLine(totalBase - totalDiscount + totalImpuesto);
        }
    }
}



