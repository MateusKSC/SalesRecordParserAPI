using Microsoft.AspNetCore.Mvc;
using SalesRecordParserApi.Services;

namespace SalesRecordParserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleStatisticsController : ControllerBase
    {
        private readonly ISaleStatisticsService _saleStatisticsService;

        public SaleStatisticsController(ISaleStatisticsService saleStatisticsService)
        {
            _saleStatisticsService = saleStatisticsService;
        }

        [HttpGet(Name = "GetSaleStatistics")]
        public IActionResult GetSaleStatistics()
        {
            return Ok(_saleStatisticsService.GetSaleStatistics());
        }
    }
}
