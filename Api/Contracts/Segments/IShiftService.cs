using AERN.Api.Models;

namespace AERN.Api.Contracts.Segments;

/// <summary>Segment: Workforce &amp; Shifts – shift plans and labor assignments.</summary>
public interface IShiftService
{
    Task<ApiResult<ShiftDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<ShiftDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, Guid? userId, DateTime? from, DateTime? to, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateShiftRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateShiftRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> AssignUserAsync(Guid shiftId, Guid userId, CancellationToken ct = default);
    Task<ApiListResult<ShiftDto>> GetUserShiftsAsync(Guid userId, DateTime from, DateTime to, CancellationToken ct = default);
}

public record ShiftDto(Guid Id, string Name, DateTime StartUtc, DateTime EndUtc, Guid? AssignedUserId, Guid TenantId, string Status);
public record CreateShiftRequest(string Name, DateTime StartUtc, DateTime EndUtc, Guid TenantId, Guid? AssignedUserId);
public record UpdateShiftRequest(string? Name, DateTime? StartUtc, DateTime? EndUtc, Guid? AssignedUserId);
