using System;
using CalculodePedidos.App;
using CalculodePedidos.Domain;
using CalculodePedidos.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using L = CalculodePedidos.SharedKernel.CalculodePedidos_Resources;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddScoped<IOrderAppSrv, OrderAppSrv>()
                .AddScoped<ICountryRepo, CountryRepo>())
    .Build();

CalculodePedidos(host.Services);


static void CalculodePedidos(IServiceProvider services)
{
    AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;
    var orderService = services.GetRequiredService<IOrderAppSrv>();

    Console.WriteLine(L.IntroduzcaUnidades);
    var units = Console.ReadLine(); 

    Console.WriteLine(L.IntroduzcaPrecioUnidad);
    var unitPrice = Console.ReadLine();

    Console.WriteLine(L.IntroduzcaPorcentajeDto);
    var discountPercentage = Console.ReadLine();
    
    var order = orderService.CreateOrder(units, unitPrice, discountPercentage);

    Console.WriteLine(L.ElDescuentoAplicadoEs + Environment.NewLine + order.TotalDiscount);

    Console.WriteLine(L.ListadoPaises);
    Console.WriteLine(orderService.GetCountriesInfo());

    Console.WriteLine(L.IntroduzcaPais);
    var countryId = Console.ReadLine();
    orderService.SetCountry(order, countryId);

    Console.WriteLine(L.ElImpuestoAplicadoEs + Environment.NewLine + order.CalculateTotalTax());

    Console.WriteLine(L.PrecioTotal);
    var TotalPrice = order.CalculateTotalPrice();
    Console.WriteLine(TotalPrice);
}

static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs e)
{
    Console.WriteLine(L.ErrorInesperado);
    Console.ReadLine();
    Environment.Exit(1);

}



