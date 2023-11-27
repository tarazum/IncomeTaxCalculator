using Moq;
using TaxCalculator.WebApi.Repositories;
using TaxCalculator.WebApi.Services;
using TaxCalculator.WebApi.Models;

namespace TaxCalculator.UnitTests
{
    public class TaxCalculatorServiceTests
    {
        [Theory]
        [InlineData(5000, 0, 0)] // Example test case for Band A
        [InlineData(15000, 20, 3000)] // Example test case for Band B
        [InlineData(30000, 40, 12000)] // Example test case for Band C
        // Add more test cases as needed
        public async Task CalculateTax_ReturnsCorrectResult(
            int annualSalary, int taxRate, int expectedTax)
        {
            // Arrange
            var taxBandRepositoryMock = new Mock<ITaxBandRepository>();
            var taxBands = new List<TaxBand>
            {
                new TaxBand { LowerLimit = 0, UpperLimit = null, TaxRate = taxRate }
            };
            taxBandRepositoryMock.Setup(repo => repo.GetTaxBands()).Returns(Task.FromResult(taxBands));

            var taxCalculator = new TaxCalculatorService(taxBandRepositoryMock.Object);

            // Act
            var result = await taxCalculator.CalculateTax(annualSalary);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Fact]
        public async Task CalculateTax_ThrowsException_ForNegativeSalary()
        {
            // Arrange
            var taxBandRepositoryMock = new Mock<ITaxBandRepository>();
            var taxCalculator = new TaxCalculatorService(taxBandRepositoryMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await taxCalculator.CalculateTax(-5000));
            Assert.Equal("Gross annual salary must be non-negative.", exception.Message);
        }
    }
}
