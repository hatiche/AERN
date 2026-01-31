using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController(IReportService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<ReportDefinitionDto>> GetById(Guid id, CancellationToken ct) => service.GetReportByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<ReportDefinitionDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetReportsPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, ct);

    [HttpPost("{reportId:guid}/run")]
    public Task<ApiResult<ReportResultDto>> Run(Guid reportId, [FromBody] ReportParameters parameters, CancellationToken ct) => service.RunReportAsync(reportId, parameters, ct);

    [HttpGet("{reportId:guid}/export")]
    public Task<ApiResult<Stream>> Export(Guid reportId, [FromQuery] string format, [FromBody] ReportParameters? parameters, CancellationToken ct) =>
        service.ExportReportAsync(reportId, parameters ?? new ReportParameters(new Dictionary<string, object?>()), format, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateReportRequest request, CancellationToken ct) => service.CreateReportAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateReportRequest request, CancellationToken ct) => service.UpdateReportAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteReportAsync(id, ct);

    [HttpGet("user/{userId:guid}/favorites")]
    public Task<ApiListResult<ReportDefinitionDto>> GetFavorites(Guid userId, CancellationToken ct) => service.GetFavoritesAsync(userId, ct);

    [HttpPost("{reportId:guid}/schedule")]
    public Task<ApiResult<bool>> Schedule(Guid reportId, [FromBody] ScheduleReportRequest schedule, CancellationToken ct) => service.ScheduleReportAsync(reportId, schedule, ct);

    [HttpGet("{reportId:guid}/history")]
    public Task<PagedResult<ReportRunHistoryDto>> GetRunHistory(Guid reportId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetRunHistoryAsync(reportId, new PagingRequest(page, pageSize), ct);
}
