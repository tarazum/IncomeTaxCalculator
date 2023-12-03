using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Db.Models;

namespace TaxCalculator.Db.Context
{
    public class TaxCalculatorDbContext : IdentityDbContext<ApplicationUser>  // Inherit from IdentityDbContext instead of DbContext
    {
        public DbSet<TaxBand> TaxBands { get; set; }

        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
