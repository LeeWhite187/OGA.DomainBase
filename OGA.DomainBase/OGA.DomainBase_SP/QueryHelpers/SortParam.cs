

namespace OGA.DomainBase.QueryHelpers
{
    /// <summary>
    /// Holds the current sort field and direction.
    /// </summary>
    public class SortParam
    {
        /// <summary>
        /// Nullable flag for sort direction.
        /// Set for descending, clear for ascending, leave null for default.
        /// </summary>
        public bool? SortOrderDescending { get; set; }

        /// <summary>
        /// Name of field to sort by.
        /// </summary>
        public string OrderProperty { get; set; }

        public SortParam()
        {
            OrderProperty = "";
        }
    }
}
