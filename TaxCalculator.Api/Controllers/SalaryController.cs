using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models;

namespace TaxCalculator.Api.Controllers
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
        public SalaryDetails Post([FromBody] int grossAnnualSalary)
        {
            var salaryDetails = _salaryService.CalculateSalaryDetails(grossAnnualSalary);

            return salaryDetails;
        }
    }
}
