namespace TaxCalculator.Reps.Models
{
    public class TaxBandDto
    {
        public int LowerLimit { get; set; }
        public int? UpperLimit { get; set; }
        public int TaxRate { get; set; }
    }
}
