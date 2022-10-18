using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxCalculation.Service.Contract;

namespace TaxCalculationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculationController : ControllerBase
    {
        private readonly ITaxCalculationService taxCalculationService;

        public TaxCalculationController(ITaxCalculationService taxCalculationService)
        {
            this.taxCalculationService = taxCalculationService;
        }

        [HttpGet]
        [Route("/calculajuros")]
        [Authorize]
        public async Task<dynamic> CalculaJuros(double valorInicial, int meses)
        {
            var result =  await taxCalculationService.CalculateTaxAsync(valorInicial, meses);

            return new 
            { 
                result = result.ToString("F2")
            };
        }

        [HttpGet]
        [Route("/showmethecode")]
        [Authorize]
        public dynamic ShowMeTheCode()
        {
            return new
            {
                URL = ""
            };
        }
    }
}