using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Recurring maintenance schedules.</summary>
public interface IMaintenanceScheduleService
{
    Task<ApiResult<MaintenanceScheduleDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<MaintenanceScheduleDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateMaintenanceScheduleRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateMaintenanceScheduleRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<WorkOrderDto>> GetGeneratedWorkOrdersAsync(Guid scheduleId, DateTime from, DateTime to, CancellationToken ct = default);
}

public record MaintenanceScheduleDto(Guid Id, string Name, Guid AssetId, string CronExpression, bool IsEnabled, Guid TenantId, DateTime? NextRunAt);
public record CreateMaintenanceScheduleRequest(string Name, Guid AssetId, string CronExpression, Guid TenantId);
public record UpdateMaintenanceScheduleRequest(string? Name, string? CronExpression);
