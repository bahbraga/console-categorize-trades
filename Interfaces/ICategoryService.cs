namespace Portifolio.Interfaces
{
    public interface ICategoryService
    {
        bool EXPIRED(DateTime referenceDate, DateTime nextPaymentDate);

        bool HIGHRISK(double value, string clientSector);

        bool MEDIUMRISK(double value, string clientSector);

        bool IsPoliticallyExposedPerson(bool isPoliticallyExposed);
    }
}
