namespace TaxCalculator.Services.Interfaces
{
    public interface ITaxCalculatorService
    {
        Task<decimal> CalculateTax(int annualSalary);
    }
}
