using ClaimsHandling.Domain.Interfaces;

namespace ClaimsHandling.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool TryLogin(Login login)
        {
            return _userRepository.UserWithLoginExists(login);
        }
    }
}
