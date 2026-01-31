using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Industrial assets CRUD and hierarchy.</summary>
public interface IAssetService
{
    Task<ApiResult<AssetDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<AssetDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? parentId, CancellationToken ct = default);
    Task<ApiListResult<AssetDto>> GetChildrenAsync(Guid parentId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateAssetRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateAssetRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<AssetHierarchyDto>> GetHierarchyAsync(Guid id, int depth, CancellationToken ct = default);
    Task<ApiResult<bool>> MoveAsync(Guid assetId, Guid? newParentId, CancellationToken ct = default);
    Task<ApiListResult<AssetDto>> SearchAsync(string query, Guid? tenantId, int limit, CancellationToken ct = default);
    Task<ApiResult<AssetHealthDto>> GetHealthAsync(Guid id, CancellationToken ct = default);
}

public record AssetDto(Guid Id, string Name, string? SerialNumber, Guid? ParentId, Guid TenantId, Guid AssetTypeId, string? LocationId, DateTime CreatedAt);
public record CreateAssetRequest(string Name, string? SerialNumber, Guid? ParentId, Guid TenantId, Guid AssetTypeId, string? LocationId);
public record UpdateAssetRequest(string? Name, string? SerialNumber, string? LocationId);
public record AssetHierarchyDto(AssetDto Asset, IReadOnlyList<AssetHierarchyDto>? Children);
public record AssetHealthDto(string Status, double? UptimePercent, DateTime? LastMaintenance);
