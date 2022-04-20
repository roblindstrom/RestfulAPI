using Microsoft.AspNetCore.Mvc;
using Restful.Services.Services.Seeds;

namespace Restful.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public OrderController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        [HttpPost]
        public async Task<IActionResult> SeedDatabase()
        {
            await _seedService.SeedDatabase();
            return Ok();
        }
    }
}
