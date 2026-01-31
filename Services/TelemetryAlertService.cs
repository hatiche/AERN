using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class TelemetryAlertService : ITelemetryAlertService
{
    public Task<ApiResult<TelemetryAlertDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<TelemetryAlertDto>(new TelemetryAlertDto(id, Guid.Empty, "temp", "gt", 100, true, Guid.Empty)));

    public Task<PagedResult<TelemetryAlertDto>> GetPageAsync(PagingRequest paging, Guid? assetId, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<TelemetryAlertDto>(Array.Empty<TelemetryAlertDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiListResult<TelemetryAlertDto>> GetActiveByAssetAsync(Guid assetId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<TelemetryAlertDto>(Array.Empty<TelemetryAlertDto>()));

    public Task<IdResult> CreateAsync(CreateTelemetryAlertRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateTelemetryAlertRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> EnableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DisableAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<PagedResult<TelemetryAlertEventDto>> GetEventsAsync(Guid alertId, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<TelemetryAlertEventDto>(Array.Empty<TelemetryAlertEventDto>(), 0, paging.Page, paging.PageSize));
}
