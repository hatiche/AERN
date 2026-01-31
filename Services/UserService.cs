using AERN.Api.Contracts;
using AERN.Api.Models;

namespace AERN.Services;

public sealed class UserService : IUserService
{
    public Task<ApiResult<UserDto>> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<UserDto>(new UserDto(id, "user@example.com", "User", false, Guid.Empty, DateTime.UtcNow)));

    public Task<PagedResult<UserDto>> GetPageAsync(PagingRequest paging, Guid? tenantId, CancellationToken ct = default) =>
        Task.FromResult(new PagedResult<UserDto>(Array.Empty<UserDto>(), 0, paging.Page, paging.PageSize));

    public Task<ApiResult<UserDto>> GetByEmailAsync(string email, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<UserDto>(new UserDto(Guid.NewGuid(), email, null, false, Guid.Empty, DateTime.UtcNow)));

    public Task<IdResult> CreateAsync(CreateUserRequest request, CancellationToken ct = default) =>
        Task.FromResult(new IdResult(Guid.NewGuid()));

    public Task<ApiResult<bool>> UpdateAsync(Guid id, UpdateUserRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> DeleteAsync(Guid id, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> SetPasswordAsync(Guid userId, SetPasswordRequest request, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> LockAsync(Guid userId, DateTime? until, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiResult<bool>> UnlockAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));

    public Task<ApiListResult<RoleDto>> GetRolesAsync(Guid userId, CancellationToken ct = default) =>
        Task.FromResult(new ApiListResult<RoleDto>(Array.Empty<RoleDto>()));

    public Task<ApiResult<bool>> AssignRolesAsync(Guid userId, IEnumerable<Guid> roleIds, CancellationToken ct = default) =>
        Task.FromResult(new ApiResult<bool>(true));
}
