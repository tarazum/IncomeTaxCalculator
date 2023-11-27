using TaxCalculator.Models;

namespace TaxCalculator.Api.Repositories
{
    public interface ITaxBandRepository
    {
        Task<List<TaxBand>> GetTaxBands();
    }
}
