using Restful.Shared.Helpers;
using Restful.Shared.RequestModels;
using Restful.Shared.ResponseModels;

namespace Restful.Services.Services.Orders
{
    public interface IOrderService
    {
        Task<PagedList<OrderResponse>> GetAllOrders(BaseRequest baseRequest);
    }
}
