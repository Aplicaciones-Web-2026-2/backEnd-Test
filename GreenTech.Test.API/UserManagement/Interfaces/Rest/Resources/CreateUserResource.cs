using System.ComponentModel.DataAnnotations;

namespace GreenTech.Test.API.UserManagement.Interfaces.Rest.Resources;

public record CreateUserResource(
    [Required(ErrorMessage = "RequiredUserId")]
    Guid UserId
    );