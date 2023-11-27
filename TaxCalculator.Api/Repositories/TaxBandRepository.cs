using TaxCalculator.WebApi.Models;

namespace TaxCalculator.WebApi.Repositories
{
    public class TaxBandRepository : ITaxBandRepository
    {
        public async Task<List<TaxBand>> GetTaxBands()
        {
            return await Task.FromResult(new List<TaxBand>
            {
                new TaxBand { LowerLimit = 0, UpperLimit = 5000, TaxRate = 0 },
                new TaxBand { LowerLimit = 5000, UpperLimit = 20000, TaxRate = 20 },
                new TaxBand { LowerLimit = 20000, UpperLimit = null, TaxRate = 40 }
            });
        }
    }
}
