using AERN.Api.Contracts.Segments;
using AERN.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AERN.Controllers.Segments;

[ApiController]
[Route("api/segments/shifts")]
public class ShiftsController(IShiftService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public Task<ApiResult<ShiftDto>> GetById(Guid id, CancellationToken ct) => service.GetByIdAsync(id, ct);

    [HttpGet]
    public Task<PagedResult<ShiftDto>> GetPage([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] Guid? tenantId = null, [FromQuery] Guid? userId = null, [FromQuery] DateTime? from = null, [FromQuery] DateTime? to = null, [FromQuery] string? sortBy = null, [FromQuery] bool sortDesc = false, CancellationToken ct = default) =>
        service.GetPageAsync(new PagingRequest(page, pageSize, sortBy, sortDesc), tenantId, userId, from, to, ct);

    [HttpPost]
    public Task<IdResult> Create([FromBody] CreateShiftRequest request, CancellationToken ct) => service.CreateAsync(request, ct);

    [HttpPut("{id:guid}")]
    public Task<ApiResult<bool>> Update(Guid id, [FromBody] UpdateShiftRequest request, CancellationToken ct) => service.UpdateAsync(id, request, ct);

    [HttpDelete("{id:guid}")]
    public Task<ApiResult<bool>> Delete(Guid id, CancellationToken ct) => service.DeleteAsync(id, ct);

    [HttpPut("{shiftId:guid}/assign")]
    public Task<ApiResult<bool>> Assign(Guid shiftId, [FromQuery] Guid userId, CancellationToken ct) => service.AssignUserAsync(shiftId, userId, ct);

    [HttpGet("user/{userId:guid}")]
    public Task<ApiListResult<ShiftDto>> GetUserShifts(Guid userId, [FromQuery] DateTime from, [FromQuery] DateTime to, CancellationToken ct) =>
        service.GetUserShiftsAsync(userId, from, to, ct);
}
