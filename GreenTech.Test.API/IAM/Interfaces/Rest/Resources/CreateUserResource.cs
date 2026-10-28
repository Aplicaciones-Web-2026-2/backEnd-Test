using System.ComponentModel.DataAnnotations;

namespace GreenTech.Test.API.IAM.Interfaces.Rest.Resources;

public record CreateUserResource(
    [Required(ErrorMessage = "RequiredUserId")]
    Guid UserId
    );