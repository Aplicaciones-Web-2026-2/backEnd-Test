using GreenTech.Test.API.IAM.Domain.Model.Commands;
using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;
using GreenTech.Test.API.IAM.Interfaces.Rest.Resources;

namespace GreenTech.Test.API.IAM.Interfaces.Rest.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource) =>
        new(new UserId(resource.UserId));
}