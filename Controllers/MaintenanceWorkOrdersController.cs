using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceWorkOrdersController : ControllerBase
{
    private readonly IMaintenanceWorkOrderService _service;

    public MaintenanceWorkOrdersController(IMaintenanceWorkOrderService service) => _service = service;

    [HttpGet("{id:guid}")]
    public Task<ApiResult<WorkOrderDto>> GetById(Guid id, CancellationToken ct) => _service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<WorkOrderDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? assetId = null, [FromQuery] string? status = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        _service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, assetId, status, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateWorkOrderRequest request, CancellationToken ct) => _service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateWorkOrderRequest request, CancellationToken ct) => _service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => _service.DeleteAsync(id, ct);

    [HttpPut("{id:guid}/assign")]
    public Task<ApiResult<bool>> Assign(Guid id, [FromQuery] Guid? assignedToUserId, CancellationToken ct) => _service.AssignAsync(id, assignedToUserId, ct);

    [HttpPost("{id:guid}/start")]
    public Task<ApiResult<bool>> Start(Guid id, CancellationToken ct) => _service.StartAsync(id, ct);

    [HttpPost("{id:guid}/complete")]
    public Task<ApiResult<bool>> Complete(Guid id, [FromBody] CompleteWorkOrderRequest request, CancellationToken ct) => _service.CompleteAsync(id, request, ct);

    [HttpPost("{id:guid}/cancel")]
    public Task<ApiResult<bool>> Cancel(Guid id, [FromQuery] string? reason, CancellationToken ct) => _service.CancelAsync(id, reason, ct);

    [HttpGet("asset/{assetId:guid}")]
    public Task<ApiListResult<WorkOrderDto>> GetByAsset(Guid assetId, [FromQuery] DateTime? from, [FromQuery] DateTime? to, CancellationToken ct = default) =>
        _service.GetByAssetAsync(assetId, from, to, ct);
}
