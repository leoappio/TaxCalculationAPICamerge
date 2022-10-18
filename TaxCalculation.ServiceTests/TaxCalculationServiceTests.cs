using NSubstitute;
using TaxCalculation.Entity;
using TaxCalculation.Repository.Contract;
using TaxCalculation.Service.Implementation;

namespace TaxCalculation.ServiceTests
{
    [TestClass]
    public class TaxCalculationServiceTests
    {
        [TestMethod]
        public void CalculatingTaxAsyncShouldReturnDoubleValue()
        {
            //Arrange
            var taxCalculationRepository = Substitute.For<ITaxCalculationRepository>();
            var taxCalculationService = new TaxCalculationService(taxCalculationRepository);
            var initialValue = 100.0;
            var time = 5;
            var expectedResult = 105.10;
            var tax = new Tax
            {
                InterestRate = 0.01
            };

            _ = taxCalculationRepository.GetInterestRateFromApiAsync().ReturnsForAnyArgs(tax);

            //Act
            var result = taxCalculationService.CalculateTaxAsync(initialValue, time);

            //Assert
            Assert.AreEqual(expectedResult.ToString("F2"), result.Result.ToString("F2"));
        }
    }
}