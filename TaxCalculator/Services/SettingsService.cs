using TaxCalculator.Web.Models;
using TaxCalculator.WebApi.Models;

namespace TaxCalculator.Web.Services
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
            var result = new ApiSettings();

            var section = _configuration.GetSection("ApiSettings");
            string? apiUrl = section["ApiUrl"];
            if (apiUrl != null)
            {
                result.ApiUrl = apiUrl;
            }
            string? appOrigin = section["AppOrigin"];
            if(appOrigin != null)
            {
                result.AppOrigin = appOrigin;
            }

            return result;
        }
    }
}
