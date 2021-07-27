namespace ClaimsHandling.Domain.Interfaces
{
    public interface IUserRepository
    {
        bool UserWithLoginExists(Login login);
    }
}
