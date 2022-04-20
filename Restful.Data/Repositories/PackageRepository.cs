using Restful.Shared.IRepositories;
using Restful.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Data.Repositories
{
    public class PackageRepository : BaseRepository<Package>, IPackageRepository
    {
            protected new readonly RestfulDbContext _restfulDbContext;
        public PackageRepository(RestfulDbContext myDbContext) : base(myDbContext)
        {
            _restfulDbContext = myDbContext;
        }
    }
}
