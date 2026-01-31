using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Maintenance work orders.</summary>
public interface IMaintenanceWorkOrderService
{
    Task<ApiResult<WorkOrderDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<WorkOrderDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetId, string? status, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateWorkOrderRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateWorkOrderRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> AssignAsync(Guid id, Guid? assignedToUserId, CancellationToken ct = default);
    Task<ApiResult<bool>> StartAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> CompleteAsync(Guid id, CompleteWorkOrderRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> CancelAsync(Guid id, string? reason, CancellationToken ct = default);
    Task<ApiListResult<WorkOrderDto>> GetByAssetAsync(Guid assetId, DateTime? from, DateTime? to, CancellationToken ct = default);
}

public record WorkOrderDto(Guid Id, string Title, string Status, Guid AssetId, Guid TenantId, Guid? AssignedToId, DateTime? DueDate, DateTime CreatedAt);
public record CreateWorkOrderRequest(string Title, Guid AssetId, Guid TenantId, DateTime? DueDate, string? Description);
public record UpdateWorkOrderRequest(string? Title, DateTime? DueDate, string? Description);
public record CompleteWorkOrderRequest(string? Notes, TimeSpan? ActualDuration);
