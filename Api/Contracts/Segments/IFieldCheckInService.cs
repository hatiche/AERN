using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Field / Mobile – field worker check-in and offline sync.</summary>
public interface IFieldCheckInService
{
    Task<ApiResult<CheckInDto>> CheckInAsync(CheckInRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> CheckOutAsync(Guid checkInId, CheckOutRequest request, CancellationToken ct = default);
    Task<ApiResult<CheckInDto>> GetActiveCheckInAsync(Guid userId, CancellationToken ct = default);
    Task<PagedResult<CheckInDto>> GetCheckInHistoryAsync(Guid userId, DateTime from, DateTime to, PagingRequest paging, CancellationToken ct = default);
    Task<ApiResult<SyncResultDto>> SubmitOfflineBatchAsync(Guid userId, IEnumerable<OfflineCheckInPayload> payloads, CancellationToken ct = default);
    Task<ApiListResult<CheckInDto>> GetByLocationAsync(string locationId, DateTime from, DateTime to, CancellationToken ct = default);
}

public record CheckInDto(Guid Id, Guid UserId, string LocationId, Guid? AssetId, DateTime CheckedInAt, DateTime? CheckedOutAt, string? Notes);
public record CheckInRequest(Guid UserId, string LocationId, Guid? AssetId, double? Latitude, double? Longitude, string? Notes);
public record CheckOutRequest(string? Notes);
public record SyncResultDto(int Accepted, int Rejected, IReadOnlyList<string> Errors);
public record OfflineCheckInPayload(string LocationId, Guid? AssetId, DateTime CheckedInAt, DateTime? CheckedOutAt, double? Lat, double? Lon);
