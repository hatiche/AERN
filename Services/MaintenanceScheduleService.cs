using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class MaintenanceScheduleService : IMaintenanceScheduleService
{
    public Task<ApiResult<MaintenanceScheduleDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<MaintenanceScheduleDto>(new MaintenanceScheduleDto(id, "Schedule", Guid.Empty, "0 0 * * *", true, Guid.Empty, DateTime.UtcNow)));

    public Task<PagedResult<MaintenanceScheduleDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? assetId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<MaintenanceScheduleDto>(Array.Empty<MaintenanceScheduleDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateMaintenanceScheduleRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateMaintenanceScheduleRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<WorkOrderDto>> GetGeneratedWorkOrdersAsync(Guid scheduleId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<WorkOrderDto>(Array.Empty<WorkOrderDto>()));
}
