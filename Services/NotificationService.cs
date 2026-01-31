using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class NotificationService : INotificationService
{
    public Task<ApiResult<NotificationDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<NotificationDto>(new NotificationDto(id, "Title", "Body", "email", false, Guid.Empty, DateTime.UtcNow)));

    public Task<PagedResult<NotificationDto>> GetPageAsync(PagingRequest paging, Guid userId, bool? unreadOnly, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<NotificationDto>(Array.Empty<NotificationDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<int>> GetUnreadCountAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<int>(0));

    public Task<ApiResult<bool>> MarkAsReadAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> MarkAllAsReadAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<IdResult> CreateAsync(CreateNotificationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<NotificationSubscriptionDto>> GetSubscriptionAsync(Guid userId, string channel, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<NotificationSubscriptionDto>(new NotificationSubscriptionDto(channel, true, null)));

    public Task<ApiResult<bool>> SubscribeAsync(Guid userId, CreateSubscriptionRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> UnsubscribeAsync(Guid userId, string channel, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
