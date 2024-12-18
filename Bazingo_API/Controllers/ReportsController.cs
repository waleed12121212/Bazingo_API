using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        // Dummy report generation
        [HttpGet("GenerateDailyReport")]
        public IActionResult GenerateDailyReport( )
        {
            // Replace this with actual reporting logic
            var report = new
            {
                ReportName = "Daily Sales Report" ,
                Date = System.DateTime.Now ,
                TotalSales = 15000
            };

            return Ok(report);
        }

        // Fetch all reports (placeholder)
        [HttpGet]
        public IActionResult GetReports( )
        {
            return Ok("List of all reports goes here");
        }
    }

}
