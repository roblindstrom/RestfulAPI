using Microsoft.AspNetCore.Mvc;
using Restful.Services.Services.Seeds;

namespace Restful.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/seed")]
    public class SeedController : ControllerBase
    {
                private readonly ISeedService _seedService;
                public SeedController(ISeedService seedService)
                {
                  _seedService = seedService ?? throw new ArgumentNullException(nameof(seedService));
                }

        [HttpPost]
        public async Task<ActionResult> SeedDatabase()
        {
            await _seedService.SeedDatabase();
            return Ok();
        }
    }
}
