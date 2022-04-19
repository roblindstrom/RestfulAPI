using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.Models
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public Guid OrderId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public Order? Order { get; set; }
        public List<LineItem>? LineItems { get; set; }


    }
}
