using Microsoft.EntityFrameworkCore;
using TaxCalculator.Db.Context;
using TaxCalculator.Reps.Interfaces;
using TaxCalculator.Reps.Models;

namespace TaxCalculator.Reps.Repositories
{
    public class TaxBandRepository : ITaxBandRepository
    {
        private readonly TaxCalculatorDbContext _context;

        public TaxBandRepository(TaxCalculatorDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaxBandDto>> GetTaxBandsAsync()
        {
            var taxBands = await _context.TaxBands.Select(r => new TaxBandDto()
            {
                LowerLimit = r.LowerLimit,
                UpperLimit = r.UpperLimit,
                TaxRate = r.TaxRate

            }).ToArrayAsync();

            return taxBands.AsEnumerable();
            
        }
    }
}
