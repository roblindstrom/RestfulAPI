using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Restful.Shared.Helpers
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            

            if (string.IsNullOrWhiteSpace(orderBy))
                return source;
            
            var orderByString = string.Empty;

            // the orderBy string is separated by ",", so we split it.
            var orderByAfterSplit = orderBy.Split(',');

            // apply each orderby clause  
            foreach (var orderByClause in orderByAfterSplit)
            {
                // trim the orderBy clause, as it might contain leading
                // or trailing spaces. Can't trim the var in foreach,
                // so use another var.
                var trimmedOrderByClause = orderByClause.Trim();

                // if the sort option ends with with " desc", we order
                // descending, ortherwise ascending
                var orderDescending = trimmedOrderByClause.EndsWith(" desc");

                orderByString = orderByString +
                        (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ")
                        + orderByClause
                        + (orderDescending ? " descending" : " ascending");
                
            }

            return source.OrderBy(orderByString);
        }
    }
}
