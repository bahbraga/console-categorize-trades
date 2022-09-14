using Portifolio.Classes;

namespace Portifolio.Interfaces
{
    public interface ITradeService
    {
        string CreateTrade(Trade trade, DateTime dateReference);
    }
}
