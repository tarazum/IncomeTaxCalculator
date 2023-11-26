using TaxCalculator.Models;

namespace TaxCalculator.Api.Repositories
{
    public interface ITaxBandRepository
    {
        List<TaxBand> GetTaxBands();
    }
}
