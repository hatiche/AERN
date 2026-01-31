using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelemetryController(ITelemetryService service) : ControllerBase
{
    [HttpPost("ingest")]
    public Task<ApiResult<bool>> Ingest([FromBody] IngestTelemetryRequest request, CancellationToken ct) => service.IngestAsync(request, ct);

    [HttpPost("ingest/batch")]
    public Task<ApiResult<bool>> IngestBatch([FromBody] IEnumerable<IngestTelemetryRequest> requests, CancellationToken ct) => service.IngestBatchAsync(requests, ct);

    [HttpGet("assets/{assetId:guid}/latest")]
    public Task<ApiResult<TelemetryReadingDto>> GetLatest(Guid assetId, [FromQuery] string metricKey, CancellationToken ct) => service.GetLatestAsync(assetId, metricKey, ct);

    [HttpGet("assets/{assetId:guid}/readings")]
    public Task<PagedResult<TelemetryReadingDto>> GetReadings(Guid assetId, [FromQuery] string metricKey, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int page = 1, [FromQuery] int pageSize = 100, CancellationToken ct = default) =>
        service.GetReadingsAsync(assetId, metricKey, from, to, new PagingRequest(page, pageSize), ct);

    [HttpGet("assets/{assetId:guid}/metrics")]
    public Task<ApiListResult<string>> GetMetricKeys(Guid assetId, CancellationToken ct) => service.GetMetricKeysAsync(assetId, ct);

    [HttpGet("assets/{assetId:guid}/aggregate")]
    public Task<ApiResult<TelemetryAggregateDto>> GetAggregate(Guid assetId, [FromQuery] string metricKey, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string aggregation, CancellationToken ct) =>
        service.GetAggregateAsync(assetId, metricKey, from, to, aggregation, ct);

    [HttpPost("assets/latest")]
    public Task<ApiListResult<TelemetryReadingDto>> GetMultiAssetLatest([FromBody] IEnumerable<Guid> assetIds, [FromQuery] string metricKey, CancellationToken ct) =>
        service.GetMultiAssetLatestAsync(assetIds, metricKey, ct);

    [HttpGet("assets/{assetId:guid}/summary")]
    public Task<ApiResult<TelemetrySummaryDto>> GetSummary(Guid assetId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetSummaryAsync(assetId, from, to, ct);
}
