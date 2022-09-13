using Portifolio.Classes;
using Portifolio.Enums;
using System.Globalization;

CultureInfo idioma = new("en-US");
const double LIMIT_VALUE = 1000000D;
const int LIMIT_EXPIRATION = 30;
const string PRIVATE_SECTOR = "Private";
const string PUPLIC_SECTOR= "Public";
const string NOT_CATEGORIZED = "Not categorized";

try
{
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
    List<Trade> lst = new();

    Console.WriteLine("Input Trade (Ex: 1000000 Public 09/15/2022 true) separated by a space: ");

    for (int i = 0; i < numTrades; i++)
    {
        elements = Console.ReadLine();

        string[] arrElements = elements.Split(' ');

        Trade objTrade = new()
        {
            Value = Convert.ToDouble(arrElements[0], idioma),
            ClientSector = arrElements[1],
            NextPaymentDate = Convert.ToDateTime(arrElements[2], idioma),
            IsPoliticallyExposed = Convert.ToBoolean(arrElements[3])
        };

        lst.Add(objTrade);
    }

    Console.WriteLine(string.Empty);
    Console.WriteLine("----Output----");

    foreach (var item in lst)
    {
        TimeSpan interval = item.NextPaymentDate - dateReference;

        if(item.IsPoliticallyExposed)
            Console.WriteLine(EnumCategory.PEP);

        else if (interval.Days > LIMIT_EXPIRATION)
            Console.WriteLine(EnumCategory.EXPIRED);

        else if (item.Value > Convert.ToDouble(LIMIT_VALUE, idioma) && item.ClientSector == PRIVATE_SECTOR)
            Console.WriteLine(EnumCategory.HIGHRISK);

        else if (item.Value > Convert.ToDouble(LIMIT_VALUE, idioma) && item.ClientSector == PUPLIC_SECTOR)
            Console.WriteLine(EnumCategory.MEDIUMRISK);
        else
            Console.WriteLine(NOT_CATEGORIZED);
    }

    Console.Write("END");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.ReadKey();
