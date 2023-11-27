namespace TaxCalculator.Api.Services
{
    public interface ITaxCalculatorService
    {
        Task<decimal> CalculateTax(int annualSalary);
    }
}
