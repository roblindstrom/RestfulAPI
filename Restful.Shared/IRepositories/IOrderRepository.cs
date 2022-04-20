using Restful.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.IRepositories
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}
