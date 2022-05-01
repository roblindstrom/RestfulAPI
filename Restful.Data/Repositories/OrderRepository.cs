using Restful.Shared.Helpers;
using Restful.Shared.IRepositories;
using Restful.Shared.Models;
using Restful.Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Data.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        protected new readonly RestfulDbContext _restfulDbContext;
        public OrderRepository(RestfulDbContext myDbContext) : base(myDbContext)
        {
            _restfulDbContext = myDbContext;
        }

        public async Task<IQueryable<Order>> GetAllOrderWithFiltering(BaseRequest baseRequest)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await Task.Run( () => 
            {
                var collection = _restfulDbContext.Orders as IQueryable<Order>;

                
                if (!string.IsNullOrWhiteSpace(baseRequest.SearchQuery))
                {
                    var searchQuery = baseRequest.SearchQuery.Trim();
                    collection = collection.Where(a => a.CustomerName.Contains(searchQuery)
                        || a.CustomerName.Contains(searchQuery)
                        || a.OrderNo.ToString().Contains(searchQuery));
                        
                }

                collection = collection.ApplySort(baseRequest.OrderBy);


                return collection;
            });
#pragma warning restore CS8603 // Possible null reference return.

        }
    }
}
