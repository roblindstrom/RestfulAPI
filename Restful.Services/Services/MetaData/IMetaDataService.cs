using Microsoft.AspNetCore.Http;
using Restful.Shared.Helpers;
using Restful.Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Services.Services.MetaData
{
    public interface IMetaDataService<TEntity>
    {
        HttpResponse AddPaginationMetaData(PagedList<TEntity> pagedList, HttpResponse httpResponse, BaseRequest baseRequest);

        bool CheckIfPropertyExistsInObject(TEntity objectToBeChecked, string orderBy);
    }
}
