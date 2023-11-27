namespace TaxCalculator.WebApi.Services
{
    public interface ITaxCalculatorService
    {
        Task<decimal> CalculateTax(int annualSalary);
    }
}
