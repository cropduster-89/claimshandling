using ClaimsHandling.Domain.Models;

namespace ClaimsHandling.Domain.Interfaces
{
    public interface ILossTypeRepository
    {
        PaginatedResult<LossType> GetPage(int pageSize, int pageIndex);
    }
}
