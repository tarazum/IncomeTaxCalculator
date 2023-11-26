namespace TaxCalculator.Api.Services
{
    public interface ITaxCalculatorService
    {
        decimal CalculateTax(int annualSalary);
    }
}
