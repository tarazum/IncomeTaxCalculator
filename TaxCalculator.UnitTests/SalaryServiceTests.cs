using Moq;
using TaxCalculator.Api.Services;

namespace TaxCalculator.UnitTests
{
    public class SalaryServiceTests
    {
        [Theory]
        [InlineData(10000, 833.33, 9000, 750, 1000.00, 83.33)]
        [InlineData(40000, 3333.33, 29000, 2416.67, 11000.00, 916.67)]
        public async Task CalculateSalaryDetails_ReturnsCorrectResult(
            int grossAnnualSalary, decimal grossMonthlySalary, decimal netAnnualSalary, decimal netMonthlySalary, decimal annualTaxPaid, decimal monthlyTaxPaid)
        {
            // Arrange
            var taxCalculatorMock = new Mock<ITaxCalculatorService>();
            taxCalculatorMock.Setup(tc => tc.CalculateTax(It.IsAny<int>())).Returns(Task.FromResult(annualTaxPaid));

            var salaryService = new SalaryService(taxCalculatorMock.Object);

            // Act
            var result = await salaryService.CalculateSalaryDetails(grossAnnualSalary);

            // Assert
            Assert.NotNull(result);
            Assert.Equal((decimal)grossAnnualSalary, result.GrossAnnualSalary);
            Assert.Equal(grossMonthlySalary, result.GrossMonthlySalary);
            Assert.Equal(netAnnualSalary, result.NetAnnualSalary);
            Assert.Equal(netMonthlySalary, result.NetMonthlySalary);
            Assert.Equal(annualTaxPaid, result.AnnualTaxPaid);
            Assert.Equal(monthlyTaxPaid, result.MonthlyTaxPaid);
        }

        [Fact]
        public async Task CalculateSalaryDetails_ThrowsException_ForNegativeSalary()
        {
            // Arrange
            var taxCalculatorMock = new Mock<ITaxCalculatorService>();
            taxCalculatorMock.Setup(tc => tc.CalculateTax(It.IsAny<int>())).Returns(Task.FromResult((decimal)0));

            var salaryService = new SalaryService(taxCalculatorMock.Object);
            var negativeSalary = -5000;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(async () => await salaryService.CalculateSalaryDetails(negativeSalary));
            Assert.Equal("Gross annual salary must be non-negative.", exception.Message);
        }
    }
}