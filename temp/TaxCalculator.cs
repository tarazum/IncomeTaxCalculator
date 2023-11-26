namespace TaxCalculator.Models
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly List<TaxBand> _taxBands;

        public TaxCalculator(List<TaxBand> taxBands)
        {
            _taxBands = taxBands;
        }

        public decimal CalculateTax(int annualSalary)
        {
            decimal taxPaid = 0;

            foreach (var band in _taxBands)
            {
                if (annualSalary <= band.LowerLimit)
                    continue;

                decimal taxableAmountInBand = band.UpperLimit.HasValue
                    ? System.Math.Min(annualSalary, band.UpperLimit.Value) - band.LowerLimit
                    : annualSalary - band.LowerLimit;

                decimal taxInBand = taxableAmountInBand * (band.TaxRate / 100m);
                taxPaid += taxInBand;

                if (!band.UpperLimit.HasValue || annualSalary <= band.UpperLimit.Value)
                    break;
            }

            return taxPaid;
        }
    }
}
