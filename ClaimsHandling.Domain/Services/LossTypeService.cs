using ClaimsHandling.Domain.Interfaces;
using ClaimsHandling.Domain.Models;

namespace ClaimsHandling.Domain.Services
{
    public class LossTypeService : ILossTypeService
    {
        private readonly ILossTypeRepository _lossTypeRepository;

        public LossTypeService(ILossTypeRepository lossTypeRepository)
        {
            _lossTypeRepository = lossTypeRepository;
        }

        public PaginatedResult<LossType> GetPage(int pageSize,
                                                 int pageIndex)
        {
            return _lossTypeRepository.GetPage(pageSize, pageIndex);
        }
    }
}
