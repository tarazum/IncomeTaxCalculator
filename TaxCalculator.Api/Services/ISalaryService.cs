using TaxCalculator.WebApi.Models;

namespace TaxCalculator.WebApi.Services

{
    public interface ISalaryService
    {
        Task<SalaryDetails> CalculateSalaryDetails(int grossAnnualSalary);
    }
}
