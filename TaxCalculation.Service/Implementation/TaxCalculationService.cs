using TaxCalculation.Repository.Contract;
using TaxCalculation.Service.Contract;

namespace TaxCalculation.Service.Implementation
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly ITaxCalculationRepository taxCalculationRepository;

        public TaxCalculationService(ITaxCalculationRepository taxCalculationRepository)
        {
            this.taxCalculationRepository = taxCalculationRepository;
        }

        public async Task<double> CalculateTaxAsync(double initialValue, int time)
        {
            var tax = await taxCalculationRepository.GetInterestRateFromApiAsync();

            var finalValue = initialValue * Math.Pow((1 + tax.InterestRate),time);

            return finalValue;
        }
    }
}
