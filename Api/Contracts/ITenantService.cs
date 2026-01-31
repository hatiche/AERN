using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Multi-tenant management: tenants, settings, quotas.</summary>
public interface ITenantService
{
    Task<ApiResult<TenantDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<TenantDto>> GetPageAsync(PagingRequest paging, CancellationToken ct = default);
    Task<ApiListResult<TenantDto>> GetAllAsync(CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateTenantRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateTenantRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<TenantSettingsDto>> GetSettingsAsync(Guid tenantId, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateSettingsAsync(Guid tenantId, TenantSettingsDto settings, CancellationToken ct = default);
    Task<ApiResult<TenantQuotaDto>> GetQuotaAsync(Guid tenantId, CancellationToken ct = default);
    Task<ApiResult<bool>> SetQuotaAsync(Guid tenantId, TenantQuotaDto quota, CancellationToken ct = default);
}

public record TenantDto(Guid Id, string Name, string Slug, bool IsActive, DateTime CreatedAt);
public record CreateTenantRequest(string Name, string Slug);
public record UpdateTenantRequest(string? Name, bool? IsActive);
public record TenantSettingsDto(string TimeZone, string Locale, string? Theme);
public record TenantQuotaDto(int MaxUsers, int MaxAssets, long StorageBytes);
