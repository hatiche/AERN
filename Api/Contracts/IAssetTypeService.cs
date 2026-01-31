using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Asset type definitions.</summary>
public interface IAssetTypeService
{
    Task<ApiResult<AssetTypeDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<AssetTypeDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default);
    Task<ApiListResult<AssetTypeDto>> GetAllByTenantAsync(Guid tenantId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateAssetTypeRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateAssetTypeRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<AssetTypeAttributeDto>> GetAttributesAsync(Guid assetTypeId, CancellationToken ct = default);
    Task<ApiResult<bool>> SetAttributesAsync(Guid assetTypeId, IEnumerable<AssetTypeAttributeDto> attributes, CancellationToken ct = default);
}

public record AssetTypeDto(Guid Id, string Name, string? Description, Guid TenantId);
public record CreateAssetTypeRequest(string Name, string? Description, Guid TenantId);
public record UpdateAssetTypeRequest(string? Name, string? Description);
public record AssetTypeAttributeDto(string Key, string Type, bool Required);
