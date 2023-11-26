namespace TaxCalculator.Models
{
    public interface ITaxCalculator
    {
        decimal CalculateTax(int annualSalary);
    }
}
