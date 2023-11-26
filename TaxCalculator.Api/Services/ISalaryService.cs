namespace TaxCalculator.Models
{
    public interface ISalaryService
    {
        SalaryDetails CalculateSalaryDetails(int grossAnnualSalary);
    }
}
