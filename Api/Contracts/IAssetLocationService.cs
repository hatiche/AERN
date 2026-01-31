using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Asset locations and sites.</summary>
public interface IAssetLocationService
{
    Task<ApiResult<AssetLocationDto>> GetByIdAsync(string id, CancellationToken ct = default);
    Task<PagedResult<AssetLocationDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? parentId, CancellationToken ct = default);
    Task<ApiListResult<AssetLocationDto>> GetChildrenAsync(string parentId, CancellationToken ct = default);
    Task<ApiResult<AssetLocationDto>> CreateAsync(CreateAssetLocationRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(string id, UpdateAssetLocationRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(string id, CancellationToken ct = default);
    Task<ApiListResult<AssetLocationDto>> GetByTenantAsync(Guid tenantId, CancellationToken ct = default);
}

public record AssetLocationDto(string Id, string Name, string? ParentId, Guid TenantId, string? Address);
public record CreateAssetLocationRequest(string Name, string? ParentId, Guid TenantId, string? Address);
public record UpdateAssetLocationRequest(string? Name, string? Address);
