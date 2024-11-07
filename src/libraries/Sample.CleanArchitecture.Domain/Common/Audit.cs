namespace Sample.CleanArchitecture.Domain.Common;

public class Audit
{
    public long? CreatedBy { get; set; }
    public DateTimeOffset CreatedDateUtc { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedDateUtc { get; set; }
}
