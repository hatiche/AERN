using AERN.Api.Contracts.Segments;
using AERN.Api.Models;

namespace AERN.Services.Segments;

public sealed class ShiftService : IShiftService
{
    public Task<ApiResult<ShiftDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<ShiftDto>(new ShiftDto(id, "Morning", DateTime.UtcNow.Date, DateTime.UtcNow.Date.AddHours(8), null, Guid.Empty, "Scheduled")));

    public Task<PagedResult<ShiftDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, DateTime? from, DateTime? to, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<ShiftDto>(Array.Empty<ShiftDto>(), 0, paging.Page, paging.PageSize));

    public Task<IdResult> CreateAsync(CreateShiftRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateShiftRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> AssignUserAsync(Guid shiftId, Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<ShiftDto>> GetUserShiftsAsync(Guid userId, DateTime from, DateTime to, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<ShiftDto>(Array.Empty<ShiftDto>()));
}
