namespace TaxCalculator.Models
{
    public interface ISalaryService
    {
        Task<SalaryDetails> CalculateSalaryDetails(int grossAnnualSalary);
    }
}
