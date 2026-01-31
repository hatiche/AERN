using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(INotificationService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<NotificationDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet("user/{userId:guid}")]
    public Task<PagedResult<NotificationDto>> GetPage(Guid userId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] bool? unreadOnly = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), userId, unreadOnly, ct);

    [HttpGet("user/{userId:guid}/unread-count")]
    public Task<ApiResult<int>> GetUnreadCount(Guid userId, CancellationToken ct) => service.GetUnreadCountAsync(userId, ct);

    [HttpPost("{id:guid}/read")]
    public Task<ApiResult<bool>> MarkAsRead(Guid id, CancellationToken ct) => service.MarkAsReadAsync(id, ct);

    [HttpPost("user/{userId:guid}/read-all")]
    public Task<ApiResult<bool>> MarkAllAsRead(Guid userId, CancellationToken ct) => service.MarkAllAsReadAsync(userId, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateNotificationRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpGet("user/{userId:guid}/subscription/{channel}")]
    public Task<ApiResult<NotificationSubscriptionDto>> GetSubscription(Guid userId, string channel, CancellationToken ct) => service.GetSubscriptionAsync(userId, channel, ct);

    [HttpPost("user/{userId:guid}/subscribe")]
    public Task<ApiResult<bool>> Subscribe(Guid userId, [FromBody] CreateSubscriptionRequest request, CancellationToken ct) => service.SubscribeAsync(userId, request, ct);

    [HttpPost("user/{userId:guid}/unsubscribe/{channel}")]
    public Task<ApiResult<bool>> Unsubscribe(Guid userId, string channel, CancellationToken ct) => service.UnsubscribeAsync(userId, channel, ct);
}
