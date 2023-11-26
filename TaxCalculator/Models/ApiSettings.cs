namespace TaxCalculator.Models
{
    public class ApiSettings
    {
        public string ApiUrl { get; set; }

        public ApiSettings()
        {
            ApiUrl = string.Empty; // or any other default value
        }
    }
}
