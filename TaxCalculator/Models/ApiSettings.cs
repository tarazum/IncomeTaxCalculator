namespace TaxCalculator.Models
{
    public class ApiSettings
    {
        public string ApiUrl { get; set; }

        public string AppOrigin { get; set; }

        public ApiSettings()
        {
            ApiUrl = string.Empty; // or any other default value
            AppOrigin = string.Empty;
        }
    }
}
