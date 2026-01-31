using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class WebhookService : IWebhookService
{
    public Task<ApiResult<WebhookDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<WebhookDto>(new WebhookDto(id, "https://example.com", "asset.created", true, Guid.Empty, null, DateTime.UtcNow)));

    public Task<PagedResult<WebhookDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? eventType, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<WebhookDto>(Array.Empty<WebhookDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateWebhookRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateWebhookRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<WebhookDeliveryDto>> GetDeliveryAsync(Guid webhookId, Guid deliveryId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<WebhookDeliveryDto>(new WebhookDeliveryDto(deliveryId, webhookId, 200, DateTime.UtcNow, null, null)));

    public Task<ApiResult<bool>> RetryDeliveryAsync(Guid webhookId, Guid deliveryId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
