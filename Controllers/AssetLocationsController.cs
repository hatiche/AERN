using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetLocationsController(IAssetLocationService service) : ControllerBase
{
    [HttpGet("{id}")]
    public Task<ApiResult<AssetLocationDto>> GetById(string id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<AssetLocationDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? parentId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, parentId, ct);

    [HttpGet("{parentId}/children")]
    public Task<ApiListResult<AssetLocationDto>> GetChildren(string parentId, CancellationToken ct) => service.GetChildrenAsync(parentId, ct);

    [HttpPost]
    public Task<ApiResult<AssetLocationDto>> Create([FromBody] CreateAssetLocationRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id}")]
    public Task<ApiResult<bool>> Update(string id, [FromBody] UpdateAssetLocationRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id}")]
    public Task<ApiResult<bool>> Delete(string id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("tenant/{tenantId:guid}")]
    public Task<ApiListResult<AssetLocationDto>> GetByTenant(Guid tenantId, CancellationToken ct) => service.GetByTenantAsync(tenantId, ct);
}
