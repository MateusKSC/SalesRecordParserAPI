namespace SalesRecordParserApi.Models
{
    public class SaleStatistics
    {
        public decimal MedianUnitCost { get; set; }
        public string MostCommonRegion { get; set; }
        public DateTime FirstOrderDate { get; set; }
        public DateTime LastOrderDate { get; set; }
        public int DaysBetweenDates { get; set; }
        public decimal TotalRevenue { get; set; }

    }
}
