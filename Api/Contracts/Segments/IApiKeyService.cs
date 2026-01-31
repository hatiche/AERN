using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: API Keys &amp; Clients – API key and client app management.</summary>
public interface IApiKeyService
{
    Task<ApiResult<ApiKeyDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<ApiKeyDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? clientId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateApiKeyRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> RevokeAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> RotateAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<ApiKeyDto>> GetByKeyHashAsync(string keyPrefix, CancellationToken ct = default);
    Task<ApiListResult<ApiClientDto>> GetClientsAsync(Guid tenantId, CancellationToken ct = default);
    Task<IdResult> CreateClientAsync(CreateApiClientRequest request, CancellationToken ct = default);
}

public record ApiKeyDto(Guid Id, Guid ClientId, string KeyPrefix, DateTime CreatedAt, DateTime? ExpiresAt, bool IsActive);
public record CreateApiKeyRequest(Guid ClientId, string? Name, DateTime? ExpiresAt);
public record ApiClientDto(Guid Id, string Name, string? ClientId, Guid TenantId, DateTime CreatedAt);
public record CreateApiClientRequest(string Name, Guid TenantId, string? Description);
