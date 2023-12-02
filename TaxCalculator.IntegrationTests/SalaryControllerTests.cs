using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using TaxCalculator.WebApi;
using TaxCalculator.WebApi.Models;

namespace TaxCalculator.IntegrationTests
{
    public class SalaryControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public SalaryControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task GetSalary_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();
            //var content = new StringContent("0", Encoding.UTF8, "application/json");
            var content = JsonContent.Create(new SalaryRequest() { GrossAnnualSalary = 0 });
            // Act
            var response = await client.PostAsync("/api/salary", content);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseObject = await response.Content.ReadFromJsonAsync<SalaryResponse>();
            Assert.NotNull(responseObject);
            Assert.NotNull(responseObject.Data);

            var result = responseObject.Data;
            var expectedResult = (decimal)0;

            Assert.Equal(expectedResult, result.GrossAnnualSalary);
            Assert.Equal(expectedResult, result.GrossMonthlySalary);
            Assert.Equal(expectedResult, result.NetAnnualSalary);
            Assert.Equal(expectedResult, result.NetMonthlySalary);
            Assert.Equal(expectedResult, result.AnnualTaxPaid);
            Assert.Equal(expectedResult, result.MonthlyTaxPaid);
        }
    }
}