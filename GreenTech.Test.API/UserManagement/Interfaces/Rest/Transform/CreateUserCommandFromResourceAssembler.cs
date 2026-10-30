using GreenTech.Test.API.UserManagement.Domain.Model.Commands;
using GreenTech.Test.API.UserManagement.Domain.Model.ValueObjects;
using GreenTech.Test.API.UserManagement.Interfaces.Rest.Resources;

namespace GreenTech.Test.API.UserManagement.Interfaces.Rest.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
        new(new UserId(resource.UserId));
}