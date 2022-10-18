using TaxCalculation.Entity;
using TaxCalculation.Service.Implementation;

namespace TaxCalculation.ServiceTests
{
    [TestClass]
    public class AuthServiceTests
    {
        [TestMethod]
        public void GeneratingTokenShouldReturnSomething()
        {
            //Arrange
            var authService = new AuthService();
            var user = new User
            {
                Email = "admin@admin.com",
                Password = "admin"
            };

            //Act
            var result = authService.GenerateToken(user);

            //Assert
            Assert.AreNotEqual(result, "");
        }

        [TestMethod]
        public void GettingUserShouldReturnSomething()
        {
            //Arrange
            var authService = new AuthService();
            var email = "admin@mail.com";
            var pass = "admin";

            var expectedResult = new User
            {
                Email = email,
                Password = pass
            };

            //Act
            var result = authService.GetUser(email, pass);

            //Assert
            Assert.AreEqual(result.Email, expectedResult.Email);
            Assert.AreEqual(result.Password, expectedResult.Password);
        }
    }
}
