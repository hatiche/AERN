using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController(IDocumentService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<DocumentDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<DocumentDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? assetId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, assetId, ct);

    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IdResult> Create([FromForm] CreateDocumentRequest request, IFormFile? file, CancellationToken ct)
    {
        var stream = file?.OpenReadStream() ?? Stream.Null;
        var contentType = file?.ContentType ?? "application/octet-stream";
        return await service.CreateAsync(request, stream, contentType, ct);
    }

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateDocumentRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpGet("{id:guid}/content")]
    public Task<ApiResult<DocumentContentDto>> GetContent(Guid id, CancellationToken ct) => service.GetContentAsync(id, ct);

    [HttpGet("{id:guid}/versions/{version:int}")]
    public Task<ApiResult<DocumentDto>> GetVersion(Guid id, int version, CancellationToken ct) => service.GetVersionAsync(id, version, ct);

    [HttpGet("{id:guid}/versions")]
    public Task<ApiListResult<DocumentVersionDto>> GetVersions(Guid id, CancellationToken ct) => service.GetVersionsAsync(id, ct);

    [HttpPost("{id:guid}/checkout")]
    public Task<ApiResult<bool>> CheckOut(Guid id, [FromQuery] Guid userId, CancellationToken ct) => service.CheckOutAsync(id, userId, ct);

    [HttpPost("{id:guid}/checkin")]
    public async Task<ApiResult<bool>> CheckIn(Guid id, IFormFile? file, CancellationToken ct)
    {
        var stream = file?.OpenReadStream();
        return await service.CheckInAsync(id, stream, ct);
    }
}
