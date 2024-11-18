using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using ClosedXML.Excel;
using SalesRecordParserApi.Models;



namespace SalesRecordParserApi.Services
{
    public class SaleStatisticsService
    {
        public List<Sale> GetSalesInformation() {

            var sales = new List<Sale>();
            var workbook = new XLWorkbook("SalesRecords.xlsx");
            var worksheet = workbook.Worksheet("Worksheet");

            var firstRowUsed = worksheet.FirstRowUsed().RowNumber();
            var lastRowUsed = worksheet.LastRowUsed().RowNumber();

            for (int rowNum = firstRowUsed + 1; rowNum <= lastRowUsed; rowNum++)
            {
                var row = worksheet.Row(rowNum);

                var sale = new SaleBuilder()
                    .WithRegion(row.Cell(1).Value.ToString())
                    .WithCountry(row.Cell(2).Value.ToString())
                    .WithType(row.Cell(3).Value.ToString())
                    .WithSalesChannel(row.Cell(4).Value.ToString())
                    .WithOrderPriority(row.Cell(5).Value.ToString())
                    .WithOrderDate(DateTime.Parse(row.Cell(6).Value.ToString()))
                    .WithOrderID(int.Parse(row.Cell(7).Value.ToString()))
                    .WithShipDate(DateTime.Parse(row.Cell(8).Value.ToString()))
                    .WithUnitsSold(int.Parse(row.Cell(9).Value.ToString()))
                    .WithUnitPrice(decimal.Parse(row.Cell(10).Value.ToString()))
                    .WithUnitCost(decimal.Parse(row.Cell(11).Value.ToString()))
                    .WithTotalRevenue(decimal.Parse(row.Cell(12).Value.ToString()))
                    .WithTotalCost(decimal.Parse(row.Cell(13).Value.ToString()))
                    .WithTotalProfit(decimal.Parse(row.Cell(14).Value.ToString()))

                    .Build();
                sales.Add(sale);
            }
            return sales;
        }
        public decimal GetMedianUnitCost()
        {
            int middleNumber, unitCostQuantity = 0;
            decimal median;

            List<Sale> sales = GetSalesInformation();

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
        public string GetMostCommonRegion()
        {
            List<Sale> sales = GetSalesInformation();
            List<string> regions = new List<string>();

            foreach (Sale sale in sales)
            {
                regions.Add(sale.Region);
            }

            var groupedStrings = regions.GroupBy(s => s);
            var mostCommon = groupedStrings.OrderByDescending(g => g.Count()).First();

            return mostCommon.Key;
        }
        public SaleStatistics GetDateInfo(SaleStatistics saleStatistics)
        {
            int daysDifference = 0;
            List<Sale> sales = GetSalesInformation();
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
        public decimal GetTotalRevenue()
        {
            List<Sale> sales = GetSalesInformation();
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
            saleStatistics.MedianUnitCost = GetMedianUnitCost();
            saleStatistics.MostCommonRegion = GetMostCommonRegion();
            saleStatistics.TotalRevenue = GetTotalRevenue();
            saleStatistics = GetDateInfo(saleStatistics);
            return saleStatistics;
        }
    }
}
