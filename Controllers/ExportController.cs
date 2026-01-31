using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExportController(IExportService service) : ControllerBase
{
    [HttpPost]
    public Task<ApiResult<ExportJobDto>> Start([FromBody] StartExportRequest request, CancellationToken ct) => service.StartExportAsync(request, ct);

    [HttpGet("{jobId:guid}")]
    public Task<ApiResult<ExportJobDto>> GetJob(Guid jobId, CancellationToken ct) => service.GetExportJobAsync(jobId, ct);

    [HttpGet]
    public Task<PagedResult<ExportJobDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? userId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetExportJobsPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, userId, ct);

    [HttpGet("{jobId:guid}/download")]
    public Task<ApiResult<Stream>> Download(Guid jobId, CancellationToken ct) => service.DownloadExportAsync(jobId, ct);

    [HttpPost("{jobId:guid}/cancel")]
    public Task<ApiResult<bool>> Cancel(Guid jobId, CancellationToken ct) => service.CancelExportAsync(jobId, ct);

    [HttpDelete("{jobId:guid}")]
    public Task<ApiResult<bool>> Delete(Guid jobId, CancellationToken ct) => service.DeleteExportAsync(jobId, ct);

    [HttpGet("templates/tenant/{tenantId:guid}")]
    public Task<ApiListResult<ExportTemplateDto>> GetTemplates(Guid tenantId, CancellationToken ct) => service.GetTemplatesAsync(tenantId, ct);

    [HttpPost("templates")]
    public Task<IdResult> CreateTemplate([FromBody] CreateExportTemplateRequest request, CancellationToken ct) => service.CreateTemplateAsync(request, ct);
}
