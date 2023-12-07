using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculator.Domain.Entities;

public class TaxBand
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(100)]
    public string TaxBandName { get; set; } = string.Empty;

    public int LowerLimit { get; set; }

    public int? UpperLimit { get; set; }

    public int TaxRate { get; set; }
}
