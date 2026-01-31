using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>External integrations and webhooks.</summary>
public interface IIntegrationService
{
    Task<ApiResult<IntegrationDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<IntegrationDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? type, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateIntegrationRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateIntegrationRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<IntegrationTestResultDto>> TestAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<IntegrationDeliveryDto>> GetWebhookDeliveriesAsync(Guid webhookId, PagingRequest paging, CancellationToken ct = default);
}

public record IntegrationDto(Guid Id, string Name, string Type, bool IsEnabled, Guid TenantId, DateTime CreatedAt);
public record CreateIntegrationRequest(string Name, string Type, string? ConfigJson, Guid TenantId);
public record UpdateIntegrationRequest(string? Name, string? ConfigJson);
public record IntegrationTestResultDto(bool Success, string? Message, int? StatusCode);
public record IntegrationDeliveryDto(Guid Id, Guid WebhookId, int StatusCode, DateTime SentAt, string? Response);
