using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class TenantService : ITenantService
{
    public Task<ApiResult<TenantDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TenantDto>(new TenantDto(id, "Tenant", "tenant", true, DateTime.UtcNow)));

    public Task<PagedResult<TenantDto>> GetPageAsync(PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<TenantDto>(Array.Empty<TenantDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<TenantDto>> GetAllAsync(CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<TenantDto>(Array.Empty<TenantDto>()));

    public Task<IdResult> CreateAsync(CreateTenantRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateTenantRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<TenantSettingsDto>> GetSettingsAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TenantSettingsDto>(new TenantSettingsDto("UTC", "en", null)));

    public Task<ApiResult<bool>> UpdateSettingsAsync(Guid tenantId, TenantSettingsDto settings, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<TenantQuotaDto>> GetQuotaAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TenantQuotaDto>(new TenantQuotaDto(100, 1000, 1_000_000_000)));

    public Task<ApiResult<bool>> SetQuotaAsync(Guid tenantId, TenantQuotaDto quota, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
