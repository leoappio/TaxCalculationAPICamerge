using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaxCalculation.Entity;
using TaxCalculation.Service.Contract;

namespace TaxCalculation.Service.Implementation
{
    public class AuthService : IAuthService
    {
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email)
                }),

                Expires = DateTime.Now.AddDays(5)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public User GetUser(string email, string password)
        {
            var users = new List<User>
            {
                new User{Email = "admin@mail.com", Password = "admin"},
                new User{Email = "user@mail.com", Password = "user"}
            };

            return users.FirstOrDefault(
                x => x.Email == email
                && x.Password == password);
        }
    }
}
