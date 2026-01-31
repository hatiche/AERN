using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class EventBusService : IEventBusService
{
    public Task<ApiResult<bool>> PublishAsync(string topic, object payload, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> PublishToTenantAsync(Guid tenantId, string eventType, object payload, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> PublishToUserAsync(Guid userId, string eventType, object payload, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<SubscriptionDto>> SubscribeAsync(Guid userId, string topic, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SubscriptionDto>(new SubscriptionDto(Guid.NewGuid(), userId, topic, DateTime.UtcNow)));

    public Task<ApiResult<bool>> UnsubscribeAsync(Guid subscriptionId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<SubscriptionDto>> GetUserSubscriptionsAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<SubscriptionDto>(Array.Empty<SubscriptionDto>()));
}
