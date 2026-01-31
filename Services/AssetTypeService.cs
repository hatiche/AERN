using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class AssetTypeService : IAssetTypeService
{
    public Task<ApiResult<AssetTypeDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetTypeDto>(new AssetTypeDto(id, "Type", null, Guid.Empty)));

    public Task<PagedResult<AssetTypeDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<AssetTypeDto>(Array.Empty<AssetTypeDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<AssetTypeDto>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetTypeDto>(Array.Empty<AssetTypeDto>()));

    public Task<IdResult> CreateAsync(CreateAssetTypeRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateAssetTypeRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<AssetTypeAttributeDto>> GetAttributesAsync(Guid assetTypeId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetTypeAttributeDto>(Array.Empty<AssetTypeAttributeDto>()));

    public Task<ApiResult<bool>> SetAttributesAsync(Guid assetTypeId, IEnumerable<AssetTypeAttributeDto> attributes, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
