using Microsoft.AspNetCore.Mvc;
using SalesRecordParserApi.Services;

namespace SalesRecordParserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleStatisticsController : ControllerBase
    {
        SaleStatisticsService saleStatisticsService = new SaleStatisticsServiceImpl();

        [HttpGet(Name = "GetSaleStatistics")]
        public IActionResult GetSaleStatistics()
        {
            return Ok(saleStatisticsService.GetSaleStatistics());
        }
        


    }
}
