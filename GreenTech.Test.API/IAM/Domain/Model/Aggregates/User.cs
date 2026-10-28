using GreenTech.Test.API.IAM.Domain.Model.Commands;
using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.IAM.Domain.Model.Aggregates;

public partial class User
{
    protected User()
    {
        SourceId = null!;
        Name = null!;
        Email = null!;
    }

    public User(CreateUserCommand createUserCommand)
    {
        ArgumentNullException.ThrowIfNull(createUserCommand);
        
        SourceId = createUserCommand.SourceId;
        Name = null!;
        Email = null!;
    }
    
    public long Id { get; private set; }
    
    public SourceId SourceId { get; init; }
    
    public string Name { get; private set; }
    
    public string Email { get; private set; }
    
}