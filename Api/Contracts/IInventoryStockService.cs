using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Stock levels and movements.</summary>
public interface IInventoryStockService
{
    Task<ApiResult<StockLevelDto>> GetByPartAndLocationAsync(Guid partId, string locationId, CancellationToken ct = default);
    Task<PagedResult<StockLevelDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? partId, string? locationId, CancellationToken ct = default);
    Task<ApiResult<bool>> AdjustAsync(AdjustStockRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> ReserveAsync(ReserveStockRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> ReleaseReservationAsync(Guid reservationId, CancellationToken ct = default);
    Task<PagedResult<StockMovementDto>> GetMovementsAsync(Guid partId, string locationId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiListResult<StockLevelDto>> GetByPartAsync(Guid partId, CancellationToken ct = default);
    Task<ApiResult<StockLevelDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
}

public record StockLevelDto(Guid Id, Guid PartId, string LocationId, int Quantity, int ReservedQuantity, Guid TenantId);
public record StockMovementDto(Guid Id, Guid PartId, string LocationId, int Delta, string Reason, DateTime At);
public record AdjustStockRequest(Guid PartId, string LocationId, int Delta, string Reason, Guid TenantId);
public record ReserveStockRequest(Guid PartId, string LocationId, int Quantity, string ReferenceId, Guid TenantId);
