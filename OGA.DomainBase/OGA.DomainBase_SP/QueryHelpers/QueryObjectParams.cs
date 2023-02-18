using System.Collections.Generic;

namespace OGA.DomainBase.QueryHelpers
{
    /// <summary>
    /// Collection of query parameters to make rich queries easier.
    /// </summary>
	public class QueryObjectParams : OGA.SharedKernel.QueryHelpers.PaginationFilter
	{
        /// <summary>
        /// Sorting queries list.
        /// </summary>
        public List<SortParam> SortingParams { get; set; }
    }
}
