using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Parts catalog and definitions.</summary>
public interface IInventoryPartService
{
    Task<ApiResult<PartDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<PartDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? category, CancellationToken ct = default);
    Task<ApiListResult<PartDto>> SearchAsync(string query, Guid tenantId, int limit, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreatePartRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdatePartRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<PartDto>> GetByCategoryAsync(Guid tenantId, string category, CancellationToken ct = default);
    Task<ApiResult<PartStockSummaryDto>> GetStockSummaryAsync(Guid partId, CancellationToken ct = default);
}

public record PartDto(Guid Id, string Sku, string Name, string? Category, Guid TenantId, string? Unit);
public record CreatePartRequest(string Sku, string Name, string? Category, Guid TenantId, string? Unit);
public record UpdatePartRequest(string? Name, string? Category, string? Unit);
public record PartStockSummaryDto(int TotalQuantity, int ReservedQuantity, int AvailableQuantity);
