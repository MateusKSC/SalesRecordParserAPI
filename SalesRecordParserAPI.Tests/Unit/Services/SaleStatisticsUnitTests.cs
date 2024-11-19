using SalesRecordParserApi.Models;
using SalesRecordParserApi.Services;

namespace SalesRecordParserAPI.Tests.Unit.Services
{
    public class SaleStatisticsUnitTests
    {

        [Fact]
        public void SaleStatisticsService_GetMedianUnitCost_ReturnListOfSales()
        {
            SaleStatisticsService saleStatisticsService = new SaleStatisticsService();
            List<Sale> sales = new List<Sale>();
            Sale sale = new Sale();
            sales.Add(sale);

            var result = saleStatisticsService.GetMedianUnitCost(sales);

            Assert.IsType<decimal>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetTotalRevenue_ReturnListOfSales()
        {
            SaleStatisticsService saleStatisticsService = new SaleStatisticsService();
            List<Sale> sales = new List<Sale>();
            Sale sale = new Sale();
            sales.Add(sale);

            var result = saleStatisticsService.GetTotalRevenue(sales);

            Assert.IsType<decimal>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetMostCommonRegion_ReturnListOfSales()
        {
            SaleStatisticsService saleStatisticsService = new SaleStatisticsService();
            List<Sale> sales = new List<Sale>();
            Sale sale = new Sale();
            sale.Region = "Europe";
            sales.Add(sale);

            var result = saleStatisticsService.GetMostCommonRegion(sales);

            Assert.IsType<string>(result);
        }

        [Fact]
        public void SaleStatisticsService_GetDateInfo_ReturnValidDateInfo()
        {
            SaleStatisticsService saleStatisticsService = new SaleStatisticsService();
            SaleStatistics saleStatistics = new SaleStatistics();
            List<Sale> sales = new List<Sale>();
            Sale sale = new Sale();
            sales.Add(sale);

            saleStatistics = saleStatisticsService.GetDateInfo(sales, saleStatistics);
            DateTime firstDate = saleStatistics.FirstOrderDate;
            DateTime lastdate = saleStatistics.LastOrderDate;
            DateTime calculatedDate = firstDate.AddDays(saleStatistics.DaysBetweenDates);

            Assert.Equal(lastdate, firstDate);
        }
    }
}