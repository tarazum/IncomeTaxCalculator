using TaxCalculator.WebApi.Models;

namespace TaxCalculator.WebApi.Repositories
{
    public interface ITaxBandRepository
    {
        Task<List<TaxBand>> GetTaxBands();
    }
}
