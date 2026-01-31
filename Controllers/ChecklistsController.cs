using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChecklistsController(IChecklistService service) : ControllerBase
{
    [HttpGet("templates/{id:guid}")]
    public Task<ApiResult<ChecklistTemplateDto>> GetTemplateById(Guid id, CancellationToken ct) => service.GetTemplateByIdAsync(id, ct);

    [HttpGet("templates")]
    public Task<PagedResult<ChecklistTemplateDto>> GetTemplatesPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? assetTypeId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetTemplatesPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, assetTypeId, ct);

    [HttpPost("templates")]
    public Task<IdResult> CreateTemplate([FromBody] CreateChecklistTemplateRequest request, CancellationToken ct) => service.CreateTemplateAsync(request, ct);

    [HttpPut("templates/{id:guid}")]
    public Task<ApiResult<bool>> UpdateTemplate(Guid id, [FromBody] UpdateChecklistTemplateRequest request, CancellationToken ct) => service.UpdateTemplateAsync(id, request, ct);

    [HttpDelete("templates/{id:guid}")]
    public Task<ApiResult<bool>> DeleteTemplate(Guid id, CancellationToken ct) => service.DeleteTemplateAsync(id, ct);

    [HttpGet("instances/{id:guid}")]
    public Task<ApiResult<ChecklistInstanceDto>> GetInstanceById(Guid id, CancellationToken ct) => service.GetInstanceByIdAsync(id, ct);

    [HttpPost("instances")]
    public Task<IdResult> CreateInstance([FromBody] CreateChecklistInstanceRequest request, CancellationToken ct) => service.CreateInstanceAsync(request, ct);

    [HttpPost("instances/{instanceId:guid}/items/{itemId:guid}/complete")]
    public Task<ApiResult<bool>> CompleteItem(Guid instanceId, Guid itemId, [FromBody] CompleteChecklistItemRequest request, CancellationToken ct) =>
        service.CompleteItemAsync(instanceId, itemId, request, ct);

    [HttpPost("instances/{instanceId:guid}/complete")]
    public Task<ApiResult<bool>> CompleteInstance(Guid instanceId, CancellationToken ct) => service.CompleteInstanceAsync(instanceId, ct);

    [HttpGet("work-order/{workOrderId:guid}/instances")]
    public Task<PagedResult<ChecklistInstanceDto>> GetInstancesByWorkOrder(Guid workOrderId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetInstancesByWorkOrderAsync(workOrderId, new PagingRequest(page, pageSize), ct);
}
