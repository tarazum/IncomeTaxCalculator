using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Models;

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
        public async Task<SalaryDetailsModel> Post([FromBody] int grossAnnualSalary)
        {
            var salaryDetails = await _salaryService.CalculateSalaryDetails(grossAnnualSalary);

            return salaryDetails;
        }
    }
}
