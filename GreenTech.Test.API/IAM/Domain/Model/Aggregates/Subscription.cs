using GreenTech.Test.API.IAM.Domain.Model.Commands;
using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.IAM.Domain.Model.Aggregates;

public partial class Subscription
{
    public long SubscriptionId { get; private set; }
     
     DateTimeOffset StartDate { get; set; }
     
     DateTimeOffset EndDate { get; set; }
     
     SubscriptionType SubscriptionType { get; set; }
     
     SubscriptionStatus SubscriptionStatus { get; set; }
    protected Subscription()
    {
        StartDate = DateTimeOffset.Now;
        EndDate = DateTimeOffset.Now;
        SubscriptionType = SubscriptionType.Basic;
        SubscriptionStatus = SubscriptionStatus.Pending;
    }
    
    public Subscription(CreateSubscriptionCommand createSubscriptionCommand)
    {
        ArgumentNullException.ThrowIfNull(createSubscriptionCommand);
        
        StartDate = DateTimeOffset.Now;
        EndDate = createSubscriptionCommand.EndDate;
        SubscriptionType = createSubscriptionCommand.SubscriptionType;
        SubscriptionStatus =  createSubscriptionCommand.SubscriptionStatus;
    }
    

}