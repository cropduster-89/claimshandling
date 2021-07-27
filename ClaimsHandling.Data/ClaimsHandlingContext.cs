using ClaimsHandling.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace ClaimsHandling.Data
{
    public class ClaimsHandlingContext : DbContext
    {
        virtual public DbSet<User> Users { get; set; }
        virtual public DbSet<LossType> LossTypes { get; set; }

        public ClaimsHandlingContext(DbContextOptions<ClaimsHandlingContext> options)
            : base(options)
        {
        }
    }
}
