using Microsoft.EntityFrameworkCore;
using TaxCalculator.Db.Context;
using TaxCalculator.Reps.Interfaces;
using TaxCalculator.Reps.Repositories;
using TaxCalculator.Services.Interfaces;
using TaxCalculator.Services.Services;
using Microsoft.AspNetCore.Identity;
using TaxCalculator.Db.Models;

namespace TaxCalculator.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register DbContext
            builder.Services.AddDbContext<TaxCalculatorDbContext>(options =>
            {
                // Configure your database connection string here
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            // Register Identity
            builder.Services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<TaxCalculatorDbContext>();

            // Register your services and repositories here
            builder.Services.AddScoped<ITaxBandRepository, TaxBandRepository>();
            builder.Services.AddScoped<ITaxCalculatorService, TaxCalculatorService>();            
            builder.Services.AddScoped<ISalaryService, SalaryService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Configure CORS with the variable
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
