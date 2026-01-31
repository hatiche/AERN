using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Energy &amp; Sustainability – consumption and carbon footprint.</summary>
public interface IEnergyConsumptionService
{
    Task<ApiResult<EnergyReadingDto>> GetLatestAsync(Guid assetId, string meterId, CancellationToken ct = default);
    Task<PagedResult<EnergyReadingDto>> GetReadingsAsync(Guid assetId, string meterId, DateTime from, DateTime to, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<EnergySummaryDto>> GetSummaryAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<ApiResult<CarbonFootprintDto>> GetCarbonFootprintAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default);
    Task<ApiResult<bool>> IngestReadingAsync(IngestEnergyReadingRequest request, CancellationToken ct = default);
}

public record EnergyReadingDto(Guid AssetId, string MeterId, double Kwh, string? Unit, DateTime TimestampUtc);
public record EnergySummaryDto(double TotalKwh, double PeakKwh, int ReadingCount, IReadOnlyDictionary<string, double> ByMeter);
public record CarbonFootprintDto(double TonnesCo2e, string Methodology, IReadOnlyList<CarbonSourceDto> Sources);
public record CarbonSourceDto(string Source, double TonnesCo2e);
public record IngestEnergyReadingRequest(Guid AssetId, string MeterId, double Kwh, string? Unit, DateTime? TimestampUtc);
