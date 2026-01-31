using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IntegrationsController(IIntegrationService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<IntegrationDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<IntegrationDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? type = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, type, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateIntegrationRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateIntegrationRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("{id:guid}/enable")]
    public Task<ApiResult<bool>> Enable(Guid id, CancellationToken ct) => service.EnableAsync(id, ct);

    [HttpPost("{id:guid}/disable")]
    public Task<ApiResult<bool>> Disable(Guid id, CancellationToken ct) => service.DisableAsync(id, ct);

    [HttpPost("{id:guid}/test")]
    public Task<ApiResult<IntegrationTestResultDto>> Test(Guid id, CancellationToken ct) => service.TestAsync(id, ct);

    [HttpGet("{webhookId:guid}/deliveries")]
    public Task<PagedResult<IntegrationDeliveryDto>> GetWebhookDeliveries(Guid webhookId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetWebhookDeliveriesAsync(webhookId, new PagingRequest(page, pageSize), ct);
}
