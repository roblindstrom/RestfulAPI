using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Services.Services.Seeds
{
    public interface ISeedService
    {
        Task SeedDatabase();
    }
}
