using Model;
using Repository.Data;

namespace Service.interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Usuarios user);
    }
}