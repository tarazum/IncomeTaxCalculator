using TaxCalculator.Services.Models;

namespace TaxCalculator.Services.Interfaces
{
    public interface ISalaryService
    {
        Task<SalaryDetailsModel> CalculateSalaryDetails(int grossAnnualSalary);
    }
}
