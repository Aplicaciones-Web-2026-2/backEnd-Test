using GreenTech.Test.API.IAM.Domain.Model.Commands;
using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.IAM.Domain.Model.Aggregates;

public partial class Subscription
{
    protected Subscription()
    {
        
    }
    
    public Subscription(CreateSubscriptionCommand createSubscriptionCommand)
    {
        ArgumentNullException.ThrowIfNull(createSubscriptionCommand);
        
        SourceId = createSubscriptionCommand.SourceId;
        StartDate = DateTimeOffset.Now;
        EndDate = createSubscriptionCommand.EndDate;
        SubscriptionType = createSubscriptionCommand.SubscriptionType;
        SubscriptionStatus =  createSubscriptionCommand.SubscriptionStatus;
    }
    
    public long Id { get; private set; }
    
    SourceId SourceId { get; init; }
    
    DateTimeOffset StartDate { get; set; }
    
    DateTimeOffset EndDate { get; set; }
    
    SubscriptionType SubscriptionType { get; set; }
    
    SubscriptionStatus SubscriptionStatus { get; set; }
}