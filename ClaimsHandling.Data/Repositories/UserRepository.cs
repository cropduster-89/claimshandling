using ClaimsHandling.Domain;
using ClaimsHandling.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ClaimsHandling.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClaimsHandlingContext _context; 

        public UserRepository(ClaimsHandlingContext context)
        {
            _context = context;
        }

        public bool UserWithLoginExists(Login login)
        {
            return _context.Users
                .AsNoTracking()
                .Any(user => user.UserName.Equals(login.Username) &&
                             user.Password.Equals(login.Password) &&
                             user.Active);
        }
    }
}
