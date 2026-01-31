using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController(ISearchService service) : ControllerBase
{
    [HttpPost]
    public Task<ApiResult<SearchResultDto>> Search([FromBody] SearchRequest request, CancellationToken ct) => service.SearchAsync(request, ct);

    [HttpGet("assets")]
    public Task<ApiResult<SearchResultDto>> SearchAssets([FromQuery] string q, [FromQuery] Guid? tenantId = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.SearchAssetsAsync(q, tenantId, new PagingRequest(page, pageSize, sortBy, sortDesc), ct);

    [HttpGet("documents")]
    public Task<ApiResult<SearchResultDto>> SearchDocuments([FromQuery] string q, [FromQuery] Guid? tenantId = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.SearchDocumentsAsync(q, tenantId, new PagingRequest(page, pageSize, sortBy, sortDesc), ct);

    [HttpGet("users")]
    public Task<ApiResult<SearchResultDto>> SearchUsers([FromQuery] string q, [FromQuery] Guid? tenantId = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.SearchUsersAsync(q, tenantId, new PagingRequest(page, pageSize, sortBy, sortDesc), ct);

    [HttpPost("index")]
    public Task<ApiResult<bool>> IndexEntity([FromQuery] string entityType, [FromQuery] Guid entityId, [FromBody] object payload, CancellationToken ct) =>
        service.IndexEntityAsync(entityType, entityId, payload, ct);

    [HttpDelete("index")]
    public Task<ApiResult<bool>> RemoveFromIndex([FromQuery] string entityType, [FromQuery] Guid entityId, CancellationToken ct) =>
        service.RemoveFromIndexAsync(entityType, entityId, ct);

    [HttpPost("reindex")]
    public Task<ApiResult<bool>> Reindex([FromQuery] string? entityType, [FromQuery] Guid? tenantId, CancellationToken ct) =>
        service.ReindexAsync(entityType, tenantId, ct);

    [HttpGet("suggestions")]
    public Task<ApiListResult<string>> GetSuggestions([FromQuery] string prefix, [FromQuery] string? entityType = null, [FromQuery] int limit = 10, CancellationToken ct = default) =>
        service.GetSuggestionsAsync(prefix, entityType, limit, ct);
}
