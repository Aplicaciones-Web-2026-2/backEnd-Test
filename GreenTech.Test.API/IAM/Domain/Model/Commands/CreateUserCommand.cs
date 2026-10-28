using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.IAM.Domain.Model.Commands;

public record CreateUserCommand(SourceId SourceId, string UserName, string Password);