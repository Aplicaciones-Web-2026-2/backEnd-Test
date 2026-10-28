namespace GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

public readonly record struct UserId
{
    public Guid Identifier
    {
        get;
        init
        {
            if (value == Guid.Empty)
                throw new ArgumentException("UserId cannot be empty GUID.", nameof(value));
            field = value;
        }
    }

    public UserId() => throw new InvalidOperationException("UserId must be initialized with a non-empty GUID.");

    public UserId(Guid id) => Identifier = id;

    public static UserId New() => new(Guid.CreateVersion7());

    public override string ToString() => Identifier.ToString();
};