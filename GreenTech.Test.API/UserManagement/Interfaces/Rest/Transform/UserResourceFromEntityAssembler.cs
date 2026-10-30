using GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;
using GreenTech.Test.API.UserManagement.Interfaces.Rest.Resources;

namespace GreenTech.Test.API.UserManagement.Interfaces.Rest.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity) => 
        new(entity.Id, entity.UserId.Identifier);
}