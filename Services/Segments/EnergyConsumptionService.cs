using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class EnergyConsumptionService : IEnergyConsumptionService
{
    public Task<ApiResult<EnergyReadingDto>> GetLatestAsync(Guid assetId, string meterId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<EnergyReadingDto>(new EnergyReadingDto(assetId, meterId, 0, "kWh", DateTime.UtcNow)));

    public Task<PagedResult<EnergyReadingDto>> GetReadingsAsync(Guid assetId, string meterId, DateTime from, DateTime to, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<EnergyReadingDto>(Array.Empty<EnergyReadingDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<EnergySummaryDto>> GetSummaryAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<EnergySummaryDto>(new EnergySummaryDto(0, 0, 0, new Dictionary<string, double>())));

    public Task<ApiResult<CarbonFootprintDto>> GetCarbonFootprintAsync(Guid tenantId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<CarbonFootprintDto>(new CarbonFootprintDto(0, "ISO", Array.Empty<CarbonSourceDto>())));

    public Task<ApiResult<bool>> IngestReadingAsync(IngestEnergyReadingRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
