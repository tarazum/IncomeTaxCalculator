using TaxCalculator.Reps.Models;

namespace TaxCalculator.Reps.Interfaces
{
    public interface ITaxBandRepository
    {
        Task<IEnumerable<TaxBandDto>> GetTaxBandsAsync();
    }
}
