using TaxCalculation.Entity;

namespace TaxCalculation.Service.Contract
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        User GetUser(string email, string password);
    }
}
