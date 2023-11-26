using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Api.Repositories;
using TaxCalculator.Api.Services;
using TaxCalculator.Models;

namespace TaxCalculator.UnitTests
{
    public class TaxCalculatorServiceTests
    {
        [Theory]
        [InlineData(5000, 0, 0)] // Example test case for Band A
        [InlineData(15000, 20, 3000)] // Example test case for Band B
        [InlineData(30000, 40, 12000)] // Example test case for Band C
        // Add more test cases as needed
        public void CalculateTax_ReturnsCorrectResult(
            int annualSalary, int taxRate, int expectedTax)
        {
            // Arrange
            var taxBandRepositoryMock = new Mock<ITaxBandRepository>();
            taxBandRepositoryMock.Setup(repo => repo.GetTaxBands()).Returns(new List<TaxBand>
            {
                new TaxBand { LowerLimit = 0, UpperLimit = null, TaxRate = taxRate }
            });

            var taxCalculator = new TaxCalculatorService(taxBandRepositoryMock.Object);

            // Act
            var result = taxCalculator.CalculateTax(annualSalary);

            // Assert
            Assert.Equal(expectedTax, result);
        }

        [Fact]
        public void CalculateTax_ThrowsException_ForNegativeSalary()
        {
            // Arrange
            var taxBandRepositoryMock = new Mock<ITaxBandRepository>();
            var taxCalculator = new TaxCalculatorService(taxBandRepositoryMock.Object);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => taxCalculator.CalculateTax(-5000));
            Assert.Equal("Gross annual salary must be non-negative.", exception.Message);
        }
    }
}
