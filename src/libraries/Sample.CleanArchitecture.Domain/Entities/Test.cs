using Sample.CleanArchitecture.Domain.Common;

namespace Sample.CleanArchitecture.Domain.Entities;

public class Test : Audit
{
    public long Id { get; set; }
    public string Name { get; set; }
    public decimal Cost { get; set; }
}
