using System;
using CalculodePedidos.Infrastructure;
using L = CalculodePedidos.CalculodePedidos_Resources;
using FluentValidation;
using FluentValidation.Validators;

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
            double totalBase = CalculateTotalBase(units, unitPrice);

            Console.WriteLine(L.IntroduzcaPorcentajeDto);
            var percentatgeDiscount = Console.ReadLine();
            var totalDiscount = Double.Parse(percentatgeDiscount) * totalBase / 100;
            Console.WriteLine(L.ElDescuentoAplicadoEs);
            Console.WriteLine(totalDiscount);

            Console.WriteLine(L.ListadoPaises);
            var countryRepo = new CountryRepo();
            Console.WriteLine(countryRepo.GetCountriesInfo());

            Console.WriteLine(L.IntroduzcaPais);
            //var countryId = Console.ReadLine();
            var totalTax = CalculateTotalTax(Console.ReadLine(), totalBase);


            Console.WriteLine(L.ElImpuestoAplicadoEs + totalTax);

            Console.WriteLine(L.PrecioTotal);
            Console.WriteLine(totalBase - totalDiscount + totalTax);
        }

        private static double CalculateTotalBase(string units, string unitPrice)
        {
            if (string.IsNullOrWhiteSpace(units)) throw new ArgumentException(L.UnidadesNoInformadas, nameof(units));
            if (string.IsNullOrWhiteSpace(unitPrice)) throw new ArgumentException(L.PrecioUnidadNoInformado, nameof(unitPrice));

            bool IsSafeToCalculate = (Double.TryParse(unitPrice, out double precio) & Double.TryParse(units, out double unidades));

            if (!IsSafeToCalculate) throw new FormatException("Las unidades o el precio por unidad no son correctos.");
            if (unidades <= 0) throw new ArgumentException(L.UnidadesNoPuedenSerCero, nameof(units));
            if (precio <= 0) throw new ArgumentException(L.PrecioUnidadNoPuedeSerCero, nameof(unitPrice));

            return unidades * precio;
        }

        private static Double CalculateTotalTax(string countryId, double totalBase)
        {
            if (string.IsNullOrWhiteSpace(countryId)) throw new ArgumentException(L.CodigoPaisNoInformado, nameof(countryId));
            if (totalBase <= 0) throw new ArgumentException(L.BaseNoPuedeSerCero, nameof(totalBase));

            var country = new CountryRepo().GetCountry(countryId);

            return country.Tax * totalBase / 100;
        }

        private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(L.ErrorInesperado);
            Console.ReadLine();
            Environment.Exit(1);

        }
    }
}



