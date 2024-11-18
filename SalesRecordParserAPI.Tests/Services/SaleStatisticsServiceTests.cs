using SalesRecordParserApi.Controllers;
using SalesRecordParserApi.Models;
using SalesRecordParserApi.Services;
using Xunit.Sdk;

namespace SalesRecordParserAPI.Tests.Controllers
{
    public class SaleStatisticsServiceTests
    {
        [Fact]
        public void SaleStatisticsService_GetSalesInformation_ReturnListOfSales()
        {
            SaleStatisticsServiceImpl saleStatisticsServiceImpl = new SaleStatisticsServiceImpl();

            var result = saleStatisticsServiceImpl.GetSalesInformation();

            Assert.IsType <List<Sale>>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetMedianUnitCost_ReturnListOfSales()
        {
            SaleStatisticsServiceImpl saleStatisticsServiceImpl = new SaleStatisticsServiceImpl();

            var result = saleStatisticsServiceImpl.GetMedianUnitCost();

            Assert.IsType<Decimal>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetTotalRevenue_ReturnListOfSales()
        {
            SaleStatisticsServiceImpl saleStatisticsServiceImpl = new SaleStatisticsServiceImpl();

            var result = saleStatisticsServiceImpl.GetTotalRevenue();

            Assert.IsType<Decimal>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetMostCommonRegion_ReturnListOfSales()
        {
            SaleStatisticsServiceImpl saleStatisticsServiceImpl = new SaleStatisticsServiceImpl();

            var result = saleStatisticsServiceImpl.GetMostCommonRegion();

            Assert.IsType<String>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetDateInfo_ReturnValidDateInfo()
        {
            SaleStatisticsServiceImpl saleStatisticsServiceImpl = new SaleStatisticsServiceImpl();
            SaleStatistics saleStatistics = new SaleStatistics();
            saleStatistics = saleStatisticsServiceImpl.GetDateInfo(saleStatistics);
            DateTime firstDate = saleStatistics.FirstOrderDate;
            DateTime Lastdate = saleStatistics.LastOrderDate;
            DateTime calculatedDate = firstDate.AddDays(saleStatistics.DaysBetweenDates);
            Assert.Equal(Lastdate, calculatedDate);
        }
    }
}