using Microsoft.AspNetCore.Http;
using Restful.Shared.Helpers;
using Restful.Shared.RequestModels;
using System.Text.Json;
using System.Threading.Tasks;

namespace Restful.Services.Services.MetaData
{
    public class MetaDataService<T> : IMetaDataService<T>
    {
        public HttpResponse AddPaginationMetaData(PagedList<T> pagedList, HttpResponse httpResponse, BaseRequest baseRequest)
        {
            var paginationMetadata = new
            {
                totalCount = pagedList.TotalCount,
                pageSize = pagedList.PageSize,
                currentPage = pagedList.CurrentPage,
                totalPages = pagedList.TotalPages,
                orderBy = baseRequest.OrderBy,
                fields = baseRequest.Fields

            };

            httpResponse.Headers.Add("X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return httpResponse;
        }

        public bool CheckIfPropertyExistsInObject(T objectToBeChecked, string propertiesFromRequest)
        {
            //Returns true if empty or null
            if (propertiesFromRequest is null || propertiesFromRequest == "")
                return true;

            var listOfPropertynames = new List<string>();
            //Get All Properties from object
            foreach (var prop in objectToBeChecked.GetType().GetProperties().ToList())
            {
                listOfPropertynames.Add(prop.Name.ToLower().Trim());
            }

            // the propertiesFromRequest string is separated by ",", so we split it.
            var orderByAfterSplit = propertiesFromRequest.Split(',');

            //Check if all propertiesFromRequest exists in properties
            foreach (var orderByClause in orderByAfterSplit)
            {
                //Returns false if orderByClause doesnt exist in listOfProperties
                if (!listOfPropertynames.Contains(orderByClause.ToLower().Trim()))
                    return false;
            }


            return true;
        }
    }
}
