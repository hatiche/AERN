using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryPartsController(IInventoryPartService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<PartDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<PartDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? category = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, category, ct);

    [HttpGet("search")]
    public Task<ApiListResult<PartDto>> Search([FromQuery] string q, [FromQuery] Guid tenantId, [FromQuery] int limit = 20, CancellationToken ct = default) => service.SearchAsync(q, tenantId, limit, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreatePartRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdatePartRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("tenant/{tenantId:guid}/category/{category}")]
    public Task<ApiListResult<PartDto>> GetByCategory(Guid tenantId, string category, CancellationToken ct) => service.GetByCategoryAsync(tenantId, category, ct);

    [HttpGet("{partId:guid}/stock-summary")]
    public Task<ApiResult<PartStockSummaryDto>> GetStockSummary(Guid partId, CancellationToken ct) => service.GetStockSummaryAsync(partId, ct);
}
