namespace TaxCalculator.Models
{
    public interface ITaxBandRepository
    {
        List<TaxBand> GetTaxBands();
    }
}
