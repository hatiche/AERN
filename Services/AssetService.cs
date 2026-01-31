using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class AssetService : IAssetService
{
    public Task<ApiResult<AssetDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetDto>(new AssetDto(id, "Asset", null, null, Guid.Empty, Guid.Empty, null, DateTime.UtcNow)));

    public Task<PagedResult<AssetDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? parentId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<AssetDto>(Array.Empty<AssetDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<AssetDto>> GetChildrenAsync(Guid parentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetDto>(Array.Empty<AssetDto>()));

    public Task<IdResult> CreateAsync(CreateAssetRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateAssetRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<AssetHierarchyDto>> GetHierarchyAsync(Guid id, int depth, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetHierarchyDto>(new AssetHierarchyDto(
            new AssetDto(id, "Asset", null, null, Guid.Empty, Guid.Empty, null, DateTime.UtcNow), null)));

    public Task<ApiResult<bool>> MoveAsync(Guid assetId, Guid? newParentId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<AssetDto>> SearchAsync(string query, Guid? tenantId, int limit, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetDto>(Array.Empty<AssetDto>()));

    public Task<ApiResult<AssetHealthDto>> GetHealthAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetHealthDto>(new AssetHealthDto("Ok", 99.9, DateTime.UtcNow)));
}
