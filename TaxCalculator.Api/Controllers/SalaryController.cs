using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.WebApi.Models;

namespace TaxCalculator.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
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
        public async Task<SalaryResponse> Post([FromBody] SalaryRequest request)
        {
            var response = new SalaryResponse()
            {
                IsOk = false
            };
            try
            {
                var salaryDetails = await _salaryService.CalculateSalaryDetails(request.GrossAnnualSalary);
                response.IsOk = true;
                response.Data = salaryDetails;
            }
            catch (Exception e)
            {
                response.IsOk = false;
                response.Message = e.Message;
                //log it: e.ToString()
            }

            return response;
        }
    }
}
