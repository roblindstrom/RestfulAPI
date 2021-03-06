using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int OrderNo { get; set; }
        public Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public List<Package>? Packages { get; set; }
    }
}
