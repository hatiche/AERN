using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Predictive Maintenance – failure risk and recommendations.</summary>
public interface IPredictiveMaintenanceService
{
    Task<ApiResult<AssetRiskDto>> GetAssetRiskAsync(Guid assetId, CancellationToken ct = default);
    Task<ApiListResult<AssetRiskDto>> GetHighRiskAssetsAsync(Guid tenantId, int limit, CancellationToken ct = default);
    Task<ApiResult<MaintenanceRecommendationDto>> GetRecommendationAsync(Guid assetId, CancellationToken ct = default);
    Task<PagedResult<PredictionEventDto>> GetPredictionHistoryAsync(Guid assetId, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<bool>> DismissRecommendationAsync(Guid recommendationId, string? reason, CancellationToken ct = default);
}

public record AssetRiskDto(Guid AssetId, string RiskLevel, double Score, string? PrimaryFactor, DateTime CalculatedAt);
public record MaintenanceRecommendationDto(Guid Id, Guid AssetId, string Action, string? Reason, DateTime? SuggestedBy, int Priority);
public record PredictionEventDto(Guid Id, Guid AssetId, string EventType, double Confidence, DateTime OccurredAt);
