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
    /// Public interface that allows a domain service to respond with a paginated list of objects.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPaginatedList<T> : IList<T>
    {
        int PageSize { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        int RowCount { get; set; }

        int FirstRowOnPage {get; }
        int LastRowOnPage { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }

    /// <summary>
    /// Extends the paginted list with url links for the first, last, next, and previous pages.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPaginatedList_withURL<T> : IPaginatedList<T>
    {
        Uri FirstPage { get; set; }
        Uri LastPage { get; set; }
        Uri NextPage { get; set; }
        Uri PreviousPage { get; set; }

        void Setup_URLs(IUriService urisvc, string route);
    }
}
