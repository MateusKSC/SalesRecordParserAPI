using SalesRecordParserApi.Models;
using SalesRecordParserApi.Services;

namespace SalesRecordParserAPI.Tests.Unit.Services
{
    public class SaleStatisticsIntegrationTests
    {
        [Fact]
        public void SaleStatisticsService_GetSalesInformation_ReturnListOfSales()
        {
            DataLoaderService dataLoaderService = new DataLoaderService();

            var result = dataLoaderService.GetSalesInformation();

            Assert.IsType<List<Sale>>(result);
        }
    }
}