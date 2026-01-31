using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController(IAssetService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<AssetDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<AssetDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? parentId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, parentId, ct);

    [HttpGet("{parentId:guid}/children")]
    public Task<ApiListResult<AssetDto>> GetChildren(Guid parentId, CancellationToken ct) => service.GetChildrenAsync(parentId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateAssetRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateAssetRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{id:guid}/hierarchy")]
    public Task<ApiResult<AssetHierarchyDto>> GetHierarchy(Guid id, [FromQuery] int depth = 5, CancellationToken ct = default) => service.GetHierarchyAsync(id, depth, ct);

    [HttpPost("{assetId:guid}/move")]
    public Task<ApiResult<bool>> Move(Guid assetId, [FromBody] Guid? newParentId, CancellationToken ct) => service.MoveAsync(assetId, newParentId, ct);

    [HttpGet("search")]
    public Task<ApiListResult<AssetDto>> Search([FromQuery] string q, [FromQuery] Guid? tenantId = null, [FromQuery] int limit = 20, CancellationToken ct = default) => service.SearchAsync(q, tenantId, limit, ct);

    [HttpGet("{id:guid}/health")]
    public Task<ApiResult<AssetHealthDto>> GetHealth(Guid id, CancellationToken ct) => service.GetHealthAsync(id, ct);
}
