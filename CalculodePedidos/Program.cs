 using System;
using System.Collections.Generic;
using L = CalculodePedidos.CalculodePedidos_Resources;

namespace CalculodePedidos
{
    internal class Program
    {        
        protected static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;

            Console.WriteLine(L.IntroduzcaUnidades);
            var units = Console.ReadLine();

            Console.WriteLine(L.IntroduzcaPrecioUnidad);
            var unitPrice = Console.ReadLine();

            var totalBase = Double.Parse(unitPrice) * Double.Parse(units);


            Console.WriteLine(L.IntroduzcaPorcentajeDto);
            var percentatgeDiscount = Console.ReadLine();
            var totalDiscount = Double.Parse(percentatgeDiscount) * totalBase / 100;

            Console.WriteLine(L.ElDescuentoAplicadoEs);
            Console.WriteLine(totalDiscount);

            Dictionary<string, Double > countries = new Dictionary<string, Double>()
                {
                    { "UT",  6.85},
                    { "NV",  8},
                    { "TX",  6.25},
                    { "AL",  4},
                    { "CA", 8.25}
            };

            Console.WriteLine(L.ListadoPaises);
            foreach (KeyValuePair<string, Double > country in countries) {                
                Console.WriteLine( "Pais: " + country.Key + " Impuesto:" + country.Value);
            }

            Console.WriteLine(L.IntroduzcaPais);
            var paisImpuesto = Console.ReadLine();
            var totalImpuesto = countries[paisImpuesto] * totalBase / 100;

            Console.WriteLine(L.ElImpuestoAplicadoEs + totalImpuesto);

            Console.WriteLine(L.PrecioTotal);
            Console.WriteLine(totalBase - totalDiscount + totalImpuesto);
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(L.ErrorInesperado);
            Console.ReadLine();
            Environment.Exit(1);

        }
    }
}



