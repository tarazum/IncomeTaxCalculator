﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaxCalculator.Db.Models;

namespace TaxCalculator.Db.Context
{
    public class TaxCalculatorDbContext : DbContext
    {
        public DbSet<TaxBand> TaxBands { get; set; }

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
