using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class ProcurementService : IProcurementService
{
    public Task<ApiResult<PurchaseOrderDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<PurchaseOrderDto>(new PurchaseOrderDto(id, "PO-001", "Draft", Guid.Empty, null, null, DateTime.UtcNow)));

    public Task<PagedResult<PurchaseOrderDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, string? status, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<PurchaseOrderDto>(Array.Empty<PurchaseOrderDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreatePurchaseOrderRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdatePurchaseOrderRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> SubmitAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> ApproveAsync(Guid id, Guid approverId, string? comment, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> RejectAsync(Guid id, Guid approverId, string reason, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> CancelAsync(Guid id, string? reason, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<PurchaseOrderLineDto>> GetLinesAsync(Guid orderId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<PurchaseOrderLineDto>(Array.Empty<PurchaseOrderLineDto>()));
}
