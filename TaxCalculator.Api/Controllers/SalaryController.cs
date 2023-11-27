using Microsoft.AspNetCore.Mvc;
using TaxCalculator.WebApi.Models;
using TaxCalculator.WebApi.Services;

namespace TaxCalculator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpPost(Name = "CalculateSalary")]
        public async Task<SalaryDetails> Post([FromBody] int grossAnnualSalary)
        {
            var salaryDetails = await _salaryService.CalculateSalaryDetails(grossAnnualSalary);

            return salaryDetails;
        }
    }
}
