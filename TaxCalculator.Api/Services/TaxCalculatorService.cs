﻿using TaxCalculator.Api.Repositories;
using TaxCalculator.Models;

namespace TaxCalculator.Api.Services
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private readonly ITaxBandRepository _taxBandRepository;

        public TaxCalculatorService(ITaxBandRepository taxBandRepository)
        {
            _taxBandRepository = taxBandRepository ?? throw new ArgumentNullException(nameof(taxBandRepository));
        }

        public decimal CalculateTax(int annualSalary)
        {
            decimal taxPaid = 0;

            foreach (var band in _taxBandRepository.GetTaxBands())
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