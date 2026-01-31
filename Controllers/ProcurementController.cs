using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProcurementController(IProcurementService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<PurchaseOrderDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<PurchaseOrderDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? status = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, status, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreatePurchaseOrderRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdatePurchaseOrderRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpPost("{id:guid}/submit")]
    public Task<ApiResult<bool>> Submit(Guid id, CancellationToken ct) => service.SubmitAsync(id, ct);

    [HttpPost("{id:guid}/approve")]
    public Task<ApiResult<bool>> Approve(Guid id, [FromQuery] Guid approverId, [FromQuery] string? comment, CancellationToken ct) =>
        service.ApproveAsync(id, approverId, comment, ct);

    [HttpPost("{id:guid}/reject")]
    public Task<ApiResult<bool>> Reject(Guid id, [FromQuery] Guid approverId, [FromBody] string reason, CancellationToken ct) =>
        service.RejectAsync(id, approverId, reason, ct);

    [HttpPost("{id:guid}/cancel")]
    public Task<ApiResult<bool>> Cancel(Guid id, [FromQuery] string? reason, CancellationToken ct) => service.CancelAsync(id, reason, ct);

    [HttpGet("{orderId:guid}/lines")]
    public Task<ApiListResult<PurchaseOrderLineDto>> GetLines(Guid orderId, CancellationToken ct) => service.GetLinesAsync(orderId, ct);
}
