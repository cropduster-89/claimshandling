using ClaimsHandling.Domain.Interfaces;
using ClaimsHandling.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClaimsHandling.Data.Repositories
{
    public class LossTypeRepository : ILossTypeRepository
    {
        private readonly ClaimsHandlingContext _context;

        public LossTypeRepository(ClaimsHandlingContext context)
        {
            _context = context;
        }

        public PaginatedResult<LossType> GetPage(int pageSize,
                                                 int pageIndex)
        {
            var query = _context.LossTypes
                .AsNoTracking();

            return new PaginatedResult<LossType>
            {
                PageData = query
                    .OrderBy(lossType => lossType.LossTypeCode)
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .Select(lossType => new LossType
                    {
                        Code = lossType.LossTypeCode,
                        Description = lossType.LossTypeDescription
                    })
                    .ToList(),
                TotalCount = query.Count()
            };
        }
    }
}
