namespace TaxCalculation.Service.Contract
{
    public interface ITaxCalculationService
    {
        Task<double> CalculateTaxAsync(double initialValue, int time);
    }
}
