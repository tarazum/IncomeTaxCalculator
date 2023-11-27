# Income Tax Calculator

## Overview

The Income Tax Calculator is a comprehensive C# project that includes both an ASP.NET Core App and an ASP.NET Core Web API. It calculates UK income tax based on tax bands, demonstrating the principles of object-oriented design, design patterns, testing, and software engineering.

## Background - Tax calculation

UK Income tax is calculated according to tax bands. Tax within each band is
calculated based on the amount of the salary falling within a band. The total tax is
the sum of the tax paid within all bands. Each band has an optional upper and
mandatory lower limit and a percentage rate of tax. Tax bands will not overlap.
Each band takes its upper limit to be the lower limit of the next band. The tax band
covering the upper part of the salary never has an upper limit. The
the uppermost tax band has a tax rate of 40%; this allows tax to be capped.
Sample data:
Tax Band Annual Salary Range (£) Tax Rate (%)
Tax Band A 0 - 5000 0
Tax Band B 5000 - 20000 20
Tax Band C 20000 + 40

Both the tax rate and limits are integer values. Tax is calculated based on the gross
annual salary. (see "Examples of tax calculations"). Net salary is gross salary less
tax. Monthly amounts are the annual amounts divided by 12.

## Project Structure

### ASP.NET Core App

The ASP.NET Core app serves as the presentation layer with a simple user interface. It includes:

- **HomeController:** Manages the home page and user interface.
  
- **Views:** Contains the Razor views for rendering the user interface.

### ASP.NET Core Web API

The ASP.NET Core Web API provides the backend logic for income tax calculation. It includes:

- **SalaryController:** Exposes an API endpoint (`/api/salary`) for calculating income tax based on the gross annual salary.

- **Services:** Includes services like `SalaryService` for calculating salary details and `TaxCalculatorService` for income tax calculation.

- **Models:** Contains data models such as `TaxBand` and `SalaryDetails`.

- **Repositories:** Houses the repository pattern with interfaces like `ITaxBandRepository` for retrieving tax bands.


## Dependencies

### Controllers -> Services -> Repositories

The project follows a clear dependency structure:

- **Controllers:** Depend on services for business logic.
  
- **Services:** Depend on repositories for data access.
  
- **Repositories:** Implement interfaces for fetching data.

## Building and Running the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/IncomeTaxCalculator.git
   ```

2. Open the solution in Visual Studio or your preferred IDE.

3. Build and run the project.

## Unit Testing
Unit tests are crucial for ensuring the correctness of the application. To run the unit tests:

	```bash
	dotnet test
	```
	
