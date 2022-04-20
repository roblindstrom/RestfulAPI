using Restful.Shared.IRepositories;
using Restful.Shared.Models;
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
    }
}
