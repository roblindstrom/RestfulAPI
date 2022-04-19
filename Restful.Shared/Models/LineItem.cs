using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.Models
{
    public class LineItem
    {
        public Guid LineItemId { get; set; }
        public Guid ItemId { get; set; }
        public string? QuantityOrdered { get; set; }
        public Item? Item { get; set; }
    }
}
