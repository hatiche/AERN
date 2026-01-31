using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class AssetLocationService : IAssetLocationService
{
    public Task<ApiResult<AssetLocationDto>> GetByIdAsync(string id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetLocationDto>(new AssetLocationDto(id, "Location", null, Guid.Empty, null)));

    public Task<PagedResult<AssetLocationDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? parentId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<AssetLocationDto>(Array.Empty<AssetLocationDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<AssetLocationDto>> GetChildrenAsync(string parentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetLocationDto>(Array.Empty<AssetLocationDto>()));

    public Task<ApiResult<AssetLocationDto>> CreateAsync(CreateAssetLocationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetLocationDto>(new AssetLocationDto(Guid.NewGuid().ToString("N")[..8], request.Name, request.ParentId, request.TenantId, request.Address)));

    public Task<ApiResult<bool>> UpdateAsync(string id, UpdateAssetLocationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(string id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<AssetLocationDto>> GetByTenantAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetLocationDto>(Array.Empty<AssetLocationDto>()));
}
