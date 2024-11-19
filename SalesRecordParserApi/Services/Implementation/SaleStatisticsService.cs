using SalesRecordParserApi.Models;



namespace SalesRecordParserApi.Services
{
    public class SaleStatisticsService : ISaleStatisticsService
    {
        private readonly IDataLoaderService _dataLoaderService;

        public SaleStatisticsService(IDataLoaderService dataLoaderService)
        {
            _dataLoaderService = dataLoaderService;
        }

        public decimal GetMedianUnitCost(List<Sale> sales)
        {
            int middleNumber, unitCostQuantity = 0;
            decimal median;

            List<decimal> unitCostValues = new List<decimal>();

            foreach (Sale sale in sales)
            {
                unitCostValues.Add(sale.UnitCost);
            }

            unitCostValues.Sort();
            unitCostQuantity = unitCostValues.Count();
            middleNumber = unitCostQuantity / 2;

            // Calculate the median value...
            if (unitCostQuantity % 2 == 0)
            {
                //...for an even number of values
                median = (unitCostValues[middleNumber - 1] + unitCostValues[middleNumber]) / 2;
            }
            else
            {
                //...for an odd number of values
                median = unitCostValues[middleNumber];
            }
            return median;
        }

        public string GetMostCommonRegion(List<Sale> sales)
        {
            List<string> regions = new List<string>();

            foreach (Sale sale in sales)
            {
                regions.Add(sale.Region);
            }

            var groupedStrings = regions.GroupBy(s => s);
            var mostCommon = groupedStrings.OrderByDescending(g => g.Count()).First();

            return mostCommon.Key;
        }

        public SaleStatistics GetDateInfo(List<Sale> sales, SaleStatistics saleStatistics)
        {
            int daysDifference = 0;
            List<DateTime> dates = new List<DateTime>();

            foreach (Sale sale in sales)
            {
                dates.Add(sale.OrderDate);
            }
            // Order the dates from oldest to most recent
            dates.Sort();

            daysDifference = (dates.Last() - dates.First()).Days;
            saleStatistics.FirstOrderDate = dates.First();
            saleStatistics.LastOrderDate = dates.Last();
            saleStatistics.DaysBetweenDates = daysDifference;
            return saleStatistics;
        }
        public decimal GetTotalRevenue(List<Sale> sales)
        {
            decimal totalRevenue = 0;

            foreach (Sale sale in sales)
            {
                totalRevenue += sale.TotalRevenue;
            }

            return totalRevenue;
        }
        
         public SaleStatistics GetSaleStatistics()
        {
            SaleStatistics saleStatistics = new SaleStatistics();
            List<Sale> sales = _dataLoaderService.GetSalesInformation();
            saleStatistics.MedianUnitCost = GetMedianUnitCost(sales);
            saleStatistics.MostCommonRegion = GetMostCommonRegion(sales);
            saleStatistics.TotalRevenue = GetTotalRevenue(sales);
            saleStatistics = GetDateInfo(sales,saleStatistics);
            return saleStatistics;
        }
    }
}
