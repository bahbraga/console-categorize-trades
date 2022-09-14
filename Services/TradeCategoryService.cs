using Portifolio.Classes;
using Portifolio.Enums;
using Portifolio.Interfaces;

namespace Portifolio.Services
{
    public class TradeCategoryService : ITradeCategoryServ
    {
        private readonly ICategoryServ _categoryServ; 
        const string NOT_CATEGORIZED = "Not categorized";

        public TradeCategoryService(ICategoryServ categoryServ)
        {
            _categoryServ = categoryServ;
        }

        public string ClassifyTrade(Trade trade, DateTime referenceDate)
        {
            if (_categoryServ.IsPoliticallyExposedPerson(trade.IsPoliticallyExposed))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.PEP);

            if (_categoryServ.EXPIRED(referenceDate, trade.NextPaymentDate))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.EXPIRED);

            if (_categoryServ.HIGHRISK(trade.Value, trade.ClientSector))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.HIGHRISK);

            if (_categoryServ.MEDIUMRISK(trade.Value, trade.ClientSector))
                return Enum.GetName(typeof(EnumCategory), EnumCategory.MEDIUMRISK);

            return NOT_CATEGORIZED;
        }
    }
}
