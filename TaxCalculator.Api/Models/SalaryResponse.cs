using TaxCalculator.Services.Models;

namespace TaxCalculator.WebApi.Models
{
    public class SalaryResponse
    {
        public SalaryDetailsModel? Data { get; set; }
        public bool IsOk { get; set; }
        public string? Message { get; set; }
    }
}
