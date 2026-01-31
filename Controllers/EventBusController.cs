using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventBusController(IEventBusService service) : ControllerBase
{
    [HttpPost("publish")]
    public Task<ApiResult<bool>> Publish([FromQuery] string topic, [FromBody] object payload, CancellationToken ct) => service.PublishAsync(topic, payload, ct);

    [HttpPost("tenant/{tenantId:guid}/publish")]
    public Task<ApiResult<bool>> PublishToTenant(Guid tenantId, [FromQuery] string eventType, [FromBody] object payload, CancellationToken ct) =>
        service.PublishToTenantAsync(tenantId, eventType, payload, ct);

    [HttpPost("user/{userId:guid}/publish")]
    public Task<ApiResult<bool>> PublishToUser(Guid userId, [FromQuery] string eventType, [FromBody] object payload, CancellationToken ct) =>
        service.PublishToUserAsync(userId, eventType, payload, ct);

    [HttpPost("user/{userId:guid}/subscribe")]
    public Task<ApiResult<SubscriptionDto>> Subscribe(Guid userId, [FromQuery] string topic, CancellationToken ct) => service.SubscribeAsync(userId, topic, ct);

    [HttpPost("unsubscribe")]
    public Task<ApiResult<bool>> Unsubscribe([FromQuery] Guid subscriptionId, CancellationToken ct) => service.UnsubscribeAsync(subscriptionId, ct);

    [HttpGet("user/{userId:guid}/subscriptions")]
    public Task<ApiListResult<SubscriptionDto>> GetUserSubscriptions(Guid userId, CancellationToken ct) => service.GetUserSubscriptionsAsync(userId, ct);
}
