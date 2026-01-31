using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Analytics and aggregations.</summary>
public interface IAnalyticsService
{
    Task<ApiResult<AnalyticsSummaryDto>> GetAssetAnalyticsAsync(Guid assetId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<ApiResult<AnalyticsSummaryDto>> GetTenantAnalyticsAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<ApiResult<TimeSeriesDto>> GetTimeSeriesAsync(Guid assetId, string metricKey, DateTime from, DateTime to, string interval, CancellationToken ct = default);
    Task<ApiListResult<TopAssetDto>> GetTopAssetsByMetricAsync(Guid tenantId, string metricKey, DateTime from, DateTime to, int top, CancellationToken ct = default);
    Task<ApiResult<AggregationDto>> GetAggregationAsync(AggregationRequest request, CancellationToken ct = default);
    Task<ApiResult<UsageDto>> GetStorageUsageAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<ApiResult<UsageDto>> GetApiUsageAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<PagedResult<AnalyticsEventDto>> GetEventsAsync(PagingRequest paging, Guid? tenantId, string? eventType, DateTime? from, DateTime? to, CancellationToken ct = default);
}

public record AnalyticsSummaryDto(IReadOnlyDictionary<string, double> Metrics, int SampleCount);
public record TimeSeriesDto(IReadOnlyList<TimeSeriesPointDto> Points);
public record TimeSeriesPointDto(DateTime Timestamp, double Value);
public record TopAssetDto(Guid AssetId, string Name, double Value);
public record AggregationRequest(Guid? TenantId, Guid? AssetId, string MetricKey, DateTime From, DateTime To, string Aggregation);
public record AggregationDto(string MetricKey, double Value, int Count);
public record UsageDto(long Total, IReadOnlyList<UsagePointDto> ByPeriod);
public record UsagePointDto(DateTime PeriodStart, long Value);
public record AnalyticsEventDto(Guid Id, string EventType, Guid? EntityId, Guid TenantId, DateTime TimestampUtc, string? Payload);
