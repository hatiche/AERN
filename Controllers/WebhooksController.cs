using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WebhooksController(IWebhookService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<WebhookDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<WebhookDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? eventType = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, eventType, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateWebhookRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateWebhookRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPost("{id:guid}/enable")]
    public Task<ApiResult<bool>> Enable(Guid id, CancellationToken ct) => service.EnableAsync(id, ct);

    [HttpPost("{id:guid}/disable")]
    public Task<ApiResult<bool>> Disable(Guid id, CancellationToken ct) => service.DisableAsync(id, ct);

    [HttpGet("{webhookId:guid}/deliveries/{deliveryId:guid}")]
    public Task<ApiResult<WebhookDeliveryDto>> GetDelivery(Guid webhookId, Guid deliveryId, CancellationToken ct) => service.GetDeliveryAsync(webhookId, deliveryId, ct);

    [HttpPost("{webhookId:guid}/deliveries/{deliveryId:guid}/retry")]
    public Task<ApiResult<bool>> RetryDelivery(Guid webhookId, Guid deliveryId, CancellationToken ct) => service.RetryDeliveryAsync(webhookId, deliveryId, ct);
}
