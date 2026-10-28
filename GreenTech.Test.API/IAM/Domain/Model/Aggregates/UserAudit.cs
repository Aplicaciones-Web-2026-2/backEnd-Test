using GreenTech.Test.API.Shared.Domain.Model;

namespace GreenTech.Test.API.IAM.Domain.Model.Aggregates;

public partial class User : IAuditableEntity
{
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}