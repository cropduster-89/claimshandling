using System.Collections.Generic;

namespace ClaimsHandling.Domain.Models
{
    public class PaginatedResult<T>
    {
        public IEnumerable<T> PageData { get; set; }
        public int TotalCount { get; set; }
    }
}
