using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class FieldCheckInService : IFieldCheckInService
{
    public Task<ApiResult<CheckInDto>> CheckInAsync(CheckInRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<CheckInDto>(new CheckInDto(Guid.NewGuid(), request.UserId, request.LocationId, request.AssetId, DateTime.UtcNow, null, request.Notes)));

    public Task<ApiResult<bool>> CheckOutAsync(Guid checkInId, CheckOutRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<CheckInDto>> GetActiveCheckInAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<CheckInDto>(new CheckInDto(Guid.NewGuid(), userId, "loc-1", null, DateTime.UtcNow, null, null)));

    public Task<PagedResult<CheckInDto>> GetCheckInHistoryAsync(Guid userId, DateTime from, DateTime to, PagingRequest paging, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<CheckInDto>(Array.Empty<CheckInDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<SyncResultDto>> SubmitOfflineBatchAsync(Guid userId, IEnumerable<OfflineCheckInPayload> payloads, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<SyncResultDto>(new SyncResultDto(0, 0, Array.Empty<string>())));

    public Task<ApiListResult<CheckInDto>> GetByLocationAsync(string locationId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<CheckInDto>(Array.Empty<CheckInDto>()));
}
