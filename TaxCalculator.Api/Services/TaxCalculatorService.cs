using TaxCalculator.WebApi.Models;
using TaxCalculator.WebApi.Repositories;

namespace TaxCalculator.WebApi.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxBandRepository _taxBandRepository;

        public TaxCalculatorService(ITaxBandRepository taxBandRepository)
        {
            _taxBandRepository = taxBandRepository ?? throw new ArgumentNullException(nameof(taxBandRepository));
        }

        public async Task<decimal> CalculateTax(int annualSalary)
        {
            if (annualSalary < 0)
            {
                throw new ArgumentException("Gross annual salary must be non-negative.");
            }

            decimal taxPaid = 0;

            foreach (var band in await _taxBandRepository.GetTaxBandsAsync())
            {
                if (annualSalary <= band.LowerLimit)
                    continue;

                decimal taxableAmountInBand = band.UpperLimit.HasValue
                    ? Math.Min(annualSalary, band.UpperLimit.Value) - band.LowerLimit
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
