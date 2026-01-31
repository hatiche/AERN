using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Dashboards and widgets.</summary>
public interface IDashboardService
{
    Task<ApiResult<DashboardDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<DashboardDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateDashboardRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateDashboardRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiListResult<DashboardWidgetDto>> GetWidgetsAsync(Guid dashboardId, CancellationToken ct = default);
    Task<ApiResult<bool>> SetWidgetsAsync(Guid dashboardId, IEnumerable<DashboardWidgetDto> widgets, CancellationToken ct = default);
    Task<ApiResult<WidgetDataDto>> GetWidgetDataAsync(Guid dashboardId, Guid widgetId, WidgetDataRequest request, CancellationToken ct = default);
}

public record DashboardDto(Guid Id, string Name, Guid TenantId, Guid? OwnerId, bool IsDefault, DateTime CreatedAt);
public record CreateDashboardRequest(string Name, Guid TenantId, Guid? OwnerId, bool IsDefault);
public record UpdateDashboardRequest(string? Name, bool? IsDefault);
public record DashboardWidgetDto(Guid Id, string Type, string? Title, int Row, int Col, int Width, int Height, string? ConfigJson);
public record WidgetDataRequest(DateTime? From, DateTime? To, IReadOnlyDictionary<string, object?>? Parameters);
public record WidgetDataDto(object Data, DateTime? CachedAt);
