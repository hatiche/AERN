using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelemetryAlertsController(ITelemetryAlertService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<TelemetryAlertDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<TelemetryAlertDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? assetId = null, [FromQuery] Guid? tenantId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), assetId, tenantId, ct);

    [HttpGet("asset/{assetId:guid}/active")]
    public Task<ApiListResult<TelemetryAlertDto>> GetActiveByAsset(Guid assetId, CancellationToken ct) => service.GetActiveByAssetAsync(assetId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateTelemetryAlertRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateTelemetryAlertRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("{id:guid}/enable")]
    public Task<ApiResult<bool>> Enable(Guid id, CancellationToken ct) => service.EnableAsync(id, ct);

    [HttpPost("{id:guid}/disable")]
    public Task<ApiResult<bool>> Disable(Guid id, CancellationToken ct) => service.DisableAsync(id, ct);

    [HttpGet("{alertId:guid}/events")]
    public Task<PagedResult<TelemetryAlertEventDto>> GetEvents(Guid alertId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetEventsAsync(alertId, new PagingRequest(page, pageSize), ct);
}
