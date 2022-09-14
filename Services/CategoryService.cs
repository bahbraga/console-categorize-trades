using Portifolio.Interfaces;

namespace Portifolio.Services
{
    public class CategoryService : ICategoryServ
    {
        const double LIMIT_VALUE = 1000000D;
        const int LIMIT_EXPIRATION = 30;
        const string PRIVATE_SECTOR = "Private";
        const string PUPLIC_SECTOR = "Public";

        public bool EXPIRED(DateTime dateReference, DateTime nextPaymentDate)
        {
            TimeSpan interval = nextPaymentDate - dateReference;
            return interval.Days > LIMIT_EXPIRATION; 
        }

        public bool HIGHRISK(double value, string clientSector) => (value > LIMIT_VALUE && clientSector == PRIVATE_SECTOR) ? true : false;

        public bool MEDIUMRISK(double value, string clientSector) => (value > LIMIT_VALUE && clientSector == PUPLIC_SECTOR) ? true : false;

        public bool IsPoliticallyExposedPerson(bool isPoliticallyExposed) => isPoliticallyExposed;
    }
}
