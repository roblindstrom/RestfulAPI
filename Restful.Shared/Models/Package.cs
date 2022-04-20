using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.Models
{
    public class Package
    {
        public Guid PackageId { get; set; }
        public Guid OrderId { get; set; }
        public Order? Order { get; set; }
        public List<Content>? Contents { get; set; }


    }
}
