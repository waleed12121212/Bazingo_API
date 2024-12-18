using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bazingo_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        // Simple health check
        [HttpGet]
        public IActionResult Get( )
        {
            return Ok(new { Status = "Healthy" , DateTime = System.DateTime.Now });
        }
    }
}
