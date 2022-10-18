using NSubstitute;
using TaxCalculationAPI.Controllers;

namespace TaxCalculation.ControllerTests
{
    [TestClass]
    public class TaxCalculationControllerTests
    {
        [TestMethod]
        public void GettingInterestRateShouldReturnCorrectTaxObject()
        {
            //Arrange
            var taxCalculationService = Substitute.For<Service.Contract.ITaxCalculationService>();
            var controller = new TaxCalculationController(taxCalculationService);
            var expectedResult = 51.01;
            var initialValue = 50;
            var time = 2;

            _ = taxCalculationService.CalculateTaxAsync(initialValue, time).ReturnsForAnyArgs(expectedResult);

            //Act
            var result = controller.CalculaJuros(initialValue, time);

            //Assert
            Assert.AreEqual(expectedResult.ToString("F2"), result.Result);
        }
    }
}