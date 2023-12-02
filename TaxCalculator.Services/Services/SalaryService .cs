﻿using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Models;

namespace TaxCalculator.Services.Services
{
    public class SalaryService : ISalaryService
    {
        public const int MonthsPerYear = 12;

        private readonly ITaxCalculatorService _taxCalculator;

        public SalaryService(ITaxCalculatorService taxCalculator)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }

        public async Task<SalaryDetailsModel> CalculateSalaryDetails(int grossAnnualSalary)
        {
            if (grossAnnualSalary < 0)
            {
                throw new ArgumentException("Gross annual salary must be non-negative.");
            }

            // Calculate tax once
            decimal annualTax = await _taxCalculator.CalculateTax(grossAnnualSalary);

            decimal netAnnualSalary = grossAnnualSalary - annualTax;
            decimal grossMonthlySalary = (decimal)grossAnnualSalary / MonthsPerYear;
            decimal netMonthlySalary = netAnnualSalary / MonthsPerYear;
            decimal monthlyTaxPaid = annualTax / MonthsPerYear;

            return new SalaryDetailsModel
            {
                GrossAnnualSalary = grossAnnualSalary,
                GrossMonthlySalary = Math.Round(grossMonthlySalary, 2),
                NetAnnualSalary = netAnnualSalary,
                NetMonthlySalary = Math.Round(netMonthlySalary, 2),
                AnnualTaxPaid = annualTax,
                MonthlyTaxPaid = Math.Round(monthlyTaxPaid, 2)
            };
        }
    }
}
