using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace TaxCalculator.Db.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaxCalculatorDbContext>
    {
        public TaxCalculatorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxCalculatorDbContext>();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new TaxCalculatorDbContext(optionsBuilder.Options);
        }
    }

}
