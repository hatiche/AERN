using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Notifications and subscriptions.</summary>
public interface INotificationService
{
    Task<ApiResult<NotificationDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<NotificationDto>> GetPageAsync(PagingRequest paging, Guid userId, bool? unreadOnly, CancellationToken ct = default);
    Task<ApiResult<int>> GetUnreadCountAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> MarkAsReadAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> MarkAllAsReadAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateNotificationRequest request, CancellationToken ct = default);
    Task<ApiResult<NotificationSubscriptionDto>> GetSubscriptionAsync(Guid userId, string channel, CancellationToken ct = default);
    Task<ApiResult<bool>> SubscribeAsync(Guid userId, CreateSubscriptionRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UnsubscribeAsync(Guid userId, string channel, CancellationToken ct = default);
}

public record NotificationDto(Guid Id, string Title, string? Body, string Channel, bool IsRead, Guid UserId, DateTime CreatedAt);
public record CreateNotificationRequest(string Title, string? Body, string Channel, Guid UserId);
public record NotificationSubscriptionDto(string Channel, bool IsEnabled, DateTime? LastNotifiedAt);
public record CreateSubscriptionRequest(string Channel, bool IsEnabled, string? Filter);
