using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/predictive-maintenance")]
public class PredictiveMaintenanceController(IPredictiveMaintenanceService service) : ControllerBase
{
    [HttpGet("assets/{assetId:guid}/risk")]
    public Task<ApiResult<AssetRiskDto>> GetAssetRisk(Guid assetId, CancellationToken ct) => service.GetAssetRiskAsync(assetId, ct);

    [HttpGet("assets/high-risk")]
    public Task<ApiListResult<AssetRiskDto>> GetHighRisk([FromQuery] Guid tenantId, [FromQuery] int limit = 20, CancellationToken ct = default) => service.GetHighRiskAssetsAsync(tenantId, limit, ct);

    [HttpGet("assets/{assetId:guid}/recommendation")]
    public Task<ApiResult<MaintenanceRecommendationDto>> GetRecommendation(Guid assetId, CancellationToken ct) => service.GetRecommendationAsync(assetId, ct);

    [HttpGet("assets/{assetId:guid}/history")]
    public Task<PagedResult<PredictionEventDto>> GetHistory(Guid assetId, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetPredictionHistoryAsync(assetId, new PagingRequest(page, pageSize), ct);

    [HttpPost("recommendations/{recommendationId:guid}/dismiss")]
    public Task<ApiResult<bool>> Dismiss(Guid recommendationId, [FromQuery] string? reason, CancellationToken ct) => service.DismissRecommendationAsync(recommendationId, reason, ct);
}
