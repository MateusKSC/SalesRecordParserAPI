using Microsoft.AspNetCore.Mvc;
using SalesRecordParserApi.Services;

namespace SalesRecordParserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleStatisticsController : ControllerBase
    {
        ISaleStatisticsService saleStatisticsService = new SaleStatisticsService();

        [HttpGet(Name = "GetSaleStatistics")]
        public IActionResult GetSaleStatistics()
        {
            return Ok(saleStatisticsService.GetSaleStatistics());
        }
    }
}
