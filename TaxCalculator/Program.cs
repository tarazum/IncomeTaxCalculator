using TaxCalculator.Web.Services;

namespace TaxCalculator.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register SettingsService
            builder.Services.AddSingleton<SettingsService>();

            // Register ApiSettings using the SettingsService
            builder.Services.AddSingleton(provider => provider.GetRequiredService<SettingsService>().GetApiSettings());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Configure CORS with the variable
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://localhost:44301")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
