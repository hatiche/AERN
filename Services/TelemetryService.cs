using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class TelemetryService : ITelemetryService
{
    public Task<ApiResult<bool>> IngestAsync(IngestTelemetryRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<TelemetryReadingDto>> GetLatestAsync(Guid assetId, string metricKey, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TelemetryReadingDto>(new TelemetryReadingDto(assetId, metricKey, 0.0, DateTime.UtcNow)));

    public Task<PagedResult<TelemetryReadingDto>> GetReadingsAsync(Guid assetId, string metricKey, DateTime from, DateTime to, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<TelemetryReadingDto>(Array.Empty<TelemetryReadingDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<string>> GetMetricKeysAsync(Guid assetId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<string>(Array.Empty<string>()));

    public Task<ApiResult<TelemetryAggregateDto>> GetAggregateAsync(Guid assetId, string metricKey, DateTime from, DateTime to, string aggregation, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TelemetryAggregateDto>(new TelemetryAggregateDto(metricKey, 0, 0, 0, 0, 0)));

    public Task<ApiResult<bool>> IngestBatchAsync(IEnumerable<IngestTelemetryRequest> requests, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<TelemetryReadingDto>> GetMultiAssetLatestAsync(IEnumerable<Guid> assetIds, string metricKey, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<TelemetryReadingDto>(Array.Empty<TelemetryReadingDto>()));

    public Task<ApiResult<TelemetrySummaryDto>> GetSummaryAsync(Guid assetId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TelemetrySummaryDto>(new TelemetrySummaryDto(new Dictionary<string, TelemetryAggregateDto>())));
}
