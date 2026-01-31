using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceSchedulesController(IMaintenanceScheduleService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<MaintenanceScheduleDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<MaintenanceScheduleDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? assetId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, assetId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateMaintenanceScheduleRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateMaintenanceScheduleRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("{id:guid}/enable")]
    public Task<ApiResult<bool>> Enable(Guid id, CancellationToken ct) => service.EnableAsync(id, ct);

    [HttpPost("{id:guid}/disable")]
    public Task<ApiResult<bool>> Disable(Guid id, CancellationToken ct) => service.DisableAsync(id, ct);

    [HttpGet("{scheduleId:guid}/work-orders")]
    public Task<ApiListResult<WorkOrderDto>> GetGeneratedWorkOrders(Guid scheduleId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetGeneratedWorkOrdersAsync(scheduleId, from, to, ct);
}
