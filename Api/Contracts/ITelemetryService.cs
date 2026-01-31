using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Real-time telemetry readings and metrics.</summary>
public interface ITelemetryService
{
    Task<ApiResult<bool>> IngestAsync(IngestTelemetryRequest request, CancellationToken ct = default);
    Task<ApiResult<TelemetryReadingDto>> GetLatestAsync(Guid assetId, string metricKey, CancellationToken ct = default);
    Task<PagedResult<TelemetryReadingDto>> GetReadingsAsync(Guid assetId, string metricKey, DateTime from, DateTime to, PagingRequest paging, CancellationToken ct = default);
    Task<ApiListResult<string>> GetMetricKeysAsync(Guid assetId, CancellationToken ct = default);
    Task<ApiResult<TelemetryAggregateDto>> GetAggregateAsync(Guid assetId, string metricKey, DateTime from, DateTime to, string aggregation, CancellationToken ct = default);
    Task<ApiResult<bool>> IngestBatchAsync(IEnumerable<IngestTelemetryRequest> requests, CancellationToken ct = default);
    Task<ApiListResult<TelemetryReadingDto>> GetMultiAssetLatestAsync(IEnumerable<Guid> assetIds, string metricKey, CancellationToken ct = default);
    Task<ApiResult<TelemetrySummaryDto>> GetSummaryAsync(Guid assetId, DateTime from, DateTime to, CancellationToken ct = default);
}

public record TelemetryReadingDto(Guid AssetId, string MetricKey, object Value, DateTime TimestampUtc);
public record TelemetryAggregateDto(string MetricKey, double? Min, double? Max, double? Avg, double? Sum, int Count);
public record TelemetrySummaryDto(IReadOnlyDictionary<string, TelemetryAggregateDto> ByMetric);
public record IngestTelemetryRequest(Guid AssetId, string MetricKey, object Value, DateTime? TimestampUtc);
