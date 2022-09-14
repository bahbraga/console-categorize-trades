using Portifolio.Classes;
using Portifolio.Interfaces;

namespace Portifolio.Services
{
    public class TradeService : ITradeServ
    {
        private readonly ITradeCategoryServ _tradeCategoryServ;

        public TradeService(ITradeCategoryServ tradeCategoryServ)
        {
            _tradeCategoryServ = tradeCategoryServ;
        }

        public string CreateTrade(Trade trade, DateTime dateReference) => _tradeCategoryServ.ClassifyTrade(trade, dateReference);
    }
}
