using Microsoft.AspNetCore.Mvc;
using SalesRecordParserApi.Models;
using SalesRecordParserApi.Services;

namespace SalesRecordParserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleStatisticsController : ControllerBase
    {
        private SaleStatisticsService saleStatisticsService = new SaleStatisticsService();

        private readonly ILogger<SaleStatisticsController> _logger;

        public SaleStatisticsController(ILogger<SaleStatisticsController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "GetSaleStatistics")]
        public IActionResult GetMedianUnitCost()
        {
            return Ok(saleStatisticsService.GetSaleStatistics());
        }
        


    }
}
