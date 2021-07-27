using ClaimsHandling.Domain.Models;

namespace ClaimsHandling.Domain.Interfaces
{
    public interface ILossTypeService
    {
        PaginatedResult<LossType> GetPage(int pageSize, int pageIndex);
    }
}
