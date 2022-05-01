using AutoMapper;
using Restful.Shared.Helpers;
using Restful.Shared.IRepositories;
using Restful.Shared.Models;
using Restful.Shared.RequestModels;
using Restful.Shared.ResponseModels;
using System.Linq;

namespace Restful.Services.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PagedList<OrderResponse>> GetAllOrders(BaseRequest baseRequest)
        {
            if (baseRequest == null)
                throw new ArgumentNullException(nameof(baseRequest));

            var collection = await _orderRepository.GetAllOrderWithFiltering(baseRequest);

            return PagedList<OrderResponse>.Create(_mapper.Map<IEnumerable<OrderResponse>>(collection),
                   baseRequest.PageNumber,
                   baseRequest.PageSize);
        }
    }
}
