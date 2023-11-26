﻿using TaxCalculator.Api.Repositories;
using TaxCalculator.Models;

namespace TaxCalculator.Api.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ITaxCalculatorService _taxCalculator;

        public SalaryService(ITaxCalculatorService taxCalculator)
        {
            _taxCalculator = taxCalculator ?? throw new ArgumentNullException(nameof(taxCalculator));
        }

        public SalaryDetails CalculateSalaryDetails(int grossAnnualSalary)
        {
            // Calculate tax once
            decimal annualTax = _taxCalculator.CalculateTax(grossAnnualSalary);

            // Basic calculation without considering deductions or other factors
            decimal netAnnualSalary = grossAnnualSalary - annualTax;
            decimal grossMonthlySalary = grossAnnualSalary / 12;
            decimal netMonthlySalary = netAnnualSalary / 12;
            decimal monthlyTaxPaid = annualTax / 12;

            return new SalaryDetails
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