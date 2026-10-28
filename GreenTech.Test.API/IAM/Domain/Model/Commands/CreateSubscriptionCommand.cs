using GreenTech.Test.API.IAM.Domain.Model.ValueObjects;

namespace GreenTech.Test.API.IAM.Domain.Model.Commands;

public record CreateSubscriptionCommand(SourceId SourceId, SubscriptionType SubscriptionType, SubscriptionStatus SubscriptionStatus, DateTimeOffset EndDate);