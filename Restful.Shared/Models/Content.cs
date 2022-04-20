using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Shared.Models
{
    public class Content
    {
        public Guid ContentId { get; set; }
        public Guid PackageId { get; set; }
        public int QuantityOrdered { get; set; }
        public string? Size { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public Package? Package { get; set; }
    }
}
