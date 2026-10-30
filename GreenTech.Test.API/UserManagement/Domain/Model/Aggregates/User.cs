using GreenTech.Test.API.UserManagement.Domain.Model.Commands;
using GreenTech.Test.API.UserManagement.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.UserManagement.Domain.Model.Aggregates;

public partial class User
{
    public long Id { get; init; }
    public UserId UserId { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    protected User(string name, string email)
    {
        Name = null!;
        Email = null!;
    }
    
    public  User(CreateUserCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        
        UserId = command.UserId;
    }
    
}