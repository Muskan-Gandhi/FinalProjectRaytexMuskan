using JWT.Models;

namespace JWT.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate (Users users );
    }
}
