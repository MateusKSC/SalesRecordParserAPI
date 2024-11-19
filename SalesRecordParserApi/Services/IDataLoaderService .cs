using SalesRecordParserApi.Models;

namespace SalesRecordParserApi.Services
{
    public interface IDataLoaderService
    {
        List<Sale> GetSalesInformation();
    }
}
