using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class MaintenanceWorkOrderService : IMaintenanceWorkOrderService
{
    public Task<ApiResult<WorkOrderDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<WorkOrderDto>(new WorkOrderDto(id, "WO", "Open", Guid.Empty, Guid.Empty, null, null, DateTime.UtcNow)));

    public Task<PagedResult<WorkOrderDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetId, string? status, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<WorkOrderDto>(Array.Empty<WorkOrderDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateWorkOrderRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateWorkOrderRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> AssignAsync(Guid id, Guid? assignedToUserId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> StartAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> CompleteAsync(Guid id, CompleteWorkOrderRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> CancelAsync(Guid id, string? reason, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<WorkOrderDto>> GetByAssetAsync(Guid assetId, DateTime? from, DateTime? to, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<WorkOrderDto>(Array.Empty<WorkOrderDto>()));
}
