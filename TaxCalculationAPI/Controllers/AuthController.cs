using Microsoft.AspNetCore.Mvc;
using TaxCalculation.Entity;
using TaxCalculation.Service.Contract;

namespace TaxCalculationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] User userRequest)
        {
            var user = authService.GetUser(userRequest.Email, userRequest.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            var token = authService.GenerateToken(user);

            return new
            {
                token = token
            };
        }
    }

}
