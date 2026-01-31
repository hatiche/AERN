using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Event bus / SignalR / Service Bus notifications.</summary>
public interface IEventBusService
{
    Task<ApiResult<bool>> PublishAsync(string topic, object payload, CancellationToken ct = default);
    Task<ApiResult<bool>> PublishToTenantAsync(Guid tenantId, string eventType, object payload, CancellationToken ct = default);
    Task<ApiResult<bool>> PublishToUserAsync(Guid userId, string eventType, object payload, CancellationToken ct = default);
    Task<ApiResult<SubscriptionDto>> SubscribeAsync(Guid userId, string topic, CancellationToken ct = default);
    Task<ApiResult<bool>> UnsubscribeAsync(Guid subscriptionId, CancellationToken ct = default);
    Task<ApiListResult<SubscriptionDto>> GetUserSubscriptionsAsync(Guid userId, CancellationToken ct = default);
}

public record SubscriptionDto(Guid Id, Guid UserId, string Topic, DateTime CreatedAt);
