namespace TaxCalculator.Models
{
    public class TaxBandRepository : ITaxBandRepository
    {
        public List<TaxBand> GetTaxBands()
        {
            // You can implement logic here to fetch tax bands from a data source.
            // For now, let's create a sample list.

            return new List<TaxBand>
            {
                new TaxBand { LowerLimit = 0, UpperLimit = 5000, TaxRate = 0 },
                new TaxBand { LowerLimit = 5000, UpperLimit = 20000, TaxRate = 20 },
                new TaxBand { LowerLimit = 20000, UpperLimit = null, TaxRate = 40 }
            };
        }
    }
}
