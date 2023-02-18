using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OGA.SharedKernel.QueryHelpers;
using OGA.SharedKernel.Services;

namespace OGA.DomainBase.QueryHelpers
{
    /// <summary>
    /// Similar to a paginated list, but maps a paginated list of domain entities into a paginated list of DTO objects.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IMappingPaginatedList<TResult>
    {
        int PageSize { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        int RowCount { get; set; }

        int FirstRowOnPage {get; }
        int LastRowOnPage { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }

        List<TResult> Data { get; set; }
    }

    /// <summary>
    /// Extends the mapped paginted list with url links for first, last, next, and previous pages.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface IMappingPaginatedList_withURL<TResult> : IMappingPaginatedList<TResult>
    {
        Uri FirstPage { get; set; }
        Uri LastPage { get; set; }
        Uri NextPage { get; set; }
        Uri PreviousPage { get; set; }

        void Setup_URLs(IUriService urisvc, string route);
    }
}
