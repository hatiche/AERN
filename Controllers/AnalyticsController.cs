using AERN.Api.Contracts;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController(IAnalyticsService service) : ControllerBase
{
    [HttpGet("asset/{assetId:guid}")]
    public Task<ApiResult<AnalyticsSummaryDto>> GetAssetAnalytics(Guid assetId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetAssetAnalyticsAsync(assetId, from, to, ct);

    [HttpGet("tenant/{tenantId:guid}")]
    public Task<ApiResult<AnalyticsSummaryDto>> GetTenantAnalytics(Guid tenantId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetTenantAnalyticsAsync(tenantId, from, to, ct);

    [HttpGet("asset/{assetId:guid}/timeseries")]
    public Task<ApiResult<TimeSeriesDto>> GetTimeSeries(Guid assetId, [FromQuery] string metricKey, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] string interval, CancellationToken ct) =>
        service.GetTimeSeriesAsync(assetId, metricKey, from, to, interval, ct);

    [HttpGet("tenant/{tenantId:guid}/top-assets")]
    public Task<ApiListResult<TopAssetDto>> GetTopAssets(Guid tenantId, [FromQuery] string metricKey, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int top = 10, CancellationToken ct = default) =>
        service.GetTopAssetsByMetricAsync(tenantId, metricKey, from, to, top, ct);

    [HttpPost("aggregate")]
    public Task<ApiResult<AggregationDto>> GetAggregation([FromBody] AggregationRequest request, CancellationToken ct) => service.GetAggregationAsync(request, ct);

    [HttpGet("tenant/{tenantId:guid}/storage-usage")]
    public Task<ApiResult<UsageDto>> GetStorageUsage(Guid tenantId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetStorageUsageAsync(tenantId, from, to, ct);

    [HttpGet("tenant/{tenantId:guid}/api-usage")]
    public Task<ApiResult<UsageDto>> GetApiUsage(Guid tenantId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetApiUsageAsync(tenantId, from, to, ct);

    [HttpGet("events")]
    public Task<PagedResult<AnalyticsEventDto>> GetEvents([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] string? eventType = null, [FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetEventsAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, eventType, from, to, ct);
}
