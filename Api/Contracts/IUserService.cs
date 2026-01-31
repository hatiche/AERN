using AERN.Api.Models;

namespace AERN.Api.Contracts;

/// <summary>Identity: users CRUD and profile.</summary>
public interface IUserService
{
    Task<ApiResult<UserDto>> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<PagedResult<UserDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default);
    Task<ApiResult<UserDto>> GetByEmailAsync(string email, CancellationToken ct = default);
    Task<IdResult> CreateAsync(CreateUserRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default);
    Task<ApiResult<bool>> SetPasswordAsync(Guid userId, SetPasswordRequest request, CancellationToken ct = default);
    Task<ApiResult<bool>> LockAsync(Guid userId, DateTime? until, CancellationToken ct = default);
    Task<ApiResult<bool>> UnlockAsync(Guid userId, CancellationToken ct = default);
    Task<ApiListResult<RoleDto>> GetRolesAsync(Guid userId, CancellationToken ct = default);
    Task<ApiResult<bool>> AssignRolesAsync(Guid userId, IEnumerable<Guid> roleIds, CancellationToken ct = default);
}

public record UserDto(Guid Id, string Email, string? DisplayName, bool IsLocked, Guid TenantId, DateTime CreatedAt);
public record CreateUserRequest(string Email, string? DisplayName, Guid TenantId);
public record UpdateUserRequest(string? DisplayName);
public record SetPasswordRequest(string Password);
