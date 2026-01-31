using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardsController(IDashboardService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<DashboardDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<DashboardDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? userId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, userId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateDashboardRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateDashboardRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{dashboardId:guid}/widgets")]
    public Task<ApiListResult<DashboardWidgetDto>> GetWidgets(Guid dashboardId, CancellationToken ct) => service.GetWidgetsAsync(dashboardId, ct);

    [HttpPut("{dashboardId:guid}/widgets")]
    public Task<ApiResult<bool>> SetWidgets(Guid dashboardId, [FromBody] IEnumerable<DashboardWidgetDto> widgets, CancellationToken ct) => service.SetWidgetsAsync(dashboardId, widgets, ct);

    [HttpGet("{dashboardId:guid}/widgets/{widgetId:guid}/data")]
    public Task<ApiResult<WidgetDataDto>> GetWidgetData(Guid dashboardId, Guid widgetId, [FromQuery] DateTime? from, [FromQuery] DateTime? to, CancellationToken ct = default) =>
        service.GetWidgetDataAsync(dashboardId, widgetId, new WidgetDataRequest(from, to, null), ct);
}
