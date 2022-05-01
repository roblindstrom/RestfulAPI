using Microsoft.AspNetCore.Mvc;
using Restful.Services.Services.MetaData;
using Restful.Services.Services.Orders;
using Restful.Services.Services.Seeds;
using Restful.Shared.Helpers;
using Restful.Shared.Models;
using Restful.Shared.RequestModels;
using Restful.Shared.ResponseModels;
using System.Text.Json;

namespace Restful.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ISeedService _seedService;
        private readonly IOrderService _orderService;
        private readonly IMetaDataService<OrderResponse> _metaDataService;

        public OrderController(ISeedService seedService, IOrderService orderService, IMetaDataService<OrderResponse> metaDataService)
        {
            _seedService = seedService ?? throw new ArgumentNullException(nameof(seedService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _metaDataService = metaDataService ?? throw new ArgumentNullException(nameof(metaDataService));
        }

        [HttpPost]
        public async Task<IActionResult> SeedDatabase()
        {
            await _seedService.SeedDatabase();
            return Ok();
        }

        [HttpGet(Name = "GetOrders")]
        [HttpHead]
        public async Task<IActionResult> GetOrders([FromQuery] BaseRequest baseRequest)
        {

            if (!_metaDataService.CheckIfPropertyExistsInObject(new OrderResponse(), baseRequest.OrderBy))
                return BadRequest($"Can't find OrderBy property: {baseRequest.OrderBy}");

            if (!_metaDataService.CheckIfPropertyExistsInObject(new OrderResponse(), baseRequest.Fields))
                return BadRequest($"Can't find Fields property: {baseRequest.Fields}");

            var ordersFromRepo =  await _orderService.GetAllOrders(baseRequest);
            _metaDataService.AddPaginationMetaData(ordersFromRepo, Response, baseRequest);

            return Ok(ordersFromRepo.ShapeData(baseRequest.Fields));
        }

        

    }
}
