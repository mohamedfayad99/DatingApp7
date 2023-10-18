using API_Project.Entities;

namespace API_Project.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
