using Sample.CleanArchitecture.Domain.Common;

namespace Sample.CleanArchitecture.Domain.Entities;

public class Treatment: Audit
{
    public long Id { get; set; }
    public long TestId { get; set; }
    public decimal TotalCost {  get; set; }

    public Test Test { get; set; }
}
