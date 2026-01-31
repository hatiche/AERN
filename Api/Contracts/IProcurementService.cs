using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Procurement and purchase orders.</summary>
public interface IProcurementService
{
    Task<ApiResult<PurchaseOrderDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<PurchaseOrderDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? status, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreatePurchaseOrderRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdatePurchaseOrderRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> SubmitAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> ApproveAsync(Guid id, Guid approverId, string? comment, CancellationToken ct = default);
    Task<ApiResult<bool>> RejectAsync(Guid id, Guid approverId, string reason, CancellationToken ct = default);
    Task<ApiResult<bool>> CancelAsync(Guid id, string? reason, CancellationToken ct = default);
    Task<ApiListResult<PurchaseOrderLineDto>> GetLinesAsync(Guid orderId, CancellationToken ct = default);
}

public record PurchaseOrderDto(Guid Id, string Number, string Status, Guid TenantId, Guid? VendorId, DateTime? DueDate, DateTime CreatedAt);
public record PurchaseOrderLineDto(Guid Id, Guid PartId, int Quantity, decimal UnitPrice, string? Notes);
public record CreatePurchaseOrderRequest(Guid TenantId, Guid? VendorId, DateTime? DueDate, IEnumerable<PurchaseOrderLineDto> Lines);
public record UpdatePurchaseOrderRequest(DateTime? DueDate, IEnumerable<PurchaseOrderLineDto>? Lines);
