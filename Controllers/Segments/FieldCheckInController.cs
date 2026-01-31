using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/field")]
public class FieldCheckInController(IFieldCheckInService service) : ControllerBase
{
    [HttpPost("check-in")]
    public Task<ApiResult<CheckInDto>> CheckIn([FromBody] CheckInRequest request, CancellationToken ct) => service.CheckInAsync(request, ct);

    [HttpPost("check-in/{checkInId:guid}/check-out")]
    public Task<ApiResult<bool>> CheckOut(Guid checkInId, [FromBody] CheckOutRequest request, CancellationToken ct) =>
        service.CheckOutAsync(checkInId, request, ct);

    [HttpGet("user/{userId:guid}/active")]
    public Task<ApiResult<CheckInDto>> GetActive(Guid userId, CancellationToken ct) => service.GetActiveCheckInAsync(userId, ct);

    [HttpGet("user/{userId:guid}/history")]
    public Task<PagedResult<CheckInDto>> GetHistory(Guid userId, [FromQuery] DateTime from, [FromQuery] DateTime to, [FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken ct = default) =>
        service.GetCheckInHistoryAsync(userId, from, to, new PagingRequest(page, pageSize), ct);

    [HttpPost("user/{userId:guid}/sync")]
    public Task<ApiResult<SyncResultDto>> SubmitOfflineBatch(Guid userId, [FromBody] IEnumerable<OfflineCheckInPayload> payloads, CancellationToken ct) =>
        service.SubmitOfflineBatchAsync(userId, payloads, ct);

    [HttpGet("location/{locationId}")]
    public Task<ApiListResult<CheckInDto>> GetByLocation(string locationId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetByLocationAsync(locationId, from, to, ct);
}