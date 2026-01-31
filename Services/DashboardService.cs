using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class DashboardService : IDashboardService
{
    public Task<ApiResult<DashboardDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<DashboardDto>(new DashboardDto(id, "Dashboard", Guid.Empty, null, false, DateTime.UtcNow)));

    public Task<PagedResult<DashboardDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<DashboardDto>(Array.Empty<DashboardDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateDashboardRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateDashboardRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<DashboardWidgetDto>> GetWidgetsAsync(Guid dashboardId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<DashboardWidgetDto>(Array.Empty<DashboardWidgetDto>()));

    public Task<ApiResult<bool>> SetWidgetsAsync(Guid dashboardId, IEnumerable<DashboardWidgetDto> widgets, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<WidgetDataDto>> GetWidgetDataAsync(Guid dashboardId, Guid widgetId, WidgetDataRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<WidgetDataDto>(new WidgetDataDto(new { }, null)));
}
