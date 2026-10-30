using GreenTech.Test.API.UserManagement.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.UserManagement.Interfaces.Rest.Resources;

public record UserResource(
    long Id,
    Guid UserId);