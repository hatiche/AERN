using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/energy")]
public class EnergyController(IEnergyConsumptionService service) : ControllerBase
{
    [HttpGet("assets/{assetId:guid}/meters/{meterId}/latest")]
    public Task<ApiResult<EnergyReadingDto>> GetLatest(Guid assetId, string meterId, CancellationToken ct) => service.GetLatestAsync(assetId, meterId, ct);

    [HttpGet("assets/{assetId:guid}/meters/{meterId}/readings")]
    public Task<PagedResult<EnergyReadingDto>> GetReadings(Guid assetId, string meterId, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int page = 1, [FromQuery] int pageSize = 100, CancellationToken ct = default) =>
        service.GetReadingsAsync(assetId, meterId, from, to, new PagingRequest(page, pageSize), ct);

    [HttpGet("tenant/{tenantId:guid}/summary")]
    public Task<ApiResult<EnergySummaryDto>> GetSummary(Guid tenantId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetSummaryAsync(tenantId, from, to, ct);

    [HttpGet("tenant/{tenantId:guid}/carbon-footprint")]
    public Task<ApiResult<CarbonFootprintDto>> GetCarbonFootprint(Guid tenantId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetCarbonFootprintAsync(tenantId, from, to, ct);

    [HttpPost("readings/ingest")]
    public Task<ApiResult<bool>> Ingest([FromBody] IngestEnergyReadingRequest request, CancellationToken ct) => service.IngestReadingAsync(request, ct);
}
