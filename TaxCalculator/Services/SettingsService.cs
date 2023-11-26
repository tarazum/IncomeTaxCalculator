using TaxCalculator.Models;

namespace TaxCalculator.Services
{
    public class SettingsService
    {
        private readonly IConfiguration _configuration;

        public SettingsService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ApiSettings GetApiSettings()
        {
            string? apiUrl = _configuration.GetSection("ApiSettings")["ApiUrl"];
            if (apiUrl != null)
            {
                return new ApiSettings { ApiUrl = apiUrl };
            }
            else 
            { 
                return new ApiSettings(); 
            }
        }
    }
}
