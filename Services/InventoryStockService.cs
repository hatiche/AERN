using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class InventoryStockService : IInventoryStockService
{
    public Task<ApiResult<StockLevelDto>> GetByPartAndLocationAsync(Guid partId, string locationId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<StockLevelDto>(new StockLevelDto(Guid.NewGuid(), partId, locationId, 0, 0, Guid.Empty)));

    public Task<PagedResult<StockLevelDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? partId, string? locationId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<StockLevelDto>(Array.Empty<StockLevelDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<bool>> AdjustAsync(AdjustStockRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> ReserveAsync(ReserveStockRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> ReleaseReservationAsync(Guid reservationId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<PagedResult<StockMovementDto>> GetMovementsAsync(Guid partId, string locationId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<StockMovementDto>(Array.Empty<StockMovementDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<StockLevelDto>> GetByPartAsync(Guid partId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<StockLevelDto>(Array.Empty<StockLevelDto>()));

    public Task<ApiResult<StockLevelDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<StockLevelDto>(new StockLevelDto(id, Guid.Empty, "", 0, 0, Guid.Empty)));
}
