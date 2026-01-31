using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class PredictiveMaintenanceService : IPredictiveMaintenanceService
{
    public Task<ApiResult<AssetRiskDto>> GetAssetRiskAsync(Guid assetId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<AssetRiskDto>(new AssetRiskDto(assetId, "Low", 0.2, null, DateTime.UtcNow)));

    public Task<ApiListResult<AssetRiskDto>> GetHighRiskAssetsAsync(Guid tenantId, int limit, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<AssetRiskDto>(Array.Empty<AssetRiskDto>()));

    public Task<ApiResult<MaintenanceRecommendationDto>> GetRecommendationAsync(Guid assetId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<MaintenanceRecommendationDto>(new MaintenanceRecommendationDto(Guid.NewGuid(), assetId, "Inspect", null, DateTime.UtcNow.AddDays(7), 1)));

    public Task<PagedResult<PredictionEventDto>> GetPredictionHistoryAsync(Guid assetId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<PredictionEventDto>(Array.Empty<PredictionEventDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<bool>> DismissRecommendationAsync(Guid recommendationId, string? reason, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
