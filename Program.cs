using Microsoft.Extensions.DependencyInjection;
using Portifolio.Classes;
using Portifolio.Interfaces;
using Portifolio.Services;
using System.Globalization;

CultureInfo idioma = new("en-US");

try
{
    IServiceCollection services = new ServiceCollection();
    ConfigureServices(services);
    var serviceProvider = services.BuildServiceProvider();

    var tradeServ = serviceProvider.GetService<ITradeServ>();

    DateTime dateReference;
    int numTrades;

    Console.WriteLine("----Credit Suisse – IT DEV RISK----");
    Console.WriteLine(string.Empty);
    Console.WriteLine("----Inputs----");

    Console.WriteLine("The reference date (mm/dd/yyyy): ");
    dateReference = Convert.ToDateTime(Console.ReadLine(), idioma);

    Console.WriteLine("The number of trades in the portfolio: ");
    numTrades = Convert.ToInt32(Console.ReadLine());

    string elements;
    List<string> lst = new();

    Console.WriteLine("Input Trade (Ex: 1000000 Public 09/15/2022 true) separated by a space: ");

    for (int i = 0; i < numTrades; i++)
    {
        elements = Console.ReadLine();

        Trade objTrade = new()
        {
            Value = Convert.ToDouble(elements.Split(' ')[0], idioma),
            ClientSector = elements.Split(' ')[1],
            NextPaymentDate = Convert.ToDateTime(elements.Split(' ')[2], idioma),
            IsPoliticallyExposed = Convert.ToBoolean(elements.Split(' ')[3])
        };

        lst.Add(tradeServ.CreateTrade(objTrade, dateReference));
    }

    Console.WriteLine(string.Empty);
    Console.WriteLine("----Output----");

    foreach (var item in lst)
    {
        Console.WriteLine(item);
        //TimeSpan interval = item.NextPaymentDate - dateReference;

        //if(item.IsPoliticallyExposed)
        //    Console.WriteLine(EnumCategory.PEP);

        //else if (interval.Days > LIMIT_EXPIRATION)
        //    Console.WriteLine(EnumCategory.EXPIRED);

        //else if (item.Value > Convert.ToDouble(LIMIT_VALUE, idioma) && item.ClientSector == PRIVATE_SECTOR)
        //    Console.WriteLine(EnumCategory.HIGHRISK);

        //else if (item.Value > Convert.ToDouble(LIMIT_VALUE, idioma) && item.ClientSector == PUPLIC_SECTOR)
        //    Console.WriteLine(EnumCategory.MEDIUMRISK);
        //else
        //    Console.WriteLine(NOT_CATEGORIZED);
    }

    Console.Write("END");
    Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

static void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ICategoryServ, CategoryService>();
    services.AddScoped<ITradeServ, TradeService>();
    services.AddScoped<ITradeCategoryServ, TradeCategoryService>();
}
