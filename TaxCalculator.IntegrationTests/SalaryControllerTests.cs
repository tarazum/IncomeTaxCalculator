using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TaxCalculator.WebApi;
using Xunit;
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
            var content = new StringContent("0", Encoding.UTF8, "application/json");
            //var content = JsonContent.Create(new { grossAnnualSalary = 0 });
            // Act
            var response = await client.PostAsync("/api/salary", content);
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
        }
    }
}