using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.IAM.Interfaces.Rest.Resources;

public record UserResource(
    long Id,
    Guid UserId);