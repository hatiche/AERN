using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Webhook endpoints and deliveries.</summary>
public interface IWebhookService
{
    Task<ApiResult<WebhookDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<WebhookDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? eventType, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateWebhookRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateWebhookRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<WebhookDeliveryDto>> GetDeliveryAsync(Guid webhookId, Guid deliveryId, CancellationToken ct = default);
    Task<ApiResult<bool>> RetryDeliveryAsync(Guid webhookId, Guid deliveryId, CancellationToken ct = default);
}

public record WebhookDto(Guid Id, string Url, string EventType, bool IsEnabled, Guid TenantId, string? Secret, DateTime CreatedAt);
public record CreateWebhookRequest(string Url, string EventType, Guid TenantId, string? Secret);
public record UpdateWebhookRequest(string? Url, string? Secret);
public record WebhookDeliveryDto(Guid Id, Guid WebhookId, int StatusCode, DateTime SentAt, string? Response, string? Error);
