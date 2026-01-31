using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController(IAdminService service) : ControllerBase
{
    [HttpPost("bulk")]
    public Task<ApiResult<BulkOperationDto>> StartBulk([FromBody] BulkOperationRequest request, CancellationToken ct) => service.StartBulkOperationAsync(request, ct);

    [HttpGet("bulk/{id:guid}")]
    public Task<ApiResult<BulkOperationDto>> GetBulk(Guid id, CancellationToken ct) => service.GetBulkOperationAsync(id, ct);

    [HttpGet("bulk")]
    public Task<PagedResult<BulkOperationDto>> GetBulkPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, CancellationToken ct = default) =>
        service.GetBulkOperationsPageAsync(new PagingRequest(page, pageSize), tenantId, ct);

    [HttpPost("bulk/{id:guid}/cancel")]
    public Task<ApiResult<bool>> CancelBulk(Guid id, CancellationToken ct) => service.CancelBulkOperationAsync(id, ct);

    [HttpGet("stats")]
    public Task<ApiResult<SystemStatsDto>> GetSystemStats(CancellationToken ct) => service.GetSystemStatsAsync(ct);

    [HttpGet("tenant/{tenantId:guid}/stats")]
    public Task<ApiResult<TenantStatsDto>> GetTenantStats(Guid tenantId, CancellationToken ct) => service.GetTenantStatsAsync(tenantId, ct);

    [HttpPost("cache/clear")]
    public Task<ApiResult<bool>> ClearCache([FromQuery] string? keyPrefix, CancellationToken ct) => service.ClearCacheAsync(keyPrefix, ct);

    [HttpPost("reindex")]
    public Task<ApiResult<bool>> Reindex([FromQuery] string indexName, CancellationToken ct) => service.ReindexAsync(indexName, ct);

    [HttpPost("migration")]
    public Task<ApiResult<bool>> RunMigration([FromQuery] string migrationName, CancellationToken ct) => service.RunMigrationAsync(migrationName, ct);

    [HttpPost("export")]
    public Task<ApiResult<AdminExportJobDto>> StartExport([FromBody] DataExportRequest request, CancellationToken ct) => service.StartDataExportAsync(request, ct);

    [HttpGet("export/{jobId:guid}")]
    public Task<ApiResult<AdminExportJobDto>> GetExportJob(Guid jobId, CancellationToken ct) => service.GetExportJobAsync(jobId, ct);

    [HttpPost("audit/purge")]
    public Task<ApiResult<bool>> PurgeAudit(Guid tenantId, [FromQuery] DateTime before, CancellationToken ct) => service.PurgeAuditLogsAsync(tenantId, before, ct);
}
