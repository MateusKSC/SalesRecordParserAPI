using FakeItEasy;
using Moq;
using SalesRecordParserApi.Services;

namespace SalesRecordParserAPI.Tests.Controllers
{
    public class SaleStatisticsControllerTests
    {
        public SaleStatisticsControllerTests()
        {
          var saleStatisticsService = A.Fake<SaleStatisticsService>();
        }

        [Fact]
        public void SaleStatisticsController_GetStatistics_ReturnOK()
        {

        }
    }
}