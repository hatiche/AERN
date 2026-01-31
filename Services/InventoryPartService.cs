using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class InventoryPartService : IInventoryPartService
{
    public Task<ApiResult<PartDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PartDto>(new PartDto(id, "SKU", "Part", null, Guid.Empty, null)));

    public Task<PagedResult<PartDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? category, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<PartDto>(Array.Empty<PartDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<PartDto>> SearchAsync(string query, Guid tenantId, int limit, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<PartDto>(Array.Empty<PartDto>()));

    public Task<IdResult> CreateAsync(CreatePartRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdatePartRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<PartDto>> GetByCategoryAsync(Guid tenantId, string category, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<PartDto>(Array.Empty<PartDto>()));

    public Task<ApiResult<PartStockSummaryDto>> GetStockSummaryAsync(Guid partId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PartStockSummaryDto>(new PartStockSummaryDto(0, 0, 0)));
}
