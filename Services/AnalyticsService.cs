using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class AnalyticsService : IAnalyticsService
{
    public Task<ApiResult<AnalyticsSummaryDto>> GetAssetAnalyticsAsync(Guid assetId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AnalyticsSummaryDto>(new AnalyticsSummaryDto(new Dictionary<string, double>(), 0)));

    public Task<ApiResult<AnalyticsSummaryDto>> GetTenantAnalyticsAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AnalyticsSummaryDto>(new AnalyticsSummaryDto(new Dictionary<string, double>(), 0)));

    public Task<ApiResult<TimeSeriesDto>> GetTimeSeriesAsync(Guid assetId, string metricKey, DateTime from, DateTime to, string interval, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TimeSeriesDto>(new TimeSeriesDto(Array.Empty<TimeSeriesPointDto>())));

    public Task<ApiListResult<TopAssetDto>> GetTopAssetsByMetricAsync(Guid tenantId, string metricKey, DateTime from, DateTime to, int top, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<TopAssetDto>(Array.Empty<TopAssetDto>()));

    public Task<ApiResult<AggregationDto>> GetAggregationAsync(AggregationRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AggregationDto>(new AggregationDto(request.MetricKey, 0, 0)));

    public Task<ApiResult<UsageDto>> GetStorageUsageAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<UsageDto>(new UsageDto(0, Array.Empty<UsagePointDto>())));

    public Task<ApiResult<UsageDto>> GetApiUsageAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<UsageDto>(new UsageDto(0, Array.Empty<UsagePointDto>())));

    public Task<PagedResult<AnalyticsEventDto>> GetEventsAsync(PagingRequest paging, Guid? tenantId, string? eventType, DateTime? from, DateTime? to, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<AnalyticsEventDto>(Array.Empty<AnalyticsEventDto>(), 0, paging.Page, paging.PageSize));
}
