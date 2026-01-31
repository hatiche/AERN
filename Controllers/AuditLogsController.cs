using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditLogsController(IAuditLogService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<AuditLogDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<AuditLogDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? userId = null, [FromQuery] string? entityType = null, [FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, userId, entityType, from, to, ct);

    [HttpGet("entity/{entityType}/{entityId:guid}")]
    public Task<ApiListResult<AuditLogDto>> GetByEntity(string entityType, Guid entityId, [FromQuery] int limit = 50, CancellationToken ct = default) =>
        service.GetByEntityAsync(entityType, entityId, limit, ct);

    [HttpPost("export")]
    public async Task<IActionResult> Export([FromBody] ExportAuditRequest request, CancellationToken ct)
    {
        await using var ms = new MemoryStream();
        var result = await service.ExportAsync(request, ms, ct);
        if (!result.Success) return BadRequest(result);
        ms.Position = 0;
        return File(ms.ToArray(), "application/octet-stream", "audit-export.csv");
    }

    [HttpGet("tenant/{tenantId:guid}/summary")]
    public Task<ApiResult<AuditSummaryDto>> GetSummary(Guid tenantId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetSummaryAsync(tenantId, from, to, ct);

    [HttpPost("archive")]
    public Task<ApiResult<bool>> Archive([FromQuery] DateTime before, [FromQuery] string destinationPath, CancellationToken ct) =>
        service.ArchiveAsync(before, destinationPath, ct);
}
