namespace InsuranceCalculator.Api.Controllers
{
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet("/api/pings/pong")]
        public IActionResult Pong() => Ok(new { PongAt = DateTime.Now });
    }
}
