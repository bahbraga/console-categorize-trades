using Portifolio.Classes;

namespace Portifolio.Interfaces
{
    public interface ITradeCategoryService
    {
        string ClassifyTrade(Trade trade, DateTime referenceDate);
    }
}
