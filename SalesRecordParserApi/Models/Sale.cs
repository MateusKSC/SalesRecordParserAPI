using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Vml;

namespace SalesRecordParserApi.Models
{
    public class Sale
    {
        public string Region { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string SalesChannel { get; set; }
        public string OrderPriority { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderID { get; set; }
        public DateTime ShipDate { get; set; }
        public int UnitsSold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalProfit { get; set; }

    }
    public class SaleBuilder
    {
        private string _region;
        private string _country;
        private string _type;
        private string _salesChannel;
        private string _orderPriority;
        private DateTime _orderDate;
        private int _orderID;
        private DateTime _shipDate;
        private int _unitsSold;
        private decimal _unitPrice;
        private decimal _unitCost;
        private decimal _totalRevenue;
        private decimal _totalCost;
        private decimal _totalProfit;

        public SaleBuilder WithRegion(string region)
        {
            _region = region;
            return this;
        }

        public SaleBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }

        public SaleBuilder WithType(string type)
        {
            _type = type;
            return this;
        }

        public SaleBuilder WithSalesChannel(string salesChannel)
        {
            _salesChannel = salesChannel;
            return this;
        }

        public SaleBuilder WithOrderPriority(string orderPriority)
        {
            _orderPriority = orderPriority;
            return this;
        }

        public SaleBuilder WithOrderDate(DateTime orderDate)
        {
            _orderDate = orderDate;
            return this;
        }

        public SaleBuilder WithOrderID(int orderID)
        {
            _orderID = orderID;
            return this;
        }

        public SaleBuilder WithShipDate(DateTime shipDate)
        {
            _shipDate = shipDate;
            return this;
        }

        public SaleBuilder WithUnitsSold(int unitsSold)
        {
            _unitsSold = unitsSold;
            return this;
        }

        public SaleBuilder WithUnitPrice(decimal unitPrice)
        {
            _unitPrice = unitPrice;
            return this;
        }

        public SaleBuilder WithUnitCost(decimal unitCost)
        {
            _unitCost = unitCost;
            return this;
        }

        public SaleBuilder WithTotalRevenue(decimal totalRevenue)
        {
            _totalRevenue = totalRevenue;
            return this;
        }

        public SaleBuilder WithTotalCost(decimal totalCost)
        {
            _totalCost = totalCost;
            return this;
        }

        public SaleBuilder WithTotalProfit(decimal totalProfit)
        {
            _totalProfit = totalProfit;
            return this;
        }

        public Sale Build()
        {
            return new Sale
            {
                Region = _region,
                Country = _country,
                Type = _type,
                SalesChannel = _salesChannel,
                OrderPriority = _orderPriority,
                OrderDate = _orderDate,
                OrderID = _orderID,
                ShipDate = _shipDate,
                UnitsSold = _unitsSold,
                UnitPrice = _unitPrice,
                UnitCost = _unitCost,
                TotalRevenue = _totalRevenue,
                TotalCost = _totalCost,
                TotalProfit = _totalProfit

            };
        }
    }
}