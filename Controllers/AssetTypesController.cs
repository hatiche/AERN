using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetTypesController(IAssetTypeService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<AssetTypeDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<AssetTypeDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, ct);

    [HttpGet("tenant/{tenantId:guid}")]
    public Task<ApiListResult<AssetTypeDto>> GetAllByTenant(Guid tenantId, CancellationToken ct) => service.GetAllByTenantAsync(tenantId, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateAssetTypeRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateAssetTypeRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{assetTypeId:guid}/attributes")]
    public Task<ApiListResult<AssetTypeAttributeDto>> GetAttributes(Guid assetTypeId, CancellationToken ct) => service.GetAttributesAsync(assetTypeId, ct);

    [HttpPut("{assetTypeId:guid}/attributes")]
    public Task<ApiResult<bool>> SetAttributes(Guid assetTypeId, [FromBody] IEnumerable<AssetTypeAttributeDto> attributes, CancellationToken ct) => service.SetAttributesAsync(assetTypeId, attributes, ct);
}
