using System.ComponentModel.DataAnnotations;

namespace TaxCalculator.Db.Models;

public class TaxBand
{
    [Key]
    public int Id { get; set; }

    public int LowerLimit { get; set; }
    public int? UpperLimit { get; set; }
    public int TaxRate { get; set; }
}
